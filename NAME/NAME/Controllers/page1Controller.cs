using NAME.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAME.Controllers
{
    public class page1Controller : Controller
    {
        // GET: page1
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NameFirst()
        {
            //var now = new DateTime();
            //int y = now.getFullYear();
            //mh = (Today.getMonth() + 1);
            //d = Today.getDate();
            //int h = DateTime.Now.getHours();
            //m = Today.getMinutes();
            //s = Today.getSeconds();
            ViewBag.KK = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Save();
            return View();
        }

        public int fId { get; set; }
        public string fClass { get; set; }
        public string fName { get; set; }

        
        public void Save()
        {
            Class1 x = new Class1();
            //x.fName = Request.Form["txtName"];
            ViewBag.KK = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //ViewBag.KK2 = DateTime.Now.ToString("HH:mm:ss");
            (new Class1()).create(x);  
        
        }
        public ActionResult CheckIt()
        {
            string keyword = Request.Form["txtKeyword"];
            string datetime = Request.Form["txtdatetime"];
            //string noon = Request.Form["txtnoon"];
            List<Class1> list = null;
            if (string.IsNullOrEmpty(datetime) && string.IsNullOrEmpty(keyword))
                list = (new Class1()).queryAll();
            else if (!string.IsNullOrEmpty(keyword) && !string.IsNullOrEmpty(datetime))
                list = (new Class1()).queryByKeyword(keyword);

            //else if (noon=="before")
              //  list = (new Class1()).queryByDate(datetime);
            else
                list = (new Class1()).queryByDate(datetime);
            return View(list);
        }
    }
    }
