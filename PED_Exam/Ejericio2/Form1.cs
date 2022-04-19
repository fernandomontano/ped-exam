using System.Collections.Generic;
using System.Linq;

namespace Ejericio2
{
    public partial class Form1 : Form
    {

        int[] StaticArray;
        int t = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void IngresarBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int num = int.Parse(txtNumber.Text);
                Array.Resize<int>(ref StaticArray, t + 1);
                StaticArray[t] = num;
                string s = string.Join(" | ", StaticArray);
                label4.Visible = true;
                InitArr.Text = s;
                InitArr.Visible = true;
                txtNumber.Clear();
                MostrarBtn.Enabled = true;
                t++;
                txtNumber.Focus();
                label2.Visible = false;
                FinArr.Visible = false;
                LimpiarBtn.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Inserte un valor valido ");
            }
        }

        static void HeapSort(int[] InitArr, int n)
        {
            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(InitArr, n, i);
            for (int i = n - 1; i >= 0; i--)
            {
                int tempo = InitArr[0];
                InitArr[0] = InitArr[i];
                InitArr[i] = tempo;
                Heapify(InitArr, i, 0);
            }
        }

        static void Heapify(int[] arr, int n, int i)
        {
            int right = 2 * i + 2;
            int left = 2 * i + 1;
            int root = i;
            
            if (left < n && arr[left] > arr[root])
                root = left;
            if (right < n && arr[right] > arr[root])
                root = right;
            if (root != i)
            {
                int swap = arr[i];
                arr[i] = arr[root];
                arr[root] = swap;
                Heapify(arr, n, root);
            }
        }

        private void MostrarBtn_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
            HeapSort(StaticArray, t);
            string r = string.Join(" | ", StaticArray);
            FinArr.Text = r;
            FinArr.Visible = true;
           

        }
        private void Clear()
        {
            List<int> ClearList = StaticArray.ToList();
            ClearList.Clear();
            StaticArray=ClearList.ToArray();
            Array.Resize<int>(ref StaticArray, 1);
            t = 0;
            label2.Visible=false;
            label4.Visible=false;
            InitArr.Text = "";
            InitArr.Visible=false;
            FinArr.Text = "";
            FinArr.Visible=false;
            MostrarBtn.Enabled=false;
        }

        private void LimpiarBtn_Click(object sender, EventArgs e)
        {
            Clear();
            LimpiarBtn.Enabled=false;
        }
    }
}