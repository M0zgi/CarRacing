using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRacing
{
    
    class Program
    {        
        static void Main(string[] args)
        {

            //Инициализируем список автомобилей
            List<Car> car = new List<Car>();

            car.Add(new RacingCar((int)CarSpeed.SuperHigh, "Гоночный автомобиль", true, DriverExperience.Junior));
            car.Add(new PassengerCar((int)CarSpeed.High, "Пассажирский автомобиль", true, DriverExperience.Middle));
            car.Add(new Bus((int)CarSpeed.Middle, "Автобус", false, DriverExperience.Junior));
            car.Add(new Truck((int)CarSpeed.Low, "Грузовой автомобиль", true, DriverExperience.Senior));
            car.Add(new Truck((int)CarSpeed.Middle, "Грузовой автомобиль 2", true, DriverExperience.Senior));


            // Вывод всех машин с пометкой о готовности к гонкам 

            IEnumerable<string> race2 = car.Select(Game.PrintReadyRacingCars);

            foreach (var item in race2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(new string('-', 30));

            // Создание перечислителя и вывод только готовых к гонкам машин
            // В дальнейшем, только эти авто учавствуютв гонах

            IEnumerable<Car> race1 = car.Where(c => c.ReadyRacing != false);

            foreach (var item in race1)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(new string('-', 30));         

            //Перед стартом гонки раздаем бонусы ввиде увеличения скорости
            Game.Start(race1);
           

            foreach (var item in car)
            {
                if (item.ReadyRacing)
                {
                   //подписываем на событие гонки
                    Game.Drive += item.Drive;        
                }                                 
            }

            Console.WriteLine("\n\n\n\n\n");           

            //получаем количество участников гонки
            Game.Place = Game.GetHandlersCount();

            do
            {
                Game.CarDrive(Game.Distance);

                Console.WriteLine(new string('-', 30));
                
                Game.Distance -= 10;

            } while (Game.GetHandlersCount() != 0);


        }
      
    }
}
