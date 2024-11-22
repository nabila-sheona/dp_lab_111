using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab09_210042111
{
    public class Mediator
    {
      

        Dictionary<IWidget, List<IWidget>> dependancy = new Dictionary<IWidget, List<IWidget>>();

        IWidget currentTime;
        IWidget currentWaqt;
        IWidget location;
        IWidget nextWaqt;
        IWidget prayerTimeSettings;
        IWidget prayerTimeTable;
        IWidget timeZone;
        IWidget waqtTime;

        public void set(IWidget currentTime,
        IWidget currentWaqt,
        IWidget location,
        IWidget nextWaqt,
        IWidget prayerTimeSettings,
        IWidget prayerTimeTable,
        IWidget timeZone,
        IWidget waqtTime) {
            this.currentTime = currentTime;
            this.currentWaqt = currentWaqt;
            this.location = location;
            this.nextWaqt = nextWaqt;
            this.prayerTimeSettings = prayerTimeSettings;
            this.prayerTimeTable = prayerTimeTable;
            this.timeZone = timeZone;
            this.waqtTime = waqtTime;
            this.Register();
        }
        public void Register()
        {
            dependancy[timeZone] = new List<IWidget> { currentTime, waqtTime };
            dependancy[location] = new List<IWidget> { waqtTime };
            dependancy[prayerTimeSettings] = new List<IWidget> { prayerTimeTable };
            dependancy[currentTime] = new List<IWidget> { currentWaqt };
            dependancy[waqtTime] = new List<IWidget> {currentWaqt, nextWaqt};
            dependancy[prayerTimeTable] = new List<IWidget> { nextWaqt };
           
        }
        public void Notify(IWidget sender)
        { 
           foreach ( IWidget widget in dependancy[sender]) { widget.Update(); }
        }
    }
}
