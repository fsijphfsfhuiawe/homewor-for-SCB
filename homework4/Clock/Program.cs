//谁是事件的产生者和接收者，不要混乱，理清逻辑，联系现实
//闹钟：嘀嗒事件，响铃事件，显示的信息（当前时间），获取闹铃的时间
//在闹钟里不要写起床之类的事件

//事件拥有者：闹钟
//闹钟其他：嘀嗒，显示当前时间，获取和设置闹铃时间
//事件：响铃并吵到同学
//事件响应者：同学
//事件处理器：同学关闹钟或（并）立刻起床

/*
 * 前置代码：声明同学和闹钟类
 * 声明通知信息类（继承eventargs）
 * 事件约束器
 * 闹钟的响铃事件（声明在闹钟类体里）
 * 声明同学的“关闹钟”或“起床方法”
 */

using System;
using System.Threading;

namespace Clock
{
    
    //通知信息类
    public class RingEventArgs : EventArgs
    {
        public int ringingTime { get; set; }
    }
    //事件约束条件
    public delegate void RingEventHandler(Clock c, RingEventArgs e);



    //时钟类
    public class Clock
    {
        int TimeNow = 0;
        //时钟设置闹铃时间
        public int ringTime { get; set; }
        //时钟闹铃的方法
        private RingEventHandler ringEventHandler;
        public event RingEventHandler Ring
        {
            //当挂载处理器时，将处理器方法装进委托
            add { this.ringEventHandler += value; }
            //当取消挂载处理器时，把处理器方法从委托中移除
            remove { this.ringEventHandler -= value; }
        }

        //事件
        public void Run(Student student)
        {
            while (TimeNow <= 24)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Clock Time: {0} o'clock", TimeNow);

                //时钟嘀嗒的方法
                if (TimeNow == 12)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Tick! It's 12 o'clock now.");
                }

                //响铃事件的发生
                if(TimeNow == ringTime)
                {
                    if (student.isSleepy)
                    {
                            
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Clock Ringing at {0}: Has been delayed.",TimeNow);
                        ringTime++;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(":Just a little more sleep...");
                        student.isSleepy = false;
                    }
                    else
                    {
                        RingEventArgs e = new RingEventArgs();
                        e.ringingTime = ringTime;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Clock Ringing at {0}: Has been closed.",e.ringingTime);
                        ringEventHandler.Invoke(this, e);
                    }
                }

                TimeNow++;
                Thread.Sleep(500);
            }
        }


    }

    //同学类
    public class Student
    {
        public bool isSleepy;

        public Student(bool issleepy)
        {
            this.isSleepy = issleepy;
        }

        //关闹钟
        public void StopRing(Clock c, RingEventArgs eventArgs)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("I'm trying to get out of bed...");
        }
            
    }
class Program
{
    static void Main(string[] args)
    {
        //设置实例
        Student student1 = new Student(true);
        Clock clock1 = new Clock();

        //设置闹铃时间，挂载处理器
        clock1.ringTime = 7;
        clock1.Ring += student1.StopRing;

        //闹钟开始计时，调用事件
        clock1.Run(student1);
        Console.ReadKey();
    }
}
}






