using Microsoft.AspNetCore.Mvc;
using MoodTracker.Model.Base;

namespace MoodTracker.Interfaces {

    public interface IDefaultEntityAccess<TEntity, TDto> where TEntity : BaseEntity where TDto : BaseDTO {

        [HttpGet]
        public Task<ActionResult<IEnumerable<TDto>>> GetRecords();

        [HttpGet("{id}")]
        public Task<ActionResult<TDto>> GetRecord(long id);

        [HttpPut("{id}")]
        public Task<IActionResult> UpdateRecord(long id, TDto recordDto);

        [HttpPost]
        public Task<ActionResult<TDto>> CreateRecord(TDto recordDto);

        [HttpDelete("{id}")]
        public Task<IActionResult> DeleteRecord(long id);
    }
}
