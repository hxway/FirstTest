using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EVENT_TEST
{
    class Program
    {
        static void Main(string[] args)
        {
            Publisher pub = new Publisher();
            Subscriber sub = new Subscriber();

            pub.NumberChanged += new NumerChangedEventHandler(sub.OnNumerChanged);
            pub.DoSomething();
            pub.NumberChanged(100);


        }
        public delegate void NumerChangedEventHandler(int count);
        public class Publisher
        {
            private int count;
           // public NumerChangedEventHandler NumberChanged; //声明委托变量
           public event NumerChangedEventHandler NumberChanged; 
            // 声明一个事件
            public void DoSomething()
            {
                if (NumberChanged != null)
                {
                    count++;
                    NumberChanged(count);
                }
            }
        }

        public class Subscriber
        {
            public void OnNumerChanged(int count)
            {
                Console.WriteLine("Subscriber notified: count = {0}", count);
            }
        }
    }
}
