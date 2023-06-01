using NUnit.Framework;

namespace LabWork4.Tests
{
    [TestFixture]
    public class BooleanFunctionTests
    { 

        [Test]
        public void NegationOperator_TruthTableNegation_ReturnsExpectedTruthTable()
        {
            bool[] truthTable = { false, true };
            BooleanFunction function = new BooleanFunction(truthTable);

            BooleanFunction negatedFunction = !function;

            bool[] expectedTruthTable = { true, false };
            CollectionAssert.AreEqual(expectedTruthTable, negatedFunction.TruthTable);
        }

        [Test]
        public void AndOperator_TruthTableAnd_ReturnsExpectedTruthTable()
        {
            bool[] truthTable1 = { false, false, true, true };
            bool[] truthTable2 = { false, true, false, true };
            BooleanFunction function1 = new BooleanFunction(truthTable1);
            BooleanFunction function2 = new BooleanFunction(truthTable2);

            BooleanFunction resultFunction = function1 & function2;

            bool[] expectedTruthTable = { false, false, false, true };
            CollectionAssert.AreEqual(expectedTruthTable, resultFunction.TruthTable);
        }

        [Test]
        public void OrOperator_TruthTableOr_ReturnsExpectedTruthTable()
        {
            bool[] truthTable1 = { false, false, true, true };
            bool[] truthTable2 = { false, true, false, true };
            BooleanFunction function1 = new BooleanFunction(truthTable1);
            BooleanFunction function2 = new BooleanFunction(truthTable2);

            BooleanFunction resultFunction = function1 | function2;

            bool[] expectedTruthTable = { false, true, true, true };
            CollectionAssert.AreEqual(expectedTruthTable, resultFunction.TruthTable);
        }

        [Test]
        public void XorOperator_TruthTableXor_ReturnsExpectedTruthTable()
        {
            bool[] truthTable1 = { false, false, true, true };
            bool[] truthTable2 = { false, true, false, true };
            BooleanFunction function1 = new BooleanFunction(truthTable1);
            BooleanFunction function2 = new BooleanFunction(truthTable2);

            BooleanFunction resultFunction = function1 ^ function2;

            bool[] expectedTruthTable = { false, true, true, false };
            CollectionAssert.AreEqual(expectedTruthTable, actual: resultFunction.TruthTable);
        }

        [Test]
        public void IdenticallyTrue_Property_ReturnsExpectedValue()
        {
            bool[] truthTable = { true, true, true, true };
            BooleanFunction function = new BooleanFunction(truthTable);

            Assert.IsTrue(function.IdenticallyTrue);
        }

        [Test]
        public void IdenticallyFalse_Property_ReturnsExpectedValue()
        {
            bool[] truthTable = { false, false, false, false };
            BooleanFunction function = new BooleanFunction(truthTable);

            Assert.IsTrue(function.IdenticallyFalse);
        }

        [Test]
        public void IsSelfDual_Property_ReturnsExpectedValue()
        {
            bool[] truthTable = { true, false, false, true };
            BooleanFunction function = new BooleanFunction(truthTable);

            Assert.IsTrue(function.IsSelfDual);
        }

        [Test]
        public void IsMonotonic_Method_ReturnsExpectedValue()
        {
            bool[] truthTable = { false, false, true, true };
            BooleanFunction function = new BooleanFunction(truthTable);

            Assert.IsTrue(function.IsMonotonic());
        }

        [Test]
        public void IsLinear_Property_ReturnsExpectedValue()
        {
            bool[] truthTable = { false, true, true, false };
            BooleanFunction function = new BooleanFunction(truthTable);

            Assert.IsTrue(function.IsLinear);
        }

        [Test]
        public void IsSymmetric_Method_ReturnsExpectedValue()
        {
            bool[] truthTable = { false, true, true, false };
            BooleanFunction function = new BooleanFunction(truthTable);

            Assert.IsTrue(function.IsSymmetric());
        }

        [Test]
        public void Equals_ObjectsAreEqual_ReturnsTrue()
        {
            bool[] truthTable1 = { false, true, true, false };
            bool[] truthTable2 = { false, true, true, false };
            BooleanFunction function1 = new BooleanFunction(truthTable1);
            BooleanFunction function2 = new BooleanFunction(truthTable2);

            Assert.IsTrue(function1.Equals(function2));
        }

        [Test]
        public void Equals_ObjectsAreNotEqual_ReturnsFalse()
        {
            bool[] truthTable1 = { false, true, true, false };
            bool[] truthTable2 = { false, true, false, false };
            BooleanFunction function1 = new BooleanFunction(truthTable1);
            BooleanFunction function2 = new BooleanFunction(truthTable2);

            Assert.IsFalse(function1.Equals(function2));
        }

        [Test]
        public void GetHashCode_ObjectsAreEqual_ReturnsSameHashCode()
        {
            bool[] truthTable1 = { false, true, true, false };
            bool[] truthTable2 = { false, true, true, false };
            BooleanFunction function1 = new BooleanFunction(truthTable1);
            BooleanFunction function2 = new BooleanFunction(truthTable2);

            Assert.AreEqual(function1.GetHashCode(), function2.GetHashCode());
        }

        [Test]
        public void GetHashCode_ObjectsAreNotEqual_ReturnsDifferentHashCodes()
        {
            bool[] truthTable1 = { false, true, true, false };
            bool[] truthTable2 = { false, true, false, false };
            BooleanFunction function1 = new BooleanFunction(truthTable1);
            BooleanFunction function2 = new BooleanFunction(truthTable2);

            Assert.AreNotEqual(function1.GetHashCode(), function2.GetHashCode());
        }
    }
}
