using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CSVReaderAPI.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSVReaderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileReaderController : ControllerBase
    {
        private readonly ICSVReaderRepository _repo;
        public FileReaderController(ICSVReaderRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile([FromForm]IFormFile file)
        {
            if(file == null){
                return BadRequest("File cannot be null");
            }
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                string[] headers = null;
                while (reader.Peek() >= 0)
                {
                    string row = Regex.Replace(reader.ReadLine(), "\"", string.Empty);
                    if (headers == null)
                    {
                        headers = row.Split(",");
                    }
                    else
                    {
                        row = row.Replace(", ", "; "); // To deal with values that have a comma inside them, to satisfy the no csv library constraint
                        string[] rowValues = row.Split(',');
                        Contact contact = new Contact();
                        for (int i = 0; i < headers.Length; i++)
                        {
                            contact.GetType().GetProperty(headers[i]).SetValue(contact, rowValues[i].Replace("; ", ", "), null);
                        }
                        _repo.Add(contact);
                    }
                }
            }
            if (await _repo.SaveAll())
            {
                return Ok();
            }

            throw new Exception("Creating the message failed on save.");
        }
    }
}