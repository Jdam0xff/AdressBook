﻿using System;
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
		private int selected;
		private int pValue;

		#endregion

		public Address_Book()
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
			}
			else
			{
				button2.Visible = false;
				button4.Visible = false;
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

			//dView.RowFilter = string.Format('%{0}%', Find.Text);
			//ContactListWindow.Items.Clear();
			//foreach (Person per in contactsList)
			//{
			//	ContactListWindow.Items.Add(new ListViewItem(new string[] { per.FullName.ToString() }));
			//}

			//ContactListWindow.Items.Clear();

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

				if (Find.Text == "")
				{
					ContactListWindow.Items[i].ForeColor = Color.Black;
				}
			}
			label6.Text = Convert.ToString(selected + "/" + ContactListWindow.Items.Count);
			this.Update();
			selected = 0;
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

			if (FullName.Text == "" || Phone.Text == "")
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
				// Czyszczenie po dodaniu
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

			Console.WriteLine("Tutaj");
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
			//var contactList = new Person() {};
			//var vcf = new StringBuilder();

			//vcf.Append("AddressBook:" + contactList.FullName + System.Environment.NewLine);
			//vcf.Append("AddressBook:" + contactList.Address + System.Environment.NewLine);
			//vcf.Append("AddressBook:" + contactList.PhoneNumber + System.Environment.NewLine);
			//var filename = @"C:\mycontact.vcf";
			//File.WriteAllText(filename, vcf.ToString());
			#endregion
		}

		private void button4_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = MessageBox.Show("Are you sure?", "Delete all", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				//do something
				ContactListWindow.Clear();
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
