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
            List<Arc> valuesFirstId = (List<Arc>) OfficeSignUp.AdjacencyHash[cmbCode.Text];
            List<int> notNull = new(); // index de cada una de las sucursales cuya distancia es distintas de 0.

            int[] distances = new int[8]; // obtener las distancias de la sucursal seleccionada a las demas (0 -> no tiene conexión directa)

            var i = 0;
            foreach (var variable in valuesFirstId) // obtengo las distancias de mi sucursal seleccionada.
            {
                distances[i] = variable.Distance;
                i++;
            }

            // este for sirve para llenar la lista de *posiciones* en las cuales la distancia no es 0.
            for (var j = 0; j < distances.Length; j++)
                if (distances[j] != 0)
                    notNull.Add(j);

            var notNullArray = notNull.ToArray(); // pasar la lista de posiciones en cuya distancia no es 0 a array.

            for (int j = 0; j < notNullArray.Length; j++) // j -> cada sucursal.
            {
                // llenar los elementos del formulario.
                var gpbox = Controls.Find("groupBox" + (j + 1), true); // true for recursive search
                foreach (GroupBox gp in gpbox)
                {
                    gp.Visible = true;
                    gp.Text = $"Sucursal {notNullArray[j] + 1}";
                }

                var distance = Controls.Find("lblDistance" + (j + 1), true); // true for recursive search
                foreach (Label lb in distance)
                    lb.Text = $"Distancia: {distances[notNull[j]]} km";

                var txtCode = Controls.Find($"txtBox{j+1}{1}",true); // true for recursive search
                foreach (TextBox tx in txtCode)
                    tx.Text = OfficeSignUp.VertexValues[notNullArray[j]].Value.IdCode;

                var txtAddress = Controls.Find($"txtBox{j + 1}{2}", true); // true for recursive search
                foreach (TextBox tx in txtAddress)
                    tx.Text = OfficeSignUp.VertexValues[notNullArray[j]].Value.Address;

                var txtResponsible = Controls.Find($"txtBox{j + 1}{3}", true); // true for recursive search
                foreach (TextBox tx in txtResponsible)
                    tx.Text = OfficeSignUp.VertexValues[notNullArray[j]].Value.ResponsableName;

                var txtContact = Controls.Find($"txtBox{j + 1}{4}", true); // true for recursive search
                foreach (TextBox tx in txtContact)
                    tx.Text = OfficeSignUp.VertexValues[notNullArray[j]].Value.ContactNumber.ToString();

                var txtEmail = Controls.Find($"txtBox{j + 1}{5}", true); // true for recursive search
                foreach (TextBox tx in txtEmail)
                    tx.Text = OfficeSignUp.VertexValues[notNullArray[j]].Value.EmailAddress;
            }
        }

        private void cmbCode_TextChanged(object sender, EventArgs e)
        {   
            ResetVisibility();
            FillOffices();
        }

        private void ResetVisibility()
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var enterOffice = new OfficeSignUp();
            enterOffice.Show();
            this.Hide();

            OfficeSignUp.AdjacencyHash.Clear();
        }
    }
}
