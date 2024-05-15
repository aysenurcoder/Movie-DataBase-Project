using MovieDataBase.Models;
using System.Linq;
using System.Web.Mvc;


namespace MovieDataBase.Controllers
{
    public class HomeController : Controller
    {
        private MoviesEntities1 _db = new MoviesEntities1();
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View(_db.Movies1.ToList());
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            var movieToDetails = _db.Movies1.Find(id);
            return View(movieToDetails);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(Movie newMovie)
        {
            if (ModelState.IsValid)
            {
                _db.Movies1.Add(newMovie);
                _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return View(newMovie);
            }

        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            var movieToEdit = _db.Movies1.Find(id);
            return View(movieToEdit);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(Movie movieToEdit)
        {
            var originalMovie = _db.Movies1.Find(movieToEdit.Id);
            try
            {
                // TODO: Add update logic here
                if (TryUpdateModel(originalMovie,
                    new string[] { "Title", "Director", "Realease_date" }))
                {
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(originalMovie);
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            var movieToDelete = _db.Movies1.Find(id);
            return View(movieToDelete);
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(Movie movieToDelete)
        {
            try
            {
                // TODO: Add delete logic here
                var selMovie = _db.Movies1.Find(movieToDelete.Id);
                if (!ModelState.IsValid)
                    return View(selMovie);
                _db.Movies1.Remove(selMovie);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(movieToDelete);
            }
        }
    }
}
