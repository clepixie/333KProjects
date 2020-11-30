using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

//TODO: Change this using statement to match your project
using Team1_FinalProject.DAL;
using Team1_FinalProject.Models;

//TODO: Change this namespace to match your project
namespace Team1_FinalProject.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private SignInManager<AppUser> _signInManager;
        private UserManager<AppUser> _userManager;
        private PasswordValidator<AppUser> _passwordValidator;
        private AppDbContext _context;

        public AccountController(AppDbContext appDbContext, UserManager<AppUser> userManager, SignInManager<AppUser> signIn)
        {
            _context = appDbContext;
            _userManager = userManager;
            _signInManager = signIn;
            //user manager only has one password validator
            _passwordValidator = (PasswordValidator<AppUser>)userManager.PasswordValidators.FirstOrDefault();
        }

        // GET: /Account/Register
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel rvm)
        {
            //if registration data is valid, create a new user on the database
            if (ModelState.IsValid)
            {
                //this code maps the RegisterViewModel to the AppUser domain model
                AppUser newUser = new AppUser
                {
                    UserName = rvm.Email,
                    Email = rvm.Email,
                    PhoneNumber = rvm.PhoneNumber,

                    //TODO: Add the rest of the custom user fields here
                    //FirstName is included as an example
                    FirstName = rvm.FirstName,
                    LastName = rvm.LastName,
                };

                //This code uses the UserManager object to create a new user with the specified password
                IdentityResult result = await _userManager.CreateAsync(newUser, rvm.Password);

                //If the add user operation was successful, we need to do a few more things
                if (result.Succeeded)
                {
                    //TODO: Add user to desired role. This example adds the user to the customer role
                    await _userManager.AddToRoleAsync(newUser, "Customer");

                    //NOTE: This code logs the user into the account that they just created
                    //You may or may not want to log a user in directly after they register - check
                    //the business rules!
                    Microsoft.AspNetCore.Identity.SignInResult result2 = await _signInManager.PasswordSignInAsync(rvm.Email, rvm.Password, false, lockoutOnFailure: false);

                    //Send the user to the home page
                    return RedirectToAction("Index", "Home");
                }
                else  //the add user operation didn't work, and we need to show an error message
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            //this is the sad path - something went wrong, 
            //return the user to the register page to try again
            return View(rvm);
        }

        // GET: /Account/Login
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated) //user has been redirected here from a page they're not authorized to see
            {
                return View("Error", new string[] { "Access Denied" });
            }
            _signInManager.SignOutAsync(); //this removes any old cookies hanging around
            ViewBag.ReturnUrl = returnUrl; //pass along the page the user should go back to
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel lvm, string returnUrl)
        {
            //if user forgot to include user name or password,
            //send them back to the login page to try again
            if (ModelState.IsValid == false)
            {
                return View(lvm);
            }

            //attempt to sign the user in using the SignInManager
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(lvm.Email, lvm.Password, lvm.RememberMe, lockoutOnFailure: false);

            //if the login worked, take the user to either the url
            //they requested OR the homepage if there isn't a specific url
            if (result.Succeeded)
            {
                //return ?? "/" means if returnUrl is null, substitute "/" (home)
                return Redirect(returnUrl ?? "/");
            }
            else //log in was not successful
            {
                //add an error to the model to show invalid attempt
                ModelState.AddModelError("", "Invalid login attempt.");
                //send user back to login page to try again
                return View(lvm);
            }
        }

        //GET: Account/Index
        public IActionResult Index()
        {
            IndexViewModel ivm = new IndexViewModel();

            //get user info
            String id = User.Identity.Name;
            AppUser user = _context.Users.FirstOrDefault(u => u.UserName == id);
            ViewBag.UserInfo = user;
            //populate the view model
            //(i.e. map the domain model to the view model)
            ivm.Email = user.Email;
            ivm.HasPassword = true;
            ivm.UserID = user.Id;
            ivm.UserName = user.UserName;

            //send data to the view
            return View(ivm);
        }

        private async Task<SelectList> GetAllUsers()
        {
            //Get the list of users from the database
            List<CreateForViewModel> customerList = new List<CreateForViewModel>();
            List<Int32> customerIDList = new List<Int32>();
            Int32 count = 0;
            foreach (AppUser user in _userManager.Users)
            {
                if (await _userManager.IsInRoleAsync(user, "Customer") == true) //user is in the role
                {
                    //add user to list of members
                    CreateForViewModel newcus = new CreateForViewModel();
                    newcus.SelectCustomerName = user.Email;
                    newcus.SelectCustomerID = count;
                    customerIDList.Add(count);
                    customerList.Add(newcus);
                    count += 1;
                }
            }

            //convert the list to a SelectList by calling SelectList constructor
            //MonthID and MonthName are the names of the properties on the Month class
            //MonthID is the primary key
            SelectList customerSelectList = new SelectList(customerList, "SelectCustomerID", "SelectCustomerName");

            //return the electList
            return customerSelectList;
        }

        [Authorize(Roles = "Employee")]
        [HttpGet]
        public async Task<IActionResult> Edit(Int32 customerID)
        {
            ViewBag.AllCustomers = await GetAllUsers();
            EditProfileViewModel epvm = new EditProfileViewModel();
            epvm.SelectedCustomerID = customerID;
            return View(epvm);
        }

        [Authorize(Roles = "Employee")]
        [HttpPost]
        public async Task<IActionResult> EditAsync([Bind("SelectedCustomerID")] EditProfileViewModel epvm)
        {
            List<EditProfileViewModel> customerList = new List<EditProfileViewModel>();

            foreach (AppUser edituser in _userManager.Users)
            {
                if (await _userManager.IsInRoleAsync(edituser, "Customer") == true) //user is in the role
                {
                    //add user to list of members
                    EditProfileViewModel editcus = new EditProfileViewModel();
                    editcus.SelectCustomerName = edituser.Email;
                    customerList.Add(editcus);
                }
            }
            // find the orders that match the user selected; we have to first a) get the int idx selected b) map that idx to the Email in customerList
            // c) match that to the Emails of Customers

            // finds the user that matches the selected ID
            AppUser customer = _userManager.Users.Where(u => u.Email == customerList[epvm.SelectedCustomerID].SelectCustomerName).First();
            // get list of orders belonging to that user
            //List<Order> orders = _context.Orders.Include(o => o.Tickets)
            //                            .ThenInclude(t => t.Showing)
            //                            .ThenInclude(s => s.Movie)
            //                            .Include(o => o.Tickets)
            //                            .ThenInclude(t => t.Showing)
            //                            .ThenInclude(s => s.Price).Where(o => o.Customer.UserName == customer.Email).ToList();
            
            // get user info
            String id = User.Identity.Name;
            AppUser user = _context.Users.FirstOrDefault(u => u.UserName == id);
            ViewBag.UserInfo = user;

            // set info equal to what the employee edits it as
            epvm.PhoneNumber = user.PhoneNumber;
            epvm.Address = user.Address;
            epvm.Birthdate = user.Birthdate;
            // not sure if this password stuff is right though
            epvm.Password = user.PasswordHash;
            epvm.ConfirmPassword = user.PasswordHash;

            // update the DB
            _context.Update(customer);
            await _context.SaveChangesAsync();

            // send data to the view
            return View(epvm);

        }




        //Logic for change password
        // GET: /Account/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        

        // POST: /Account/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel cpvm)
        {
            //if user forgot a field, send them back to 
            //change password page to try again
            if (ModelState.IsValid == false)
            {
                return View(cpvm);
            }

            //Find the logged in user using the UserManager
            AppUser userLoggedIn = await _userManager.FindByNameAsync(User.Identity.Name);

            //Attempt to change the password using the UserManager
            var result = await _userManager.ChangePasswordAsync(userLoggedIn, cpvm.OldPassword, cpvm.NewPassword);

            //if the attempt to change the password worked
            if (result.Succeeded)
            {
                //sign in the user with the new password
                await _signInManager.SignInAsync(userLoggedIn, isPersistent: false);

                //send the user back to the home page
                return RedirectToAction("Index", "Home");
            }
            else //attempt to change the password didn't work
            {
                //Add all the errors from the result to the model state
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                //send the user back to the change password page to try again
                return View(cpvm);
            }
        }

        //GET:/Account/AccessDenied
        public IActionResult AccessDenied(String ReturnURL)
        {
            return View("Error", new string[] { "Access is denied" });
        }

        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LogOff()
        {
            //sign the user out of the application
            _signInManager.SignOutAsync();

            //send the user back to the home page
            return RedirectToAction("Index", "Home");
        }           
    }
}