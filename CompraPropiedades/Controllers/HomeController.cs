using CompraPropiedades.Models;
using CompraPropiedades.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompraPropiedades.Controllers
{
    public class HomeController : Controller
    {
        ISearchPropertiesService _searchProperties;

        public  HomeController(ISearchPropertiesService searchPropertiesService) {

            this._searchProperties = searchPropertiesService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ViewResult BuscarCasas()
        {
            return View();
        }
        public JsonResult Precios() {

            _searchProperties = new SearchProperties();

            var jsonPrecio = JsonConvert.SerializeObject((this._searchProperties.GetPrecios()));
            return Json(jsonPrecio);
        }

        public JsonResult Provincias()
        {

           // _searchProperties = new SearchProperties();

            var jsonProvincia = JsonConvert.SerializeObject((this._searchProperties.GetProvincias()));
            return Json(jsonProvincia);
        }

        public JsonResult Sectores()
        {

            var idProvincia = int.Parse(Request.Form["idProvincia"]);
            //_searchProperties = new SearchProperties();

            var jsonSector = JsonConvert.SerializeObject((this._searchProperties.GetSectores(idProvincia)));
            return Json(jsonSector);
        }

        public ViewResult Casas() {


            return View("Casas");
        }
    }
}