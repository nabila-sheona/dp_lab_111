using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab07_210042111
{
    public class TwitterApi
    {
        public List<(string Id, string Content, bool IsRead)> GetTweets()
        {
            return new List<(string, string, bool)>
        {
            ("1", "Tweet 1", false),
            ("2", "Tweet 2", true)
        };
        }

        public void MarkTweetAsRead(string tweetId)
        {
            Console.WriteLine($"Twitter: Marking tweet {tweetId} as read.");
        }

        public void DeleteTweet(string tweetId)
        {
            Console.WriteLine($"Twitter: Deleting tweet {tweetId}.");
        }
    }

}
