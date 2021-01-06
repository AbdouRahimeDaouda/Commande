﻿using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Ajouter_une_nouvelle_ligne_commande : Form
    {
        public Ajouter_une_nouvelle_ligne_commande()
        {
            InitializeComponent();
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                

                e.Handled = true;
                e.SuppressKeyPress = true;
                Ligne_de_Cde ligne = new Ligne_de_Cde(); 
                ligne.ShowDialog();
               
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
               
            }
        }
        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);

        public event UpdateDelegate UpdateEventHandler;

        public class UpdateEventArgs: EventArgs
        {
            public string Data { get; set; }
        }
        protected void insert()
        {
            UpdateEventArgs args = new UpdateEventArgs();
            UpdateEventHandler.Invoke(this, args);
        }
        private void button4_Click(object sender, EventArgs e)
        {

                Connexion conn = new Connexion();
          
                MySqlCommand commnand = new MySqlCommand("INSERT INTO `lignecommande`(`CodeProduit`, `Qte`, `Prix`) VALUES (@codeP, @qte, @prix)", conn.getConnection());
                
                commnand.Parameters.Add("@codeP", MySqlDbType.VarChar).Value = codeP.Text;
                commnand.Parameters.Add("@qte", MySqlDbType.VarChar).Value = qte.Text;
                commnand.Parameters.Add("@prix", MySqlDbType.VarChar).Value = prix.Text;

                conn.openConnection();
                commnand.ExecuteNonQuery();
                insert();
                conn.closeConnection();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}