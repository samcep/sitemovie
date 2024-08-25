using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using sitemovie.ApplicationContexts;

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
        
         


     

    }
}

