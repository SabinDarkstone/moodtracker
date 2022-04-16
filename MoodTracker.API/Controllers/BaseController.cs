using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoodTracker.Interfaces;
using MoodTracker.Model.Base;
using MoodTracker.Model.Base.Interfaces;
using MoodTracker.Model.Data;

namespace MoodTracker.API.Controllers {

    [ApiController]
    public abstract class BaseController<TEntity, TDto> : ControllerBase, IDefaultEntityAccess<TEntity, TDto>
        where TEntity : BaseEntity, IEntity<TDto>, new()
        where TDto : BaseDTO, IDto<TEntity>, new() {

        protected readonly MoodContext _context;

        protected BaseController(MoodContext context) {
            this._context = context;
        }

        [HttpPost]
        public async Task<ActionResult<TDto>> CreateRecord(TDto recordDto) {
            var record = recordDto.ToEntity();

            _context.Add(record);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetRecord),
                new { Id = record.Id },
                record.ToDTO());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecord(long id) {
            var record = await _context.Set<TEntity>().FindAsync(id);

            if (record == null) {
                return NotFound();
            }

            _context.Set<TEntity>().Remove(record);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TDto>> GetRecord(long id) {
            var record = await _context.Set<TEntity>().FindAsync(id);

            if (record == null) {
                return NotFound();
            }

            return record.ToDTO();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TDto>>> GetRecords() {
            return await _context.Set<TEntity>()
                .Select(x => x.ToDTO())
                .ToListAsync();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecord(long id, TDto recordDto) {
            if (id != recordDto.Id) {
                return BadRequest();
            }

            var record = await _context.Set<TEntity>().FindAsync(id);
            if (record == null) {
                return NotFound();
            }

            record = recordDto.ToEntity();

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) when (!RecordExists(id)) {
                return NotFound();
            }

            return NoContent();
        }

        protected bool RecordExists(long id) {
            return _context.Set<TEntity>().Any(x => x.Id == id);
        }
    }
}
