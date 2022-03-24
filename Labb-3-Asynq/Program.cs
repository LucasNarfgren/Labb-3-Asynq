using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Labb_3_Asynq
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Racet har börjat!");
            StartRace();
        }

        public static async void StartRace()
        {
            Task<int> racer1 = Car1(new Bil { Id = 1, Name = "Volvo", Speed = 120 });
            Car2(new Bil { Id = 2, Name = "Saab", Speed = 120 });
            List<string> failure = new List<string>();



            //int count = await racer1;
        }

        public static async Task<int> Car1(Bil bil)
        {

            int count = 0;
            await Task.Run(() =>
            {
                int ran = 0;
                int seconds = 0;
                int Length = 0;
                for (int i = 0; i < 12000; i += bil.Speed)
                {
                    Console.WriteLine($"{bil.Name} " + i + " " + seconds);
                    Task.Delay(1000).Wait();
                    Length += bil.Speed;
                    

                    if (seconds == 10)
                    {
                        Random r1 = new Random();
                        ran = r1.Next(1, 5);
                        seconds = 0;
                    }


                    if (Length >= 12000)
                    {
                        Console.WriteLine($"{bil.Name} bilen har gått i mål.");
                        break;
                    }

                    if (ran == 1)
                    {
                        OutofGas(bil);
                    }
                    if (ran == 2)
                    {
                        FlatTire(bil);
                    }
                    if (ran == 3)
                    {
                        BirdOnWindshield(bil);
                    }
                    if (ran == 4)
                    {
                        EngineFailure(bil);
                    }
                    seconds++;
                    ran = 0;
                }

            });
            return count;

        }

        public static async void Car2(Bil bil)
        {
            int ran = 0;
            int seconds = 0;
            int length = 0;
            for (int i = 0; i < 12000; i += bil.Speed)
            {
                Console.WriteLine($"{bil.Name} " + i);
                Task.Delay(1000).Wait();
                length += bil.Speed;

                if (length >= 12000)
                {
                    Console.WriteLine($"{bil.Name} bilen har gått i mål.");
                    break;
                }


                if (seconds == 10)
                {
                    Random r2 = new Random();
                    ran = r2.Next(1, 5);
                    seconds = 0;
                }
                if (ran == 1)
                {
                    OutofGas(bil);
                }
                if (ran == 2)
                {
                    FlatTire(bil);
                }
                if (ran == 3)
                {
                    BirdOnWindshield(bil);
                }
                if (ran == 4)
                {
                    EngineFailure(bil);
                }
                seconds++;
                ran = 0;
            }

        }


        public static void OutofGas(Bil bil)
        {
            Random r1 = new Random();
            int num = r1.Next(1, 50);

            //if (num == 5)
            //{
            Console.WriteLine($"{bil.Name} ran out of gas.");
            Task.Delay(30000).Wait();
            //}

        }
        public static void FlatTire(Bil bil)
        {
            Random r1 = new Random();
            int num = r1.Next(1, 25);

            //if (num == 5)
            //{
            Console.WriteLine($"{bil.Name} got a flat tire.");
            Task.Delay(20000).Wait();
            //}

        }
        public static void BirdOnWindshield(Bil bil)
        {
            Random r1 = new Random();
            int num = r1.Next(1, 10);
            //if (num == 5)
            //{
            Console.WriteLine($"{bil.Name} got hit by a bird.");
            Task.Delay(10000).Wait();
            //}

        }
        public static void EngineFailure(Bil bil)
        {
            Random r1 = new Random();
            int num = r1.Next(1, 6);
            //if (num == 5)
            //{
            Console.WriteLine($"{bil.Name} is having an engine failure.");
            Task.Delay(1000);
            bil.Speed--;
            //}
        }
    }
}
