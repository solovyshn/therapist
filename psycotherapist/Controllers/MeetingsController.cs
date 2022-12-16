using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using psycotherapist.Dto;

namespace psycotherapist.Controllers
{
    [ApiController]
    [Route("/meetings")]
    public class MeetingsController : ControllerBase
    {
        private readonly PsychiatricHospitalContext _context;

        public MeetingsController(PsychiatricHospitalContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetMeetings()
        {
            var meetings = await _context.Meetings.ToListAsync();
            var result = meetings.Select(d => d.ToDto());

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details([FromRoute] int? id)
        {
            if (id == null || _context.Meetings == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meetings.FindAsync(id);
            if (meeting == null)
            {
                return NotFound();
            }

            return Ok(meeting.ToDto());
        }
        [HttpGet("find/{word}")]
        public async Task<IActionResult> Find([FromRoute] string? word)
        {
            if (word == null || _context.Meetings == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meetings.FirstOrDefaultAsync(i=>i.Description.Contains(word));
            if (meeting == null)
            {
                return NotFound();
            }

            return Ok(meeting.ToDto());
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Create([FromRoute] int id, CreateMeetingDto dto)
        {
            var newDisease = new Meeting
            {      
                Name = dto.Name,
                Description = dto.Description,
                FirstMeeting = dto.FirstMeeting,
                FrequencyTime =dto.FrequencyTime,
                PsycotherapistId = dto.PsycotherapistId,
            };

            await _context.Meetings.AddAsync(newDisease);
            await _context.SaveChangesAsync();

            return Ok(newDisease.ToDto());
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int? id, CreateMeetingDto dto)
        {
            if (id == null || _context.Meetings == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meetings.FindAsync(id);
            if (meeting == null)
            {
                return NotFound();
            }

            meeting.Name = dto.Name;
            meeting.Description = dto.Description;
            meeting.FirstMeeting = dto.FirstMeeting;
            meeting.FrequencyTime = dto.FrequencyTime;
            meeting.PsycotherapistId = dto.PsycotherapistId;

            _context.Meetings.Update(meeting);
            await _context.SaveChangesAsync();

            return Ok(meeting.ToDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int? id)
        {
            if (id == null || _context.Meetings == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meetings.FindAsync(id);
            if (meeting == null)
            {
                return NotFound();
            }

            _context.Meetings.Remove(meeting);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
