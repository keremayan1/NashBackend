using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.ReCaptcha.GoogleReCaptcha
{
    public class GoogleReChaptcaValidator : IRecaptchaValidator
    {
        private const string GoogleRecaptchaAddress = "https://www.google.com/recaptcha/api/siteverify";
        public readonly IConfiguration Configuration;

        public GoogleReChaptcaValidator(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public bool IsRecaptchaValid(string token)
        {
            var client = new HttpClient();
            var response = client.GetStringAsync($@"{GoogleRecaptchaAddress}?secret={Configuration["Google:RecaptchaV3SecretKey"]}&response={token}").Result;
            var recaptchaResponse = JsonConvert.DeserializeObject<RecaptchaResponse>(response);

            if (!recaptchaResponse.Success || recaptchaResponse.Score < Convert.ToDecimal(Configuration["Google:RecaptchaMinScore"]))
            {
                return false;
            }
            return true;

        }
    }
}
