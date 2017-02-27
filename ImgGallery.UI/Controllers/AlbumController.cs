using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using businessLayer;
using ViewModels.Models;

namespace ImgGallery.UI.Controllers
{
    public class AlbumController : Controller
    {

        private AlbumAutomapper AlbumAutomapper { get; set; }
        private PhotoAutomapper PhotoAutomapper { get; set; }

        public AlbumController()
        {
            AlbumAutomapper = new AlbumAutomapper();
            PhotoAutomapper = new PhotoAutomapper();
        }
        //
        // GET: /Album/
        public ActionResult Index()
        {
            var g = AlbumAutomapper.FromBltoUiGetAll();
            return View(g);
        }

        //
        // GET: /Album/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var r = await AlbumAutomapper.FromBltoUiGetById(id);
            if (r == null)
            {
                return HttpNotFound();
            }
            return View(r);
        }

        //
        // GET: /Album/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Album/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AlbumViewModel album)
        {
            if (ModelState.IsValid)
            {
                album.AlbumId = Guid.NewGuid();
                await AlbumAutomapper.FromBltoUiInser(album);
                return RedirectToAction("Index");
            }

            return View(album);
        }

        //
        // GET: /Album/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {

            var editMap = await AlbumAutomapper.FromBltoUiGetById(id);

            if (editMap == null)
            {
                return HttpNotFound();
            }
            return View(editMap);
        }

        //
        // POST: /Album/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AlbumViewModel album)
        {
            if (ModelState.IsValid)
            {
                await AlbumAutomapper.FromBltoUiEditAsync(album);
                return RedirectToAction("Index");
            }
            return View(album);
        }

        //
        // GET: /Album/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            var getFromR = await AlbumAutomapper.FromBltoUiGetById(id);
            if (getFromR == null)
            {
                return HttpNotFound();
            }
            return View(getFromR);
        }

        //
        // POST: /Album/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            await AlbumAutomapper.FromBltoUiDeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
