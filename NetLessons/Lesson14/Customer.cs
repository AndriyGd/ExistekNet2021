using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson14
{
    public class Customer
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        [JsonIgnore] public bool IsSelected { get; set; }
    }
}
