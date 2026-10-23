using Microsoft.AspNetCore.Mvc; 
using DAO;                     
using Entities;                 

namespace API.Controllers
{
    
    [Route("api/[controller]")]
    
    [ApiController]
    public class PlayerController : ControllerBase
    {
     
        private readonly PlayerDAO _playerDAO;

     
        public PlayerController(PlayerDAO playerDAO)
        {
            _playerDAO = playerDAO;
        }

  
        [HttpGet]
        public ActionResult<List<Player>> GetAll()
        {
            return Ok(_playerDAO.GetAll()); 
        }

    
        [HttpGet("{id}")]
        public ActionResult<Player> GetById(long id)
        {
            var player = _playerDAO.GetById(id);
            if (player == null) return NotFound(); 
            return Ok(player);
        }

       
        [HttpPost]
        public ActionResult<Player> Create([FromBody] Player player)
        {
       
            if (string.IsNullOrEmpty(player.Name))
            {
                return BadRequest("El nombre del jugador es requerido.");
            }

            var createdPlayer = _playerDAO.Create(player);
          
            return Created($"/api/player/{createdPlayer.Id}", createdPlayer);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Player player)
        {
            bool updated = _playerDAO.Update(id, player);
            if (!updated) return NotFound();

            return Ok(player);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            bool deleted = _playerDAO.Delete(id);
            if (!deleted) return NotFound();

            return NoContent(); 
        }
    }
}
