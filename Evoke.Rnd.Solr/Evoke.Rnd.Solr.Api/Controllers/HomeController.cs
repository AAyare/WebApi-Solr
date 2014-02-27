using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Evoke.Rnd.Solr.Api.Models;

namespace Evoke.Rnd.Solr.Api.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMessageService _messageService;
        public HomeController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public ActionResult Index()
        {
            ViewBag.Message = _messageService.GetWelcomeMessage();
            return View();
        }
    }
}
