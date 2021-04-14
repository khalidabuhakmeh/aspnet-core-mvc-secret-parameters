using System.ComponentModel;

namespace Secrets.Models
{
    public class IndexModel
    {
        [DisplayName("Number: ")]
        public int Number { get; set; }
        [DisplayName("Name :")]
        public string Name { get; set; }
    }
}