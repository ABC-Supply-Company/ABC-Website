using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABCSupplyCompany.Models;
using ABCSupplyCompany.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ABCSupplyCompany.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        private readonly ILogger<AdminController> _loggerAdmin;
        public IConfiguration Configuration { get; }
        public AdminController(ILogger<AdminController> loggerAdmin, IConfiguration configuration)
        {
            _loggerAdmin = loggerAdmin;
            Configuration = configuration;
        }
        public ActionResult Index()
        {
            string connString = Configuration["ConnectionStrings:DefaultConnection"];
            return View("Index", InventoryAction.GetFullInventory(connString));
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                InventoryItem item = new InventoryItem();
                item.lottag_number = collection["lottag_number"];
                item.lottag_description = collection["lottag_description"];
                item.weight_net = collection["weight_net"];
                item.on_hand_balance = collection["on_hand_balance"];
                item.unit_of_measure = collection["unit_of_measure"];
                item.active = Convert.ToBoolean(collection["active"].ToString().Split(',')[0]);


                string connString = Configuration["ConnectionStrings:DefaultConnection"];
                bool IsCreated = InventoryAction.CreateInventoryItem(connString, item);

                if (IsCreated)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View("ErrorUpdating");
                }                
            }
            catch
            {
                return View("ErrorUpdating");
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            string connString = Configuration["ConnectionStrings:DefaultConnection"];
            InventoryItem item = new InventoryItem();
            item = InventoryAction.GetInventoryItem(connString, id);

            return View(item);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                InventoryItem item = new InventoryItem();
                item.id = int.Parse(collection["id"]);
                item.lottag_number = collection["lottag_number"];
                item.lottag_description = collection["lottag_description"];
                item.weight_net = collection["weight_net"];
                item.on_hand_balance = collection["on_hand_balance"];
                item.unit_of_measure = collection["unit_of_measure"];
                item.active = Convert.ToBoolean(collection["active"].ToString().Split(',')[0]); 


                string connString = Configuration["ConnectionStrings:DefaultConnection"];                
                bool IsUpdated = InventoryAction.UpdateInventoryItem(connString, item);

                if (IsUpdated)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View("ErrorUpdating");
                }
            }
            catch
            {
                return View("ErrorUpdating");
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            string connString = Configuration["ConnectionStrings:DefaultConnection"];
            InventoryItem item = new InventoryItem();
            item = InventoryAction.GetInventoryItem(connString, id);

            return View(item);           
        }

        // POST: Admin/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                string connString = Configuration["ConnectionStrings:DefaultConnection"];
                bool IsDeleted = InventoryAction.DeleteInventoryItem(connString, id);

                if (IsDeleted)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View("ErrorDeleting");
                }

                
            }
            catch
            {
                return View("ErrorDeleting");
            }
        }
    }
}