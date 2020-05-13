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
    public class ArtistController : Controller
    {
        private readonly ILogger<ArtistController> _logger;

        public ArtistController(ILogger<ArtistController> logger)
        {
            _logger = logger;
        }

        // public ArtistController()
        // {
        //
        /// }
        public IActionResult Index()
        {
            // 1. *************RETRIEVE ALL NAMES DETAILS ******************
            // GET: Names
            try
            {
                List<Artist> artistList = new List<Artist>();
                artistList = ArtistDB.GetArtists();
                ModelState.Clear();
                return View(artistList);
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
                List<Artist> artistList = new List<Artist>();
                //Name tmp1 = new Name() { ID = 1, FirstName = "Dan", LastName = "Test" };
                //Name tmp2 = new Name() { ID = 2, FirstName = "Tom", LastName = "Brady" };
                //myList.Add(tmp1);
                //myList.Add(tmp2);
                artistList = ArtistDB.GetArtists();
                ModelState.Clear();
                return View(artistList);
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
        public IActionResult Create(Artist objModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (ArtistDB.AddArtist(objModel))
                    {
                        ViewBag.Message = "Artist has been successfully added.";
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

        public IActionResult Edit(int artist_id)
        {
            Artist objTest = new Artist();
            objTest = ArtistDB.GetArtist(artist_id);
            return View(objTest);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public IActionResult Edit(int artist_id, Artist objTemp)
        {
            try
            {
                bool updateFlag = ArtistDB.UpdateArtist(objTemp);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View();
            }
        }

        // 4. ************* DELETE NAME DETAILS ******************
        // GET: Name/Delete/5
        public IActionResult ShowDelete(int artist_id)
        {
            Artist objTest = new Artist();
            objTest = ArtistDB.GetArtist(artist_id);
            return View(objTest);

        }
        public IActionResult Delete(int artist_id, Artist objTemp)
        {
            try
            {
                bool deleteFlag = ArtistDB.DeleteArtist(objTemp);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public IActionResult Detail(int artist_id)
        {
            Artist objTest = new Artist();
            objTest = ArtistDB.GetArtist(artist_id);
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