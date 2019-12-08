
using Newtonsoft.Json;

namespace PapildomaUzduotis.Models
{
    public class Company
    {
        [JsonProperty("lookupId")]
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        [JsonProperty("month")]
        public string MonthSalary { get; set; }
        [JsonProperty("avgWage")]
        public string AvgMonthSalary { get; set; }
        [JsonProperty("numInsured")]
        public string InsuredPeople { get; set; }
        [JsonProperty("tax")]
        public string Taxes { get; set; }

        public override string ToString() => JsonConvert.SerializeObject(this);

    }
}
