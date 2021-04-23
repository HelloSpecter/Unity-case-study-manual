using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 模拟Coroutine
{
    public class WaitForFrames : IWait
    {
        private float _frames = 0f;
        public WaitForFrames(float frames)
        {
            if (frames<0f)
            {
                return;
            }
            this._frames = frames;
        }
        public bool Tick()
        {
            this._frames -= 1;
            //Console.WriteLine("WaitForFrames-_frames-" + this._frames);
            return this._frames <= 0;
        }
    }
}
