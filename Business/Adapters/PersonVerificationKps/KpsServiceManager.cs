using Entities;
using KpsNationalIdVerification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Adapters.PersonVerificationKps
{
    public class KpsServiceManager : IKpsService
    {
        public async Task<bool> Verify(Person person)
        {
            return await VerifyId(person);
        }
        public async Task<bool> VerifyId(Person person)
        {
            var kps = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
            var kpsVerification = await kps.TCKimlikNoDogrulaAsync(Convert.ToInt64(person.NationalId), person.Name.ToUpper(), person.LastName.ToUpper(), person.DateOfBirth.Year);
            return kpsVerification.Body.TCKimlikNoDogrulaResult;
        }
    }
}
