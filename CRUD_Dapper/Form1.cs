using CodeLib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_Dapper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadBooks();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Book book = new Book();

            book.Title = txtTitle.Text;
            book.Author = txtAuthor.Text;
            book.Price = decimal.Parse(txtPrice.Text);
            book.Description = txtDescription.Text;
            book.CountryId = 1;

            BookRepo repo = new BookRepo();
            repo.AddBook(book);
            LoadBooks();
        }

        private void LoadBooks()
        {
            BookRepo repo = new BookRepo();
            this.grvBooks.DataSource = null;
            grvBooks.DataSource = repo.GetBooks();
        }

        private void grvBooks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                lblId.Text = "ID:";
                lblId.Text += grvBooks.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTitle.Text = grvBooks.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtAuthor.Text = grvBooks.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtPrice.Text = grvBooks.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtDescription.Text = grvBooks.Rows[e.RowIndex].Cells[4].Value.ToString();
                btnUpdate.Enabled = true;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Book book = new Book();


            book.Id = int.Parse(lblId.Text.Substring(3));
            book.Title = txtTitle.Text;
            book.Author = txtAuthor.Text;
            book.Price = decimal.Parse(txtPrice.Text);
            book.Description = txtDescription.Text;
            book.CountryId = 1;

            BookRepo repo = new BookRepo();
            repo.UpdateBook(book);
            LoadBooks();
        }
    }
}
