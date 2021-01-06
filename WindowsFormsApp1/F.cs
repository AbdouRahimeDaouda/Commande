using System;
using System.Windows.Forms;

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
    }
}