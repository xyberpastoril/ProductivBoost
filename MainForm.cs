using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BeTimelyProject
{
    public partial class MainForm : Form
    {
        #region Attributes
        private int TaskIndex;
        private Routine CurrentRoutine;
        public List<Task> CurrentRoutineTasks { get; private set; }
        private Duration CurrentTimer;
        private int h, m, s;
        #endregion

        #region Controls
        // Root Controls
        private Panel Panel_Routines;
        private PictureBox PictureBox_NoRoutineSelected;
        private Panel Panel_RoutineData;
        private Panel Panel_ActiveRoutine;
        private Timer Timer;

        // Panel_Routines
        private Label Label_RoutinesHeader;
        private ListBox ListBox_Routines;
        private Button Button_CreateRoutine;

        // Panel_RoutineData
        private Label Label_RoutineName;
        private PictureBox PictureBox_NoTasksAvailable;
        private Panel Panel_RoutineTasks;
        private Button Button_DeleteRoutine;
        private Button Button_EditRoutine;
        private Button Button_StartRoutine;

        // Panel_RoutineTasks (Within Panel_RoutineData)
        private Label Label_TotalNumberOfTasks;
        private Label Label_TotalDuration;
        private DataGridView DataGridView_RoutineTasks;

        // Panel_ActiveRoutine (hide Panel_Routines, PictureBox & RoutineData)
        private Label Label_Timer;
        private Label Label_CurrentTaskName;
        private Button Button_PauseRoutine;
        private Button Button_ResumeRoutine;
        private Button Button_SkipNextTask;
        private Button Button_StopRoutine;

        #endregion

        #region ChildForms
        private RoutineForm RoutineForm;
        #endregion

        #region Events


        // Timer
        private void Timer_Tick(object sender, EventArgs e)
        {
            this.CurrentTimer.Tick();
            this.Label_Timer.Text = this.CurrentTimer.ToString();
            if (this.CurrentTimer.TimeUp)
            {
                this.RestoreDuration();
                // Check if there's still next task
                if (IsThereNextTask())
                {
                    this.TaskIndex++;
                    this.LoadTask();
                    if (!IsThereNextTask()) this.Button_SkipNextTask.Enabled = false; 
                }
                else
                    this.StopRoutine();
            }
        }

        // ListBox_Routines
        private void ListBox_Routines_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.ListBox_Routines.SelectedItem == null)
            {
                this.DataGridView_RoutineTasks.DataSource = null;
                this.Panel_RoutineData.Hide();
                this.PictureBox_NoRoutineSelected.Show();
            }
            else
            {
                this.Panel_RoutineData.Show();
                this.PictureBox_NoRoutineSelected.Hide();
                Routine r = (Routine) this.ListBox_Routines.SelectedItem;
                this.Label_RoutineName.Text = r.Name;
                this.Label_TotalNumberOfTasks.Text = "Tasks : " + r.Tasks.Count.ToString();
                this.Label_TotalDuration.Text = "Total Duration: " + r.GetTotalDuration().ToString();
                this.DataGridView_RoutineTasks.DataSource = r.Tasks;
                if(r.Tasks.Count < 1)
                {
                    this.PictureBox_NoTasksAvailable.Show();
                    this.Panel_RoutineTasks.Hide();
                    this.Button_StartRoutine.Enabled = false;
                }
                else
                {
                    this.PictureBox_NoTasksAvailable.Hide();
                    this.Panel_RoutineTasks.Show();
                    this.Button_StartRoutine.Enabled = true;
                }
            }
        }


        // Button_CreateRoutine
        private void Button_CreateRoutine_Click(object sender, EventArgs e)
        {                
            this.RoutineForm.Reset();
            this.RoutineForm.ShowDialog();
        }


        // Button_DeleteRoutine
        private void Button_DeleteRoutine_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this routine? This can't be undone.", "",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if(result == DialogResult.Yes)
            {
                int index = this.ListBox_Routines.SelectedIndex;
                this.ListBox_Routines.ClearSelected();
                this.ListBox_Routines.Items.RemoveAt(index);
                
                if (index == this.ListBox_Routines.Items.Count) index--;
                if (this.ListBox_Routines.Items.Count != 0)
                    this.ListBox_Routines.SelectedIndex = index;
            }
        }


        // Button_EditRoutine
        private void Button_EditRoutine_Click(object sender, EventArgs e)
        {
            this.RoutineForm.Reset();
            this.RoutineForm.PopulateFields((Routine)this.ListBox_Routines.SelectedItem);
            this.RoutineForm.ShowDialog();
        }


        // Button_StartRoutine
        private void Button_StartRoutine_Click(object sender, EventArgs e)
        {
            this.TaskIndex = 0;
            this.CurrentRoutine = (Routine) this.ListBox_Routines.SelectedItem;

            foreach (Task t in this.CurrentRoutine.Tasks)
                this.CurrentRoutineTasks.Add(t);

            this.LoadTask();
            if (!IsThereNextTask()) this.Button_SkipNextTask.Enabled = false;
            else this.Button_SkipNextTask.Enabled = true;

            this.Panel_ActiveRoutine.Show();
            this.Button_PauseRoutine.Show();

            this.Button_ResumeRoutine.Hide();
            this.PictureBox_NoRoutineSelected.Hide();
            this.Panel_RoutineData.Hide();
            this.Panel_Routines.Hide();

            this.Timer.Start();
        }

        // Button_PauseRoutine
        private void Button_PauseRoutine_Click(object sender, EventArgs e)
        {
            this.Timer.Stop();
            this.Button_PauseRoutine.Hide();
            this.Button_ResumeRoutine.Show();
        }


        // Button_ResumeRoutine
        private void Button_ResumeRoutine_Click(object sender, EventArgs e)
        {
            this.Timer.Start();
            this.Button_PauseRoutine.Show();
            this.Button_ResumeRoutine.Hide();
        }


        // Button_SkipNextTask
        private void Button_SkipNextTask_Click(object sender, EventArgs e)
        {
            this.RestoreDuration();
            this.TaskIndex++;
            this.LoadTask();

            if (!IsThereNextTask()) this.Button_SkipNextTask.Enabled = false;
        }


        // Button_StopRoutine
        private void Button_StopRoutine_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you are going to stop the routine?", "", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
                this.StopRoutine();
        }

        // RoutineForm
        private void RoutineForm_Shown(object sender, EventArgs e) => this.RoutineForm.TextBox_RoutineName.Focus();
        
        private void RoutineForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool showDialog = false;

            if(this.RoutineForm.NoClosePrompt == false)
            {
                if (!string.IsNullOrWhiteSpace(this.RoutineForm.TextBox_RoutineName.Text) ||
                    this.RoutineForm.ListBox_Tasks.Items.Count != 0)
                    showDialog = true;
            }
            else
            {
                this.RoutineForm.NoClosePrompt = false; // NEWLY ADDED (For checking)
            }

            if (showDialog == true)
            {
                DialogResult result = MessageBox.Show(
                    "You have unsaved fields. Are you sure to cancel?", "",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                e.Cancel = (result == DialogResult.No);
            }
            else
            {
                e.Cancel = false;
            }
        }

        // Receive data from RoutineForm
        private void RoutineForm_CreateRoutine(Routine r)
        {
            this.ListBox_Routines.Items.Add(r);
            this.ListBox_Routines.SelectedIndex = this.ListBox_Routines.Items.Count - 1;
            this.RoutineForm.Hide();
            this.RoutineForm.NoClosePrompt = false;
        }

        private void RoutineForm_UpdateRoutine(Routine r)
        {
            this.ListBox_Routines.Items[this.ListBox_Routines.SelectedIndex] = r;
            this.RoutineForm.Hide();
            this.RoutineForm.NoClosePrompt = false;
        }

        #endregion

        public MainForm()
        {
            #region Attributes
            this.TaskIndex = 0;
            this.CurrentRoutineTasks = new List<Task>();
            #endregion

            #region Form Properties
            this.Size = new Size(640, 360);
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;

            this.RoutineForm = new RoutineForm();
            this.RoutineForm.Shown += new EventHandler(this.RoutineForm_Shown);
            this.RoutineForm.CreateRoutine += new RoutineDataSentHandler(this.RoutineForm_CreateRoutine);
            this.RoutineForm.UpdateRoutine += new RoutineDataSentHandler(this.RoutineForm_UpdateRoutine);
            this.RoutineForm.FormClosing += new FormClosingEventHandler(this.RoutineForm_FormClosing);
            #endregion

            #region Timer
            this.Timer = new Timer
            {
                Interval = 1000,
                Enabled = false,
            };
            this.Timer.Tick += new EventHandler(this.Timer_Tick);
            #endregion 

            ///
            /// Root Controls
            /// 
            #region Root Controls

            this.Panel_Routines = new Panel
            {
                BackColor = Color.White,
                Size = new Size(240, 360),
            };
            this.Controls.Add(this.Panel_Routines);

            this.PictureBox_NoRoutineSelected = new PictureBox
            {
                Location = new Point(240, 0),
                Size = new Size(400, 360),
                BackColor = Color.Black,
            };
            this.Controls.Add(this.PictureBox_NoRoutineSelected);

            this.Panel_RoutineData = new Panel
            {
                Location = new Point(240, 0),
                Size = new Size(400, 360)
            };
            this.Controls.Add(this.Panel_RoutineData);

            this.Panel_ActiveRoutine = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(this.Width, this.Height),
            };
            this.Controls.Add(this.Panel_ActiveRoutine);

            #endregion

            ///
            /// Panel_Routines
            ///
            #region Panel_Routines            

            this.Label_RoutinesHeader = new Label
            {
                Location = new Point(10, 10),
                Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point),
                Text = "Routines"
            };
            this.Panel_Routines.Controls.Add(this.Label_RoutinesHeader);

            this.ListBox_Routines = new ListBox
            {
                Location = new Point(10, 40),
                Size = new Size(220, 240), // minus button later
                Name = "ListBox_Routines",
                TabIndex = 1
            };
            this.Panel_Routines.Controls.Add(this.ListBox_Routines);
            this.ListBox_Routines.SelectedIndexChanged += new EventHandler(this.ListBox_Routines_SelectedIndexChanged);

            this.Button_CreateRoutine = new Button
            {
                Location = new Point(10, 280),
                Size = new Size(220, 30),
                Text = "Create Routine",
                TabIndex = 2
            };
            this.Panel_Routines.Controls.Add(this.Button_CreateRoutine);
            this.Button_CreateRoutine.Click += new EventHandler(this.Button_CreateRoutine_Click);

            #endregion

            ///
            /// Panel_RoutineData
            ///
            #region Panel_RoutineData

            // Panel Controls
            this.Label_RoutineName = new Label
            {
                Location = new Point(10, 10),
                Size = new Size(this.Panel_RoutineData.Width - 30, 30),
                Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point),
                Text = "Example Routine"
            };
            this.Panel_RoutineData.Controls.Add(this.Label_RoutineName);

            this.PictureBox_NoTasksAvailable = new PictureBox
            {
                Location = new Point(0, 40),
                Size = new Size(400, 230),
                BackColor = Color.Black,
            };
            this.Panel_RoutineData.Controls.Add(this.PictureBox_NoTasksAvailable);

            this.Panel_RoutineTasks = new Panel
            {
                Location = new Point(0, 40),
                Size = new Size(400, 230),
                //BackColor = Color.Red
            };
            this.Panel_RoutineData.Controls.Add(this.Panel_RoutineTasks);

            // this.Button_DeleteRoutine
            this.Button_DeleteRoutine = new Button
            {
                Location = new Point(55, 280),
                Size = new Size(80, 30),
                Text = "Delete",
                TabIndex = 3
            };
            this.Panel_RoutineData.Controls.Add(this.Button_DeleteRoutine);
            this.Button_DeleteRoutine.Click += new EventHandler(this.Button_DeleteRoutine_Click);

            this.Button_EditRoutine = new Button
            {
                Location = new Point(140, 280),
                Size = new Size(80, 30),
                Text = "Edit",
                TabIndex = 4
            };
            this.Panel_RoutineData.Controls.Add(this.Button_EditRoutine);
            this.Button_EditRoutine.Click += new EventHandler(this.Button_EditRoutine_Click);

            this.Button_StartRoutine = new Button
            {
                Location = new Point(225, 280),
                Size = new Size(150, 30),
                Text = "Start Routine",
                TabIndex = 5,
            };
            this.Panel_RoutineData.Controls.Add(this.Button_StartRoutine);
            this.Button_StartRoutine.Click += new EventHandler(Button_StartRoutine_Click);

            #endregion /// Panel_RoutineData

            ///
            /// Panel_RoutineTasks (Inside Panel_RoutineData)
            ///
            #region Panel_RoutineTasks

            this.Label_TotalNumberOfTasks = new Label
            {
                Location = new Point(10, 0),
                Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point),
                Text = "Tasks : 0"
            };
            this.Panel_RoutineTasks.Controls.Add(this.Label_TotalNumberOfTasks);

            this.Label_TotalDuration = new Label
            {
                Location = new Point(180, 0),
                Size = new Size(180, 15),
                Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point),
                Text = "Total Duration : 00:00:00"
            };
            this.Panel_RoutineTasks.Controls.Add(this.Label_TotalDuration);

            this.DataGridView_RoutineTasks = new DataGridView
            {
                Location = new Point(15, 30),
                Size = new Size(360, 200),
                DataSource = null,
                AllowUserToResizeColumns = false,
                AllowUserToResizeRows = false,
                AllowUserToOrderColumns = false,
                RowHeadersVisible = false,
                BackgroundColor = SystemColors.Control,
                GridColor = SystemColors.Control,
                ReadOnly = true,
            };
            this.DataGridView_RoutineTasks.DefaultCellStyle.BackColor = Color.White;
            this.DataGridView_RoutineTasks.DefaultCellStyle.SelectionBackColor = Color.White;
            this.DataGridView_RoutineTasks.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.DataGridView_RoutineTasks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.Panel_RoutineTasks.Controls.Add(this.DataGridView_RoutineTasks);
            #endregion // Panel_RoutineTasks

            ///
            /// Panel_ActiveRoutine
            ///
            #region Panel_ActiveRoutine

            //private Label Label_Timer;
            this.Label_Timer = new Label
            {
                Location = new Point(0, this.Height / 8),
                Size = new Size(this.Width, 112),
                Font = new Font("Segoe UI", 72F, FontStyle.Bold, GraphicsUnit.Point),
                TextAlign = ContentAlignment.MiddleCenter,
                Text = "00:00:00",
            };
            this.Panel_ActiveRoutine.Controls.Add(this.Label_Timer);

            //private Label Label_CurrentTaskName;
            this.Label_CurrentTaskName = new Label
            {
                Location = new Point(0, this.Height - 200),
                Size = new Size(this.Width, 30),
                Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point),
                TextAlign = ContentAlignment.MiddleCenter,
                Text = "1/12: Wake Up",
            };
            this.Panel_ActiveRoutine.Controls.Add(this.Label_CurrentTaskName);

            //private Button Button_PauseRoutine;
            this.Button_PauseRoutine = new Button
            {
                Location = new Point(115, this.Height - 160),
                Size = new Size(150, 30),
                Text = "Pause Routine",
            };
            this.Panel_ActiveRoutine.Controls.Add(this.Button_PauseRoutine);
            this.Button_PauseRoutine.Click += new EventHandler(this.Button_PauseRoutine_Click);


            //private Button Button_ResumeRoutine;
            this.Button_ResumeRoutine = new Button
            {
                Location = new Point(115, this.Height - 160),
                Size = new Size(150, 30),
                Text = "Resume Routine",
            };
            this.Panel_ActiveRoutine.Controls.Add(this.Button_ResumeRoutine);
            this.Button_ResumeRoutine.Click += new EventHandler(this.Button_ResumeRoutine_Click);


            //private Button Button_SkipNextTask;
            this.Button_SkipNextTask = new Button
            {
                Location = new Point(275, this.Height - 160),
                Size = new Size(150, 30),
                Text = "Skip Next Task",
            };
            this.Panel_ActiveRoutine.Controls.Add(this.Button_SkipNextTask);
            this.Button_SkipNextTask.Click += new EventHandler(this.Button_SkipNextTask_Click);


            //private Button Button_StopRoutine;
            this.Button_StopRoutine = new Button
            {
                Location = new Point(435, this.Height - 160),
                Size = new Size(80, 30),
                Text = "Stop",
            };
            this.Panel_ActiveRoutine.Controls.Add(this.Button_StopRoutine);
            this.Button_StopRoutine.Click += new EventHandler(this.Button_StopRoutine_Click);


            #endregion

            #region Test
            this.Panel_ActiveRoutine.Hide();
            this.Panel_RoutineData.Hide();
            this.PictureBox_NoRoutineSelected.Show();

            this.Button_PauseRoutine.Hide();
            #endregion

            //InitializeComponent();
        }

        #region Methods
        private void StopRoutine()
        {
            Timer.Stop();
            this.RestoreDuration();

            this.CurrentRoutineTasks.Clear();
            this.CurrentRoutine = null;

            this.Panel_ActiveRoutine.Hide();

            this.Panel_RoutineData.Show();
            this.Panel_Routines.Show();

            GC.Collect();
        }

        private void LoadTask()
        {
            // Get Current Timer
            this.CurrentTimer = this.CurrentRoutineTasks[TaskIndex].Duration;
            this.Label_Timer.Text = this.CurrentTimer.ToString();

            this.h = this.CurrentTimer.Hours;
            this.m = this.CurrentTimer.Minutes;
            this.s = this.CurrentTimer.Seconds;

            // Get Current Task Name
            this.Label_CurrentTaskName.Text = (this.TaskIndex + 1) + "/" + this.CurrentRoutineTasks.Count + " : " + this.CurrentRoutineTasks[TaskIndex].Name;
        }

        private void RestoreDuration()
        {
            // The if statement ensures that when the routine is already finished
            // and the message box whether to stop the routine still exists, it
            // won't render an error if the user clicked Yes.
            if(this.CurrentRoutineTasks.Count != 0)
            {
                this.CurrentRoutineTasks[TaskIndex].Duration.Hours = this.h;
                this.CurrentRoutineTasks[TaskIndex].Duration.Minutes = this.m;
                this.CurrentRoutineTasks[TaskIndex].Duration.Seconds = this.s;
                this.CurrentRoutineTasks[TaskIndex].Duration.TimeUp = false;
            }
        }

        private bool IsThereNextTask() => this.TaskIndex + 1 < this.CurrentRoutineTasks.Count;
        #endregion
    }
}
