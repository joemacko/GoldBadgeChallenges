using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Insurance_Repo
{
    public class BadgeRepository
    {
        private readonly Dictionary<int, Badge> _badgeDictionary = new Dictionary<int, Badge>();
        private int _devIDCounter = 0;

        // Create a badge method
        public void CreateNewBadge(Badge badge)
        {
            badge.BadgeID = _devIDCounter + 1;
            _badgeDictionary.Add(badge.BadgeID, badge);
            _devIDCounter++;
        }
        
        // Read all badges method
        public Dictionary<int, Badge> ReadAllBadges()
        {
            return _badgeDictionary;
        }
        
        // Update a badge method
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

        // Delete a badge method
        public bool RemoveBadge(int badgeID)
        {
            if (_badgeDictionary.Remove(badgeID))
            {
                return true;
            }
            return false;
        }

        // Helper
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
    }
}
