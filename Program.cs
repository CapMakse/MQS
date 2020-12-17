using System;

namespace MQS
{
    class Program
    {
        static void Main(string[] args)
        {
            MultiLevelQueue queue = new MultiLevelQueue();
            queue.AddProcess(new Process(ProcessType.Interactive, 19));
            queue.Dump();
            queue.DoProcess();
            queue.Dump();
            queue.AddProcess(new Process(ProcessType.System, 9));
            queue.AddProcess(new Process(ProcessType.System, 3));
            queue.AddProcess(new Process(ProcessType.System, 12));
            queue.Dump();
            queue.DoProcess();
            queue.Dump();
            queue.DoProcess();
            queue.Dump();
            queue.DoProcess();
            queue.Dump();
            queue.DoProcess();
            queue.Dump();
            queue.DoProcess();
            queue.Dump();
            queue.DoProcess();
            queue.Dump();
            queue.DoProcess();
            queue.Dump();
        }
    }
}
