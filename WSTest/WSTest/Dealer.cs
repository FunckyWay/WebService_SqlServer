using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WSTest
{
    public class Dealer
    {
        static string constr = SqlHelper.GetConnSting();
        public static DataSet GetInfo(int beginYear, int beginMonth, int endYear, int endMonth,string CorName)
        {
            DataSet ds = new DataSet();
            DataTable dt = SqlHelper.ExecuteDataset(constr, CommandType.Text, "select * from buyInfo where CONVERT(date,CONVERT(varchar,Year) +'-' + CONVERT(varchar,month) +'-01')" +
"between '" + beginYear.ToString() + "-" + beginMonth.ToString() + "-1' and '" + endYear.ToString() + "-" + endMonth.ToString() + "-1' and  CorName in ('" + CorName + "')").Tables[0].Copy();
            dt.TableName = "Info";

            ds.Tables.Add(dt);

            return ds;

        }

        public static DataSet GetMajorCost(int beginYear,int beginMonth,int endYear,int endMonth,string CorName )
        {
            DataSet ds = new DataSet();
            DataTable dt = SqlHelper.ExecuteDataset(constr, CommandType.Text, "select * from MajorCost where CONVERT(date,CONVERT(varchar,Year) +'-' + CONVERT(varchar,month) +'-01')" +
"between '" + beginYear.ToString() + "-" + beginMonth.ToString() + "-1' and '" + endYear.ToString() + "-" + endMonth.ToString() + "-1' and  CorName in ('" + CorName + "')").Tables[0].Copy();
            dt.TableName = "MajorCost";
            ds.Tables.Add(dt);
            return ds;
        }

        public static DataSet GetFixedAssets(string CorName)
        {
            DataSet ds = new DataSet();
            DataTable dt = SqlHelper.ExecuteDataset(constr, CommandType.Text, "select * from FixedAssets where CorName in ('" + CorName + "')").Tables[0].Copy();
            dt.TableName = "FixedAssets";
            ds.Tables.Add(dt);
            return ds;
        }

        public static DataSet GetData(string CorName)
        {
            DataSet ds = new DataSet();
            DataTable dt = SqlHelper.ExecuteDataset(constr, CommandType.Text, "select * from Info  where CorName in ('" + CorName + "')").Tables[0].Copy();
            dt.TableName = "Data";

            DataTable BindingX = new DataTable("BindingX");
            BindingX.Columns.Add(new DataColumn("AxistX",typeof(object)));
            DataRow row = BindingX.NewRow();
            row["AxistX"] = "Month";
            BindingX.Rows.Add(row);
          

            DataTable BindingY = new DataTable("BindingY");
            BindingY.Columns.AddRange(new DataColumn[] {
                    new DataColumn("BindingColumn",typeof(string)),
                    new DataColumn("BindingName",typeof(string))
            });

            DataRow first = BindingY.NewRow();
            first["BindingColumn"] = "TotalCar";
            first["BindingName"] = "整车";
            DataRow second = BindingY.NewRow();
            second["BindingColumn"] = "Service";
            second["BindingName"] = "服务";
            DataRow third = BindingY.NewRow();
            third["BindingColumn"] = "Part";
            third["BindingName"] = "配件";

            ds.Tables.Add(dt);
            ds.Tables.Add(BindingX);
            ds.Tables.Add(BindingY);

            return ds;

        }

        public static DataSet GetNumb(string CorName)
        {
            DataSet ds = new DataSet();
            DataTable dt = SqlHelper.ExecuteDataset(constr, CommandType.Text, "select * from BalanceSheet  where CorName in ('" + CorName + "')").Tables[0].Copy();
            dt.TableName = "Sheets";

            //DataTable BindingX = new DataTable("BindingX");
            //BindingX.Columns.Add(new DataColumn("AxistX", typeof(object)));
            //DataRow row = BindingX.NewRow();
            //row["AxistX"] = "Month";
            //BindingX.Rows.Add(row);


            //DataTable BindingY = new DataTable("BindingY");
            //BindingY.Columns.AddRange(new DataColumn[] {
            //        new DataColumn("BindingColumn",typeof(string)),
            //        new DataColumn("BindingName",typeof(string))
            //});

            //DataRow first = BindingY.NewRow();
            //first["BindingColumn"] = "TotalCar";
            //first["BindingName"] = "整车";
            //DataRow second = BindingY.NewRow();
            //second["BindingColumn"] = "Service";
            //second["BindingName"] = "服务";
            //DataRow third = BindingY.NewRow();
            //third["BindingColumn"] = "Part";
            //third["BindingName"] = "配件";


            //ds.Tables.Add(BindingX);
            //ds.Tables.Add(BindingY);
            ds.Tables.Add(dt);
            return ds;

        }

        public static DataSet GetVelcityData(int beginYear, int beginMonth, int endYear, int endMonth,string CorName)
        {
            DataSet ds = new DataSet();
            DataTable dt = SqlHelper.ExecuteDataset(constr, CommandType.Text, "select * from Velocity where CONVERT(date,CONVERT(varchar,Year) +'-' + CONVERT(varchar,month) +'-01')" +
"between '" + beginYear.ToString() + "-" + beginMonth.ToString() + "-1' and '" + endYear.ToString() + "-" + endMonth.ToString() + "-1' and  CorName in ('" + CorName + "')").Tables[0].Copy();
            dt.TableName = "Velocity";
            ds.Tables.Add(dt);
            return ds;
        }

        
        public static DataSet GetDebtAnalyse_time(int beginYear, int beginMonth, int endYear, int endMonth,string CorName)
        {
            DataSet ds = new DataSet();
            DataTable dt = SqlHelper.ExecuteDataset(constr, CommandType.Text, "select * from DebtAnalyse where CONVERT(date,CONVERT(varchar,Year) +'-' + CONVERT(varchar,month) +'-01')" +
"between '" + beginYear.ToString() + "-" + beginMonth.ToString() + "-1' and '" + endYear.ToString() + "-" + endMonth.ToString() + "-1' and  CorName in ('" + CorName + "')").Tables[0].Copy();
            dt.TableName = "DebtAnalysetime";
            ds.Tables.Add(dt);
            return ds;
        }

        public static DataSet GetDataByDate(int year, int month, string TableName,string CorName)
        {
            DataSet ds = new DataSet();
            DataTable dt = SqlHelper.ExecuteDataset(constr, CommandType.Text, "select * from " + TableName + " where Year=" + year + " and Month=" + month+ "and  CorName in ('" + CorName + "')").Tables[0].Copy();
            dt.TableName = TableName;

            ds.Tables.Add(dt.Copy());

            return ds;
        }

        public static DataSet GetSale_ServiceAnalysisData(int start_year, int start_month, int end_year, int end_month,string CorName)
        {

            string sql = "select * from Sale_ServiceAnalysis where CONVERT(date,CONVERT(varchar,Year) +'-' + CONVERT(varchar,month) +'-01')" +
"between '" + start_year + "-" + start_month + "-1' and '" + end_year + "-" + end_month + "- 1' and CorName in ('" + CorName + "')";

            //SqlParameter sy = new SqlParameter("@startYear", start_year);
            //SqlParameter ey = new SqlParameter("@endYear", end_year);
            //SqlParameter sm = new SqlParameter("@startMonth", start_month);
            //SqlParameter em = new SqlParameter("@endMonth", end_month);

            DataSet ds = SqlHelper.ExecuteDataset(constr, CommandType.Text, sql);
            return ds;
        }

        public static DataSet GetAccount_BalanceData(int year, int month,string CorName)
        {
            string sql = "select * from Account_Balance where Year=@Year and Month=@Month and CorName in ('" + CorName + "')";

            SqlParameter yp = new SqlParameter("@Year", year);
            SqlParameter mp = new SqlParameter("@Month", month);

            DataSet ds = SqlHelper.ExecuteDataset(constr, CommandType.Text, sql, yp, mp);

            return ds;
        }
        public static DataSet GetCompany_location()
        {
            DataSet ds = new DataSet();
            DataTable dt = SqlHelper.ExecuteDataset(constr, CommandType.Text, "select * from Company").Tables[0].Copy();
            dt.TableName = "Company";

            ds.Tables.Add(dt.Copy());

            return ds;
        }

        public static DataSet GetCompany_Name(int id)
        {
            DataSet ds = new DataSet();
            DataTable dt = SqlHelper.ExecuteDataset(constr, CommandType.Text, "select CorName from Company where Id = "+id).Tables[0].Copy();
            dt.TableName = "Company";

            ds.Tables.Add(dt.Copy());

            return ds;
        }

    }
}