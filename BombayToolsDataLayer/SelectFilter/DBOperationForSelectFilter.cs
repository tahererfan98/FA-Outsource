using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.Data;
using System.Data.Sql;
using HC = BombayToolsDBConnector.Helper;
using DB = BombayToolsDataLayer;
using DBM = BombayToolsDBConnector;
using System.Data.SqlClient;

namespace BombayToolsDataLayer.SelectFilter
{

    public class DBOperationForSelectFilter
    {
        DBM.FGERPDBConnection objConn = new DBM.FGERPDBConnection();

        public DataTable GetPrincipalList(string logType)
        {
            if(logType == "FAGlass")
            {
                DataTable PrincipalDL = new DataTable();
                HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
                string strsql = " USP_PrincipalDetails ";
                PrincipalDL = db.sub_GetDatatableForFA(strsql);
                return PrincipalDL;
            }
            else
            {
                DataTable PrincipalDL = new DataTable();
                HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
                string strsql = " USP_PrincipalDetails ";
                PrincipalDL = db.sub_GetDatatableForFG(strsql);
                return PrincipalDL;
            }
        }

        public DataTable GetFieldType()
        {
            DataTable FieldDL = new DataTable();
            HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
            string strsql = " USP_FieldDropDown ";
            FieldDL = db.sub_GetDatatable(strsql);
            return FieldDL;
        }

        public DataTable GetCategoryList()
        {
            DataTable CategoryDL = new DataTable();
            HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
            string strsql = " USP_CategoryList ";
            CategoryDL = db.sub_GetDatatable(strsql);
            return CategoryDL;
        }

        public DataTable GetSectorList(string logType)
        {
            if (logType == "FAGlass")
            {
                DataTable SectorlDL = new DataTable();
                HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
                string strsql = " USP_SectorDetails ";
                SectorlDL = db.sub_GetDatatableForFA(strsql);
                return SectorlDL;
            }
            else
            {
                DataTable SectorlDL = new DataTable();
                HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
                string strsql = " USP_SectorDetails ";
                SectorlDL = db.sub_GetDatatableForFG(strsql);
                return SectorlDL;
            }
        }

        public DataTable GetIndustryList(string logType)
        {
            if (logType == "FAGlass")
            {
                DataTable IndustryDL = new DataTable();
                HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
                string strsql = " USP_IndustryDetails ";
                IndustryDL = db.sub_GetDatatableForFA(strsql);
                return IndustryDL;
            }
            else
            {
                DataTable IndustryDL = new DataTable();
                HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
                string strsql = " USP_IndustryDetails ";
                IndustryDL = db.sub_GetDatatableForFG(strsql);
                return IndustryDL;
            }
        }


        public DataTable GetStateList(string logType)
        {
            if (logType == "FAGlass")
            {
                DBM.FAglassDBConnection accessDB = new DBM.FAglassDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_State";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;

                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
            else
            {
                DBM.FGERPDBConnection accessDB = new DBM.FGERPDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_State";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;

                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }

        }

        public DataTable GetCountryList(string logType)
        {
            if (logType == "FAGlass")
            {
                DBM.FAglassDBConnection accessDB = new DBM.FAglassDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_Country";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;

                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
            else
            {
                DBM.FGERPDBConnection accessDB = new DBM.FGERPDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_Country";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;

                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }

        }

        public DataTable GetDepartmentList(string logType)
        {
            if (logType == "FAGlass")
            {
                DataTable DepartmentDL = new DataTable();
                HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
                string strsql = " USP_Department ";
                DepartmentDL = db.sub_GetDatatableForFA(strsql);
                return DepartmentDL;
            }
            else
            {
                DataTable DepartmentDL = new DataTable();
                HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
                string strsql = " USP_Department ";
                DepartmentDL = db.sub_GetDatatableForFG(strsql);
                return DepartmentDL;
            }

        }

        public DataTable GetDesignationList()
        {
            DataTable DesignationDL = new DataTable();
            HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
            string strsql = " USP_Designation ";
            DesignationDL = db.sub_GetDatatable(strsql);
            return DesignationDL;
        }

        public DataTable GetSalesPersonList()
        {
            DataTable SalesPerson = new DataTable();
            HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
            string strsql = " USP_SalesPerson ";
            SalesPerson = db.sub_GetDatatable(strsql);
            return SalesPerson;
        }

        public DataTable GetSalesCoordinatorList()
        {
            DataTable SalesCoordinatorList = new DataTable();
            HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
            string strsql = " USP_SaleCoordinator ";
            SalesCoordinatorList = db.sub_GetDatatable(strsql);
            return SalesCoordinatorList;
        }

        public DataTable GetTemplateList()
        {
            DataTable TemplateList = new DataTable();
            HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
            string strsql = " USP_QuotTemplateList ";
            TemplateList = db.sub_GetDatatableForFG(strsql);
            return TemplateList;
        }

        public DataTable GetRoleList()
        {
            DataTable TemplateList = new DataTable();
            HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
            string strsql = " USP_RoleDropdown ";
            TemplateList = db.sub_GetDatatable(strsql);
            return TemplateList;
        }

        public DataTable GetUserListToShare(int ID)
        {
            DataTable TemplateList = new DataTable();
            HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
            string strsql = " USP_UserListToShare "+ID+"";
            TemplateList = db.sub_GetDatatable(strsql);
            return TemplateList;
        }
        //Dyynamic Report
        public DataTable GetDynamicReportTables()
        {
            DataTable List = new DataTable();
            HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
            string strsql = " USP_DynamicReportTables ";
            List = db.sub_GetDatatable(strsql);
            return List;
        }

        public DataTable GetVerticalList(string logType)
        {

            if (logType == "FAGlass")
            {
                DBM.FAglassDBConnection accessDB = new DBM.FAglassDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_VerticalDropDown";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }
            else
            {
                DBM.FGERPDBConnection accessDB = new DBM.FGERPDBConnection();
                string sqlCommandString;
                using (SqlConnection connection = accessDB.GetConnection)
                {
                    //connection.Open();
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        sqlCommandString = "USP_VerticalDropDown";
                        SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                        objCommand.CommandType = CommandType.StoredProcedure;

                        DataTable dtLoginDetails = new DataTable();

                        using (SqlDataAdapter _Data = new SqlDataAdapter())
                        {
                            _Data.SelectCommand = objCommand;
                            _Data.Fill(dtLoginDetails);
                        }
                        connection.Close();
                        return dtLoginDetails;
                    }
                    catch (Exception ex)
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        throw ex;
                    }
                }
            }

        }

        public DataTable GetRegistrationTypes(string logType)
        {
           if(logType == "FAGlass")
            {
                DataTable DepartmentDL = new DataTable();
                HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
                string strsql = "USP_GetRegistrationTypes";
                DepartmentDL = db.sub_GetDatatableForFA(strsql);
                return DepartmentDL;
            }
            else
            {
                DataTable DepartmentDL = new DataTable();
                HC.DBOperationsForBombayTools db = new HC.DBOperationsForBombayTools();
                string strsql = "USP_GetRegistrationTypes";
                DepartmentDL = db.sub_GetDatatableForFG(strsql);
                return DepartmentDL;
            }
        }
    }
}
