using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class CSDLContext:DbContext
    {
        public DbSet<Sanpham> Sanpham { get; set; }
        public DbSet<Loaisanpham> Loaisanpham { get; set; }
        public CSDLContext() {
            SqlConnectionStringBuilder sqlb = new SqlConnectionStringBuilder();
            sqlb.DataSource = "DESKTOP-SSQ3U0E";
            sqlb.InitialCatalog = "SanPhamEntityDay5";
            sqlb.IntegratedSecurity = true;
            Database.Connection.ConnectionString = sqlb.ConnectionString;
        }
    }

    public class Sanpham
    {
        [Key]
        public int ID { get; set; }
        public string Tensanpham { get; set; }
        public int Gia { get; set; }
        public string Nsx { get; set; }
        public Loaisanpham Loaisanpham { get; set; }
    }
    public class Loaisanpham
    {
        [Key]
        public int Idloai { get; set; }
        public string Tenloai { get; set; }
        public ICollection<Sanpham> Sanpham { get; set; }
    }
}