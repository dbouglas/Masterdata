using Microsoft.AspNetCore.Mvc;
using Masterdata.Data;
using Masterdata.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Masterdata.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index(string startDate, string endDate)
        {
            ViewBag.UserName = TempData["UserName"];

            IEnumerable<Desembarque> data = DesembarqueRepository.GetAll();

            if (DateTime.TryParse(startDate, out var start))
            {
                data = data.Where(d => d.FechaGrabacion >= start);
            }
            if (DateTime.TryParse(endDate, out var end))
            {
                data = data.Where(d => d.FechaGrabacion <= end);
            }

            var noRevisados = data.Where(d => !d.Revisado);
            var revisados = data.Where(d => d.Revisado);

            ViewBag.NoRevisados = noRevisados;
            ViewBag.Revisados = revisados;

            return View();
        }

        [HttpPost]
        public IActionResult MarkReviewed(int[] ids)
        {
            var items = DesembarqueRepository.GetAll().Where(d => ids.Contains(d.Id));
            foreach (var i in items)
            {
                i.Revisado = true;
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var list = DesembarqueRepository.GetAll().ToList();
            var item = list.FirstOrDefault(d => d.Id == id);
            if (item != null)
            {
                list.Remove(item);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item = DesembarqueRepository.GetAll().FirstOrDefault(d => d.Id == id);
            if (item == null) return RedirectToAction("Index");
            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(Desembarque model)
        {
            var item = DesembarqueRepository.GetAll().FirstOrDefault(d => d.Id == model.Id);
            if (item != null) { item.Referencia = model.Referencia; }
            return RedirectToAction("Index");
        }
    }
}
