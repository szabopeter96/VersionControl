﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();

        public Form1()
        {
            InitializeComponent();

            InitializeComponent();
            lblFullName.Text = Resource1.FullName; 
            btnAdd.Text = Resource1.Add;
            btnWriting.Text = Resource1.Writing;

            listUsers.DataSource = users;
            listUsers.ValueMember = "ID";
            listUsers.DisplayMember = "FullName";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = txtFullName.Text, //hozzáadás
                
            };
            users.Add(u);
        }

        private void btnWriting_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "txt";
            if (sfd.ShowDialog() != DialogResult.OK) return;
            

            using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
            {
                foreach (var s in users)
                {
                    sw.Write(s.ID);
                    sw.Write(" ");
                    sw.Write(s.FullName);
                }
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            var torol = (User)listUsers.SelectedItem;
            users.Remove(torol);
        }
    }
}
