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
                    Address = rvm.Address,
                    Birthdate = rvm.Birthdate,
                    FirstName = rvm.FirstName,
                    LastName = rvm.LastName,
                };

                //This code uses the UserManager object to create a new user with the specified password
                IdentityResult result = await _userManager.CreateAsync(newUser, rvm.Password);

                //If the add user operation was successful, we need to do a few more things
                if (result.Succeeded)
                {
                    //TODO: Add user to desired role. This example adds the user to the customer role
                    await _userManager.AddToRoleAsync(newUser, rvm.RoleChoice.ToString());

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
            ivm.FirstName = user.FirstName;
            ivm.LastName = user.LastName;
            ivm.UserName = user.UserName;
            ivm.Birthdate = user.Birthdate;
            ivm.PhoneNumber = user.PhoneNumber;
            ivm.Address = user.Address;
            

            return View(ivm);
        }


        //this is a customer master list for employees
        [Authorize(Roles = "Employee, Manager")]
        public async Task<IActionResult> IndexCustomer()
        {

            //Get the list of users from the database

            List<AppUser> customers = new List<AppUser>();

            foreach (AppUser user in _userManager.Users)
            {
                if (await _userManager.IsInRoleAsync(user, "Customer") == true) //user is in the role
                {
                    customers.Add(user);
                }
            }

            return View("IndexCustomer", customers);
        }

        [Authorize(Roles = "Employee, Manager")]
        [HttpGet]
        public IActionResult EditCustomer(string email)
        {
            EditProfileViewModel newepvm = new EditProfileViewModel();
            newepvm.Email = email;
            return View(newepvm);
        }

        [Authorize(Roles = "Employee, Manager")]
        [HttpPost]
        public async Task<IActionResult> EditCustomer([Bind("Email, Address, PhoneNumber, Birthdate")] EditProfileViewModel epvm)
        {
            //List<EditProfileViewModel> customerList = new List<EditProfileViewModel>();

            //foreach (AppUser edituser in _userManager.Users)
            //{
            //    if (await _userManager.IsInRoleAsync(edituser, "Customer") == true) //user is in the role
            //    {
            //        //add user to list of members
            //        EditProfileViewModel editcus = new EditProfileViewModel();
            //        editcus.Email = epvm.Email;
            //        customerList.Add(editcus);
            //    }
            //}
            // find the orders that match the user selected; we have to first a) get the int idx selected b) map that idx to the Email in customerList
            // c) match that to the Emails of Customers

            // finds the user that matches the selected ID
            AppUser dbUsers = _context.Users.Where(u => u.Email == epvm.Email).FirstOrDefault();

            //String id = User.Identity.Name;
            //AppUser user = _context.Users.FirstOrDefault(u => u.UserName == id);
            //ViewBag.UserInfo = user;

            //// set info equal to what the employee edits it as
            //epvm.PhoneNumber = user.PhoneNumber;
            //epvm.Address = user.Address;
            //epvm.Birthdate = user.Birthdate;
            //// not sure if this password stuff is right though
            //epvm.Password = user.PasswordHash;
            //epvm.ConfirmPassword = user.PasswordHash;

            //update the properties
            if (epvm.ConfirmPassword != epvm.Password)
            {
                
                return View("Error", new String[] {"The passwords do not match." });
                
            }

            if (epvm.Address != null)
            {
                dbUsers.Address = epvm.Address;
            }
            if (epvm.PhoneNumber != null)
            {
                dbUsers.PhoneNumber = epvm.PhoneNumber;
            }

            if (epvm.Birthdate != null)
            {
                dbUsers.Birthdate = epvm.Birthdate;
            }

            if (epvm.Password != null && epvm.ConfirmPassword != null)
            {
                dbUsers.PasswordHash = epvm.Password;
                dbUsers.PasswordHash = epvm.ConfirmPassword;
            }

            // update the DB
            _context.Update(dbUsers);
            await _context.SaveChangesAsync();

            // send data to the view
            return RedirectToAction(nameof(Index));

        }

        //Logic for change password
        // GET: /Account/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }


        // GET: /Account/ChangeAddress
        [HttpGet]
        public ActionResult ChangeAddress(string email)
        {
            ChangeAddressViewModel newavm = new ChangeAddressViewModel();
            {
                newavm.Email = email;

            };

            return View(newavm);
        }

        // post change address
        [HttpPost]
        public async Task<ActionResult> ChangeAddress([Bind("Email, NewAddress")] ChangeAddressViewModel avm)
        {
            if (User.Identity.Name != avm.Email)
            {
                return View("Error", new String[] { "There was a problem editing this customer. Try again!" });
            }

            AppUser userLoggedIn = await _userManager.FindByNameAsync(User.Identity.Name);

            if (ModelState.IsValid == false)
            {
                return View(avm);
            }

            try
            {
                //find the record in the database
                AppUser dbUsers = _context.Users.Where(u => u.Email == avm.Email).FirstOrDefault();

                //update the notes
                dbUsers.Address = avm.NewAddress;

                _context.Update(dbUsers);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return View("Error", new String[] { "There was an error updating this order!", ex.Message });
            }

            //send the user to the Account Index page.
            return RedirectToAction(nameof(Index));

        }

        //Logic for change birthdate
        // GET: /Account/ChangeBirthdate
        [HttpGet]
        public ActionResult ChangeBirthdate(string email)
        {
            ChangeBirthdateViewModel newcbvm = new ChangeBirthdateViewModel();
            {
                newcbvm.Email = email;

            };

            return View(newcbvm);
        }

        [HttpPost]
        public async Task<ActionResult> ChangeBirthdate([Bind("Email, NewBirthdate")] ChangeBirthdateViewModel cbvm)
        { 
            if (User.Identity.Name != cbvm.Email)
            {
                return View("Error", new String[] { "There was a problem editing this customer. Try again!" });
            }

            AppUser userLoggedIn = await _userManager.FindByNameAsync(User.Identity.Name);

            if (ModelState.IsValid == false)
            {
                return View(cbvm);
            }

            try
            {
                //find the record in the database
                AppUser dbUsers = _context.Users.Where(u => u.Email == cbvm.Email).FirstOrDefault();

                //update the notes
                dbUsers.Birthdate = cbvm.NewBirthdate;

                _context.Update(dbUsers);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return View("Error", new String[] { "There was an error updating this order!", ex.Message });
            }

            //send the user to the Account Index page.
            return RedirectToAction(nameof(Index));

        }

        // get for change phonenumber
        [HttpGet]
        public ActionResult ChangePhoneNumber(string email)
        {
            ChangePhoneNumberViewModel newpnvm = new ChangePhoneNumberViewModel();
            {
                newpnvm.Email = email;

            };

            return View(newpnvm);
        }

        // change phone number
        [HttpPost]
        public async Task<ActionResult> ChangePhoneNumberAsync(string id, [Bind("Email, NewPhoneNumber")] ChangePhoneNumberViewModel pnvm)
        {
            if (User.Identity.Name != pnvm.Email)
            {
                return View("Error", new String[] { "There was a problem editing this customer. Try again!" });
            }

            AppUser userLoggedIn = await _userManager.FindByNameAsync(User.Identity.Name);

            if (ModelState.IsValid == false)
            {
                return View(pnvm);
            }

            try
            {
                //find the record in the database
                AppUser dbUsers = _context.Users.Where(u => u.Email == pnvm.Email).FirstOrDefault();

                //update the notes
                dbUsers.PhoneNumber = pnvm.NewPhoneNumber;

                _context.Update(dbUsers);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return View("Error", new String[] { "There was an error updating this order!", ex.Message });
            }

            //send the user to the Account Index page.
            return RedirectToAction(nameof(Index));
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