using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BeTimelyProject
{
    public delegate void SettingsDataSentHandler(Setting s);
    public partial class SettingsForm : Form
    {
        #region Controls
        // Root Controls
        private GroupBox GroupBox_Settings;
        private Button Button_Cancel;
        private Button Button_Save;

        // GroupBox_Settings
        private CheckBox CheckBox_SwitchToFront;
        private Label Label_SwitchToFront;
        private CheckBox CheckBox_PositionOnFront;
        #endregion

        #region Events
        // Send data to MainForm
        public event SettingsDataSentHandler SaveSettings;

        // private void Button_Cancel
        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        // private void Button_Save
        private void Button_Save_Click(object sender, EventArgs e)
        {
            this.SaveSettings(new Setting(this.CheckBox_SwitchToFront.Checked, this.CheckBox_PositionOnFront.Checked));
        }

        #endregion

        public SettingsForm()
        {
            #region Form Properties
            this.Name = "Settings";
            this.Size = new Size(500, 230);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            #endregion

            #region Root Controls
            //private GroupBox GroupBox_Settings;
            this.GroupBox_Settings = new GroupBox
            {
                Text = "Settings",
                Location = new Point(10, 10),
                Size = new Size(460, 130),
            };
            this.Controls.Add(this.GroupBox_Settings);

            //private Button Button_Cancel;
            this.Button_Cancel = new Button
            {
                Text = "Cancel",
                Location = new Point(this.Width - 235, 150),
                Size = new Size(100, 30),
            };
            this.Controls.Add(this.Button_Cancel);
            this.Button_Cancel.Click += Button_Cancel_Click;

            //private Button Button_Save;
            this.Button_Save = new Button
            {
                Text = "Save",
                Location = new Point(this.Width - 130, 150),
                Size = new Size(100, 30),
            };
            this.Controls.Add(this.Button_Save);
            this.Button_Save.Click += Button_Save_Click;

            #endregion

            #region GroupBox_Settings
            //private CheckBox CheckBox_SwitchToFront;
            this.CheckBox_SwitchToFront = new CheckBox
            {
                Text = "Switch Application to front when current task's duration is fully consumed.",
                Location = new Point(10, 25),
                Size = new Size(420, 18),
            };
            this.GroupBox_Settings.Controls.Add(this.CheckBox_SwitchToFront);

            this.Label_SwitchToFront = new Label
            {
                Text = "Leaving this unchecked will use Windows Native Notifications. \nMake sure your device is not in silent mode.",
                Location = new Point(25, 50),
                Size = new Size(395, 36),
            };
            this.GroupBox_Settings.Controls.Add(this.Label_SwitchToFront);

            //private CheckBox CheckBox_PositionOnFront;
            this.CheckBox_PositionOnFront = new CheckBox
            {
                Text = "Position Application on top of other windows when running a routine.",
                Location = new Point(10, 90),
                Size = new Size(420, 18),
            };
            this.GroupBox_Settings.Controls.Add(this.CheckBox_PositionOnFront);

            #endregion
            //InitializeComponent();
        }

        public void SetFields(Setting s)
        {
            this.CheckBox_PositionOnFront.Checked = s.PositionOnFront;
            this.CheckBox_SwitchToFront.Checked = s.SwitchToFront;
        }
    }
}
