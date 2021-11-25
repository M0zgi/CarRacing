using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRacing
{
    enum CarSpeed
    {
        Low = 190,
        Middle = 240,
        High = 250,
        SuperHigh = 290
    }

    enum BonusSpeed
    {
        Point1 = 15,
        Point2 = 30,
        Point3 = 60,
        Point4 = 120,
    }

    enum DriverExperience
    {
        Junior = 10,
        Middle = 20,
        Senior = 50,
        Lead = 80,
    }

    
    abstract class Car
    {
        public Car(int speed, string name, bool ready) 
        {
            Speed = speed;
            Name = name;
            ReadyRacing = ready;
        }

        public int CarPlace { get; set; }
        public int Speed { get; set; }
        public string Name { get; set; }
        public bool ReadyRacing { get; set; }

        public int Distance { get; set; }

        public virtual string ReadyToStart()
        {
            if (ReadyRacing == true)
                return $"{Name}  - Готов к гонке";

            else
                return $"{Name}  - Не готов к гонке";
        }

        public virtual void Drive(int distance){}
        public virtual void Finish() { }

        public override string ToString()
        {
            return $"{Name} {Speed} {ReadyRacing}"; 
        }
    }

    class RacingCar : Car
    {
        public RacingCar(int speed, string name, bool ready, DriverExperience driver) : base(speed, name, ready)
        {
            //к скорости авто добавляется бонус в виде опыта водителя
            Speed += (int)driver;
        }    
        
        public override void Drive(int distance)
        {
            Distance = distance - Speed / 10;
            if (Distance > 0)
                Console.WriteLine($"{Name} в движении, осталось проехать {Distance} км");

            else
                Finish();
        }

        public override void Finish()
        {
            //фиксируем каким по счету пришел автомобиль
            CarPlace = Game.Place - (Game.GetHandlersCount() - 1);
            //отписываем от собитя ехать (если пришел на финиш)
            Game.Drive -= Drive;            
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{Name} закончил гонку. Занял {CarPlace} место");
            Console.ResetColor();
        }

        public override string ReadyToStart()
        {
            if (ReadyRacing == true)
                return $"{Name}  - Готов к гонке";

            else
                return $"{Name}  - Не готов к гонке";
        }
    }

    class PassengerCar : Car
    {

        public PassengerCar(int speed, string name, bool ready, DriverExperience driver) : base(speed, name, ready)
        {
            //к скорости авто добавляется бонус в виде опыта водителя
            Speed += (int)driver;
        }
        public override void Drive(int distance)
        {
            Distance = distance - Speed / 10;
            if (Distance > 0)
                Console.WriteLine($"{Name} в движении, осталось проехать {Distance} км");

            else
                Finish();
        }

        public override void Finish()
        {
            //фиксируем каким по счету пришел автомобиль
            CarPlace = Game.Place - (Game.GetHandlersCount() - 1);
            //отписываем от собитя ехать (если пришел на финиш)
            Game.Drive -= Drive;
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{Name} закончил гонку. Занял {CarPlace} место");
            Console.ResetColor();
        }

        public override string ReadyToStart()
        {
            if (ReadyRacing == true)
                return $"{Name}  - Готов к гонке";

            else
                return $"{Name}  - Не готов к гонке";
        }
    }

    class Truck : Car
    {
        public Truck(int speed, string name, bool ready, DriverExperience driver) : base(speed, name, ready)
        {
            //к скорости авто добавляется бонус в виде опыта водителя
            Speed += (int)driver;
        }
        public override void Drive(int distance)
        {
            Distance = distance - Speed / 10;
            if (Distance > 0)
                Console.WriteLine($"{Name} в движении, осталось проехать {Distance} км");

            else
                Finish();
        }

        public override void Finish()
        {
            //фиксируем каким по счету пришел автомобиль
            CarPlace = Game.Place - (Game.GetHandlersCount() - 1);
            //отписываем от собитя ехать (если пришел на финиш)
            Game.Drive -= Drive;
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{Name} закончил гонку. Занял {CarPlace} место");
            Console.ResetColor();
        }

        public override string ReadyToStart()
        {
            if (ReadyRacing == true)
                return $"{Name}  - Готов к гонке";

            else
                return $"{Name}  - Не готов к гонке";
        }
    }

    class Bus : Car
    {
        public Bus(int speed, string name, bool ready, DriverExperience driver) : base(speed, name, ready)
        {
            //к скорости авто добавляется бонус в виде опыта водителя
            Speed += (int)driver;
        }
        public override void Drive(int distance)
        {
            Distance = distance - Speed / 10;
            if (Distance > 0)
                Console.WriteLine($"{Name} в движении, осталось проехать {Distance} км");

            else
                Finish();
        }

        public override void Finish()
        {
             //фиксируем каким по счету пришел автомобиль
            CarPlace = Game.Place - (Game.GetHandlersCount() - 1);
            //отписываем от собитя ехать (если пришел на финиш)
            Game.Drive -= Drive; 
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{Name} закончил гонку. Занял {CarPlace} место");
            Console.ResetColor();
        }

        public override string ReadyToStart()
        {
            if (ReadyRacing == true)
                return $"{Name}  - Готов к гонке";

            else
                return $"{Name}  - Не готов к гонке";
        }
    }
}
