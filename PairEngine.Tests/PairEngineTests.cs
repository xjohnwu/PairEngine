using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairEngine.Tests
{
    [TestFixture]
    public class PairEngineTests
    {
        [Test]
        public void PairEngine()
        {
            var a = new Person("sky");
            var b = new Person("cc");
            var c = new Person("wh");

            var pairEngine = new PairEngine(new[] { a, b, c });
            pairEngine.PairUp();

            AssertConsistency(pairEngine.PairList);
            pairEngine.PrintResult();
        }

        [Test, ExpectedException(typeof(OperationCanceledException))]
        public void PairEngine_exception()
        {
            var a = new Person("sky");
            var b = new Person("cc");
            a.Link(b);
            var c = new Person("wh");

            var pairEngine = new PairEngine(new[] { a, b, c });
            pairEngine.PairUp();

            AssertConsistency(pairEngine.PairList);
            pairEngine.PrintResult();
        }

        private void AssertConsistency(IDictionary<Person,Person> result)
        {
            foreach (var kv in result)
            {
                Assert.IsFalse(kv.Key.IsCouple(kv.Value));
            }
        }

        [Test]
        public void PairEngine_full()
        {
            var a = new Person("sky");
            var b = new Person("cc");
            a.Link(b);
            var c = new Person("mich");
            var d = new Person("ray");
            c.Link(d);
            var e = new Person("ml");
            var f = new Person("fei");
            e.Link(f);
            var g = new Person("shuqi");
            var h = new Person("lzs");
            g.Link(h);
            var i = new Person("suqi");
            var j = new Person("chris");
            i.Link(j);

            var pairEngine = new PairEngine(new[] { a, b, c, d, e, f, g, h, i, j });
            pairEngine.PairUp();

            AssertConsistency(pairEngine.PairList);
            pairEngine.PrintResult();
        }
    }
}
