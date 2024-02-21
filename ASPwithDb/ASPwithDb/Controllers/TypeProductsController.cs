﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPwithDb.Data;

namespace ASPwithDb.Controllers
{
    public class TypeProductsController : Controller
    {
        private readonly ApplicationDbContext _context; //програмното име на БД

        public TypeProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TypeProducts
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypeProducts.ToListAsync());
        }

        // GET: TypeProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeProduct = await _context.TypeProducts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeProduct == null)
            {
                return NotFound();
            }

            return View(typeProduct);
        }

        // GET: TypeProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Discription")] TypeProduct typeProduct)
        {
            typeProduct.DateModification = DateTime.Now;
            if (ModelState.IsValid)
            {
                return View(typeProduct);
            }
            _context.TypeProducts.Add(typeProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: TypeProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeProduct = await _context.TypeProducts.FindAsync(id);
            if (typeProduct == null)
            {
                return NotFound();
            }
            return View(typeProduct);
        }

        // POST: TypeProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Discription")] TypeProduct typeProduct)
        {
            if (id != typeProduct.Id)
            {
                return NotFound();
            }
            typeProduct.DateModification = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return View(typeProduct);
            }
            //когато вс е наред
            try
            {
                _context.TypeProducts.Update(typeProduct);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeProductExists(typeProduct.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: TypeProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeProduct = await _context.TypeProducts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeProduct == null)
            {
                return NotFound();
            }

            return View(typeProduct);
        }

        // POST: TypeProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeProduct = await _context.TypeProducts.FindAsync(id);
            if (typeProduct != null)
            {
                _context.TypeProducts.Remove(typeProduct);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeProductExists(int id)
        {
            return _context.TypeProducts.Any(e => e.Id == id);
        }
    }
}
