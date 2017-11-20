using System;
using System.Reflection;

namespace ISC.Whitest.Core.EqualityHelpers
{
    public class EqualsBuilder
    {
        private bool _isEqual;

        public EqualsBuilder()
        {
            _isEqual = true;
        }

        public static bool ReflectionEquals(object lhs, object rhs)
        {
            return ReflectionEquals(lhs, rhs, false, null);
        }

        public static bool ReflectionEquals(object lhs, object rhs, bool testTransients)
        {
            return ReflectionEquals(lhs, rhs, testTransients, null);
        }

        public static bool ReflectionEquals(object lhs, object rhs, bool testTransients, Type reflectUpToClass)
        {
            if (lhs == rhs)
                return true;
            if (lhs == null || rhs == null)
                return false;

            var lhsClass = lhs.GetType();
            var rhsClass = rhs.GetType();
            Type testClass;
            if (lhsClass.IsInstanceOfType(rhs))
            {
                testClass = lhsClass;
                if (!rhsClass.IsInstanceOfType(lhs))
                    testClass = rhsClass;
            }
            else if (rhsClass.IsInstanceOfType(lhs))
            {
                testClass = rhsClass;
                if (!lhsClass.IsInstanceOfType(rhs))
                    testClass = lhsClass;
            }
            else
            {
                return false;
            }
            var equalsBuilder = new EqualsBuilder();
            try
            {
                ReflectionAppend(lhs, rhs, testClass, equalsBuilder, testTransients);
                while (testClass.BaseType != null && testClass != reflectUpToClass)
                {
                    testClass = testClass.BaseType;
                    ReflectionAppend(lhs, rhs, testClass, equalsBuilder, testTransients);
                }
            }
            catch (ArgumentException e)
            {
                return false;
            }
            return equalsBuilder.IsEquals();
        }

        private static void ReflectionAppend(
            object lhs,
            object rhs,
            Type clazz,
            EqualsBuilder builder,
            bool useTransients)
        {
            var fields = clazz.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic |
                                         BindingFlags.DeclaredOnly);
            for (var i = 0; i < fields.Length && builder._isEqual; i++)
            {
                var f = fields[i];
                //TODO:atrosin Revise:f.getName().indexOf('$')
                if (f.Name.IndexOf('$') == -1
                    && (useTransients || !IsTransient(f))
                    && !f.IsStatic)
                    try
                    {
                        builder.Append(f.GetValue(lhs), f.GetValue(rhs));
                    }

                    catch (TargetException te)
                    {
                        throw new Exception("Unexpected TargetException", te);
                    }
                    catch (NotSupportedException nse)
                    {
                    }
            }
        }

        public EqualsBuilder AppendSuper(bool superEquals)
        {
            if (_isEqual == false)
                return this;
            _isEqual = superEquals;
            return this;
        }

        public EqualsBuilder Append(object lhs, object rhs)
        {
            if (_isEqual == false)
                return this;
            if (lhs == rhs)
                return this;
            if (lhs == null || rhs == null)
            {
                _isEqual = false;
                return this;
            }
            var lhsClass = lhs.GetType();
            if (!lhsClass.IsArray)
            {
                _isEqual = lhs.Equals(rhs);
            }
            else
            {
                EnsureArraysSameDemention(lhs, rhs);
                if (_isEqual == false)
                    return this;

                if (lhs is long[])
                    Append((long[]) lhs, rhs as long[]);
                else if (lhs is int[])
                    Append((int[]) lhs, rhs as int[]);
                else if (lhs is short[])
                    Append((short[]) lhs, rhs as short[]);
                else if (lhs is char[])
                    Append((char[]) lhs, rhs as char[]);
                else if (lhs is byte[])
                    Append((byte[]) lhs, rhs as byte[]);
                else if (lhs is double[])
                    Append((double[]) lhs, rhs as double[]);
                else if (lhs is float[])
                    Append((float[]) lhs, rhs as float[]);
                else if (lhs is bool[])
                    Append((bool[]) lhs, rhs as bool[]);
                else if (lhs is object[])
                    Append((object[]) lhs, rhs as object[]);
                {
                    // Not an simple array of primitives
                    CompareArrays(lhs, rhs, 0, 0);
                }
            }
            return this;
        }


        private void EnsureArraysSameDemention(object lhs, object rhs)
        {
            var isArray1 = lhs is Array;
            var isArray2 = rhs is Array;

            if (isArray1 != isArray2)
            {
                _isEqual = false;
                return;
            }

            var array1 = (Array) lhs;
            var array2 = (Array) lhs;

            if (array1.Rank != array2.Rank)
                _isEqual = false;

            if (array1.Length != array2.Length)
                _isEqual = false;
        }

