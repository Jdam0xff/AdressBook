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

namespace AdressBook
{
	public partial class Address_Book : Form
	{
		#region Variables

		static string line;
		static string emptyList = "List is empty...";
		static string addressBook = "AdressBook.txt";

		List<string> allInfo = new List<string>();

		#endregion


		public Address_Book()
		{
			InitializeComponent();
		}

		private void Address_Book_Load(object sender, EventArgs e)
		{
			if (!File.Exists(addressBook))
			{
				ReadTxt();
			}
			else 
			MessageBox.Show("No address book in your folder! \n New address book create if you click ok.");
			
		} 

		private void addListItem(string value)
		{
			contactList.Items.Add(value);
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
			
				allInfo.Add(FullName.Text);
				addListItem(FullName.Text);

				allInfo.Add(Address.Text);

				allInfo.Add(Phone.Text);

			if (string.IsNullOrEmpty(FullName.Text)) FullName.Text = "empty.";
			if (string.IsNullOrEmpty(Address.Text)) Address.Text = "empty.";
			if (string.IsNullOrEmpty(Phone.Text)) Phone.Text = "empty.";

			UpdateNotepad();
			
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (contactList.SelectedItem !=null && contactList.Text != emptyList)
			{
				contactList.Items.RemoveAt(contactList.SelectedIndex);
				allInfo.Remove(FullName.Text);
				allInfo.Remove(Address.Text);
				allInfo.Remove(Phone.Text);
				UpdateNotepad();
			}
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (contactList.SelectedItem != null && contactList.Text != emptyList)
			{
				FullName.Text = contactList.Text;
				//Address.Text = allInfo[contactList.SelectedIndex + 1];
				//Phone.Text = allInfo[contactList.SelectedIndex + 2];
			}
		}

		private void CloseForm(object sender, FormClosingEventArgs e)
		{
			
		}

		private void UpdateNotepad()
		{
			StreamWriter writeFile = new StreamWriter(addressBook);
			foreach(string write in allInfo)
			{
				if (!write.Contains(""))
				{
					writeFile.Write(write);
					writeFile.WriteLine();
				}
			}
			writeFile.Close();
		}

		private void ReadTxt()
		{
			StreamReader readFile = new StreamReader(addressBook);

			try
			{
				while ((line = readFile.ReadLine()) != null)
				{
					allInfo.Add(line);
				}
			}

			finally
			{
				readFile.Close();
			}

			for (int i = 0; i < allInfo.Count; i += 3)
			{
				addListItem(allInfo[i]);
			}
		}
	}
}
