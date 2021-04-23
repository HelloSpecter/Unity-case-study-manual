using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 模拟Coroutine
{
    public class WaitForSeconds :IWait
    {
        private float _seconds = 0f;
        public WaitForSeconds(float seconds)
        {
            if (seconds < 0f)
            {
                return;
            }
            this._seconds = seconds;
        }
        public bool Tick()
        {
            this._seconds -= Time.deltaTime;
            //Console.WriteLine("WaitForSeconds-_seconds-" + this._seconds);
            return this._seconds <= 0;
        }
    }
}
