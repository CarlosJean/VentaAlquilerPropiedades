using CompraPropiedades.Models;
using CompraPropiedades.Repositories;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
        
        public ViewResult Buscar()
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
            var jsonProvincia = JsonConvert.SerializeObject((this._searchProperties.GetProvincias()));
            return Json(jsonProvincia);
        }

        public JsonResult Sectores()
        {
            var idProvincia = int.Parse(Request.Form["idProvincia"]);

            var jsonSector = JsonConvert.SerializeObject((this._searchProperties.GetSectores(idProvincia)));
            return Json(jsonSector);
        }

        public ViewResult Casas() {


            return View("Casas");
        }

        public JsonResult PropertyTypes() {


            var jsonPropertyTypes = JsonConvert.SerializeObject(this._searchProperties.GetPropertyTypes());
            return Json(jsonPropertyTypes);
            
        }

        public JsonResult PublicationTypes()
        {

            var publicationTypesList = JsonConvert.SerializeObject(this._searchProperties.GetPublicationTypes());

            return Json(publicationTypesList);

        }

        public JsonResult Publications() {

            //var province = int.Parse(Request.Form["Province"]);
            float[] price = new float[2];

            // float[] arrayPrice = new float[2];
            //var arrayPrice = new string[2];
            //if (Request.Form["Price"] != null){
                var arrayPrice = (JArray)JsonConvert.DeserializeObject(Request.Form["Price"]);
                price[0] = float.Parse(arrayPrice[0].ToString());
                price[1] = float.Parse(arrayPrice[1].ToString());
            //}
            


            var propertyType           = int.Parse(Request.Form["PropertyType"]);
            List<int> publicationTypes = new List<int>();

            var arraypublicationTypes = new JArray();
            if (Request.Form["PublicationTypes"] != null) {
                arraypublicationTypes = (JArray)JsonConvert.DeserializeObject(Request.Form["PublicationTypes"]);
            }
            

            for (var index=0; index<arraypublicationTypes.Count(); index++) {
                publicationTypes.Add(int.Parse(arraypublicationTypes[index].ToString()));
            }

            var sector          = int.Parse(Request.Form["Sector"]);

            var rownumberFrom = int.Parse(Request.Form["rownumberFrom"]);
            var rownumberTo   = int.Parse(Request.Form["rownumberTo"]);

            var publicationsList = JsonConvert.SerializeObject(
                this._searchProperties.GetPublications(price, propertyType, publicationTypes, rownumberFrom, rownumberTo,/*province,*/ sector));

            return Json(publicationsList);
        
        }
    }
}