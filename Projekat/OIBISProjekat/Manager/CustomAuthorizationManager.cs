using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public class CustomAuthorizationManager : ServiceAuthorizationManager
    {
        // provjera da li za svakog korisnika postoji permisija read jer to svi imaju
        // autetifikacija failed ne postoji jer je dozvoljen korisnik bez permisija
        protected override bool CheckAccessCore(OperationContext operationContext)
        {
            CustomPrincipal principal = operationContext.ServiceSecurityContext.
                AuthorizationContext.Properties["Principal"] as CustomPrincipal;

            bool retValue = principal.IsInRole("Read");

            if (!retValue)
            {
                try
                {
                    Audit.AuthorizationFailed(Formater.ParseName(principal.Identity.Name),
                        OperationContext.Current.IncomingMessageHeaders.Action, "Need Read permission.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return retValue;
        }
    }
}
