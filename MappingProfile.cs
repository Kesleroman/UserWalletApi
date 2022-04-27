using AutoMapper;
using PlayersWallet.Model;

namespace PlayersWallet
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Transaction, TransactionDto>();
        }
    }
}
