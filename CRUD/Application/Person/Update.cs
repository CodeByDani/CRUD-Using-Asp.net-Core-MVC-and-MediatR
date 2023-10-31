using CRUD.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Application.Person
{
    public class Update
    {
        public class Command : IRequest<Unit>
        {
            public Guid Id { get; set; }
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
                var person = await dBContext.Persons.FindAsync(request.Id);

                if (person != null)
                {

                    person.Id = request.Id;
                    person.FirstName = request.FirstName;
                    person.LastName = request.LastName;
                    person.Email = request.Email;
                    person.PhoneNumber = request.PhoneNumber;
                    person.DateOFBirth = request.DateOFBirth;

                    await dBContext.SaveChangesAsync();
                }
                return new Unit();
            }
        }
    }
}
