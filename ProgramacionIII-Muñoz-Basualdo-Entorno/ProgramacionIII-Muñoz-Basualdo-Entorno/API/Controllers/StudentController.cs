using Microsoft.AspNetCore.Mvc; 
using Entities;                
using DAO;                      

namespace API.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDAO _studentDAO;

      
        public StudentController(StudentDAO studentDAO)
        {
            _studentDAO = studentDAO;
        }

 
        [HttpGet]
        public ActionResult<List<Student>> GetAll()
        {
            return Ok(_studentDAO.GetAll()); 
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetById(long id)
        {
            var student = _studentDAO.GetById(id);
            if (student == null) return NotFound(); 
            return Ok(student); 
        }

        [HttpPost]
        public ActionResult<Student> Create([FromBody] Student student)
        {
           
            if (string.IsNullOrEmpty(student.Name) || string.IsNullOrEmpty(student.File))
            {
                return BadRequest("El nombre y el legajo son obligatorios.");
            }

            var createdStudent = _studentDAO.Create(student);
            return Created($"/api/student/{createdStudent.Id}", createdStudent);
        }

       
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Student student)
        {
            bool updated = _studentDAO.Update(id, student);
            if (!updated) return NotFound(); 

            return Ok(student); 
        }

   
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            bool deleted = _studentDAO.Delete(id);
            if (!deleted) return NotFound();

            return NoContent(); 
        }
    }
}
