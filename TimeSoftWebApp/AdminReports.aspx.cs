using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TimeSoft.BusinessComponents;
using TimeSoft.DataStructures;
using System.Threading;
using System.IO;
using System.Configuration;
using TimeSoft.DataStructures.Enumerator;


namespace TimeSoftWebApp
{
    public partial class AdminReports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HttpContext.Current.User.Identity.Name))
            {
                if (!IsPostBack)
                {
                    WebDateAllEmployeeFromDate.Value = DateTime.Now;
                    WebDateAllEmployeeToDate.Value = DateTime.Now;
                    WebDateFromAllEmpAmPm.Value = DateTime.Now;
                    WebDateToAllEmpAmPm.Value = DateTime.Now;
                    WebDateFromSummaryLog.Value = DateTime.Now;
                    WebDateToSumaryLog.Value = DateTime.Now;
                    //WebDateFromByBusDivDepLoc.Value = DateTime.Now;
                    //WebDateToByBusDivDepLoc.Value = DateTime.Now;

                    //ComboBusinessComponent comboBusinessComponent = new ComboBusinessComponent(Thread.CurrentPrincipal);
                    //ComboEntityCollection comboEntityCollection = new ComboEntityCollection();
                    //comboEntityCollection = comboBusinessComponent.GetComboData(ReferenceTable.BusinessUnit, true);
                    //DropDownBusinessUnit.DataSource = comboEntityCollection;
                    //DropDownBusinessUnit.DataTextField = Combo.Description;
                    //DropDownBusinessUnit.DataValueField = Combo.ID;
                    //DropDownBusinessUnit.DataBind();

                    //comboEntityCollection = new ComboEntityCollection();
                    //comboEntityCollection = comboBusinessComponent.GetComboData(ReferenceTable.Location, true);
                    //DropDownLocation.DataSource = comboEntityCollection;
                    //DropDownLocation.DataTextField = Combo.Description;
                    //DropDownLocation.DataValueField = Combo.ID;
                    //DropDownLocation.DataBind();
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
            LabelMessage.Text = string.Empty;

        }

        protected void LinkButtonReportAllEmployee_Click(object sender, EventArgs e)
        {
            CustomBusinessComponent customBusinessComponent = new CustomBusinessComponent(Thread.CurrentPrincipal);
            EmployeeTimeLogEntityCollection employeeTimeLogEntityCollection = customBusinessComponent.ReportTimeLogForAllEmployee((DateTime)WebDateAllEmployeeFromDate.Value, (DateTime)WebDateAllEmployeeToDate.Value);

            string outputpath = HttpContext.Current.Server.MapPath(".") + ConfigurationManager.AppSettings["ReportPath"] + "AllEmployeeLog.xls";

            try
            {
                if (File.Exists(outputpath))
                {
                    File.Delete(outputpath);
                }
            }
            catch (Exception ex)
            {
                LabelMessage.Text = ex.Message;
            }
            System.Data.OleDb.OleDbConnection objConn = new System.Data.OleDb.OleDbConnection(
             "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + outputpath + ";" + "Extended Properties=Excel 8.0;");
            try
            {
                objConn.Open();
                //Creating the command
                System.Data.OleDb.OleDbCommand objCmd = new System.Data.OleDb.OleDbCommand();
                objCmd.Connection = objConn;
                //Setting the sheet name
                string strSheetName = "ALL_EMPLOYEE_TIME_LOG";

                //Creating the first row in the Excel Sheet
                string strCreate = "CREATE TABLE " + strSheetName + "(";
                strCreate = strCreate + "FIRST_NAME nvarchar(50),";
                strCreate = strCreate + "LAST_NAME nvarchar(50),";
                strCreate = strCreate + "EMPLOYEE_NO nvarchar(50),";
                strCreate = strCreate + "CARD_NO nvarchar(50),";
                strCreate = strCreate + "[DATE] nvarchar(50),";
                strCreate = strCreate + "[DAY] nvarchar(50),";
                strCreate = strCreate + "TIME_IN nvarchar(50),";
                strCreate = strCreate + "TIME_OUT nvarchar(50),";
                strCreate = strCreate + "DOOR_IN nvarchar(50),";
                strCreate = strCreate + "DOOR_OUT nvarchar(50),";
                strCreate = strCreate + "AM_TIME_LOSS  decimal(18,2),";
                strCreate = strCreate + "PM_TIME_LOSS  decimal(18,2),";
                strCreate = strCreate + "DAY_TIME_OUT  decimal(18,2),";
                strCreate = strCreate + "TOTAL_TIME_LOSS_PER_DAY  decimal(18,2),";
                strCreate = strCreate + "ERROR_MESSAGE nvarchar(50))";

                objCmd.CommandText = strCreate;
                objCmd.ExecuteNonQuery();

                //Navigating the Data View to fill into a Excel file  


                decimal totalAMLoss = 0;
                decimal totalPMLoss = 0;
                decimal totalDatOutTime = 0;

                for (int i = 0; i < employeeTimeLogEntityCollection.Count; i++)
                {

                    if (i == 0)
                    {
                        string strInsert = "Insert into " + strSheetName + "(";
                        strInsert = strInsert + "FIRST_NAME,";
                        strInsert = strInsert + "LAST_NAME,";
                        strInsert = strInsert + "EMPLOYEE_NO,";
                        strInsert = strInsert + "CARD_NO,";
                        strInsert = strInsert + "[DATE],";
                        strInsert = strInsert + "[DAY],";
                        strInsert = strInsert + "TIME_IN,";
                        strInsert = strInsert + "TIME_OUT,";
                        strInsert = strInsert + "DOOR_IN,";
                        strInsert = strInsert + "DOOR_OUT,";
                        strInsert = strInsert + "AM_TIME_LOSS,";
                        strInsert = strInsert + "PM_TIME_LOSS,";
                        strInsert = strInsert + "DAY_TIME_OUT,";
                        strInsert = strInsert + "TOTAL_TIME_LOSS_PER_DAY,";
                        strInsert = strInsert + "ERROR_MESSAGE";

                        strInsert = strInsert + ")" + "values ('";
                        strInsert = strInsert + employeeTimeLogEntityCollection[i].FName.Replace("'", "''") + "','";
                        strInsert = strInsert + employeeTimeLogEntityCollection[i].LName.Replace("'", "''") + "','";
                        strInsert = strInsert + employeeTimeLogEntityCollection[i].EmployeeNo + "','";
                        strInsert = strInsert + employeeTimeLogEntityCollection[i].CardNo + "','";
                        strInsert = strInsert + employeeTimeLogEntityCollection[i].DateTimeIn.Value.Date.ToShortDateString() + "','";
                        strInsert = strInsert + employeeTimeLogEntityCollection[i].DateTimeIn.Value.DayOfWeek.ToString() + "','";
                        strInsert = strInsert + employeeTimeLogEntityCollection[i].DateTimeIn.Value.ToShortTimeString() + "','";
                        strInsert = strInsert + employeeTimeLogEntityCollection[i].DateTimeOut.Value.ToShortTimeString() + "','";
                        strInsert = strInsert + employeeTimeLogEntityCollection[i].DoorIn + "','";
                        strInsert = strInsert + employeeTimeLogEntityCollection[i].DoorOut + "','";
                        strInsert = strInsert + ((decimal)employeeTimeLogEntityCollection[i].MorningTimeLoss / (decimal)60).ToString("F2") + "','";
                        strInsert = strInsert + ((decimal)employeeTimeLogEntityCollection[i].EndOfDayTimeLoss / (decimal)60).ToString("F2") + "','";
                        strInsert = strInsert + ((decimal)employeeTimeLogEntityCollection[i].DayTimeLoss / (decimal)60).ToString("F2") + "','";
                        strInsert = strInsert + (((decimal)employeeTimeLogEntityCollection[i].MorningTimeLoss / (decimal)60) +
                                                ((decimal)employeeTimeLogEntityCollection[i].EndOfDayTimeLoss / (decimal)60)+
                                                ((decimal)employeeTimeLogEntityCollection[i].DayTimeLoss / (decimal)60)).ToString("F2") + "','";
                        strInsert = strInsert + employeeTimeLogEntityCollection[i].Error;
                        strInsert = strInsert + "')";

                        objCmd.CommandText = strInsert;
                        objCmd.ExecuteNonQuery();

                        totalAMLoss = (decimal)employeeTimeLogEntityCollection[i].MorningTimeLoss / (decimal)60;
                        totalPMLoss = (decimal)employeeTimeLogEntityCollection[i].EndOfDayTimeLoss / (decimal)60;
                        totalDatOutTime = (decimal)employeeTimeLogEntityCollection[i].DayTimeLoss / (decimal)60;
                    }
                    else
                    {
                        string strInsert = string.Empty;
                        if (employeeTimeLogEntityCollection[i].CardNo == employeeTimeLogEntityCollection[i - 1].CardNo)
                        {

                            totalAMLoss = totalAMLoss + (decimal)employeeTimeLogEntityCollection[i].MorningTimeLoss / (decimal)60;
                            totalPMLoss = totalPMLoss + (decimal)employeeTimeLogEntityCollection[i].EndOfDayTimeLoss / (decimal)60;
                            totalDatOutTime = totalDatOutTime + (decimal)employeeTimeLogEntityCollection[i].DayTimeLoss / (decimal)60;
                        }
                        else
                        {
                            strInsert = "Insert into " + strSheetName + "(";
                            strInsert = strInsert + "AM_TIME_LOSS,";
                            strInsert = strInsert + "PM_TIME_LOSS,";
                            strInsert = strInsert + "DAY_TIME_OUT,";
                            strInsert = strInsert + "TOTAL_TIME_LOSS_PER_DAY";


                            strInsert = strInsert + ")" + "values ('";
                            strInsert = strInsert + totalAMLoss.ToString("F2") + "','";
                            strInsert = strInsert + totalPMLoss.ToString("F2") + "','";
                            strInsert = strInsert + totalDatOutTime.ToString("F2") + "','";
                            strInsert = strInsert + (totalAMLoss + totalPMLoss  + totalDatOutTime).ToString("F2") + "";
                            strInsert = strInsert + "')";

                            objCmd.CommandText = strInsert;
                            objCmd.ExecuteNonQuery();
                            totalAMLoss = 0;
                            totalPMLoss = 0;
                            totalDatOutTime = 0;

                            totalAMLoss = (decimal)employeeTimeLogEntityCollection[i].MorningTimeLoss / (decimal)60;
                            totalPMLoss = (decimal)employeeTimeLogEntityCollection[i].EndOfDayTimeLoss / (decimal)60;
                            totalDatOutTime = (decimal)employeeTimeLogEntityCollection[i].DayTimeLoss / (decimal)60;

                        }

                        strInsert = "Insert into " + strSheetName + "(";
                        strInsert = strInsert + "FIRST_NAME,";
                        strInsert = strInsert + "LAST_NAME,";
                        strInsert = strInsert + "EMPLOYEE_NO,";
                        strInsert = strInsert + "CARD_NO,";
                        strInsert = strInsert + "[DATE],";
                        strInsert = strInsert + "[DAY],";
                        strInsert = strInsert + "TIME_IN,";
                        strInsert = strInsert + "TIME_OUT,";
                        strInsert = strInsert + "DOOR_IN,";
                        strInsert = strInsert + "DOOR_OUT,";
                        strInsert = strInsert + "AM_TIME_LOSS,";
                        strInsert = strInsert + "PM_TIME_LOSS,";
                        strInsert = strInsert + "DAY_TIME_OUT,";
                        strInsert = strInsert + "TOTAL_TIME_LOSS_PER_DAY,";
                        strInsert = strInsert + "ERROR_MESSAGE";

                        strInsert = strInsert + ")" + "values ('";
                        strInsert = strInsert + employeeTimeLogEntityCollection[i].FName.Replace("'", "''") + "','";
                        strInsert = strInsert + employeeTimeLogEntityCollection[i].LName.Replace("'", "''") + "','";
                        strInsert = strInsert + employeeTimeLogEntityCollection[i].EmployeeNo + "','";
                        strInsert = strInsert + employeeTimeLogEntityCollection[i].CardNo + "','";
                        strInsert = strInsert + employeeTimeLogEntityCollection[i].DateTimeIn.Value.Date.ToShortDateString() + "','";
                        strInsert = strInsert + employeeTimeLogEntityCollection[i].DateTimeIn.Value.DayOfWeek.ToString() + "','";
                        strInsert = strInsert + employeeTimeLogEntityCollection[i].DateTimeIn.Value.ToShortTimeString() + "','";
                        strInsert = strInsert + employeeTimeLogEntityCollection[i].DateTimeOut.Value.ToShortTimeString() + "','";
                        strInsert = strInsert + employeeTimeLogEntityCollection[i].DoorIn + "','";
                        strInsert = strInsert + employeeTimeLogEntityCollection[i].DoorOut + "','";
                        strInsert = strInsert + ((decimal)employeeTimeLogEntityCollection[i].MorningTimeLoss / (decimal)60).ToString("F2") + "','";
                        strInsert = strInsert + ((decimal)employeeTimeLogEntityCollection[i].EndOfDayTimeLoss / (decimal)60).ToString("F2") + "','";
                        strInsert = strInsert + ((decimal)employeeTimeLogEntityCollection[i].DayTimeLoss / (decimal)60).ToString("F2") + "','";
                        strInsert = strInsert + (((decimal)employeeTimeLogEntityCollection[i].MorningTimeLoss / (decimal)60) +
                                                ((decimal)employeeTimeLogEntityCollection[i].EndOfDayTimeLoss / (decimal)60) +
                                                ((decimal)employeeTimeLogEntityCollection[i].DayTimeLoss / (decimal)60)).ToString("F2") + "','";
                        strInsert = strInsert + employeeTimeLogEntityCollection[i].Error;
                        strInsert = strInsert + "')";

                        objCmd.CommandText = strInsert;
                        objCmd.ExecuteNonQuery();
                    }
                    if (i == employeeTimeLogEntityCollection.Count - 1)
                    {
                        string strInsert = "Insert into " + strSheetName + "(";
                        strInsert = strInsert + "AM_TIME_LOSS,";
                        strInsert = strInsert + "PM_TIME_LOSS,";
                        strInsert = strInsert + "DAY_TIME_OUT,";
                        strInsert = strInsert + "TOTAL_TIME_LOSS_PER_DAY";


                        strInsert = strInsert + ")" + "values ('";
                        strInsert = strInsert + ((decimal)totalAMLoss ).ToString("F2") + "','";
                        strInsert = strInsert + ((decimal)totalPMLoss).ToString("F2") + "','";
                        strInsert = strInsert + ((decimal)totalDatOutTime).ToString("F2") + "','";
                        strInsert = strInsert + (totalAMLoss + totalPMLoss + totalDatOutTime).ToString("F2") + "";

                        strInsert = strInsert + "')";

                        objCmd.CommandText = strInsert;
                        objCmd.ExecuteNonQuery();
                    }
                }

                //Closing the connection
                objConn.Close();


                string filename = ConfigurationManager.AppSettings["ReportURL"] + "AllEmployeeLog.xls";
                Response.Redirect(filename, false);
                //Response.Write("<script language=\"javascript\" type=\"text/javascript\">window.open(\"" + filename + "\",null,\"height=500,width=700,status=yes,toolbar=no,scrollbars=yes,menubar=yes,location=no,left=30,top=10\")</script>");

            }
            catch (Exception ex)
            {
                LabelMessage.Text = ex.Message;
            }
            finally
            {
                objConn.Close();
            }
        }

        protected void LinkButtonGenerateEmployeeReport_Click(object sender, EventArgs e)
        {
            CustomBusinessComponent customBusinessComponent = new CustomBusinessComponent(Thread.CurrentPrincipal);
            EmployeeEntityCollection employeeEntityCollection = customBusinessComponent.Employee_FindAll();
            string outputpath = HttpContext.Current.Server.MapPath(".") + ConfigurationManager.AppSettings["ReportPath"] + "ReportEmployee.xls";

            try
            {
                if (File.Exists(outputpath))
                {
                    File.Delete(outputpath);
                }
            }
            catch (Exception ex)
            {
                LabelMessage.Text = ex.Message;
            }
            System.Data.OleDb.OleDbConnection objConn = new System.Data.OleDb.OleDbConnection(
             "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + outputpath + ";" + "Extended Properties=Excel 8.0;");
            try
            {
                objConn.Open();
                //Creating the command
                System.Data.OleDb.OleDbCommand objCmd = new System.Data.OleDb.OleDbCommand();
                objCmd.Connection = objConn;
                //Setting the sheet name
                string strSheetName = "STAFF_LIST";

                //Creating the first row in the Excel Sheet
                string strCreate = "CREATE TABLE " + strSheetName + "(";
                strCreate = strCreate + "EMPLOYEE_NO nvarchar(50),";
                strCreate = strCreate + "FIRST_NAME nvarchar(50),";
                strCreate = strCreate + "LAST_NAME nvarchar(50),";
                strCreate = strCreate + "CARD_NO nvarchar(50),";
                strCreate = strCreate + "JOB_TITLE nvarchar(50),";
                strCreate = strCreate + "HOURLY_RATE nvarchar(50),";
                strCreate = strCreate + "DEPARTMENT nvarchar(50),";
                strCreate = strCreate + "DIVISION_UNIT nvarchar(50),";
                strCreate = strCreate + "BUSINESS_UNIT nvarchar(50),";
                strCreate = strCreate + "LOCATION nvarchar(50))";

                objCmd.CommandText = strCreate;
                objCmd.ExecuteNonQuery();

                //Navigating the Data View to fill into a Excel file      

                for (int i = 0; i < employeeEntityCollection.Count; i++)
                {
                    string strInsert = "Insert into " + strSheetName + "(";
                    strInsert = strInsert + "EMPLOYEE_NO,";
                    strInsert = strInsert + "FIRST_NAME,";
                    strInsert = strInsert + "LAST_NAME,";
                    strInsert = strInsert + "CARD_NO,";
                    strInsert = strInsert + "JOB_TITLE,";
                    strInsert = strInsert + "HOURLY_RATE,";
                    strInsert = strInsert + "DEPARTMENT,";
                    strInsert = strInsert + "DIVISION_UNIT,";
                    strInsert = strInsert + "BUSINESS_UNIT,";
                    strInsert = strInsert + "LOCATION";

                    strInsert = strInsert + ")" + "values ('";
                    strInsert = strInsert + employeeEntityCollection[i].EmployeeNo + "','";
                    strInsert = strInsert + employeeEntityCollection[i].FName.Replace("'", "''") + "','";
                    strInsert = strInsert + employeeEntityCollection[i].LName.Replace("'", "''") + "','";
                    strInsert = strInsert + employeeEntityCollection[i].CardNo + "','";
                    strInsert = strInsert + employeeEntityCollection[i].JobTitle.Replace("'", "''") + "','";
                    strInsert = strInsert + employeeEntityCollection[i].RateperHour.ToString() + "','";
                    strInsert = strInsert + employeeEntityCollection[i].DepartmentDesc + "','";
                    strInsert = strInsert + employeeEntityCollection[i].DivisionUnitDesc + "','";
                    strInsert = strInsert + employeeEntityCollection[i].BusinessUnitDesc + "','";
                    strInsert = strInsert + employeeEntityCollection[i].StaffLocationDesc;
                    strInsert = strInsert + "')";

                    objCmd.CommandText = strInsert;
                    objCmd.ExecuteNonQuery();
                }

                //Closing the connection
                objConn.Close();


                string filename = ConfigurationManager.AppSettings["ReportURL"] + "ReportEmployee.xls";
                Response.Redirect(filename, false);
                //Response.Write("<script language=\"javascript\" type=\"text/javascript\">window.open(\"" + filename + "\",null,\"height=500,width=700,status=yes,toolbar=no,scrollbars=yes,menubar=yes,location=no,left=30,top=10\")</script>");

            }
            catch (Exception ex)
            {
                LabelMessage.Text = ex.Message;
            }
            finally
            {
                objConn.Close();
            }

        }

        protected void LinkButtonAllEmpAmPm_Click(object sender, EventArgs e)
        {
            CustomBusinessComponent customBusinessComponent = new CustomBusinessComponent(Thread.CurrentPrincipal);
            EmployeeTimeLogEntityCollection employeeTimeLogEntityCollection = customBusinessComponent.ReportTimeLogForAllEmployee((DateTime)WebDateFromAllEmpAmPm.Value, (DateTime)WebDateToAllEmpAmPm.Value);

            string outputpath = HttpContext.Current.Server.MapPath(".") + ConfigurationManager.AppSettings["ReportPath"] + "AllEmployeeLogAmPM.xls";

            try
            {
                if (File.Exists(outputpath))
                {
                    File.Delete(outputpath);
                }
            }
            catch (Exception ex)
            {
                LabelMessage.Text = ex.Message;
            }
            System.Data.OleDb.OleDbConnection objConn = new System.Data.OleDb.OleDbConnection(
             "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + outputpath + ";" + "Extended Properties=Excel 8.0;");
            try
            {
                objConn.Open();
                //Creating the command
                System.Data.OleDb.OleDbCommand objCmd = new System.Data.OleDb.OleDbCommand();
                objCmd.Connection = objConn;
                //Setting the sheet name
                string strSheetName = "ALL_EMPLOYEE_TIME_LOG";

                //Creating the first row in the Excel Sheet
                string strCreate = "CREATE TABLE " + strSheetName + "(";
                strCreate = strCreate + "FIRST_NAME nvarchar(50),";
                strCreate = strCreate + "LAST_NAME nvarchar(50),";
                strCreate = strCreate + "EMPLOYEE_NO nvarchar(50),";
                strCreate = strCreate + "CARD_NO nvarchar(50),";
                strCreate = strCreate + "[DATE] nvarchar(50),";
                strCreate = strCreate + "[DAY] nvarchar(50),";
                strCreate = strCreate + "TIME_IN nvarchar(50),";
                strCreate = strCreate + "TIME_OUT nvarchar(50),";
                strCreate = strCreate + "DOOR_IN nvarchar(50),";
                strCreate = strCreate + "DOOR_OUT nvarchar(50),";
                strCreate = strCreate + "AM_TIME_LOSS  decimal(18,2),";
                strCreate = strCreate + "PM_TIME_LOSS  decimal(18,2),";
                strCreate = strCreate + "TOTAL_TIME_LOSS_PER_DAY  decimal(18,2))";
                //strCreate = strCreate + "DAY_TIME_OUT decimal,";
                //strCreate = strCreate + "ERROR_MESSAGE nvarchar(50))";

                objCmd.CommandText = strCreate;
                objCmd.ExecuteNonQuery();

                //Navigating the Data View to fill into a Excel file  


                string fName = string.Empty;
                string lName = string.Empty;
                string employeeNo = string.Empty;
                string cardNo = string.Empty;
                string date = string.Empty;
                string day = string.Empty;
                string timeIn = string.Empty;
                string timeOut = string.Empty;
                string doorIn = string.Empty;
                string doorOut = string.Empty;
                decimal amLoss = 0;
                decimal pmLoss = 0;
                decimal totalAMLoss = 0;
                decimal totalPMLoss = 0;

                for (int i = 0; i < employeeTimeLogEntityCollection.Count; i++)
                {

                    if (i == 0)
                    {

                        fName = employeeTimeLogEntityCollection[i].FName.Replace("'", "''");
                        lName = employeeTimeLogEntityCollection[i].LName.Replace("'", "''");
                        employeeNo = employeeTimeLogEntityCollection[i].EmployeeNo;
                        cardNo = employeeTimeLogEntityCollection[i].CardNo.ToString();
                        date = employeeTimeLogEntityCollection[i].DateTimeIn.Value.Date.ToShortDateString();
                        day = employeeTimeLogEntityCollection[i].DateTimeIn.Value.DayOfWeek.ToString();
                        timeIn = employeeTimeLogEntityCollection[i].DateTimeIn.Value.ToShortTimeString();
                        doorIn = employeeTimeLogEntityCollection[i].DoorIn;
                        amLoss = ((decimal)employeeTimeLogEntityCollection[i].MorningTimeLoss / (decimal)60);
                    }
                    else
                    {
                        string strInsert = string.Empty;
                        if (employeeTimeLogEntityCollection[i].DateTimeIn.Value.Date == employeeTimeLogEntityCollection[i - 1].DateTimeIn.Value.Date &&
                            employeeTimeLogEntityCollection[i].CardNo == employeeTimeLogEntityCollection[i - 1].CardNo)
                        {


                        }
                        else if (employeeTimeLogEntityCollection[i].DateTimeIn.Value.Date != employeeTimeLogEntityCollection[i - 1].DateTimeIn.Value.Date ||
                            employeeTimeLogEntityCollection[i].CardNo != employeeTimeLogEntityCollection[i - 1].CardNo)
                        {

                            timeOut = employeeTimeLogEntityCollection[i - 1].DateTimeOut.Value.ToShortTimeString();
                            doorOut = employeeTimeLogEntityCollection[i - 1].DoorOut;
                            pmLoss = ((decimal)employeeTimeLogEntityCollection[i - 1].EndOfDayTimeLoss / (decimal)60);

                            strInsert = "Insert into " + strSheetName + "(";
                            strInsert = strInsert + "FIRST_NAME,";
                            strInsert = strInsert + "LAST_NAME,";
                            strInsert = strInsert + "EMPLOYEE_NO,";
                            strInsert = strInsert + "CARD_NO,";
                            strInsert = strInsert + "[DATE],";
                            strInsert = strInsert + "[DAY],";
                            strInsert = strInsert + "TIME_IN,";
                            strInsert = strInsert + "TIME_OUT,";
                            strInsert = strInsert + "DOOR_IN,";
                            strInsert = strInsert + "DOOR_OUT,";
                            strInsert = strInsert + "AM_TIME_LOSS,";
                            strInsert = strInsert + "PM_TIME_LOSS,";
                            strInsert = strInsert + "TOTAL_TIME_LOSS_PER_DAY";


                            strInsert = strInsert + ")" + "values ('";
                            strInsert = strInsert + fName + "','";
                            strInsert = strInsert + lName + "','";
                            strInsert = strInsert + employeeNo + "','";
                            strInsert = strInsert + cardNo + "','";
                            strInsert = strInsert + date + "','";
                            strInsert = strInsert + day + "','";
                            strInsert = strInsert + timeIn + "','";
                            strInsert = strInsert + timeOut + "','";
                            strInsert = strInsert + doorIn + "','";
                            strInsert = strInsert + doorOut + "','";
                            strInsert = strInsert + amLoss.ToString("F2") + "','";
                            strInsert = strInsert + pmLoss.ToString("F2") + "','";
                            strInsert = strInsert + (amLoss+pmLoss).ToString("F2");

                            strInsert = strInsert + "')";

                            objCmd.CommandText = strInsert;
                            objCmd.ExecuteNonQuery();

                            totalAMLoss = totalAMLoss + amLoss;
                            totalPMLoss = totalPMLoss + pmLoss;

                            if (employeeTimeLogEntityCollection[i].CardNo != employeeTimeLogEntityCollection[i - 1].CardNo)
                            {
                                strInsert = "Insert into " + strSheetName + "(";
                                strInsert = strInsert + "AM_TIME_LOSS,";
                                strInsert = strInsert + "PM_TIME_LOSS,";
                                strInsert = strInsert + "TOTAL_TIME_LOSS_PER_DAY";


                                strInsert = strInsert + ")" + "values ('";
                                strInsert = strInsert + totalAMLoss.ToString("F2") + "','";
                                strInsert = strInsert + totalPMLoss.ToString("F2") + "','";
                                strInsert = strInsert + (totalAMLoss+totalPMLoss).ToString("F2");

                                strInsert = strInsert + "')";

                                objCmd.CommandText = strInsert;
                                objCmd.ExecuteNonQuery();

                                totalAMLoss = 0;
                                totalPMLoss = 0;
                            }


                            fName = employeeTimeLogEntityCollection[i].FName.Replace("'", "''");
                            lName = employeeTimeLogEntityCollection[i].LName.Replace("'", "''");
                            employeeNo = employeeTimeLogEntityCollection[i].EmployeeNo;
                            cardNo = employeeTimeLogEntityCollection[i].CardNo.ToString();
                            date = employeeTimeLogEntityCollection[i].DateTimeIn.Value.Date.ToShortDateString();
                            day = employeeTimeLogEntityCollection[i].DateTimeIn.Value.DayOfWeek.ToString();
                            timeIn = employeeTimeLogEntityCollection[i].DateTimeIn.Value.ToShortTimeString();
                            doorIn = employeeTimeLogEntityCollection[i].DoorIn;
                            amLoss = ((decimal)employeeTimeLogEntityCollection[i].MorningTimeLoss / (decimal)60);
                            timeOut = string.Empty;
                            doorOut = string.Empty;
                            pmLoss = 0;
                        }
                    }
                    if (i == employeeTimeLogEntityCollection.Count - 1)
                    {
                        timeOut = employeeTimeLogEntityCollection[i].DateTimeOut.Value.ToShortTimeString();
                        doorOut = employeeTimeLogEntityCollection[i].DoorOut;
                        pmLoss = ((decimal)employeeTimeLogEntityCollection[i].EndOfDayTimeLoss / (decimal)60);

                        string strInsert = "Insert into " + strSheetName + "(";
                        strInsert = strInsert + "FIRST_NAME,";
                        strInsert = strInsert + "LAST_NAME,";
                        strInsert = strInsert + "EMPLOYEE_NO,";
                        strInsert = strInsert + "CARD_NO,";
                        strInsert = strInsert + "[DATE],";
                        strInsert = strInsert + "[DAY],";
                        strInsert = strInsert + "TIME_IN,";
                        strInsert = strInsert + "TIME_OUT,";
                        strInsert = strInsert + "DOOR_IN,";
                        strInsert = strInsert + "DOOR_OUT,";
                        strInsert = strInsert + "AM_TIME_LOSS,";
                        strInsert = strInsert + "PM_TIME_LOSS,";
                        strInsert = strInsert + "TOTAL_TIME_LOSS_PER_DAY";


                        strInsert = strInsert + ")" + "values ('";
                        strInsert = strInsert + fName + "','";
                        strInsert = strInsert + lName + "','";
                        strInsert = strInsert + employeeNo + "','";
                        strInsert = strInsert + cardNo + "','";
                        strInsert = strInsert + date + "','";
                        strInsert = strInsert + day + "','";
                        strInsert = strInsert + timeIn + "','";
                        strInsert = strInsert + timeOut + "','";
                        strInsert = strInsert + doorIn + "','";
                        strInsert = strInsert + doorOut + "','";
                        strInsert = strInsert + amLoss.ToString("F2") + "','";
                        strInsert = strInsert + pmLoss.ToString("F2") + "','";
                        strInsert = strInsert + (amLoss+pmLoss).ToString("F2");

                        strInsert = strInsert + "')";

                        objCmd.CommandText = strInsert;
                        objCmd.ExecuteNonQuery();

                        totalAMLoss = totalAMLoss + amLoss;
                        totalPMLoss = totalPMLoss + pmLoss;
                        strInsert = "Insert into " + strSheetName + "(";
                        strInsert = strInsert + "AM_TIME_LOSS,";
                        strInsert = strInsert + "PM_TIME_LOSS,";
                        strInsert = strInsert + "TOTAL_TIME_LOSS_PER_DAY";


                        strInsert = strInsert + ")" + "values ('";
                        strInsert = strInsert + totalAMLoss.ToString("F2") + "','";
                        strInsert = strInsert + totalPMLoss.ToString("F2") + "','";
                        strInsert = strInsert + (totalAMLoss + totalPMLoss).ToString("F2");

                        strInsert = strInsert + "')";

                        objCmd.CommandText = strInsert;
                        objCmd.ExecuteNonQuery();

                        totalAMLoss = 0;
                        totalPMLoss = 0;


                    }
                }

                //Closing the connection
                objConn.Close();


                string filename = ConfigurationManager.AppSettings["ReportURL"] + "AllEmployeeLogAmPM.xls";
                Response.Redirect(filename, false);
                //Response.Write("<script language=\"javascript\" type=\"text/javascript\">window.open(\"" + filename + "\",null,\"height=500,width=700,status=yes,toolbar=no,scrollbars=yes,menubar=yes,location=no,left=30,top=10\")</script>");

            }
            catch (Exception ex)
            {
                LabelMessage.Text = ex.Message;
            }
            finally
            {
                objConn.Close();
            }
        }

        protected void LinkButtonGenerateSummaryLog_Click(object sender, EventArgs e)
        {
            CustomBusinessComponent customBusinessComponent = new CustomBusinessComponent(Thread.CurrentPrincipal);
            SummaryEmployeeTimeLogEntityCollection summaryEmployeeTimeLogEntityCollection = customBusinessComponent.SummaryReportTimeLogForAllEmployee((DateTime)WebDateFromSummaryLog.Value, (DateTime)WebDateToSumaryLog.Value);

            string outputpath = HttpContext.Current.Server.MapPath(".") + ConfigurationManager.AppSettings["ReportPath"] + "SummaryTimeLogEmployeeLog.xls";

            try
            {
                if (File.Exists(outputpath))
                {
                    File.Delete(outputpath);
                }
            }
            catch (Exception ex)
            {
                LabelMessage.Text = ex.Message;
            }
            System.Data.OleDb.OleDbConnection objConn = new System.Data.OleDb.OleDbConnection(
             "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + outputpath + ";" + "Extended Properties=Excel 8.0;");
            try
            {
                objConn.Open();
                //Creating the command
                System.Data.OleDb.OleDbCommand objCmd = new System.Data.OleDb.OleDbCommand();
                objCmd.Connection = objConn;
                //Setting the sheet name
                string strSheetName = "SUMMARY_EMPLOYEE_TIME_LOG";

                //Creating the first row in the Excel Sheet
                string strCreate = "CREATE TABLE " + strSheetName + "(";
                strCreate = strCreate + "FIRST_NAME nvarchar(50),";
                strCreate = strCreate + "LAST_NAME nvarchar(50),";
                strCreate = strCreate + "EMPLOYEE_NO nvarchar(50),";
                strCreate = strCreate + "CARD_NO nvarchar(50),";
                strCreate = strCreate + "PLANNED_MANHOURS  decimal(18,2),";
                strCreate = strCreate + "ACTUAL_MANHOURS  decimal(18,2),";
                strCreate = strCreate + "AM_TIME_LOSS  decimal(18,2),";
                strCreate = strCreate + "PM_TIME_LOSS  decimal(18,2),";
                strCreate = strCreate + "TOTAL_MANHOUR_LOSS  decimal(18,2),";
                strCreate = strCreate + "HOURLY_RATE  decimal(18,2),";
                strCreate = strCreate + "COST_OF_MAN_HOUR_LOSS decimal(18,2),";
                strCreate = strCreate + "DAY_TIME_OUT  decimal(18,2),";
                strCreate = strCreate + "BUSINESS_UNIT nvarchar(50),";
                strCreate = strCreate + "DIVISION_UNIT nvarchar(50),";
                strCreate = strCreate + "DEPARTMENT nvarchar(50),";
                strCreate = strCreate + "LOCATION nvarchar(50),";
                strCreate = strCreate + "JOB_TITLE nvarchar(50))";


                //strCreate = strCreate + "ERROR_MESSAGE nvarchar(50))";

                objCmd.CommandText = strCreate;
                objCmd.ExecuteNonQuery();

                //Navigating the Data View to fill into a Excel file  
                decimal totalPlannedHours = 0;
                DateTime fromDate = (DateTime)WebDateFromSummaryLog.Value;
                DateTime toDate = (DateTime)WebDateToSumaryLog.Value;
                while (fromDate <= toDate)
                {
                    DayOfWeek day = fromDate.DayOfWeek;

                    if (day == DayOfWeek.Monday || day == DayOfWeek.Tuesday || day == DayOfWeek.Wednesday || day == DayOfWeek.Thursday)
                    {
                        totalPlannedHours = totalPlannedHours + 7.5M;
                    }
                    else if (day == DayOfWeek.Friday)
                    {
                        totalPlannedHours = totalPlannedHours + 7.0M;
                    }
                    fromDate = fromDate.AddDays(1);
                }
                for (int i = 0; i < summaryEmployeeTimeLogEntityCollection.Count; i++)
                {

                    decimal totalTimeLoss = ((decimal)(summaryEmployeeTimeLogEntityCollection[i].MorningTimeLoss + summaryEmployeeTimeLogEntityCollection[i].EndOfDayTimeLoss) / 60M);
                    string strInsert = "Insert into " + strSheetName + "(";
                    strInsert = strInsert + "FIRST_NAME,";
                    strInsert = strInsert + "LAST_NAME,";
                    strInsert = strInsert + "EMPLOYEE_NO,";
                    strInsert = strInsert + "CARD_NO,";
                    strInsert = strInsert + "PLANNED_MANHOURS,";
                    strInsert = strInsert + "ACTUAL_MANHOURS,";
                    strInsert = strInsert + "AM_TIME_LOSS,";
                    strInsert = strInsert + "PM_TIME_LOSS,";
                    strInsert = strInsert + "TOTAL_MANHOUR_LOSS,";
                    strInsert = strInsert + "HOURLY_RATE,";
                    strInsert = strInsert + "COST_OF_MAN_HOUR_LOSS,";
                    strInsert = strInsert + "DAY_TIME_OUT,";
                    strInsert = strInsert + "BUSINESS_UNIT,";
                    strInsert = strInsert + "DIVISION_UNIT,";
                    strInsert = strInsert + "DEPARTMENT,";
                    strInsert = strInsert + "LOCATION,";
                    strInsert = strInsert + "JOB_TITLE";


                    strInsert = strInsert + ")" + "values ('";
                    strInsert = strInsert + summaryEmployeeTimeLogEntityCollection[i].FName.Replace("'", "''") + "','";
                    strInsert = strInsert + summaryEmployeeTimeLogEntityCollection[i].LName.Replace("'", "''") + "','";
                    strInsert = strInsert + summaryEmployeeTimeLogEntityCollection[i].EmployeeNo + "','";
                    strInsert = strInsert + summaryEmployeeTimeLogEntityCollection[i].CardNo + "','";
                    strInsert = strInsert + totalPlannedHours.ToString("F2") + "','";
                    strInsert = strInsert + (totalPlannedHours - totalTimeLoss).ToString("F2") + "','";
                    strInsert = strInsert + ((decimal)summaryEmployeeTimeLogEntityCollection[i].MorningTimeLoss / 60M).ToString("F2") + "','";
                    strInsert = strInsert + ((decimal)summaryEmployeeTimeLogEntityCollection[i].EndOfDayTimeLoss / 60M).ToString("F2") + "','";
                    strInsert = strInsert + totalTimeLoss.ToString("F2") + "','";
                    strInsert = strInsert + summaryEmployeeTimeLogEntityCollection[i].RateperHour.ToString("F2") + "','";
                    strInsert = strInsert + (summaryEmployeeTimeLogEntityCollection[i].RateperHour * totalTimeLoss).ToString("F2") + "','";
                    strInsert = strInsert + ((decimal)summaryEmployeeTimeLogEntityCollection[i].EndOfDayTimeLoss / 60M).ToString("F2") + "','";
                    strInsert = strInsert + summaryEmployeeTimeLogEntityCollection[i].BusinessUnitDesc.Replace("'", "''") + "','";
                    strInsert = strInsert + summaryEmployeeTimeLogEntityCollection[i].DivisionUnitDesc.Replace("'", "''") + "','";
                    strInsert = strInsert + summaryEmployeeTimeLogEntityCollection[i].DepartmentDesc.Replace("'", "''") + "','";
                    strInsert = strInsert + summaryEmployeeTimeLogEntityCollection[i].LocationDesc.Replace("'", "''") + "','";
                    strInsert = strInsert + summaryEmployeeTimeLogEntityCollection[i].JobTitle.Replace("'", "''");
                    strInsert = strInsert + "')";

                    objCmd.CommandText = strInsert;
                    objCmd.ExecuteNonQuery();

                }
                //Closing the connection
                objConn.Close();


                string filename = ConfigurationManager.AppSettings["ReportURL"] + "SummaryTimeLogEmployeeLog.xls";
                Response.Redirect(filename, false);
                //Response.Write("<script language=\"javascript\" type=\"text/javascript\">window.open(\"" + filename + "\",null,\"height=500,width=700,status=yes,toolbar=no,scrollbars=yes,menubar=yes,location=no,left=30,top=10\")</script>");

            }
            catch (Exception ex)
            {
                LabelMessage.Text = ex.Message;
            }
            finally
            {
                objConn.Close();
            }
        }



        //protected void DropDownBusinessUnit_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (DropDownBusinessUnit.SelectedIndex != -1)
        //    {
        //        if (DropDownBusinessUnit.SelectedValue != "0")
        //        {
        //            ComboBusinessComponent comboBusinessComponent = new ComboBusinessComponent(Thread.CurrentPrincipal);
        //            ComboEntityCollection comboEntityCollection = new ComboEntityCollection();
        //            comboEntityCollection = comboBusinessComponent.GetComboDataByForeignnKey(ReferenceTable.DivisionUnit, int.Parse(DropDownBusinessUnit.SelectedValue), true);
        //            DropDownDivisionUnit.DataSource = comboEntityCollection;
        //            DropDownDivisionUnit.DataTextField = Combo.Description;
        //            DropDownDivisionUnit.DataValueField = Combo.ID;
        //            DropDownDivisionUnit.DataBind();

        //            comboEntityCollection = new ComboEntityCollection();
        //            DropDownDepartment.DataSource = comboEntityCollection;
        //            DropDownDepartment.DataTextField = Combo.Description;
        //            DropDownDepartment.DataValueField = Combo.ID;
        //            DropDownDepartment.DataBind();
        //        }

        //        else
        //        {
        //            ComboEntityCollection comboEntityCollection = new ComboEntityCollection();
        //            DropDownDivisionUnit.DataSource = comboEntityCollection;
        //            DropDownDivisionUnit.DataTextField = Combo.Description;
        //            DropDownDivisionUnit.DataValueField = Combo.ID;
        //            DropDownDivisionUnit.DataBind();

        //            comboEntityCollection = new ComboEntityCollection();
        //            DropDownDepartment.DataSource = comboEntityCollection;
        //            DropDownDepartment.DataTextField = Combo.Description;
        //            DropDownDepartment.DataValueField = Combo.ID;
        //            DropDownDepartment.DataBind();
        //        }
        //    }
        //    else
        //    {
        //        ComboEntityCollection comboEntityCollection = new ComboEntityCollection();
        //        DropDownDivisionUnit.DataSource = comboEntityCollection;
        //        DropDownDivisionUnit.DataTextField = Combo.Description;
        //        DropDownDivisionUnit.DataValueField = Combo.ID;
        //        DropDownDivisionUnit.DataBind();

        //        comboEntityCollection = new ComboEntityCollection();
        //        DropDownDepartment.DataSource = comboEntityCollection;
        //        DropDownDepartment.DataTextField = Combo.Description;
        //        DropDownDepartment.DataValueField = Combo.ID;
        //        DropDownDepartment.DataBind();
        //    }



        //}

        //protected void DropDownDivisionUnit_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (DropDownDivisionUnit.SelectedIndex != -1)
        //    {
        //        if (DropDownDivisionUnit.SelectedValue != "0")
        //        {
        //            ComboBusinessComponent comboBusinessComponent = new ComboBusinessComponent(Thread.CurrentPrincipal);
        //            ComboEntityCollection comboEntityCollection = new ComboEntityCollection();
        //            comboEntityCollection = comboBusinessComponent.GetComboDataByForeignnKey(ReferenceTable.Department, int.Parse(DropDownDivisionUnit.SelectedValue), true);
        //            DropDownDepartment.DataSource = comboEntityCollection;
        //            DropDownDepartment.DataTextField = Combo.Description;
        //            DropDownDepartment.DataValueField = Combo.ID;
        //            DropDownDepartment.DataBind();
        //        }
        //        else
        //        {
        //            ComboEntityCollection comboEntityCollection = new ComboEntityCollection();
        //            DropDownDepartment.DataSource = comboEntityCollection;
        //            DropDownDepartment.DataTextField = Combo.Description;
        //            DropDownDepartment.DataValueField = Combo.ID;
        //            DropDownDepartment.DataBind();
        //        }
        //    }
        //    else
        //    {
        //        ComboEntityCollection comboEntityCollection = new ComboEntityCollection();
        //        DropDownDepartment.DataSource = comboEntityCollection;
        //        DropDownDepartment.DataTextField = Combo.Description;
        //        DropDownDepartment.DataValueField = Combo.ID;
        //        DropDownDepartment.DataBind();
        //    }
        //}

        //protected void LinkButtonGenerateByBusDivDepLoc_Click(object sender, EventArgs e)
        //{
        //    CustomBusinessComponent customBusinessComponent = new CustomBusinessComponent(Thread.CurrentPrincipal);
        //    SummaryEmployeeTimeLogEntityCollection summaryEmployeeTimeLogEntityCollection = customBusinessComponent.SummaryReportTimeLogForAllEmployee((DateTime)WebDateFromSummaryLog.Value, (DateTime)WebDateToSumaryLog.Value);

        //    string outputpath = HttpContext.Current.Server.MapPath(".") + ConfigurationManager.AppSettings["ReportPath"] + "SummaryTimeLogByBusDivDepLoc.xls";

        //    try
        //    {
        //        if (File.Exists(outputpath))
        //        {
        //            File.Delete(outputpath);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LabelMessage.Text = ex.Message;
        //    }
        //    System.Data.OleDb.OleDbConnection objConn = new System.Data.OleDb.OleDbConnection(
        //     "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + outputpath + ";" + "Extended Properties=Excel 8.0;");
        //    try
        //    {
        //        objConn.Open();
        //        //Creating the command
        //        System.Data.OleDb.OleDbCommand objCmd = new System.Data.OleDb.OleDbCommand();
        //        objCmd.Connection = objConn;
        //        //Setting the sheet name

        //        string strSheetName = "SUMMARY_EMPLOYEE_TIME_LOG_FILTERED";

        //        //Creating the first row in the Excel Sheet
        //        string strCreate = "CREATE TABLE " + strSheetName + "(";
        //        strCreate = strCreate + "FIRST_NAME nvarchar(50),";
        //        strCreate = strCreate + "LAST_NAME nvarchar(50),";
        //        strCreate = strCreate + "EMPLOYEE_NO nvarchar(50),";
        //        strCreate = strCreate + "CARD_NO nvarchar(50),";
        //        strCreate = strCreate + "PLANNED_MANHOURS  decimal(18,2),";
        //        strCreate = strCreate + "ACTUAL_MANHOURS  decimal(18,2),";
        //        strCreate = strCreate + "AM_TIME_LOSS  decimal(18,2),";
        //        strCreate = strCreate + "PM_TIME_LOSS  decimal(18,2),";
        //        strCreate = strCreate + "TOTAL_MANHOUR_LOSS  decimal(18,2),";
        //        strCreate = strCreate + "HOURLY_RATE  decimal(18,2),";
        //        strCreate = strCreate + "COST_OF_MAN_HOUR_LOSS decimal(18,2),";
        //        strCreate = strCreate + "DAY_TIME_OUT  decimal(18,2),";
        //        strCreate = strCreate + "BUSINESS_UNIT nvarchar(50),";
        //        strCreate = strCreate + "DIVISION_UNIT nvarchar(50),";
        //        strCreate = strCreate + "DEPARTMENT nvarchar(50),";
        //        strCreate = strCreate + "LOCATION nvarchar(50),";
        //        strCreate = strCreate + "JOB_TITLE nvarchar(50))";


        //        //strCreate = strCreate + "ERROR_MESSAGE nvarchar(50))";

        //        objCmd.CommandText = strCreate;
        //        objCmd.ExecuteNonQuery();

        //        //Navigating the Data View to fill into a Excel file  
        //        decimal totalPlannedHours = 0;
        //        DateTime fromDate = (DateTime)WebDateFromSummaryLog.Value;
        //        DateTime toDate = (DateTime)WebDateToSumaryLog.Value;
        //        while (fromDate <= toDate)
        //        {
        //            DayOfWeek day = fromDate.DayOfWeek;

        //            if (day == DayOfWeek.Monday || day == DayOfWeek.Tuesday || day == DayOfWeek.Wednesday || day == DayOfWeek.Thursday)
        //            {
        //                totalPlannedHours = totalPlannedHours + 7.5M;
        //            }
        //            else if (day == DayOfWeek.Friday)
        //            {
        //                totalPlannedHours = totalPlannedHours + 7.0M;
        //            }
        //            fromDate = fromDate.AddDays(1);
        //        }
        //        for (int i = 0; i < summaryEmployeeTimeLogEntityCollection.Count; i++)
        //        {

        //            decimal totalTimeLoss = ((decimal)(summaryEmployeeTimeLogEntityCollection[i].MorningTimeLoss + summaryEmployeeTimeLogEntityCollection[i].EndOfDayTimeLoss) / 60M);
        //            string strInsert = "Insert into " + strSheetName + "(";
        //            strInsert = strInsert + "FIRST_NAME,";
        //            strInsert = strInsert + "LAST_NAME,";
        //            strInsert = strInsert + "EMPLOYEE_NO,";
        //            strInsert = strInsert + "CARD_NO,";
        //            strInsert = strInsert + "PLANNED_MANHOURS,";
        //            strInsert = strInsert + "ACTUAL_MANHOURS,";
        //            strInsert = strInsert + "AM_TIME_LOSS,";
        //            strInsert = strInsert + "PM_TIME_LOSS,";
        //            strInsert = strInsert + "TOTAL_MANHOUR_LOSS,";
        //            strInsert = strInsert + "HOURLY_RATE,";
        //            strInsert = strInsert + "COST_OF_MAN_HOUR_LOSS,";
        //            strInsert = strInsert + "DAY_TIME_OUT,";
        //            strInsert = strInsert + "BUSINESS_UNIT,";
        //            strInsert = strInsert + "DIVISION_UNIT,";
        //            strInsert = strInsert + "DEPARTMENT,";
        //            strInsert = strInsert + "LOCATION,";
        //            strInsert = strInsert + "JOB_TITLE";


        //            strInsert = strInsert + ")" + "values ('";
        //            strInsert = strInsert + summaryEmployeeTimeLogEntityCollection[i].FName.Replace("'", "''") + "','";
        //            strInsert = strInsert + summaryEmployeeTimeLogEntityCollection[i].LName.Replace("'", "''") + "','";
        //            strInsert = strInsert + summaryEmployeeTimeLogEntityCollection[i].EmployeeNo + "','";
        //            strInsert = strInsert + summaryEmployeeTimeLogEntityCollection[i].CardNo + "','";
        //            strInsert = strInsert + totalPlannedHours.ToString("F2") + "','";
        //            strInsert = strInsert + (totalPlannedHours - totalTimeLoss).ToString("F2") + "','";
        //            strInsert = strInsert + ((decimal)summaryEmployeeTimeLogEntityCollection[i].MorningTimeLoss / 60M).ToString("F2") + "','";
        //            strInsert = strInsert + ((decimal)summaryEmployeeTimeLogEntityCollection[i].EndOfDayTimeLoss / 60M).ToString("F2") + "','";
        //            strInsert = strInsert + totalTimeLoss.ToString("F2") + "','";
        //            strInsert = strInsert + summaryEmployeeTimeLogEntityCollection[i].RateperHour.ToString("F2") + "','";
        //            strInsert = strInsert + (summaryEmployeeTimeLogEntityCollection[i].RateperHour * totalTimeLoss).ToString("F2") + "','";
        //            strInsert = strInsert + ((decimal)summaryEmployeeTimeLogEntityCollection[i].EndOfDayTimeLoss / 60M).ToString("F2") + "','";
        //            strInsert = strInsert + summaryEmployeeTimeLogEntityCollection[i].BusinessUnitDesc.Replace("'", "''") + "','";
        //            strInsert = strInsert + summaryEmployeeTimeLogEntityCollection[i].DivisionUnitDesc.Replace("'", "''") + "','";
        //            strInsert = strInsert + summaryEmployeeTimeLogEntityCollection[i].DepartmentDesc.Replace("'", "''") + "','";
        //            strInsert = strInsert + summaryEmployeeTimeLogEntityCollection[i].LocationDesc.Replace("'", "''") + "','";
        //            strInsert = strInsert + summaryEmployeeTimeLogEntityCollection[i].JobTitle.Replace("'", "''");
        //            strInsert = strInsert + "')";

        //            objCmd.CommandText = strInsert;
        //            objCmd.ExecuteNonQuery();

        //        }
        //        //Closing the connection
        //        objConn.Close();


        //        string filename = ConfigurationManager.AppSettings["ReportURL"] + "SummaryTimeLogByBusDivDepLoc.xls";
        //        Response.Redirect(filename, false);
        //        //Response.Write("<script language=\"javascript\" type=\"text/javascript\">window.open(\"" + filename + "\",null,\"height=500,width=700,status=yes,toolbar=no,scrollbars=yes,menubar=yes,location=no,left=30,top=10\")</script>");

        //    }
        //    catch (Exception ex)
        //    {
        //        LabelMessage.Text = ex.Message;
        //    }
        //    finally
        //    {
        //        objConn.Close();
        //    }
        //}
    }
}