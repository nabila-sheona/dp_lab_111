using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab09_210042111
{
    internal class Program
    {
        static void Main(string[] args)
        {
           


            Mediator mediator = new Mediator();
            IWidget currentTime=new CurrentTime(mediator);
            IWidget currentWaqt =new CurrentWaqt(mediator);
            IWidget location =new Location(mediator);
            IWidget nextWaqt =new NextWaqt(mediator);
            IWidget prayerTimeSettings =new PrayerTimeSettings(mediator);
            IWidget prayerTimeTable =new PrayerTimeTable(mediator);
            IWidget timeZone =new TimeZone(mediator);
            IWidget waqtTime =new WaqtTime(mediator);

            mediator.set(currentTime, currentWaqt, location, nextWaqt, prayerTimeSettings, prayerTimeTable, timeZone, waqtTime);
           
            Console.WriteLine("timeZone");

          
            mediator.Notify(timeZone);
            Console.ReadKey();

            Console.WriteLine("currentTime");
            mediator.Notify(currentTime);
            Console.ReadKey();

            Console.ReadKey();
            Console.WriteLine("location");
            mediator.Notify(location);
            Console.ReadKey();


            Console.WriteLine("prayerTimeSettings");

           
          

            mediator.Notify(prayerTimeSettings);

            Console.ReadKey();
            Console.WriteLine("prayerTimeTable");
            mediator.Notify(prayerTimeTable);

            Console.ReadKey();
            Console.WriteLine("waqtTime");
            mediator.Notify(waqtTime);

            Console.ReadKey();

        }
    }
}
