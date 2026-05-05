using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CP2_DOTNET.Data;
using CP2_DOTNET.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace CP2_DOTNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TutorController(ApplicationContext context)
        {
            _context = context;
        }

        [SwaggerOperation(
            Summary = "Lista todos os tutores",
            Description = "Retorna a lista completa de tutores cadastrados."
        )]
        [SwaggerResponse(statusCode: 200, description: "Tutores retornados com sucesso")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tutores = await _context.Tutores.ToListAsync();
            return Ok(tutores);
        }

        [SwaggerOperation(
            Summary = "Busca tutor por ID",
            Description = "Retorna um tutor específico com base no ID informado."
        )]
        [SwaggerResponse(statusCode: 200, description: "Tutor encontrado com sucesso")]
        [SwaggerResponse(statusCode: 404, description: "Tutor não encontrado")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var tutor = await _context.Tutores.FindAsync(id);

            if (tutor == null)
                return NotFound();

            return Ok(tutor);
        }

        [SwaggerOperation(
            Summary = "Cadastra um novo tutor",
            Description = "Cria um novo tutor no sistema."
        )]
        [SwaggerResponse(statusCode: 200, description: "Tutor criado com sucesso")]
        [SwaggerResponse(statusCode: 400, description: "Dados inválidos")]
        [HttpPost]
        public async Task<IActionResult> Post(Tutor tutor)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Tutores.Add(tutor);
            await _context.SaveChangesAsync();

            return Ok(tutor);
        }

        [SwaggerOperation(
            Summary = "Atualiza um tutor",
            Description = "Atualiza os dados de um tutor existente."
        )]
        [SwaggerResponse(statusCode: 200, description: "Tutor atualizado com sucesso")]
        [SwaggerResponse(statusCode: 404, description: "Tutor não encontrado")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Tutor tutor)
        {
            var tutorExistente = await _context.Tutores.FindAsync(id);

            if (tutorExistente == null)
                return NotFound();

            tutorExistente.Nome = tutor.Nome;
            tutorExistente.Email = tutor.Email;
            tutorExistente.Telefone = tutor.Telefone;

            _context.Tutores.Update(tutorExistente);
            await _context.SaveChangesAsync();

            return Ok(tutorExistente);
        }

        [SwaggerOperation(
            Summary = "Remove um tutor",
            Description = "Exclui um tutor com base no ID informado."
        )]
        [SwaggerResponse(statusCode: 204, description: "Tutor removido com sucesso")]
        [SwaggerResponse(statusCode: 404, description: "Tutor não encontrado")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tutor = await _context.Tutores.FindAsync(id);

            if (tutor == null)
                return NotFound();

            _context.Tutores.Remove(tutor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [SwaggerOperation(
            Summary = "Lista pets de um tutor",
            Description = "Retorna todos os pets vinculados a um tutor específico."
        )]
        [SwaggerResponse(statusCode: 200, description: "Pets retornados com sucesso")]
        [SwaggerResponse(statusCode: 404, description: "Tutor não encontrado")]
        [HttpGet("{id}/pets")]
        public async Task<IActionResult> GetPetsDoTutor(int id)
        {
            var tutor = await _context.Tutores.FindAsync(id);

            if (tutor == null)
                return NotFound("Tutor não encontrado.");

            var pets = await _context.Pets
                .Where(p => p.TutorId == id)
                .ToListAsync();

            return Ok(pets);
        }
    }
}