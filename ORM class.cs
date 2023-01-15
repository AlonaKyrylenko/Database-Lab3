using Npgsql;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace lab2
{
    public class Shop
    {
        public class Customer
        {
            public int customer_id { get; set; }
            public string name { get; set; }
            public int order_id { get; set; }
        }
        public class Orders
        {
            public int order_id { get; set; }
            public int good_id { get; set; }
            public DateTime data { get; set; }
            public int customer_id { get; set; }
        }
        public class Departments
        {
            public int department_id { get; set; }
            public string name { get; set; }
            public int good_id { get; set; }
            public int availability { get; set; }
        }
        public class Categories
        {
            public int category_id { get; set; }
            public string name { get; set; }
            public int order_id { get; set; }
        }
        public class Goods
        {
            public int good_id { get; set; }
            public string name { get; set; }
            public int price { get; set; }
            public int category_id { get; set; }
            public int department_id { get; set; }
            public Departments department { get; set; }
            public int order_id { get; set; }
        }
        public class Context : BaseContext
        {
            public BaseSet<Customer> customer { get; set; }
            public BaseSet<Orders> orders { get; set; }
            public BaseSet<Departments> departments { get; set; }
            public BaseSet<Categories> categories { get; set; }
            public BaseSet<Goods> goods { get; set; }

            public Context()
            {
                Database.EnsureCreated();
            }
            protected override void OnConfiguring(BaseContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=1234;Database=KPI");
            }
        }
    }
}
