using Microsoft.AspNetCore.Mvc;
using Mission06_Rogers.Data;
using Mission06_Rogers.Models;
using System.Linq;

namespace Mission06_Rogers.Controllers;

public class MoviesController : Controller
{
    private readonly MovieCollectionContext _context;

    public MoviesController(MovieCollectionContext context)
    {
        _context = context;
    }

    // Step 5: List all movies
    [HttpGet]
    public IActionResult Index()
    {
        var movies = _context.Movies
            .OrderBy(m => m.Title)
            .ToList();

        return View(movies);
    }

    // Optional: keep Create if you still want it, but Mission 7 focuses on Update and Delete.
    [HttpGet]
    public IActionResult Create()
    {
        return View(new Movie());
    }

    [HttpPost]
    public IActionResult Create(Movie movie)
    {
        if (!ModelState.IsValid)
        {
            return View(movie);
        }

        _context.Movies.Add(movie);
        _context.SaveChanges();

        return View("Confirmation", movie);
    }

    // Step 6: Edit (Update)
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var movie = _context.Movies.FirstOrDefault(m => m.MovieId == id);
        if (movie == null) return NotFound();

        return View(movie);
    }

    [HttpPost]
    public IActionResult Edit(Movie movie)
    {
        if (!ModelState.IsValid)
        {
            return View(movie);
        }

        _context.Movies.Update(movie);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    // Step 7: Delete (Confirm)
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var movie = _context.Movies.FirstOrDefault(m => m.MovieId == id);
        if (movie == null) return NotFound();

        return View(movie);
    }

    // Step 7: Delete (POST)
    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var movie = _context.Movies.FirstOrDefault(m => m.MovieId == id);
        if (movie == null) return NotFound();

        _context.Movies.Remove(movie);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}
