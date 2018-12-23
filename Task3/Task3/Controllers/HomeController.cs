using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using DataProvider;
using DataBase;
using DataProvider.DbAction;

namespace Task3.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Update(string val)
        {       
            if(Request.IsAjaxRequest())
            {
                string output = "Данный цвет зарегистрирован ранее";
                string connection = WebConfigurationManager.AppSettings["sqlConnection"];
                //Должна быть возможность создать одно сеодинение к бд и использовать его в дальнейшем, а создать его на каждый чих
                DbLink _dbLink = new DbLink(Fabricate.CreateConnection(connection, ConnectionType.SqlConnection));
                if(!Colour.Exist(_dbLink, val))
                {
                    if (Colour.Insert(_dbLink, val))
                        output = "Цвет успешно зарегистрирован";
                    else
                        output = "Значение не удалось добавить";
                }
                //вернем только часть страницы 
                return PartialView("_UpdatePartial", output);
            }
            //Если будет отключен js, то перейдем полностью на новую форму
            return View(val);
        }
    }
}