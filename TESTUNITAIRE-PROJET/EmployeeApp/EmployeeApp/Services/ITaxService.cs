using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApp.Services
{
   public interface ITaxService
    {
        double GetTaxeRate();
    }

    public class TaxeService : ITaxService
    {
        const double _taxeRate = 0.15;
        public double GetTaxeRate()
        {
            return _taxeRate;
        }
    }
}
