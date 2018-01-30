using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Fasetto.Word.Web.Server.Controllers
{
    public class HomeController : Controller
    {
        #region Protected Members

        /// <summary>
        /// The scoped Application context
        /// </summary>
        protected ApplicationDbContext mContext;

        /// <summary>
        /// Manager for user operations
        /// </summary>
        protected UserManager<ApplicationUser> mUserManager;

        /// <summary>
        /// Manager for handling signing in and out
        /// </summary>
        protected SignInManager<ApplicationUser> mSignInManager;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="context">The injected context</param>
        public HomeController(ApplicationDbContext context, 
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            mContext = context;
            mUserManager = userManager;
            mSignInManager = signInManager;
        }

        #endregion

        public IActionResult Index()
        {
            // Make sure we have the database
            mContext.Database.EnsureCreated();

            // If we have no settings already...
            if (!mContext.Settings.Any())
            {
                // Add a new setting
                mContext.Settings.Add(new SettingsDataModel
                {
                    Name = "BackgroundColor",
                    Value = "Red"
                });

                // Check to show the new setting is currently only local and not in the database
                var settingsLocally = mContext.Settings.Local.Count();
                var settingsDatabase = mContext.Settings.Count();
                var firstLocal = mContext.Settings.Local.FirstOrDefault();
                var firstDatabase = mContext.Settings.FirstOrDefault();

                // Commit setting to database
                mContext.SaveChanges();

                // Recheck to show its now in local and the actual database
                settingsLocally = mContext.Settings.Local.Count();
                settingsDatabase = mContext.Settings.Count();
                firstLocal = mContext.Settings.Local.FirstOrDefault();
                firstDatabase = mContext.Settings.FirstOrDefault();
            }

            return View();
        }

        /// <summary>
        /// Creates our single user
        /// </summary>
        /// <returns></returns>
        [Route("create")]
        public async Task<IActionResult> CreateUserAsync()
        {
            var result = await mUserManager.CreateAsync(new ApplicationUser
            {
                UserName = "pnkfld7892",
                Email = "contact@pnkfldlab.com"
            }, "password");

            if(result.Succeeded)
                return Content("User was Created", "text/html");
            return Content("User Creation Failed", "text/html");
        }

        ///private area
        [Authorize]
        [Route("private")]
        public IActionResult Private()
        {
            return Content($"This is a private area. Welcome {HttpContext.User.Identity.Name}", "text/html");
        }

        /// <summary>
        /// Auto login page for testing
        /// </summary>
        /// <param name="returnUrl">the url to return to if sucessfully logged in</param>
        /// <returns></returns>
        [Route("login")]
        public async Task<IActionResult> LoginAsync(string returnUrl)
        {
            //faking login process
            var result = await mSignInManager.PasswordSignInAsync("pnkfld7892", "password", true,false);

            if (result.Succeeded)
            {
                if (string.IsNullOrEmpty(returnUrl))
                    return RedirectToAction(nameof(Index));
                else
                    return Redirect(returnUrl);
            }
            return Content("testing", "text/html");
        }
    }
}
