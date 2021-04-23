using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 模拟Coroutine
{
    //定义等待方式的接口
    public interface IWait
    {
        bool Tick();
    }
}
