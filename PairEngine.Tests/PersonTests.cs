using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairEngine.Tests
{
    [TestFixture]
    public class PersonTests
    {
        [Test]
        public void Id_increasing()
        {
            var personNull = new Person();
            var id = personNull.Id;

            var person1 = new Person();
            var person2 = new Person();
            Assert.AreEqual(++id, person1.Id);
            Assert.AreEqual(++id, person2.Id);
        }

        [Test]
        public void Link_couple()
        {
            var person1 = new Person();
            var person2 = new Person();

            person1.Link(person2);
            Assert.True(person1.IsCouple(person2));
            Assert.True(person2.IsCouple(person1));

            var person3 = new Person();
            Assert.False(person3.IsCouple(person2));

        }

        [Test]
        public void Break_couple()
        {
            var person1 = new Person();
            var person3 = new Person();

            person1.Link(person3);

            var person2 = new Person();
            person2.Link(person1);

            Assert.True(person1.IsCouple(person2));
            Assert.True(person2.IsCouple(person1));
            Assert.False(person3.IsCouple(person1));
        }
    }
}
