using ASP.NET_MVC_App.Data;
using ASP.NET_MVC_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_MVC_App.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        //GET
        public IActionResult Upsert(int? id)
        {
            User user = new();
            if(id==null || id == 0)
            {
                return View(user);

            }
            else
            {
                user = _db.Users.Where(u => u.Id == id).FirstOrDefault();
                return View(user);
            }
            
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(User user)
        {

            if (ModelState.IsValid)
            {
                if (user.Id == 0)
                {
                    _db.Users.Add(user);
                    TempData["success"] = "User created successfully!";
                    _db.SaveChanges();
                }
                else
                {
                    _db.Users.Update(user);
                    TempData["success"] = "User updated successfully!";
                    _db.SaveChanges();
                }
                
                return RedirectToAction("Index");
            }
            return View(user);
        }

        

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var usersList = _db.Users.ToList();
            return Json(new { data = usersList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _db.Users.FirstOrDefault(u => u.Id == id);
            if(obj == null)
            {
                return Json(new { success = false, message = "Error while deleting!" });
            }

            _db.Users.Remove(obj);
            _db.SaveChanges();

            return Json(new { success = true, message = "User deleted successfully!" });

        }
        #endregion
    }
}
