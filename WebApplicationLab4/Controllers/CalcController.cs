using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebApplicationLab4.Models;

namespace WebApplicationLab4.Controllers
{
    public class CalcController : Controller
    {

        // GET: Calc
        public ActionResult Index()
        {
            ViewBag.Compare = 25;
            return View(new Calc());
        }

        public ActionResult Calculation()
        {
            ViewBag.Calculation = HttpContext.Request.Cookies["CookieResult"].Value;
            return View();
        }


        [HttpPost]


        public ActionResult Index(Calc c, string ActButton)
        {
            ViewBag.Compare = 25;

            if (ModelState.IsValid)
            {
                sbyte OP1 = c.OP1;
                decimal OP2 = c.OP2;
                string Operation = c.Operation;
                decimal NumbResult = 0;



                switch (Operation)
                {
                    case "+":
                        NumbResult = OP1 + OP2;
                        break;
                    case "-":
                        NumbResult = OP1 - OP2;
                        break;
                    case "*":
                        NumbResult = OP1 * OP2;
                        break;
                    case "/":
                        NumbResult = OP1 / OP2;
                        break;
                }

                
                ViewBag.Result = NumbResult;



                string Result = OP1.ToString() + " " + Operation + " " + OP2.ToString() + " = " + NumbResult.ToString();

                int i = Result.LastIndexOf("=");

                Result = Result.Substring(0,i) + " ravno " + Result.Substring(i+1);


                HttpContext.Response.Cookies["CookieResult"].Value = Result;

            }
            else
            {
                ModelState.AddModelError("OP1", "Enter the required operands");
                ModelState.AddModelError("OP2", "The operand2 must be between -100 and 100");

            }



            if (ActButton == "Clear")
            {
                ModelState.Clear();

                c.OP1 = 0;
                c.OP2 = 0;
                c.Operation = null;
            }
            return View();

            
            

            

        }










    }
}