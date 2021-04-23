using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 模拟Coroutine
{
    /// <summary>
    /// 用一个链表记录了添加的所有“协程”，并在UpdateCoroutine()方法的每一次执行都去遍历这些“协程”以及检测等待是否结束
    /// </summary>
    class CoroutineManager
    {
        #region 构建懒汉单例
        private static CoroutineManager _instance = null;
        public static CoroutineManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CoroutineManager();
                }
                return _instance;
            }
        }
        #endregion
        //list链表<迭代器>
        private LinkedList<IEnumerator> coroutineList = new LinkedList<IEnumerator>();

        #region 启动某个协程，将他添加至链表尾部
        //启动协程，将ie加到链表末尾
        public void StartCoroutine(IEnumerator ie)
        {
            coroutineList.AddLast(ie);
        }
        #endregion

        #region 停止某个协程，将他从链表里删除
        //停止协程，尝试移除ie
        public void StopCoroutine(IEnumerator ie)
        {
            try
            {
                coroutineList.Remove(ie);
            }
            catch (Exception e) { Console.WriteLine(e.ToString()); }
        }
        #endregion

        #region 对“协程”链表进行遍历
        //遍历协程
        public void UpdateCoroutine()
        {
            //node为根（首）节点
            var node = coroutineList.First;
            //当首节点存在时：
            while (node != null)
            {
                //迭代器ie为节点的Value值
                IEnumerator ie = node.Value;
                //ret记录迭代器是否有下1个元素（true有，false没有）
                bool ret = true;
                //判断ie迭代器的Cur是否为IWait类型
                if (ie.Current is IWait)
                {
                    //定义一个wait变量保存ie迭代器的Cur
                    IWait wait = (IWait)ie.Current;
                    //执行Tick()方法，并检测等待条件，条件满足，跳到迭代器的下一元素 （IEnumerator方法里的下一个yield）
                    if (wait.Tick())
                    {
                        ret = ie.MoveNext();
                    }
                }
                //当前协程内，不是yield return的语句直接执行，并跳向下1条语句
                else
                {
                    ret = ie.MoveNext();
                }
                //迭代器没有下一个元素了，删除迭代器（IEnumerator方法执行结束）
                if (!ret)
                {
                    coroutineList.Remove(node);
                }
                //链表里的下一个"协程"
                node = node.Next;
            }
        }
        #endregion
    }
}
