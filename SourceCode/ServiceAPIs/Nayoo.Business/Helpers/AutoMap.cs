using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Nayoo.Business.Helpers
{
    public class AutoMap<Source, Destination>
    {
        public static Destination Map(Source source)
        {
            AutoMapper.Mapper.CreateMap<Source, Destination>();
            var obj = AutoMapper.Mapper.Map<Source, Destination>(source);
            return obj;
        }

        public static List<Destination> Map(List<Source> source)
        {
            AutoMapper.Mapper.CreateMap<Source, Destination>();
            var obj = AutoMapper.Mapper.Map<List<Source>, List<Destination>>(source);
            return obj;
        }
    }
}
