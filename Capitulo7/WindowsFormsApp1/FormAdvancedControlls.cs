using System;
using System.Collections.Generic;
using System.Windows.Forms;
// Asumo que tu clase Car está definida correctamente en algún lugar del namespace

namespace WindowsFormsApp1
{
    public partial class FormAdvancedControlls : Form
    {
        // Declara la lista a nivel de clase para que esté disponible en toda la vista
        private List<Car> coches = new List<Car>();

        public FormAdvancedControlls()
        {
            InitializeComponent();
        }

        private void FormAdvancedControlls_Load(object sender, EventArgs e)
        {
            // 1. Llenar la lista 'coches' con más datos de ejemplo
            coches.Add(new Car
            {
                Nombre = "Focus",
                Fabricante = "Ford"
            });
            coches.Add(new Car
            {
                Nombre = "Civic",
                Fabricante = "Honda"
            });
            coches.Add(new Car
            {
                Nombre = "Vento",
                Fabricante = "VW"
            });

           
            listBox1.DataSource = coches;
            listBox1.DisplayMember = "Nombre";

           
            comboBox1.DataSource = coches;
            comboBox1.DisplayMember = "Fabricante";
            
           // dateTimePicker1.Value
         
        }
    }
}