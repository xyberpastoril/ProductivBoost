using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BeTimelyProject
{
    public delegate void TaskDataSentHandler(Task t);
    public partial class TaskForm : Form
    {
        #region Attributes
        public bool NoClosePrompt;
        private int h, m, s;
        #endregion

        #region Controls

        // Root Controls
        private ColorDialog ColorDialog;
        private Label Label_TaskName;
        public TextBox TextBox_TaskName;
        private GroupBox GroupBox_Duration;
        private GroupBox GroupBox_Color; // NEW
        private Button Button_Cancel;
        private Button Button_CreateTask;
        private Button Button_UpdateTask;

        // GroupBox_Duration
        public NumericUpDown NumericUpDown_Hours;
        public NumericUpDown NumericUpDown_Minutes;
        public NumericUpDown NumericUpDown_Seconds;
        private Label Label_Hours;
        private Label Label_Minutes;
        private Label Label_Seconds;

        // GroupBox_Color
        private PictureBox PictureBox_Color_Border;
        private PictureBox PictureBox_Color; // NEW
        private Button Button_SelectColor; // NEW

        #endregion

        #region Events

        // Send Data to RoutineForm
        public event TaskDataSentHandler CreateTask;
        public event TaskDataSentHandler UpdateTask;

        // Button_Cancel
        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            bool showDialog = false;

            // Check if everything is blank
            if (!string.IsNullOrWhiteSpace(this.TextBox_TaskName.Text) || 
                this.NumericUpDown_Hours.Value != 0 || this.NumericUpDown_Minutes.Value != 0 || this.NumericUpDown_Seconds.Value != 0)
                    showDialog = true;

            if (showDialog == true)
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

        // Button_CreateTask
        private void Button_CreateTask_Click(object sender, EventArgs e)
        {
            bool hasError = this.ValidateTask();

            if(hasError == false)
            {
                // If Task Name is blank
                if (string.IsNullOrWhiteSpace(this.TextBox_TaskName.Text))
                    this.TextBox_TaskName.Text = "Untitled Task";

                // Set last saved data
                this.h = (int)this.NumericUpDown_Hours.Value;
                this.m = (int)this.NumericUpDown_Minutes.Value;
                this.s = (int)this.NumericUpDown_Seconds.Value;

                this.NoClosePrompt = true;
                this.CreateTask(
                    new Task(
                        this.TextBox_TaskName.Text, 
                        new Duration(
                            (int)this.NumericUpDown_Hours.Value, 
                            (int)this.NumericUpDown_Minutes.Value, 
                            (int)this.NumericUpDown_Seconds.Value
                        ),
                        this.PictureBox_Color.BackColor
                    )
                );
            }
        }

        // Button_UpdateTask
        private void Button_UpdateTask_Click(object sender, EventArgs e)
        {
            bool hasError = this.ValidateTask();

            if(hasError == false)
            {
                // If Task Name is blank
                if (string.IsNullOrWhiteSpace(this.TextBox_TaskName.Text))
                    this.TextBox_TaskName.Text = "Untitled Task";

                // Set last saved data
                this.h = (int)this.NumericUpDown_Hours.Value;
                this.m = (int)this.NumericUpDown_Minutes.Value;
                this.s = (int)this.NumericUpDown_Seconds.Value;

                this.NoClosePrompt = true;
                this.UpdateTask(new Task(
                    this.TextBox_TaskName.Text,
                    new Duration(
                        (int)this.NumericUpDown_Hours.Value,
                        (int)this.NumericUpDown_Minutes.Value,
                        (int)this.NumericUpDown_Seconds.Value
                    ),
                    this.PictureBox_Color.BackColor
                ));
            }
        }

        // Button_SelectColor
        private void Button_SelectColor_Click(object sender, EventArgs e)
        {
            this.ColorDialog.Color = this.PictureBox_Color.BackColor;
            DialogResult colorResult = this.ColorDialog.ShowDialog();

            if(colorResult == DialogResult.OK)
                this.PictureBox_Color.BackColor = this.ColorDialog.Color;
        }

        #endregion

        public TaskForm()
        {
            #region Attributes
            this.NoClosePrompt = false;
            #endregion

            #region Form Properties
            this.Size = new Size(480, 300);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterParent;



            #endregion

            ///
            /// Root Controls
            /// 
            #region Root Controls

            // ColorDialog
            this.ColorDialog = new ColorDialog
            {
                Color = SystemColors.Control,
            };

            // Label_TaskName
            this.Label_TaskName = new Label
            {
                Location = new Point(10, 15),
                Text = "Task Name : "
            };
            this.Controls.Add(this.Label_TaskName);

            // TextBox_TaskName
            this.TextBox_TaskName = new TextBox
            {
                Location = new Point(120, 10),
                Size = new Size(240, 30)
            };
            this.Controls.Add(this.TextBox_TaskName);

            // GroupBox_Duration
            this.GroupBox_Duration = new GroupBox
            {
                Location = new Point(10, 50),
                Size = new Size(445, 80),
                Text = "Duration",
            };
            this.Controls.Add(this.GroupBox_Duration);

            // GroupBox_Color
            this.GroupBox_Color = new GroupBox
            {
                Location = new Point(10, 135),
                Size = new Size(445, 70),
                Text = "Color"
            };
            this.Controls.Add(this.GroupBox_Color);

            // Button_Cancel
            this.Button_Cancel = new Button
            {
                Location = new Point(220, 210),
                Size = new Size(80, 30),
                Text = "Cancel",
            };
            this.Controls.Add(this.Button_Cancel);
            this.Button_Cancel.Click += new EventHandler(this.Button_Cancel_Click);

            // Button_CreateTask
            this.Button_CreateTask = new Button
            {
                Location = new Point(305, 210),
                Size = new Size(150, 30),
                Text = "Create Task",
            };
            this.Controls.Add(this.Button_CreateTask);
            this.Button_CreateTask.Click += new EventHandler(this.Button_CreateTask_Click);

            // Button_UpdateTask
            this.Button_UpdateTask = new Button
            {
                Location = new Point(305, 210),
                Size = new Size(150, 30),
                Text = "Update Task",
            };
            this.Controls.Add(this.Button_UpdateTask);
            this.Button_UpdateTask.Click += new EventHandler(this.Button_UpdateTask_Click);

            #endregion

            #region GroupBox_Duration

            // NumericUpDown_Hours
            this.NumericUpDown_Hours = new NumericUpDown
            {
                Location = new Point(10, 25),
                Size = new Size(80, 50),
                Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point),
                Maximum = 23,
                Minimum = 0,
            };
            this.GroupBox_Duration.Controls.Add(this.NumericUpDown_Hours);

            // Label_Hours
            this.Label_Hours = new Label
            {
                Location = new Point(10 + this.NumericUpDown_Hours.Width, 35),
                Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point),
                Size = new Size(45, 30),
                Text = "hrs."
            };
            this.GroupBox_Duration.Controls.Add(this.Label_Hours);

            // NumericUpDown_Minutes
            this.NumericUpDown_Minutes = new NumericUpDown
            {
                Location = new Point(
                    20 + this.NumericUpDown_Hours.Width + this.Label_Hours.Width, 
                    25),
                Size = new Size(80, 50),
                Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point),
                Maximum = 59,
                Minimum = 0,
            };
            this.GroupBox_Duration.Controls.Add(this.NumericUpDown_Minutes);

            // Label_Minutes
            this.Label_Minutes = new Label
            {
                Location = new Point(
                    20 + this.NumericUpDown_Hours.Width + this.Label_Hours.Width +
                    this.NumericUpDown_Minutes.Width, 
                    35),
                Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point),
                Size = new Size(60, 30),
                Text = "mins."
            };
            this.GroupBox_Duration.Controls.Add(this.Label_Minutes);

            // NumericUpDown_Seconds
            this.NumericUpDown_Seconds = new NumericUpDown
            {
                Location = new Point(
                    30 + this.NumericUpDown_Hours.Width + this.Label_Hours.Width +
                    this.NumericUpDown_Minutes.Width + this.Label_Minutes.Width,
                    25),
                Size = new Size(80, 50),
                Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point),
                Maximum = 59,
                Minimum = 0,
            };
            this.GroupBox_Duration.Controls.Add(this.NumericUpDown_Seconds);
            //this.NumericUpDown_Seconds.ValueChanged += new EventHandler(this.NumericUpDown_Seconds_ValueChanged);
            //this.NumericUpDown_Seconds.KeyPress += new KeyPressEventHandler(this.NumericUpDown_Seconds_KeyPress);

            // Label_Seconds
            this.Label_Seconds = new Label
            {
                Location = new Point(
                    30 + this.NumericUpDown_Hours.Width + this.Label_Hours.Width +
                    this.NumericUpDown_Minutes.Width + this.Label_Minutes.Width +
                    this.NumericUpDown_Seconds.Width,
                    35),
                Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point),
                Size = new Size(60, 30),
                Text = "secs."
            };
            this.GroupBox_Duration.Controls.Add(this.Label_Seconds);

            #endregion

            #region GroupBox_Color

            // PictureBox_Color;
            this.PictureBox_Color = new PictureBox
            {
                Location = new Point(10, 25),
                Size = new Size(30, 30),
                BackColor = SystemColors.Control,
                
            };
            this.GroupBox_Color.Controls.Add(this.PictureBox_Color);

            // PictureBox_Color_Border
            this.PictureBox_Color_Border = new PictureBox
            {
                Location = new Point(8, 23),
                Size = new Size(34, 34),
                BackColor = Color.Black,
            };
            this.GroupBox_Color.Controls.Add(this.PictureBox_Color_Border);


            // Button_SelectColor;
            this.Button_SelectColor = new Button
            {
                Location = new Point(50, 25),
                Size = new Size(150, 30),
                Text = "Select Color",
            };
            this.GroupBox_Color.Controls.Add(this.Button_SelectColor);
            this.Button_SelectColor.Click += new EventHandler(this.Button_SelectColor_Click);

            #endregion

            #region Test
            this.Button_UpdateTask.Hide();
            #endregion

            //InitializeComponent();
        }

        public void Reset()
        {
            // Clear Task Name
            this.TextBox_TaskName.Clear();

            // Set duration to last saved (Look for feedback on this matter)
            this.NumericUpDown_Hours.Value = this.h;
            this.NumericUpDown_Minutes.Value = this.m;
            this.NumericUpDown_Seconds.Value = this.s;

            // Set Color to Control
            this.PictureBox_Color.BackColor = SystemColors.Control;

            // Hide Update Task
            this.Button_UpdateTask.Hide();
            this.Button_CreateTask.Show();

            this.NoClosePrompt = false;

            GC.Collect();
        }

        public void PopulateFields(Task t)
        {
            this.TextBox_TaskName.Text = t.Name;
            this.NumericUpDown_Hours.Value = t.Duration.Hours;
            this.NumericUpDown_Minutes.Value = t.Duration.Minutes;
            this.NumericUpDown_Seconds.Value = t.Duration.Seconds;
            this.PictureBox_Color.BackColor = t.Color;
            this.Button_CreateTask.Hide();
            this.Button_UpdateTask.Show();
        }

        private bool ValidateTask()
        {
            bool hasError = false;
            // If Task Duration is 00:00:00
            if (this.NumericUpDown_Hours.Value == 00 && this.NumericUpDown_Minutes.Value == 00 && this.NumericUpDown_Seconds.Value == 0)
            {
                MessageBox.Show("Please enter a duration at least 1 second.");
                hasError = true;
            }

            return hasError;
        }
    }
}
