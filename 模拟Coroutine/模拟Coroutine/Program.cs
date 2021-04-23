using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 模拟Coroutine
{
    class Program
    {
        static void Main(string[] args)
        {
            var t1 = Test01();
            var t2 = Test02();
            CoroutineManager.Instance.StartCoroutine(t1);
            CoroutineManager.Instance.StartCoroutine(t2);

            while (true)// 模拟update
            {
                //每0.02s执行1次Upda
                Thread.Sleep(Time.deltaMilliseconds);
                CoroutineManager.Instance.UpdateCoroutine();
            }
        }
        static IEnumerator Test01()
        {
            Console.WriteLine("start test 01");
            yield return new WaitForSeconds(5);
            Console.WriteLine("\n---------------------after 5 seconds---------------------\n");
            yield return new WaitForSeconds(5);
            Console.WriteLine("\n---------------------after 5 seconds---------------------\n");
        }

        static IEnumerator Test02()
        {
            Console.WriteLine("start test 02");
            yield return new WaitForFrames(500);
            Console.WriteLine("\n---------------------after 500 frames--------------------\n");
        }

    }
}
