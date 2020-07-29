using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace xunit.calculatorTests
{
    public static class TestDataShare
    {
        public static IEnumerable<object[]> AddOrSubtractData
        {
            get
            {
                yield return new object[] {3, 4, -1, true};
                yield return new object[] { 3, 4, 10, false };
            }

        }


        public static IEnumerable<object[]> AddOrSubtractDataFromTextFile
        {
            get
            {
                var alllines = System.IO.File.ReadAllLines("Data.txt");
                return alllines.Select(x =>
                {
                    var lineSplit = x.Split(',');
                    return new object[] {int.Parse(lineSplit[0]), int.Parse(lineSplit[1]), int.Parse(lineSplit[2]), bool.Parse(lineSplit[3])};
                });
            }


        }




    }
}
