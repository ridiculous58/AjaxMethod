using Ajax_Method.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ajax_Method.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        
        public ActionResult Index()
        {
            List<string> datas = new List<string> { "emirhan", "cifci", "asp.net", "mvc egitimi", "asp.net core", "mvc egitimi" };
            Session["liste"] = datas;
            return View();
        }
        public ActionResult Index2()
        {
            return View(new ToDoItem());
        }
        [HttpPost]
        public PartialViewResult Index2(ToDoItem model)
        {
            List<ToDoItem> list = null;
            if(Session["todolist"] != null)
            {
                list = Session["todolist"] as List<ToDoItem>;
            }
            else
            {
                list = new List<ToDoItem>();
            }
            model.Id = Guid.NewGuid();
            list.Add(model);

            Session["todolist"] = list;
            return PartialView("_ToDoItemPartialView",model);
        }

        public PartialViewResult LoadList()
        {

            System.Threading.Thread.Sleep(3000);
            return PartialView("_PartialHome",Session["liste"]);
        }

        public MvcHtmlString Remove(int id)
        {
            List<string> list = Session["liste"] as List<string>;
            list.RemoveAt(id);

            Session["liste"] = list;

            return MvcHtmlString.Empty;
        }
    }
}