using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

// 전체적으로 연산부분이 곂치는 부분이 많음 이를 나누고 묶는 독립성과 응집도에 대한 다듬음이 필요한코드
// 아마 굳이 Exception 을상속하지 않는다면 PMath에 반복적인 연산을 묶고 이를 가지고 one, two, three 를 상속받거나
// one -> two -> three 과정으로 상속받는 편이 나았을 코드

namespace test01
{
    enum Arithmetic { Add = 1, Sub = 2, Mul = 3, Div = 4 }
    enum Choose { One = 1, Two, Three }
    class PMath
    {
        int x = 0, y = 0;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        public int Add(out char ari)
        {
            ari = '+';
            return x + y;
        }
        public int Sub(out char ari)
        {
            ari = '-';
            return x - y;
        }
        public int Mul(out char ari)
        {
            ari = '*';
            return x * y;
        }
        public int Div(out char ari)
        {
            ari = '/';
            return x / y;
        }

        public int Make(Choose choose, out char ari)     //자릿수를 결정하기 위한 choose형 및 연산자를 확인하기위한 ari
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            int temp = 0;
            switch (choose)
            {
                case Choose.One:
                    X = random.Next(1, 10);
                    Y = random.Next(1, 10);
                    break;
                case Choose.Two:
                    X = random.Next(10, 100);
                    Y = random.Next(10, 100);
                    break;
                case Choose.Three:
                    X = random.Next(100, 1000);
                    Y = random.Next(100, 1000);
                    break;
            }
            ari = ' ';
            int arithmetic = random.Next(1, 5); //1~5 연산자
            switch (arithmetic)
            {
                case (int)Arithmetic.Add: temp = this.Add(out ari); ari = '+'; break;
                case (int)Arithmetic.Sub: temp = this.Sub(out ari); ari = '-'; break;
                case (int)Arithmetic.Mul: temp = this.Mul(out ari); ari = '*'; break;
                case (int)Arithmetic.Div: temp = this.Div(out ari); ari = '/'; break;
            }
            return temp;
        }
    }
}