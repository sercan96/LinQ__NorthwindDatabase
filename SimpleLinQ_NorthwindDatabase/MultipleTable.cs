using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleLinQ_NorthwindDatabase
{
    public partial class MultipleTable : Form
    {
        NorthwindEntities _db;
        public MultipleTable()
        {
            InitializeComponent();
            _db = new NorthwindEntities();
        }
        private void DataSource<T>(T entities)
        {
            dgwTable.DataSource = entities;
        }
        private void MultipleTable_Load(object sender, EventArgs e)
        {
            // Siparş sayısı 0'dan fazla olan müşterileri getir.

            /*
             * B's Beverages isimli şirketin kaç adet siparişi vardır?
             * Bu siparişlerin toplam ücreti ne kadardır?  
             * Verilen siparişlerin ürünId ve ürün ismini getir
            */


        }
        /// <summary>
        /// Siparş sayısı 0'dan fazla olan müşterileri getir.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>



        public class CustomerVM
        {
            public CustomerVM()
            {
                Orders = new List<OrderDetailVM>();
            }
            public string CompanyName { get; set; }
            public int TotalOrderCount { get; set; }
            public List<OrderDetailVM> Orders { get; set; }

        }

        public class OrderDetailVM
        {
            public int OrderId { get; set; }
            public decimal TotalPrice { get; set; }
            public List<ProductVM> Products { get; set; }

        }

        public class ProductVM
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }

        }
        /// <summary>
        /// B's Beverages isimli şirketin kaç adet siparişi vardır?  Bu siparişlerin toplam ücreti ne kadardır?         Verilen siparişlerin ürünId ve ürün ismini getir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery2_Click(object sender, EventArgs e)
        {
            // var customer artık customer nesnesinden çıktı ayrı bir nesneye geçti(customerVM) 
            var customers = _db.Customers
                                         .Where(c => c.CompanyName == "B's Beverages")
                                         .Select(c => new CustomerVM()
                                         {
                                             CompanyName = c.CompanyName,
                                             TotalOrderCount = c.Orders.Count(),
                                             // Böyle bir bilgi olmadığı için view model ile yeni bir tablo yaratıyoruz.
                                             Orders = c.Orders.Select(o => new OrderDetailVM()
                                             {
                                                 OrderId = o.OrderID,
                                                 TotalPrice = o.Order_Details.Sum(od => od.UnitPrice * od.Quantity),
                                                 Products = o.Order_Details.Select(od => new ProductVM()
                                                 {
                                                     ProductID = od.ProductID,
                                                     ProductName = od.Product.ProductName
                                                 }).ToList()
                                             }).ToList()
                                         }).ToList();

            dgwTable.DataSource = customers;     

        }
        private void btnQuery1_Click(object sender, EventArgs e)
        {
               var ordersInGermany = _db.Customers
              .Where(c => c.Country == "Germany" && c.CompanyName == "Alfreds Futterkiste")
              .SelectMany(c => c.Orders)
              .SelectMany(o => o.Order_Details)
              .Select(od => new OrderVM()
              {
                  OrderId = od.OrderID,
                  CompanyName = od.Order.Customer.CompanyName,
                  ProductName = od.Product.ProductName,
                  UnitPrice = od.UnitPrice,
                  Quantity = od.Quantity,
                  Country = od.Order.Customer.Country,
                  TotalPrice = od.UnitPrice * od.Quantity
              })
              .ToList();

              dgwTable.DataSource = ordersInGermany;
        }

        public class OrderVM
        {
            public int OrderId { get; set; }
            public string ProductName { get; set; }
            public string CompanyName { get; set; }
            public string Country { get; set; }
            public decimal UnitPrice { get; set; }
            public decimal Quantity { get; set; }
            public decimal TotalPrice { get; set; }

        }


    }
}
