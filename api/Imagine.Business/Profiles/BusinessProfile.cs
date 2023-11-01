using AutoMapper;
using Imagine.Business.Models;
using Imagine.EntityFramework.Entities;

namespace Imagine.Business.Profiles
{
    public class BusinessProfile : Profile
    {
        public BusinessProfile()
        {
            CreateMap<MovieEntity, Movie>();
        }
    }
}
