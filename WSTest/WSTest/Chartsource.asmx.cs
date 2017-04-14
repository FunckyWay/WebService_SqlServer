using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WSTest
{
    /// <summary>
    /// Test 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class Chartsource : System.Web.Services.WebService
    {

        [WebMethod]
        public DataSet HelloWorld(string CorName)
        {
            return Dealer.GetData(CorName);
        }

        [WebMethod]
        public DataSet BuyInfo(int start_year, int start_month, int end_year, int end_month,string CorName)
        {
            return Dealer.GetInfo(start_year, start_month, end_year, end_month,CorName);
        }

        //[WebMethod]
        //public DataSet BalanceSheet()
        //{
        //    return Dealer.GetNumb();
        //}

        [WebMethod]
        public DataSet GetVelocityData(int start_year, int start_month, int end_year, int end_month, string CorName)
        {
            return Dealer.GetVelcityData(start_year, start_month, end_year, end_month,CorName);
        }

        [WebMethod]
        public DataSet GetFixedaAssets(string CorName)
        {
            return Dealer.GetFixedAssets(CorName);
        }

        [WebMethod]
        public DataSet GetMajorCost(int start_year, int start_month, int end_year, int end_month, string CorName)
        {
            return Dealer.GetMajorCost(start_year,start_month,end_year,end_month,CorName);
        }
       
        [WebMethod]
        public DataSet GetDebtAnalyse_time(int start_year, int start_month, int end_year, int end_month, string CorName)
        {
            return Dealer.GetDebtAnalyse_time(start_year, start_month, end_year, end_month,CorName);
        }

        [WebMethod]
        public DataSet Sale_ServiceAnalysis(int startyear, int startmonth, int endyear, int endmongh, string CorName)
        {
            return Dealer.GetSale_ServiceAnalysisData(startyear, startmonth, endyear, endmongh,CorName);
        }

        [WebMethod]
        public DataSet Account_Balance(int year, int month, string CorName)
        {
            return Dealer.GetAccount_BalanceData(year, month,CorName);
        }


        [WebMethod]
        public DataSet GetProfit_LosData(int year, int month, string CorName)
        {
            return Dealer.GetDataByDate(year, month, "Profit_Loss",CorName);
        }

        [WebMethod]
        public DataSet GetBusinessAnalysis(string startYear, string startMonth, string endYear, string endMonth, string CorName)
        {
            //            string sql = string.Format(select Month, Year, Vehicle, Servic, Spare, Other from BusinessAnalysis where CONVERT(date, CONVERT(varchar, Year) + '-' + CONVERT(varchar, month) + '-01')" +
            ////"between '{0}-{1}-1' and '{2}-{3}-1'  ").Tables[0].Copy(), startYear, startMonth, endYear, endMonth);
            string constr = SqlHelper.GetConnSting();
            DataSet ds = new DataSet();
            DataTable dt = SqlHelper.ExecuteDataset(constr, CommandType.Text, "select Month,Year,Vehicle,Servic,Spare,Other from BusinessAnalysis where CONVERT(date,CONVERT(varchar,Year) +'-' + CONVERT(varchar,month) +'-01')" +
"between '" + startYear + "-" + startMonth + "-1' and '" + endYear + "-" + endMonth + " - 1' and  CorName in ('" + CorName + "')").Tables[0].Copy();
            dt.TableName = "Data";
            ds.Tables.Add(dt);

            return ds;

        }

        [WebMethod]
        public DataSet GetStock(string startYear, string startMonth, string endYear, string endMonth,string CorName)
        {
            //            string sql = string.Format(select Month, Year, Vehicle, Servic, Spare, Other from BusinessAnalysis where CONVERT(date, CONVERT(varchar, Year) + '-' + CONVERT(varchar, month) + '-01')" +
            ////"between '{0}-{1}-1' and '{2}-{3}-1'  ").Tables[0].Copy(), startYear, startMonth, endYear, endMonth);
            string constr = SqlHelper.GetConnSting();
            DataSet ds = new DataSet();
            DataTable dt = SqlHelper.ExecuteDataset(constr, CommandType.Text, "select corname, Year, Month, Own, Other, owndata, otherdata from Stock where CONVERT(date, CONVERT(varchar, Year) + '-' + CONVERT(varchar, month) + '-01')" +
"between '" + startYear + "-" + startMonth + "-1' and '" + endYear + "-" + endMonth + " - 1' and  CorName in ('" + CorName + "')").Tables[0].Copy();
            string s = "select corname, Year, Month, Own, Other, owndata, otherdata from Stock where CONVERT(date, CONVERT(varchar, Year) + '-' + CONVERT(varchar, month) + '-01')" +
"between '" + startYear + "-" + startMonth + "-1' and '" + endYear + "-" + endMonth + " - 1' and  CorName in ('" + CorName + "')";
            dt.TableName = "Data";
            ds.Tables.Add(dt);

            return ds;

        }

        [WebMethod]
        public DataSet GetAssetsAndLiabilities(int Year, int Month,string CorName)
        {
            string sql = "select * from AssetsAndLiabilities where Year=" + Year + " and Month=" + Month+ "and  CorName in ('" + CorName + "')";
            string constr = SqlHelper.GetConnSting();
            DataSet ds = new DataSet();
            DataTable dt = SqlHelper.ExecuteDataset(constr, CommandType.Text, sql).Tables[0].Copy();
            dt.TableName = "Data";
            ds.Tables.Add(dt);

            return ds;
        }

        [WebMethod]
        public DataSet Login(string UserName, string PassWord)
        {
            string sqlconn = string.Format("select UserName, PassWord, LastLoginTime from Users where UserName = '{0}' and PassWord = '{1}'", UserName, PassWord);
            string constr = SqlHelper.GetConnSting();
            DataSet ds = new DataSet();
            DataTable dt = SqlHelper.ExecuteDataset(constr, CommandType.Text, sqlconn).Tables[0].Copy();
            dt.TableName = "Data";
            ds.Tables.Add(dt);
            return ds;
        }
        [WebMethod]
        public void Update(string UserName, string PassWord)
        {
            string sqlconn = string.Format("update Users set LastLoginTime = GETDATE() where  UserName = '{0}' and PassWord = '{1}'", UserName, PassWord);
            // bool user = new bool();
            using (SqlConnection connection = new SqlConnection(SqlHelper.GetConnSting()))
            {
                SqlCommand comm = new SqlCommand(sqlconn, connection);
                connection.Open();
                comm.ExecuteNonQuery();
                connection.Close();
            }

            //  return user;
        }

        [WebMethod]
        public DataSet GetLocation()
        {
            return Dealer.GetCompany_location();
        }

        [WebMethod]
        public DataSet GetCompanyName(int id)
        {
            return Dealer.GetCompany_Name(id);
        }

    }
}
