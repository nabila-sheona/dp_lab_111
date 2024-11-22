using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab09_210042111
{
    public class TimeZone: IWidget
    {
        Mediator mediator;

        public TimeZone(Mediator mediator)
        {
            this.mediator = mediator;
        }
        public void Update()
        {

            Console.WriteLine("TimeZone has been updated");
            mediator.Notify(this);
        }
    }
}
