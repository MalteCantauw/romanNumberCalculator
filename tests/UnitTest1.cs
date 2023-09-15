namespace tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestSwitchToInt()
        {
            Calc calc = new Calc();
            Assert.AreEqual(true, calc.Switch_To_int(), "123");
        }
    }
}