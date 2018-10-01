using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.IO;

namespace FootballManager
{
    public partial class Form1 : Form
    {
        Manager Manager = null;
        List<KeyValuePair<string, bool>> Teams = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //initalize the tabpages
            tpPlan.Enter += new EventHandler(TpPlan_Enter);
            tpTable.Enter += new EventHandler(TpTable_Enter);

            Teams = new List<KeyValuePair<string, bool>>();
            
            //Import settings
            if(File.Exists("Settings.txt"))
            {
                ImportSettings();
            }

            //Import savefile if exist
            if(Directory.Exists("Saves") && cbLoadLastBackupOnStart.Checked)
            {
                var aveDT = new TimeSpan();
                var path = "";
                var now = DateTime.Now;
                var files = Directory.GetFiles("Saves");
                foreach (var f in files)
                {
                    var tmp = now - File.GetCreationTime(f);
                    if(aveDT == TimeSpan.Zero || tmp < aveDT)
                    {
                        aveDT = tmp;
                        path = f;
                    }
                }
                if (path != "") DoImport(path);
            }
        }

        private void TpTable_Enter(object sender, EventArgs e)
        {
            if (Manager == null) return;

            //if (!Manager.PlanHasChanged()) return;

            lvTable.Items.Clear();

            List<Stats> stats = Manager.GetTable();
            int count = 1;
            foreach (var s in stats)
            {
                ListViewItem lvi = new ListViewItem(count.ToString());
                lvi.SubItems.Add(s.Team);
                lvi.SubItems.Add(s.Games.ToString());
                lvi.SubItems.Add(s.Points.ToString());
                lvi.SubItems.Add(s.GoalsFor.ToString());
                lvi.SubItems.Add(s.GoalsAgainst.ToString());
                lvi.SubItems.Add((s.GoalsFor - s.GoalsAgainst).ToString());
                lvTable.Items.Add(lvi);
                count++;
            }
        }

        private void TpPlan_Enter(object sender, EventArgs e)
        {
            if (Manager == null) return;

            if (!Manager.PlanHasChanged()) return;

            lvSpiele.Items.Clear();

            List<Spiele> games = Manager.GetPlan();
            foreach (var s in games)
            {
                ListViewItem lvi = new ListViewItem(s.Time);
                lvi.Tag = s.Id;
                lvi.SubItems.Add(s.Home);
                lvi.SubItems.Add((s.HomeGoals == -1 ? "__" : s.HomeGoals.ToString()) + ":" + (s.GuestGoals == -1 ? "__" : s.GuestGoals.ToString()));
                lvi.SubItems.Add(s.Guest);
                lvi.SubItems.Add(s.Rating.ToString());
                lvi.BackColor = (s.Played ? Color.LightGray : Color.White);
                lvSpiele.Items.Add(lvi);
            }

            cbFilter.SelectedIndex = cbFilter.Items.Count - 1;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach(var p in System.Diagnostics.Process.GetProcessesByName("excel"))
            {
                if(p.MainWindowTitle == "")
                    p.Close();
            }

            SaveSettings();
            if (!cbCloseBackup.Checked) return;
            if (Manager == null) return;
            if (!System.IO.Directory.Exists("Saves")) System.IO.Directory.CreateDirectory("Saves");
            Manager.SavePlan(SaveFormat.File, @"Saves\Save_" + DateTime.Now.ToString("dd_MM_yyyy-HH_mm_ss") + ".fm");
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string teamName = TextInputPrompt.ShowDialog(this, "Teamname", "Input a name for the team");
            if(teamName != "-1")
            {
                lvTeams.Items.Add(teamName);
                lvTeams.Items[lvTeams.Items.Count - 1].Tag = true;
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvTeams.SelectedItems.Count < 1) return;
            string teamName = TextInputPrompt.ShowDialog(this, "Teamname", "Input a name for the team", lvTeams.SelectedItems[0].Text);
            if (teamName != "-1")
            {
                lvTeams.SelectedItems[0].Text = teamName;
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvTeams.SelectedItems.Count < 1) return;
            lvTeams.Items.RemoveAt(lvTeams.SelectedIndices[0]);
        }

