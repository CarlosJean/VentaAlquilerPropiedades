using CompraPropiedades.Models;
using CompraPropiedades.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompraPropiedades.Controllers
{
    public class MyPostsController : Controller
    {
        public IPublicationService _iPublicationService;
        public MyPostsController(IPublicationService publicationService) {
            this._iPublicationService = publicationService;
        }
        // GET: MyPosts
        //[HttpPost]
        public ActionResult Index()
        {
            var myPublications = this._iPublicationService.GetMyPublications(1);
            return View("Index",myPublications);
        }

        [HttpPost]
        public JsonResult HidePost(FormCollection collection) {
            var id_publication = Convert.ToInt32(collection["publicationId"]);
            var result = this._iPublicationService.Hide(id_publication);
            return Json(result);
        } 
        
        public JsonResult ShowPost(FormCollection collection) {
            var id_publication = Convert.ToInt32(collection["publicationId"]);
            var result = this._iPublicationService.Show(id_publication);
            return Json(result);
        }


        // GET: MyPosts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MyPosts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyPosts/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MyPosts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MyPosts/Edit/5
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

        // GET: MyPosts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MyPosts/Delete/5
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
    }
}
