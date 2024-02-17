using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ_MulitpleTable
{
    public class Program
    {
        private static NorthwindEntities _db = new NorthwindEntities();
        static void Main(string[] args)
        {
            //Example1();
            // Exapmle2();
            Example3();
            Console.ReadLine();
        }

        /// <summary>
        /// Siparş sayısı 0'dan fazla olan müşterileri getir.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Example1()
        {
            var customers = _db.Customers
                                        .Where(c => c.Orders.Count > 0)
                                        .OrderByDescending(c => c.Orders.Count)
                                        .ToList();
        }


        /// <summary>
        /// B's Beverages isimli şirketin kaç adet siparişi vardır?  Bu siparişlerin toplam ücreti ne kadardır?         Verilen siparişlerin ürünId ve ürün ismini getir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void Example2()
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

            foreach (var customer in customers)
            {
                Console.WriteLine($"customerName : {customer.CompanyName} , TotalOrderCount : {customer.TotalOrderCount}");

                foreach (var order in customer.Orders)
                {
                    Console.WriteLine($"orderId : {order.OrderId} , orderTotalPrice : {order.TotalPrice}");

                    foreach (var product in order.Products)
                    {
                        Console.WriteLine($"productId : {product.ProductID} , ProductName : {product.ProductName}");
                    }
                }
            }
        }

        /// <summary>
        ///  "Germany(Almanya)" ülkesindeki müşterilere ait sipariş detaylarını(UnitPrice,Quantity) getirin. 
        ///  Müşteri adı, ürün adı, birim fiyatı, miktarı ve toplam fiyatı içeren bilgileri döndürün. 
        ///  Bu sorguyu çalıştırarak, müşterilerin Almanya'dan hangi ürünleri sipariş ettiklerini ve bu siparişlerin detaylarını gösterin.
        /// </summary>
        static void Example3()
        {
            var ordersInGermany = _db.Customers
            .Where(c => c.Country == "Germany" && c.CompanyName == "Alfreds Futterkiste")
            .SelectMany(c => c.Orders)
            .SelectMany(o => o.Order_Details)
            .Select(od => new OrderVM()
            {
                CompanyName = od.Order.Customer.CompanyName,
                ProductName = od.Product.ProductName,
                UnitPrice = od.UnitPrice,
                Quantity = od.Quantity,
                Country = od.Order.Customer.Country,
            })
            .ToList();

            foreach (var item in ordersInGermany)
            {
                Console.WriteLine($" CompanyName : {item.CompanyName} \n Produc Name: {item.ProductName} \n Unit Price : {item.UnitPrice} \n Quantity :{item.Quantity} \n Country : {item.Country} \n" );
            }

        }
        public class OrderVM
        {
            public int OrderId { get; set; }
            public string ProductName { get; set; }
            public string CompanyName { get; set; }
            public string Country { get; set; }
            public decimal UnitPrice { get; set; }
            public decimal Quantity { get; set; }

        }
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
        
    }
}
