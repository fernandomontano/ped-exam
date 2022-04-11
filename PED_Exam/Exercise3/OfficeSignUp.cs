using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise3
{
    public partial class OfficeSignUp : Base
    {
        public static Hashtable AdjacencyTable = new Hashtable();
        public static Vertex[] VertexValues = new Vertex[8];
        private List<string> IdValues = new List<string>();

        public int I = 0;

        public OfficeSignUp()
        {
            InitializeComponent();
        }
        private void btnContinue_Click(object sender, EventArgs e)
        {
                if (txtAddress.Text == "" || txtCode.Text == "" || txtContact.Text == "" || txtEmail.Text == "" ||
                    txtResponsible.Text == "" || !Valid())
                {
                    MessageBox.Show("Lo siento, debes llenar todos los campos antes de darle continuar.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (I < 8)
                {
                    IdValues.Add(txtCode.Text);
                    VertexValues[I] = new Vertex(new Office(txtAddress.Text, txtCode.Text, txtResponsible.Text,
                        int.Parse(txtContact.Text), txtEmail.Text));

                    MessageBox.Show($"Valores añadidos con éxito a la Sucursal N° {I+1}!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Iterator();
                }
                if (I == 8)
                {
                    Iterator();
                }

        }

        private void Iterator()
        {
            if (I == 8)
            {
                CreateArcs();
                btnContinue.Text = "Mostrar grafo creado";
            }
            else
                I++;
                
                
            lblSucursal.Text = $"Sucursal N° {I + 1}";
        }

        private void CreateArcs() // los he creado de forma Manual y por medio de listas ya que a la hora de crearlo en una tabla Hash, necesito filtrarlo por llaves.
        {
            // Arcos (Aristas) de la sucursal 1. (de acuerdo al gráfico)
            #region Arcos sucursal 1
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
            VertexValues[1].AddArc(new Arc(VertexValues[1], VertexValues[2], 5)); // 2 a 3
            VertexValues[1].AddArc(new Arc(VertexValues[1], VertexValues[3], 4)); // 2 a 4.
            VertexValues[1].AddArc(new Arc(VertexValues[1], VertexValues[4], 0)); // 2 a 5.
            VertexValues[1].AddArc(new Arc(VertexValues[1], VertexValues[5], 0)); // 2 a 6.
            VertexValues[1].AddArc(new Arc(VertexValues[1], VertexValues[6], 0)); // 2 a 7.
            VertexValues[1].AddArc(new Arc(VertexValues[1], VertexValues[7], 0)); // 2 a 8.

            #endregion

            // Arcos (Aristas) de la sucursal 3.
            #region Arcos sucursal 3
            VertexValues[2].AddArc(new Arc(VertexValues[2], VertexValues[0], 0));
            VertexValues[2].AddArc(new Arc(VertexValues[2], VertexValues[1], 5));
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
            VertexValues[6].AddArc(new Arc(VertexValues[5], VertexValues[0], 8));
            VertexValues[6].AddArc(new Arc(VertexValues[5], VertexValues[1], 0));
            VertexValues[6].AddArc(new Arc(VertexValues[5], VertexValues[2], 0));
            VertexValues[6].AddArc(new Arc(VertexValues[5], VertexValues[3], 0));
            VertexValues[6].AddArc(new Arc(VertexValues[5], VertexValues[4], 5));
            VertexValues[6].AddArc(new Arc(VertexValues[5], VertexValues[5], 0));
            VertexValues[6].AddArc(new Arc(VertexValues[5], VertexValues[6], 0));
            VertexValues[6].AddArc(new Arc(VertexValues[5], VertexValues[7], 0));
            #endregion

            // Arcos (Aristas) de la sucursal 8.
            #region Arcos sucursal 8
            VertexValues[7].AddArc(new Arc(VertexValues[5], VertexValues[0], 0));
            VertexValues[7].AddArc(new Arc(VertexValues[5], VertexValues[1], 0));
            VertexValues[7].AddArc(new Arc(VertexValues[5], VertexValues[2], 9));
            VertexValues[7].AddArc(new Arc(VertexValues[5], VertexValues[3], 0));
            VertexValues[7].AddArc(new Arc(VertexValues[5], VertexValues[4], 2));
            VertexValues[7].AddArc(new Arc(VertexValues[5], VertexValues[5], 0));
            VertexValues[7].AddArc(new Arc(VertexValues[5], VertexValues[6], 0));
            VertexValues[7].AddArc(new Arc(VertexValues[5], VertexValues[7], 0));
            #endregion

            foreach (var distances in VertexValues[0].ArcsList)
            {
                MessageBox.Show(distances.Distance.ToString());
            }


            for (int i = 0; i < 8; i++)
            {
                AdjacencyTable.Add($"{VertexValues[i].Value.IdCode}", $"{VertexValues[i].ArcsList}");
            }
        }

        private bool Valid()
        {
            return IdValues.All(id => txtCode.Text != id);
        }

    }
}
