
using System.Linq;
using System.Web.Mvc;
using TestWebApp.AppObjs;
using TestWebApp.Domain.Entities;
using TestWebApp.Domain.Repositories;
using TestWebApp.ViewModel;

namespace TestWebApp.Controllers
{
    public class HomeController : Controller
    {
        private UserRepository userRepo;
        public HomeController()
        {
            userRepo = new UserRepository();
        }
        // GET: Home
        public ActionResult Login()
        { 
            return View(new LoginViewModel());
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if(model == null ||string.IsNullOrWhiteSpace(model.Email) || string.IsNullOrWhiteSpace(model.Password))
            {
                ViewBag.Msg = "Error! Please Provide your login Credential";
                return View(model);
            }
            if (model.Email == null)
            {
                ViewBag.Msg = "Error! Username is Empty ";
                return View(model);
            }
            var user =userRepo.GetUser(model.Email.Trim());
            if(user == null)
            {
                ViewBag.Msg = "Invalid Username ";
                return View(model);
            }
            string salted = user.SaltedPassword;
            string attemptPasswordHash = GlobalTool.GetHash(model.Password.Trim(), salted);
            string password = user.Password;
            bool confirmPass =GlobalTool.ComparePasswordHash(model.Password.Trim(), password, salted);
            if(!confirmPass)
            {
                ViewBag.Msg = "Error! Invalid Password ";
                return View(model);
            }
            Session["User"] = user;
            return View("Index");
        }
       
        public ActionResult Index()
        {
           
            return View("Index");
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                var userList = userRepo.GetAll().ToList();
                if(userList!=null &&userList.Where(x=>x.Email.Trim().ToLower()==model.Email.Trim().ToLower()).Count()>0)
                {
                    ViewBag.Error = "Email Already Exist";
                    return View(model); 
                }
                if (userList.Where(x => x.FirsName.Trim().ToLower() == model.FirsName.Trim().ToLower()
                   && x.LastName.Trim().ToLower() == model.LastName.Trim().ToLower()).Count() > 0)
                {
                    ViewBag.Error = "User Information Already Exist";
                    return View(model);
                }
                string saltedPassword = GlobalTool.CreateSalt();
                var user = new User {
                    DateOfBirth = model.DateOfBirth, Email = model.Email.Trim(),
                    FirsName = model.FirsName.Trim(),
                    LastName = model.LastName.Trim(),
                    SaltedPassword = saltedPassword,
                    Sex =  (int)model.Sex,
                    Password=GlobalTool.GetHash(model.Password.Trim(), saltedPassword),
                    RegisteredDate=System.DateTime.Now
                };
                int userId = userRepo.Add(user);
                if(userId<1)
                {
                    ViewBag.Error = "Error! Unable to Registered User, Try Again";
                    return View(model);
                }
                string msg = "<a href='/Home/Login'>Click Here </a> to login";
                ViewBag.Success = "You have Registered Successfully "+msg;
                return View(new RegisterViewModel());
            }
            ModelState.AddModelError(string.Empty,"Please Fill All the Field");
            return View(model);
        }

        public ActionResult LogOff()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}