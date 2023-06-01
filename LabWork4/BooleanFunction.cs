using System;
using System.Text;

namespace LabWork4
{
    [Serializable]
    public class BooleanFunction : BaseBooleanFunction
    {
        public bool[] TruthTable;

        public BooleanFunction(bool[] truthTable) : base(truthTable)
        {
            TruthTable = truthTable;
        }

        public bool this[bool input1, bool input2]
        {
            get { return Evaluate(input1, input2); }
        }

        public bool IdenticallyTrue => base.IdenticallyTrue;

        public bool IdenticallyFalse => base.IdenticallyFalse;

        public bool IsSelfDual => base.IsSelfDual;

        public bool IsMonotonic() => base.IsMonotonic();

        public bool IsLinear => base.IsLinear;

        public bool IsSymmetric() => base.IsSymmetric();
        /// <summary>
        /// Обчислює значення функції для заданих вхідних параметрів.
        /// </summary>
        /// <param name="inputs">Вхідні параметри</param>
        /// <returns>Значення функції</returns>
        protected override bool Calculate(bool[] inputs)
        {
            if (inputs == null || inputs.Length != InputCount)
                throw new ArgumentException("Invalid input values");

            int index = GetNumber(inputs);
            return TruthTable[index];
        }
        /// <summary>
        /// Перегрузка оператора "НЕ" для функції.
        /// </summary>
        /// <param name="function">Функція</param>
        /// <returns>Неговорна функція</returns>
        public static BooleanFunction operator !(BooleanFunction function)
        {
            bool[] negatedTable = new bool[function.TruthTable.Length];
            for (int i = 0; i < function.TruthTable.Length; i++)
            {
                negatedTable[i] = !function.TruthTable[i];
            }

            return new BooleanFunction(negatedTable);
        }
        /// <summary>
        /// Перегрузка оператора "І" для функцій.
        /// </summary>
        /// <param name="function1">Перша функція</param>
        /// <param name="function2">Друга функція</param>
        /// <returns>Функція, отримана шляхом логічного "І" двох функцій</returns>
        public static BooleanFunction operator &(BooleanFunction function1, BooleanFunction function2)
        {
            ValidateFunctionCompatibility(function1, function2);
            bool[] resultTable = new bool[function1.TruthTable.Length];
            for (int i = 0; i < function1.TruthTable.Length; i++)
            {
                resultTable[i] = function1.TruthTable[i] && function2.TruthTable[i];
            }

            return new BooleanFunction(resultTable);
        }
        /// <summary>
        /// Перегрузка оператора "АБО" для функцій.
        /// </summary>
        public static BooleanFunction operator |(BooleanFunction function1, BooleanFunction function2)
        {
            ValidateFunctionCompatibility(function1, function2);
            bool[] resultTable = new bool[function1.TruthTable.Length];
            for (int i = 0; i < function1.TruthTable.Length; i++)
            {
                resultTable[i] = function1.TruthTable[i] || function2.TruthTable[i];
            }

            return new BooleanFunction(resultTable);
        }
        /// <summary>
        /// Перегрузка оператора "Виключне АБО" для функцій.
        /// </summary>
        public static BooleanFunction operator ^(BooleanFunction function1, BooleanFunction function2)
        {
            ValidateFunctionCompatibility(function1, function2);
            bool[] resultTable = new bool[function1.TruthTable.Length];
            for (int i = 0; i < function1.TruthTable.Length; i++)
            {
                resultTable[i] = function1.TruthTable[i] ^ function2.TruthTable[i];
            }

            return new BooleanFunction(resultTable);
        }
        /// <summary>
        /// Перевіряє рівність двох функцій.
        /// </summary>
        public static bool operator ==(BooleanFunction function1, BooleanFunction function2)
        {
            return Equals(function1, function2);
        }
        /// <summary>
        /// Перевіряє нерівність двох функцій.
        /// </summary>
        public static bool operator !=(BooleanFunction function1, BooleanFunction function2)
        {
            return !Equals(function1, function2);
        }
        /// <summary>
        /// Перевіряє, чи дорівнює об'єкт поточній функції.
        /// </summary>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        /// <summary>
        /// Повертає хеш-код функції.
        /// </summary>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        /// <summary>
        /// Повертає рядкове представлення функції.
        /// </summary>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Truth Table:");
            int rowCount = TruthTable.Length / InputCount;
            int columnCount = InputCount + 1;

            for (int i = 0; i < columnCount; i++)
            {
                if (i < InputCount)
                    sb.Append($"Input {i + 1}\t");
                else
                    sb.Append("Output\t");
            }
            sb.AppendLine();

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    if (j < InputCount)
                        sb.Append($"{((i >> (InputCount - j - 1)) & 1) == 1}\t");
                    else
                        sb.Append($"{TruthTable[i * columnCount + j]}\t");
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }

        private int GetNumber(bool[] binary)
        {
            int result = 0;
            int power = InputCount - 1;

            for (int i = 0; i < InputCount; i++)
            {
                int bitValue = binary[i] ? 1 : 0;
                result += bitValue * (int)Math.Pow(2, power);
                power--;
            }

            return result;
        }

        private static void ValidateFunctionCompatibility(BooleanFunction function1, BooleanFunction function2)
        {
            if (function1.InputCount != function2.InputCount)
                throw new ArgumentException("Input counts of the two functions do not match");
        }

        protected override BaseBooleanFunction CreateInstance(bool[] truthTable)
        {
            return null;
        }

    }
}