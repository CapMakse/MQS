using System;
using System.Collections.Generic;
using System.Text;

namespace MQS
{
    class MultiLevelQueue
    {
        LinkedList<Process> System = new LinkedList<Process>();
        LinkedList<Process> Interactive = new LinkedList<Process>();
        LinkedList<Process> Batch = new LinkedList<Process>();

        public void AddProcess(Process proc)
        {
            switch (proc.Type)
            {
                case ProcessType.System:
                    System.AddLast(proc);
                    break;
                case ProcessType.Interactive:
                    Interactive.AddLast(proc);
                    break;
                case ProcessType.Batch:
                    Batch.AddLast(proc);
                    break;
                default:
                    break;
            }
        }
        public void DoProcess()
        {
            if(System.Count != 0) 
            {
                Process proc = System.First.Value;
                System.RemoveFirst();
                proc.Time -= 8;
                if (proc.Time > 0) System.AddLast(proc);
            }
            else if(Interactive.Count != 0) 
            {
                Process proc = Interactive.First.Value;
                Interactive.RemoveFirst();
                proc.Time -= 8;
                if (proc.Time > 0) Interactive.AddLast(proc);
            }
            else if(Batch.Count != 0) 
            {
                Batch.First.Value.Time--;
                if (Batch.First.Value.Time == 0) Batch.RemoveFirst();
            }
        }
        public void Dump()
        {
            foreach (var item in System)
            {
                Console.WriteLine("ID - {0}, Type - {1}, Time = {2}", item.ID, item.Type.ToString(), item.Time);
            }
            foreach (var item in Interactive)
            {
                Console.WriteLine("ID - {0}, Type - {1}, Time = {2}", item.ID, item.Type.ToString(), item.Time);
            }
            foreach (var item in Batch)
            {
                Console.WriteLine("ID - {0}, Type - {1}, Time = {2}", item.ID, item.Type.ToString(), item.Time);
            }
            if (System.Count + Interactive.Count + Batch.Count == 0) Console.WriteLine("Empty");
            Console.WriteLine();
        }
    }
    class Process
    {
        static int IDCounter = 0;
        public Process(ProcessType type, int time)
        {
            Type = type;
            Time = time;
            IDCounter++;
            ID = IDCounter;
        }
        public ProcessType Type { get; }
        public int Time { get; set; }
        public int ID { get; }
    }
    enum ProcessType
    {
        System,
        Interactive,
        Batch
    }
}
