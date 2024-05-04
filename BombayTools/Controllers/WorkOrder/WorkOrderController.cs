using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBView = BombayToolBusinessLayer.WorkOrder;
using BO = BombayToolsEntities.BusinessEntities;
using BombayTools.Filters;
using System.Diagnostics;
using System.IO;
using System.Data.OleDb;
using System.Data;
using Newtonsoft.Json;

namespace BombayTools.Controllers.WorkOrder
{
    [UserAuthenticationFilter]
    public class WorkOrderController : Controller
    {
        // GET: WorkOrder
        DBView.WorkOrderDataProvider FNBusinessLayer = new DBView.WorkOrderDataProvider();

        public ActionResult WorkOrder()
        {
            return View();
        }

        public ActionResult GetWorkOrderList(DateTime startDate, DateTime endDate, string SearchCriteria, string Search)
        {
            var UserID = Convert.ToInt32(Session["userid"]);
            var UserType = Convert.ToString(Session["usertype"]);
            List<BO.WorkOrder> proformaInvoiceList = FNBusinessLayer.GetWorkOrder(startDate, endDate, UserType, UserID, SearchCriteria, Search, Convert.ToString(Session["LoginType"]));
            var jsonResult = Json(proformaInvoiceList, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;

        }



    }
}