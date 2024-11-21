using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IGTask.Core.Data;
using IGTask.Core.DTO;



namespace IGTask.Core.Configrations
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
        }
    }
}
