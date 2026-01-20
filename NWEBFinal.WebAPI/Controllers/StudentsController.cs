using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NWEBFinal.Application.DTOs;
using NWEBFinal.Application.Services;

namespace NWEBFinal.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _svc;
        public StudentsController(IStudentService svc) => _svc = svc;

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _svc.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var s = await _svc.GetByIdAsync(id);
            return s is null ? NotFound() : Ok(s);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StudentDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var created = await _svc.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.StudentId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] StudentDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return await _svc.UpdateAsync(id, dto)
                ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
            => await _svc.DeleteAsync(id)
                ? NoContent() : NotFound();
    }
}
