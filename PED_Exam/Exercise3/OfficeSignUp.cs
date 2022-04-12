using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise3
{
    public partial class OfficeSignUp : Base
    {
        public static Hashtable AdjacencyHash = new();
        public static Vertex[] VertexValues = new Vertex[8];
        public static Graph GraphValues = new();
        public List<string> IdValues = new();

        public static int I = 0;

        public OfficeSignUp()
        {
            InitializeComponent();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (txtAddress.Text == "" || txtCode.Text == "" || txtContact.Text == "" || txtEmail.Text == "" ||
                    txtResponsible.Text == "" || txtCode.Text == "a")
                {
                    MessageBox.Show("Lo siento, debes llenar todos los campos antes de darle continuar.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!Valid())
                {
                    MessageBox.Show("Lo siento, el código de cada sucursal debe ser único.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (I < 8)
                {
                    IdValues.Add(txtCode.Text);
                    VertexValues[I] = new Vertex(new Office(txtAddress.Text, txtCode.Text, txtResponsible.Text,
                        int.Parse(txtContact.Text), txtEmail.Text));

                    MessageBox.Show($"Valores añadidos o actualizados con éxito a la Sucursal N° {I + 1}!", "Exito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Iterator();
                }

                if (I == 8)
                    Iterator();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hubo un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void Iterator()
        {
            if (I == 8)
            {
                btnContinue.Visible = false;
                btnConsultar.Visible = true;
                // añado los valores de mis vértices al grafo, lo pude haber hecho directamente a la hora de pedir los datos pero, considero que es un poco más cómodo todos de una vez.
                for (int i = 0; i <= 7; i++)
                    GraphValues.AddVertex(VertexValues[i]);
            }
            else
            {
                I++;
                if (I != 8)
                {
                    lblSucursal.Text = $"Sucursal N° {I + 1}";
                    Clear();
                }

            }

        }

        private void CreateArcs() // los he creado de forma Manual y por medio de listas ya que a la hora de crearlo en una tabla Hash, necesito filtrarlo por llaves.
        {
            // Arcos (Aristas) de la sucursal 1. (de acuerdo al gráfico)
            #region Arcos sucursal 1
            VertexValues[0].AddArc(new Arc(VertexValues[0], VertexValues[0], 0)); // 2
            VertexValues[0].AddArc(new Arc(VertexValues[0], VertexValues[1], 3)); // 2
            VertexValues[0].AddArc(new Arc(VertexValues[0], VertexValues[2], 0)); // 3
            VertexValues[0].AddArc(new Arc(VertexValues[0], VertexValues[3], 0)); // 4
            VertexValues[0].AddArc(new Arc(VertexValues[0], VertexValues[4], 8)); // 5
            VertexValues[0].AddArc(new Arc(VertexValues[0], VertexValues[5], 2)); // 6
            VertexValues[0].AddArc(new Arc(VertexValues[0], VertexValues[6], 8)); // 7
            VertexValues[0].AddArc(new Arc(VertexValues[0], VertexValues[7], 0)); // 8
            #endregion // usé una región solo para que no se viera tan lleno el code :P

            // Arcos (Aristas) de la sucursal 2.
            #region Arcos sucursal 2
            VertexValues[1].AddArc(new Arc(VertexValues[1], VertexValues[0], 3)); // 2 -> 1
            VertexValues[1].AddArc(new Arc(VertexValues[1], VertexValues[1], 0)); // 2 -> 1
            VertexValues[1].AddArc(new Arc(VertexValues[1], VertexValues[2], 5)); // 2 a 3
            VertexValues[1].AddArc(new Arc(VertexValues[1], VertexValues[3], 4)); // 2 a 4.
            VertexValues[1].AddArc(new Arc(VertexValues[1], VertexValues[4], 0)); // 2 a 5.
            VertexValues[1].AddArc(new Arc(VertexValues[1], VertexValues[5], 0)); // 2 a 6.
            VertexValues[1].AddArc(new Arc(VertexValues[1], VertexValues[7], 0)); // 2 a 8.
            #endregion

            // Arcos (Aristas) de la sucursal 3.
            #region Arcos sucursal 3
            VertexValues[2].AddArc(new Arc(VertexValues[2], VertexValues[0], 0));
            VertexValues[2].AddArc(new Arc(VertexValues[2], VertexValues[1], 5));
            VertexValues[2].AddArc(new Arc(VertexValues[2], VertexValues[2], 0));
            VertexValues[2].AddArc(new Arc(VertexValues[2], VertexValues[3], 0));
            VertexValues[2].AddArc(new Arc(VertexValues[2], VertexValues[4], 0));
            VertexValues[2].AddArc(new Arc(VertexValues[2], VertexValues[5], 0));
            VertexValues[2].AddArc(new Arc(VertexValues[2], VertexValues[6], 0));
            VertexValues[2].AddArc(new Arc(VertexValues[2], VertexValues[7], 9));
            #endregion

            // Arcos (Aristas) de la sucursal 4.
            #region Arcos sucursal 4
            VertexValues[3].AddArc(new Arc(VertexValues[3], VertexValues[0], 0));
            VertexValues[3].AddArc(new Arc(VertexValues[3], VertexValues[1], 4));
            VertexValues[3].AddArc(new Arc(VertexValues[3], VertexValues[2], 0));
            VertexValues[3].AddArc(new Arc(VertexValues[3], VertexValues[3], 0));
            VertexValues[3].AddArc(new Arc(VertexValues[3], VertexValues[4], 5));
            VertexValues[3].AddArc(new Arc(VertexValues[3], VertexValues[5], 0));
            VertexValues[3].AddArc(new Arc(VertexValues[3], VertexValues[6], 0));
            VertexValues[3].AddArc(new Arc(VertexValues[3], VertexValues[7], 0));
            #endregion

            // Arcos (Aristas) de la sucursal 5.
            #region Arcos sucursal 5
            VertexValues[4].AddArc(new Arc(VertexValues[4], VertexValues[0], 8));
            VertexValues[4].AddArc(new Arc(VertexValues[4], VertexValues[1], 0));
            VertexValues[4].AddArc(new Arc(VertexValues[4], VertexValues[2], 0));
            VertexValues[4].AddArc(new Arc(VertexValues[4], VertexValues[3], 5));
            VertexValues[4].AddArc(new Arc(VertexValues[4], VertexValues[4], 0));
            VertexValues[4].AddArc(new Arc(VertexValues[4], VertexValues[5], 3));
            VertexValues[4].AddArc(new Arc(VertexValues[4], VertexValues[6], 5));
            VertexValues[4].AddArc(new Arc(VertexValues[4], VertexValues[7], 2));
            #endregion

            // Arcos (Aristas) de la sucursal 6.
            #region Arcos sucursal 6
            VertexValues[5].AddArc(new Arc(VertexValues[5], VertexValues[0], 2));
            VertexValues[5].AddArc(new Arc(VertexValues[5], VertexValues[1], 0));
            VertexValues[5].AddArc(new Arc(VertexValues[5], VertexValues[2], 0));
            VertexValues[5].AddArc(new Arc(VertexValues[5], VertexValues[3], 0));
            VertexValues[5].AddArc(new Arc(VertexValues[5], VertexValues[4], 3));
            VertexValues[5].AddArc(new Arc(VertexValues[5], VertexValues[5], 0));
            VertexValues[5].AddArc(new Arc(VertexValues[5], VertexValues[6], 0));
            VertexValues[5].AddArc(new Arc(VertexValues[5], VertexValues[7], 0));
            #endregion

            // Arcos (Aristas) de la sucursal 7.
            #region Arcos sucursal 7
            VertexValues[6].AddArc(new Arc(VertexValues[6], VertexValues[0], 8));
            VertexValues[6].AddArc(new Arc(VertexValues[6], VertexValues[1], 0));
            VertexValues[6].AddArc(new Arc(VertexValues[6], VertexValues[2], 0));
            VertexValues[6].AddArc(new Arc(VertexValues[6], VertexValues[3], 0));
            VertexValues[6].AddArc(new Arc(VertexValues[6], VertexValues[4], 5));
            VertexValues[6].AddArc(new Arc(VertexValues[6], VertexValues[5], 0));
            VertexValues[6].AddArc(new Arc(VertexValues[6], VertexValues[6], 0));
            VertexValues[6].AddArc(new Arc(VertexValues[6], VertexValues[7], 0));
            #endregion

            // Arcos (Aristas) de la sucursal 8.
            #region Arcos sucursal 8
            VertexValues[7].AddArc(new Arc(VertexValues[7], VertexValues[0], 0));
            VertexValues[7].AddArc(new Arc(VertexValues[7], VertexValues[1], 0));
            VertexValues[7].AddArc(new Arc(VertexValues[7], VertexValues[2], 9));
            VertexValues[7].AddArc(new Arc(VertexValues[7], VertexValues[3], 0));
            VertexValues[7].AddArc(new Arc(VertexValues[7], VertexValues[4], 2));
            VertexValues[7].AddArc(new Arc(VertexValues[7], VertexValues[5], 0));
            VertexValues[7].AddArc(new Arc(VertexValues[7], VertexValues[6], 0));
            VertexValues[7].AddArc(new Arc(VertexValues[7], VertexValues[7], 0));
            #endregion

            for (var i = 0; i < 8; i++)
                AdjacencyHash.Add(VertexValues[i].Value.IdCode, VertexValues[i].ArcsList);
        }

        private bool Valid() => IdValues.All(id => txtCode.Text != id);

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CreateArcs();
            var enterConsult = new Consult();
            enterConsult.Show();
            this.Hide();
        }

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            //condicion para solo números
            if (char.IsDigit(e.KeyChar))
                e.Handled = false;
            //para tecla backspace
            else if (char.IsControl(e.KeyChar))
                e.Handled = false;
            /*verifica que pueda ingresar punto y también que solo pueda 
           ingresar un punto*/
            else if ((e.KeyChar == '.') && (!txtContact.Text.Contains(".")))
                e.Handled = false;
            //si no se cumple nada de lo anterior entonces que no lo deje pasar
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo se admiten datos numéricos", "Validación de números", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool ValidateEmail(string email)
        {
            //cadena o expresion regular que verifica a un formato de correo electrónico
            var expression = @"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$";

            if (Regex.IsMatch(email, expression))
            {
                //verifica que la direccion corresponda y que la longitud de la cadena no esté vacía
                if (Regex.Replace(email, expression, string.Empty).Length == 0)
                    return true;
                return false;
            }
            return false;
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (ValidateEmail(txtEmail.Text)) {}
                //si es correcto no debe hacer nada
            else
            {
                MessageBox.Show("Dirección de correo no válida", "Validación de correo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Clear(); // selecciona todo lo de la casilla 
            }
        }

        private void Clear()
        {
            txtCode.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            txtResponsible.Clear();
            txtContact.Clear();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (I > 0 && I != 8)
            {
                DialogResult dr = MessageBox.Show("Si regresas, perderás todos los datos de las sucursales siguientes a tu sucursal de destino", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (dr != DialogResult.Yes) return;

                I -= 2;
                Iterator();
                txtContact.Text = VertexValues[I].Value.ContactNumber.ToString();
                txtAddress.Text = VertexValues[I].Value.Address;
                txtCode.Text = VertexValues[I].Value.IdCode;
                txtEmail.Text = VertexValues[I].Value.EmailAddress;
                txtResponsible.Text = VertexValues[I].Value.ResponsableName;

                IdValues.Remove(VertexValues[I].Value.IdCode);
            }
            else if (I == 8)
            {
                I -= 2;
                Iterator();
                txtContact.Text = VertexValues[I].Value.ContactNumber.ToString();
                txtAddress.Text = VertexValues[I].Value.Address;
                txtCode.Text = VertexValues[I].Value.IdCode;
                txtEmail.Text = VertexValues[I].Value.EmailAddress;
                txtResponsible.Text = VertexValues[I].Value.ResponsableName;

                IdValues.Remove(VertexValues[I].Value.IdCode);
                btnContinue.Visible = true;
                btnConsultar.Visible = false;
            }
            else
                MessageBox.Show("No puedes regresar a un lugar donde no has estado, ¿paradoja?", "Wow", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            
        }
    }
}
