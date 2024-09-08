using AutoMapper;
using Azure;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sitemovie.ApplicationContexts;
using sitemovie.DTO;
using sitemovie.Entities;
using sitemovie.Helpers;

namespace sitemovie.Controllers
{
    [ApiController]
    [Route("api/autors")]
    public class ActorController : ControllerBase
    {
        private readonly SqlServerDbContext _dbContext;
        private readonly IMapper _iMappper;
        public ActorController(SqlServerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _iMappper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<List<ActorDto>>> Get([FromQuery] PaginationDto paginationDto)
        {
            var queryable = _dbContext.Actors.AsQueryable();
            await HttpContext.InsertParamsPagination(queryable, paginationDto.RowsPerPage);
            var actors = await queryable.Paginate(paginationDto).ToListAsync();
            return _iMappper.Map<List<ActorDto>>(actors);
        }


        [HttpGet("{id:int}" , Name = "getActorById")]
        public async Task<ActionResult<ActorDto>> Get(int id)
        {
            var actor = await _dbContext.Actors.FirstOrDefaultAsync(g => g.Id == id);
            if (actor is null)
            {
                return NotFound();
            }
            var actorsDto = _iMappper.Map<ActorDto>(actor);
            return actorsDto;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromForm] ActorCreateDto actorCreateDto)
        {
            var entity = _iMappper.Map<Actor>(actorCreateDto);
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();

            var actorDto = _iMappper.Map<ActorDto>(entity);

            return new CreatedAtRouteResult("getActorById", new { id = actorDto.Id }, actorDto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, [FromBody] ActorCreateDto actorCreateDto)
        {
            var entity = _iMappper.Map<Actor>(actorCreateDto);
            entity.Id = id;
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exists = await _dbContext.Actors.AnyAsync(g => g.Id == id);
            if (!exists)
            {
                return NotFound();
            }
            _dbContext.Remove(new Actor() { Id = id });
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }


        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ActorPatchDto> patchDocument)
        {
            if(patchDocument == null)
            {
                return BadRequest();
            }

            var entityDb = await _dbContext.Actors.FirstOrDefaultAsync(a => a.Id == id);
            if (entityDb == null)
            {
                return NotFound();
            }

            var entityDto = _iMappper.Map<ActorPatchDto>(entityDb);

            patchDocument.ApplyTo(entityDto , ModelState);

            var isValid = TryValidateModel(entityDto);

            if(!isValid)
            {
                return BadRequest(ModelState);
            }

            _iMappper.Map(entityDto, entityDb);

            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

    }
}

