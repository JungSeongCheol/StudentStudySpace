using EddyNewHome.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EddyNewHome.Controllers
{
    public class BoardController : Controller
    {
        // GET: Board
        EddyNewHomeEntities db = new EddyNewHomeEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            BoardArticles article = new BoardArticles();
            return View(article);
        }

        [HttpPost]
        public ActionResult Create(BoardArticles article)
        {
            article.Email = "test@Text.com";
            article.BoardIDX = 2000; // 1000: 공지사항 게시판 2000:자유게시판 3000: QnA
            article.IPAddress = Commons.GetIpAddress();
            article.ViewCnt = 0;
            article.RegistDate = DateTime.Now;
            article.RegistUserName = "SYSTEM";

            try
            {
                db.Entry(article).State = System.Data.Entity.EntityState.Added;
                db.BoardArticles.Add(article);
                db.SaveChanges();

                ViewBag.Result = "OK";
            }
            catch (Exception ex)
            {
                ViewBag.Result = "FAIL";
                Debug.WriteLine(ex.Message);
            }

            return View(article);
        }

        public ActionResult List()
        {
            IEnumerable<BoardArticles> list = db.BoardArticles.ToList();
            return View(list);
        }
    }
}