        private void lvTeams_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvTeams.SelectedItems.Count == 1)
            {
                //Check if item has a tag of type bool
                if(!(lvTeams.SelectedItems[0].Tag is bool)) lvTeams.SelectedItems[0].Tag = true;

                if ((bool)lvTeams.SelectedItems[0].Tag == true)
                {
                    lvTeams.SelectedItems[0].Tag = false;
                    lvTeams.SelectedItems[0].BackColor = Color.Gray;
                }
                else
                {
                    lvTeams.SelectedItems[0].Tag = true;
                    lvTeams.SelectedItems[0].BackColor = Color.White;
                }
                lvTeams.SelectedIndices.Clear();
            }
        }

        private void btnCreatePlan_Click(object sender, EventArgs e)
        {
            if (mtbStartTime.Text == "" || mtbGameLength.Text == "" || mtbPauseLength.Text == "")
            {
                MessageBox.Show(this, "There are some empty fields you have to fill!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Teams.Clear();

            foreach (ListViewItem item in lvTeams.Items)
            {
                Teams.Add(new KeyValuePair<string, bool>(item.Text, (bool)item.Tag));
            }

            List<Tuple<string, int>> pauses = new List<Tuple<string, int>>();
            foreach (ListViewItem item in lvPauses.Items)
            {
                pauses.Add(new Tuple<string, int>(item.Text, int.Parse(item.SubItems[1].Text)));
            }

            Manager = new Manager(Teams, mtbStartTime.Text, int.Parse(mtbGameLength.Text), int.Parse(mtbPauseLength.Text), pauses);
            Manager.createPlan();

            lvTable.Items.Clear();
            cbFilter.Items.Clear();
            foreach (var s in Teams)
            {
                cbFilter.Items.Add(s.Key);
            }
            cbFilter.Items.Add("No filter");

            tbMain.SelectedIndex = 1;
            return;
        }

        private void lvSpiele_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                string[] split = lvSpiele.SelectedItems[0].SubItems[2].Text.Split(':');
                int preset1 = int.Parse(split[0] == "__" ? (-1).ToString() : split[0]);
                int preset2 = int.Parse(split[1] == "__" ? (-1).ToString() : split[1]);
                Tuple<int, int> goals = GoalInputPrompt.ShowDialog(this, "Input", "Home      Enemy", preset1 == -1 ? 0 : preset1, preset2 == -1 ? 0 : preset2);

                bool played = true;
                int HGoals = goals.Item1;
                int EGoals = goals.Item2;
                if (goals.Item1 == 878987 || goals.Item2 == 878987)
                {
                    played = false;
                    HGoals = -1;
                    EGoals = -1;
                }

                if (Manager.UpdateGame((int)lvSpiele.SelectedItems[0].Tag, HGoals, EGoals, played))
                {
                    lvSpiele.SelectedItems[0].BackColor = played ? Color.LightGray : Color.White;

                    lvSpiele.SelectedItems[0].SubItems[2].Text = string.Format("{0}:{1}", HGoals == -1 ? "__" : HGoals.ToString(), EGoals == -1 ? "__" : EGoals.ToString());
                }
                else throw new Exception();
            }
            catch
            {
                MessageBox.Show(this, "You typed in the wrong format or an other error occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSavePlan_Click(object sender, EventArgs e)
        {
            if (Manager == null)
            {
                MessageBox.Show(this, "You did not create a plan", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Football manager files (*.fm)|*.fm|Open Document Spreadsheet|*.ods", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    SaveFormat sf = SaveFormat.File;
                    if (sfd.FileName.Contains(".ods"))
                    {
                        sf = SaveFormat.Excel;
                    }
                    bool status = Manager.SavePlan(sf, sfd.FileName);
                    if(status)
                        MessageBox.Show(this, "Save successfull", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show(this, "An error ocurred during the saving process", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnImportPlan_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog sfd = new OpenFileDialog() { Filter = "Football manager files (*.fm)|*.fm", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    DoImport(sfd.FileName);
                }
            }
        }

        private void tsmiDeletePause_Click(object sender, EventArgs e)
        {
            if (lvPauses.SelectedItems.Count == 1)
            {
                lvPauses.Items.RemoveAt(lvPauses.SelectedIndices[0]);
            }
        }

        private void tsmiAddPause_Click(object sender, EventArgs e)
        {
            var timeinput = TimeInputPrompt.ShowDialog(this, "Pauses", "Pause starttime and length in minutes");
            if (timeinput.Item1 != DateTime.MaxValue)
            {
                ListViewItem lvi = new ListViewItem(string.Format("{0:00}:{1:00}", timeinput.Item1.Hour, timeinput.Item1.Minute));
                lvi.SubItems.Add(timeinput.Item2.ToString());
                lvPauses.Items.Add(lvi);
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvSpiele.Items.Clear();

            List<Spiele> plan = Manager.GetPlan();

            foreach (var s in plan)
            {
                if(s.Home == cbFilter.SelectedItem.ToString() || s.Guest == cbFilter.SelectedItem.ToString() || cbFilter.SelectedIndex == cbFilter.Items.Count - 1)
                {
                    ListViewItem lvi = new ListViewItem(s.Time);
                    lvi.Tag = s.Id;
                    lvi.SubItems.Add(s.Home);
                    lvi.SubItems.Add((s.HomeGoals == -1 ? "__" : s.HomeGoals.ToString()) + ":" + (s.GuestGoals == -1 ? "__" : s.GuestGoals.ToString()));
                    lvi.SubItems.Add(s.Guest);
                    lvi.SubItems.Add(s.Rating.ToString());
                    lvi.BackColor = (s.Played ? Color.LightGray : Color.White);
                    lvSpiele.Items.Add(lvi);
                }
            }
        }

        private void btnSaveTable_Click(object sender, EventArgs e)
        {
            if (Manager == null)
            {
                MessageBox.Show(this, "You don't have a table to save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "txt files (*.txt)|*.txt|Open Document Spreadsheet|*.ods", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    SaveFormat sf = SaveFormat.File;
                    if (sfd.FileName.Contains(".ods"))
                    {
                        sf = SaveFormat.Excel;
                    }
                    bool status = Manager.SaveTable(sf, sfd.FileName);
                    if (status)
                        MessageBox.Show(this, "Save successfull", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show(this, "An error ocurred during the saving process", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tmrBackup_Tick(object sender, EventArgs e)
        {
            if (!cbAutoBackup.Checked) return;
            if (Manager == null) return;

            if (!System.IO.Directory.Exists(@"Saves\tmp")) System.IO.Directory.CreateDirectory(@"Saves\tmp");
            Manager.SavePlan(SaveFormat.File, @"Saves\tmp\tmp.fm");
        }
        
        private static Random rng = new Random();
        private void lvTeams_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //Scramble teams
            List<Tuple<string, bool>> names = new List<Tuple<string, bool>>();
            foreach(ListViewItem i in lvTeams.Items)
            {
                names.Add(new Tuple<string, bool> (i.Text, (bool)i.Tag));
            }

            int n = names.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Tuple<string, bool> value = names[k];
                names[k] = names[n];
                names[n] = value;
            }
            lvTeams.Items.Clear();
            foreach(var s in names)
            {
                lvTeams.Items.Add(new ListViewItem(s.Item1) { Tag = s.Item2, BackColor = s.Item2 == true ? Color.White : Color.Gray });
            }
        }

        /// <summary>
        /// Perform the import with the given filename. Checks if the format is correct as well.
        /// This function manipulates the form. 
        /// </summary>
        /// <param name="FileName"></param>
        private void DoImport(string FileName)
        {
            Manager = new Manager();
            if (Manager.ImportPlanFromTxt(FileName))
            {
                lvTeams.Items.Clear();

                Teams = Manager.GetTeams();
                foreach (var s in Teams)
                {
                    lvTeams.Items.Add(s.Key);
                    lvTeams.Items[lvTeams.Items.Count - 1].Tag = s.Value;
                    lvTeams.Items[lvTeams.Items.Count - 1].BackColor = (s.Value ? Color.White : Color.Gray);
                }

                tbMain.SelectedIndex = 1;

                lvTable.Items.Clear();
                cbFilter.Items.Clear();
                foreach (var s in Teams)
                {
                    cbFilter.Items.Add(s.Key);
                }
                cbFilter.Items.Add("No filter");
                cbFilter.SelectedIndex = cbFilter.Items.Count - 1;

                mtbStartTime.Text = Manager.GetStartTime();
                mtbGameLength.Text = Manager.GetGameLength().ToString().PadLeft(2, '0');
                mtbPauseLength.Text = Manager.GetGamePause().ToString().PadLeft(2, '0');

                lvPauses.Items.Clear();
                foreach (var p in Manager.GetPauses())
                {
                    ListViewItem lvi = new ListViewItem(p.Item1);
                    lvi.SubItems.Add(p.Item2.ToString());
                    lvPauses.Items.Add(lvi);
                }
            }
            else
            {
                Manager = null;
                MessageBox.Show(this, "An error occurred while loading the file, could it be in a wrong format?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Save the current settings to a settings.txt file
        /// </summary>
        private void SaveSettings()
        {
            string settings = $"loadLastBackupOnStart = {cbLoadLastBackupOnStart.Checked.ToString()}\n" +
                $"backupOnClosing = {cbCloseBackup.Checked.ToString()}\n" +
                $"autoBackup = {cbAutoBackup.Checked.ToString()}\n";

            File.WriteAllText("Settings.txt", settings);
        }

        /// <summary>
        /// Imports the settings.txt file
        /// </summary>
        private void ImportSettings()
        {
            string[] settings = File.ReadAllLines("Settings.txt");

            foreach (var s in settings)
            {
                string test = s.Split('=')[1].ToLower().Trim();
                bool state = false;
                bool b = Boolean.TryParse(test, out state);

                if (!b) continue;

                if (s.Contains("loadLastBackupOnStart"))
                {
                    cbLoadLastBackupOnStart.Checked = state;
                }
                else if (s.Contains("backupOnClosing"))
                {
                    cbCloseBackup.Checked = state;
                }
                else if (s.Contains("autoBackup"))
                {
                    cbAutoBackup.Checked = state;
                }
            }
        }

    }
}
