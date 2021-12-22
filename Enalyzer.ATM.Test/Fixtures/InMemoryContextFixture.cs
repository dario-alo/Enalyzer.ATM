using System.Collections.Generic;
using Enalyzer.ATM.Domain.Cash;

namespace Enalyzer.ATM.Test.Fixtures
{
    public static class InMemoryContextFixture
    {
        public static IEnumerable<Cash> CashTypes = new List<Cash>()
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
}