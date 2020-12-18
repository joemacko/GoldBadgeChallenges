using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Insurance_Repo
{
    public class BadgeRepository
    {
        public Dictionary<int, Badge> _badgeDictionary = new Dictionary<int, Badge>();
        private int _badgeIDCounter = 0;

        // Create A Badge Method
        public void CreateNewBadge(Badge badge)
        {
            badge.BadgeID = _badgeIDCounter + 1;
            _badgeDictionary.Add(badge.BadgeID, badge);
            _badgeIDCounter++;
        }
        
        // Read All Badges Method
        public Dictionary<int, Badge> ReadAllBadges()
        {
            return _badgeDictionary;
        }
        
        // Update A Badge Method
        public bool UpdateBadge(int badgeID, Badge badge)
        {
            Badge oldBadge = _badgeDictionary[badgeID];
            
            if (oldBadge != null)
            {
                oldBadge.DoorNames = badge.DoorNames;
                return true;
            }
            else
            {
                return false;
            }
        }

        // Delete A Badge Method
        public bool RemoveBadge(int badgeID)
        {
            if (_badgeDictionary.Remove(badgeID))
            {
                return true;
            }
            return false;
        }

        // Get Badge By ID Helper Method
        public Badge GetBadgeByID(int badgeID)
        {
            foreach (KeyValuePair<int, Badge> badge in _badgeDictionary)
            {
                int key = badge.Key;
                Badge value = badge.Value;

                if (key == badgeID)
                {
                    return value;
                }
            }
            return null;
        }

        // Add Door To Badge Helper Method
        public bool AddDoorToBadge(int badgeID, string doorName)
        {
            Badge badge = GetBadgeByID(badgeID);

            foreach (string door in badge.DoorNames)
            {
                if (door == doorName)
                {
                    badge.DoorNames.Add(door);
                    return true;
                }
            }
            return false;
        }

        // Remove Door From Badge Helper Method
        public bool RemoveDoorFromBadge(int badgeID, string doorName)
        {
            Badge badge = GetBadgeByID(badgeID);

            foreach (string door in badge.DoorNames)
            {
                if (door == doorName)
                {
                    badge.DoorNames.Remove(door);
                    return true;
                }
            }
            return false;
        }
    }
}
