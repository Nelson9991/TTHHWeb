using AutoMapper;
using TTHHWeb.Shared.Models.Trabajador;

namespace TTHHWeb.Client.Mappers;

public class MapperProfiles : Profile
{
  public MapperProfiles()
  {
    CreateMap<TrabajadorDto, UpsertTrabajadorDto>();
  }
}
