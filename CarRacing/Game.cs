using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRacing
{

    delegate void DriveDelegate(int distance);

    class Game
    {
        static public int Distance { get; set; }

        public static int GetHandlersCount()
        {
            var eventHandler = Drive;
            if (eventHandler != null)
                return eventHandler.GetInvocationList().Length;
            else return 0;
        }

        static public int Place { get; set; }

        static Game()
        {
            Distance = 100;
        }

        public static event DriveDelegate Drive;
        public static void CarDrive(int distance)
        {
            if (Drive != null)
                Drive(distance);
        }

        static public string PrintAllCars(Car car)
        {
            return $"{car.Name} {car.Speed} {car.ReadyRacing}";
        }

        static public string PrintReadyRacingCars(Car car)
        {
            if (car.ReadyRacing == true)
                return $"{car.Name}  - Готов к гонке";

            else
                return $"{car.Name}  - Не готов к гонке";
        }

        static public void Start(IEnumerable<Car> car)
        {
            var rnd = new Random();

            foreach (var item in car)
            {                
                BonusSpeed[] BonusSpeedValues = Enum.GetValues(typeof(BonusSpeed)).Cast<BonusSpeed>().ToArray();

                //гоночная машина не получает бонусов в скорости
                if (item is RacingCar)
                    continue;
                item.Speed += (int)BonusSpeedValues[rnd.Next(BonusSpeedValues.Length)];
            }
        }      
    }
}
