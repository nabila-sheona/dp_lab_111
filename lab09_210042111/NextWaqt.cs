using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab09_210042111
{
    public class NextWaqt : IWidget
    {
        Mediator mediator;

        public NextWaqt(Mediator mediator)
        {
            this.mediator = mediator;
        }
        public void Update()
        {

            Console.WriteLine("NextWaqt has been updated");
        
        }
    }
}
