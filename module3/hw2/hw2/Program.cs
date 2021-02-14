using System;

namespace task6
{
    public delegate void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs a);

    public abstract class Creature
    {
        public string Name { get; protected set; }
        protected string Location;
        public virtual void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e) { }
    }
    // 1) класс с данными о событии "Кольцо найдено"
    public class RingIsFoundEventArgs : EventArgs
    {
        public RingIsFoundEventArgs(string s) { Message = s; }
        // Будем передавать только строку
        public String Message { get; set; }
    }

    public class Wizard : Creature
    {
        
        
        //3) событие "Кольцо найдено"
        public event RingIsFoundEventHandler RaiseRingIsFoundEvent;
        public Wizard(string s) { Name = s; }
        public Wizard() { }
        // Когда волшебнику кажется, что кольцо найдено, он вызывает этот метод
        public void SomeThisIsChangedInTheAir()
        {
            Console.WriteLine($"{Name} >> Кольцо найдено у старого Бильбо! Призываю вас в Ривендейл! ");
            RaiseRingIsFoundEvent(this, new RingIsFoundEventArgs("Ривендейл"));
        }
    }

    public class Hobbit : Creature
    {
        
        public Hobbit(string s) { Name = s; Location = "Северодвинск"; }
        public override void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e)
        {
            Console.WriteLine($"{Name} >> Покидаю SHEER ({Location})! Иду в " + e.Message);
            Location = e.Message;
        }
    }
    public class Human : Creature
    {
        
        public Human(string s) { Name = s; Location = "Новокубанск"; }
        public override void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e)
        {
            Console.WriteLine($"{Name} >> Волшебник {((Wizard)sender).Name} позвал. Моя цель - построить коммунизм. Покидаю {Location}, направляюсь в {e.Message}.");
            Location = e.Message;
        }
    }

    public class Elf: Creature
    {
        
        public Elf(string s) { Name = s; Location = "GayCity"; }
        public override void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e)
        {
            Console.WriteLine($"{Name} >> Звёзды светят не так ярко как обычно. Цветы увядают. Листья предсказывают долгий путь. Покидаю {Location}, направляюсь в {e.Message}");
            Location = e.Message;
        }
    }
    public class Dwarf : Creature
    {
        
        public Dwarf(string s) { Name = s; Location = "Махачкала"; }
        public override void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e)
        {
            Console.WriteLine($"{Name} >> Точим топоры, собираем припасы, режем барашка! Уезжаем из {Location} в {e.Message}, ежжи да");
            Location = e.Message;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Wizard wizard = new Wizard("Гендальф");
            Creature[] creatures = new Creature[8];
            creatures[0] = new Hobbit("Фродо");
            creatures[1] = new Hobbit("Сээээм");
            creatures[2] = new Hobbit("Pipin");
            creatures[3] = new Hobbit("Мэрри");
            creatures[4] = new Human("Боромир");
            creatures[5] = new Human("ARA_GONE");
            creatures[6] = new Dwarf("Gimley");
            creatures[7] = new Elf("Легалайз");
            foreach(Creature creature in creatures)
            {
                wizard.RaiseRingIsFoundEvent += creature.RingIsFoundEventHandler;
            }
            
            wizard.SomeThisIsChangedInTheAir();
        }
    }

}

