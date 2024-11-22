using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab09_210042111
{
    public class Location:IWidget
    {
        Mediator mediator;

        public Location(Mediator mediator)
        {//
            this.mediator = mediator;
        }
        public void Update()
        {

            Console.WriteLine("Location has been updated");
           mediator.Notify(this);
        }
    }
}
