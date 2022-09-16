using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApi.DBOperations;
using WebApi.TokenOperations.Models;
using WebApi.UserOperations.CreateToken;
using WebApi.UserOperations.CreateUser;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class UserController:ControllerBase
    {
        private readonly IBookStoreDbContext _context;

        private readonly IMapper _mapper;

        readonly IConfiguration _configuration;

        public UserController(IBookStoreDbContext context,IMapper mapper,IConfiguration configuration)
        {
            _context=context;
            _configuration=configuration;
            _mapper=mapper;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateUserModel model)
        {
            CreateUserCommand command =new CreateUserCommand(_context,_mapper);
            command.Model=model;

            command.Handle();

            return Ok();

        }

        [HttpPost("connect/token")]
        public ActionResult<Token> CreateToken([FromBody] CreateTokenModel login )
        {
            CreateTokenCommand command = new CreateTokenCommand(_context,_mapper,_configuration);
            command.Model=login;
            var token=command.Handle();
            return token;
        }


    }
}