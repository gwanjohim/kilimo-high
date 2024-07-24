using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KilmoniCloud.Data;

namespace KilmoniCloud.Controllers
{
    public class FormStreamsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public FormStreamsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: FormStreams
        public async Task<IActionResult> Index()
        {
            return View(await _context.FormStreams.ToListAsync());
        }

        // GET: FormStreams/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formStream = await _context.FormStreams
                .FirstOrDefaultAsync(m => m.FormStreamId == id);
            if (formStream == null)
            {
                return NotFound();
            }

            return View(formStream);
        }

        // GET: FormStreams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FormStreams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FormStreamId,Name")] FormStream formStream)
        {
            if (ModelState.IsValid)
            {
                formStream.FormStreamId = Guid.NewGuid();
                _context.Add(formStream);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(formStream);
        }

        // GET: FormStreams/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formStream = await _context.FormStreams.FindAsync(id);
            if (formStream == null)
            {
                return NotFound();
            }
            return View(formStream);
        }

        // POST: FormStreams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("FormStreamId,Name")] FormStream formStream)
        {
            if (id != formStream.FormStreamId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formStream);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormStreamExists(formStream.FormStreamId))
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
            return View(formStream);
        }

        // GET: FormStreams/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formStream = await _context.FormStreams
                .FirstOrDefaultAsync(m => m.FormStreamId == id);
            if (formStream == null)
            {
                return NotFound();
            }

            return View(formStream);
        }

        // POST: FormStreams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var formStream = await _context.FormStreams.FindAsync(id);
            if (formStream != null)
            {
                _context.FormStreams.Remove(formStream);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormStreamExists(Guid id)
        {
            return _context.FormStreams.Any(e => e.FormStreamId == id);
        }
    }
}
