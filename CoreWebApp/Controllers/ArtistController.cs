using CoreWebApp.Models;
using CoreWebApp.Models.ViewModels;
using CoreWebApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebApp.Controllers
{
    public class ArtistController : Controller
    {
        private IArtistRepository _artistRepository;
        private IWebHostEnvironment _env;

        public ArtistController(IArtistRepository artistRepository, IWebHostEnvironment env)
        {
            _artistRepository = artistRepository;
            _env = env;
        }

        public IActionResult Index()
        {
            IEnumerable<Artist> list = _artistRepository.GetAllArtists().ToList();
            ViewBag.Title = "Artist List";
            return View(list);
        }
        public IActionResult Details(int id)
        {
            Artist model = _artistRepository.GetArtistById(id);
            string name = model.ArtistName;
            ViewBag.Title = "Artist Details";
            return View(model);
        }
        public IActionResult Create()
        {
            ViewBag.Title = "Artist Create";
            return View();
        }
        [HttpPost]
        public IActionResult Create(ArtistInsertViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadFile(model);

                Artist newArtist = new Artist
                {
                    ArtistName = model.Name,
                    Email = model.Email,
                    Medium = model.Medium,
                    PicturePath = uniqueFileName
                };
                _artistRepository.Save(newArtist);
                return RedirectToAction("Details", new { id = newArtist.ArtistId });

            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            Artist artist = _artistRepository.GetArtistById(id);
            ArtistUpdateViewModel model = new ArtistUpdateViewModel
            {
                Id = artist.ArtistId,
                Name = artist.ArtistName,
                Email = artist.Email,
                Medium = artist.Medium,
                ExistingPicturepath = artist.PicturePath
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ArtistUpdateViewModel model)
        {
            try
            {
                Artist artist = _artistRepository.GetArtistById(model.Id);
                artist.ArtistName = model.Name;
                artist.Email = model.Email;
                artist.Medium = model.Medium;

                if (model.Picture != null)
                {
                    // If there's an existing picture, attempt to delete it
                    if (model.ExistingPicturepath != null)
                    {
                        string filePath = Path.Combine(_env.WebRootPath, "images", model.ExistingPicturepath);

                        if (System.IO.File.Exists(filePath))
                        {
                            try
                            {
                                System.IO.File.Delete(filePath);
                            }
                            catch (UnauthorizedAccessException ex)
                            {
                                // Log exception or handle it according to your needs
                                ModelState.AddModelError("", "Unable to delete the existing picture file. Permission denied.");
                            }
                        }
                    }

                    // Upload the new picture and save the file path
                    artist.PicturePath = ProcessUploadFile(model);
                }

                // Update the artist in the repository
                Artist updatedArtist = _artistRepository.Update(artist);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Handle any other exceptions and display an error message
                ModelState.AddModelError("", "An error occurred while updating the artist.");
                return View(model);  // Return to the view with the error message
            }
        }




        //[HttpPost]
        //public IActionResult Edit(ArtistUpdateViewModel model)
        //{
        //    //if (ModelState.IsValid)
        //    {
        //        Artist artist = _artistRepository.GetArtistById(model.Id);
        //        artist.ArtistName = model.Name;
        //        artist.Email = model.Email;
        //        artist.Medium = model.Medium;
        //        if (model.Picture != null)
        //        {
        //            if (model.ExistingPicturepath != null)
        //            {
        //                string filePath1 = Path.Combine(_env.WebRootPath, "images", model.ExistingPicturepath);
        //                System.IO.File.Delete(filePath1);

        //            }

        //            artist.PicturePath = ProcessUploadFile(model);


        //        }
        //        Artist upArtist = _artistRepository.Update(artist);
        //        return RedirectToAction("Index");
        //    }

        //}

        public IActionResult Delete(int id)
        {
            Artist artist = _artistRepository.GetArtistById(id);
            if (artist != null)
            {
                _artistRepository.Delete(artist.ArtistId);
                return RedirectToAction("Index");
            }

            return View();
        }

        private string ProcessUploadFile(ArtistInsertViewModel model)
        {
            string uniqueFileName = "";
            if (model.Picture != null)
            {
                string uploadFolder = Path.Combine(_env.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Picture.FileName;
                string filePath = Path.Combine(uploadFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Picture.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
