using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OdeToFood.Filters;

namespace OdeToFood.Controllers
{
    //[Authorize]
    [Log]
    public class CuisineController : Controller
    {
        
      
        public ActionResult Search()
        {

            throw new Exception("info");
            return Content("search");
        }
     


    }
}
