using CRUD.Application.Person;
using CRUD.Models;
using CRUD.Models.Domain;
using CRUD.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Controllers
{
    public class PersonController : Controller
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
          var persons = await _mediator.Send(new All.Query{ });
            return View(persons.People);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(PersonViewModel InsertPersonRequest)
        {

           await _mediator.Send(new Add.Command
            {
                FirstName = InsertPersonRequest.FirstName,
                LastName = InsertPersonRequest.LastName,
                Email = InsertPersonRequest.Email,
                PhoneNumber = InsertPersonRequest.PhoneNumber,
                DateOFBirth = InsertPersonRequest.DateOFBirth,
            });
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var person = await _mediator.Send(new View.Query { Id = id });
            if (person.person != null)
            {
                var updatedPerson = new UpdatePersonViewModel()
               {
                   Id = person.person.Id,
                   FirstName = person.person.FirstName,
                   LastName = person.person.LastName,
                   Email = person.person.Email,
                   PhoneNumber = person.person.PhoneNumber,
                   DateOFBirth = person.person.DateOFBirth,
               };
               return await Task.Run(()=>View("View",updatedPerson));

          }
           return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdatePersonViewModel model)
        {
            var person = await _mediator.Send(new Update.Command { 
            Id = model.Id,
            FirstName = model.FirstName,    
            LastName = model.LastName,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
            DateOFBirth=model.DateOFBirth,
            });
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdatePersonViewModel model)
        {
            var person = await _mediator.Send(new Delete.Query { Id = model.Id });
            return RedirectToAction("Index");
        }
    }
}