        private void CompareArrays(object parray1, object parray2, int prank, int pindex)
        {
            if (_isEqual == false)
                return;
            if (parray1 == parray2)
                return;
            if (parray1 == null || parray2 == null)
            {
                _isEqual = false;
                return;
            }

            var array1 = (Array) parray1;
            var array2 = (Array) parray2;
            var rank1 = array1.Rank;
            var rank2 = array2.Rank;

            if (rank1 != rank2)
            {
                _isEqual = false;
                return;
            }

            var size1 = array1.GetLength(prank);
            var size2 = array2.GetLength(prank);

            if (size1 != size2)
            {
                _isEqual = false;
                return;
            }

            if (prank == rank1 - 1)
            {
                var index = 0;

                var min = pindex;
                var max = min + size1;


                var enumerator1 = array1.GetEnumerator();
                var enumerator2 = array2.GetEnumerator();
                while (enumerator1.MoveNext())
                {
                    if (_isEqual == false)
                        return;
                    enumerator2.MoveNext();


                    if (index >= min && index < max)
                    {
                        var obj1 = enumerator1.Current;
                        var obj2 = enumerator2.Current;

                        var isArray1 = obj1 is Array;
                        var isArray2 = obj2 is Array;

                        if (isArray1 != isArray2)
                        {
                            _isEqual = false;
                            return;
                        }

                        if (isArray1)
                            CompareArrays(obj1, obj2, 0, 0);
                        else
                            Append(obj1, obj2);
                    }

                    index++;
                }
            }
            else
            {
                var mux = 1;

                var currentRank = rank1 - 1;

                do
                {
                    var sizeMux1 = array1.GetLength(currentRank);
                    var sizeMux2 = array2.GetLength(currentRank);

                    if (sizeMux1 != sizeMux2)
                    {
                        _isEqual = false;
                        return;
                    }

                    mux *= sizeMux1;
                    currentRank--;
                } while (currentRank > prank);

                for (var i = 0; i < size1; i++)
                {
                    Console.Write("{ ");
                    CompareArrays(parray1, parray2, prank + 1, pindex + i * mux);
                    Console.Write("} ");
                }
            }
        }


        public EqualsBuilder Append(long lhs, long rhs)
        {
            if (_isEqual == false)
                return this;
            _isEqual = lhs == rhs;
            return this;
        }

        public EqualsBuilder Append(int lhs, int rhs)
        {
            if (_isEqual == false)
                return this;
            _isEqual = lhs == rhs;
            return this;
        }

        public EqualsBuilder Append(short lhs, short rhs)
        {
            if (_isEqual == false)
                return this;
            _isEqual = lhs == rhs;
            return this;
        }

        public EqualsBuilder Append(char lhs, char rhs)
        {
            if (_isEqual == false)
                return this;
            _isEqual = lhs == rhs;
            return this;
        }

        public EqualsBuilder Append(DateTime lhs, DateTime rhs)
        {
            var diff = lhs.Subtract(rhs).Seconds;
            _isEqual = Math.Abs(diff) == 0;
            return this;
        }

        public EqualsBuilder Append(byte lhs, byte rhs)
        {
            if (_isEqual == false)
                return this;
            _isEqual = lhs == rhs;
            return this;
        }

        public EqualsBuilder Append(double lhs, double rhs)
        {
            if (_isEqual == false)
                return this;

            return Append(BitConverter.DoubleToInt64Bits(lhs), BitConverter.DoubleToInt64Bits(rhs));
        }

        public EqualsBuilder Append(double lhs, double rhs, double epsilon)
        {
            if (_isEqual == false)
                return this;
            _isEqual = MathUtil.DoubleEqualTo(lhs, rhs, epsilon);
            return this;
        }

        public EqualsBuilder Append(float lhs, float rhs)
        {
            if (_isEqual == false)
                return this;
            return Append(
                BitConverterUtil.SingleToInt32Bits(lhs),
                BitConverterUtil.SingleToInt32Bits(rhs));
        }

        public EqualsBuilder Append(float lhs, float rhs, float epsilon)
        {
            if (_isEqual == false)
                return this;
            _isEqual = MathUtil.FloatEqualTo(lhs, rhs, epsilon);
            return this;
        }

        public EqualsBuilder Append(bool lhs, bool rhs)
        {
            if (_isEqual == false)
                return this;
            _isEqual = lhs == rhs;
            return this;
        }

