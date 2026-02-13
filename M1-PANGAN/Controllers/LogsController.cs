using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using M1_PANGAN.Data;
using M1_PANGAN.Models;

namespace M1_PANGAN.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LogsController : ControllerBase
{
    private readonly AppDbContext _db;
    public LogsController(AppDbContext db) { _db = db; }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LogEntry>>> Get() =>
        await _db.Logs.AsNoTracking().OrderByDescending(l => l.TimestampUtc).ToListAsync();
}
