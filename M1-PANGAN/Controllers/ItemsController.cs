using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using M1_PANGAN.Data;
using M1_PANGAN.Models;
using System.Text.Json;

namespace M1_PANGAN.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemsController : ControllerBase
{
    private readonly AppDbContext _db;
    public ItemsController(AppDbContext db) => _db = db;

    private static readonly JsonSerializerOptions JsonOpts = new(JsonSerializerDefaults.Web);

    private string GetUserName() =>
        Request.Headers.TryGetValue("X-User", out var v) && !string.IsNullOrWhiteSpace(v)
            ? v.ToString()
            : "system";

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Item>>> GetAll() =>
        await _db.Items.OrderBy(i => i.Name).ToListAsync();

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Item>> Get(int id) =>
        await _db.Items.FindAsync(id) is { } it ? it : NotFound();

    [HttpPost]
    public async Task<ActionResult<Item>> Create(Item dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name) || string.IsNullOrWhiteSpace(dto.Code))
            return BadRequest("Name and Code are required.");

        try
        {
            _db.Items.Add(dto);
            await _db.SaveChangesAsync();

            _db.Logs.Add(new LogEntry
            {
                Action = "CREATE",
                ItemId = dto.Id,
                Username = GetUserName(),
                BeforeJson = string.Empty,
                AfterJson = JsonSerializer.Serialize(dto, JsonOpts)
            });
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
        }
        catch (DbUpdateException ex) when (ex.InnerException?.Message.Contains("UNIQUE", StringComparison.OrdinalIgnoreCase) == true ||
                                          ex.Message.Contains("UNIQUE", StringComparison.OrdinalIgnoreCase))
        {
            return Conflict("An item with the same Code already exists.");
        }
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Item dto)
    {
        if (id != dto.Id) return BadRequest("Id mismatch.");

        var existing = await _db.Items.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (existing is null) return NotFound();

        try
        {
            _db.Entry(dto).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            _db.Logs.Add(new LogEntry
            {
                Action = "UPDATE",
                ItemId = dto.Id,
                Username = GetUserName(),
                BeforeJson = JsonSerializer.Serialize(existing, JsonOpts),
                AfterJson = JsonSerializer.Serialize(dto, JsonOpts)
            });
            await _db.SaveChangesAsync();

            return NoContent();
        }
        catch (DbUpdateException ex) when (ex.InnerException?.Message.Contains("UNIQUE", StringComparison.OrdinalIgnoreCase) == true ||
                                          ex.Message.Contains("UNIQUE", StringComparison.OrdinalIgnoreCase))
        {
            return Conflict("An item with the same Code already exists.");
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var entity = await _db.Items.FindAsync(id);
        if (entity is null) return NotFound();

        var before = JsonSerializer.Serialize(entity, JsonOpts);

        _db.Items.Remove(entity);
        await _db.SaveChangesAsync();

        _db.Logs.Add(new LogEntry
        {
            Action = "DELETE",
            ItemId = id,
            Username = GetUserName(),
            BeforeJson = before,
            AfterJson = string.Empty
        });
        await _db.SaveChangesAsync();

        return NoContent();
    }
}
