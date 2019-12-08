using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PapildomaUzduotis.Entities;

namespace PapildomaUzduotis.Pages.CompaniesInfo
{
    public class ListModel : PageModel
    {
        private CompaniesInfoContext _providerCompanies;
        private readonly ILogger<ListModel> _logging;
        [BindProperty(SupportsGet =true)]
        public string SearchedTerm { get; set; }
        public IEnumerable<Companies> SearchedCompanies { get; set; }
        public ListModel(CompaniesInfoContext providerCompanies, ILogger<ListModel> logging)
        {
            _logging = logging;
            _providerCompanies = providerCompanies;
        }


        public void OnGet(string SearchedTerm)
        {
           if (string.IsNullOrWhiteSpace(SearchedTerm))
           {
                SearchedCompanies = Enumerable.Empty<Companies>();  
           }
           else
           {
                SearchedCompanies = _providerCompanies.Companies.Where(c => c.Id == SearchedTerm).ToList();
           }
        }
    }
}