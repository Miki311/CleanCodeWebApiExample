using Mapster;
using CleanCodeExample.Contracts.Deals;
using CleanCodeExample.Application.DealHandling.Commands;
using CleanCodeExample.Application.DealHandling.Queries;

namespace CleanCodeExample.Api.Mapping
{
    public class DealMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<DealRequest, AddDealComand>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.Objection, src => src.Objection);

            config.NewConfig<DealRequest, GetDealQuery>()
                .Map(dest => dest.Id, src => src.Id);
               
            config.NewConfig<DealResponseResult, DealResponse>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name);
        }
    }
}
