using pv03_1702019_MNurA.Model;
using pv03_1702019_MNurA.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pv03_1702019_MNurA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TodoRepository todo = new TodoRepository();

            string nim = tbNim.Text;

            if(todo.cekNim(nim) == 1)
            {
                tbNim.Enabled = false;
                btnAdd.Enabled = true;
                submitNim.Enabled = false;

                dataGridView1.DataSource = todo.getByNim(nim);
            }
            else
            {
                MessageBox.Show("NIM tidak ada");
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Todo temp = new Todo();

            temp.NimMhs = tbNim.Text;
            temp.Nama = tbNama.Text;
            temp.Kategori = tbKategori.Text;

            TodoRepository todo = new TodoRepository();

            todo.addTodo(temp);

            string nim = tbNim.Text;

            dataGridView1.DataSource = todo.getByNim(nim);
                 
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Todo temp = new Todo();

            temp.Id = Convert.ToInt16(tbDelete.Text);
            //temp.Nama = tbNama.Text;
            //temp.Kategori = tbKategori.Text;

            TodoRepository todo = new TodoRepository();

            todo.deleteTodo(temp);

            string nim = tbNim.Text;
            btnDelete.Enabled = false;

            dataGridView1.DataSource = todo.getByNim(nim);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Todo temp = new Todo();

            temp.Id = Convert.ToInt16(tbUpId.Text);
            temp.Nama = tbUpNama.Text;
            temp.Kategori = tbUpKategori.Text;

            TodoRepository todo = new TodoRepository();

            todo.updateTodo(temp);
            tbUpId.Enabled = false;

            string nim = tbNim.Text;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;


            dataGridView1.DataSource = todo.getByNim(nim);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
