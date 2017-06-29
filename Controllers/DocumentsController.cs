using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarkCollab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarkCollab.Controllers {
  [Route("api/docs")]
  public class DocumentsController : Controller {
    private MarkCollabDbContext _context;
    public DocumentsController(MarkCollabDbContext context) {
      _context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<Document>> GetAllAsync() {
      return await _context.Documents.ToListAsync();
    }

    [HttpPost("{title}")]
    public async Task<IActionResult> AddNew(string title) {
      var doc = new Document(title);
      _context.Documents.Add(doc);
      if (await _context.SaveChangesAsync() > 0) {
        return Created(Url.ToString(), doc);
      }
      else return BadRequest();
    }
  }
}