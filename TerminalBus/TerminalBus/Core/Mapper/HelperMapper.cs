using AutoMapper;
using System;
using TerminalBus.Core.Model;
using TerminalBus.Core.ViewModel;

namespace TerminalBus.Core.Mapper
{
    public class HelperMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg => {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<MappingProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;

        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<BusViewModel, Bus>();
                CreateMap<Bus, BusViewModel>();

                CreateMap<ViajeViewModel, Viaje>();
                CreateMap<Viaje, ViajeViewModel>();

                CreateMap<BoletoViewModel, Boleto>();
                CreateMap<Boleto, BoletoViewModel>();

            }
        }
    }
}
