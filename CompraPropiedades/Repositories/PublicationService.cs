using CompraPropiedades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompraPropiedades.ViewModels;
using System.IO;
using System.Web.Mvc;
using System.Data.Entity.Core.Objects;

namespace CompraPropiedades.Repositories
{
    
    public class PublicationService:IPublicationService 
    {
        private readonly VentaPropiedadesContext _db;
        private readonly string _defaultDirectoryPath = "C:/Users/Jean Holguin/source/repos/CompraPropiedades/CompraPropiedades/App_Data/Images/";
        public PublicationService() {
            this._db = new VentaPropiedadesContext();
        }
        public List<Acommodation> GetAccomodations()
        {
            var accomodationList = this._db.Accomodation.ToList();

            return accomodationList;
        }

        public void RegisterPublication(PostViewModel postViewModel) {

            using (var transaction = this._db.Database.BeginTransaction()) {
                try
                {

                    this.SavePublication(postViewModel);
                    this.SavePublicationAccomodation(postViewModel);
                    this.SavePublicationImage(postViewModel);                  
                    
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                  transaction.Rollback();
                }
                

            }

        }


        private void SavePublication(PostViewModel postViewModel) {
            postViewModel.Publication.PublicationDate = DateTime.Parse(DateTime.Today.ToString("yyyy-MM-dd HH:mm"));
            postViewModel.Publication.IdUser = 1;
            postViewModel.Publication.User = this._db.User.FirstOrDefault(p => p.IdUser == postViewModel.Publication.IdUser);
            postViewModel.Publication.PropertyType = this._db.PropertyType.FirstOrDefault(p => p.IdPropertyType == postViewModel.Publication.IdPropertyType);

            postViewModel.Publication.Active    = true;
            postViewModel.Publication.Available = true;

            this._db.Publication.Add(postViewModel.Publication);
            this._db.SaveChanges();
        }

        private void SavePublicationAccomodation(PostViewModel postViewModel) {
            var publicationId = this._db.Publication.OrderByDescending(p => p.IdPublication).FirstOrDefault().IdPublication;

            var publicationAccomodation = new PublicationAcommodation();

            foreach (var accomodation in postViewModel.Accomodations)
            {
                publicationAccomodation.IdPublication = publicationId;
                publicationAccomodation.Quantity = 1;
                publicationAccomodation.IdAcommodation = int.Parse(accomodation);
                this._db.PublicationAccomodation.Add(publicationAccomodation);
                this._db.SaveChanges();
            }
        }

        private void SavePublicationImage(PostViewModel postViewModel) {

            var publicationId = this._db.Publication.OrderByDescending(p => p.IdPublication).FirstOrDefault().IdPublication;
            var publicationImage = new PublicationImage();
            var publicationImageId = 0;


            var index = 0;
            foreach (var image in postViewModel.PublicationImage)
            {
                publicationImage.IdPublication = publicationId;

                var publicationImageCount = this._db.PublicationImage.Count();

                if (publicationImageCount > 0)
                {
                     publicationImageId = Convert.ToInt32(this._db.PublicationImage.Max(p => p.IdPublicationImage)) + 1;
                }

                publicationImage.Date = DateTime.Parse(DateTime.Today.ToString("yyyy-MM-dd HH:mm"));
                publicationImage.Image = this.GetImagePath(publicationId, index,image.ContentType)/*"../Assets/Images/"+ publicationImageId.ToString()+"/Imagen"+ (index+1).ToString()+"."+image.ContentType*/;
                //publicationImage.IdPublicationImage = publicationImageId;
                //publicationImage.Publication.Add(postViewModel.Publication);

                this._db.PublicationImage.Add(publicationImage);

                //var file = postViewModel.PublicationImage[index];
                
                index++;


                this._db.SaveChanges();
                this.CopyImageToServer(publicationId, image, index);
            }

            //this._db.SaveChanges();
        }

        private string GetImagePath(int publicationId, int imageNumber, string imageContentType) {

            var _publicationId = publicationId.ToString();
            var _imageNumber        = (imageNumber+1).ToString();
            var _imageContentType = imageContentType.Split("/".ToCharArray());
            var imageType = _imageContentType[1];

            var imagePath = "../AppData/Images/" + _publicationId + "/Image"+ _imageNumber+"."+imageType;

            return imagePath;
        }
        //Copia el archivo en el servidor.
        private void CopyImageToServer(int publicationId, HttpPostedFileBase file, int index = 0, string imageType = "jpeg") {

            var basePath = this._defaultDirectoryPath + publicationId;

            if (!Directory.Exists(basePath)) {
                Directory.CreateDirectory(basePath);
            }
            
            string path = basePath + "/Image"+index.ToString()+"."+ imageType;
            file.SaveAs(path);

        }

        public List<MyPublicationsViewModel> GetMyPublications(int idUser){
            var publications = (from p in this._db.Publication
                                where p.IdUser == 1
                                select new {p.IdPublication,
                                    p.Title, p.Description,
                                    (from publicationImage in this._db.PublicationImage
                                     where publicationImage.IdPublication == p.IdPublication
                                     select new { publicationImage.Image}
                                    ).FirstOrDefault().Image,
                                    p.Available
                                }).ToList();

            List<MyPublicationsViewModel> myPublicationsViewModelsList = new List<MyPublicationsViewModel>();
            MyPublicationsViewModel myPublicationsViewModel       = new MyPublicationsViewModel();

            foreach (var publication in publications) {
                myPublicationsViewModelsList.Add(new MyPublicationsViewModel { PublicationId=publication.IdPublication,
                                                                               Title = publication.Title, 
                                                                               Description = publication.Description, 
                                                                               Image = publication.Image,
                                                                               Available = publication.Available});
             
            }

            return myPublicationsViewModelsList;            
        }

        public HidePublication Hide(int idPublication) {
            var result = this._db.SpHidePublication(idPublication);
            return result;
        }
        
        public HidePublication Show(int idPublication) {
            var result = this._db.SpShowPublication(idPublication);
            return result;
        }
    }
}