using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace KaspiTestApp
{
    public class Payment
    {
        [JsonIgnore]
        public int Id { get; set; }
        [RegularExpression(@"\d{10}", ErrorMessage = "Номер счета должен состоять из цифр и 10 знаков. Шот нөмірі сандар мен 10 таңбадан тұруы керек")]
        public string Account { get; set; } = string.Empty;
        public long Amount { get; set; }
        [JsonIgnore]
        public DateTime Date { get; set; }
        [JsonIgnore]
        public string Provider { get; set; } = string.Empty;
        public Payment()
        {
            this.Date = DateTime.Now;
        }
    }
    
}
