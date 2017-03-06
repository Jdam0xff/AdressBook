using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace AdressBook
{
	public partial class Address_Book : Form
	{
		#region Veriables

		List<Person> contactsList = new List<Person>();

		#endregion

		public Address_Book()
		{
				InitializeComponent();
		}

		private void Address_Book_Load(object sender, EventArgs e)
		{
			string pathFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			if(!Directory.Exists(pathFolder + "\\Address Book Data"))
				Directory.CreateDirectory(pathFolder + "\\Address Book Data");
			if (!File.Exists(pathFolder + "\\Address Book Data\\DataBase.txt"))
			{
				
			}
		}

		class Person
		{
			public string FullName
			{
				get;
				set;
			}

			public string Address
			{
				get;
				set;
			}
			public string PhoneNumber
			{
				get;
				set;
			}
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			
		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBox3_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBox4_TextChanged(object sender, EventArgs e)
		{

		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			Person per = new Person();
			per.FullName = FullName.Text;
			per.Address = Address.Text;
			per.PhoneNumber = Phone.Text;
			if (FullName.Text == "")  per.FullName = "empty"; 
			if(Address.Text == "") per.Address = "empty";
			if (Phone.Text == "") per.PhoneNumber = "empty";

			contactsList.Add(per);

			ContactListWindow.Items.Add(per.FullName);

			// Czyszczenie po dodaniu
			Clear();
			CountUpdate();
		}

		void Clear()
		{
			if (checkBox1.Checked == true)
			{
				FullName.Text = "";
				Address.Text = "";
				Phone.Text = "";
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			
			Delete();
			CountUpdate();
			Clear();
		}

		void Delete()
		{
			try
			{
				ContactListWindow.Items.Remove(ContactListWindow.SelectedItems[0]);
				contactsList.RemoveAt(ContactListWindow.SelectedItems[0].Index);

			}
			catch
			{ 

			}
		}

		void CountUpdate()
		{
			label6.Visible = true;
			label6.Text = Convert.ToString(ContactListWindow.Items.Count);
			this.Update();
		}
		

		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ContactListWindow.SelectedItems.Count == 0) return;		// Naprawilo blad z brakiem na liscie
			FullName.Text = contactsList[ContactListWindow.SelectedItems[0].Index].FullName;
			Address.Text = contactsList[ContactListWindow.SelectedItems[0].Index].Address;
			Phone.Text = contactsList[ContactListWindow.SelectedItems[0].Index].PhoneNumber;

		}

		private void button3_Click(object sender, EventArgs e)
		{
			contactsList[ContactListWindow.SelectedItems[0].Index].FullName = FullName.Text;
			contactsList[ContactListWindow.SelectedItems[0].Index].Address = Address.Text;
			contactsList[ContactListWindow.SelectedItems[0].Index].PhoneNumber = Phone.Text;
			ContactListWindow.SelectedItems[0].Text = FullName.Text;
		}

		private void Address_Book_FormClosing(object sender, FormClosingEventArgs e)
		{
			//XmlDocument xDoc = new XmlDocument();
			//string pathFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			//xDoc.Load(pathFolder + "\\Address Book Data\\DataBase.xml");

		}
	}
}
