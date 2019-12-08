using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PapildomaUzduotis.Entities
{
    public class Companies
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string MonthSalary { get; set; }
        public string AvgMonthSalary { get; set; }
        public string InsuredPeople { get; set; }
        public string Taxes { get; set; }
    }
}
