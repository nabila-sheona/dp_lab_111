using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab09_210042111
{
    public class CurrentTime: IWidget
    {
        Mediator mediator;

        public CurrentTime(Mediator mediator)
        {
            this.mediator = mediator;
        }
        public void Update()
        {

            Console.WriteLine("currenttime has been updated");
            mediator.Notify(this);
        }
    }
}
