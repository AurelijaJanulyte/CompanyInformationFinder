using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PapildomaUzduotis.Entities;
using PapildomaUzduotis.Models;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapildomaUzduotis.Controllers
{
    public class FileUploadController : Controller
    {
        private CompaniesInfoContext _context { get; set; }



        public FileUploadController(CompaniesInfoContext context)
        {
            _context = context;
        }

        [HttpPost("FileUpload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            var fileContents = new StreamReader(file.OpenReadStream()).ReadToEnd();
            var parsedContents = JsonConvert.DeserializeObject<List<Company>>(fileContents);

            _context.Companies.AddRange(parsedContents.Select(c =>
                new Companies
                {
                    AvgMonthSalary = c.AvgMonthSalary,
                    Code = c.Code,
                    InsuredPeople = c.InsuredPeople,
                    MonthSalary = c.MonthSalary,
                    Name = c.Name,
                    Taxes = c.Taxes,
                    Id = c.Id
                }));

            await _context.SaveChangesAsync();

            return Redirect("/");
        }
        [HttpGet("export/{id}")]
        public FileResult ExportData(string id) 
        {
            var exportedCompany=_context.Companies.Where(c => c.Id == id);
            string csvString = CsvSerializer.SerializeToCsv(exportedCompany);

            return File(new UTF8Encoding().GetBytes(csvString), "text/csv", "export.csv");
        }

    }
}