        public EqualsBuilder Append(object[] lhs, object[] rhs)
        {
            if (_isEqual == false)
                return this;
            if (lhs == rhs)
                return this;
            if (lhs == null || rhs == null)
            {
                _isEqual = false;
                return this;
            }
            if (lhs.Length != rhs.Length)
            {
                _isEqual = false;
                return this;
            }
            for (var i = 0; i < lhs.Length && _isEqual; ++i)
            {
                if (lhs[i] != null)
                {
                    var lhsClass = lhs[i].GetType();
                    if (!lhsClass.IsInstanceOfType(rhs[i]))
                    {
                        _isEqual = false; 
                        break;
                    }
                }
                Append(lhs[i], rhs[i]);
            }
            return this;
        }

        public EqualsBuilder Append(long[] lhs, long[] rhs)
        {
            if (_isEqual == false)
                return this;
            if (lhs == rhs)
                return this;
            if (lhs == null || rhs == null)
            {
                _isEqual = false;
                return this;
            }
            if (lhs.Length != rhs.Length)
            {
                _isEqual = false;
                return this;
            }
            for (var i = 0; i < lhs.Length && _isEqual; ++i)
                Append(lhs[i], rhs[i]);
            return this;
        }

        public EqualsBuilder Append(int[] lhs, int[] rhs)
        {
            if (_isEqual == false)
                return this;
            if (lhs == rhs)
                return this;
            if (lhs == null || rhs == null)
            {
                _isEqual = false;
                return this;
            }
            if (lhs.Length != rhs.Length)
            {
                _isEqual = false;
                return this;
            }
            for (var i = 0; i < lhs.Length && _isEqual; ++i)
                Append(lhs[i], rhs[i]);
            return this;
        }

        public EqualsBuilder Append(short[] lhs, short[] rhs)
        {
            if (_isEqual == false)
                return this;
            if (lhs == rhs)
                return this;
            if (lhs == null || rhs == null)
            {
                _isEqual = false;
                return this;
            }
            if (lhs.Length != rhs.Length)
            {
                _isEqual = false;
                return this;
            }
            for (var i = 0; i < lhs.Length && _isEqual; ++i)
                Append(lhs[i], rhs[i]);
            return this;
        }

        public EqualsBuilder Append(char[] lhs, char[] rhs)
        {
            if (_isEqual == false)
                return this;
            if (lhs == rhs)
                return this;
            if (lhs == null || rhs == null)
            {
                _isEqual = false;
                return this;
            }
            if (lhs.Length != rhs.Length)
            {
                _isEqual = false;
                return this;
            }
            for (var i = 0; i < lhs.Length && _isEqual; ++i)
                Append(lhs[i], rhs[i]);
            return this;
        }

        public EqualsBuilder Append(byte[] lhs, byte[] rhs)
        {
            if (_isEqual == false)
                return this;
            if (lhs == rhs)
                return this;
            if (lhs == null || rhs == null)
            {
                _isEqual = false;
                return this;
            }
            if (lhs.Length != rhs.Length)
            {
                _isEqual = false;
                return this;
            }
            for (var i = 0; i < lhs.Length && _isEqual; ++i)
                Append(lhs[i], rhs[i]);
            return this;
        }

        public EqualsBuilder Append(double[] lhs, double[] rhs)
        {
            if (_isEqual == false)
                return this;
            if (lhs == rhs)
                return this;
            if (lhs == null || rhs == null)
            {
                _isEqual = false;
                return this;
            }
            if (lhs.Length != rhs.Length)
            {
                _isEqual = false;
                return this;
            }
            for (var i = 0; i < lhs.Length && _isEqual; ++i)
                Append(lhs[i], rhs[i]);
            return this;
        }

        public EqualsBuilder Append(float[] lhs, float[] rhs)
        {
            if (_isEqual == false)
                return this;
            if (lhs == rhs)
                return this;
            if (lhs == null || rhs == null)
            {
                _isEqual = false;
                return this;
            }
            if (lhs.Length != rhs.Length)
            {
                _isEqual = false;
                return this;
            }
            for (var i = 0; i < lhs.Length && _isEqual; ++i)
                Append(lhs[i], rhs[i]);
            return this;
        }

        public EqualsBuilder Append(bool[] lhs, bool[] rhs)
        {
            if (_isEqual == false)
                return this;
            if (lhs == rhs)
                return this;
            if (lhs == null || rhs == null)
            {
                _isEqual = false;
                return this;
            }
            if (lhs.Length != rhs.Length)
            {
                _isEqual = false;
                return this;
            }
            for (var i = 0; i < lhs.Length && _isEqual; ++i)
                Append(lhs[i], rhs[i]);
            return this;
        }

        public bool IsEquals()
        {
            return _isEqual;
        }


        private static bool IsTransient(FieldInfo fieldInfo)
        {
            return (fieldInfo.Attributes & FieldAttributes.NotSerialized) == FieldAttributes.NotSerialized;
        }
    }
}