using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab09_210042111
{
    public class CurrentWaqt : IWidget
    {
        Mediator mediator;

        public CurrentWaqt(Mediator mediator)
        {
            this.mediator = mediator;
        }
        public void Update()
        {

            Console.WriteLine("CurrentWaqt has been updated");
    
        }
    }
}
