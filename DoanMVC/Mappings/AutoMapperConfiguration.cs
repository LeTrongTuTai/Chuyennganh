using AutoMapper;
using DoanMVC.Models;
using Model.EF;

namespace DoanMVC.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {           
            Mapper.CreateMap<USERGROUP, UserGroupViewModel>();           
        }
    }
}