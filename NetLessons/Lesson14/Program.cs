using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Lesson14
{
    class Program
    {

        /*
         "{\"status\":\"success\",\"customerData\":{\"40215502\":{\"id\":\"40215502\",\"name\":\"\\u0422\\u043e\\u043f-\\u0410\\u0440\\u0442\",\"description\":\"\\u041c\\u0438\\u0445\\u0430\\u0438\\u043b|21.05.2021  09:08|\\u041a\\u0418\\u0407\\u0412|\\u0428\\u041f\\u041e\\u041d\\/\\u041a\\u041e\\u0420\\u0406\\u041d\\u041d\\u042f|\\u0420\\u0410\\u0411\\u041e\\u0422\\u0410\\u0415\\u041c|\\u0427\\u041f \\u0425\\u0425\",\"email\":\"\",\"assignedToEmployee\":{\"id\":\"164584\",\"email\":\"viktor@baykal.com.ua\",\"internalNumber\":\"902\",\"name\":\"\\u0412\\u0418\\u041a\\u0422\\u041e\\u0420\"},\"numbers\":[\"0674094005\"],\"labels\":[]}}}"
         */
        static void Main(string[] args)
        {
            var customer = new Customer
            {
                Name = "Tom",
                Id = 23566,
                Description = "Good customer",
                Email = "tom.f@gmail.com"
            };

            var str = JsonConvert.SerializeObject(customer);
            Console.WriteLine(str);

            var nC = "{ \"Id\": \"40215502\", \"name\": \"Viktor\" }";

            var c1 = JsonConvert.DeserializeObject<Customer>(nC);

            var response = "{\"status\":\"success\",\"customerData\":{\"40215502\":{\"id\":\"40215502\",\"name\":\"\\u0422\\u043e\\u043f-\\u0410\\u0440\\u0442\",\"description\":\"\\u041c\\u0438\\u0445\\u0430\\u0438\\u043b|21.05.2021  09:08|\\u041a\\u0418\\u0407\\u0412|\\u0428\\u041f\\u041e\\u041d\\/\\u041a\\u041e\\u0420\\u0406\\u041d\\u041d\\u042f|\\u0420\\u0410\\u0411\\u041e\\u0422\\u0410\\u0415\\u041c|\\u0427\\u041f \\u0425\\u0425\",\"email\":\"\",\"assignedToEmployee\":{\"id\":\"164584\",\"email\":\"viktor@baykal.com.ua\",\"internalNumber\":\"902\",\"name\":\"\\u0412\\u0418\\u041a\\u0422\\u041e\\u0420\"},\"numbers\":[\"0674094005\"],\"labels\":[]}}}";

            var p = ParseSearch(response);

            Console.WriteLine($"\n{p.Name}");

            Console.ReadKey();
        }


        private static ResponseSearchCustomer ParseSearch(string response)
        {
            JObject obj = null;

            try
            {
                obj = JsonConvert.DeserializeObject<JObject>(response);
            }
            catch (Exception e)
            {
                return null;
            }

            var childrens = obj.Children().ToList();

            var searchStr = "{" + $"{childrens[0]}" + "}";
            ResponseBase responseBase = null;
            ResponseSearchCustomer responseSearchCustomer = null;
            try
            {
                responseBase = JsonConvert.DeserializeObject<ResponseBase>(searchStr);
            }
            catch (Exception)
            {
                //ignore
            }

            if (responseBase != null)
            {
                if (responseBase.Status == "success")
                {
                    var customerDetailStr = childrens[1].ToString();
                    if (customerDetailStr.Contains("id"))
                    {
                        var childrens2 = childrens[1].Children().ToList();
                        var detailChildrens = childrens2[0].Children().ToList();

                        var customerToken = detailChildrens[0].Children().ToList();
                        responseSearchCustomer = JsonConvert.DeserializeObject<ResponseSearchCustomer>(customerToken[0].ToString());
                        responseSearchCustomer.Status = responseBase.Status;
                    }
                }
            }

            return responseSearchCustomer;
        }
    }

    public class ResponseBase
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }

        public string Request { get; set; }
        public string RequestUrl { get; set; }
    }
    public class ResponseSearchCustomer : ResponseBase
    {
        [JsonProperty("id")]
        public string CustomerId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("numbers")]
        public string[] Numbers { get; set; }
        [JsonIgnore]
        public bool Searched { get; set; }
        [JsonIgnore]
        public string Subject { get; set; }
        [JsonIgnore]
        public string ResponseString { get; set; }

        public override string ToString()
        {
            return $"CustomerIdAtBinotel: {CustomerId}|CompanyName: {Name}|Description: {Description}|Numbers: {string.Join(",", Numbers)}";
        }
    }

}
