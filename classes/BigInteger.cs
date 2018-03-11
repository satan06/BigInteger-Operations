using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace std
{
    class BigInteger
    {
        protected internal List<int> items = new List<int>();
        protected internal bool is_negative = false;
        public BigInteger(string str)
        {
            for (int i = str.Length - 1; i >= 0; i--)
            {
                if (str[i] == '-')
                {
                    is_negative = true;
                    break;
                }
                items.Add(int.Parse(str[i].ToString()));
            }
        }
        public BigInteger(List<int> items)
        {
            this.items = items;
        }
        public static BigInteger operator + (BigInteger a_uint, BigInteger b_uint)
        {
            if (((a_uint.items.Count == b_uint.items.Count) && a_uint.BitComparison(b_uint) && a_uint.is_negative)
                || ((a_uint.items.Count > b_uint.items.Count) && a_uint.is_negative && !b_uint.is_negative))
            {
                BigInteger res = a_uint.Substruction(b_uint);
                res.is_negative = true;
                return res;
            }
            else if (((a_uint.items.Count == b_uint.items.Count) && a_uint.BitComparison(b_uint) && b_uint.is_negative)
                || ((a_uint.items.Count > b_uint.items.Count) && b_uint.is_negative && !a_uint.is_negative))
            {
                BigInteger res = a_uint.Substruction(b_uint);
                return res;
            }
            else if (((a_uint.items.Count == b_uint.items.Count) && b_uint.BitComparison(a_uint) && a_uint.is_negative)
                || ((a_uint.items.Count < b_uint.items.Count) && a_uint.is_negative)
                || (a_uint.items.SequenceEqual(b_uint.items) && (a_uint.is_negative || b_uint.is_negative)))
            {
                BigInteger res = b_uint.Substruction(a_uint);
                return res;
            }
            else if (((a_uint.items.Count == b_uint.items.Count) && b_uint.BitComparison(a_uint) && b_uint.is_negative)
                || ((a_uint.items.Count < b_uint.items.Count) && b_uint.is_negative))
            {
                BigInteger res = b_uint.Substruction(a_uint);
                res.is_negative = true;
                return res;
            }
            else if (((a_uint.items.Count == b_uint.items.Count) && (a_uint.BitComparison(b_uint) 
                || b_uint.BitComparison(a_uint)) && a_uint.is_negative && b_uint.is_negative)
                || ((a_uint.items.Count > b_uint.items.Count) && a_uint.is_negative && b_uint.is_negative))
            {
                BigInteger res = a_uint.Addition(b_uint);
                res.is_negative = true;
                return res;
            }
            else
            {
                return a_uint.Addition(b_uint);
            }
        }
        public static BigInteger operator - (BigInteger a_uint, BigInteger b_uint)
        {
            if(((a_uint.items.Count == b_uint.items.Count) && a_uint.BitComparison(b_uint) && a_uint.is_negative)
                || ((a_uint.items.Count < b_uint.items.Count) && a_uint.is_negative)
                || ((a_uint.items.Count > b_uint.items.Count) && a_uint.is_negative)
                || ((a_uint.items.Count == b_uint.items.Count) && b_uint.BitComparison(a_uint) && a_uint.is_negative))
            {
                BigInteger res = a_uint.Addition(b_uint);
                res.is_negative = true;
                return res;
            }
            else if (((a_uint.items.Count == b_uint.items.Count) && b_uint.BitComparison(a_uint) && b_uint.is_negative)
                || ((a_uint.items.Count > b_uint.items.Count) && b_uint.is_negative)
                || ((a_uint.items.Count < b_uint.items.Count) && b_uint.is_negative)
                || ((a_uint.items.Count == b_uint.items.Count) && a_uint.BitComparison(b_uint) && b_uint.is_negative))
            {
                BigInteger res = a_uint.Addition(b_uint);
                return res;
            }
            else if (((a_uint.items.Count == b_uint.items.Count) && a_uint.BitComparison(b_uint) && a_uint.is_negative && b_uint.is_negative)
                || ((a_uint.items.Count > b_uint.items.Count) && b_uint.is_negative && a_uint.is_negative))
            {
                BigInteger res = a_uint.Substruction(b_uint);
                res.is_negative = true;
                return res;
            }
            else
            {
                return a_uint.Substruction(b_uint);
            }
        } 
        public static BigInteger operator * (BigInteger a_uint, BigInteger b_uint)
        {
            if ((a_uint.is_negative && b_uint.is_negative) 
                || (!a_uint.is_negative && !b_uint.is_negative))
            {
                return a_uint.Multiply(b_uint);
            }
            else
            {
                BigInteger res = a_uint.Multiply(b_uint);
                res.is_negative = true;
                return res;
            }
        }
        private BigInteger Addition(BigInteger _uint)
        {
            int tsf = 0, n = Math.Max(items.Count, _uint.items.Count);
            List<int> ans_t = new List<int>();

            for (int i = 0; i < n; i++)
            {
                int a_temp = (items.Count > i) ? items[i] : 0;
                int b_temp = (_uint.items.Count > i) ? _uint.items[i] : 0;

                ans_t.Add(a_temp + b_temp + tsf);
                if (ans_t[i] >= 10)
                {
                    ans_t[i] -= 10;
                    tsf = 1;
                }
                else
                {
                    tsf = 0;
                }
            }
            if (tsf == 1)
            {
                ans_t.Add(tsf);
            }

            return new BigInteger(ans_t);
        }
        private BigInteger Substruction(BigInteger _uint)
        {
            int tsf = 0, n = Math.Max(items.Count, _uint.items.Count);
            List<int> ans_t = new List<int>();

            for (int i = 0; i < n; i++)
            {
                int a_temp = (items.Count > i) ? items[i] : 0;
                int b_temp = (_uint.items.Count > i) ? _uint.items[i] : 0;

                ans_t.Add(a_temp - b_temp - tsf);
                if (ans_t[i] < 0)
                {
                    ans_t[i] += 10;
                    tsf = 1;
                }
                else
                {
                    tsf = 0;
                }
            }
            while (ans_t.Count > 0 && ans_t[ans_t.Count - 1] == 0)
            {
                ans_t.RemoveAt(ans_t.Count - 1);
            }

            return new BigInteger(ans_t);
        }
        private BigInteger Multiply(int _val)
        {
            int tsf = 0;
            List<int> ans_t = new List<int>();

            for(int i = 0; i < items.Count; i++)
            {
                int temp = items[i] * _val + tsf;
                ans_t.Add(temp % 10);
                tsf = (temp / 10);
            }

            ans_t.Add(tsf);

            while (ans_t.Count > 0 && ans_t[ans_t.Count - 1] == 0)
            {
                ans_t.RemoveAt(ans_t.Count - 1);
            }

            return new BigInteger(ans_t);
        }
        private BigInteger Multiply(BigInteger _uint)
        {
            BigInteger res = new BigInteger("0");

            for(int i = 0; i < items.Count; i++)
            {
                BigInteger temp = _uint.Multiply(items[i]);
                for(int j = 0; j < i; j++)
                {
                    temp.items.Insert(0, 0);
                }
                res = res.Addition(temp);
            }
            return res;
        }
        private bool BitComparison(BigInteger _uint)
        {
            for (int i = items.Count - 1; i >= 0; i--)
            {
                int a_temp = items[i];
                int b_temp = _uint.items[i];

                if(a_temp > b_temp)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
