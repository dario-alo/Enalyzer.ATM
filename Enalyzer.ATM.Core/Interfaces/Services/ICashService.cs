using System.Collections.Generic;
using Enalyzer.ATM.Domain.Cash;

namespace Enalyzer.ATM.Core.Interfaces.Services
{
    public interface ICashService
    {
        IEnumerable<Cash> GetCash(int amount);
    }
}