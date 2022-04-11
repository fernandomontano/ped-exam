using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise3
{
    public partial class Consult : Base
    {
        public Consult()
        {
            InitializeComponent();
            Fill();
        }

        public void Fill() // llenar el combobox con todos los Ids de las sucursales.
        {
            foreach (var variable in OfficeSignUp.GraphValues.VertexList) // pude haber usado directamente la lista de vértices, para darle uso al grafo lo hice de esta forma.
                cmbCode.Items.Add(variable.Value.IdCode);
        }

        public void FillOffices()
        {
            List<Arc> valuesFirstId = (List<Arc>)OfficeSignUp.AdjacencyHash[cmbCode.Text];
            List<int> notNull = new(); // index de cada una de las sucursales cuya distancia es distintas de 0.

            int[] distances = new int[8]; // obtener las distancias de la sucursal seleccionada a las demas (0 -> no tiene conexión directa)

            var i = 0;
            foreach (var variable in valuesFirstId)
            {
                distances[i] = variable.Distance;
                i++;
            }

            for (var j = 0; j < distances.Length; j++)
            {
                if (distances[j] != 0)
                    notNull.Add(j);
            }

            foreach (var var in notNull)
            {
                MessageBox.Show(var.ToString());
            }
            //for (int j = 0; j < notNullArray.Length; j++)
            //{
            //    MessageBox.Show(notNullArray[j].ToString());
            //    var gpbox = this.Controls.Find("groupBox" + j, true); // true for recursive search
            //    foreach (GroupBox gp in gpbox)
            //        gp.Text = $"Sucursal {notNullArray[j] + 1}";
            //}
        }

        private void cmbCode_TextChanged(object sender, EventArgs e)
        {
            FillOffices();
        }
    }
}
