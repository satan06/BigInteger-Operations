using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace std
{
    class BigIntegerFraction
    {
        protected internal BigInteger numerator;
        protected internal BigInteger denominator;
        public BigIntegerFraction(BigInteger numerator, BigInteger denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;

            if((numerator.is_negative && denominator.is_negative)
                || (!numerator.is_negative && !denominator.is_negative))
            {
                numerator.is_negative = false;
                denominator.is_negative = false;
            }
            else
            {
                numerator.is_negative = true;
                denominator.is_negative = false;
            }
        }
        public BigIntegerFraction(string str)
        {
            char delimiter = '/';
            string[] substrings = str.Split(delimiter);

            this.numerator = new BigInteger(substrings[0]);
            this.denominator = new BigInteger(substrings[1]);

            if ((numerator.is_negative && denominator.is_negative)
                 || (!numerator.is_negative && !denominator.is_negative))
            {
                numerator.is_negative = false;
                denominator.is_negative = false;
            }
            else
            {
                numerator.is_negative = true;
                denominator.is_negative = false;
            }
        }
        public static BigIntegerFraction operator + (BigIntegerFraction a_fraction, BigIntegerFraction b_fraction)
        {
            if (a_fraction.denominator.items.SequenceEqual(b_fraction.denominator.items))
            {
                BigInteger common_denominator = a_fraction.denominator;
                BigInteger result_numerator = a_fraction.numerator + b_fraction.numerator;

                return new BigIntegerFraction(result_numerator, common_denominator);
            }
            else
            {
                BigInteger common_denominator = a_fraction.denominator * b_fraction.denominator;
                BigInteger result_numerator = a_fraction.numerator + b_fraction.numerator;

                return new BigIntegerFraction(result_numerator, common_denominator);
            }
        }
        public static BigIntegerFraction operator - (BigIntegerFraction a_fraction, BigIntegerFraction b_fraction)
        {
            if (a_fraction.denominator.items.SequenceEqual(b_fraction.denominator.items))
            {
                BigInteger common_denominator = a_fraction.denominator;
                BigInteger result_numerator = a_fraction.numerator - b_fraction.numerator;

                return new BigIntegerFraction(result_numerator, common_denominator);
            }
            else
            {
                BigInteger common_denominator = a_fraction.denominator * b_fraction.denominator;
                BigInteger result_numerator = a_fraction.numerator - b_fraction.numerator;

                return new BigIntegerFraction(result_numerator, common_denominator);
            }
        }
        public static BigIntegerFraction operator * (BigIntegerFraction a_fraction, BigIntegerFraction b_fraction)
        {
            BigInteger common_denominator = a_fraction.denominator * b_fraction.denominator;
            BigInteger result_numerator = a_fraction.numerator * b_fraction.numerator;

            return new BigIntegerFraction(result_numerator, common_denominator);
        }
    }
}
