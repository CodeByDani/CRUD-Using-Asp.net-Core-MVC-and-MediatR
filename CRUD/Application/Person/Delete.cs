using CRUD.Repository;
using MediatR;

namespace CRUD.Application.Person
{
    public class Delete
    {
        public class Query : IRequest<Unit>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Unit>
        {
            private readonly DBContext dbContext;

            public Handler(DBContext db)
            {
                dbContext = db;
            }

            public async Task<Unit> Handle(Query request, CancellationToken cancellationToken)
            {
                var person = await dbContext.Persons.FindAsync(request.Id);
                if (person != null)
                {
                    dbContext.Persons.Remove(person);
                    await dbContext.SaveChangesAsync();
                }
                return new Unit();
            }
        }
       
    }
}
