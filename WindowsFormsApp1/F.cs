using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class F : Form
    {
        public F()
        {
            InitializeComponent();
        }

      
      

        private void label6_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void addCdeClt(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                

                e.Handled = true;
                e.SuppressKeyPress = true;
                Client client = new Client();  
                client.ShowDialog();
               
            }
        }

        private void addCdeCltt(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
               
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Ajouter_une_nouvelle_ligne_commande nouvelleLigneCommande = new Ajouter_une_nouvelle_ligne_commande();
            nouvelleLigneCommande.ShowDialog();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void F_Load_1(object sender, EventArgs e)
        {
            Connexion conn = new Connexion();
            string query = "SELECT NumCmd FROM commande WHERE NumCmd=(SELECT max(NumCmd) FROM commande)";
            MySqlCommand commnand = new MySqlCommand(query, conn.getConnection());
            conn.openConnection();
            object result = commnand.ExecuteScalar();
            commnand.ExecuteNonQuery();
            textBox1.Text = result.ToString();
            conn.closeConnection();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Connexion conn = new Connexion();
          
            MySqlCommand commnand = new MySqlCommand("UPDATE `commande` as d set d.DateCommande=@date, d.NumClient=(SELECT c.NumCleint from client as c where c.Nom=@nom and c.Rue=@rue and c.Tel=@tel and c.Ville=@ville and c.CP=@cp) where NumCmd=@ref", conn.getConnection());
            //@nom,@rue,@ville,@cp,@tel
            commnand.Parameters.Add("@nom", MySqlDbType.VarChar).Value = clt.Text;
            commnand.Parameters.Add("@rue", MySqlDbType.VarChar).Value = rue.Text;
            commnand.Parameters.Add("@ville", MySqlDbType.VarChar).Value = ville.Text;
            commnand.Parameters.Add("@cp", MySqlDbType.VarChar).Value = cp.Text;
            commnand.Parameters.Add("@tel", MySqlDbType.VarChar).Value = tel.Text;
            commnand.Parameters.Add("@ref", MySqlDbType.VarChar).Value = textBox1.Text;
            commnand.Parameters.Add("@date", MySqlDbType.VarChar).Value = dateTimePicker1.Value.ToString("yyyy-MM-dd");;
            conn.openConnection();
            commnand.ExecuteNonQuery();
            
            conn.closeConnection();
           
        }
    }
}