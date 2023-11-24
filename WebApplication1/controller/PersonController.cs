using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using WebApplication1.model;
using WebApplication1.repository.implementation;

namespace WebApplication1.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public PersonRepositoryImpl personRepositoryImpl { get; set; }

        public string Index() => "Hello world";

        [HttpGet("{id}")]
        public IActionResult GetPerson(int id)
        {
            var person = personRepositoryImpl.FindById(id);
            return person == null? NotFound() : Ok(person);
        }

        [HttpPost] //?
        public IActionResult CreatePerson([FromForm] Person input_person)
        {
            if (!IsValidPhoneNumber(input_person.PhoneNumber)) return BadRequest("Invalid phone number!");

            var savedPerson = personRepositoryImpl.Save(input_person);
            return Ok(savedPerson);
        }

        [HttpPut]
        public IActionResult UpdatePerson(int id, [FromBody] Person input_person)
        {
            if (!IsValidPhoneNumber(input_person.PhoneNumber)) return BadRequest("Invalid phone number!");
            
            var updatedPerson = personRepositoryImpl.Update(id, input_person);
            return Ok(updatedPerson);

        }

        [HttpDelete("{id}")]
        public IActionResult DeletePerson(int id) { 
            var deletedPerson = personRepositoryImpl.DeleteById(id);
            return Ok(deletedPerson);
        }

        [NonAction]
        public DateTime GetBirthDate(string date) { return DateTime.ParseExact(date, "yyyy.MM.dd", null); }

        [NonAction]
        static bool IsValidPhoneNumber(string phoneNumber)
        {
            string pattern = @"^(?:\+7|8)[0-9]{10}$";
            return Regex.IsMatch(phoneNumber, pattern);
        }
    }
}
