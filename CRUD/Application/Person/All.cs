using CRUD.Models.Domain;
using CRUD.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;

namespace CRUD.Application.Person
{
    public class All
    {
        public class Query : IRequest<Response>
        {
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
                var pers = await dbContext.Persons.ToListAsync();
                return new Response
                {
                    People = pers
                };
            }
        }

        public class Response
        {
            public List<Models.Domain.Person> People { get; set; }
        }
    }
}
