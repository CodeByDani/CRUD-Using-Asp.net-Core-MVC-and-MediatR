using CRUD.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Application.Person
{
    public class View
    {
        public class Query : IRequest<Response>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Response>
        {
            private readonly DBContext dbContext;

            public Handler(DBContext db)
            {
                dbContext = db;
            }

            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                var person = await dbContext.Persons.FirstOrDefaultAsync(x => x.Id == request.Id);
                return new Response
                {
                    person = person
                };
            }
        }

        public class Response
        {
            public Models.Domain.Person person { get; set; }
        }
    }
}
