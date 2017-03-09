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
	public partial class Prometeusz : Form
	{
		#region Veriables

		List<Person> contactsList = new List<Person>();

		private int selected;
		private int pValue;

		#endregion

		public Prometeusz()
		{
				InitializeComponent();
		}

		private void Address_Book_Load(object sender, EventArgs e)
		{
			#region VerticalList
			ContactListWindow.View = View.Details;
			ContactListWindow.HeaderStyle = ColumnHeaderStyle.None;  //or ContactListWindow.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
			#endregion

			#region CreatingFolderIn%appdata%
			string pathFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			if(!Directory.Exists(pathFolder + "\\Address Book Data"))
				Directory.CreateDirectory(pathFolder + "\\Address Book Data");
			#endregion

			#region CreatingXml/Read

			if (!File.Exists(pathFolder + "\\Address Book Data\\DataBase.xml"))
			{
				XmlTextWriter xwrite = new XmlTextWriter(pathFolder + "\\Address Book Data\\DataBase.xml",Encoding.UTF8);
				xwrite.WriteStartElement("ContactList");
				xwrite.WriteEndElement();
				xwrite.Close();
			}

			AddContact();
			#endregion

			Vis();
			CountUpdate();
		}

		void Vis()
		{
			if (ContactListWindow.Items.Count != 0)
			{
				button2.Visible = true;
				button4.Visible = true;
				button3.Visible = true;
				label3.Visible = true;
				Find.Visible = true;
			}
			else
			{
				button2.Visible = false;
				button4.Visible = false;
				button3.Visible = false;
				label3.Visible = false;
				Find.Visible = false;
			}
		}

		void AddContact()
		{
			string pathFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			XmlDocument xDoc = new XmlDocument();
			xDoc.Load(pathFolder + "\\Address Book Data\\DataBase.xml");
			foreach (XmlNode xNode in xDoc.SelectNodes("ContactList/Contact"))
			{
				Person per = new Person();
				per.FullName = xNode.SelectSingleNode("FullName").InnerText;
				per.Address = xNode.SelectSingleNode("Address").InnerText;
				per.PhoneNumber = xNode.SelectSingleNode("PhoneNumber").InnerText;
				contactsList.Add(per);
				ContactListWindow.Items.Add(per.FullName);
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
			ContactListWindow.SelectedItems.Clear();
			for (int i = 0; i < ContactListWindow.Items.Count; i++)
			{ 

				ContactListWindow.Items[i].ForeColor = Color.Black;
				if (ContactListWindow.Items[i].ToString().ToLower().Contains(Find.Text.ToLower()))
				{
					selected++;
					ContactListWindow.Items[i].ForeColor = Color.Red;
					ContactListWindow.Items[i].Selected = true;

				}

				if (string.IsNullOrWhiteSpace(Find.Text))
				{
					ContactListWindow.Items[i].ForeColor = Color.Black;
				}
			}
			label6.Text = Convert.ToString(selected + "/" + ContactListWindow.Items.Count);
			this.Update();
			selected = 0;

			ListViewItem foundItem =
	ContactListWindow.FindItemWithText(Find.Text, false, 0, true);
			if (foundItem != null)
			{
				ContactListWindow.TopItem = foundItem;
			}

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

			if (string.IsNullOrWhiteSpace(FullName.Text) || Phone.Text == "")
			{
				MessageBox.Show("Empty phone number or name!");
			}
			else
			{
				if (!int.TryParse(Phone.Text, out pValue))
				{
					MessageBox.Show("Number only field!", "Phone Number");
					return;
				}
				contactsList.Add(per);

				ContactListWindow.Items.Add(per.FullName);
				Vis();
				Clear();
				CountUpdate();
				Vis();
			}
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
			Vis();
		}

		void Delete()
		{
			try
			{
				
				contactsList.RemoveAt(ContactListWindow.SelectedItems[0].Index);
				ContactListWindow.Items.Remove(ContactListWindow.SelectedItems[0]);
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
			if (string.IsNullOrWhiteSpace(FullName.Text) || Phone.Text == "")
			{
				MessageBox.Show("Empty phone number or name!");
			}
			else
			{
				if (!int.TryParse(Phone.Text, out pValue))
				{
					MessageBox.Show("Number only field!", "Phone Number");
					return;
				}
				contactsList[ContactListWindow.SelectedItems[0].Index].FullName = FullName.Text;
				contactsList[ContactListWindow.SelectedItems[0].Index].Address = Address.Text;
				contactsList[ContactListWindow.SelectedItems[0].Index].PhoneNumber = Phone.Text;
				ContactListWindow.SelectedItems[0].Text = FullName.Text;
			}
		}

		private void Address_Book_FormClosing(object sender, FormClosingEventArgs e)
		{
			#region SaveToXml

			string pathFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			XmlDocument xDoc = new XmlDocument();
			xDoc.Load(pathFolder + "\\Address Book Data\\DataBase.xml");

			XmlNode xnode = xDoc.SelectSingleNode("ContactList");
			xnode.RemoveAll();

			foreach(Person per in contactsList)
			{
				XmlNode xTitle = xDoc.CreateElement("Contact");
				XmlNode xFullName = xDoc.CreateElement("FullName");
				XmlNode xAddress = xDoc.CreateElement("Address");
				XmlNode xPhoneNumber = xDoc.CreateElement("PhoneNumber");

				xFullName.InnerText = per.FullName;
				xAddress.InnerText = per.Address;
				xPhoneNumber.InnerText = per.PhoneNumber;

				xTitle.AppendChild(xFullName);
				xTitle.AppendChild(xAddress);
				xTitle.AppendChild(xPhoneNumber);
				xDoc.DocumentElement.AppendChild(xTitle);

			}

			xDoc.Save(pathFolder + "\\Address Book Data\\DataBase.xml");
			#endregion

			#region SaveToVCF

			StringBuilder vcf = new StringBuilder();

			foreach (Person per in contactsList)
			{
				string N = string.Join(" ", per.FullName.Split(' ').Reverse());
				vcf.Append("BEGIN:VCARD" + System.Environment.NewLine);
				vcf.Append("VERSION:2.1" + System.Environment.NewLine);
				vcf.Append("N:" + N.Replace(" ", ";") + ";" + System.Environment.NewLine);
				vcf.Append("FN:" + per.FullName + System.Environment.NewLine);
				vcf.Append("TEL;CELL:" + per.PhoneNumber + System.Environment.NewLine);
				vcf.Append("END:VCARD" + System.Environment.NewLine);
			}
			File.WriteAllText(pathFolder + "\\Address Book Data\\myContactsDataBase.vcf", vcf.ToString());

			#region WhatINeed
			//BEGIN:VCARD
			//VERSION:2.1
			//N:;Nazwa_kotaktu;;;
			//FN:Nazwa_kotaktu
			//TEL; CELL:Nr_tel
			//END:VCARD
			#endregion

			#endregion
		}

		private void button4_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = MessageBox.Show("Are you sure?", "Delete all", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				//do something
				//ContactListWindow.Clear(); <- nie może byc bo po usunieciu nie widac kontaktow przy dodawaniu w listview
				ContactListWindow.Items.Clear();
				CountUpdate();
				contactsList.Clear();
				Vis();
			}
			else if (dialogResult == DialogResult.No)
			{
				//do something else
			}
		}
	}
}
