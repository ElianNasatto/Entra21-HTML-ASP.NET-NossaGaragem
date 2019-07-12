using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class VeiculoController : Controller
    {
        // GET: Veiculo
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Cadastro()
        {
            return View();
        }
    }
}