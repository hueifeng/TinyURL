using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TinyURL.Core
{
    public class ShortUrlGenerator
    {
        private static readonly char RandomInsertStr = 'a';
        private static readonly string[] Chars = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z".Split(',');

        public static string Generator(int id)
        {
            var radix = Chars.Length;
            ArrayList arr = new ArrayList();
            var Quotient = +id;
            do
            {
                var mod = Quotient % radix;
                Quotient = (Quotient - mod) / radix;
                arr.Add(Chars[mod]);
            } while (Quotient != 0);

            var codeStr = arr.Cast<object>().Aggregate("", (current, s) => current + s);
            codeStr = codeStr.Length < 6 ? codeStr + RandomInsertStr + RandomWord(5 - codeStr.Length, RandomInsertStr) : codeStr;
            return codeStr;
        }

        private static string RandomWord(int range, char ruledOutStr)
        {
            var str = "";

            char[] Arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            var list = new List<char>(Arr);
            list.Remove(ruledOutStr);

            for (var i = 0; i < range; i++)
            {
                var pos = (int)Math.Round((new Random().NextDouble() * (list.Count - 1)));
                str += list[pos];
            }
            return str;

        }

        public static string MurmurHash3(string url)
        {
            var hasher = new MurmurHash3();
            var bytes = Encoding.UTF8.GetBytes(url);
            var result = hasher.ComputeHash(bytes);
            return string.Concat(Array.ConvertAll(result, x => x.ToString("x2")));
        }

    }
}
