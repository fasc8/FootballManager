using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager
{
    enum SaveFormat
    {
        File,
        Excel
    }

    class Spiele
    {
        public int Id { get; set; }
        public string Time { get; set; }
        public string Home { get; set; }
        public int HomeGoals { get; set; }
        public string Guest { get; set; }
        public int GuestGoals { get; set; }
        public bool Played { get; set; }
        public bool Rating { get; set; }
    }

    public class Game
    {
        public string Home { get; set; }
        public string Guest { get; set; }
    }

    public class Stats
    {
        public string Team { get; set; }
        public int Games { get; set; }
        public int Points { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
    }
}
