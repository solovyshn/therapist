using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using psycotherapist.Dto;

namespace psycotherapist.Controllers
{
    [ApiController]
    [Route("/psycotherapists")]
    public class PsycotherapistsController : ControllerBase
    {
        private readonly PsychiatricHospitalContext _context;

        public PsycotherapistsController(PsychiatricHospitalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetPsycotherapists()
        {
            var patients = await _context.Psycotherapists.ToListAsync();
            var result = patients.Select(p => p.ToDto());

            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPsycotherapist([FromRoute] int? id)
        {
            if (id == null || _context.Psycotherapists == null)
            {
                return NotFound();
            }

            var patient = await _context.Psycotherapists.Include(p => p.Calendar).FirstOrDefaultAsync(p => p.Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient.ToDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreatePsycotherapistDto dto)
        {
            var newPsycotherapist = new Psycotherapist
            {
                Name = dto.Name,
                Address = dto.Address,
                Password = dto.Password,
            };

            await _context.Psycotherapists.AddAsync(newPsycotherapist);
            await _context.SaveChangesAsync();

            return Ok(newPsycotherapist.ToDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int? id, CreatePsycotherapistDto dto)
        {
            if (id == null || _context.Psycotherapists == null)
            {
                return NotFound();
            }

            var psycotherapist = await _context.Psycotherapists.FindAsync(id);
            if (psycotherapist == null)
            {
                return NotFound();
            }

            psycotherapist.Name = dto.Name;
            psycotherapist.Address = dto.Address;
            psycotherapist.Password = dto.Password;

            _context.Psycotherapists.Update(psycotherapist);
            await _context.SaveChangesAsync();

            return Ok(psycotherapist.ToDto());
        }
    }
}
