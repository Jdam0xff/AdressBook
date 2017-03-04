namespace AdressBook
{
	partial class Address_Book
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
			this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.Phone = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.Address = new System.Windows.Forms.TextBox();
			this.FullName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.contactList = new System.Windows.Forms.ListBox();
			this.label3 = new System.Windows.Forms.Label();
			this.Find = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// fileSystemWatcher1
			// 
			this.fileSystemWatcher1.EnableRaisingEvents = true;
			this.fileSystemWatcher1.SynchronizingObject = this;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.Phone);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.Address);
			this.groupBox1.Controls.Add(this.FullName);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.button2);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(272, 134);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Info";
			// 
			// Phone
			// 
			this.Phone.Location = new System.Drawing.Point(81, 75);
			this.Phone.Name = "Phone";
			this.Phone.Size = new System.Drawing.Size(171, 20);
			this.Phone.TabIndex = 7;
			this.Phone.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(34, 78);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(41, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Phone:";
			// 
			// Address
			// 
			this.Address.Location = new System.Drawing.Point(81, 50);
			this.Address.Name = "Address";
			this.Address.Size = new System.Drawing.Size(171, 20);
			this.Address.TabIndex = 5;
			this.Address.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
			// 
			// FullName
			// 
			this.FullName.Location = new System.Drawing.Point(81, 24);
			this.FullName.Name = "FullName";
			this.FullName.Size = new System.Drawing.Size(171, 20);
			this.FullName.TabIndex = 4;
			this.FullName.Text = "\r\n";
			this.FullName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(27, 53);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Address:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(18, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(57, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Full Name:";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(177, 101);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 1;
			this.button2.Text = "Delete";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(81, 101);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Add";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click_1);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.contactList);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.Find);
			this.groupBox2.Location = new System.Drawing.Point(290, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(268, 134);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Contact";
			// 
			// contactList
			// 
			this.contactList.FormattingEnabled = true;
			this.contactList.Location = new System.Drawing.Point(69, 55);
			this.contactList.Name = "contactList";
			this.contactList.Size = new System.Drawing.Size(164, 69);
			this.contactList.TabIndex = 7;
			this.contactList.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(33, 31);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(30, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Find:";
			// 
			// Find
			// 
			this.Find.Location = new System.Drawing.Point(69, 28);
			this.Find.Name = "Find";
			this.Find.Size = new System.Drawing.Size(164, 20);
			this.Find.TabIndex = 6;
			this.Find.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
			// 
			// Address_Book
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(571, 161);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "Address_Book";
			this.Text = "Adress Book";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CloseForm);
			this.Load += new System.EventHandler(this.Address_Book_Load);
			((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.IO.FileSystemWatcher fileSystemWatcher1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox Find;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox Address;
		private System.Windows.Forms.TextBox FullName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ListBox contactList;
		private System.Windows.Forms.TextBox Phone;
		private System.Windows.Forms.Label label4;
	}
}

