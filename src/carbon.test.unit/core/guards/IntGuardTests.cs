using carbon.core.guards;
using NUnit.Framework;

namespace carbon.test.unit.core.guards
{
    [TestFixture]
    public class IntGuardTests
    {
        [Test]
        public void IntZeroGuardThrow()
        {    
            int test = 0;

            Assert.Throws<GuardException>(() =>
            {
                Guard.Against(test, GuardType.Zero);
            });

        }
        
        [Test]
        public void IntZeroGuardNoThrow()
        {
            int test = 110;

            Assert.DoesNotThrow(() =>
            {
                Guard.Against(test, GuardType.Zero);
            });

        }
        
        [Test]
        public void IntNotZeroGuardThrow()
        {    
            int test = 100;

            Assert.Throws<GuardException>(() =>
            {
                Guard.Against(test, GuardType.NotZero);
            });

        }
        
        [Test]
        public void IntNotZeroGuardNoThrow()
        {
            int test = 0;

            Assert.DoesNotThrow(() =>
            {
                Guard.Against(test, GuardType.NotZero);
            });

        }
        
    }
}