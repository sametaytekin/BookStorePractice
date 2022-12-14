using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FluentValidation;
using WebApi.DBOperations;
using WebApi.GenreOperations.GetGenres;
using WebApi.GenreOperations.GetGenreDetail;
using WebApi.GenreOperations.CreateGenre;
using WebApi.GenreOperations.UpdateGenre;
using WebApi.GenreOperations.DeleteGenre;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class GenreController:ControllerBase
    {
        private readonly IBookStoreDbContext _context;
        public readonly IMapper _mapper;

        public GenreController(IMapper mapper, IBookStoreDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]

        public IActionResult GetGenres()
        {
            GetGenresQuery query = new GetGenresQuery(_context,_mapper);
            var obj= query.Handle();

            return Ok(obj) ;
        }

        [HttpGet("{id}")]
        public IActionResult GetGenreDetail(int id)
        {
            GetGenreDetailQuery query = new GetGenreDetailQuery(_context,_mapper);
            query.GenreId=id;
            GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var obj = query.Handle();

            return Ok(obj);
        }

        [HttpPost]
        public IActionResult CreateGenre([FromBody] CreateGenreModel newGenre){
            
            CreateGenreCommand command = new CreateGenreCommand(_context);
            command.Model=newGenre;
            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGenre(int id,[FromBody] UpdateGenreModel updateGenre)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.GenreId=id;
            command.Model=updateGenre;

            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id)
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            command.GenreId = id;

            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }



    }
}