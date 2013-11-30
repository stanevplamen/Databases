using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MondodbDemo.Data.Library;
using MondodbDemo.Data;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Driver.Builders;
using MongoDB.Bson;
using System.Text;
using iTextSharp.text;
using System.IO;
using MondodbDemo.Data.Helpers;

namespace MondodbDemo.WebApp
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) // Main()
        {
            if (!IsPostBack)
            {
                grdResultFill();
            }
        }

        private void grdResultFill()
        {
            grdResult.DataSource = this.LoadData<Book>().ToList();
            grdResult.DataBind();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            Book book = new Book();
            book.Title = txtBookTitle.Text;
            book.Author = txtBookAuthor.Text;
            book.PublishDate = DateTime.Now;

            this.SaveData<Book>(book);
            grdResultFill();
        }

        private void SaveData<T>(T value)
        {
            try
            {
                var result = MongoDbProvider.db.GetCollection<T>(typeof(T).Name).Save(value, SafeMode.True);
            }
            catch (MongoConnectionException ex)
            {
                throw new MongoCommandException("Cannot access database. Please try again later");
            }
        }

        private IQueryable<T> LoadData<T>()
        {
            try
            {
                var result = MongoDbProvider.db.GetCollection<T>(typeof(T).Name).AsQueryable();
                return result;
            }
            catch (MongoConnectionException ex)
            {
                throw new MongoCommandException("Cannot access database. Please try again later");
            }
        }

        public void DeleteData<T>(string id) 
        {
            try
            {
                var result = MongoDbProvider.db.GetCollection<T>(typeof(T).Name).Remove(Query.EQ("_id", new ObjectId(id)));
            }
            catch (MongoConnectionException ex)
            {
                throw new MongoCommandException("Cannot access database. Please try again later");
            }
        }

        protected void grdResult_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            this.DeleteData<Book>(e.Keys[0].ToString());
            grdResultFill();
        }

        protected void grdResult_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            var id = new ObjectId(e.Keys[0].ToString());
            var book = LoadData<Book>().FirstOrDefault(b => b._id == id);
            if (book != null)
            {
                book.Title = e.NewValues[0] == null ? string.Empty : e.NewValues[0].ToString();
                book.Author = e.NewValues[1] == null ? string.Empty : e.NewValues[1].ToString();
            }
            SaveData(book);
        }

        protected void grdResult_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            grdResult.EditIndex = e.NewEditIndex;
            grdResultFill();
        }

        protected void grdResult_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            grdResult.EditIndex = -1;
            grdResultFill();
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                grdResultFill();
            }
            else
            {
                grdResult.DataSource =
                LoadData<Book>().Where(b => b.Title.Contains(txtSearch.Text)).ToList();
                grdResult.DataBind();
            }
        }

        protected void btnGeneratePdf_Click1(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<table>");
            sb.Append("<tr>");
            sb.Append("<th>Title</th>");
            sb.Append("<th>Author</th>");
            sb.Append("<th>PublishDate</th>");
            sb.Append("</tr>");
            LoadData<Book>().ToList().ForEach(b =>
            {
                sb.Append("<tr>");
                sb.AppendFormat("<td>{0}</td>", b.Title);
                sb.AppendFormat("<td>{0}</td>", b.Author);
                sb.AppendFormat("<td>{0}</td>", b.PublishDate);
                sb.Append("</tr>");
            });
            sb.Append("</table>");

            PDFBuilder.HtmlToPdfBuilder builder = new PDFBuilder.HtmlToPdfBuilder(PageSize.LETTER);
            PDFBuilder.HtmlPdfPage page = builder.AddPage();
            page.AppendHtml(sb.ToString());
            byte[] file = builder.RenderPdf();
            string tempFolder = AppDomain.CurrentDomain.BaseDirectory + "PdfResult\\";
            string tempFileName = DateTime.Now.ToString("yyyy-MM-dd") + "-" + Guid.NewGuid() + ".pdf";
            if (Helpers.DirectoryExist(tempFolder))
            {
                if (!File.Exists(tempFolder + tempFileName))
                    File.WriteAllBytes(tempFolder + tempFileName, file);
            }
        }
    }
}