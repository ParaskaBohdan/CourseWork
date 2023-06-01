using System;

namespace LabWork4
{
    public abstract class BaseBooleanFunction : IBooleanFunction, IEquatable<BaseBooleanFunction>, ICloneable
    {
        protected bool[] truthTable;

        public BaseBooleanFunction(bool[] truthTable)
        {
            if (truthTable == null)
                throw new ArgumentNullException(nameof(truthTable));

            int tableLength = truthTable.Length;
            int inputCount = (int)Math.Log2(tableLength);

            if (tableLength != Math.Pow(2, inputCount))
                throw new ArgumentException("Invalid truth table size");

            this.truthTable = truthTable;
            InputCount = inputCount;
        }

        public string GetName()
        {
            return "BooleanFunction";
        }

        public bool Evaluate(bool input1, bool input2)
        {
            bool[] inputs = new bool[] { input1, input2 };
            return Calculate(inputs);
        }

        public int InputCount { get; }

        public bool Evaluate(params bool[] inputs)
        {
            if (inputs == null || inputs.Length != InputCount)
                throw new ArgumentException("Invalid input values");

            return Calculate(inputs);
        }

        protected abstract bool Calculate(bool[] inputs);

        public bool IdenticallyTrue
        {
            get
            {
                for (int i = 0; i < truthTable.Length; i++)
                {
                    if (!truthTable[i])
                        return false;
                }

                return true;
            }
        }

        public bool IdenticallyFalse
        {
            get
            {
                for (int i = 0; i < truthTable.Length; i++)
                {
                    if (truthTable[i])
                        return false;
                }

                return true;
            }
        }

        public bool IsSelfDual
        {
            get
            {
                int halfTableLength = truthTable.Length / 2;
                for (int i = 0; i < halfTableLength; i++)
                {
                    if (truthTable[i] != !truthTable[truthTable.Length - 1 - i])
                        return false;
                }

                return true;
            }
        }

        public bool IsMonotonic()
        {
            for (int i = 1; i < truthTable.Length; i++)
            {
                if (truthTable[i - 1] && !truthTable[i])
                    return false;
            }

            return true;
        }

        public bool IsLinear
        {
            get
            {
                for (int i = 0; i < truthTable.Length; i++)
                {
                    if (truthTable[i] != false)
                        return false;
                }

                return true;
            }
        }

        public bool IsSymmetric()
        {
            int halfTableLength = truthTable.Length / 2;
            for (int i = 0; i < halfTableLength; i++)
            {
                if (truthTable[i] != truthTable[truthTable.Length - 1 - i])
                    return false;
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            if (ReferenceEquals(null, obj) || obj.GetType() != GetType())
                return false;

            return Equals((BaseBooleanFunction)obj);
        }

        public bool Equals(BaseBooleanFunction other)
        {
            if (ReferenceEquals(null, other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (truthTable.Length != other.truthTable.Length)
                return false;

            for (int i = 0; i < truthTable.Length; i++)
            {
                if (truthTable[i] != other.truthTable[i])
                    return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + InputCount.GetHashCode();
            for (int i = 0; i < truthTable.Length; i++)
            {
                hash = hash * 23 + truthTable[i].GetHashCode();
            }

            return hash;
        }

        public object Clone()
        {
            bool[] clonedTable = (bool[])truthTable.Clone();
            return CreateInstance(clonedTable);
        }

        protected abstract BaseBooleanFunction CreateInstance(bool[] truthTable);
    }
}
