using LeaveManagement.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Encodings.Web;

namespace LeaveManagement.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class LeaveTypesController : Controller
{
  private readonly AppDbContext _context;

  public LeaveTypesController(AppDbContext context)
  {
    _context = context;
  }

  // GET: LeaveTypes
  [HttpGet]
  public async Task<IActionResult> Index()
  {
    var leaveTypes = await _context.LeaveTypes.ToListAsync(); // Select * from LeaveTypes
    return Ok(leaveTypes);
  }

  // GET: LeaveTypes/Details/5
  [HttpGet("{id}")]
  public async Task<IActionResult> Details(int? id)
  {
    if (id == null)
    {
      return NotFound();
    }

    var leaveType = await _context.LeaveTypes
      .FirstOrDefaultAsync(m => m.Id == id);
    if (leaveType == null)
    {
      return NotFound();
    }

    return Ok(leaveType);
  }

  // GET: LeaveTypes/Create
  public IActionResult Create()
  {
    return Ok();
  }

  // POST: LeaveTypes/Create
  [HttpPost]
  [ValidateAntiForgeryToken]

  public async Task<IActionResult> Create([Bind("Name, DefaultDays, Id, DateCreated, DateModified")] LeaveType leaveType)
  {
    if (ModelState.IsValid)
    {
      _context.Add(leaveType);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }
    return Ok(leaveType);
  }

  // GET: LeaveTypes/Edit/5
  [HttpGet("edit/{id}")]
  public async Task<IActionResult> Edit(int? id)
  {
    if (id == null)
    {
      return NotFound();
    }

    var leaveType = await _context.LeaveTypes.FindAsync(id);
    if (leaveType == null)
    {
      return NotFound();
    }
    return Ok(leaveType);
  }

  // POST: LeaveTypes/Edit/5
  [HttpPost("edit/{id}")]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Edit(int id, [Bind("Name, DefaultDays, Id, DateCreated, DateModified")] LeaveType leaveType)
  {
    if (id != leaveType.Id)
    {
      return NotFound();
    }

    if (ModelState.IsValid)
    {
      try
      {
        _context.Update(leaveType);
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!LeaveTypeExists(leaveType.Id))
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
    return Ok(leaveType);
  }

  // GET: LeaveTypes/Delete/5
  [HttpGet("delete/{id}")]
  public async Task<IActionResult> Delete(int? id)
  {
    if (id == null)
    {
      return NotFound();
    }

    var leaveType = await _context.LeaveTypes
      .FirstOrDefaultAsync(m => m.Id == id);
    if (leaveType == null)
    {
      return NotFound();
    }

    return Ok(leaveType);
  }

  // POST: LeaveTypes/Delete/5
  [HttpPost("delete/{id}"), ActionName("Delete")]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> DeleteConfirmed(int id)
  {
    var leaveType = await _context.LeaveTypes.FindAsync(id);
    _context.LeaveTypes.Remove(leaveType);
    await _context.SaveChangesAsync();
    return RedirectToAction(nameof(Index));
  }

  private bool LeaveTypeExists(int id)
  {
    return _context.LeaveTypes.Any(e => e.Id == id);
  }

}