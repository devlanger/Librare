using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Books;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BooksController : BaseApiController
    {
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return HandleResult(await Mediator.Send(new List.Query{ }));
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Book = book }));
        }
    }
}

