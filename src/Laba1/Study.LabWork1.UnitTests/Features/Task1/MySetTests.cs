using System;
using System.Collections.Generic;
using System.Text;
using Study.LabWork1.Features.Task1;

namespace Study.LabWork1.UnitTests.Features.Task1
{
    [TestFixture]
    public class MySetTests
    {

        [Test]
        public void Constructor()
        {
            var set = new MySet<int>(new[] { 1, 1, 2, 3, 3 });

            Assert.That(set.Count(), Is.EqualTo(3));
            Assert.That(set.Contains(1));
            Assert.That(set.Contains(2));
            Assert.That(set.Contains(3));
        }

        [Test]
        public void Union()
        {
            var a = new MySet<int>(new[] { 1, 2, 3 });
            var b = new MySet<int>(new[] { 3, 4 });

            var result = a | b;

            Assert.That(result, Is.EqualTo(new MySet<int>(new[] { 1, 2, 3, 4 })));
        }

        [Test]
        public void Intersection()
        {
            var a = new MySet<int>(new[] { 1, 2, 3 });
            var b = new MySet<int>(new[] { 2, 3, 4 });

            var result = a & b;

            Assert.That(result, Is.EqualTo(new MySet<int>(new[] { 2, 3 })));
        }

        [Test]
        public void Difference()
        {
            var a = new MySet<int>(new[] { 1, 2, 3 });
            var b = new MySet<int>(new[] { 2 });

            var result = a - b;

            Assert.That(result, Is.EqualTo(new MySet<int>(new[] { 1, 3 })));
        }

        [Test]
        public void SymmetricDifference()
        {
            var a = new MySet<int>(new[] { 1, 2, 3 });
            var b = new MySet<int>(new[] { 3, 4 });

            var result = a / b;

            Assert.That(result, Is.EqualTo(new MySet<int>(new[] { 1, 2, 4 })));
        }

        [Test]
        public void Operations_DoNotModifyOriginalSets()
        {
            var a = new MySet<int>(new[] { 1, 2 });
            var b = new MySet<int>(new[] { 2, 3 });

            var _ = a | b;
            var __ = a & b;
            var ___ = a - b;
            var ____ = a / b;

            Assert.That(a, Is.EqualTo(new MySet<int>(new[] { 1, 2 })));
            Assert.That(b, Is.EqualTo(new MySet<int>(new[] { 2, 3 })));
        }

        [Test]
        public void EqualityWorksRegardlessOfOrder()
        {
            var a = new MySet<int>(new[] { 1, 2, 3 });
            var b = new MySet<int>(new[] { 3, 2, 1 });

            Assert.That(a == b, Is.True);
            Assert.That(a != b, Is.False);
        }

        [Test]
        public void EqualityReturnsFalseForDifferentSets()
        {
            var a = new MySet<int>(new[] { 1, 2 });
            var b = new MySet<int>(new[] { 1, 3 });

            Assert.That(a == b, Is.False);
            Assert.That(a != b, Is.True);
        }

        [Test]
        public void EqualsMethod()
        {
            var a = new MySet<int>(new[] { 1, 2 });
            var b = new MySet<int>(new[] { 2, 1 });

            Assert.That(a.Equals(b), Is.True);
        }

        [Test]
        public void StringFormatCorrect()
        {
            var set = new MySet<int>(new[] { 1, 2, 3 });

            var str = set.ToString();

            Assert.That(str.StartsWith("{"));
            Assert.That(str.EndsWith("}"));
            Assert.That(str.Contains("1"));
            Assert.That(str.Contains("2"));
            Assert.That(str.Contains("3"));
        }

        [Test]
        public void EmptySets()
        {
            var a = new MySet<int>(Array.Empty<int>());
            var b = new MySet<int>(Array.Empty<int>());

            Assert.That(a, Is.EqualTo(b));

            Assert.That((a | b).Any(), Is.False);
            Assert.That((a & b).Any(), Is.False);
        }

        [Test]
        public void NullComparison()
        {
            var a = new MySet<int>(new[] { 1, 2 });

            Assert.That(a == null, Is.False);
            Assert.That(a != null, Is.True);
        }

        [Test]
        public void StringsWork()
        {
            var a = new MySet<string>(new[] { "a", "b", "b" });
            var b = new MySet<string>(new[] { "b", "c" });

            var result = a | b;

            Assert.That(result, Is.EqualTo(new MySet<string>(new[] { "a", "b", "c" })));
        }
    }
}
