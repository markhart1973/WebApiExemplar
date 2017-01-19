using StructureMap;
using System;
using System.Linq;
using AutoMapper;

namespace WebApiWithStructureMap.Infrastructure.Mapper
{
    public class MapperRegistry :
        Registry
    {
        public MapperRegistry()
        {
            var profiles = typeof(MapperRegistry)
                .Assembly
                .GetTypes()
                .Where(x => typeof(Profile).IsAssignableFrom(x))
                .Select(x => (Profile)Activator.CreateInstance(x))
                .ToList();

            var config = new MapperConfiguration(cfg =>
            {
                foreach (var profile in profiles)
                {
                    cfg.AddProfile(profile);
                }
            });

            //Create a mapper that will be used by the DI container
            var mapper = config.CreateMapper();

            //Register the DI interfaces with their implementation
            For<IConfigurationProvider>().Use(config);
            For<IMapper>().Use(mapper);
        }
    }
}