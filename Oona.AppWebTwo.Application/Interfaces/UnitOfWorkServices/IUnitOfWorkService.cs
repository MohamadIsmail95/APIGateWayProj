using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oona.AppWebTwo.Application.Interfaces.UnitOfWorkServices
{
    public interface IUnitOfWorkService
    {
        ICountryServices.ICountryServices CountryServices { get; }
    }
}
