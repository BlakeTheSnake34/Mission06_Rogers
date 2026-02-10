using Microsoft.AspNetCore.Mvc;
using Mission06_Rogers.Data;
using Mission06_Rogers.Models;

namespace Mission06_Rogers.Controllers;

public class MoviesController : Controller
{
    private readonly MovieCollectionContext _context;

    public MoviesController(MovieCollectionContext context)
    {
        _context = context;
    }

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
}