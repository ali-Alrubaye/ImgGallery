using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using businessLayer;
using ViewModels.Models;

namespace ImgGallery.UI.Controllers
{
    public class HomeController : Controller
    {
        private AlbumAutomapper AlbumAutomapper { get; set; }
        private PhotoAutomapper PhotoAutomapper { get; set; }

        public HomeController()
        {
            AlbumAutomapper = new AlbumAutomapper();
            PhotoAutomapper = new PhotoAutomapper();
        }
        // GET: Home
        public ActionResult Index()
        {
            var p = PhotoAutomapper.FromBltoUiGetAll();
            return View(p);
        }
        public ActionResult List()
        {
            var p = PhotoAutomapper.FromBltoUiGetAll();
            return PartialView("_list",p);
        }
        // GET: /photo/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.AlbumId = new SelectList(AlbumAutomapper.FromBltoUiGetAll(), "AlbumId", "AlbumName");
            return PartialView("_CreatePhotos",new PhotoViewModel());
        }

        //
        // POST: /photo/Create
        [HttpPost]
        public async Task<ActionResult> Create([Bind(Include = "PhotoID,PhotoName,PhotoDate,Description,photoPath,AlbumId")] PhotoViewModel photo, HttpPostedFileBase photoPath)
        {
            if (string.IsNullOrWhiteSpace(photo.PhotoName))
            {
                return Json(new { Status = 0, Message = "Namnet får inte vara tomt!" }, JsonRequestBehavior.AllowGet);
            }
            if (string.IsNullOrWhiteSpace(photo.Description))
            {
                return Json(new { Status = 0, Message = "Description får inte vara tomt!" }, JsonRequestBehavior.AllowGet);
            }
            if (photoPath == null || photoPath.ContentLength == 0)
            {
                return Json(new { Status = 0, Message = "En fil vill jag gärna att du laddar upp!" }, JsonRequestBehavior.AllowGet);
            }
            var destination = Server.MapPath("~/GalleryImages/");
            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }

            photoPath.SaveAs(Path.Combine(destination, photoPath.FileName));
                photo.PhotoPath = photoPath.FileName;
                photo.PhotoId = Guid.NewGuid();

                await PhotoAutomapper.FromBltoUiInser(photo);
                ViewBag.AlbumId = new SelectList(AlbumAutomapper.FromBltoUiGetAll(), "AlbumId", "AlbumName");
            //return RedirectToAction("Index");


            return RedirectToAction("Index");
        }

        //
        // GET: /photo/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(Guid? photoIdGuid)
        {

            ViewBag.AlbumId = new SelectList(AlbumAutomapper.FromBltoUiGetAll(), "AlbumId", "AlbumName");
            var editMap = await PhotoAutomapper.FromBltoUiGetById((Guid)photoIdGuid);

            return PartialView("_Edit", editMap);
        }

        //
        // POST: /photo/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(PhotoViewModel photo)
        {
            if (ModelState.IsValid)
            {
                await PhotoAutomapper.FromBltoUiEditAsync(photo);
                //return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
