using System;
using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Books
{
	public class List
	{
		public class Query : IRequest<Result<List<Book>>>
		{
			
		}

        public class Handler : IRequestHandler<Query, Result<List<Book>>>
        {
            private readonly AppDbContext dbContext;

            public Handler(AppDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<Result<List<Book>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<List<Book>>.Success(await dbContext.Books.ToListAsync());
            }
        }
    }
}

