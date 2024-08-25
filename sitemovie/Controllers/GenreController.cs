using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sitemovie.ApplicationContexts;
using sitemovie.DTO;
using sitemovie.Entities;

namespace sitemovie.Controllers
{
    [ApiController]
    [Route("api/genres")]
    public class GenreController  : ControllerBase
    {


        private readonly SqlServerDbContext _dbContext;
        private readonly IMapper _iMappper;

        public GenreController(SqlServerDbContext dbContext , IMapper mapper)
        {
            _dbContext = dbContext;
            _iMappper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<List<GenreDto>>> Get()
        {
            var Genres = await _dbContext.Genres.ToListAsync();
            var GenresDto = _iMappper.Map<List<GenreDto>>(Genres);
            return GenresDto;
        }

        [HttpGet("{id:int}" , Name = "GetById")]
        public async Task<ActionResult<GenreDto>> GetById( int id)
        {
            var Genre = await _dbContext.Genres.FirstOrDefaultAsync(g => g.Id == id);
            if(Genre is null)
            {
                return NotFound();
            }
            var GenreDto = _iMappper.Map<GenreDto>(Genre);
            return GenreDto;
        }


        [HttpPost]
        public async Task<ActionResult> Create([FromBody] GenreCreateDto genreCreateDto)
        {
            var entity = _iMappper.Map<Genre>(genreCreateDto);
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();

            var genreDto = _iMappper.Map<GenreDto>(entity);

            return new CreatedAtRouteResult("GetById" , new { id = genreDto.Id} , genreDto);
        }



        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, [FromBody] GenreCreateDto genreCreateDto)
        {
            var entity = _iMappper.Map<Genre>(genreCreateDto);
            entity.Id = id;
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exists = await _dbContext.Genres.AnyAsync(g => g.Id == id);
            if(!exists)
            {
                return NotFound();
            }
            _dbContext.Remove(new Genre() { Id = id });
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
