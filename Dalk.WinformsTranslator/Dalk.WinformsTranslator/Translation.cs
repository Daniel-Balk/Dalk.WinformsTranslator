using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Dalk.WinformsTranslator
{
    public class Translation : Dictionary<string, string>
    {
        public static Dictionary<string,string> FromJson(string json)
        {
#pragma warning disable CS8603
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
#pragma warning restore CS8603
        }
        public static Dictionary<string,string> FromJson(byte[] jsonr)
        {
            var temp = Path.GetTempFileName();
            File.WriteAllBytes(temp, jsonr);
            var json = File.ReadAllText(temp);
            File.Delete(temp);
#pragma warning disable CS8603
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
#pragma warning restore CS8603
        }
    }
}