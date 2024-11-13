using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab07_210042111
{
    public class LinkedInApi
    {
        public List<(string Id, string Message, bool Seen)> GetUpdates()
        {
            return new List<(string, string, bool)>
            {
                ("1", "LinkedIn Notification 1", false),
                ("2", "LinkedIn Notification 2", true)
            };
        }

        public void MarkUpdateAsSeen(string updateId)
        {
            Console.WriteLine($"LinkedIn: Marking update {updateId} as seen.");
        }

        public void RemoveUpdate(string updateId)
        {
            Console.WriteLine($"LinkedIn: Removing update {updateId}.");
        }
    }


}
