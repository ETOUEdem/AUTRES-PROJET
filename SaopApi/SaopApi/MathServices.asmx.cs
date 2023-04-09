using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SaopApi
{
    /// <summary>
    /// Description résumée de MathServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    // [System.Web.Script.Services.ScriptService]
    public class MathServices : System.Web.Services.WebService
    {

        [WebMethod]
        public int Add(int a, int b)
        {
            return (a + b);
        }
        [WebMethod]
        public System.Single Subtract(System.Single A, System.Single B)
        {
            return (A - B);
        }
        [WebMethod]
        public System.Single Multiply(System.Single A, System.Single B)
        {
            return A * B;
        }
        [WebMethod]
        public System.Single Divide(System.Single A, System.Single B)
        {
            if (B == 0) return -1;
            return Convert.ToSingle(A / B);
        }
    }
}
