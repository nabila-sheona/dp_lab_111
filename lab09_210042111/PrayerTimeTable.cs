﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab09_210042111
{
    public class PrayerTimeTable : IWidget
    {
        Mediator mediator;

        public PrayerTimeTable(Mediator mediator)
        {
            this.mediator = mediator;
        }
        public void Update()
        {

            Console.WriteLine("PrayerTimeTable has been updated");
            mediator.Notify(this);
        }
    }
}