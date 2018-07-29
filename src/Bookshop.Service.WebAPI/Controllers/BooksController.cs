using System.Collections.Generic;
using AutoMapper;
using Bookshop.Domain.Entities;
using Bookshop.Domain.Interfaces.Services;
using Bookshop.Service.WebAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bookshop.Service.WebAPI.Controllers
{

    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly IBookService _service;
        private readonly IMapper _mapper;

        public BooksController(IBookService bookService, IMapper mapper)
        {
            _service = bookService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var books = _service.GetAll();
            return Ok(_mapper.Map<IEnumerable<BookViewModel>>(books));
        }

        [HttpGet("{isbn}")]
        public IActionResult Get(string isbn)
        {
            var bookISBN = new BookViewModel() { ISBN = isbn };
            var bookFull = _service.GetByParams(_mapper.Map<Book>(bookISBN));
            return Ok(_mapper.Map<BookViewModel>(bookFull));
        }

        [HttpPost]
        public IActionResult Post([FromBody] BookViewModel bookViewModel)
        {
            var book = _mapper.Map<Book>(bookViewModel);

            if (book.Invalid)
                return BadRequest(new { Messages = book.Notifications });

            _service.Add(book);
            return Ok(bookViewModel);
        }

        [HttpPut]
        public IActionResult Update([FromBody] BookViewModel bookViewModel)
        {
            var book = _mapper.Map<Book>(bookViewModel);

            if (book.Invalid)
                return BadRequest(new { Messages = book.Notifications });

            _service.Update(book);
            return Ok(bookViewModel);
        }

        [HttpDelete("{isbn}")]
        public IActionResult Delete(string ISBN)
        {
            var bookViewModel = new BookViewModel();
            bookViewModel.ISBN = ISBN;

            _service.Remove(_mapper.Map<Book>(bookViewModel));
            return Ok();
        }
    }
}