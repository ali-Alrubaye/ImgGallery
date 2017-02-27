using System;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using businessLayer;
using ViewModels.Models;

namespace ImgGallery.UI.Controllers
{
    public class PhotoController : Controller
    {
        private AlbumAutomapper AlbumAutomapper { get; set; }
        private PhotoAutomapper PhotoAutomapper { get; set; }

        public PhotoController()
        {
            AlbumAutomapper = new AlbumAutomapper();
            PhotoAutomapper = new PhotoAutomapper();
        }
        // GET: /photo/
        public ActionResult Index()
        {
            var g = PhotoAutomapper.FromBltoUiGetAll();
            return View(g);
        }


        //
        // GET: /photo/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var r = await PhotoAutomapper.FromBltoUiGetById(id);
            if (r == null)
            {
                return HttpNotFound();
            }
            return View(r);
        }

        //
        // GET: /photo/Create
        public ActionResult Create()
        {
            ViewBag.AlbumId = new SelectList(AlbumAutomapper.FromBltoUiGetAll(), "AlbumId", "AlbumName");
            return View();
        }

        //
        // POST: /photo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PhotoID,PhotoName,PhotoDate,Description,photoPath,AlbumId")] PhotoViewModel photo, HttpPostedFileBase photoPath)
        {
            if (ModelState.IsValid)
            {
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
                return RedirectToAction("Index");
            }

            return View(photo);
        }

        //
        // GET: /photo/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            //ViewBag.AlbumId = new SelectList(AlbumAutomapper.FromBltoUiGetAll(), "AlbumId", "AlbumName");
            var editMap = await PhotoAutomapper.FromBltoUiGetById(id);

            if (editMap == null)
            {
                return HttpNotFound();
            }
            return PartialView("_EditPhoto", editMap);
        }

        //
        // POST: /photo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PhotoViewModel photo)
        {
            if (ModelState.IsValid)
            {
                await PhotoAutomapper.FromBltoUiEditAsync(photo);
                ViewBag.AlbumId = new SelectList(AlbumAutomapper.FromBltoUiGetAll(), "AlbumId", "AlbumName");
                return RedirectToAction("Index");
            }

            return View(photo);
        }

        //
        // GET: /photo/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            var getFromR = await PhotoAutomapper.FromBltoUiGetById(id);
            if (getFromR == null)
            {
                return HttpNotFound();
            }
            return View(getFromR);
        }

        //
        // POST: /photo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            await PhotoAutomapper.FromBltoUiDeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}