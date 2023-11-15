using SachOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace SachOnline.Controllers
{
    public class SachOnlineController : Controller
    {
        // GET: SachOnline
        dbSachOnlineDataContext data = new dbSachOnlineDataContext();
        private List<SACH> LaySachMoi(int count)
        {
            return data.SACHes.OrderByDescending(a => a.NgayCapNhat).Take(count).ToList();
        }
        public ActionResult Index()
        {
            var listSachMoi = LaySachMoi(6);
            return View(listSachMoi);
        }

        public ActionResult ChuDePartial()
        {
            var listChuDe = from cd in data.CHUDEs select cd;
            return PartialView(listChuDe);
        }

        public ActionResult NhaXuatBanPartial()
        {
            var listNhaXuatBan = from cd in data.NHAXUATBANs select cd;
            return PartialView(listNhaXuatBan);
        }

        public ActionResult NavPartial()
        {
            return PartialView();
        }
        public ActionResult SachBanNhieuPartial()
        {
            var listSachBanNhieu = LaySachMoi(6);
            return PartialView(listSachBanNhieu);
        }
        public ActionResult SliderPartial()
        {
            return PartialView();
        }

        public ActionResult SachTheoChuDe(int id, int? page)
        {
            foreach (var item in data.CHUDEs)
            {
                if (item.MaCD == id)
                {
                    ViewBag.tenchude = item.TenChuDe.ToString();
                }
            }
            ViewBag.MACD = id;
            int Size = 3;
            int PageNum = (page ?? 1);
            var sach = (from s in data.SACHes where s.MaCD == id select s).ToList();
            return View(sach.ToPagedList(PageNum, Size));
        }

        public ActionResult SachTheoNhaXuatBan(int id, int ? page)
        {
            foreach (var item in data.CHUDEs)
            {
                if (item.MaCD == id)
                {
                    ViewBag.tenchude = item.TenChuDe.ToString();
                }
            }
            ViewBag.MACD = id;
            int Size = 3;
            int PageNum = (page ?? 1);
            var sach = (from s in data.SACHes where s.MaCD == id select s).ToList();
            return View(sach.ToPagedList(PageNum, Size));
        }

        public ActionResult ChiTietSach(int id)
        {
            var sach = from s in data.SACHes where s.MaSach == id select s;
            return View(sach.Single());
        }

        public ActionResult LoginLogout()
        {
            return PartialView("LoginLogoutPartial");
        }

    }
}