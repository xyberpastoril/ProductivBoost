
namespace ProductivBoostProject
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel_sessions = new System.Windows.Forms.TableLayoutPanel();
            this.label_sessionsHeader = new System.Windows.Forms.Label();
            this.listBox_sessions = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel_sessionButtons = new System.Windows.Forms.TableLayoutPanel();
            this.button_deleteSession = new System.Windows.Forms.Button();
            this.button_createSession = new System.Windows.Forms.Button();
            this.panel_sessionData = new System.Windows.Forms.Panel();
            this.groupBox_taskDetails = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label_tasksHeader = new System.Windows.Forms.Label();
            this.listBox_tasks = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.button_deleteTask = new System.Windows.Forms.Button();
            this.button_createTask = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label_sessionName = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button_sessionPrimary = new System.Windows.Forms.Button();
            this.button_sessionSecondary = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel_sessions.SuspendLayout();
            this.tableLayoutPanel_sessionButtons.SuspendLayout();
            this.panel_sessionData.SuspendLayout();
            this.groupBox_taskDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel_sessions);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel_sessionData);
            this.splitContainer1.Size = new System.Drawing.Size(778, 335);
            this.splitContainer1.SplitterDistance = 217;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel_sessions
            // 
            this.tableLayoutPanel_sessions.ColumnCount = 1;
            this.tableLayoutPanel_sessions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_sessions.Controls.Add(this.label_sessionsHeader, 0, 0);
            this.tableLayoutPanel_sessions.Controls.Add(this.listBox_sessions, 0, 1);
            this.tableLayoutPanel_sessions.Controls.Add(this.tableLayoutPanel_sessionButtons, 0, 2);
            this.tableLayoutPanel_sessions.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel_sessions.Name = "tableLayoutPanel_sessions";
            this.tableLayoutPanel_sessions.RowCount = 3;
            this.tableLayoutPanel_sessions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.169727F));
            this.tableLayoutPanel_sessions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.83028F));
            this.tableLayoutPanel_sessions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel_sessions.Size = new System.Drawing.Size(195, 311);
            this.tableLayoutPanel_sessions.TabIndex = 0;
            // 
            // label_sessionsHeader
            // 
            this.label_sessionsHeader.AutoSize = true;
            this.label_sessionsHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_sessionsHeader.Location = new System.Drawing.Point(3, 0);
            this.label_sessionsHeader.Name = "label_sessionsHeader";
            this.label_sessionsHeader.Size = new System.Drawing.Size(74, 21);
            this.label_sessionsHeader.TabIndex = 4;
            this.label_sessionsHeader.Text = "Sessions ";
            // 
            // listBox_sessions
            // 
            this.listBox_sessions.FormattingEnabled = true;
            this.listBox_sessions.ItemHeight = 15;
            this.listBox_sessions.Location = new System.Drawing.Point(3, 27);
            this.listBox_sessions.Name = "listBox_sessions";
            this.listBox_sessions.Size = new System.Drawing.Size(189, 229);
            this.listBox_sessions.TabIndex = 2;
            // 
            // tableLayoutPanel_sessionButtons
            // 
            this.tableLayoutPanel_sessionButtons.ColumnCount = 2;
            this.tableLayoutPanel_sessionButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_sessionButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_sessionButtons.Controls.Add(this.button_deleteSession, 1, 0);
            this.tableLayoutPanel_sessionButtons.Controls.Add(this.button_createSession, 0, 0);
            this.tableLayoutPanel_sessionButtons.Location = new System.Drawing.Point(3, 273);
            this.tableLayoutPanel_sessionButtons.Name = "tableLayoutPanel_sessionButtons";
            this.tableLayoutPanel_sessionButtons.RowCount = 1;
            this.tableLayoutPanel_sessionButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_sessionButtons.Size = new System.Drawing.Size(189, 35);
            this.tableLayoutPanel_sessionButtons.TabIndex = 0;
            // 
            // button_deleteSession
            // 
            this.button_deleteSession.Location = new System.Drawing.Point(97, 3);
            this.button_deleteSession.Name = "button_deleteSession";
            this.button_deleteSession.Size = new System.Drawing.Size(89, 29);
            this.button_deleteSession.TabIndex = 1;
            this.button_deleteSession.Text = "Delete";
            this.button_deleteSession.UseVisualStyleBackColor = true;
            // 
            // button_createSession
            // 
            this.button_createSession.Location = new System.Drawing.Point(3, 3);
            this.button_createSession.Name = "button_createSession";
            this.button_createSession.Size = new System.Drawing.Size(88, 29);
            this.button_createSession.TabIndex = 0;
            this.button_createSession.Text = "Create";
            this.button_createSession.UseVisualStyleBackColor = true;
            // 
            // panel_sessionData
            // 
            this.panel_sessionData.Controls.Add(this.groupBox_taskDetails);
            this.panel_sessionData.Controls.Add(this.tableLayoutPanel2);
            this.panel_sessionData.Controls.Add(this.textBox1);
            this.panel_sessionData.Controls.Add(this.label_sessionName);
            this.panel_sessionData.Controls.Add(this.tableLayoutPanel1);
            this.panel_sessionData.Location = new System.Drawing.Point(3, 12);
            this.panel_sessionData.Name = "panel_sessionData";
            this.panel_sessionData.Size = new System.Drawing.Size(548, 311);
            this.panel_sessionData.TabIndex = 0;
            // 
            // groupBox_taskDetails
            // 
            this.groupBox_taskDetails.Controls.Add(this.label5);
            this.groupBox_taskDetails.Controls.Add(this.numericUpDown3);
            this.groupBox_taskDetails.Controls.Add(this.label4);
            this.groupBox_taskDetails.Controls.Add(this.numericUpDown2);
            this.groupBox_taskDetails.Controls.Add(this.label3);
            this.groupBox_taskDetails.Controls.Add(this.label2);
            this.groupBox_taskDetails.Controls.Add(this.numericUpDown1);
            this.groupBox_taskDetails.Controls.Add(this.textBox2);
            this.groupBox_taskDetails.Controls.Add(this.label1);
            this.groupBox_taskDetails.Location = new System.Drawing.Point(201, 32);
            this.groupBox_taskDetails.Name = "groupBox_taskDetails";
            this.groupBox_taskDetails.Size = new System.Drawing.Size(340, 224);
            this.groupBox_taskDetails.TabIndex = 5;
            this.groupBox_taskDetails.TabStop = false;
            this.groupBox_taskDetails.Text = "Task Details";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(291, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 19);
            this.label5.TabIndex = 12;
            this.label5.Text = "secs.";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericUpDown3.Location = new System.Drawing.Point(226, 108);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(59, 34);
            this.numericUpDown3.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(179, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 19);
            this.label4.TabIndex = 10;
            this.label4.Text = "mins.";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericUpDown2.Location = new System.Drawing.Point(114, 108);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(59, 34);
            this.numericUpDown2.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(77, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "hrs.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Duration :";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericUpDown1.Location = new System.Drawing.Point(12, 108);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(59, 34);
            this.numericUpDown1.TabIndex = 6;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(10, 46);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(251, 23);
            this.textBox2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name : ";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label_tasksHeader, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.listBox_tasks, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 32);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(195, 279);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // label_tasksHeader
            // 
            this.label_tasksHeader.AutoSize = true;
            this.label_tasksHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_tasksHeader.Location = new System.Drawing.Point(3, 0);
            this.label_tasksHeader.Name = "label_tasksHeader";
            this.label_tasksHeader.Size = new System.Drawing.Size(46, 20);
            this.label_tasksHeader.TabIndex = 4;
            this.label_tasksHeader.Text = "Tasks";
            // 
            // listBox_tasks
            // 
            this.listBox_tasks.FormattingEnabled = true;
            this.listBox_tasks.ItemHeight = 15;
            this.listBox_tasks.Location = new System.Drawing.Point(3, 23);
            this.listBox_tasks.Name = "listBox_tasks";
            this.listBox_tasks.Size = new System.Drawing.Size(189, 199);
            this.listBox_tasks.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.button_deleteTask, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.button_createTask, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 242);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(189, 34);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // button_deleteTask
            // 
            this.button_deleteTask.Location = new System.Drawing.Point(97, 3);
            this.button_deleteTask.Name = "button_deleteTask";
            this.button_deleteTask.Size = new System.Drawing.Size(89, 28);
            this.button_deleteTask.TabIndex = 1;
            this.button_deleteTask.Text = "Delete Task";
            this.button_deleteTask.UseVisualStyleBackColor = true;
            // 
            // button_createTask
            // 
            this.button_createTask.Location = new System.Drawing.Point(3, 3);
            this.button_createTask.Name = "button_createTask";
            this.button_createTask.Size = new System.Drawing.Size(88, 28);
            this.button_createTask.TabIndex = 0;
            this.button_createTask.Text = "Create Task";
            this.button_createTask.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(102, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(272, 23);
            this.textBox1.TabIndex = 3;
            // 
            // label_sessionName
            // 
            this.label_sessionName.AutoSize = true;
            this.label_sessionName.Location = new System.Drawing.Point(6, 6);
            this.label_sessionName.Name = "label_sessionName";
            this.label_sessionName.Size = new System.Drawing.Size(90, 15);
            this.label_sessionName.TabIndex = 2;
            this.label_sessionName.Text = "Session Name : ";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.button_sessionPrimary, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_sessionSecondary, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(315, 273);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(226, 33);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // button_sessionPrimary
            // 
            this.button_sessionPrimary.Location = new System.Drawing.Point(116, 3);
            this.button_sessionPrimary.Name = "button_sessionPrimary";
            this.button_sessionPrimary.Size = new System.Drawing.Size(107, 27);
            this.button_sessionPrimary.TabIndex = 1;
            this.button_sessionPrimary.Text = "Primary";
            this.button_sessionPrimary.UseVisualStyleBackColor = true;
            // 
            // button_sessionSecondary
            // 
            this.button_sessionSecondary.Location = new System.Drawing.Point(3, 3);
            this.button_sessionSecondary.Name = "button_sessionSecondary";
            this.button_sessionSecondary.Size = new System.Drawing.Size(107, 27);
            this.button_sessionSecondary.TabIndex = 0;
            this.button_sessionSecondary.Text = "Secondary";
            this.button_sessionSecondary.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 335);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel_sessions.ResumeLayout(false);
            this.tableLayoutPanel_sessions.PerformLayout();
            this.tableLayoutPanel_sessionButtons.ResumeLayout(false);
            this.panel_sessionData.ResumeLayout(false);
            this.panel_sessionData.PerformLayout();
            this.groupBox_taskDetails.ResumeLayout(false);
            this.groupBox_taskDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_sessions;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_sessionButtons;
        private System.Windows.Forms.Button button_deleteSession;
        private System.Windows.Forms.Button button_createSession;
        private System.Windows.Forms.Panel panel_sessionData;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label_sessionName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button_sessionPrimary;
        private System.Windows.Forms.Button button_sessionSecondary;
        private System.Windows.Forms.Label label_sessionsHeader;
        private System.Windows.Forms.ListBox listBox_sessions;
        private System.Windows.Forms.GroupBox groupBox_taskDetails;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label_tasksHeader;
        private System.Windows.Forms.ListBox listBox_tasks;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button button_deleteTask;
        private System.Windows.Forms.Button button_createTask;
        private System.Windows.Forms.Button s;
    }
}

