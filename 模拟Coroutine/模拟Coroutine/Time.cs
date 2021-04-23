using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 模拟Coroutine
{
     class Time
    {
        //每帧，毫秒 20ms
        public static int deltaMilliseconds
        {
            get { return 20; }
        }
        //每帧，秒 0.02s
        public static float deltaTime
        {
            get
            {
                return (float)deltaMilliseconds / 1000;
            }
        }
    }
}
