using SimpleLinQ_NorthwindDatabase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace LinQWorking_SingleTable
{
     //Working with a Single Table
    public partial class Form1 : Form
    {
        NorthwindEntities db;
        public Form1()
        {
            InitializeComponent();
            db= new NorthwindEntities();    
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Tüm müşteri kayılarını getiriniz. 
            // Tüm müşteri kayıtlarının sadece CompanyName ve CompanyId bilgilerini getiriniz.
            // New York'ta yaşayan müşterileri isim sırasına göre getiriniz.
            // "Beverages" katergorisine ait ürünlerin isimlerini getiriniz.
            // En son eklenen 5 ürün bilgisini alınız
            // Fiyatı 10- 30 arasında olan ürünlerin isim ve fiyat bilgilerini alınız.
            // "Beverages" katergorisindeki ürünlerin ortalama fiyatı nedir.
            // "Beverages" katergorisinde kaç ürün vardır.
            // "Beverages" ve "Condiments" categorilerindeki ürünlerin toplam fiyatı nedir
            // "Tea" kelimesi içeren ürünleri getiriniz.
            // En pahalı ve en ucuz hangisidir?
        }
        private void DataSource<T>(T entity)
        {
            dgwTable.DataSource = entity;
        }

        /// <summary>
        ///    // Tüm müşteri kayıtlarını getiriniz.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnQuery1_Click(object sender, EventArgs e)
        {
            var customers = db.Customers.ToList();
            DataSource(customers);
        }
        /// <summary>
        /// Tüm müşteri kayıtlarının sadece CompanyName ve CompanyId bilgilerini getiriniz.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery2_Click(object sender, EventArgs e)
        {
            var customers = db.Customers.Select(c => new
            {
                c.CustomerID,
                c.CompanyName
            }).ToList();
            DataSource(customers);
        }

        /// <summary>
        ///  London'ta yaşayan müşterileri şirket isimlerine göre getiriniz.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery3_Click(object sender, EventArgs e)
        {
            var customers = db.Customers
             .Where(c => c.City == "London")
             .Select(c => new { c.CompanyName, c.City }).ToList();
            DataSource(customers);
        }
        /// <summary>
        /// "Beverages" katergorisine ait ürünlerin isimlerini getiriniz.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery4_Click(object sender, EventArgs e)
        {
            // Uzun Yol
            //var category = db.Categories.Where(c => c.CategoryName == "Beverages").FirstOrDefault();
            //var products = db.Products.Where(p => p.CategoryID == category.CategoryID).ToList();

            // Kısa Yol
            var products = db.Products.Where(p => p.Category.CategoryName == "Beverages").ToList(); // Lazy Loading
            DataSource(products);
        }
        /// <summary>
        /// En son eklenen 5 ürün bilgisini alınız
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery5_Click(object sender, EventArgs e)
        {
            var products = db.Products.OrderByDescending(p=>p.ProductID).Take(5).ToList();  
            // Take(count) tablonun en üstündeki count kadar bilgiyi verir. OrderByDescending diyerek ve id vererek tabloyu id bilgisine göre ters çevirmiş olduk.

            DataSource(products);
        }
        /// <summary>
        /// Fiyatı 10- 30 arasında olan ürünlerin azalan sıraya göre isim ve fiyat bilgilerini alınız.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery6_Click(object sender, EventArgs e)
        {
            var products = db.Products
                                      .Where(p => p.UnitPrice > 10 && p.UnitPrice < 30)
                                      .Select(p => new { p.ProductName, p.UnitPrice })
                                      .OrderByDescending(p=> p.UnitPrice)
                                      .ToList();
            DataSource(products);
        }

        /// <summary>
        /// "Beverages" kategorisindeki ürünlerin ortalama fiyatını hesaplama
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery7_Click(object sender, EventArgs e)
        {
            var average = db.Products
                                    .Where(p => p.Category.CategoryName == "Beverages")
                                    .Average(p => p.UnitPrice);
            MessageBox.Show(average.ToString());

        }

        /// <summary>
        /// "Beverages" katergorisinde kaç ürün vardır.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery8_Click(object sender, EventArgs e)
        {
            var count = db.Products.Count(p => p.Category.CategoryName == "Beverages");
            MessageBox.Show($"Beverages Product Count : {count}");                
        }
        /// <summary>
        /// "Beverages" ve "Condiments" categorilerindeki ürünlerin toplam fiyatı nedir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery9_Click(object sender, EventArgs e)
        {
            var totalPrice = db.Products
                                    .Where(p => p.Category.CategoryName == "Beverages" || p.Category.CategoryName == "Condiments")
                                    .Sum(p => p.UnitPrice); 
            MessageBox.Show($"Total Unit Price : {totalPrice}");
        }
        /// <summary>
        /// "Tea" kelimesi içeren ürünleri getiriniz.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery10_Click(object sender, EventArgs e)
        {
            var products = db.Products.Where(p => p.ProductName.ToLower().Contains("Tea")).ToList();
            DataSource(products);
        }
        /// <summary>
        ///  En pahalı ve en ucuz hangisidir?
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery11_Click(object sender, EventArgs e)
        {
            var minP = db.Products.Where(p => p.UnitPrice != null).Min(p => p.UnitPrice);
            var maxP = db.Products.Where(p => p.UnitPrice != null).Max(p => p.UnitPrice);
            MessageBox.Show($"Product(MinPrice) : {minP} \n Product(MaxPrice) : {maxP}");

            var product = db.Products
                                     .Where(p => p.UnitPrice == db.Products.Min(m => m.UnitPrice))
                                     .Select(p => new
                                     {
                                         p.ProductID,
                                         p.ProductName,
                                         p.UnitPrice
                                     }).ToList();
            DataSource(product);
                                    
        }
    }
}
