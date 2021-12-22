using System.Collections.Generic;
using Enalyzer.ATM.Domain.Cash;

namespace Enalyzer.ATM.Core.Interfaces.Repositories
{
    public interface ICashRepository
    {
        IEnumerable<Cash> GetAllCashTypes();
    }
}