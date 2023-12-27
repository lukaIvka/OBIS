using System;
using System.Collections.Generic;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public class CustomAuthorizationPolicy : IAuthorizationPolicy
    {
        public CustomAuthorizationPolicy()
        {
            Id = Guid.NewGuid().ToString();
        }

        // apstraktna klasa
        public ClaimSet Issuer
        {
            get { return ClaimSet.System; }
        }
        public string Id
        {
            get;
        }

        public bool Evaluate(EvaluationContext evaluationContext, ref object state)
        {
            // prva provjera liste vec postojecih indetiteta
            // rijecnik Propreties se pretrazuje po kljucu , sa ciljem postvljanja naseg principala i ubacuje u object list ako postoji
            if (!evaluationContext.Properties.TryGetValue("Identities", out object list))
            {
                return false;
            }
            // castovanje za dobijanje idnetiteta i provjera liste
            IList<IIdentity> identities = list as IList<IIdentity>;
            if (list == null || identities.Count <= 0)
            {
                return false;
            }
            // postoje indentity (korisnici) i uzima prvi iz liste...
            WindowsIdentity windowsIdentity = identities[0] as WindowsIdentity;

            // i potvrdjuje se autentifikacija
            try
            {
                Audit.AuthenticationSuccess(Formater.ParseName(windowsIdentity.Name));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            // i postavljamo nas custom principal sa nasim indetitetom
            // jer custom principal metoda zahtjeva neki indentiti da se uzme
            evaluationContext.Properties["Principal"] =
                new CustomPrincipal((WindowsIdentity)identities[0]);
            return true;
        }
    }
}
