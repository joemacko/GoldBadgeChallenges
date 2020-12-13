using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Insurance_Repo
{
    // POCO
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> DoorNames { get; set; }

        // Constructors
        public Badge() { }

        public Badge(int badgeID, List<string> doorNames)
        {
            BadgeID = badgeID;
            DoorNames = doorNames;
        }
    }
}
