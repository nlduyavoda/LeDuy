﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Danhsachsanphamfull()
        {
            QuanLy ql = new QuanLy();
            List<Sanpham> dsfull = ql.dsspfull();
            ViewBag.dsfull = dsfull;
            return View();
        }

        public ActionResult Xoasanpham()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult ResultXoasanpham(int id)
        {
            QuanLy ql = new QuanLy();
            ql.xoa(id);
            ViewBag.Message = "Your list was remove";
            return View();
        }

        public ActionResult Suasanpham(int id)
        {
            QuanLy ql = new QuanLy();
            Sanpham sp = ql.TimID(id);
            ViewBag.sp = sp;
            return View();
            
        }
        [HttpPost]
        public ActionResult Resultsuasanpham(int id,string tensanpham, int gia, string nsx)
        {
            

            QuanLy ql = new QuanLy();
            int tmp = ql.sua(id,tensanpham,gia,nsx);
            if (tmp != 0) ViewBag.Message = "Sửa Thành Công";
            else ViewBag.Message = "Sửa Thất Bại";
            return View();
        }

        public ActionResult themsanpham1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult resultthemsanpham1(int id,string tensanpham, int gia, string nsx, string tenloai)
        {
            QuanLy ql = new QuanLy();
            int tmp = ql.them1(id,tensanpham, gia, nsx, tenloai);
            if (tmp != 0) ViewBag.Message = "Add to succes";
            else ViewBag.Message = "Add failed";
            return View();
        }

        public ActionResult TimsanphamtheoID(int id)
        {
            QuanLy q = new QuanLy();
            Sanpham sp = q.TimID(id);
            ViewBag.sp = sp;
            return View();
        }




    }
}