using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TherapyApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TherapyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartsController : ControllerBase
    {
        private readonly PatientContext _context;
        private readonly IMapper _mapper;

        public PartsController(PatientContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Parts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PartDTO>>> GetParts()
        {
            var parts = await _context.Parts.ToListAsync();
            return _mapper.Map<List<PartDTO>>(parts);
        }

        // GET: api/Parts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PartDTO>> GetPart(int id)
        {
            var part = await _context.Parts.FindAsync(id);

            if (part == null)
            {
                return NotFound();
            }

            return _mapper.Map<PartDTO>(part);
        }

        // PUT: api/Parts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPart(int id, PartDTO partDTO)
        {
            if (id != partDTO.Id)
            {
                return BadRequest();
            }

            var part = await _context.Parts.FindAsync(id);

            if (part == null)
            {
                return NotFound();
            }

            _mapper.Map(partDTO, part);
            _context.Entry(part).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Parts
        [HttpPost]
        public async Task<ActionResult<PartDTO>> PostPart(PartDTO partDTO)
        {
            var part = _mapper.Map<Part>(partDTO);
            _context.Parts.Add(part);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPart), new { id = part.Id }, _mapper.Map<PartDTO>(part));
        }

        // DELETE: api/Parts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePart(int id)
        {
            var part = await _context.Parts.FindAsync(id);
            if (part == null)
            {
                return NotFound();
            }

            _context.Parts.Remove(part);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        // GET: api/parts/{partId}/customquestions
        [HttpGet("{partId}/customquestions")]
        public async Task<ActionResult<IEnumerable<CustomQuestionDTO>>> GetCustomQuestions(int partId)
        {
            if (!PartExists(partId))
            {
                return NotFound();
            }

            var customQuestions = await _context.CustomQuestions
                .Where(cq => cq.PartId == partId)
                .ToListAsync();

            return _mapper.Map<List<CustomQuestionDTO>>(customQuestions);
        }

        // POST: api/parts/{partId}/customquestions
        [HttpPost("{partId}/customquestions")]
        public async Task<ActionResult<CustomQuestionDTO>> PostCustomQuestion(int partId, CustomQuestionDTO customQuestionDTO)
        {
            if (!PartExists(partId))
            {
                return NotFound();
            }

            var customQuestion = _mapper.Map<CustomQuestion>(customQuestionDTO);
            customQuestion.PartId = partId;

            _context.CustomQuestions.Add(customQuestion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomQuestions", new { partId = partId }, _mapper.Map<CustomQuestionDTO>(customQuestion));
        }

        // PUT: api/parts/{partId}/customquestions/{questionId}
        [HttpPut("{partId}/customquestions/{questionId}")]
        public async Task<IActionResult> PutCustomQuestion(int partId, int questionId, CustomQuestionDTO customQuestionDTO)
        {
            if (!PartExists(partId) || !CustomQuestionExists(questionId))
            {
                return NotFound();
            }

            var customQuestion = await _context.CustomQuestions.FindAsync(questionId);
            if (customQuestion == null || customQuestion.PartId != partId)
            {
                return BadRequest();
            }

            _mapper.Map(customQuestionDTO, customQuestion);
            _context.Entry(customQuestion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // DELETE: api/parts/{partId}/customquestions/{questionId}
        [HttpDelete("{partId}/customquestions/{questionId}")]
        public async Task<IActionResult> DeleteCustomQuestion(int partId, int questionId)
        {
            var customQuestion = await _context.CustomQuestions.FindAsync(questionId);
            if (customQuestion == null || customQuestion.PartId != partId)
            {
                return NotFound();
            }

            _context.CustomQuestions.Remove(customQuestion);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        //Validating Existience
        private bool CustomQuestionExists(int id)
        {
            return _context.CustomQuestions.Any(e => e.Id == id);
        }

        private bool PartExists(int id)
        {
            return _context.Parts.Any(e => e.Id == id);
        }
    }


}

