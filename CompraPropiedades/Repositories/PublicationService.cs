using CompraPropiedades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompraPropiedades.ViewModels;
using System.IO;

namespace CompraPropiedades.Repositories
{
    
    public class PublicationService:IPublicationService
    {
        private readonly VentaPropiedadesContext _db;
        private  string _defaultDirectoryPath = "C:/Users/Jean Holguin/source/repos/CompraPropiedades/CompraPropiedades/Publications/";
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
                    Console.WriteLine(ex);
                  transaction.Rollback();
                }
                

            }

        }


        private void SavePublication(PostViewModel postViewModel) {
            postViewModel.Publication.PublicationDate = DateTime.Parse(DateTime.Today.ToString("yyyy-MM-dd HH:mm"));
            postViewModel.Publication.IdUser = 1;
            postViewModel.Publication.User = this._db.User.FirstOrDefault(p => p.IdUser == postViewModel.Publication.IdUser);
            postViewModel.Publication.PropertyType = this._db.PropertyType.FirstOrDefault(p => p.IdPropertyType == postViewModel.Publication.IdPropertyType);

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

            var imagePath = "../Assets/Images/"+ _publicationId + "/Imagen"+ _imageNumber+"."+imageType;

            return imagePath;
        }
        //Copia el archivo en el servidor.
        private void CopyImageToServer(int publicationId, HttpPostedFileBase file, int index = 0, string imageType = "jpeg") {

            var basePath = this._defaultDirectoryPath + publicationId;

            if (!Directory.Exists(basePath)) {
                Directory.CreateDirectory(basePath);
            }
            
            string path = basePath + "/Imagen"+index.ToString()+"."+ imageType;
            file.SaveAs(path);

        }
    }
}