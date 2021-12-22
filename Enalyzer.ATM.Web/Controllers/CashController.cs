using System;
using System.Collections.Generic;
using AutoMapper;
using Enalyzer.ATM.Common.Enums;
using Enalyzer.ATM.Common.ExtensionMethods;
using Enalyzer.ATM.Common.Settings;
using Enalyzer.ATM.Core.Interfaces.Services;
using Enalyzer.ATM.Domain.Cash;
using Enalyzer.ATM.Web.Models.Cash;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Enalyzer.ATM.Web.Controllers
{
    public class CashController : Controller
    {
        private readonly ICashService _cashService;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        private readonly ILogger<CashController> _logger;

        public CashController(ICashService cashService, IMapper mapper, IOptions<AppSettings> appSettings, ILogger<CashController> logger)
        {
            _cashService = cashService ?? throw new ArgumentNullException(nameof(cashService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _appSettings = appSettings?.Value ?? throw new ArgumentNullException(nameof(appSettings));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Withdraw(WithdrawViewModel withdrawModel)
        {
            var cashWithdraw = new List<CashViewModel>();

            try
            {
                _logger.LogInformation($"CashController - Withdraw called with: {withdrawModel.AsJsonString()}");

                IEnumerable<Cash> cashResult = _cashService.GetCash(withdrawModel.Amount);

                foreach (var item in cashResult)
                {
                    var cashModel = _mapper.Map<CashViewModel>(item);

                    if (item is Coin)
                        cashModel.BoxType = (item as Coin).Diameter > _appSettings.CoinDivider ? BoxType.BigCoins : BoxType.SmallCoints;

                    cashWithdraw.Add(cashModel);
                }

                _logger.LogInformation($"CashController - Withdraw finished: {cashWithdraw.AsJsonString()}");
            }
            catch(Exception e)
            {
                _logger.LogError($"CashController - Withdraw Exception: {e.Message}");
            }

            return View(cashWithdraw);
        }
    }
}
