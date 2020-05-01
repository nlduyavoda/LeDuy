using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class QuanLy
    {
   
        public int them1(int id,string tensanpham,int gia,string nsx, string tenloai)
        {
            try
            {
                using (CSDLContext db = new CSDLContext())
                {
                    db.Sanpham.Add(new Sanpham {ID = id,Tensanpham = tensanpham, Gia = gia, Nsx = nsx});
                    db.Loaisanpham.Add(new Loaisanpham { Tenloai = tenloai });
                    db.SaveChanges();
                }
                return 1;
            }
            catch (Exception)
            { return 0; }

        }

        public int xoa(int id)
        {
            try
            {
                using (CSDLContext db = new CSDLContext())
                {
                    Sanpham lsp = db.Sanpham.Find(id);
                    db.Entry(lsp).State = EntityState.Deleted;
                    db.SaveChanges();
                }
                return 1;
            }
            catch (Exception)
            { return 0; }



        }

        public int sua(int id,string tensanpham,int gia, string nsx)
        {

            try
            {
                using (CSDLContext db = new CSDLContext())
                {
                    Sanpham lsp = db.Sanpham.Find(id);
                    lsp.Tensanpham = tensanpham;
                    lsp.Gia = gia;
                    lsp.Nsx = nsx;
                    db.Entry(lsp).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return 1;
            }
            catch (Exception)
            { return 0; }    
        }

        public List<Loaisanpham> dssp()
        {
            List<Loaisanpham> list = new List<Loaisanpham>();
            using (CSDLContext db = new CSDLContext())
            {
                list = db.Loaisanpham.ToList();
                return list;
            }
        }

        public List<Sanpham> dsspfull()
        {
            List<Sanpham> list = new List<Sanpham>();
            using (CSDLContext db = new CSDLContext())
            {
                list = db.Sanpham.ToList();
                return list;
            }
        }

        public Sanpham TimID(int id)
        {
            using (CSDLContext db = new CSDLContext())
            {
                return db.Sanpham.Find(id);
            }
        }

        public List<Sanpham> Timtheonsx(string Nsx)
        {
            using (CSDLContext db = new CSDLContext())
            {
                return db.Sanpham.Where(a => a.Nsx.Equals(Nsx)).ToList();
            }
        }

        public List<Sanpham> SapXepTangDan()
        {
            using (CSDLContext db = new CSDLContext())
            {
                return db.Sanpham.OrderBy(a => a.Gia).Take(3).ToList();
            }
        }

        public List<Sanpham> SapXepGiamDan()
        {
            using (CSDLContext db = new CSDLContext())
            {
                return db.Sanpham.OrderByDescending(a => a.Gia).ToList();
            }
        }


    }
}