using AutoMapper;
using HW2.Data.Domain;
using SipayApi.Schema;

namespace HW2.Schema.Mapper
{
    public class MapperConfig :Profile
    {
        public MapperConfig()
        {
            CreateMap<Transaction,TransactionResponse>().ReverseMap();

        }
    }
}
