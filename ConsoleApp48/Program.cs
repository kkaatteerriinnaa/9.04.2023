using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp48
{
    // Интерфейс стратегии
    interface ITransportStrategy
    {
        void GetToAirport();
        int GetCost();
        int GetTime();
    }

    // Конкретная стратегия для езды на автобусе
    class BusStrategy : ITransportStrategy
    {
        private const int Cost = 50;
        private const int Time = 60;

        public void GetToAirport()
        {
            Console.WriteLine("Добираемся до аэропорта на автобусе");
        }

        public int GetCost()
        {
            return Cost;
        }

        public int GetTime()
        {
            return Time;
        }
    }

    // Конкретная стратегия для поездки на такси
    class TaxiStrategy : ITransportStrategy
    {
        private const int Cost = 200;
        private const int Time = 30;

        public void GetToAirport()
        {
            Console.WriteLine("Добираемся до аэропорта на такси");
        }

        public int GetCost()
        {
            return Cost;
        }

        public int GetTime()
        {
            return Time;
        }
    }

    // Конкретная стратегия для поездки на велосипеде
    class BicycleStrategy : ITransportStrategy
    {
        private const int Cost = 0;
        private const int Time = 120;

        public void GetToAirport()
        {
            Console.WriteLine("Добираемся до аэропорта на велосипеде");
        }

        public int GetCost()
        {
            return Cost;
        }

        public int GetTime()
        {
            return Time;
        }
    }

    // Класс контекста, который выбирает стратегию в зависимости от наличия денег или времени до отлета
    class Context
    {
        private ITransportStrategy strategy;

        public Context(ITransportStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void SetStrategy(ITransportStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void GoToAirport()
        {
            strategy.GetToAirport();
        }

        public int GetCost()
        {
            return strategy.GetCost();
        }

        public int GetTime()
        {
            return strategy.GetTime();
        }
    }

    // Пример использования
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context(new BusStrategy());

            // Если есть достаточно времени, едем на автобусе
            context.GoToAirport();
            Console.WriteLine($"Стоимость поездки на автобусе: {context.GetCost()} рублей");
            Console.WriteLine($"Время в пути на автобусе: {context.GetTime()} минут");

            // Если мало времени, но есть деньги, едем на такси
            context.SetStrategy(new TaxiStrategy()); context.GoToAirport();
            Console.WriteLine($"Стоимость поездки на такси: {context.GetCost()} рублей");
            Console.WriteLine($"Время в пути на такси: {context.GetTime()} минут");

            // Если мало денег, но есть время, едем на велосипеде
            context.SetStrategy(new BicycleStrategy());
            context.GoToAirport();
            Console.WriteLine($"Стоимость поездки на велосипеде: {context.GetCost()} рублей");
            Console.WriteLine($"Время в пути на велосипеде: {context.GetTime()} минут");
        }
    }
}
