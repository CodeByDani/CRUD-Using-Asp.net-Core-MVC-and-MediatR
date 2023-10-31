using CRUD.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CRUD.Application.Person
{
    public class Add
    {
        public class Command : IRequest<Unit>
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public DateTime DateOFBirth { get; set; }
            public string PhoneNumber { get; set; }
        }

        public class Handler : IRequestHandler<Command, Unit>
        {
            private readonly DBContext dBContext;

            public Handler(DBContext db)
            {
                dBContext = db;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
              var person = await dBContext.Persons.AddAsync(new Models.Domain.Person()
                {
                    Id = Guid.NewGuid(),
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    DateOFBirth = request.DateOFBirth,
                });
                await dBContext.SaveChangesAsync();
                return new Unit();
            }
        }
       
    }
}
