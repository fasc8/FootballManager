using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.IO;

namespace FootballManager
{
    class Manager
    {
        private List<KeyValuePair<string, bool>> lTeams = null;
        private List<Spiele> lGames = null;
        private bool bPlanHasChanged = false;
        private List<Stats> lStats = null;
        private string StartTime = "";
        private int GameLength = -1;
        private int GamePause = -1;
        private List<Tuple<string, int>> lPauses = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Teams"><see cref="string"/> is teamname and <see cref="bool"/> is true if team is part of competition</param>
        /// <param name="StartTime">format: hh.mm</param>
        /// <param name="GameLength">in minutes</param>
        /// <param name="GamePause">in minutes</param>
        /// <param name="Pauses"></param>
        public Manager(List<KeyValuePair<string, bool>> Teams, string StartTime, int GameLength, int GamePause, List<Tuple<string, int>> Pauses)
        {
            this.lTeams = Teams;
            this.StartTime = StartTime;
            this.GameLength = GameLength;
            this.GamePause = GamePause;
            this.lPauses = Pauses;
        }

        /// <summary>
        /// 
        /// </summary>
        public Manager()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="Path"></param>
        /// <returns></returns>
        public bool SaveTable(SaveFormat format, string Path)
        {
            switch (format)
            {
                case SaveFormat.File:
                    SaveTableToFile(Path);
                    break;
                case SaveFormat.Excel:
                    SaveTableToExcel(Path);
                    break;
                default:
                    break;
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Path"></param>
        private void SaveTableToExcel(string Path)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb = app.Workbooks.Add(XlSheetType.xlWorksheet);
            Worksheet ws = (Worksheet)app.ActiveSheet;
            app.Visible = false;
            //Zellen Headers
            ws.Cells[1, 1] = "Rang";
            ws.Cells[1, 2] = "Mannschaft";
            ws.Cells[1, 3] = "Spiele";
            ws.Cells[1, 4] = "Punkte";
            ws.Cells[1, 5] = "Tore";
            ws.Cells[1, 6] = "Gegentore";
            ws.Cells[1, 7] = "Tordifferenz";

            int i = 0;
            foreach (var s in lStats)
            {
                ws.Cells[i + 2, 1] = i + 1;
                ws.Cells[i + 2, 2] = s.Team;
                ws.Cells[i + 2, 3] = s.Games;
                ws.Cells[i + 2, 4] = s.Points;
                ws.Cells[i + 2, 5] = s.GoalsFor;
                ws.Cells[i + 2, 6] = s.GoalsAgainst;
                ws.Cells[i + 2, 7] = s.GoalsFor - s.GoalsAgainst;
                i++;
            }
            wb.SaveAs(Path, XlFileFormat.xlOpenDocumentSpreadsheet, Type.Missing, Type.Missing, true, false, XlSaveAsAccessMode.xlNoChange, XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);
            app.Quit();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Path"></param>
        private void SaveTableToFile(string Path)
        {
            if (lGames == null) return;

            string text = "";
            int i = 1;
            foreach (var s in lStats)
            {
                text += i + ";" + s.Team + ";" + s.Games + ";" + s.Points + ";" + s.GoalsFor + ";" + s.GoalsAgainst + ";" + (s.GoalsFor - s.GoalsAgainst).ToString() + "\n";
                i++;
            }
            File.WriteAllText(Path, text);
        }

        /// <summary>
        /// Save the plan to a file with given format
        /// </summary>
        /// <param name="format"></param>
        /// <param name="Path"></param>
        /// <returns>true on succes</returns>
        public bool SavePlan(SaveFormat format, string Path)
        {
            switch (format)
            {
                case SaveFormat.File:
                    return SavePlanToFile(Path);
                case SaveFormat.Excel:
                    return SavePlanToExcel(Path);
                default:
                    break;
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Path"></param>
        private bool SavePlanToExcel(string Path)
        {
            bool status = true;
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb = app.Workbooks.Add(XlSheetType.xlWorksheet);
            Worksheet ws = (Worksheet)app.ActiveSheet;
            app.Visible = false;
            //Zellen Headers
            ws.Cells[1, 1] = "ID";
            ws.Cells[1, 2] = "Zeit";
            ws.Cells[1, 3] = "Heim";
            ws.Cells[1, 4] = "Stand";
            ws.Cells[1, 5] = "Gast";
            
            int i = 0;
            foreach (var s in lGames)
            {
                ws.Cells[i + 2, 1] = s.Id;
                ws.Cells[i + 2, 2] = s.Time;
                ws.Cells[i + 2, 3] = s.Home;
                ws.Cells[i + 2, 4] = (s.HomeGoals == -1 ? "__" : s.HomeGoals.ToString()) + ":" + (s.GuestGoals == -1 ? "__" : s.GuestGoals.ToString());
                ws.Cells[i + 2, 5] = s.Guest;
                i++;
            }

            try
            {
                wb.SaveAs(Path, XlFileFormat.xlOpenDocumentSpreadsheet, Type.Missing, Type.Missing, true, false, XlSaveAsAccessMode.xlNoChange, XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);

            }
            catch (Exception)
            {
                status = false;
            }
            wb.Close();
            app.Quit();
            return status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="bIsAutoSaveFile"></param>
        private bool SavePlanToFile(string Path)
        {
            if (lGames == null) return false;

            string text = "";
            foreach (var s in lGames)
            {
                text += s.Id + ";" + s.Time + ";" + s.Home + ";" + s.HomeGoals + ":" + s.GuestGoals + ";" + s.Guest + ";" + s.Played + ";" + s.Rating + "\n";
            }
            text += "{Teams}\n";
            foreach(var s in lTeams)
            {
                text += s.Key + ";" + s.Value + "\n";
            }
            File.WriteAllText(Path, text);
            return true;
        }

        /// <summary>
        /// Imports a Plan from a txt and overrides the old plan
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public bool ImportPlanFromTxt(string Path)
        {
            try
            {
                lGames = new List<Spiele>();
                lTeams = new List<KeyValuePair<string, bool>>();
                string[] lines = File.ReadAllLines(Path);
                List<string> games = new List<string>();
                List<string> teams = new List<string>();

                for (int i = 0; i < lines.Length; i++)
                {
                    if(lines[i] == "{Teams}")
                    {
                        games = lines.Take(i).ToList();
                        teams = lines.Skip(i + 1).ToList();
                        break;
                    }
                }

                if (games.Count() == 0 || teams.Count() == 0) throw new Exception();
                
                foreach (var s in games)
                {
                    Spiele game = new Spiele();
                    game.Id = int.Parse(s.Split(';')[0]);
                    game.Time = s.Split(';')[1];
                    game.Home = s.Split(';')[2];
                    game.HomeGoals = int.Parse(s.Split(';')[3].Split(':')[0]);
                    game.Guest = s.Split(';')[4];
                    game.GuestGoals = int.Parse(s.Split(';')[3].Split(':')[1]);
                    game.Played = (s.Split(';')[5] == "True" ? true : false);
                    game.Rating = (s.Split(';')[6] == "True" ? true : false);
                    lGames.Add(game);
                }

                foreach (var s in teams)
                {
                    string teamName = s.Split(';')[0];
                    bool rating = (s.Split(';')[1] == "True" ? true : false);
                    lTeams.Add(new KeyValuePair<string, bool>(teamName, rating));
                }

                this.createTable();

                bPlanHasChanged = true;
                return true;
            }
            catch (Exception)
            {

            }
            return false;
        }

        /// <summary>
        /// Update a specific game with new goal values. Sets bPlanHasChanged to true
        /// </summary>
        /// <param name="Id">Id to specifie the game</param>
        /// <param name="HomeGoals"></param>
        /// <param name="EnemyGoals"></param>
        /// <param name="Played"></param>
        /// <returns></returns>
        public bool UpdateGame(int Id, int HomeGoals, int EnemyGoals, bool Played)
        {
            if (Id > lGames.Count()) return false;

            lGames.Where(a => a.Id == Id).First().HomeGoals = HomeGoals;
            lGames.Where(a => a.Id == Id).First().GuestGoals = EnemyGoals;
            lGames.Where(a => a.Id == Id).First().Played = Played;

            if (lGames.Where(a => a.Id == Id).First().Rating) this.createTable();

            bPlanHasChanged = true;
            return true;
        }

        /// <summary>
        /// True if the plan has been changed resently. If so bPlanHasChanged is set to false
        /// </summary>
        /// <returns></returns>
        public bool PlanHasChanged()
        {
            if(bPlanHasChanged)
            {
                bPlanHasChanged = false;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Stats> GetTable()
        {
            if (lStats == null) return new List<Stats>();
            return lStats;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Spiele> GetPlan()
        {
            if (lGames == null) return new List<Spiele>();
            return lGames;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<KeyValuePair<string, bool>> GetTeams()
        {
            if (lTeams == null) return new List<KeyValuePair<string, bool>>();
            return lTeams;
        }

        /// <summary>
        /// creates or recalculate the table, sets the internal value lStats to it and returns it as list
        /// </summary>
        /// <returns>a list sorted by points and goal difference</returns>
        public List<Stats> createTable()
        {
            if (lGames == null) return new List<Stats>();
            lStats = makeTable();
            return lStats;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<Stats> makeTable()
        {
            List<string> Teams = new List<string>();
            foreach(var s in this.lTeams)
            {
                if(s.Value) Teams.Add(s.Key);
            }
            
            List<Stats> stat = new List<Stats>();
            
            foreach (var v in Teams)
            {
                Stats val = new Stats();
                foreach (var s in lGames.Where(a => (a.Home == v || a.Guest == v) && a.Rating == true && a.Played == true))
                {
                    if (s.Home == v)
                    {
                        if (s.HomeGoals < s.GuestGoals)
                        {
                            val.GoalsFor += s.HomeGoals;
                            val.GoalsAgainst += s.GuestGoals;
                            val.Games += 1;
                        }
                        else if (s.HomeGoals > s.GuestGoals)
                        {
                            val.GoalsFor += s.HomeGoals;
                            val.GoalsAgainst += s.GuestGoals;
                            val.Points += 3;
                            val.Games += 1;
                        }
                        else if (s.HomeGoals == s.GuestGoals)
                        {
                            val.GoalsFor += s.HomeGoals;
                            val.GoalsAgainst += s.GuestGoals;
                            val.Points += 1;
                            val.Games += 1;
                        }
                    }
                    else if (s.Guest == v)
                    {
                        if (s.HomeGoals > s.GuestGoals)
                        {
                            val.GoalsFor += s.GuestGoals;
                            val.GoalsAgainst += s.HomeGoals;
                            val.Games += 1;
                        }
                        else if (s.HomeGoals < s.GuestGoals)
                        {
                            val.GoalsFor += s.GuestGoals;
                            val.GoalsAgainst += s.HomeGoals;
                            val.Points += 3;
                            val.Games += 1;
                        }
                        else if (s.HomeGoals == s.GuestGoals)
                        {
                            val.GoalsFor += s.GuestGoals;
                            val.GoalsAgainst += s.HomeGoals;
                            val.Points += 1;
                            val.Games += 1;
                        }
                    }
                }
                val.Team = v;
                stat.Add(val);
            }
            List<Stats> sortedList = stat.OrderByDescending(o => o.Points).ThenByDescending(u => u.GoalsFor - u.GoalsAgainst).ToList();
            return sortedList;
        }

        /// <summary>
        /// Creates plan, sets the internal value lGames to it and returns it as list
        /// </summary>
        /// <returns></returns>
        public List<Spiele> createPlan()
        {
            if(lGames == null) lGames = makePlan(this.StartTime, this.GameLength, this.GamePause, this.lPauses, this.lTeams);
            return lGames;
        }

        /// <summary>
        /// Creates a new plan nad sets bPlanHasChanged to true
        /// </summary>
        /// <param name="StartTime"></param>
        /// <param name="GameLength"></param>
        /// <param name="GamePause">Pause zwischen den Spielen</param>
        /// <param name="lPauses">Liste mit unregelmäßigen Pausen</param>
        /// <param name="lTeams"><see cref="KeyValuePair"/> mit Team und einem bool ob es in der Wertung ist</param>
        /// <returns></returns>
        private List<Spiele> makePlan(string StartTime, int GameLength, int GamePause, List<Tuple<string, int>> lPauses, List<KeyValuePair<string, bool>> lTeams)
        {
            if (lTeams == null || StartTime == "" || GameLength == -1 || GamePause == -1 || lPauses == null) return new List<Spiele>();
            
            //Formate testen
            if (!Regex.IsMatch(StartTime, @"^\d{2}:\d{2}$")) return new List<Spiele>();

            TimeSpan startTime = TimeSpan.Parse(StartTime);
            
            List<string> Teams = new List<string>();
            foreach(var s in lTeams)
            {
                Teams.Add(s.Key);
            }
            

            List<Game> GamePlan = new List<Game>();
            int c = Teams.Count;

            //Spielplan nach Round-Robin system
            for (int i = 1; i < c; i++)
            {
                GamePlan.Add(new Game { Guest = Teams[i - 1], Home = Teams[c - 1] });

                for (int k = 1; k < (Teams.Count / 2); k++)
                {
                    GamePlan.Add(new Game { Guest = Teams[mod((i + k), (c - 1)) != 0 ? mod((i + k), (c - 1)) - 1 : c - 2], Home = Teams[mod((i - k), (c - 1)) != 0 ? mod((i - k), (c - 1)) - 1 : c - 2] });
                }
            }
            
            List<Spiele> sp = new List<Spiele>();

            int pause = GamePause;
            int dauer = GameLength;
            int count = 0;

            foreach (var s in GamePlan)
            {
                sp.Add(new Spiele { Id = count, Time = string.Format(startTime.ToString(@"hh\:mm") + " - " + startTime.Add(TimeSpan.FromMinutes(dauer)).ToString(@"hh\:mm")), Home = s.Home, Guest = s.Guest, GuestGoals = -1, HomeGoals = -1, Played = false, Rating = lTeams.Where(a => a.Key == s.Home).FirstOrDefault().Value == true && lTeams.Where(a => a.Key == s.Guest).FirstOrDefault().Value == true ? true : false });
                
                startTime = startTime.Add(TimeSpan.FromMinutes(dauer + pause));

                if (lPauses.Count > 0)
                {
                    foreach (var l in lPauses)
                    {
                        string zeit = l.Item1.ToString();
                        string länge = l.Item2.ToString();

                        TimeSpan tres = TimeSpan.Parse(zeit);
                        TimeSpan t = tres.Add(TimeSpan.FromMinutes(int.Parse(länge)));

                        if ((tres <= startTime && startTime <= t) || (tres <= startTime.Add(TimeSpan.FromMinutes(dauer)) && startTime.Add(TimeSpan.FromMinutes(dauer)) <= t))
                        {
                            startTime = t;
                        }
                    }
                }
                count++;
            }
            bPlanHasChanged = true;
            return sp;
        }

        /// <summary>
        /// Real modula function
        /// </summary>
        /// <param name="x">Number one</param>
        /// <param name="m">Number two</param>
        /// <returns>modula of these numbers</returns>
        private int mod(int x, int m)
        {
            return (x % m + m) % m;
        }
    }
}
