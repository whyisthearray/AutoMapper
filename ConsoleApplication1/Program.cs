using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace ConsoleApplication1
{
    static class Program
    {
        static void Main(string[] args)
        {
            var a = new
            {
                name = 13,
                surname = 15
            };
            var b = Activator.CreateInstance(a.GetType());

        }
    }
}
