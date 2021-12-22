using System.Collections.Generic;
using Enalyzer.ATM.Core.Interfaces.Repositories;
using Enalyzer.ATM.Domain.Cash;

namespace Enalyzer.ATM.Infrastructure.Repositories
{
    public class CashRepository : ICashRepository
    {
        private readonly IEnumerable<Cash> CashTypes;

        #region Constructor

        public CashRepository()
        {
            CashTypes = new List<Cash>()
            {
                new Note { Value = 1000 },
                new Note { Value = 500 },
                new Note { Value = 200 },
                new Note { Value = 100 },
                new Note { Value = 50 },
                new Coin { Value = 20, Diameter = 40 },
                new Coin { Value = 10, Diameter = 20 },
                new Coin { Value = 5, Diameter = 50 },
                new Coin { Value = 2, Diameter = 30 },
                new Coin { Value = 1, Diameter = 10 }
            };
        }

        #endregion Constructor

        #region Public Methods

        public IEnumerable<Cash> GetAllCashTypes()
        {
            return CashTypes;
        }

        #endregion Public Methods
    }
}