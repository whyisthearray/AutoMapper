using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace ConsoleApplication1
{
    static class Program
    {
        static void Main(string[] args)
        {
            var toMapping = new
            {
                name = 13,
                surname = 15,
                adress = new
                {
                    street = 23,
                    number = 14f

                }
            };

            var propList = toMapping.GetType().GetProperties().ToList();
            var typeofAnon = propList[2].PropertyType;

            var ctor = typeofAnon.GetConstructors()[0];
            var inst = ctor.Invoke(new object[ctor.GetParameters().Length]);

            var val = propList[2].GetValue(toMapping);

            inst = val;
        }
    }
}
