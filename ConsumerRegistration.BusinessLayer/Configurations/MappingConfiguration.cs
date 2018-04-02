using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ConsumerRegistrationPortal.BusinessLayer.Dtos;
using ConsumerRegistrationPortal.EntityFramework;

namespace ConsumerRegistrationPortal.BusinessLayer.Configurations
{
   public static class MappingConfiguration<TSource,TDestination> where TSource : class where TDestination : class
    {
        internal static TDestination GetDestination(TSource source)
        {
            var config = new MapperConfiguration(cfg =>
            cfg.CreateMap<TSource, TDestination>()
            );

            var mapper = config.CreateMapper();
            return mapper.Map<TDestination>(source);
        }

        internal static List<TDestination> GetDestinationAsList(List<TSource> source)
        {
            var config = new MapperConfiguration(cfg =>
            cfg.CreateMap<TSource, TDestination>()
            );

            var mapper = config.CreateMapper();
            return mapper.Map<List<TDestination>>(source);
        }

        //internal static List<HTMLGenerationMultipleEntity> GetDestinationAsList(List<TerminologiesDetail> list)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
