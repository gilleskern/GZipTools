
namespace GZipTools.Forms
{
    partial class SettingsDlg
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
            this.AESPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblSelectKey = new System.Windows.Forms.Label();
            this.lblKeyID = new System.Windows.Forms.Label();
            this.lblKeyValue = new System.Windows.Forms.Label();
            this.comboBoxSelectKey = new System.Windows.Forms.ComboBox();
            this.textBoxKeyValue = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblKeyAction = new System.Windows.Forms.Label();
            this.textBoxKeyID = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.AESPage.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.AESPage);
            this.tabControl1.Location = new System.Drawing.Point(2, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(624, 553);
            this.tabControl1.TabIndex = 0;
            // 
            // AESPage
            // 
            this.AESPage.Controls.Add(this.tableLayoutPanel1);
            this.AESPage.Location = new System.Drawing.Point(4, 22);
            this.AESPage.Name = "AESPage";
            this.AESPage.Padding = new System.Windows.Forms.Padding(3);
            this.AESPage.Size = new System.Drawing.Size(616, 527);
            this.AESPage.TabIndex = 2;
            this.AESPage.Text = "AES";
            this.AESPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.75954F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.24046F));
            this.tableLayoutPanel1.Controls.Add(this.lblSelectKey, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblKeyID, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblKeyValue, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxSelectKey, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxKeyValue, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblTitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(603, 515);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblSelectKey
            // 
            this.lblSelectKey.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSelectKey.AutoSize = true;
            this.lblSelectKey.Location = new System.Drawing.Point(3, 48);
            this.lblSelectKey.Name = "lblSelectKey";
            this.lblSelectKey.Size = new System.Drawing.Size(58, 13);
            this.lblSelectKey.TabIndex = 0;
            this.lblSelectKey.Text = "Select Key";
            // 
            // lblKeyID
            // 
            this.lblKeyID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblKeyID.AutoSize = true;
            this.lblKeyID.Location = new System.Drawing.Point(3, 78);
            this.lblKeyID.Name = "lblKeyID";
            this.lblKeyID.Size = new System.Drawing.Size(39, 13);
            this.lblKeyID.TabIndex = 1;
            this.lblKeyID.Text = "Key ID";
            // 
            // lblKeyValue
            // 
            this.lblKeyValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblKeyValue.AutoSize = true;
            this.lblKeyValue.Location = new System.Drawing.Point(3, 123);
            this.lblKeyValue.Name = "lblKeyValue";
            this.lblKeyValue.Size = new System.Drawing.Size(55, 13);
            this.lblKeyValue.TabIndex = 2;
            this.lblKeyValue.Text = "Key Value";
            // 
            // comboBoxSelectKey
            // 
            this.comboBoxSelectKey.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxSelectKey.DisplayMember = "Name";
            this.comboBoxSelectKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelectKey.FormattingEnabled = true;
            this.comboBoxSelectKey.Location = new System.Drawing.Point(92, 44);
            this.comboBoxSelectKey.Name = "comboBoxSelectKey";
            this.comboBoxSelectKey.Size = new System.Drawing.Size(327, 21);
            this.comboBoxSelectKey.TabIndex = 4;
            this.comboBoxSelectKey.ValueMember = "Value";
            this.comboBoxSelectKey.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectKey_SelectedIndexChanged);
            // 
            // textBoxKeyValue
            // 
            this.textBoxKeyValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxKeyValue.Location = new System.Drawing.Point(92, 103);
            this.textBoxKeyValue.Multiline = true;
            this.textBoxKeyValue.Name = "textBoxKeyValue";
            this.textBoxKeyValue.Size = new System.Drawing.Size(327, 54);
            this.textBoxKeyValue.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnGenerate);
            this.panel1.Location = new System.Drawing.Point(92, 163);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(508, 34);
            this.panel1.TabIndex = 6;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(222, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(105, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete Key";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(111, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(105, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add/Update Key";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(0, 3);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(105, 23);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "Generate Key";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitle.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblTitle, 2);
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(249, 6);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(105, 20);
            this.lblTitle.TabIndex = 7;
            this.lblTitle.Text = "Manage Keys";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblKeyAction);
            this.panel2.Controls.Add(this.textBoxKeyID);
            this.panel2.Location = new System.Drawing.Point(92, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(508, 24);
            this.panel2.TabIndex = 9;
            // 
            // lblKeyAction
            // 
            this.lblKeyAction.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblKeyAction.AutoSize = true;
            this.lblKeyAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKeyAction.Location = new System.Drawing.Point(333, 5);
            this.lblKeyAction.Name = "lblKeyAction";
            this.lblKeyAction.Size = new System.Drawing.Size(55, 13);
            this.lblKeyAction.TabIndex = 10;
            this.lblKeyAction.Text = "Updated";
            this.lblKeyAction.Visible = false;
            // 
            // textBoxKeyID
            // 
            this.textBoxKeyID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxKeyID.Location = new System.Drawing.Point(0, 2);
            this.textBoxKeyID.Name = "textBoxKeyID";
            this.textBoxKeyID.Size = new System.Drawing.Size(327, 20);
            this.textBoxKeyID.TabIndex = 9;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(458, 571);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(546, 571);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // SettingsDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 606);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsDlg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.tabControl1.ResumeLayout(false);
            this.AESPage.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage AESPage;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblSelectKey;
        private System.Windows.Forms.Label lblKeyID;
        private System.Windows.Forms.Label lblKeyValue;
        private System.Windows.Forms.ComboBox comboBoxSelectKey;
        private System.Windows.Forms.TextBox textBoxKeyValue;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBoxKeyID;
        private System.Windows.Forms.Label lblKeyAction;
    }
}