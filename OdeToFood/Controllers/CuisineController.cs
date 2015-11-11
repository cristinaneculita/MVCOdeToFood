using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OdeToFood.Filters;

namespace OdeToFood.Controllers
{
    [Log]
    public class CuisineController : Controller
    {
        //
        // GET: /Cuisine/
       
        public ActionResult Search(string name)
        {
            var message = name;
            return Content(message);
        }
     


    }
}
