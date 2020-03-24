using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetIn(new StreamReader(Console.OpenStandardInput(8192)));
            Console.WriteLine("                                                     Welcome To RSA        ");
            Console.WriteLine("                                             -------------------------------");
          
            #region input
            integer integ =new integer();

                Console.WriteLine("Enter The (2) Keys : ");
                Console.Write("(1) => ");
                string M = Console.ReadLine();
                Console.Write("(2) => ");
                string P = Console.ReadLine();
                Console.WriteLine("Enter The Encrypting/Decrypting Number : ");
                Console.Write("=> ");
                string B = Console.ReadLine();
                Console.WriteLine("Enter Type ( 0 => Encrypting ,  1=> Decrypting ) : ");
                Console.Write("=> ");
                string type = Console.ReadLine();
                if (type == "0")
                {
                    integ.input_First_number(M);
                    integ.input_Power(P);
                    integ.input_Second_number(B);
                    List<char> res = integ.Encrypt(integ.Get_Second_Number(), integ.Get_Power(), integ.Get_First_Number());
                    string wr = string.Join("", res);
                    Console.WriteLine("The Encrypted Number : ");
                    Console.Write("=> ");
                    Console.WriteLine(wr);
                }
                else if (type == "1")
                {
                    integ.input_First_number(M);
                    integ.input_Power(P);
                    integ.input_Second_number(B);
                    List<char> res = integ.Decrypt(integ.Get_Second_Number(), integ.Get_Power(), integ.Get_First_Number());
                    string wr = string.Join("", res);
                    Console.WriteLine("The Encrypted Number : ");
                    Console.Write("=> "); 
                    Console.WriteLine(wr);
                }
        }
            #endregion
        }
    }

