using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MACDTrade.Data;

namespace MACDTrade.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private StockRepository _stockRepository;

        public HomeController()
        {
            _stockRepository = new StockRepository();
        }

        public ActionResult Index()
        {
            var objModel = _stockRepository.ListStocks();
            return View(objModel);
        }
    }
}