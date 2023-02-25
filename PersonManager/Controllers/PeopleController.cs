using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PersonManager.Dao;
using PersonManager.Models;

namespace PersonManager.Controllers
{
    public class PeopleController : Controller
    {

        private static readonly ICosmosDbService service = CosmosDbServiceProvider.CosmosDbService;

        public async Task<ActionResult> Index()
        {
            return View(await service.GetPersonsAsync("SELECT * FROM People"));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Person person)
        {
            if (ModelState.IsValid)
            {
                person.Id = Guid.NewGuid().ToString();
                await service.AddPersonAsync(person);
                return RedirectToAction("Index");
            }

            return View(person);
        }

        public async Task<ActionResult> Edit(string id) => await ShowItem(id);

        private async Task<ActionResult> ShowItem(string id)
        {
            if (id == null)
            {
                return new StatusCodeResult(400);
            }
            var person = await service.GetPersonAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                await service.UpdatePersonAsync(person);
                return RedirectToAction("Index");
            }
            return View(person);
        }

        public async Task<ActionResult> Delete(string id) => await ShowItem(id);

        [HttpPost]
        public async Task<ActionResult> Delete(Person person)
        {
            await service.DeletePersonAsync(person);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details(string id) => await ShowItem(id);
    }
}
