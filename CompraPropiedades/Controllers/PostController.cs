using CompraPropiedades.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompraPropiedades.ViewModels;

namespace CompraPropiedades.Controllers
{
    public class PostController : Controller
    {

        IPublicationService _publicationService;

        public PostController(IPublicationService publicationService) {

            this._publicationService = publicationService;
        }
        // GET: Post
        public ActionResult Index()
        {
            //var publication

            return View("POST");
        }

        // GET: Post/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Post/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        public ActionResult Create(PostViewModel postViewModel)
        {
            try
            {
                // TODO: Add insert logic here

                //this._publicationService.RegisterPublication(postViewModel);

                return RedirectToAction("SavedPost");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Post/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Post/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult SavedPost() {

            return View();
        }
        public JsonResult GetAccomodations() {
            var accomodations = JsonConvert.SerializeObject(this._publicationService.GetAccomodations());
            return Json(accomodations);
        }

       
    }

   
}
