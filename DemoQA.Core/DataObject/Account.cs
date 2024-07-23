using Newtonsoft.Json;


namespace DemoQA.Core.DataObject
{
    public class Account
    {
        [JsonProperty("userid")]
        public string userid { get; set; }


        [JsonProperty("username")]
        public string username { get; set; }


        [JsonProperty("password")]
        public string password { get; set; }
        
        
        [JsonProperty("token")]
        public string token { get; set; }
    }
}
