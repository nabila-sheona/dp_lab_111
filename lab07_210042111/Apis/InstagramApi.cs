using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab07_210042111
{
    public class InstagramApi
    {
        public List<(string Id, string Caption, bool Seen)> GetStories()
        {
            return new List<(string, string, bool)>
            {
                ("1", "Instagram Story 1", false),
                ("2", "Instagram Story 2", true)
            };
        }

        public void MarkStoryAsSeen(string storyId)
        {
            Console.WriteLine($"Instagram: Marking story {storyId} as seen.");
        }

        public void RemoveStory(string storyId)
        {
            Console.WriteLine($"Instagram: Removing story {storyId}.");
        }
    }
}
