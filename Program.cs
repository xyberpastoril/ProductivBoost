using BeTimelyProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductivBoostProject
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Engine e = new Engine();
            e.MainForm.FormClosing += new FormClosingEventHandler(e.MainForm_FormClosing);

            Application.Run(e.MainForm);
            //Application.Run(new SettingsForm());
        }

        
    }

    public class Engine
    {
        public MainForm MainForm;
        public Engine()
        {
            this.MainForm = new MainForm();
        }

        public void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MainForm.CurrentRoutineTasks.Count != 0)
            {
                DialogResult result = MessageBox.Show(
                    "You currently have an active routine. Are you sure to stop and exit program?", "",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                e.Cancel = (result == DialogResult.No);
            }
            else
            {
                e.Cancel = false;
            }
        }
    }
}
