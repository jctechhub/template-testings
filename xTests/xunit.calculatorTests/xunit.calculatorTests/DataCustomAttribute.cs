using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit.Sdk;
namespace xunit.calculatorTests
{
    public class DataCustomAttribute : DataAttribute
    {
        

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            var alllines = System.IO.File.ReadAllLines("Data.txt");
            return alllines.Select(x =>
            {
                var lineSplit = x.Split(',');
                return new object[] { int.Parse(lineSplit[0]), int.Parse(lineSplit[1]), int.Parse(lineSplit[2]), bool.Parse(lineSplit[3]) };
            });
        }
    }
}
