using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using SmartPTUI.Business.ViewModels;
using SmartPTUI.Data;

namespace SmartPTUI.Business
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<CustomerViewModel, Customer>().ReverseMap();
        }

    }
}
