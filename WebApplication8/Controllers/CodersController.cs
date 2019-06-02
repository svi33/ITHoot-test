using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication8.Data;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class CodersController : Controller
    {
        private readonly CProjectContext _context;

        public CodersController(CProjectContext context)
        {
            _context = context;
        }

        // GET: Coders
        public ActionResult Index()
        {
            return View( _context.Coders.ToList());
        }

        // GET: Coders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coder = await _context.Coders
                .FirstOrDefaultAsync(m => m.CoderID == id);
            if (coder == null)
            {
                return NotFound();
            }

            return View(coder);
        }

        // GET: Coders/Details/5
        public ActionResult p_Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coder = _context.Coders
                .FirstOrDefault(m => m.CoderID == id);
            if (coder == null)
            {
                return NotFound();
            }

            return PartialView(coder);
        }



        // GET: Coders/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: Coders/Create
        public ActionResult p_Create()
        {
            return PartialView();
        }

        // POST: Coders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CoderID,Name,CoderInfo")] Coder coder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coder);
        }

        // GET: Coders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coder = await _context.Coders.FindAsync(id);
            if (coder == null)
            {
                return NotFound();
            }
            return View(coder);
        }

        // GET: Coders/Edit/5
        public ActionResult p_Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coder = _context.Coders.Find(id);
            if (coder == null)
            {
                return NotFound();
            }
            return PartialView(coder);
        }




        // POST: Coders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Coder coder)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoderExists(coder.CoderID))
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
            return View(coder);
        }

        // GET: Coders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coder = await _context.Coders
                .FirstOrDefaultAsync(m => m.CoderID == id);
            if (coder == null)
            {
                return NotFound();
            }

            return View(coder);
        }

        // GET: Coders/Delete/5
        public ActionResult p_Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coder = _context.Coders
                .FirstOrDefault(m => m.CoderID == id);
            if (coder == null)
            {
                return NotFound();
            }

            return View(coder);
        }



        // POST: Coders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Coder cod)
        {
            var coder = await _context.Coders.FindAsync(cod.CoderID);
            _context.Coders.Remove(coder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoderExists(int id)
        {
            return _context.Coders.Any(e => e.CoderID == id);
        }
    }
}
