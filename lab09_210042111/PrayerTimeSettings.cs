using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab09_210042111
{
    public class PrayerTimeSettings : IWidget
    {
        Mediator mediator;

        public PrayerTimeSettings(Mediator mediator)
        {
            this.mediator = mediator;
        }
        public void Update()
        {

            Console.WriteLine("PrayerTimeSettings has been updated");
            mediator.Notify(this);
        }
    }
}
