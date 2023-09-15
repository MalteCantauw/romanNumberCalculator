using Malte_Cantauw_flapo_it_exercise.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malte_Cantauw_flapo_it_exercise_test.tests
{
    public class CalculatorUnitTests
    {
        [Fact]
        public void TestCalculator()
        {
            var calculator = new Calculator();
            Assert.NotNull(calculator);
        }

        [Fact]
        public void TestSwitchToInt()
        {
            var calculator = new Calculator();
            Assert.Equal(1, calculator.Switch_to_int("I"));
            Assert.Equal(4, calculator.Switch_to_int("IV"));
            Assert.Equal(5, calculator.Switch_to_int("V"));
            Assert.Equal(9, calculator.Switch_to_int("IX"));
            Assert.Equal(10, calculator.Switch_to_int("X"));
            Assert.Equal(40, calculator.Switch_to_int("XL"));
            Assert.Equal(50, calculator.Switch_to_int("L"));
            Assert.Equal(90, calculator.Switch_to_int("XC"));
            Assert.Equal(100, calculator.Switch_to_int("C"));
            Assert.Equal(400, calculator.Switch_to_int("CD"));
            Assert.Equal(500, calculator.Switch_to_int("D"));
            Assert.Equal(900, calculator.Switch_to_int("CM"));
            Assert.Equal(1000, calculator.Switch_to_int("M"));
            Assert.Equal(3049, calculator.Switch_to_int("MMMXLIX"));
            Assert.Equal(1234, calculator.Switch_to_int("MCCXXXIV"));
            Assert.Equal(3999, calculator.Switch_to_int("MMMCMXCIX"));
            Assert.Equal(1444, calculator.Switch_to_int("MCDXLIV"));
            Assert.Equal(1998, calculator.Switch_to_int("MCMXCVIII"));
        }

        [Fact]
        public void TestSwitchToRoman() {
            var calculator = new Calculator();
            Assert.Equal("I", calculator.Switch_to_roman(1));
            Assert.Equal("IV", calculator.Switch_to_roman(4));
            Assert.Equal("V", calculator.Switch_to_roman(5));
            Assert.Equal("IX", calculator.Switch_to_roman(9));
            Assert.Equal("X", calculator.Switch_to_roman(10));
            Assert.Equal("XL", calculator.Switch_to_roman(40));
            Assert.Equal("L", calculator.Switch_to_roman(50));
            Assert.Equal("XC", calculator.Switch_to_roman(90));
            Assert.Equal("C", calculator.Switch_to_roman(100));
            Assert.Equal("CD", calculator.Switch_to_roman(400));
            Assert.Equal("D", calculator.Switch_to_roman(500));
            Assert.Equal("CM", calculator.Switch_to_roman(900));
            Assert.Equal("M", calculator.Switch_to_roman(1000));
            Assert.Equal("MMMXLIX", calculator.Switch_to_roman(3049));
            Assert.Equal("MMMCMXCIX", calculator.Switch_to_roman(3999));
            Assert.Equal("MCCXXXIV", calculator.Switch_to_roman(1234));
        }

        [Fact]
        public void TestSwitchBoth()
        {
            var calculator = new Calculator();
            for (int i = 0; i <= 3999; i++)
            {
                Assert.Equal(i, calculator.Switch_to_int(calculator.Switch_to_roman(i)));
            }
        }

        [Fact]
        public void TestCheckIfValid_goodInput() {
            var calculator = new Calculator();
            Assert.True(calculator.Check_input_Valid("123"), $"The input 123 should be valid.");
            Assert.True(calculator.Check_input_Valid("MMMCM"), "The input MMMCM should be valid.");
        }

        [Fact]
        public void TestCheckIfValid_falseInput()
        {
            var calculator = new Calculator();
            Assert.False(calculator.Check_input_Valid("asdcse"), "The input asdcse should be invalid");
            Assert.False(calculator.Check_input_Valid("123asdc"), "The input 123asdc should be invalid");
            Assert.False(calculator.Check_input_Valid("MMMCM1234"), "The input MMMCM1234 should be invalid");
            Assert.False(calculator.Check_input_Valid("MMMCMasxc"), "The input MMMCMasxc should be invalid");
            Assert.False(calculator.Check_input_Valid("IVMMM"), "The input IVMMM should be invalid");
            Assert.False(calculator.Check_input_Valid("MMMM"), "The input MMMM should be invalid");
            Assert.False(calculator.Check_input_Valid("2.1"), "The input 2.1 should be invalid");
        }
    }
}
