using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLayerProject.API.Filters;
using NLayerProject.Core.Models;
using NLayerProject.Core.Services;

namespace NLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IService<Person> _personService;

        public PersonsController(IService<Person> personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var persons = await _personService.GetAllAsync();
            return Ok(persons);
        }

        [ServiceFilter(typeof(GenericNotFoundFilter<Person>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var person = await _personService.GetByIdAsync(id);
            return Ok(person);
        }

        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> SavePerson(Person person)
        {
            var newPerson = await _personService.AddAsync(person);
            return Created(String.Empty, newPerson);
        }

        //ValidatonFilter yazmıyorum çünkü startup tarafında bunu genel bir filter olarak ekledim.
        [HttpPut]
        public IActionResult UpdatePerson(Person person)
        {
            if (string.IsNullOrEmpty(person.Id.ToString()) || person.Id<=0)             //Best Practice açısından doğru değil normalde UpdatePerson diye bir Dto tanımlayıp onun Idsinin üzerine Required eklemem gerekmekte.
            {
                throw new Exception("Id alanı gereklidir.");
            }


            var updatedPerson = _personService.Update(person);

            return Accepted(person); //best practices açısından nocontent gönderilmesi gerekmektedir.
        }

    }
}
