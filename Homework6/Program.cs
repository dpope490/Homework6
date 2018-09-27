using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter two integers (numerator and denominator): ");
            int num = int.Parse(Console.ReadLine());
            int denom = int.Parse(Console.ReadLine());
            var rationalOne = new Rational();
            rationalOne.SetFraction(num, denom);
            Console.WriteLine("Enter two more integers: ");
            num = int.Parse(Console.ReadLine());
            denom = int.Parse(Console.ReadLine());
            var rationalTwo = new Rational();
            rationalTwo.SetFraction(num, denom);
            Console.WriteLine("\nHow many digits to you want to display in past the decimal?");
            int digits = int.Parse(Console.ReadLine());

            Console.WriteLine("\nReduced first fraction: ");
            Console.WriteLine($"{rationalOne.ToRationalString()}");
            Console.WriteLine("Reduced second fraction: ");
            Console.WriteLine($"{rationalTwo.ToRationalString()}");

            Console.WriteLine($"Added rational numbers = {Rational.Add(rationalOne.ToFloat(), rationalTwo.ToFloat())}");
            Console.WriteLine($"Subtracted rational numbers =  {Rational.Subtract(rationalOne.ToFloat(), rationalTwo.ToFloat())}");
            Console.WriteLine($"Multiplied rational numbers = {Rational.Multiply(rationalOne.ToFloat(), rationalTwo.ToFloat())}");
            Console.WriteLine($"Divided rational numbers = {Rational.Divide(rationalOne.ToFloat(), rationalTwo.ToFloat())}");

            Console.WriteLine("\nPress any key to end program.");
            Console.ReadKey();
        }
        public class Rational
        {
            private int Numerator;
            private int Denominator;

            public Rational()
            {
                Numerator = 1;
                Denominator = 1;
            }

            public void SetFraction(int num, int denom)
            {
                Numerator = num;
                Denominator = denom;
                reduce(ref Numerator, ref Denominator);
            }

            public static float Add(float num1, float num2)
            {
                return num1 + num2;
            }

            public static float Subtract(float num1, float num2)
            {
                if (num1 > num2)
                {
                    return num1 - num2;
                }
                else
                {
                    return num2 - num1;
                }
            }

            public static float Multiply(float num1, float num2)
            {
                return num1 * num2;
            }

            public static float Divide(float num1, float num2)
            {
                if (num1 > num2)
                {
                    return num1 / num2;
                }
                else
                {
                    return num2 / num1;
                }
            }

            public string ToRationalString() =>
                $"{this.Numerator}/{this.Denominator}";

            public float ToFloat() =>
                (float)Numerator / (float)Denominator;

            /* Computes the Greatest Common Denominator of
            * two positive integers. 
            */
            static int gcd(int n1, int n2)
            {
                if (n2 != 0)
                    return gcd(n2, n1 % n2);
                else
                    return n1;
            }

            /* Reduces a rational number represented by n1/n2
             * by computing the GCD of n1 and n2, then using it
             * to reduce the number to it's lowest form.
            */
            static void reduce(ref int n1, ref int n2)
            {
                int aN1 = n1 < 0 ? -n1 : n1;
                int aN2 = n2 < 0 ? -n2 : n2;

                int gcdNs = gcd(aN1, aN2);
                n1 = n1 / gcdNs;
                n2 = n2 / gcdNs;
            }

            
        }
    }
}
