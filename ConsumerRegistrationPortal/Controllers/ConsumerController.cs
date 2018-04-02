using ConsumerRegistrationPortal.BusinessLayer.Interfaces;
using ConsumerRegistrationPortal.BusinessLayer.Dtos;
using ConsumerRegistrationPortal.DomainLayer.Interfaces;
using ConsumerRegistrationPortal.DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConsumerRegistrationPortal.Controllers
{
    public class ConsumerController : Controller
    {
        private readonly IConsumerRepository _consumerRepository;
        private readonly IILogger _log;
        private readonly IDynamicHTMLRepository _dynamicHTMLRepository;
        public ConsumerController(IConsumerRepository consumerRepository, IILogger log, IDynamicHTMLRepository dynamicHTMLRepository)
        {
            _consumerRepository = consumerRepository;
            _log = log;
            _dynamicHTMLRepository = dynamicHTMLRepository;
        }
        // GET: Consumer
        public ActionResult Index()
        {
            var res = _dynamicHTMLRepository.GetHTMLDbSet(1);
            return View(res);
        }
        [HttpPost]
        public string Index(List<HTMLGenerationEntity> hTMLGenerationEntity)
        {
            if (ModelState.IsValid)
            {
                var attributes = Utils.ParseRequest(Request.Form);
                try
                {
                    var res = _consumerRepository.ValidateConsumer(1, attributes);
                    ViewData.Add("validatecustomer", (res.Count > 0) ? true : false);
                }
                catch (Exception ex)
                {
                    _log.Log(ex, LoggingEventType.error);
                    return "Error";
                }
               
            }
            return "Success";
        }

        public List<HTMLGenerationMultipleEntity> GetHTMLChildTags(int masterTagId)
        {
            return _dynamicHTMLRepository.GetHTMLDetails(masterTagId);
        }
    }
}