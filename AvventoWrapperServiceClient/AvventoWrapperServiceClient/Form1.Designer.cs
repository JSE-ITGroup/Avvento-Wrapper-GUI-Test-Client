namespace AvventoWrapperServiceClient
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button7 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblrow = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.ActionQuery = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listBoxSelectedDataTypes = new System.Windows.Forms.ListBox();
            this.listBoxAllDataTypes = new System.Windows.Forms.ListBox();
            this.SelectedDataTypesToAllDataTypes = new System.Windows.Forms.Button();
            this.AllDataTypeToSelectedDataTypes = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBoxSelectedOperations = new System.Windows.Forms.ListBox();
            this.listBoxAllOperations = new System.Windows.Forms.ListBox();
            this.SelectedOpsToAllOps = new System.Windows.Forms.Button();
            this.AllOpsToSelectedOps = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblLoginStatus = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.lblConnection = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 41);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1276, 655);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button7);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.lblrow);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.ActionQuery);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1268, 629);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Manual Test";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(801, 101);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(158, 23);
            this.button7.TabIndex = 22;
            this.button7.Text = "Save Data Download XML";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Submit XML Query Action Below:";
            // 
            // lblrow
            // 
            this.lblrow.AutoSize = true;
            this.lblrow.Location = new System.Drawing.Point(583, 279);
            this.lblrow.Name = "lblrow";
            this.lblrow.Size = new System.Drawing.Size(10, 13);
            this.lblrow.TabIndex = 20;
            this.lblrow.Text = "-";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(642, 201);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Export To CSV";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(642, 150);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(130, 23);
            this.button4.TabIndex = 16;
            this.button4.Text = "Load Template File";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(11, 298);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1241, 260);
            this.dataGridView1.TabIndex = 15;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(642, 101);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(130, 23);
            this.button3.TabIndex = 14;
            this.button3.Text = "Submit Action";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // ActionQuery
            // 
            this.ActionQuery.Location = new System.Drawing.Point(24, 101);
            this.ActionQuery.Multiline = true;
            this.ActionQuery.Name = "ActionQuery";
            this.ActionQuery.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ActionQuery.Size = new System.Drawing.Size(569, 180);
            this.ActionQuery.TabIndex = 12;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button5);
            this.tabPage2.Controls.Add(this.button10);
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1268, 629);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Simulation";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(567, 585);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 5;
            this.button5.Text = "Go";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(1132, 570);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(112, 23);
            this.button10.TabIndex = 4;
            this.button10.Text = "Export Log";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(28, 413);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(1216, 150);
            this.dataGridView2.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listBoxSelectedDataTypes);
            this.groupBox3.Controls.Add(this.listBoxAllDataTypes);
            this.groupBox3.Controls.Add(this.SelectedDataTypesToAllDataTypes);
            this.groupBox3.Controls.Add(this.AllDataTypeToSelectedDataTypes);
            this.groupBox3.Location = new System.Drawing.Point(743, 193);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(501, 205);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Data Download";
            // 
            // listBoxSelectedDataTypes
            // 
            this.listBoxSelectedDataTypes.FormattingEnabled = true;
            this.listBoxSelectedDataTypes.Location = new System.Drawing.Point(341, 40);
            this.listBoxSelectedDataTypes.Name = "listBoxSelectedDataTypes";
            this.listBoxSelectedDataTypes.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxSelectedDataTypes.Size = new System.Drawing.Size(120, 160);
            this.listBoxSelectedDataTypes.TabIndex = 3;
            // 
            // listBoxAllDataTypes
            // 
            this.listBoxAllDataTypes.FormattingEnabled = true;
            this.listBoxAllDataTypes.Location = new System.Drawing.Point(40, 40);
            this.listBoxAllDataTypes.Name = "listBoxAllDataTypes";
            this.listBoxAllDataTypes.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxAllDataTypes.Size = new System.Drawing.Size(120, 160);
            this.listBoxAllDataTypes.TabIndex = 2;
            // 
            // SelectedDataTypesToAllDataTypes
            // 
            this.SelectedDataTypesToAllDataTypes.Location = new System.Drawing.Point(216, 108);
            this.SelectedDataTypesToAllDataTypes.Name = "SelectedDataTypesToAllDataTypes";
            this.SelectedDataTypesToAllDataTypes.Size = new System.Drawing.Size(75, 23);
            this.SelectedDataTypesToAllDataTypes.TabIndex = 1;
            this.SelectedDataTypesToAllDataTypes.Text = "<<";
            this.SelectedDataTypesToAllDataTypes.UseVisualStyleBackColor = true;
            // 
            // AllDataTypeToSelectedDataTypes
            // 
            this.AllDataTypeToSelectedDataTypes.Location = new System.Drawing.Point(216, 65);
            this.AllDataTypeToSelectedDataTypes.Name = "AllDataTypeToSelectedDataTypes";
            this.AllDataTypeToSelectedDataTypes.Size = new System.Drawing.Size(75, 23);
            this.AllDataTypeToSelectedDataTypes.TabIndex = 1;
            this.AllDataTypeToSelectedDataTypes.Text = ">>";
            this.AllDataTypeToSelectedDataTypes.UseVisualStyleBackColor = true;
            this.AllDataTypeToSelectedDataTypes.Click += new System.EventHandler(this.AllDataTypeToSelectedDataTypes_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBoxSelectedOperations);
            this.groupBox2.Controls.Add(this.listBoxAllOperations);
            this.groupBox2.Controls.Add(this.SelectedOpsToAllOps);
            this.groupBox2.Controls.Add(this.AllOpsToSelectedOps);
            this.groupBox2.Location = new System.Drawing.Point(28, 202);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(501, 205);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Order Manipulation";
            // 
            // listBoxSelectedOperations
            // 
            this.listBoxSelectedOperations.FormattingEnabled = true;
            this.listBoxSelectedOperations.Location = new System.Drawing.Point(332, 49);
            this.listBoxSelectedOperations.Name = "listBoxSelectedOperations";
            this.listBoxSelectedOperations.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxSelectedOperations.Size = new System.Drawing.Size(140, 147);
            this.listBoxSelectedOperations.TabIndex = 3;
            // 
            // listBoxAllOperations
            // 
            this.listBoxAllOperations.FormattingEnabled = true;
            this.listBoxAllOperations.Location = new System.Drawing.Point(26, 40);
            this.listBoxAllOperations.Name = "listBoxAllOperations";
            this.listBoxAllOperations.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxAllOperations.Size = new System.Drawing.Size(120, 160);
            this.listBoxAllOperations.TabIndex = 2;
            // 
            // SelectedOpsToAllOps
            // 
            this.SelectedOpsToAllOps.Location = new System.Drawing.Point(216, 108);
            this.SelectedOpsToAllOps.Name = "SelectedOpsToAllOps";
            this.SelectedOpsToAllOps.Size = new System.Drawing.Size(75, 23);
            this.SelectedOpsToAllOps.TabIndex = 1;
            this.SelectedOpsToAllOps.Text = "<<";
            this.SelectedOpsToAllOps.UseVisualStyleBackColor = true;
            this.SelectedOpsToAllOps.Click += new System.EventHandler(this.SelectedOpsToAllOps_Click);
            // 
            // AllOpsToSelectedOps
            // 
            this.AllOpsToSelectedOps.Location = new System.Drawing.Point(216, 65);
            this.AllOpsToSelectedOps.Name = "AllOpsToSelectedOps";
            this.AllOpsToSelectedOps.Size = new System.Drawing.Size(75, 23);
            this.AllOpsToSelectedOps.TabIndex = 1;
            this.AllOpsToSelectedOps.Text = ">>";
            this.AllOpsToSelectedOps.UseVisualStyleBackColor = true;
            this.AllOpsToSelectedOps.Click += new System.EventHandler(this.AllOpsToSelectedOps_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblLoginStatus);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(28, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 168);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Credentials";
            // 
            // lblLoginStatus
            // 
            this.lblLoginStatus.AutoSize = true;
            this.lblLoginStatus.Location = new System.Drawing.Point(193, 144);
            this.lblLoginStatus.Name = "lblLoginStatus";
            this.lblLoginStatus.Size = new System.Drawing.Size(10, 13);
            this.lblLoginStatus.TabIndex = 5;
            this.lblLoginStatus.Text = "-";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(108, 105);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(152, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(22, 139);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(152, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Test Connection";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(108, 68);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(152, 20);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.Text = "P@ssw0rd";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(108, 33);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(152, 20);
            this.txtUserName.TabIndex = 2;
            this.txtUserName.Text = "JSECCAPI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "EndPoint";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "UserName:";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1209, 12);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 19;
            this.button6.Text = "Logout";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // lblConnection
            // 
            this.lblConnection.AutoSize = true;
            this.lblConnection.Location = new System.Drawing.Point(13, 12);
            this.lblConnection.Name = "lblConnection";
            this.lblConnection.Size = new System.Drawing.Size(10, 13);
            this.lblConnection.TabIndex = 13;
            this.lblConnection.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(626, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "-";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 727);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.lblConnection);
            this.Name = "Form1";
            this.Text = "Avvento Service Wrapper Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lblrow;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button3;
        public System.Windows.Forms.Label lblConnection;
        private System.Windows.Forms.TextBox ActionQuery;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button SelectedDataTypesToAllDataTypes;
        private System.Windows.Forms.Button AllDataTypeToSelectedDataTypes;
        private System.Windows.Forms.Button SelectedOpsToAllOps;
        private System.Windows.Forms.Button AllOpsToSelectedOps;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLoginStatus;
        private System.Windows.Forms.ListBox listBoxSelectedDataTypes;
        private System.Windows.Forms.ListBox listBoxAllDataTypes;
        private System.Windows.Forms.ListBox listBoxSelectedOperations;
        private System.Windows.Forms.ListBox listBoxAllOperations;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label5;

    }
}

