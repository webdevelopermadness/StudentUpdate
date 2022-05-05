using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentUpdate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        private readonly StudentContext _context;
        public StudentsController(StudentContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Model.Student>>> GetStudent() => await _context.Students.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Model.Student>> GetStudent(Guid id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null) return NotFound("Incorrect Id passed Or Not Found");

            return student;
        }
        [HttpPost]
        public async Task<ActionResult<Model.Student>> PostStudent(Model.Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }

        [HttpPut]
        public async Task<IActionResult> PutStudent(Guid id, Model.Student student)
        {
            if (id != student.Id) return BadRequest();

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!StudentExists(id))
                    return NotFound();
                else
                    throw new Exception(ex.Message, ex);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(Guid id) => _context.Students.Any(e => e.Id == id);

    }
}
