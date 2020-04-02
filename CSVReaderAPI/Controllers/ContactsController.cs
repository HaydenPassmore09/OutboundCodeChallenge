using System;
using System.Threading.Tasks;
using CSVReaderAPI.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace CSVReaderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ICSVReaderRepository _repo;

        public ContactsController(ICSVReaderRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            var contacts = _repo.GetContacts();

            return Ok(contacts);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteContacts()
        {
            if (await _repo.DeleteAll())
            {
                if (await _repo.SaveAll())
                {
                    return Ok();
                }
            }else{
                return Ok("Nothing to delete");
            }
            throw new Exception("Failed to delete the records");
        }
    }
}