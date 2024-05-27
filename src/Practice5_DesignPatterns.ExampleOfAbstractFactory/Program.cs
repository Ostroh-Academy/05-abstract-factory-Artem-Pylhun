using System.Text;

namespace Practice5_DesignPatterns.ExampleOfAbstractFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Оберіть свого героя:\n1.Elf\n2.Warrior");
            var result = Console.ReadLine();
            while (result != "Elf" && result != "Warrior")
            {
                result = Console.ReadLine();
            }
            if (result == "Elf")
            {
                Hero elf = new Hero(new ElfFactory());
                Console.WriteLine("Було обрано ельфа, яку дію ви хочете побачити?\n1.Hit\n2.Run");
                result = Console.ReadLine();
                while (result != "Hit" && result != "Run")
                {
                    result = Console.ReadLine();
                }
                if(result == "Hit")
                {
                    elf.Hit();
                }
                else if(result == "Run")
                {
                    elf.Run();
                }
            }
            else if (result == "Warrior")
            {
                Hero warrior = new Hero(new WarriorFactory());
                Console.WriteLine("Було обрано воїна, яку дію ви хочете побачити?\n1.Hit\n2.Run");
                result = Console.ReadLine();
                while (result != "Hit" && result != "Run")
                {
                    result = Console.ReadLine();
                }
                if (result == "Hit")
                {
                    warrior.Hit();
                }
                else if (result == "Run")
                {
                    warrior.Run();
                }
            }
        }
        interface IHeroFactory
        {
            public IMovement CreateMovement();
            public IWeapon CreateWeapon();
        }
        class ElfFactory : IHeroFactory
        {
            public IMovement CreateMovement()
            {
                return new FlyMovement();
            }
            public IWeapon CreateWeapon()
            {
                return new Arbalet();
            }
        }
        class WarriorFactory : IHeroFactory
        {
            public IMovement CreateMovement()
            {
                return new RunMovement();
            }

            public IWeapon CreateWeapon()
            {
                return new Sword();
            }
        }
        interface IWeapon
        {
            public void Hit();
        }

        interface IMovement
        {
            public abstract void Move();
        }

        class Arbalet : IWeapon
        {
            public void Hit()
            {
                Console.WriteLine("Стріляємо з арбалета");
            }
        }

        class Sword : IWeapon
        {
            public void Hit()
            {
                Console.WriteLine("Б'ємо мечем");
            }
        }

        class FlyMovement : IMovement
        {
            public void Move()
            {
                Console.WriteLine("Летимо");
            }
        }
        class RunMovement : IMovement
        {
            public void Move()
            {
                Console.WriteLine("Біжимо");
            }
        }
        class Hero
        {
            private IWeapon weapon;
            private IMovement movement;
            public Hero(IHeroFactory factory)
            {
                weapon = factory.CreateWeapon();
                movement = factory.CreateMovement();
            }
            public void Run()
            {
                movement.Move();
            }
            public void Hit()
            {
                weapon.Hit();
            }
        }
    }
}
