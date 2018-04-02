using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConsumerRegistrationPortal.BusinessLayer.Interfaces;
using ConsumerRegistrationPortal.DomainLayer.Interfaces;

namespace ConsumerRegistrationPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDynamicHTMLRepository _dynamicHTMLRepository;
        private readonly IILogger _log;
        public HomeController(IDynamicHTMLRepository dynamicHTMLRepository, IILogger log)
        {
            _dynamicHTMLRepository = dynamicHTMLRepository;
            _log = log;
        }
        public ActionResult Index()
        {
            var res = _dynamicHTMLRepository.GetHTMLDbSet(1);

            _log.Log("Result success", LoggingEventType.info);
            return View(_dynamicHTMLRepository.GetHTMLMasterTags(res));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return RedirectToAction("Index", "Consumer");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}