using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BeTimelyProject
{
    public delegate void RoutineDataSentHandler(Routine r);
    public partial class RoutineForm : Form
    {
        #region Attributes
        private readonly string TaskToStringDetails = "{0, -11}{1, -80}";
        public bool NoClosePrompt;
        #endregion

        #region Controls
        private Label Label_RoutineName;
        public TextBox TextBox_RoutineName;
        private GroupBox GroupBox_Tasks;
        private Button Button_Cancel;
        private Button Button_CreateRoutine;
        private Button Button_UpdateRoutine;

        // GroupBox_Tasks
        private Label Label_TasksHeader;
        public ListBox ListBox_Tasks;
        private Button Button_CreateTask;
        private Button Button_EditTask;
        private Button Button_MoveUpTask;
        private Button Button_MoveDownTask;
        private Button Button_DeleteTask;

        #endregion

        #region ChildForms
        private TaskForm TaskForm;
        #endregion

        #region Events

        // Send Data to MainForm
        public event RoutineDataSentHandler CreateRoutine;
        public event RoutineDataSentHandler UpdateRoutine;


        // Button_Cancel
        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            // Slightly different implementation of FormClosing.

            bool showDialog = false;

            // Check if everything is blank
            if (!string.IsNullOrWhiteSpace(this.TextBox_RoutineName.Text) ||
                this.ListBox_Tasks.Items.Count != 0)
                showDialog = true;

            if(showDialog == true)
            {
                DialogResult result = MessageBox.Show(
                    "You have unsaved fields. Are you sure to cancel?",
                    "",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    this.NoClosePrompt = true;
                    this.Hide();
                }
            }
            else
            {
                this.Hide();
            }
        }

        // Button_CreateRoutine
        private void Button_CreateRoutine_Click(object sender, EventArgs e)
        {
            // Prevents Unsaved Dialog from appearing on FormClosing Event
            this.NoClosePrompt = true;

            // If Routine Name is blank
            if (string.IsNullOrWhiteSpace(this.TextBox_RoutineName.Text))
                this.TextBox_RoutineName.Text = "Untitled Routine";

            Routine r = new Routine(this.TextBox_RoutineName.Text);

            foreach(Task t in this.ListBox_Tasks.Items)
                r.Tasks.Add(t);

            this.CreateRoutine(r);
        }

        // Button_UpdateRoutine
        private void Button_UpdateRoutine_Click(object sender, EventArgs e)
        {
            // Prevents Unsaved Dialog from appearing on FormClosing Event
            this.NoClosePrompt = true;

            // If Routine Name is blank
            if (string.IsNullOrWhiteSpace(this.TextBox_RoutineName.Text))
                this.TextBox_RoutineName.Text = "Untitled Routine";

            Routine r = new Routine(this.TextBox_RoutineName.Text);

            foreach (Task t in this.ListBox_Tasks.Items)
                r.Tasks.Add(t);

            this.UpdateRoutine(r);
        }

        // ListBox_Tasks
        private void ListBox_Tasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if(this.ListBox_Tasks.SelectedItem == null)
            {
                this.Button_EditTask.Enabled = false;
                this.Button_MoveUpTask.Enabled = false;
                this.Button_MoveDownTask.Enabled = false;
                this.Button_DeleteTask.Enabled = false;
            }
            else
            {
                this.Button_EditTask.Enabled = true;
                this.Button_MoveUpTask.Enabled = true;
                this.Button_MoveDownTask.Enabled = true;
                this.Button_DeleteTask.Enabled = true;
            }

            
        }

        // Button_CreateTask
        private void Button_CreateTask_Click(object sender, EventArgs e)
        {                
            this.TaskForm.Reset();
            this.TaskForm.ShowDialog();
        }

        // Button_EditTask
        private void Button_EditTask_Click(object sender, EventArgs e)
        {
            this.TaskForm.Reset();
            this.TaskForm.PopulateFields((Task) this.ListBox_Tasks.SelectedItem);
            this.TaskForm.ShowDialog();
        }

        // Button_MoveUpTask
        private void Button_MoveUpTask_Click(object sender, EventArgs e)
        {
            int selectedIndex = this.ListBox_Tasks.SelectedIndex;
            if (selectedIndex > 0)
            {
                this.ListBox_Tasks.Items.Insert(selectedIndex - 1, this.ListBox_Tasks.Items[selectedIndex]);
                this.ListBox_Tasks.Items.RemoveAt(selectedIndex + 1);
                this.ListBox_Tasks.SelectedIndex = selectedIndex - 1;
            }
        }

        // Button_MoveDownTask
        private void Button_MoveDownTask_Click(object sender, EventArgs e)
        {
            int selectedIndex = this.ListBox_Tasks.SelectedIndex;
            if (selectedIndex < this.ListBox_Tasks.Items.Count - 1 & selectedIndex != -1)
            {
                this.ListBox_Tasks.Items.Insert(selectedIndex + 2, this.ListBox_Tasks.Items[selectedIndex]);
                this.ListBox_Tasks.Items.RemoveAt(selectedIndex);
                this.ListBox_Tasks.SelectedIndex = selectedIndex + 1;
            }
        }

        // Button_DeleteTask
        private void Button_DeleteTask_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this task?", "",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int index = this.ListBox_Tasks.SelectedIndex;
                this.ListBox_Tasks.ClearSelected();
                this.ListBox_Tasks.Items.RemoveAt(index);

                if (index == this.ListBox_Tasks.Items.Count) index--;
                if (this.ListBox_Tasks.Items.Count != 0)
                    this.ListBox_Tasks.SelectedIndex = index;
            }
        }

        // TaskForm
        private void TaskForm_Shown(object sender, EventArgs e) => this.TaskForm.TextBox_TaskName.Focus();

        private void TaskForm_CreateTask(Task t)
        {
            this.ListBox_Tasks.Items.Add(t);
            this.ListBox_Tasks.SelectedIndex = this.ListBox_Tasks.Items.Count - 1;
            this.TaskForm.Hide();
        }

        private void TaskForm_UpdateTask(Task t)
        {
            this.ListBox_Tasks.Items[this.ListBox_Tasks.SelectedIndex] = t;
            this.TaskForm.Hide();
        }

        private void TaskForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool showDialog = false;

            if(this.TaskForm.NoClosePrompt == false)
            {
                if (!string.IsNullOrWhiteSpace(this.TaskForm.TextBox_TaskName.Text) ||
                    this.TaskForm.NumericUpDown_Hours.Value != 0 || 
                    this.TaskForm.NumericUpDown_Minutes.Value != 0 
                    || this.TaskForm.NumericUpDown_Seconds.Value != 0)
                    showDialog = true;
            }
            else
            {
                this.TaskForm.NoClosePrompt = false;
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


        #endregion

        public RoutineForm()
        {
            #region Attributes
            this.NoClosePrompt = false;
            #endregion

            #region Form Properties
            this.Size = new Size(480, 440);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterParent;

            this.TaskForm = new TaskForm();
            this.TaskForm.Shown += new EventHandler(this.TaskForm_Shown);
            this.TaskForm.CreateTask += this.TaskForm_CreateTask;
            this.TaskForm.UpdateTask += this.TaskForm_UpdateTask;
            this.TaskForm.FormClosing += this.TaskForm_FormClosing;
            #endregion

            ///
            /// Root Controls
            ///
            #region Root Controls

            // Label_RoutineName
            this.Label_RoutineName = new Label
            {
                Location = new Point(10, 15),
                Text = "Routine Name : "
            };
            this.Controls.Add(this.Label_RoutineName);

            // TextBox_RoutineName;
            this.TextBox_RoutineName = new TextBox
            {
                Location = new Point(120, 10),
                Size = new Size(240, 30)
            };
            this.Controls.Add(this.TextBox_RoutineName);

            // GroupBox_Tasks
            this.GroupBox_Tasks = new GroupBox
            {
                Location = new Point(10, 50),
                Size = new Size(445, 295),
                Text = "Tasks",
            };
            this.Controls.Add(this.GroupBox_Tasks);

            // Button_Cancel;
            this.Button_Cancel = new Button
            {
                Location = new Point(220, 360),
                Size = new Size(80, 30),
                Text = "Cancel",
            };
            this.Controls.Add(this.Button_Cancel);
            this.Button_Cancel.Click += new EventHandler(this.Button_Cancel_Click);

            // Button_CreateRoutine
            this.Button_CreateRoutine = new Button
            {
                Location = new Point(305, 360),
                Size = new Size(150, 30),
                Text = "Create Routine",
            };
            this.Controls.Add(this.Button_CreateRoutine);
            this.Button_CreateRoutine.Click += new EventHandler(this.Button_CreateRoutine_Click);

            // Button_UpdateRoutine
            this.Button_UpdateRoutine = new Button
            {
                Location = new Point(305, 360),
                Size = new Size(150, 30),
                Text = "Update Routine",
            };
            this.Controls.Add(this.Button_UpdateRoutine);
            this.Button_UpdateRoutine.Click += new EventHandler(this.Button_UpdateRoutine_Click);


            #endregion

            /// 
            /// GroupBox_Tasks
            ///
            #region GroupBox_Tasks

            // Label_TasksHeader
            this.Label_TasksHeader = new Label
            {
                Location = new Point(15, 30),
                Size = new Size(300, 15),
                Text = string.Format(this.TaskToStringDetails, "Duration", "Task Name [Color]"),
            };
            this.GroupBox_Tasks.Controls.Add(this.Label_TasksHeader);
            
            // ListBox_Tasks;
            this.ListBox_Tasks = new ListBox
            {
                Location = new Point(15, 50),
                Size = new Size(300, 230),
            };
            this.GroupBox_Tasks.Controls.Add(this.ListBox_Tasks);
            this.ListBox_Tasks.SelectedIndexChanged += new EventHandler(this.ListBox_Tasks_SelectedIndexChanged);

            // Button_CreateTask
            this.Button_CreateTask = new Button
            {
                Location = new Point(320, 49),
                Size = new Size(110, 30),
                Text = "Create",
            };
            this.GroupBox_Tasks.Controls.Add(this.Button_CreateTask);
            this.Button_CreateTask.Click += new EventHandler(this.Button_CreateTask_Click);

            // Button_EditTask
            this.Button_EditTask = new Button
            {
                Location = new Point(320, 84),
                Size = new Size(110, 30),
                Text = "Edit",
            };
            this.GroupBox_Tasks.Controls.Add(this.Button_EditTask);
            this.Button_EditTask.Click += new EventHandler(this.Button_EditTask_Click);

            // Button_MoveUpTask
            this.Button_MoveUpTask = new Button
            {
                Location = new Point(320, 119),
                Size = new Size(110, 30),
                Text = "Move Up",
            };
            this.GroupBox_Tasks.Controls.Add(this.Button_MoveUpTask);
            this.Button_MoveUpTask.Click += new EventHandler(this.Button_MoveUpTask_Click);

            // Button_MoveDownTask
            this.Button_MoveDownTask = new Button
            {
                Location = new Point(320, 154),
                Size = new Size(110, 30),
                Text = "Move Down",
            };
            this.GroupBox_Tasks.Controls.Add(this.Button_MoveDownTask);
            this.Button_MoveDownTask.Click += new EventHandler(this.Button_MoveDownTask_Click);

            // Button_DeleteTask
            this.Button_DeleteTask = new Button
            {
                Location = new Point(320, 189),
                Size = new Size(110, 30),
                Text = "Delete",
            };
            this.GroupBox_Tasks.Controls.Add(this.Button_DeleteTask);
            this.Button_DeleteTask.Click += new EventHandler(this.Button_DeleteTask_Click);


            #endregion

            #region Test
            
            #endregion

            //InitializeComponent();
        }

        #region Methods
        public void Reset()
        {
            // Clear Routine Name
            this.TextBox_RoutineName.Clear();

            // Clear ListBox_Tasks & Disable List Buttons (Except Create)
            this.ListBox_Tasks.Items.Clear();
            this.Button_EditTask.Enabled = false;
            this.Button_MoveUpTask.Enabled = false;
            this.Button_MoveDownTask.Enabled = false;
            this.Button_DeleteTask.Enabled = false;

            // Hide Button_UpdateRoutine
            this.Button_UpdateRoutine.Hide();
            this.Button_CreateRoutine.Show();

            this.NoClosePrompt = false;

            GC.Collect();
        }

        public void PopulateFields(Routine r)
        {
            this.TextBox_RoutineName.Text = r.Name;
            foreach (Task t in r.Tasks)
                ListBox_Tasks.Items.Add(t);
            this.Button_CreateRoutine.Hide();
            this.Button_UpdateRoutine.Show();
        }
        #endregion
    }
}
