using System.Collections.Generic;
using System.Linq;
using Enalyzer.ATM.Core.Interfaces.Repositories;
using Enalyzer.ATM.Core.Interfaces.Services;
using Enalyzer.ATM.Core.Services;
using Enalyzer.ATM.Domain.Cash;
using Enalyzer.ATM.Test.Fixtures;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Enalyzer.ATM.Test
{
    public class CashServiceShould
    {
        private readonly ICashService _cashService;
        private readonly Mock<ICashRepository> _cashRepository;
        private readonly Mock<ILogger<CashService>> _loggerMock;

        public CashServiceShould()
        {
            _cashRepository = new Mock<ICashRepository>();

            _cashRepository.Setup(p => p.GetAllCashTypes()).Returns(InMemoryContextFixture.CashTypes);

            _loggerMock = new Mock<ILogger<CashService>>();

            _cashService = new CashService(_cashRepository.Object, _loggerMock.Object);
        }

        [Fact]
        public void ReturnCash_ZeroValue()
        {
            IEnumerable<Cash> result = _cashService.GetCash(0);

            Assert.Empty(result);
        }

        [Fact]
        public void ReturnCash_LessThanZero()
        {
            IEnumerable<Cash> result = _cashService.GetCash(-50);

            Assert.Empty(result);
        }

        [Fact]
        public void ReturnCash_AssignmentAmount()
        {
            int value = 578;

            IEnumerable<Cash> result = _cashService.GetCash(value);

            Assert.Equal(6, result.Count());
            Assert.Equal(value, result.Sum(x => x.Value));
        }

        [Fact]
        public void ReturnCash_AllCashTypes()
        {
            int value = 1888;

            IEnumerable<Cash> result = _cashService.GetCash(value);

            Assert.Equal(10, result.Count());
            Assert.Equal(value, result.Sum(x => x.Value));
        }

        [Fact]
        public void ReturnCash_BigAmount()
        {
            int value = int.MaxValue;

            IEnumerable<Cash> result = _cashService.GetCash(value);

            Assert.Equal(value, result.Sum(x => x.Value));
        }
    }
}