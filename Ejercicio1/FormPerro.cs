using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio1
{
    public partial class FormPerro : Form
    {
        public FormPerro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Instanciar un objeto de la clase Perro

            Perro miPerro = new Perro();

            //Perro miPerro2 = new Perro("Tobi");

            //Perro miPerro3 = new Perro("Benyi", "Pastor", 55);

            miPerro.Nombre = "Benyi";
            miPerro.Raza = "Pastor aleman";
            miPerro.Altura = 50;


            MessageBox.Show(miPerro.Nombre + " es de raza " + miPerro.Raza + " y mide " + 
                miPerro.DevuelveAltura() + " centímetros");



        }
    }
}
