using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TimeSoft.DataStructures.Enumerator;
using TimeSoft.DataStructures;
using TimeSoft.BusinessComponents;
using System.Threading;
using System.IO;
using System.Configuration;

namespace TimeSoftWebApp
{
    public partial class EmployeeReport : System.Web.UI.Page
    {

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (Context != null && Context.Session != null)
            {
                int count = Session.Count;
            }
        }
     

        protected void Page_Load(object sender, EventArgs e)
        {
         
            if (!IsPostBack)
            {
                DropDownListSearchCriteria.Items.Clear();
                ListItem item = new ListItem("Business Unit", SearchCriteria.BusinessUnit);
                DropDownListSearchCriteria.Items.Add(item);
                 item = new ListItem("CardNo", SearchCriteria.CardNo);
                DropDownListSearchCriteria.Items.Add(item);
                item = new ListItem("Department", SearchCriteria.Department);
                DropDownListSearchCriteria.Items.Add(item);
                item = new ListItem("Division Unit", SearchCriteria.DivisionUnit);
                DropDownListSearchCriteria.Items.Add(item);
                item = new ListItem("Employee No", SearchCriteria.EmployeeNo);
                DropDownListSearchCriteria.Items.Add(item);
                item = new ListItem("First Name", SearchCriteria.FName);
                DropDownListSearchCriteria.Items.Add(item);
                item = new ListItem("Last Name", SearchCriteria.LName);
                DropDownListSearchCriteria.Items.Add(item);
                item = new ListItem("Active", SearchCriteria.Active);
                DropDownListSearchCriteria.Items.Add(item);
                DropDownListSearchCriteria.DataBind();

                WebDateFrom.Value = DateTime.Now;
                WebDateTo.Value = DateTime.Now;
                WebDateTo.MaxDate = DateTime.Now;
                WebDateFrom.MaxDate = DateTime.Now;
               
            }
   

        }
        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBoxSearchField.Text))
            {
                LoadGridEmployee(DropDownListSearchCriteria.SelectedValue.ToString(), TextBoxSearchField.Text);
            }
            else
            {
                LabelMessageEmployee.Text = "Please Enter Search Field.";
            }
        }
        void LoadGridEmployee(string field, string searchWord)
        {
            EmployeeEntityCollection employeeEntityCollection = new EmployeeEntityCollection();
            CustomBusinessComponent customBusinessComponent = new CustomBusinessComponent(Thread.CurrentPrincipal);
            employeeEntityCollection = customBusinessComponent.Employee_FindAllBySearchWord(field, searchWord);
            GridViewEmployee.DataSource = employeeEntityCollection;
            GridViewEmployee.DataBind();
            Session["Col"] = employeeEntityCollection;
            if (employeeEntityCollection.Count == 0)
            {
                LabelMessageEmployee.Text = "No Employee record found.";
            }
            else
            {
                LabelMessageEmployee.Text = employeeEntityCollection.Count + " Employee record(s) found.";
            }

        }

        protected void GridViewEmployee_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Generate")
            {
                if ((DateTime)WebDateFrom.Value <= (DateTime)WebDateTo.Value)
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = GridViewEmployee.Rows[index];
                    int employeeID = int.Parse(GridViewEmployee.DataKeys[row.RowIndex].Values["EmployeeID"].ToString());
                    CustomBusinessComponent customBusinessComponent = new CustomBusinessComponent(Thread.CurrentPrincipal);
                    EmployeeTimeLogEntityCollection employeeTimeLogEntityCollection = customBusinessComponent.ReportTimeLogByIndividualEmployee(employeeID, (DateTime)WebDateFrom.Value, (DateTime)WebDateTo.Value);

                    string outputpath = HttpContext.Current.Server.MapPath(".") + ConfigurationManager.AppSettings["ReportPath"] + "IndividualEmployeeLogAmPM.xls";

                    try
                    {
                        if (File.Exists(outputpath))
                        {
                            File.Delete(outputpath);
                        }
                    }
                    catch (Exception ex)
                    {
                        LabelMessageEmployee.Text = ex.Message;
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
                                    strInsert = strInsert + (amLoss + pmLoss).ToString("F2");

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
                                        strInsert = strInsert + (totalAMLoss+ totalPMLoss).ToString("F2");

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
                                strInsert = strInsert + (amLoss + pmLoss).ToString("F2");

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


                        string filename = ConfigurationManager.AppSettings["ReportURL"] + "IndividualEmployeeLogAmPM.xls";
                        Response.Redirect(filename, false);
                        //Response.Write("<script language=\"javascript\" type=\"text/javascript\">window.open(\"" + filename + "\",null,\"height=500,width=700,status=yes,toolbar=no,scrollbars=yes,menubar=yes,location=no,left=30,top=10\")</script>");

                    }
                    catch (Exception ex)
                    {
                        LabelMessageEmployee.Text = ex.Message;
                    }
                    finally
                    {
                        objConn.Close();
                    }
                }
                else
                {
                    LabelMessageEmployee.Text = "Please select valid dates.";
                }              

            }
        }
        
    }
}