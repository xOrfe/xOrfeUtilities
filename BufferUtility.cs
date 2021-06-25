using System.Collections.Generic;
using UnityEngine;

namespace xOrfe.Utilities
{
    public class BufferUtility<T>  where T: struct
    {
        private List<BufferData<T>> bufferDatas = new List<BufferData<T>>();
        public int Count => bufferDatas.Count;

        public int GetNextDatasTick()
        {
            return bufferDatas[0].Tick;
        }
        public int GetNextDatasStep()
        {
            return bufferDatas[0].Step;
        }
        public void Enqueue(T data,int step)
        {
            bufferDatas.Add(new BufferData<T>(data,step));
        }
        public void Enqueue(T data,int step,int tick)
        {
            bufferDatas.Add(new BufferData<T>(data,step,tick));
        }
        public BufferData<T> Dequeue()
        {
            BufferData<T> tmpBufferData = new BufferData<T>(bufferDatas[0].Data,bufferDatas[0].Tick,bufferDatas[0].Step);
            bufferDatas.RemoveAt(0);
            return tmpBufferData;
        }
    }
    public class BufferData<T> where T: struct
    {
        public readonly int Tick;
        public readonly int Step;
        public readonly T Data;
        
        public BufferData(T data,int step)
        {
            Tick = TickUtility.Instance.Tick;
            Step = step;
            Data = data;
        }
        public BufferData(T data,int tick,int step)
        {
            Tick = tick;
            Step = step;
            Data = data;
        }
    }
}
