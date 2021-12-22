using AutoMapper;
using Enalyzer.ATM.Domain.Cash;
using Enalyzer.ATM.Web.Models.Cash;

namespace Enalyzer.ATM.Web.Profiles
{
    public class CashProfile : Profile
    {
        public CashProfile()
        {
            CreateMap<Cash, CashViewModel>();
        }
    }
}