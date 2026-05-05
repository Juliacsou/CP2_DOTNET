using CP2_DOTNET.Data;
using CP2_DOTNET.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace CP2_DOTNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PetController(ApplicationContext context)
        {
            _context = context;
        }

        [SwaggerOperation(
            Summary = "Lista todos os pets",
            Description = "Retorna a lista completa de pets cadastrados."
        )]
        [SwaggerResponse(statusCode: 200, description: "Pets retornados com sucesso")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var pets = await _context.Pets.ToListAsync();
            return Ok(pets);
        }

        [SwaggerOperation(
            Summary = "Busca pet por ID",
            Description = "Retorna um pet específico com base no ID informado."
        )]
        [SwaggerResponse(statusCode: 200, description: "Pet encontrado com sucesso")]
        [SwaggerResponse(statusCode: 404, description: "Pet não encontrado")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var pet = await _context.Pets
                .Include(p => p.Tutor)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pet == null)
                return NotFound();

            return Ok(pet);
        }

        [SwaggerOperation(
            Summary = "Cadastra um novo pet",
            Description = "Cria um novo pet vinculado a um tutor existente."
        )]
        [SwaggerResponse(statusCode: 200, description: "Pet criado com sucesso")]
        [SwaggerResponse(statusCode: 400, description: "Dados inválidos ou tutor não encontrado")]
        [HttpPost]
        public async Task<IActionResult> Post(Pet pet)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var tutor = await _context.Tutores.FindAsync(pet.TutorId);

            if (tutor == null)
                return BadRequest("Tutor não encontrado.");

            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();

            return Ok(pet);
        }

        [SwaggerOperation(
            Summary = "Atualiza um pet",
            Description = "Atualiza os dados de um pet existente."
        )]
        [SwaggerResponse(statusCode: 200, description: "Pet atualizado com sucesso")]
        [SwaggerResponse(statusCode: 400, description: "Dados inválidos ou tutor não encontrado")]
        [SwaggerResponse(statusCode: 404, description: "Pet não encontrado")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Pet pet)
        {
            var petExistente = await _context.Pets.FindAsync(id);

            if (petExistente == null)
                return NotFound();

            var tutor = await _context.Tutores.FindAsync(pet.TutorId);

            if (tutor == null)
                return BadRequest("Tutor não encontrado.");

            petExistente.Nome = pet.Nome;
            petExistente.Especie = pet.Especie;
            petExistente.Raca = pet.Raca;
            petExistente.Idade = pet.Idade;
            petExistente.TutorId = pet.TutorId;

            _context.Pets.Update(petExistente);
            await _context.SaveChangesAsync();

            return Ok(petExistente);
        }

        [SwaggerOperation(
            Summary = "Remove um pet",
            Description = "Exclui um pet com base no ID informado."
        )]
        [SwaggerResponse(statusCode: 204, description: "Pet removido com sucesso")]
        [SwaggerResponse(statusCode: 404, description: "Pet não encontrado")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pet = await _context.Pets.FindAsync(id);

            if (pet == null)
                return NotFound();

            _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}