using Microsoft.AspNetCore.Mvc;
using SongApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongApp.Controllers
{
    public class SongController:Controller
    {
        private readonly AppDataContext context;

        public SongController(AppDataContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var sngs = context.Songs.ToList();
            return View(sngs);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Song model)
        {
            if (!ModelState.IsValid) return View(model);
            context.Add(model);
            context.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var sngs = context.Songs.Find(id);
            return View(sngs);
        }

        [HttpPost]
        public IActionResult Edit(Song model)
        {
            if (!ModelState.IsValid) return View(model);
            context.Songs.Update(model);
            context.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var sngs = context.Songs.Find(id);
            context.Songs.Remove(sngs);
            context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
