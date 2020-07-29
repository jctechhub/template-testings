using System;
using System.Security.Principal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Xunit;
using Assert = Xunit.Assert;

namespace xunit.calculatorTests
{
    public class CalculatorFixture
    {
        public Calculator Calc => new Calculator();
        public PrivateObject CalcPrivate => new PrivateObject(new Calculator());
    }


    public class CalculatorTests : IClassFixture<CalculatorFixture>
    {
        private CalculatorFixture _calculatorFixture;

        public CalculatorTests(CalculatorFixture calculatorFixture)
        {
            _calculatorFixture = calculatorFixture;
        }

        [Fact]
        [Trait("CalCategory", "Add")]
        public void privateMethod_test_success()
        {
            var result = _calculatorFixture.CalcPrivate.Invoke("AddThenSubtract", 3, 4) as int?;
            Assert.True(result == 6);
        }

        [Fact]
        [Trait("CalCategory", "Add")]
        public void test_add_success()
        {
            Assert.True(_calculatorFixture.Calc.Add(3, 4) == 7, "Cal Add result is 7. ");
        }

        [Fact]
        [Trait("CalCategory", "Add")]
        public void test_add_fail()
        {
            Assert.False(_calculatorFixture.Calc.Add(3, 4) == 10, "Cal Add result isn't 10. ");
        }



        [Fact]
        [Trait("CalCategory", "Subtract")]
        public void test_subtract_success()
        {
            Assert.True(_calculatorFixture.Calc.Subtract(3, 4) == -1, "Cal subtract result is -1. ");
        }

        [Fact]
        [Trait("CalCategory", "Subtract")]
        public void test_subtract_fail()
        {
            Assert.False(_calculatorFixture.Calc.Subtract(3, 4) == -10, "Cal subtract result isnot  -10. ");
        }


        [Theory]
        [InlineData(3,4, -1, true)]
        [InlineData(3, 4, -10, false)]
        [Trait("CalCategory", "Subtract")]
        public void test_subtract_generic(int x, int y, int result, bool expected)
        {
            var check = _calculatorFixture.Calc.Subtract(x, y) == result;
            Assert.Equal(check, expected);
        }

        [Theory]
        [MemberData(nameof(TestDataShare.AddOrSubtractDataFromTextFile), MemberType = typeof(TestDataShare))]
        [Trait("CalCategory", "Subtract")]
        public void test_subtract_generic_using_share_data(int x, int y, int result, bool expected)
        {
            var check = _calculatorFixture.Calc.Subtract(x, y) == result;
            Assert.Equal(check, expected);
        }

        [Theory]
        [DataCustom]
        [Trait("CalCategory", "Subtract")]
        public void test_subtract_generic_using_share_data_in_custom_attribute(int x, int y, int result, bool expected)
        {
            var check = _calculatorFixture.Calc.Subtract(x, y) == result;
            Assert.Equal(check, expected);
        }

        /// <summary>
        /// this illustrates the mocking using MOQ
        /// </summary>
        [Fact]
        [Trait("Category", "Mocking")]
        public void mocking_test_specialFunction()
        {
            var input = 10;
            var prefix = Mock.Of<SpecialPrefix>(x=>x.ResultPrefix == "Mocking of Prefix");
            var specialFunction = new Mock<ICalculatorSpecialFunctionsInterface>();
            specialFunction.Setup(x => x.DividedBy2(input, prefix.ResultPrefix)).Returns($"Mocking result is 5");

            var specialCal = new SpecialCalculator(specialFunction.Object);
            var expected = "final result is: Mocking result is 5";
            var result = specialCal.GetFinalResult();
            Assert.True(string.Compare(expected, result, StringComparison.CurrentCultureIgnoreCase) == 0);
        }

        ////this is the mocking for ASP.NET MVC Controller. 
        //private void MockHTTPContext()
        //{
        //    var fakeHttpContext = new Mock<HttpContextBase>();
        //    var fakeIdentity = new GenericIdentity("test@gmail.com");
        //    var principal = new GenericPrincipal(fakeIdentity, null);

        //    fakeHttpContext.Setup(t => t.User).Returns(principal);

        //    var controllerContext = new Mock<ControllerContext>();
        //    controllerContext.Setup(t => t.HttpContext).Returns(fakeHttpContext.Object);

        //    this.ControllerContext = controllerContext.Object;
        //    var combforms = new CombatFormsController();
        //    combforms.ControllerContext = controllerContext.Object;
        //}

    }
}
