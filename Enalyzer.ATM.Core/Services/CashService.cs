using System;
using System.Collections.Generic;
using System.Linq;
using Enalyzer.ATM.Core.Interfaces.Repositories;
using Enalyzer.ATM.Core.Interfaces.Services;
using Enalyzer.ATM.Domain.Cash;
using Microsoft.Extensions.Logging;

namespace Enalyzer.ATM.Core.Services
{
    public class CashService : ICashService
    {
        private readonly ICashRepository _cashRepository;
        private readonly ILogger<CashService> _logger;

        public CashService(ICashRepository cashRepository, ILogger<CashService> logger)
        {
            _cashRepository = cashRepository ?? throw new ArgumentNullException(nameof(cashRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        #region Public Methods

        public IEnumerable<Cash> GetCash(int amount)
        {
            try
            {
                _logger.LogInformation($"CashService - GetCash: Requested {amount}");

                var cashTypes = _cashRepository.GetAllCashTypes().OrderByDescending(x => x.Value);

                if (cashTypes != null && cashTypes.Any(x => x.Value > 0))
                {
                    return GetGreedyCash(cashTypes, amount);
                }
                else
                {
                    _logger.LogWarning("CashService - GetCash: No cash available");
                    return new List<Cash>();
                }
            }
            catch (Exception e)
            {
                _logger.LogWarning($"CashService - GetCash: Exception {e.Message}");
                return new List<Cash>();
            }
        }

        #endregion Public Methods

        #region Private Methods

        private IEnumerable<Cash> GetGreedyCash(IEnumerable<Cash> cashTypes, int amount)
        {
            int i = 0;

            while (true)
            {
                if (amount < 1)
                    break;

                var max = cashTypes.ElementAt(i);

                if (amount >= max.Value)
                {
                    amount -= max.Value;
                    yield return max;
                }
                else
                {
                    i++;
                }
            }
        }

        #endregion Private Methods
    }
}