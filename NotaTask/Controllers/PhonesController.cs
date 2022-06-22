using Microsoft.AspNetCore.Mvc;
using NotaTask.Helpers;
using NotaTask.Models;
using System.Collections.Generic;
using System.Linq;

namespace NotaTask.Controllers
{
    [Route("api/phonesController")]
    [ApiController]
    #region Convention
      [ApiConventionType(typeof(DefaultApiConventions))]
    #endregion

    public class PhonesController : Controller
    {
        UserContext db;
        public PhonesController(UserContext usercontext)
        {
            db = usercontext;
        }
        [HttpGet("GetallPersonsPhone")]
        public List<PersonPhone> GetallPersonsPhone()
        {
           var personsphone= db.PersonPhones.ToList();
            if (personsphone == null)
                return null;
            return personsphone;
        }

        // Search
        
        [HttpGet("GetById")]
        public ActionResult<PersonPhone> GetById(int id)
        {
            try
            {

                var personphone = db.PersonPhones.FirstOrDefault(s => s.Id == id);
                if (personphone == null)
                    return NotFound();

                return personphone;
            }catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }

        }

        // Add Person Phone Data
        [HttpPut("Add")]
        public IActionResult Add([FromBody] PersonPhone value)
        {
            try
            {
                var personphone = new PersonPhone();
                personphone.Name = value.Name;
                personphone.Phone = value.Phone;
                db.PersonPhones.Add(personphone);
                db.SaveChanges();
                return Ok(personphone);
            }
           catch(AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        // update personphone data
        [HttpPut("Update")]
        public void Update(int id, [FromBody] PersonPhone value)
        {
            try
            {
                var PersonPhone = db.PersonPhones.FirstOrDefault(s => s.Id == id);
                if (PersonPhone != null)
                {
                    db.Entry<PersonPhone>(PersonPhone).CurrentValues.SetValues(value);
                    db.SaveChanges();
                }
            } catch (AppException ex)
            {
            }
        }
        // DELETE api/<PhonesController>/5
        [HttpDelete("{id}")]
        public void  Delete(int id)
        {
            try
            {
                var PersonPhone = db.PersonPhones.FirstOrDefault(s => s.Id == id);
                if (PersonPhone != null)
                {
                    db.PersonPhones.Remove(PersonPhone);
                    db.SaveChanges();
                }

            }catch(AppException ex)
            {
            }
        }
    }
}
