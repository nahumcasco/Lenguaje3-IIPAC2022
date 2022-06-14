using LibreriaCoche;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banco
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Cliente cliente;
        Cuenta cuenta;
        MovimientoCuenta movimientoCuenta;
         
        

        private void CrearCuentaButton_Click(object sender, EventArgs e)
        {
            cliente = new Cliente(IdentidadTextBox.Text, NombreClienteTextBox.Text);

            cuenta = new Cuenta(NumeroCuentaTextBox.Text, cliente, DateTime.Now, 0);

            SaldoTextBox.Text = cuenta.Saldo.ToString("N");


        }

        private void AgregarMovimientoButton_Click(object sender, EventArgs e)
        {
            if (MontoMovimientoTextBox.Text == "")
            {
                errorProvider1.SetError(MontoMovimientoTextBox, "Digite un monto");
                MontoMovimientoTextBox.Focus();
                return;
            }
            if (string.IsNullOrEmpty(TipoMovimientoComboBox.Text))
            {
                errorProvider1.SetError(TipoMovimientoComboBox, "Seleccione un Tipo Movimiento");
                return;
            }

            if (TipoMovimientoComboBox.Text == "Depósito")
            {
                cuenta.Depositar(Convert.ToDecimal(MontoMovimientoTextBox.Text));

                movimientoCuenta = new MovimientoCuenta(cuenta, DateTime.Now,
                                                        Convert.ToDecimal(MontoMovimientoTextBox.Text),
                                                        TipoMovimientoComboBox.Text);

                MovimientosListBox.Items.Add(
                                            "Depósito a la cuenta N. " + cuenta.NumeroCuenta +
                                            " por la cantidad de L. " + movimientoCuenta.Monto +
                                            " con fecha: " + movimientoCuenta.Fecha
                    );

                SaldoTextBox.Text = cuenta.Saldo.ToString("N");
            }
            else if(TipoMovimientoComboBox.Text == "Retiro")
            {
                bool pudoRetirar = cuenta.Retirar(Convert.ToDecimal(MontoMovimientoTextBox.Text));

                if (pudoRetirar)
                {
                    movimientoCuenta = new MovimientoCuenta(cuenta, DateTime.Now, 
                                                            Convert.ToDecimal(MontoMovimientoTextBox.Text),
                                                            TipoMovimientoComboBox.Text);

                    MovimientosListBox.Items.Add(
                                            "Retiro a la cuenta N. " + cuenta.NumeroCuenta +
                                            " por la cantidad de L. " + movimientoCuenta.Monto +
                                            " con fecha: " + movimientoCuenta.Fecha);

                    SaldoTextBox.Text = cuenta.Saldo.ToString("N");

                }
                else
                {
                    MessageBox.Show("La cuenta N. " + cuenta.NumeroCuenta + " no tiene saldo disponible para transaccionar");
                }
            }
        }
    }
}
