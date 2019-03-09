using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandChildGetTheHabitFromUncle
{

    interface GrandpaPaper
    {
        string TakeTheGarbageOut();
        string LikeFood();
    }

    public class Mom : GrandpaPaper
    {
        public string LikeFood()
        {
            return "pasta";
        }

        public string TakeTheGarbageOut()
        {
            return "Take the garbage out like the Mom";
        }
    }

    public class Uncle : GrandpaPaper
    {
        public string LikeFood()
        {
            return "pizza";
        }

        public string TakeTheGarbageOut()
        {
            return "Take the garbage out like the Uncle";
        }
    }

    public class Son : Mom
    {
        GrandpaPaper uncle = new Uncle();
        public string TakeTheGarbageOut()
        {
            return uncle.TakeTheGarbageOut();
        }
    }
}
