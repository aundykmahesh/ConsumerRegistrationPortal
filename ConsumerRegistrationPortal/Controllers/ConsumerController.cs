using ConsumerRegistrationPortal.BusinessLayer.Interfaces;
using ConsumerRegistrationPortal.DomainLayer.Interfaces;
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
        public ConsumerController(IConsumerRepository consumerRepository, IILogger log)
        {
            _consumerRepository = consumerRepository;
            _log = log;
        }
        // GET: Consumer
        public ActionResult Index()
        {
            var res = _consumerRepository.ValidateConsumer(1, "123456,test test test,987654321");
            return View();
        }
    }
}