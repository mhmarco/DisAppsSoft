﻿using AssetsManagement;
using ManejoDeActivos.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ManejoDeActivos
{
    public partial class UserManagment:Form
    {
        UserManagmentController userManagmenteController = new UserManagmentController();
        public UserManagment()
        {
            InitializeComponent();
        }
        

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

       
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        //Gets the information from the text inputs to then add a new user
        private void addUserBtn_Click(object sender, EventArgs e)
        {

            string nameUser = nameUserTxt.Text;
            string username = usernameTxt.Text;
            string password = passwordTxt.Text;
            string userRole = (string) userRolCbx.SelectedItem;

            Boolean usernameFound = userManagmenteController.VerifyUsername(username);

            if (!usernameFound)
            {
                userManagmenteController.CreateUser(nameUser, username, password, userRole);
                outputUserLbl.Text = "";
                ClearForm();
                MessageBox.Show("Usuario Agregado Correctamente");
            }
            else
            {
                outputUserLbl.Text = "Nombre de usuario ya existe";
            }    
        }

        //Allow to clear all text inputs and calls the UpdateUsersTable()
        private void ClearForm()
        {
            nameUserTxt.Text = "";
            usernameTxt.Text = "";
            passwordTxt.Text = "";
            userRolCbx.ResetText();
            userRolCbx.SelectedItem = -1;
            outputUserLbl.Text = "";

            UpdateUsersTable();

        }

        private void UserManagment_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_AssetsManagement_DbModelDataSet.UserEntities' table. You can move, or remove it, as needed.
            this.userEntitiesTableAdapter.Fill(this._AssetsManagement_DbModelDataSet.UserEntities);

        }

        // Allows to refresh the datagrid after inserting new record
        private void UpdateUsersTable()
        {
            using (DbModel db = new DbModel())
            {
                usersTable.DataSource = db.User.ToList<UserEntity>();
            }
        }

        private void RemoveUserBtn_Click(object sender, EventArgs e)
        {
            if (usersTable.SelectedCells.Count > 0)
            {
                int selectedrowindex = usersTable.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = usersTable.Rows[selectedrowindex];
                string a = Convert.ToString(selectedRow.Cells["Usuario"].Value);
                userManagmenteController.RemoveUser(a);
                UpdateUsersTable();
            }
        }
    }
}
