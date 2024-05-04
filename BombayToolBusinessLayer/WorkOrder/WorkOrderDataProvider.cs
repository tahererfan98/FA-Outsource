using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BO = BombayToolsEntities.BusinessEntities;
using DL = BombayToolsDataLayer.WorkOrder;
using E = BombayToolsEntities.Enums;

namespace BombayToolBusinessLayer.WorkOrder
{
    public class WorkOrderDataProvider
    {
        DL.WorkOrderDBManager DBManager = new DL.WorkOrderDBManager();

        public List<BO.WorkOrder> GetWorkOrder(DateTime startDate, DateTime endDate, string userType, int userID, string SearchCriteria, string Search, string logType)
        {
            try
            {
                DataTable workOrderListDL = new DataTable();
                int userTypeID = GetUserTypeID(userType);
                workOrderListDL = DBManager.GetWorkOrder(startDate, endDate, userTypeID, userID, SearchCriteria, Search, logType);
                List<BO.WorkOrder> workOrderBL = new List<BO.WorkOrder>();
                BO.WorkOrderList workOrderListBL = new BO.WorkOrderList();
                workOrderListBL.TotalPCs = 0;
                workOrderListBL.TotalSQM = 0;
                workOrderListBL.TotalBalancePCs = 0;
                workOrderListBL.TotalBalanceSQM = 0;
                if (workOrderListDL != null)
                {
                    int i = 0;
                    workOrderListBL.ColumnName = new string[workOrderListDL.Columns.Count];
                    foreach (DataColumn column in workOrderListDL.Columns)
                    {
                        workOrderListBL.ColumnName[i] = column.ColumnName;
                        i++;
                    }
                    foreach (DataRow row in workOrderListDL.Rows)
                    {
                        BO.WorkOrder workOrder = new BO.WorkOrder();
                        workOrder.WONO = Convert.ToString(row[workOrderListBL.ColumnName[0]]);
                        workOrder.WODate = Convert.ToString(row[workOrderListBL.ColumnName[1]]);
                        workOrder.PINO = Convert.ToString(row[workOrderListBL.ColumnName[2]]);
                        workOrder.Customer = Convert.ToString(row[workOrderListBL.ColumnName[3]]);
                        workOrder.ProjectName = Convert.ToString(row[workOrderListBL.ColumnName[4]]);
                        workOrder.PCS = Convert.ToDecimal(row[workOrderListBL.ColumnName[5]]); ;
                        workOrder.SQM = Convert.ToDecimal(row[workOrderListBL.ColumnName[6]]);
                        workOrder.Owner = Convert.ToString(row[workOrderListBL.ColumnName[7]]);
                        workOrder.SalesPerson = Convert.ToString(row[workOrderListBL.ColumnName[8]]);
                        workOrder.CustomerID = Convert.ToInt32(row[workOrderListBL.ColumnName[9]]);
                        workOrder.PIDate = Convert.ToString(row["pi date"]);
                        workOrder.PINumber = Convert.ToString(row["pi no1"]);
                        workOrder.WONumber = Convert.ToString(row["WO NO1"]);
                        workOrder.ExpectedDeliveryDate = Convert.ToString(row["Expected Delivery Date"]);
                        workOrder.ShortDescription = Convert.ToString(row["Short Desc"]);
                        workOrder.BalancePcs = Convert.ToDecimal(row["balance pcs"]);
                        workOrder.BalanceSQM = Convert.ToDecimal(row["balance sqm"]);
                        workOrder.Status = Convert.ToString(row["Status"]);
                        workOrderBL.Add(workOrder);
                    }
                    //if (workOrderListDL.Rows.Count != 0)
                    //{


                    //    int PCS = workOrderListDL.AsEnumerable().Sum(row => row.Field<int>("PCS"));
                    //    decimal SQM = workOrderListDL.AsEnumerable().Sum(row => row.Field<decimal>("SQM"));
                    //    int BalancePCS = workOrderListDL.AsEnumerable().Sum(row => row.Field<int>("Balance PCS"));
                    //    double BalanceSQM = workOrderListDL.AsEnumerable().Sum(row => row.Field<double>("balance SQM"));
                    //    //double BalancePCs = workOrderListDL.AsEnumerable().Sum(row => row.Field<double>(workOrderListBL.ColumnName[6]));

                    //    workOrderListBL.TotalPCs = Convert.ToDecimal(PCS);
                    //    workOrderListBL.TotalSQM = Convert.ToDecimal(SQM);
                    //    workOrderListBL.TotalBalancePCs = Convert.ToDecimal(BalancePCS);
                    //    workOrderListBL.TotalBalanceSQM = Convert.ToDecimal(BalanceSQM);
                    //    //pi.Amount = Convert.ToDecimal(Amount); 

                    //}
                    workOrderListBL.WOList = workOrderBL;
                }

                return workOrderBL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetUserTypeID(string userType)
        {
            if (userType == "Administrator")
            {
                userType = "admin";
            }
            if (userType.ToLower() == E.UserRoleEnum.Admin.ToString().ToLower())
            {
                return (int)E.UserRoleEnum.Admin;
            }
            //else if (userType.ToLower() == E.UserRoleEnum.Administrator.ToString().ToLower())
            //{
            //    return (int)E.UserRoleEnum.Administrator;
            //}
            else if (userType.ToLower() == E.UserRoleEnum.SalesCoordinator.ToString().ToLower())
            {
                return (int)E.UserRoleEnum.SalesCoordinator;
            }
            else if (userType.ToLower() == E.UserRoleEnum.SalesPerson.ToString().ToLower())
            {
                return (int)E.UserRoleEnum.SalesPerson;
            }
            else if (userType.ToLower() == E.UserRoleEnum.Customer.ToString().ToLower())
            {
                return (int)E.UserRoleEnum.Customer;
            }
            else
            {
                return (int)E.UserRoleEnum.None;
            }

        }
    }
}
