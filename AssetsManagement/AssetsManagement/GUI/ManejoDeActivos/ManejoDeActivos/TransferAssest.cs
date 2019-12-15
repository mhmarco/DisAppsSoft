﻿using AssetsManagement;
using ManejoDeActivos.Controller;
using ManejoDeActivos.Controller.Sanitize;
using ManejoDeActivos.Controller.Sanitize.DefinedSanitizers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManejoDeActivos
{
    public partial class TransferAssest : Form
    {
        AssetManagmentController assetManagmentController = new AssetManagmentController();

        public TransferAssest()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void nameUserTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void TransferAssest_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_AssetsManagement_DbModelDataSet2.AssetTransferHistoryEntities' table. You can move, or remove it, as needed.
            this.assetTransferHistoryEntitiesTableAdapter.Fill(this._AssetsManagement_DbModelDataSet2.AssetTransferHistoryEntities);

        }

        private void TransferAssetBtn_Click(object sender, EventArgs e)
        {
            int labid = labCbx.SelectedIndex;
            int selectedrowindex = assetsTransferTable.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = assetsTransferTable.Rows[selectedrowindex];
            string id = Convert.ToString(selectedRow.Cells[0].Value);
            int fromlab = 0;
            string username = LoginController.currentUser.username;

            User.TransferAsset(id, username, fromlab, labid);

            MessageBox.Show("Activo Transferido Correctamente");


        }
    }
}
