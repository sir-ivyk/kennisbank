﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kennisbank.Data;
using Kennisbank.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Kennisbank.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly KennisbankContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public DocumentsController(KennisbankContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        // GET: Documents
        public async Task<IActionResult> Index(string documentTag, string searchString, string filter)
        {
            var tagQuery = from d in _context.Document
                           orderby d.Tag
                           select d.Tag;

            var documents = from d in _context.Document
                            select d;

            if (!String.IsNullOrEmpty(searchString))
            {
                if (filter == "addedby")
                {
                    documents = documents.Where(s => s.AddedBy.Contains(searchString));
                }
                else if (filter == "document")
                {
                    documents = documents.Where(s => s.Name.Contains(searchString));
                }
            }

            if (!String.IsNullOrEmpty(documentTag))
            {
                documents = documents.Where(x => x.Tag == documentTag);
            }

            var documentTagVM = new DocumentTagViewModel
            {
                Tags = new SelectList(await tagQuery.Distinct().ToListAsync()),
                Documents = await documents.ToListAsync()
            };

            return View(documentTagVM);
        }

        // GET: Documents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var document = await _context.Document
                .FirstOrDefaultAsync(m => m.Id == id);
            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        // GET: Documents/Create
        public async Task<IActionResult> Create()
        {
            var tags = from t in _context.Tag
                           orderby t.Name
                           select t.Name;

            var documentVM = new DocumentViewModel
            {
                Tags = new SelectList(await tags.Distinct().ToListAsync())
            };

            return View(documentVM);
        }

        // POST: Documents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DocumentViewModel documentVM, IFormFile file)
        {
            var document = new Document { };

            if (ModelState.IsValid)
            {
                var fileSize = file.Length;

                if (fileSize > 0)
                {
                    var filePath = Path.Combine(webHostEnvironment.WebRootPath, "files");
                    var fileName = Path.Combine(file.FileName);
                    filePath = Path.Combine(filePath, fileName);

                    using var stream = new FileStream(filePath, FileMode.Create);
                    await file.CopyToAsync(stream);

                    document = new Document
                    {
                        Name = fileName,
                        FileSize = fileSize,
                        Tag = documentVM.Tag,
                        AddedBy = "mike" // temporary placeholder until actual login is added.
                    };
                }

                _context.Add(document);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(document);
        }

        // GET: Documents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var document = await _context.Document.FindAsync(id);
            if (document == null)
            {
                return NotFound();
            }
            return View(document);
        }

        // POST: Documents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,AddedOn,Tag,AddedBy,FileSize")] Document document)
        {
            if (id != document.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(document);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentExists(document.Id))
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
            return View(document);
        }

        // GET: Documents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var document = await _context.Document
                .FirstOrDefaultAsync(m => m.Id == id);
            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        // POST: Documents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var document = await _context.Document.FindAsync(id);
            _context.Document.Remove(document);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentExists(int id)
        {
            return _context.Document.Any(e => e.Id == id);
        }
    }
}
