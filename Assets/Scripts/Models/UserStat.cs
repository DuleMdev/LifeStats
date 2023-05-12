using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Models
{
    public class UserStat
    {
        public Stat stat;

        public int count;
        public int streakCount;
        
        private List<CheckIn> checkIns;
        private string lastCheckInDate;
        private int longestStreak;


        public event Action UpdateStatDisplay;

        public UserStat(Stat s)
        {
            stat = s;
            checkIns = new List<CheckIn>();
            count = 0;
            streakCount = 0;
            lastCheckInDate = "";
            longestStreak = 0;
        }

        public void CheckInAdded()
        {
            checkIns.Add(new CheckIn(DateTime.Now.ToString()));
            count++;
            UpdateStatDisplay?.Invoke();
            CheckForStreak();
        }

        public void CheckIfStreakShouldReset()
        {
            if (streakCount == 0) return;
            if (DifferenceInDayFromLastCheckIn() > 1) ResetStreak();
        }
        

        private int DifferenceInDayFromLastCheckIn()
        {
            if (!DateTime.TryParse("", out var checkInDate)) return 0;
            var difference = DateTime.Today - checkInDate;
            return difference.Days;
        }

        private void CheckForStreak()
        {
            if (streakCount == 0 || DifferenceInDayFromLastCheckIn() == 1)
            {
                AddStreak();
            }
        }

        private void AddStreak()
        {
            streakCount++;
            lastCheckInDate = DateTime.Today.ToString();
        }

        private void ResetStreak()
        {
            if (streakCount > longestStreak)
            {
                longestStreak = streakCount;
            }
            streakCount = 0;
            lastCheckInDate = "";
        }
    }
}