using System;
using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.Books
{
	public class Create
	{
		public class Command : IRequest<Result<Unit>>
		{
			public Book? Book { get; set; }
		}

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly AppDbContext dbContext;

            public Handler(AppDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                if(request.Book == null)
                {
                    //TODO: Handle null
                    //return null;
                }

                dbContext.Books.Add(request.Book);

                var result = await dbContext.SaveChangesAsync() > 0;
                if(!result)
                {
                    return Result<Unit>.Failure("Couldn't add book");
                }

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}

