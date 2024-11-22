using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab09_210042111
{
    public class WaqtTime: IWidget
    {
        Mediator mediator;

        public WaqtTime(Mediator mediator)
        {
            this.mediator = mediator;
        }
        public void Update()
        {

            Console.WriteLine("waqt time has been updated");
            mediator.Notify(this);
        }
    }
}
