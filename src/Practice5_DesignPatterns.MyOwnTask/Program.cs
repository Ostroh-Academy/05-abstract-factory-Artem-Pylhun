using static Practice5_DesignPatterns.MyOwnTask.Program;

namespace Practice5_DesignPatterns.MyOwnTask
{
    /*        9  Авто на гусеничному та колісному ходу: 
      *        Розробити фабрику, що дозволяє проектувати 
      *        транспортні засоби на основі їх ходової частини, 
      *        оптимізуючи їх для різних умов пересування.
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Оберіть ходову частину вашого транспорту:\n1.Колісна\n2.Гусенична");
            var result = Console.ReadLine();
            while ((result != "Ходова" && result != "2") && (result != "Колісна" && result != "1"))
            {
                result = Console.ReadLine();
            }
            if (result == "1")
            {
                Vehicle car = new Vehicle(new WheeledVehicle());
                Console.WriteLine("Було обрано колісну техніку, чи хочете ви запустити двигун і поїхати?\n1.Так\n2.Ні");
                result = Console.ReadLine();
                while ((result != "Ні" && result != "2") && (result != "Так" && result != "1"))
                {
                    result = Console.ReadLine();
                }
                if (result == "Ні" || result == "2")
                {
                    Console.WriteLine("Ваш транспортний засіб стоїть");
                }
                else if (result == "Так" || result == "1")
                {
                    car.Drive();
                    DateTime current = DateTime.Now;
                    Console.WriteLine("Чи бажаєте ви зупинити транспорт?\n1.Так\n2.Ні");
                    result = Console.ReadLine();
                    while ((result != "Ні" && result != "2") && (result != "Так" && result != "1"))
                    {
                        result = Console.ReadLine();
                    }
                    if (result == "Ні" || result == "2")
                    {
                        Console.WriteLine("Ваш транспортний засіб все ще їде");
                    }
                    else if (result == "Так" || result == "1")
                    {
                        car.Stop();
                        var time = DateTime.Now - current;
                        Console.WriteLine($"Час запущеного двигуна: {time.TotalSeconds.ToString("0.00")}s");
                    }
                }


            }
            else if (result == "2")
            {
                Vehicle car = new Vehicle(new TrackedVehicle());
                Console.WriteLine("Було обрано гусеничну техніку, чи хочете ви запустити двигун і поїхати?\n1.Так\n2.Ні");
                result = Console.ReadLine();
                while ((result != "Ні" && result != "2") && (result != "Так" && result != "1"))
                {
                    result = Console.ReadLine();
                }
                if (result == "Ні" || result == "2")
                {
                    Console.WriteLine("Ваш транспортний засіб стоїть");
                }
                else if (result == "Так" || result == "1")
                {
                    car.Drive();
                    DateTime current = DateTime.Now;
                    Console.WriteLine("Чи бажаєте ви зупинити транспорт?\n1.Так\n2.Ні");
                    result = Console.ReadLine();
                    while ((result != "Ні" && result != "2") && (result != "Так" && result != "1"))
                    {
                        result = Console.ReadLine();
                    }
                    if (result == "Ні" || result == "2")
                    {
                        Console.WriteLine("Ваш транспортний засіб все ще їде");
                    }
                    else if (result == "Так" || result == "1")
                    {
                        car.Stop();
                        var time = DateTime.Now - current;
                        Console.WriteLine($"Час запущеного двигуна: {time.TotalSeconds.ToString("0.00")}s");
                    }
                }
            }
        }
        public interface IVehicleFactory
        {
            public abstract IEngine CreateEngine();
            public abstract IChassis CreateChassis();
        }
        class TrackedVehicle: IVehicleFactory
        {
            public IEngine CreateEngine()
            {
                return new DieselEngine();
            }
            public IChassis CreateChassis()
            {
                return new TrackedChassis();
            }
        }
        class WheeledVehicle : IVehicleFactory
        {
            public IEngine CreateEngine()
            {
                return new PetrolEngine();
            }
            public IChassis CreateChassis()
            {
                return new WheeledChassis();
            }
        }

    }

     interface IChassis
    {
        public void Move();
        public void Stop();
    }

    class TrackedChassis : IChassis
    {
        public void Move()
        {
            Console.WriteLine("Рух по гусеницях");
        }

        public void Stop()
        {
            Console.WriteLine("Зупинка гусеничного транспортного засобу");
        }
    }

    class WheeledChassis : IChassis
    {
        public void Move()
        {
            Console.WriteLine("Рух на колесах");
        }

        public void Stop()
        {
            Console.WriteLine("Зупинка колісного транспортного засобу");
        }
    }
    public interface IEngine
    {
        public void Start();
    }
    class DieselEngine : IEngine
    {
        public void Start()
        {
            Console.WriteLine("Дизельний двигун запущено");
        }
    }

    class PetrolEngine : IEngine
    {
        public void Start()
        {
            Console.WriteLine("Бензиновий двигун запущено");
        }
    }
    class Vehicle
    {
        private IEngine _engine;
        private IChassis _chassis;
        public Vehicle(IVehicleFactory factory)
        {
            _engine = factory.CreateEngine();
            _chassis = factory.CreateChassis();
        }

        public void Drive()
        {
            _engine.Start();
            _chassis.Move();
        }

        public void Stop()
        {
            _chassis.Stop();
        }
    }
}
