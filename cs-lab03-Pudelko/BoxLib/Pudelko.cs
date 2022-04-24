using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using cs_lab03_Pudelko.BoxLib;
using Microsoft.VisualBasic.CompilerServices;

namespace cs_lab03_Pudelko
{
    public sealed class Pudelko : IEquatable<Pudelko>, IComparable<Pudelko>, IFormattable, IEnumerator
    {
        #region Variables/Properties
        private double a, b, c;
        private UnitOfMeasure unit { get; set; }

        public double A
        {
            get => a;
            set => a = value;
        }

        public double B
        {
            get => b;
            set => b = value;
        }

        public double C
        {
            get => c;
            set => c = value;
        }
        #endregion

        #region Constructor
        public double ConvertToMeters(double? length, UnitOfMeasure unit)
        {
            if (length == null)
                return 0.1;

            if (unit == UnitOfMeasure.milimeter)
                if (length <= 0.1)
                    return 0;
                else
                    return (double)(length / (double)unit);
            else if (unit == UnitOfMeasure.centimeter)
                if (length <= 0.1)
                    return 0;
                else
                    return (double)(length / (double)unit);
            else
                return (double)length;
        }
        public Pudelko(double? a = null, double? b = null, double? c = null, UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            this.unit = unit;
            A = ConvertToMeters(a, this.unit);
            B = ConvertToMeters(b, this.unit);
            C = ConvertToMeters(c, this.unit);
            if (A <= 0 || B <= 0 || C <= 0 || A > 10 || B > 10 || C > 10)
                throw new ArgumentOutOfRangeException();
        }
        #endregion

        #region Conversions
        public double Objetosc => Math.Round((A * B * C), 9);
        public double Pole => Math.Round((2 * A * C + 2 * A * B + 2 * B * C), 6);

        #endregion

        #region Indexer, Enumeration
        private double[] Boxes => new[] {A, B, C};
        private int _position = -1;

        public double this[int index]
        {
            get
            {
                if (index == 0)
                    return A;
                if (index == 1)
                    return B;
                if (index == 2)
                    return C;
                throw new ArgumentOutOfRangeException();
            }
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }
        public bool MoveNext()
        {
            _position++;
            return(_position < Boxes.Length);
        }

        public void Reset()
        {
            _position = -1;
        }

        public object Current => Boxes[_position];

        #endregion

        #region Equals
        public bool Equals(Pudelko other)
        {

            if (A + B + C == other.A + other.B + other.C)
                return true;
            else
                return false;
        }
        public override int GetHashCode()
        {
            return A.GetHashCode() + B.GetHashCode() + C.GetHashCode();
        }
        #endregion

        #region Operators, Overloading
        public static bool operator ==(Pudelko pudelko1, Pudelko pudelko2)
        {
            if (ReferenceEquals(pudelko1, pudelko2))
                return true;
            if (ReferenceEquals(pudelko1, null))
                return false;
            if (ReferenceEquals(pudelko2, null))
                return false;
            return pudelko1.Equals(pudelko2);
        }

        public static bool operator !=(Pudelko pudelko1, Pudelko pudelko2) => !(pudelko1 == pudelko2);
        public static explicit operator double[](Pudelko p) => new[] { p.A, p.B, p.C };

        public static implicit operator Pudelko(ValueTuple<int, int, int> p) =>
            new(p.Item1, p.Item2, p.Item3, UnitOfMeasure.milimeter);

        

        public static Pudelko operator + (Pudelko pudelko1, Pudelko pudelko2)
        {
            double x, y, z;
            x = pudelko1.A + pudelko2.A;
            if (pudelko1.B > pudelko2.B)
                y = pudelko1.B;
            else
                y = pudelko2.B;
            if (pudelko1.C > pudelko2.C)
                z = pudelko1.C;
            else
                z = pudelko2.C;
            return new Pudelko(x, y, z);
        }
        #endregion

        #region Comparison<Pudelko>
        public int CompareTo(Pudelko other)
        {
            if (Objetosc < other.Objetosc) return -1;
            if (Objetosc > other.Objetosc) return 1;
            if (Objetosc.Equals(other.Objetosc))
            {
                if (Pole < other.Pole) return -1;
                if (Pole > other.Pole) return 1;
                if (Pole.Equals(other.Pole))
                {
                    if (A + B + C < other.A + other.B + other.C) return -1;
                    if (A + B + C > other.A + other.B + other.C) return 1;

                }
            }
            return 0;
        }
        #endregion

        #region Parse
        public static Pudelko Parse(string pudelko)
        {
            char[] separators = {' ', 'm', '×' };
            string[] tokens = pudelko.Split(separators).Where(x => !string.IsNullOrEmpty(x)).ToArray();
            double[] numbers = new double[3];
            for (int i = 0; i < tokens.Length; i++)
            {
                numbers[i] = Convert.ToDouble(tokens[i].Trim());
            }

            return new Pudelko(numbers[0], numbers[1], numbers[2]);
        }
        #endregion

        #region ToString
        public override string ToString()
        {
            string precision;
            if (unit == UnitOfMeasure.meter)
            {
                precision = "m";
            }
            else if (unit == UnitOfMeasure.centimeter)
            {
                precision = "cm";
            }
            else
            {
                precision = "mm";
            }
            return ToString(precision);
        }

        public string ToString(string format, IFormatProvider formatProvider = null)
        {
            if (format == "m" || format == "" || format == null)
            {
                format = "m";
                return
                    $"{A.ToString("F3", formatProvider)} {format} × {B.ToString("F3", formatProvider)} {format} × {C.ToString("F3", formatProvider)} {format}";
            }
            else if (format == "cm")
            {
                return
                    $"{(A * 100).ToString("F1", formatProvider)} {format} × {(B * 100).ToString("F1", formatProvider)} {format} × {(C * 100).ToString("F1", formatProvider)} {format}";
            }
            else if (format == "mm")
            {
                return $"{(A * 1000).ToString("F0", formatProvider)} {format} × {(B * 1000).ToString("F0", formatProvider)} {format} × {(C * 1000).ToString("F0", formatProvider)} {format}";
            }
            else
            {
                throw new FormatException();
            }
        }
        #endregion
    }
}
