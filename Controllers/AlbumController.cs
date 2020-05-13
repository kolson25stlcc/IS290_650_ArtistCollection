using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ArtistCollection.Models;

namespace ArtistCollection.Controllers
{
    public class AlbumController : Controller
    {
        private readonly ILogger<AlbumController> _logger;

        public AlbumController(ILogger<AlbumController> logger)
        {
            _logger = logger;
        }

        // public AlbumController()
        // {
        //
        /// }
        public IActionResult Index()
        {
            // 1. *************RETRIEVE ALL NAMES DETAILS ******************
            // GET: Names
            try
            {
                List<Album> albumList = new List<Album>();
                albumList = AlbumDB.GetAlbums();
                ModelState.Clear();
                return View(albumList);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public IActionResult ShowData()
        {
            // 1. *************RETRIEVE ALL NAMES DETAILS ******************
            // GET: Names
            try
            {
                List<Album> albumList = new List<Album>();
                //Name tmp1 = new Name() { ID = 1, FirstName = "Dan", LastName = "Test" };
                //Name tmp2 = new Name() { ID = 2, FirstName = "Tom", LastName = "Brady" };
                //myList.Add(tmp1);
                //myList.Add(tmp2);
                albumList = AlbumDB.GetAlbums();
                ModelState.Clear();
                return View(albumList);
            }
            catch (Exception ex)
            {
                return View();
                //throw;
            }
        }

        // 2. *************ADD A NEW NAME RECORD ******************
        // GET: Name/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Name/Create
        [HttpPost]
        public IActionResult Create(Album objModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (AlbumDB.AddAlbum(objModel))
                    {
                        ViewBag.Message = "Album has been successfully added.";
                        ModelState.Clear();
                    }

                }
                return View();

            }
            catch (Exception)
            {
                return View();
            }
        }

        // 3. ************* EDIT NAME DETAILS ******************
        // GET: Name/Edit/3

        public IActionResult Edit(int album_id)
        {
            Album objTest = new Album();
            objTest = AlbumDB.GetAlbum(album_id);
            return View(objTest);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public IActionResult Edit(int album_id, Album objTemp)
        {
            try
            {
                bool updateFlag = AlbumDB.UpdateAlbum(objTemp);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View();
            }
        }

        // 4. ************* DELETE NAME DETAILS ******************
        // GET: Name/Delete/5
        public IActionResult Delete(int album_id)
        {
            Album objTest = new Album();
            objTest = AlbumDB.GetAlbum(album_id);
            return View(objTest);

        }
        [HttpPost]
        public IActionResult Delete(int album_id, Album objTemp)
        {
            try
            {
                bool deleteFlag = AlbumDB.DeleteAlbum(objTemp);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public IActionResult Detail(int album_id)
        {
            Album objTest = new Album();
            objTest = AlbumDB.GetAlbum(album_id);
            return View(objTest);

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
