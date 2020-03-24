using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA
{
    class integer
    {
        #region Vars
        public struct strc
        {
            public List<long> q;
            public List<long> r;
        }
        private long f, s;
        public List<char> lis = new List<char>();
        public List<long> f_number = new List<long>();
        public List<long> s_number = new List<long>();
        public List<long> power = new List<long>();
        private bool is_string = false;
        #endregion

        #region Input
        public void input_Second_number(string number)
        {
            string inp;
            inp = number;
            //f_number = new List<long>();
            List<char> num = inp.ToList<char>();
            long count = num.Count;
            for (int i = 0; i < count; i++) { 
            if (inp[i] > 57)
            {
                is_string = true;
                break;
            }
        }
            for (int i = 0; i < count; i++)
            {
                if (inp[i] > 57)
                {
                    f = (int)num[i] - 48;
                    s = f % 10;
                    f /= 10;
                    if (f > 0)
                        s_number.Add(f);
                    else
                        if (i < count - 1)
                            s_number.Add(0);
                    s_number.Add(s);
                }

                else
                {
                    s_number.Add((int)num[i] - 48);
                }
            }
        }
        public void input_First_number(string number)
        {
            string inp;
            inp = number;
            // s_number = new List<long>();
            List<char> num = new List<char>(inp.ToList<char>());
            int count1 = inp.Count<char>();
            long count = num.Count;
            for (int i = 0; i < count; i++)
            {
                f_number.Add((int)num[i] - 48);

            }
        }
        public void input_Power(string number)
        {
            string inp;
            inp = number;
            //      power = new List<long>();
            List<char> num = new List<char>(inp.ToList<char>());
            int count1 = inp.Count<char>();
            long count = num.Count;
            for (int i = 0; i < count; i++)
            {
                power.Add((int)num[i] - 48);

            }
        }
        #endregion

        #region Print
        public void print_First_number()
        {
            string print = String.Join("", f_number);
            Console.WriteLine(print);
        }
        public void print_Second_number()
        {
            string print = String.Join("", s_number);
            Console.WriteLine(print);
        }
        #endregion

        #region Get
        public List<long> Get_First_Number()
        {
            return f_number;
        }

        public List<long> Get_Second_Number()
        {
            return s_number;
        }

        public List<long> Get_Power()
        {
            return power;
        }
        #endregion

        #region Subtraction
        public List<long> Subtraction(List<long> first, List<long> second)//o(n)
        {
            List<long> R_list = new List<long>();
            List<long> assistant = new List<long>();

            if (first.Count >= second.Count)
            {
                R_list = new List<long>(first);
                assistant = new List<long>(second);
            }

            else if (first.Count < second.Count)
            {
                R_list = new List<long>(second);
                assistant = new List<long>(first);
            }

            long big = R_list.Count;
            long small = assistant.Count;
            assistant.Reverse();
            for (int i = 0; i < (big - small); i++)
            {
                assistant.Add(0);
            }
            assistant.Reverse();
            small = big;
            List<long> bigger = new List<long>();
            List<long> smaller = new List<long>();
            int count = 0;
            while (count <= big - 1)
            {

                if (R_list[count] > assistant[count])
                {
                    bigger = new List<long>(R_list);
                    smaller = new List<long>(assistant);
                    break;
                }
                else if ((R_list[count] < assistant[count]))
                {
                    smaller = new List<long>(R_list);
                    bigger = new List<long>(assistant);
                    break;
                }
                count++;
            }
            if (count == big)
            {
                bigger.Add(0);
                return bigger;
            }


            for (int i = (int)big - 1; i >= 0; i--)
            {
                if (bigger[i] >= smaller[i])
                    bigger[i] -= smaller[i];
                else
                {
                    bigger[i - 1] -= 1;
                    bigger[i] += 10;
                    bigger[i] -= smaller[i];
                }
            }

            #region DeleteAdditionZeros
            int zero_count = 0;
            for (int i = 0; i < bigger.Count; i++)
                if (bigger[i] == 0)
                    zero_count++;
                else
                    break;
            List<long> ret_list = new List<long>();
            for (int i = zero_count; i < bigger.Count; i++)
                ret_list.Add(bigger[i]);
            bigger = ret_list;

            #endregion
            return bigger;
        }
        #endregion

        #region Addition
        public List<long> add(List<long> first, List<long> second)
        {
            long sum = 0;
            List<long> res = new List<long>();
            List<long> num1 = new List<long>(first);
            List<long> num2 = new List<long>(second);

            num1.Reverse();
            num2.Reverse();
            if (num1.Count < num2.Count)
            {
                List<long> temp = num1;
                num1 = num2;
                num2 = temp;
            }
            if (num1.Count >= num2.Count)
            {

                long carry = 0;
                int count2 = num2.Count;
                for (int i = 0; i < count2; i++)
                {
                    sum = num1[i] + num2[i] + carry;
                    res.Add(sum % 10);
                    carry = sum / 10;
                }
                if (num1.Count > num2.Count)
                    count2 = num2.Count;
                int count1 = num1.Count;
                for (int i = count2; i < count1; i++)
                {
                    sum = num1[i] + carry;
                    res.Add(sum % 10);
                    carry = sum / 10;
                }
                if (carry > 0)
                    res.Add(carry);
                res.Reverse();
            }
            return res;
        }
        #endregion

        #region Multiplication
        public List<long> innerMult(List<long> first, List<long> second, long len)
        {
            if (first.Count > 5 || second.Count > 5)
            {

                #region EvenAndEqual
                long max_loop = 0;
                if (len % 2 != 0)
                {
                    first.Reverse();
                    second.Reverse();
                    first.Add(0);
                    second.Add(0);
                    first.Reverse();
                    second.Reverse();
                    len += 1;
                }
                if (first.Count > second.Count)
                {
                    max_loop = second.Count;
                    long fcount = first.Count;
                    second.Reverse();
                    while (fcount > max_loop)
                    {
                        second.Add(0);
                        max_loop++;
                    }
                    second.Reverse();
                }
                else if (first.Count < second.Count)
                {
                    max_loop = first.Count;
                    long scount = second.Count;
                    first.Reverse();
                    while (max_loop < scount)
                    {
                        first.Add(0);
                        max_loop++;
                    }
                    first.Reverse();
                }
                /////////////////////////////////////////////////////// make odd ->even
                #endregion

                List<long> a = new List<long>();
                List<long> b = new List<long>();
                List<long> c = new List<long>();
                List<long> d = new List<long>();
                long f_count = 0;
                long s_count = 0;
                for (int i = (int)len / 2; i < len; i++)
                {
                    f_count += 1;
                    a.Add(first[i]);
                    c.Add(second[i]);
                }

                for (int i = 0; i < len / 2; i++)
                {
                    s_count += 1;
                    b.Add(first[i]);
                    d.Add(second[i]);
                }

                List<long> ac = innerMult(a, c, f_count);
                List<long> bd = innerMult(b, d, s_count);
                List<long> add_ab = add(a, b);
                List<long> add_cd = add(c, d);
                if (s_count > f_count)
                    max_loop = s_count;
                else
                    max_loop = f_count;

                int max = add_ab.Count;
                if (add_ab.Count > add_cd.Count)
                    max = add_ab.Count;
                else if (add_ab.Count < add_cd.Count)
                    max = add_cd.Count;
                List<long> z = innerMult(add_ab, add_cd, max);
                List<long> sub_zac = Subtraction(z, ac);
                List<long> sub_zacbd = Subtraction(sub_zac, bd);

                for (int i = 0; i < max_loop; i++)
                    sub_zacbd.Add(0);
                for (int i = 0; i < len; i++)
                    bd.Add(0);
                List<long> added = add(add(bd, sub_zacbd), ac);
                return added;
            }
            else
            {
                long total1 = 0;
                foreach (int entry in first)
                {
                    total1 = 10 * total1 + entry;
                }
                long total2 = 0;
                foreach (int entry in second)
                {
                    total2 = 10 * total2 + entry;
                }
                total1 *= total2;
                List<long> ret = new List<long>();
                if (total1 == 0)
                {
                    ret.Add(0);
                }
                while (total1 > 0)
                {
                    ret.Add(total1 % 10);
                    total1 /= 10;
                }
                ret.Reverse();
                return ret;
            }
        }

        public List<long> Multiplication(List<long> first, List<long> second)
        {
            int max = 0;
            if (first.Count > second.Count)
                max = first.Count;
            else
                max = second.Count;
            List<long> list = innerMult(first, second, max);
            int added_Count = list.Count, zero_count = 0;
            for (int i = 0; i < added_Count; i++)
                if (list[i] == 0)
                    zero_count++;
                else
                    break;
            List<long> ret_list = new List<long>();
            for (int i = zero_count; i < added_Count; i++)
                ret_list.Add(list[i]);

            return ret_list;
        }
        #endregion

        #region Divide
        public strc div(List<long> a, List<long> b)
        {
            #region ShowBigger
            bool first = false, second = false;
            if (a.Count > b.Count)
            {
                first = true;
                second = false;
            }


            else if (a.Count < b.Count)
            {
                first = false;
                second = true;
            }


            else if (a.Count == b.Count)
            {
                int i = 0;
                while (i <= a.Count - 1)
                {

                    if (a[i] < b[i])
                    {
                        first = false;
                        second = true;
                        break;
                    }
                    else if ((a[i] > b[i]))
                    {
                        first = true;
                        second = false;
                        break;
                    }
                    i++;
                }
            }
            #endregion

            if (second)
                return new strc() { q = new List<long>() { 0 }, r = a };
            List<long> ass = new List<long>(b);
            List<long> mul = add(ass, b);
            strc st = div(a, mul);
            List<long> f = new List<long>(st.q);
            List<long> s = new List<long>(st.q);
            st.q = add(f, s);

            #region DeleteAdditionBits
            List<long> temp = new List<long>();
            int zeros = 0;
            for (int i = 0; i < st.r.Count; i++)
                if (st.r[i] == 0)
                    zeros++;
                else
                    break;
            for (int i = zeros; i < st.r.Count; i++)
                temp.Add(st.r[i]);
            st.r = temp;
            #endregion

            #region ShowBigger
            first = false;
            second = false;
            if (st.r.Count > b.Count)
            {
                first = true;
                second = false;
            }


            else if (st.r.Count < b.Count)
            {
                first = false;
                second = true;
            }


            else if (st.r.Count == b.Count)
            {
                int i = 0;
                while (i <= st.r.Count - 1)
                {

                    if (st.r[i] < b[i])
                    {
                        first = false;
                        second = true;
                        break;
                    }
                    else if ((st.r[i] > b[i]))
                    {
                        first = true;
                        second = false;
                        break;
                    }
                    i++;
                }
            }
            #endregion

            if (second)
                return st;
            else
            {
                st.q = add(new List<long>() { 1 }, st.q);
                st.r = Subtraction(st.r, b);
                return st;
            }
        }

        #endregion

        #region Mod
        public List<long> Mod(List<long> B, List<long> P, List<long> M)
        {
            if ((P.Count == 1 && P[P.Count - 1] > 1) || P.Count > 1)
            {
                List<long> d = div(P, new List<long>() { 2 }).q;
                if (P[P.Count - 1] % 2 == 0)
                {
                    List<long> mod = Mod(B, d, M);
                    List<long> temp = new List<long>(mod);
                    List<long> ml = Multiplication(temp, mod);
                    List<long> ret_mod = div(ml, M).r;

                    #region DeleteAdditionZeros
                    int zero_count = 0;
                    for (int i = 0; i < ret_mod.Count; i++)
                        if (ret_mod[i] == 0)
                            zero_count++;
                        else
                            break;
                    List<long> ret_list = new List<long>();
                    for (int i = zero_count; i < ret_mod.Count; i++)
                        ret_list.Add(ret_mod[i]);
                    ret_mod = ret_list;

                    #endregion

                    return ret_mod;
                }
                else
                {
                    List<long> mod2 = Mod(B, d, M);
                    List<long> temp = new List<long>(mod2);
                    List<long> ml2 = Multiplication(temp, mod2);
                    List<long> mod3 = div(B, M).r;

                    #region DeleteAdditionZeros
                    int zero_count = 0;
                    for (int i = 0; i < mod3.Count; i++)
                        if (mod3[i] == 0)
                            zero_count++;
                        else
                            break;
                    List<long> ret_list = new List<long>();
                    for (int i = zero_count; i < mod3.Count; i++)
                        ret_list.Add(mod3[i]);
                    mod3 = ret_list;

                    #endregion

                    List<long> ml3 = Multiplication(ml2, mod3);
                    List<long> ret_mod2 = div(ml3, M).r;

                    #region DeleteAdditionZeros
                    zero_count = 0;
                    for (int i = 0; i < ret_mod2.Count; i++)
                        if (ret_mod2[i] == 0)
                            zero_count++;
                        else
                            break;
                    ret_list = new List<long>();
                    for (int i = zero_count; i < ret_mod2.Count; i++)
                        ret_list.Add(ret_mod2[i]);
                    ret_mod2 = ret_list;

                    #endregion

                    return ret_mod2;
                }
            }
            else
                return B;
        }
        #endregion

        #region Encrypt
        public List<char> Encrypt(List<long> B, List<long> P, List<long> M)
        {
            B = Mod(B, P, M);
            long count = B.Count;
            bool odd = false;

            for (int i = 0; i < count; i++)
            {
                if (is_string && (i != count - 1))
                {
                    f = B[i];
                    f *= 10;
                    f += B[i + 1];
                    if ((f >= 10 && f <= 78))
                    {
                        lis.Add((char)(f + 48));
                        i++;
                        continue;
                    }
                }

                lis.Add((char)(B[i] + 48));
            }

            is_string = false;
            return lis;
        }


        #endregion

        #region Decrypt
        public List<char> Decrypt(List<long> B, List<long> P, List<long> M)
        {
            B = Mod(B, P, M);
            long count = B.Count;
            bool odd = false;

            for (int i = 0; i < count; i++)
            {
                if (is_string && (i != count - 1))
                {
                    f = B[i];
                    f *= 10;
                    f += B[i + 1];
                    if ((f >= 10 && f <= 78))
                    {
                        lis.Add((char)(f + 48));
                        i++;
                        continue;
                    }
                }

                lis.Add((char)(B[i] + 48));
            }

            is_string = false;
            return lis;
        }



        #endregion 
    }
}
