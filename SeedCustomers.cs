using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//TODO: Change these using statements to match your project
using Team1_FinalProject.DAL;
using Team1_FinalProject.Models;


//TODO: Change this namespace to match your project
namespace Team1_FinalProject.Seeding
{
    //add identity data
    public static class SeedCustomers
    {
        public static async Task AddCustomer(IServiceProvider serviceProvider)
        {
            //Get instances of the services needed to add a user & add a user to a role
            AppDbContext _context = serviceProvider.GetRequiredService<AppDbContext>();
            UserManager<AppUser> _userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            RoleManager<IdentityRole> _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            //TODO: Add the needed roles
            //if the admin role doesn't exist, add it
            //if the customer role doesn't exist, add it
            if (await _roleManager.RoleExistsAsync("Customer") == false)
            {
                await _roleManager.CreateAsync(new IdentityRole("Customer"));
            }

			//create a new instance of the app user class
			AppUser newUser = new AppUser();
			
			newUser.UserName = "cbaker@puppy.com";
			newUser.Email = "cbaker@puppy.com";
			newUser.PhoneNumber = "5125551132";
			newUser.FirstName = "Christopher";
			newUser.MiddleInitial = "L";
			newUser.LastName = "Baker";
			newUser.Birthdate = new DateTime(1949,11,23);
			newUser.Address = "1245 Lake Anchorage Blvd. Austin, TX37705";
			newUser.PopcornPoints = 90;
			
			IdentityResult result = new IdentityResult();
			result = await _userManager.CreateAsync(newUser,"hello1");
			
			_context.SaveChanges();
			newUser = _context.Users.FirstOrDefault(u => u.UserName == "cbaker@puppy.com");
			
			if (await _userManager.IsInRoleAsync(newUser, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser, "Customer");
			}
			
			_context.SaveChanges();
			
			newUser = new AppUser();
			
			newUser.UserName = "banker@longhorn.net";
			newUser.Email = "banker@longhorn.net";
			newUser.PhoneNumber = "5125552243";
			newUser.FirstName = "Martin";
			newUser.MiddleInitial = "T";
			newUser.LastName = "Banks";
			newUser.Birthdate = new DateTime(1962,11,27);
			newUser.Address = "6700 Small Pine Lane Austin, TX37712";
			newUser.PopcornPoints = 80;
			
			result = new IdentityResult();
			result = await _userManager.CreateAsync(newUser,"snowing");
			
			_context.SaveChanges();
			newUser = _context.Users.FirstOrDefault(u => u.UserName == "banker@longhorn.net");
			
			if (await _userManager.IsInRoleAsync(newUser, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser, "Customer");
			}
			
			_context.SaveChanges();
			
			newUser = new AppUser();
			
			newUser.UserName = "franco@puppy.com";
			newUser.Email = "franco@puppy.com";
			newUser.PhoneNumber = "5125555546";
			newUser.FirstName = "Franco";
			newUser.MiddleInitial = "V";
			newUser.LastName = "Broccolo";
			newUser.Birthdate = new DateTime(1992,10,11);
			newUser.Address = "562 Sad Road Austin, TX37704";
			newUser.PopcornPoints = 10;
			
			result = new IdentityResult();
			result = await _userManager.CreateAsync(newUser,"skating");
			
			_context.SaveChanges();
			newUser = _context.Users.FirstOrDefault(u => u.UserName == "franco@puppy.com");
			
			if (await _userManager.IsInRoleAsync(newUser, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser, "Customer");
			}
			
			_context.SaveChanges();
			
			newUser = new AppUser();
			
			newUser.UserName = "wchang@puppy.com";
			newUser.Email = "wchang@puppy.com";
			newUser.PhoneNumber = "5125553376";
			newUser.FirstName = "Wiseman";
			newUser.MiddleInitial = "L";
			newUser.LastName = "Chang";
			newUser.Birthdate = new DateTime(1997,5,16);
			newUser.Address = "7202 Big Hall Round Rock, TX37681";
			newUser.PopcornPoints = 20;
			
			result = new IdentityResult();
			result = await _userManager.CreateAsync(newUser,"Fighter");
			
			_context.SaveChanges();
			newUser = _context.Users.FirstOrDefault(u => u.UserName == "wchang@puppy.com");
			
			if (await _userManager.IsInRoleAsync(newUser, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser, "Customer");
			}
			
			_context.SaveChanges();
			
			newUser = new AppUser();
			
			newUser.UserName = "limchou@gogle.com";
			newUser.Email = "limchou@gogle.com";
			newUser.PhoneNumber = "5125555379";
			newUser.FirstName = "Lim";
			newUser.MiddleInitial = "C";
			newUser.LastName = "Chou";
			newUser.Birthdate = new DateTime(1970,4,6);
			newUser.Address = "8600 Cherry Lane Austin, TX37705";
			newUser.PopcornPoints = 70;
			
			result = new IdentityResult();
			result = await _userManager.CreateAsync(newUser,"Dallas63");
			
			_context.SaveChanges();
			newUser = _context.Users.FirstOrDefault(u => u.UserName == "limchou@gogle.com");
			
			if (await _userManager.IsInRoleAsync(newUser, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser, "Customer");
			}
			
			_context.SaveChanges();
			
			newUser = new AppUser();
			
			newUser.UserName = "shdixon@aoll.com";
			newUser.Email = "shdixon@aoll.com";
			newUser.PhoneNumber = "5125556607";
			newUser.FirstName = "Shaman";
			newUser.MiddleInitial = "D";
			newUser.LastName = "Dixon";
			newUser.Birthdate = new DateTime(1984,1,12);
			newUser.Address = "8234 Puppy Circle Austin, TX37712";
			newUser.PopcornPoints = 10;
			
			result = new IdentityResult();
			result = await _userManager.CreateAsync(newUser,"peppero");
			
			_context.SaveChanges();
			newUser = _context.Users.FirstOrDefault(u => u.UserName == "shdixon@aoll.com");
			
			if (await _userManager.IsInRoleAsync(newUser, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser, "Customer");
			}
			
			_context.SaveChanges();
			
			newUser = new AppUser();
			
			newUser.UserName = "j.b.evans@aheca.org";
			newUser.Email = "j.b.evans@aheca.org";
			newUser.PhoneNumber = "5125552289";
			newUser.FirstName = "Jim Bob";
			newUser.MiddleInitial = "C";
			newUser.LastName = "Evans";
			newUser.Birthdate = new DateTime(1959,9,9);
			newUser.Address = "9506 Kitten Circle Georgetown, TX37628";
			newUser.PopcornPoints = 0;
			
			result = new IdentityResult();
			result = await _userManager.CreateAsync(newUser,"longhorn");
			
			_context.SaveChanges();
			newUser = _context.Users.FirstOrDefault(u => u.UserName == "j.b.evans@aheca.org");
			
			if (await _userManager.IsInRoleAsync(newUser, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser, "Customer");
			}
			
			_context.SaveChanges();
			
			newUser = new AppUser();
			
			newUser.UserName = "feeley@penguin.org";
			newUser.Email = "feeley@penguin.org";
			newUser.PhoneNumber = "5125559999";
			newUser.FirstName = "Lou Ann";
			newUser.MiddleInitial = "K";
			newUser.LastName = "Feeley";
			newUser.Birthdate = new DateTime(2001,1,12);
			newUser.Address = "7600 N 7th Street W Austin, TX37746";
			newUser.PopcornPoints = 200;
			
			result = new IdentityResult();
			result = await _userManager.CreateAsync(newUser,"aggiesuck");
			
			_context.SaveChanges();
			newUser = _context.Users.FirstOrDefault(u => u.UserName == "feeley@penguin.org");
			
			if (await _userManager.IsInRoleAsync(newUser, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser, "Customer");
			}
			
			_context.SaveChanges();
			
			newUser = new AppUser();
			
			newUser.UserName = "tfreeley@minnetonka.ci.us";
			newUser.Email = "tfreeley@minnetonka.ci.us";
			newUser.PhoneNumber = "5125558827";
			newUser.FirstName = "Teresa";
			newUser.MiddleInitial = "P";
			newUser.LastName = "Freeley";
			newUser.Birthdate = new DateTime(1991,2,4);
			newUser.Address = "5448 Clearview Ave. Horseshoe Bay, TX37657";
			newUser.PopcornPoints = 250;
			
			result = new IdentityResult();
			result = await _userManager.CreateAsync(newUser,"raiders75");
			
			_context.SaveChanges();
			newUser = _context.Users.FirstOrDefault(u => u.UserName == "tfreeley@minnetonka.ci.us");
			
			if (await _userManager.IsInRoleAsync(newUser, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser, "Customer");
			}
			
			_context.SaveChanges();
			
			newUser = new AppUser();
			
			newUser.UserName = "mgarcia@gogle.com";
			newUser.Email = "mgarcia@gogle.com";
			newUser.PhoneNumber = "5125550002";
			newUser.FirstName = "Mikaela";
			newUser.MiddleInitial = "L";
			newUser.LastName = "Garcia";
			newUser.Birthdate = new DateTime(1991,10,2);
			newUser.Address = "3594 Cowview Austin, TX37727";
			newUser.PopcornPoints = 40;
			
			result = new IdentityResult();
			result = await _userManager.CreateAsync(newUser,"mustang54");
			
			_context.SaveChanges();
			newUser = _context.Users.FirstOrDefault(u => u.UserName == "mgarcia@gogle.com");
			
			if (await _userManager.IsInRoleAsync(newUser, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser, "Customer");
			}
			
			_context.SaveChanges();
			
			newUser = new AppUser();
			
			newUser.UserName = "chaley@mug.com";
			newUser.Email = "chaley@mug.com";
			newUser.PhoneNumber = "5125550198";
			newUser.FirstName = "Charmander";
			newUser.MiddleInitial = "E";
			newUser.LastName = "Haley";
			newUser.Birthdate = new DateTime(1974,7,10);
			newUser.Address = "43 One Pigboy Pkwy Austin, TX37712";
			newUser.PopcornPoints = 30;
			
			result = new IdentityResult();
			result = await _userManager.CreateAsync(newUser,"onetime76");
			
			_context.SaveChanges();
			newUser = _context.Users.FirstOrDefault(u => u.UserName == "chaley@mug.com");
			
			if (await _userManager.IsInRoleAsync(newUser, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser, "Customer");
			}
			
			_context.SaveChanges();
			
			newUser = new AppUser();
			
			newUser.UserName = "jeffh@mario.com";
			newUser.Email = "jeffh@mario.com";
			newUser.PhoneNumber = "5125552134";
			newUser.FirstName = "Jeff";
			newUser.MiddleInitial = "T";
			newUser.LastName = "Hampton";
			newUser.Birthdate = new DateTime(2004,3,10);
			newUser.Address = "7337 67th St. San Marcos, TX37666";
			newUser.PopcornPoints = 50;
			
			result = new IdentityResult();
			result = await _userManager.CreateAsync(newUser,"hampton98");
			
			_context.SaveChanges();
			newUser = _context.Users.FirstOrDefault(u => u.UserName == "jeffh@mario.com");
			
			if (await _userManager.IsInRoleAsync(newUser, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser, "Customer");
			}
			
			_context.SaveChanges();
			
			newUser = new AppUser();
			
			newUser.UserName = "wjhearniii@umich.org";
			newUser.Email = "wjhearniii@umich.org";
			newUser.PhoneNumber = "5125559729";
			newUser.FirstName = "John";
			newUser.MiddleInitial = "B";
			newUser.LastName = "Hearn";
			newUser.Birthdate = new DateTime(1950,8,5);
			newUser.Address = "8225 South First Plano, TX37705";
			newUser.PopcornPoints = 60;
			
			result = new IdentityResult();
			result = await _userManager.CreateAsync(newUser,"jhearn99");
			
			_context.SaveChanges();
			newUser = _context.Users.FirstOrDefault(u => u.UserName == "wjhearniii@umich.org");
			
			if (await _userManager.IsInRoleAsync(newUser, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser, "Customer");
			}
			
			_context.SaveChanges();
			
			newUser = new AppUser();
			
			newUser.UserName = "ahick@yaho.com";
			newUser.Email = "ahick@yaho.com";
			newUser.PhoneNumber = "5125553967";
			newUser.FirstName = "Abadon";
			newUser.MiddleInitial = "J";
			newUser.LastName = "Hicks";
			newUser.Birthdate = new DateTime(2004,12,8);
			newUser.Address = "632 NE Dog Ln., Ste 910 Austin, TX37712";
			newUser.PopcornPoints = 60;
			
			result = new IdentityResult();
			result = await _userManager.CreateAsync(newUser,"hickemon");
			
			_context.SaveChanges();
			newUser = _context.Users.FirstOrDefault(u => u.UserName == "ahick@yaho.com");
			
			if (await _userManager.IsInRoleAsync(newUser, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser, "Customer");
			}
			
			_context.SaveChanges();
			
			newUser = new AppUser();
			
			newUser.UserName = "ingram@jack.com";
			newUser.Email = "ingram@jack.com";
			newUser.PhoneNumber = "5125552142";
			newUser.FirstName = "Brock";
			newUser.MiddleInitial = "S";
			newUser.LastName = "Ingram";
			newUser.Birthdate = new DateTime(2001,9,5);
			newUser.Address = "9548 El Perro Ct. New York, NY10101";
			newUser.PopcornPoints = 90;
			
			result = new IdentityResult();
			result = await _userManager.CreateAsync(newUser,"ingram2098");
			
			_context.SaveChanges();
			newUser = _context.Users.FirstOrDefault(u => u.UserName == "ingram@jack.com");
			
			if (await _userManager.IsInRoleAsync(newUser, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser, "Customer");
			}
			
			_context.SaveChanges();
			
			newUser = new AppUser();
			
			newUser.UserName = "toddj@yourmom.com";
			newUser.Email = "toddj@yourmom.com";
			newUser.PhoneNumber = "5125555557";
			newUser.FirstName = "Todd";
			newUser.MiddleInitial = "L";
			newUser.LastName = "Jack";
			newUser.Birthdate = new DateTime(1999,1,20);
			newUser.Address = "2564 Tree St. Austin, TX37729";
			newUser.PopcornPoints = 140;
			
			result = new IdentityResult();
			result = await _userManager.CreateAsync(newUser,"toddy53");
			
			_context.SaveChanges();
			newUser = _context.Users.FirstOrDefault(u => u.UserName == "toddj@yourmom.com");
			
			if (await _userManager.IsInRoleAsync(newUser, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser, "Customer");
			}
			
			_context.SaveChanges();
			
			newUser = new AppUser();
			
			newUser.UserName = "thequeen@aska.net";
			newUser.Email = "thequeen@aska.net";
			newUser.PhoneNumber = "5125550156";
			newUser.FirstName = "Vic";
			newUser.MiddleInitial = "M";
			newUser.LastName = "Lancer";
			newUser.Birthdate = new DateTime(2000,4,14);
			newUser.Address = "1639 Butter Ln. Beverly Hills, CA90210";
			newUser.PopcornPoints = 110;
			
			result = new IdentityResult();
			result = await _userManager.CreateAsync(newUser,"nothing34");
			
			_context.SaveChanges();
			newUser = _context.Users.FirstOrDefault(u => u.UserName == "thequeen@aska.net");
			
			if (await _userManager.IsInRoleAsync(newUser, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser, "Customer");
			}
			
			_context.SaveChanges();
			
			newUser = new AppUser();
			
			newUser.UserName = "linebacker@gogle.com";
			newUser.Email = "linebacker@gogle.com";
			newUser.PhoneNumber = "5125550168";
			newUser.FirstName = "Sweeney";
			newUser.MiddleInitial = "W";
			newUser.LastName = "Lineback";
			newUser.Birthdate = new DateTime(2003,12,2);
			newUser.Address = "1700 Land St Austin, TX37758";
			newUser.PopcornPoints = 50;
			
			result = new IdentityResult();
			result = await _userManager.CreateAsync(newUser,"Password5");
			
			_context.SaveChanges();
			newUser = _context.Users.FirstOrDefault(u => u.UserName == "linebacker@gogle.com");
			
			if (await _userManager.IsInRoleAsync(newUser, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser, "Customer");
			}
			
			_context.SaveChanges();
			
			newUser = new AppUser();
			
			newUser.UserName = "elowe@scare.net";
			newUser.Email = "elowe@scare.net";
			newUser.PhoneNumber = "5125556959";
			newUser.FirstName = "Ernesto";
			newUser.MiddleInitial = "S";
			newUser.LastName = "Lowe";
			newUser.Birthdate = new DateTime(1977,12,7);
			newUser.Address = "2301 Snail Drive New Braunfels, TX37130";
			newUser.PopcornPoints = 40;
			
			result = new IdentityResult();
			result = await _userManager.CreateAsync(newUser,"aclfest2076");
			
			_context.SaveChanges();
			newUser = _context.Users.FirstOrDefault(u => u.UserName == "elowe@scare.net");
			
			if (await _userManager.IsInRoleAsync(newUser, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser, "Customer");
			}
			
			_context.SaveChanges();
			
			newUser = new AppUser();
			
			newUser.UserName = "cluce@gogle.com";
			newUser.Email = "cluce@gogle.com";
			newUser.PhoneNumber = "5125556919";
			newUser.FirstName = "Charles";
			newUser.MiddleInitial = "B";
			newUser.LastName = "Luce";
			newUser.Birthdate = new DateTime(1949,3,16);
			newUser.Address = "7945 Small Clouds Cactus, TX79013";
			newUser.PopcornPoints = 160;
			
			result = new IdentityResult();
			result = await _userManager.CreateAsync(newUser,"nothinggreat");
			
			_context.SaveChanges();
			newUser = _context.Users.FirstOrDefault(u => u.UserName == "cluce@gogle.com");
			
			if (await _userManager.IsInRoleAsync(newUser, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser, "Customer");
			}
			
			_context.SaveChanges();
			
			newUser = new AppUser();
			
			newUser.UserName = "mackcloud@george.com";
			newUser.Email = "mackcloud@george.com";
			newUser.PhoneNumber = "5125553223";
			newUser.FirstName = "Jackson";
			newUser.MiddleInitial = "D";
			newUser.LastName = "MacLeod";
			newUser.Birthdate = new DateTime(1947,2,21);
			newUser.Address = "2804 Near West Blvd. Plano, TX37654";
			newUser.PopcornPoints = 130;
			
			result = new IdentityResult();
			result = await _userManager.CreateAsync(newUser,"However");
			
			_context.SaveChanges();
			newUser = _context.Users.FirstOrDefault(u => u.UserName == "mackcloud@george.com");
			
			if (await _userManager.IsInRoleAsync(newUser, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser, "Customer");
			}
			
			_context.SaveChanges();
			
			newUser = new AppUser();
			
			newUser.UserName = "cmartin@beets.com";
			newUser.Email = "cmartin@beets.com";
			newUser.PhoneNumber = "5125554445";
			newUser.FirstName = "Candice";
			newUser.MiddleInitial = "P";
			newUser.LastName = "Markham";
			newUser.Birthdate = new DateTime(1972,3,20);
			newUser.Address = "9761 Bike Chase Kissimmee, FL34741";
			newUser.PopcornPoints = 200;
			
			result = new IdentityResult();
			result = await _userManager.CreateAsync(newUser,"nobodycares");
			
			_context.SaveChanges();
			newUser = _context.Users.FirstOrDefault(u => u.UserName == "cmartin@beets.com");
			
			if (await _userManager.IsInRoleAsync(newUser, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser, "Customer");
			}
			
			_context.SaveChanges();
			
			newUser = new AppUser();
			
			newUser.UserName = "clarence@yoho.com";
			newUser.Email = "clarence@yoho.com";
			newUser.PhoneNumber = "5125554447";
			newUser.FirstName = "Clarence";
			newUser.MiddleInitial = "A";
			newUser.LastName = "Martin";
			newUser.Birthdate = new DateTime(1992,7,19);
			newUser.Address = "387 Alcedo St. Austin, TX37709";
			newUser.PopcornPoints = 230;
			
			result = new IdentityResult();
			result = await _userManager.CreateAsync(newUser,"eggsellent");
			
			_context.SaveChanges();
			newUser = _context.Users.FirstOrDefault(u => u.UserName == "clarence@yoho.com");
			
			if (await _userManager.IsInRoleAsync(newUser, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser, "Customer");
			}
			
			_context.SaveChanges();
			
			newUser = new AppUser();
			
			newUser.UserName = "gregmartinez@drdre.com";
			newUser.Email = "gregmartinez@drdre.com";
			newUser.PhoneNumber = "5125556666";
			newUser.FirstName = "Greg";
			newUser.MiddleInitial = "R";
			newUser.LastName = "Martinez";
			newUser.Birthdate = new DateTime(1947,5,28);
			newUser.Address = "2495 Sunrise Blvd. Red Rock, TX37662";
			newUser.PopcornPoints = 70;
			
			result = new IdentityResult();
			result = await _userManager.CreateAsync(newUser,"rainrain");
			
			_context.SaveChanges();
			newUser = _context.Users.FirstOrDefault(u => u.UserName == "gregmartinez@drdre.com");
			
			if (await _userManager.IsInRoleAsync(newUser, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser, "Customer");
			}
			
			_context.SaveChanges();
			
			newUser = new AppUser();
			
			newUser.UserName = "cmiller@bob.com";
			newUser.Email = "cmiller@bob.com";
			newUser.PhoneNumber = "5125555923";
			newUser.FirstName = "Charles";
			newUser.MiddleInitial = "R";
			newUser.LastName = "Miller";
			newUser.Birthdate = new DateTime(1990,10,15);
			newUser.Address = "897762 Main St. South Padre Island, TX37597";
			newUser.PopcornPoints = 0;
			
			result = new IdentityResult();
			result = await _userManager.CreateAsync(newUser,"mypuppyspot");
			
			_context.SaveChanges();
			newUser = _context.Users.FirstOrDefault(u => u.UserName == "cmiller@bob.com");
			
			if (await _userManager.IsInRoleAsync(newUser, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser, "Customer");
			}
			
			_context.SaveChanges();
			
			newUser = new AppUser();
			
			newUser.UserName = "knelson@aoll.com";
			newUser.Email = "knelson@aoll.com";
			newUser.PhoneNumber = "5125557213";
			newUser.FirstName = "Kelly";
			newUser.MiddleInitial = "T";
			newUser.LastName = "Nelson";
			newUser.Birthdate = new DateTime(1971,7,13);
			newUser.Address = "5601 Blue River Disney, OK74340";
			newUser.PopcornPoints = 10;
			
			result = new IdentityResult();
			result = await _userManager.CreateAsync(newUser,"spotmycat");
			
			_context.SaveChanges();
			newUser = _context.Users.FirstOrDefault(u => u.UserName == "knelson@aoll.com");
			
			if (await _userManager.IsInRoleAsync(newUser, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser, "Customer");
			}
			
			_context.SaveChanges();
			
			newUser = new AppUser();
			
			newUser.UserName = "joewin@xfactor.com";
			newUser.Email = "joewin@xfactor.com";
			newUser.PhoneNumber = "5125557774";
			newUser.FirstName = "Joe";
			newUser.MiddleInitial = "C";
			newUser.LastName = "Nguyen";
			newUser.Birthdate = new DateTime(1984,3,17);
			newUser.Address = "8249 54th SW St. Del Rio, TX37841";
			newUser.PopcornPoints = 30;
			
			result = new IdentityResult();
			result = await _userManager.CreateAsync(newUser,"joejoebob");
			
			_context.SaveChanges();
			newUser = _context.Users.FirstOrDefault(u => u.UserName == "joewin@xfactor.com");
			
			if (await _userManager.IsInRoleAsync(newUser, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser, "Customer");
			}
			
			_context.SaveChanges();
			
			newUser = new AppUser();
			
			newUser.UserName = "orielly@foxnews.cnn";
			newUser.Email = "orielly@foxnews.cnn";
			newUser.PhoneNumber = "5125551111";
			newUser.FirstName = "Bill";
			newUser.MiddleInitial = "T";
			newUser.LastName = "O'Reilly";
			newUser.Birthdate = new DateTime(1959,7,8);
			newUser.Address = "9870 Gato Drive Fort Worth, TX37746";
			newUser.PopcornPoints = 120;
			
			result = new IdentityResult();
			result = await _userManager.CreateAsync(newUser,"bobbyboy");
			
			_context.SaveChanges();
			newUser = _context.Users.FirstOrDefault(u => u.UserName == "orielly@foxnews.cnn");
			
			if (await _userManager.IsInRoleAsync(newUser, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser, "Customer");
			}
			
			_context.SaveChanges();
			
			newUser = new AppUser();
			
			newUser.UserName = "ankaisrad@gogle.com";
			newUser.Email = "ankaisrad@gogle.com";
			newUser.PhoneNumber = "5125555631";
			newUser.FirstName = "Anka";
			newUser.MiddleInitial = "L";
			newUser.LastName = "Radkovich";
			newUser.Birthdate = new DateTime(1966,5,19);
			newUser.Address = "7900 Mark Pl Plano, TX37712";
			newUser.PopcornPoints = 150;
			
			result = new IdentityResult();
			result = await _userManager.CreateAsync(newUser,"chadgirl");
			
			_context.SaveChanges();
			newUser = _context.Users.FirstOrDefault(u => u.UserName == "ankaisrad@gogle.com");
			
			if (await _userManager.IsInRoleAsync(newUser, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser, "Customer");
			}
			
			_context.SaveChanges();
			
			newUser = new AppUser();
			
			newUser.UserName = "megrhodes@freserve.co.uk";
			newUser.Email = "megrhodes@freserve.co.uk";
			newUser.PhoneNumber = "5125557700";
			newUser.FirstName = "Megan";
			newUser.MiddleInitial = "C";
			newUser.LastName = "Rhodes";
			newUser.Birthdate = new DateTime(1965,3,12);
			newUser.Address = "1187 Carpet Rd. Austin, TX37705";
			newUser.PopcornPoints = 50;
			
			result = new IdentityResult();
			result = await _userManager.CreateAsync(newUser,"megan55");
			
			_context.SaveChanges();
			newUser = _context.Users.FirstOrDefault(u => u.UserName == "megrhodes@freserve.co.uk");
			
			if (await _userManager.IsInRoleAsync(newUser, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser, "Customer");
			}
			
			_context.SaveChanges();
			
			newUser = new AppUser();
			
			newUser.UserName = "erynrice@aoll.com";
			newUser.Email = "erynrice@aoll.com";
			newUser.PhoneNumber = "5125550006";
			newUser.FirstName = "Eryn";
			newUser.MiddleInitial = "M";
			newUser.LastName = "Rice";
			newUser.Birthdate = new DateTime(1975,4,28);
			newUser.Address = "2205 Rio Pequeno Austin, TX37375";
			newUser.PopcornPoints = 70;
			
			result = new IdentityResult();
			result = await _userManager.CreateAsync(newUser,"ricearoni");
			
			_context.SaveChanges();
			newUser = _context.Users.FirstOrDefault(u => u.UserName == "erynrice@aoll.com");
			
			if (await _userManager.IsInRoleAsync(newUser, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(newUser, "Customer");
			}
			
			_context.SaveChanges();
			

			
			
        }

    }
}