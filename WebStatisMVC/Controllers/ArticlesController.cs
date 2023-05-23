using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebStatisMVC.Data;
using WebStatisMVC.Models;

namespace WebStatisMVC.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly WebStatisMVCContext _context;

        private readonly IWebHostEnvironment _hostingEnvirontment;
        public ArticlesController( WebStatisMVCContext context, IWebHostEnvironment hostingEnvirontment)
        {
            _context = context;
            _hostingEnvirontment = hostingEnvirontment;
        }

        // GET: Articles
        public IActionResult Index()
        {
            /*return _context.Article != null ? 
                        View(await _context.Article.ToListAsync()) :
                        Problem("Entity set 'WebStatisMVCContext.Article'  is null.");*/
            var articles = _context.Articles.ToList();

            return View(articles);
        }

        public IActionResult AllBlog()
        {
            var articles = _context.Articles.ToList();

            return View(articles);
        }

        // GET: Articles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Articles == null)
            {
                return NotFound();
            }

            var article = await _context.Articles
                .FirstOrDefaultAsync(m => m.id == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        public async Task<IActionResult> Full(int? id)
        {
            if (id == null || _context.Articles == null)
            {
                return NotFound();
            }

            var article = await _context.Articles
                .FirstOrDefaultAsync(m => m.id == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // GET: Articles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Title,Description,Excerpt,Publish_date,Author,Time_read,Category")] Articles article, IFormFile? Featured_images)
        {
            if (Featured_images != null)
            {
                string nameFile = Featured_images.FileName;
                string folderPath = Path.Combine(_hostingEnvirontment.WebRootPath, "images");
                string filePath = Path.Combine(folderPath, nameFile);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Featured_images.CopyToAsync(stream);
                }

                article.Featured_images = nameFile;
            }
            if (ModelState.IsValid)
            {
                _context.Add(article);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }

        // GET: Articles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Articles == null)
            {
                return NotFound();
            }

            var article = await _context.Articles.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Title,Description,Excerpt,Publish_date,Author,Time_read,Category")] Articles article, IFormFile? Featured_images)
        {
            if (Featured_images != null)
            {
                string nameFile = Featured_images.FileName;
                string folderPath = Path.Combine(_hostingEnvirontment.WebRootPath, "images");
                string filePath = Path.Combine(folderPath, nameFile);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Featured_images.CopyToAsync(stream);
                }

                article.Featured_images = nameFile;
            }
            if (id != article.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(article);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(article.id))
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
            return View(article);
        }

        // GET: Articles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Articles == null)
            {
                return NotFound();
            }

            var article = await _context.Articles
                .FirstOrDefaultAsync(m => m.id == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Articles == null)
            {
                return Problem("Entity set 'WebStatisMVCContext.Article'  is null.");
            }
            var article = await _context.Articles.FindAsync(id);
            if (article != null)
            {
                _context.Articles.Remove(article);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int id)
        {
            return (_context.Articles?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
