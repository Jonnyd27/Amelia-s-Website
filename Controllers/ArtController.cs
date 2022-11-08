using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Dev_Project.Data;
using Web_Dev_Project.Models;

namespace Web_Dev_Project.Controllers
{
    //[Route("/")]
    public class ArtController : Controller
    {
        private MyDBContext dbContext;
        //This is the name of where all the art is stored.
        List<Art> ArtTable = new List<Art>();
        //This is my constructor, info will be transfered to a data base.
        public ArtController(MyDBContext db)
        {
            dbContext = db;
        }
        public IActionResult Index() //This method Is my Index that I plan to have all of my links
        {
            return View("ListAll", dbContext.ArtTable.ToList());
        }
        
        public IActionResult Home()//This is the main page to display Amelias work and catch the eye
        {
            return View();
        }

        public IActionResult About()//This gives personability to Amelia, maybe we will add family pictures
        {
            return View();
        }

        public IActionResult ArtInfo(int id)//This is Amelia Portfolio
        {
            Art a = dbContext.ArtTable.SingleOrDefault(m => m.Id == id);

            if (a != null)
                return View(a);

            //we only get here is the shoe.id was not found
            return NotFound();//404 error - page not found
        }

        public IActionResult ListAll()
        {
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Art art)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            dbContext.ArtTable.Add(art);
            dbContext.SaveChanges();
            return RedirectToAction("Index");

        }

        //This is the get method for my Edit Action
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Art a = dbContext.ArtTable.SingleOrDefault(m => m.Id == id);

            if (a != null)
                return View(a);

            //art id was not found
            return NotFound();
        }
        //This is the get method for my Edit Action
        [HttpPost]
        public IActionResult Edit(int id, Art a)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }


            Art ar = dbContext.ArtTable.SingleOrDefault(m => m.Id == id);
            if(ar != null)
            {
                ar.PieceName = a.PieceName;
                ar.Description = a.Description;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            //a.PieceName = 
            return Content("Art details updated");
        }

        public IActionResult Delete(int id)
        {
            Art a = dbContext.ArtTable.SingleOrDefault(m => m.Id == id);
            if (!ModelState.IsValid)
            {
                dbContext.Remove(a);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        //All of these actions have a view page that will point to each other and give meaningfull information
    }
}
