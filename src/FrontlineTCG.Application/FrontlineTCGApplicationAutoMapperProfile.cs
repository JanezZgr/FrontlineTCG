using AutoMapper;
using FrontlineTCG.Cards;

namespace FrontlineTCG;

public class FrontlineTCGApplicationAutoMapperProfile : Profile
{
    public FrontlineTCGApplicationAutoMapperProfile()
    {
        CreateMap<CardAbility,CardAbilityDTO>();
        CreateMap<CardAbilityDTO,CreateUpdateAbilityDTO>();
        CreateMap<CreateUpdateAbilityDTO,CardAbility>();

        CreateMap<Card,CardDTO>();
        CreateMap<CardDTO, CreateUpdateCardDTO>();
        CreateMap<CreateUpdateCardDTO,Card>();

        CreateMap<UnitCard, UnitCardDTO>();
        CreateMap<UnitCardDTO, CreateUpdate_UnitCardDTO>();
        CreateMap<CreateUpdate_UnitCardDTO, UnitCard>();
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
    }
}
