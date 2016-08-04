using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mariage.Controllers
{
    public class PhotosController : Controller
    {
        // GET: Photos
        public ActionResult Index()
        {
            var files = Directory.EnumerateFiles(@"~\gerard", "*.jpg", SearchOption.AllDirectories);

            return View();
        }
    }
}