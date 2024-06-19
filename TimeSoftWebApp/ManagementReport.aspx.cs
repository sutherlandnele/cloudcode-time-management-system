using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Collections;
using System.Configuration;
using System.IO;
using TimeSoft.DataStructures;
using TimeSoft.BusinessComponents;
using System.Threading;
using TimeSoft.DataStructures.Enumerator;

namespace TimeSoftWebApp
{
    public partial class ManagementReport : System.Web.UI.Page
    {
        string reportPath = HttpContext.Current.Server.MapPath("CrystalReports\\ReportByBusinessUnit.rpt");
        ReportDocument Report;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                WebDateAllBusinessFromDate.Value = DateTime.Now.Date;
                WebDateAllBusinessToDate.Value = DateTime.Now.Date;
                WebDateAllBusinessFromDate.MaxDate = DateTime.Now.Date;
                WebDateAllBusinessToDate.MaxDate = DateTime.Now.Date;
                WebDateBusUnitFrom.Value = DateTime.Now.Date;
                WebDateBusinessUnitTo.Value = DateTime.Now.Date;
                WebDateBusUnitFrom.MaxDate = DateTime.Now.Date;
                WebDateBusinessUnitTo.MaxDate = DateTime.Now.Date;
                WebDateDivFromDate.Value = DateTime.Now.Date;
                WebDateDivToDate.Value = DateTime.Now.Date;
                WebDateDivFromDate.MaxDate = DateTime.Now.Date;
                WebDateDivToDate.MaxDate = DateTime.Now.Date;
                WebDateDepFromDate.Value = DateTime.Now.Date;
                WebDateDepToDate.Value = DateTime.Now.Date;
                WebDateDepFromDate.MaxDate = DateTime.Now.Date;
                WebDateDepToDate.MaxDate = DateTime.Now.Date;

                PanelAllBusiness.Visible = false;
                PanelBusinessUnit.Visible = false;
                PanelDivision.Visible = false;
                PanelDepartment.Visible = false;

                ComboEntityCollection comboEntityCollectionBusUnit = new ComboEntityCollection();
                ComboBusinessComponent comboBusinessComponent = new ComboBusinessComponent(Thread.CurrentPrincipal);
                comboEntityCollectionBusUnit = comboBusinessComponent.GetComboData(ReferenceTable.BusinessUnit, true);

                UserBusinessComponent userBusinessComponent = new UserBusinessComponent(Thread.CurrentPrincipal);
                UserEntity userEntity = userBusinessComponent.GetByUserName(HttpContext.Current.User.Identity.Name);
                if (userEntity != null)
                {
                    if (userEntity.RoleID == (int)Role.BusinessHead)
                    {
                        PanelBusinessUnit.Visible = true;
                        PanelDivision.Visible = true;
                        PanelDepartment.Visible = true;
                        DropDownListBusinessUnit.DataSource = null;
                        DropDownListDivBusinessUnit.DataSource = null;
                        DropDownListDepBusinessUnit.DataSource = null;
                        DropDownListBusinessUnit.DataBind();
                        DropDownListDivBusinessUnit.DataBind();
                        DropDownListDepBusinessUnit.DataBind();

                        for (int i = 0; i < comboEntityCollectionBusUnit.Count; i++)
                        {
                            if (userEntity.BusinessUnitID != null)
                            {
                                if ((int)userEntity.BusinessUnitID == comboEntityCollectionBusUnit[i].ComboID ||
                                    comboEntityCollectionBusUnit[i].ComboID == 0)
                                {
                                    ListItem item = new ListItem(comboEntityCollectionBusUnit[i].ComboDesc,comboEntityCollectionBusUnit[i].ComboID.ToString());
                                    DropDownListBusinessUnit.Items.Add(item);
                                    DropDownListDivBusinessUnit.Items.Add(item);
                                    DropDownListDepBusinessUnit.Items.Add(item);
                                }
                            }                          
                        }
                        DropDownListBusinessUnit.DataBind();
                        DropDownListDivBusinessUnit.DataBind();
                        DropDownListDepBusinessUnit.DataBind();
                    }
                    else if (userEntity.RoleID == (int)Role.DivisionHead)
                    {
                        PanelDivision.Visible = true;
                        PanelDepartment.Visible = true;
                        DropDownListDivBusinessUnit.DataSource = null;
                        DropDownListDepBusinessUnit.DataSource = null;
                        DropDownListDivBusinessUnit.DataBind();
                        DropDownListDepBusinessUnit.DataBind();
                        for (int i = 0; i < comboEntityCollectionBusUnit.Count; i++)
                        {                          

                            if (userEntity.BusinessUnitID != null)
                            {
                                if ((int)userEntity.BusinessUnitID == comboEntityCollectionBusUnit[i].ComboID
                            || comboEntityCollectionBusUnit[i].ComboID == 0)
                                {
                                    ListItem item = new ListItem(comboEntityCollectionBusUnit[i].ComboDesc, comboEntityCollectionBusUnit[i].ComboID.ToString());
                                    DropDownListDivBusinessUnit.Items.Add(item);
                                    DropDownListDepBusinessUnit.Items.Add(item);
                                }
                            } 
                        }
                        DropDownListDivBusinessUnit.DataBind();
                        DropDownListDepBusinessUnit.DataBind();                      

                    }
                    else if (userEntity.RoleID == (int)Role.DepartmentManager)
                    {                       
                        PanelDepartment.Visible = true;                       
                        DropDownListDepBusinessUnit.DataSource = null;
                        DropDownListDepBusinessUnit.DataBind();
                        for (int i = 0; i < comboEntityCollectionBusUnit.Count; i++)
                        {
                            if (userEntity.BusinessUnitID != null)
                            {
                                if ((int)userEntity.BusinessUnitID == comboEntityCollectionBusUnit[i].ComboID
                                    || comboEntityCollectionBusUnit[i].ComboID == 0)
                                {
                                    ListItem item = new ListItem(comboEntityCollectionBusUnit[i].ComboDesc, comboEntityCollectionBusUnit[i].ComboID.ToString());
                                    DropDownListDepBusinessUnit.Items.Add(item);
                                }
                            }
                        }                      
                        DropDownListDepBusinessUnit.DataBind();       
                    }
                    else if (userEntity.RoleID == (int)Role.Chief || userEntity.RoleID == (int)Role.MD ||
                        userEntity.RoleID == (int)Role.Admin)
                    {
                        PanelAllBusiness.Visible = true;
                        PanelBusinessUnit.Visible = true;
                        PanelDivision.Visible = true;
                        PanelDepartment.Visible = true;

                      
                        comboEntityCollectionBusUnit = new ComboEntityCollection();
                        comboEntityCollectionBusUnit = comboBusinessComponent.GetComboData(ReferenceTable.BusinessUnit, true);
                        DropDownListBusinessUnit.DataSource = comboEntityCollectionBusUnit;
                        DropDownListBusinessUnit.DataTextField = Combo.Description;
                        DropDownListBusinessUnit.DataValueField = Combo.ID;
                        DropDownListBusinessUnit.DataBind();
                        comboEntityCollectionBusUnit = new ComboEntityCollection();
                        comboEntityCollectionBusUnit = comboBusinessComponent.GetComboData(ReferenceTable.BusinessUnit, true);
                        DropDownListDivBusinessUnit.DataSource = comboEntityCollectionBusUnit;
                        DropDownListDivBusinessUnit.DataTextField = Combo.Description;
                        DropDownListDivBusinessUnit.DataValueField = Combo.ID;
                        DropDownListDivBusinessUnit.DataBind();
                        comboEntityCollectionBusUnit = new ComboEntityCollection();
                        comboEntityCollectionBusUnit = comboBusinessComponent.GetComboData(ReferenceTable.BusinessUnit, true);
                        DropDownListDepBusinessUnit.DataSource = comboEntityCollectionBusUnit;
                        DropDownListDepBusinessUnit.DataTextField = Combo.Description;
                        DropDownListDepBusinessUnit.DataValueField = Combo.ID;
                        DropDownListDepBusinessUnit.DataBind();

                    }
                    else
                    {
                        Response.Redirect("AccessDenied.aspx");
                    }

                }
            }

            LabelMessage.Text = string.Empty;
        }

        private void SetCurrentValuesForParameterField(ReportDocument reportDocument, ArrayList arrayList, string reportName)
        {
            ParameterValues currentParameterValues = new ParameterValues();
            foreach (object submittedValue in arrayList)
            {
                ParameterDiscreteValue parameterDiscreteValue = new ParameterDiscreteValue();
                parameterDiscreteValue.Value = submittedValue;
                currentParameterValues.Add(parameterDiscreteValue);
            }
            ParameterFieldDefinitions parameterFieldDefinitions = reportDocument.DataDefinition.ParameterFields;
            ParameterFieldDefinition parameterFieldDefinition = parameterFieldDefinitions[reportName];
            parameterFieldDefinition.ApplyCurrentValues(currentParameterValues);
        }
        
        private void SetDBLogonForReport(ConnectionInfo connectionInfo, ReportDocument reportDocument)
        {
            Tables tables = reportDocument.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table table in tables)
            {
                TableLogOnInfo tableLogonInfo = table.LogOnInfo;
                tableLogonInfo.ConnectionInfo = connectionInfo;
                table.ApplyLogOnInfo(tableLogonInfo);

                table.Location = connectionInfo.DatabaseName + ".dbo." + table.Location.Substring(table.Location.LastIndexOf(".") + 1);
            }
        }

        public void SetDBLogonForSubReports(ConnectionInfo connectionInfo, ReportDocument reportDocument)
        {
            Sections sections = reportDocument.ReportDefinition.Sections;

            foreach (Section section in sections)
            {
                ReportObjects reportObjects = section.ReportObjects;
                foreach (ReportObject reportObject in reportObjects)
                {
                    if (reportObject.Kind == ReportObjectKind.SubreportObject)
                    {
                        SubreportObject subreportObject = (SubreportObject)reportObject;
                        ReportDocument subReportDocument = subreportObject.OpenSubreport(subreportObject.SubreportName);
                        SetDBLogonForReport(connectionInfo, subReportDocument);
                    }
                }
            }
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            if (Report != null)
            {
                Report.Close();
                Report.Dispose();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        private void SetSubReportParameters(ReportDocument reportDocument, string subReport, int id, string Param)
        {
            reportDocument.SetParameterValue(Param, id, subReport);
        }

        private void SetSubReportParametersDates(ReportDocument reportDocument, string subReport, DateTime date, string Param)
        {
            reportDocument.SetParameterValue(Param, date, subReport);
        }

        #region Report by Business Unit
        protected void LinkButtonGenerateByBusinessUnit_Click(object sender, EventArgs e)
        {
            if (((DateTime)WebDateBusUnitFrom.Value).Date <= ((DateTime)WebDateBusinessUnitTo.Value).Date)
            {
                ConfigureCrystalReports();
            }
            else
            {
                LabelMessage.Text = "Please select valid dates.";
            }
        }

        private void ConfigureCrystalReports()
        {
            reportPath = HttpContext.Current.Server.MapPath("CrystalReports\\ReportByBusinessUnit.rpt");
            DateTime fromDate = ((DateTime)WebDateBusUnitFrom.Value).Date;
            DateTime toDate = ((DateTime)WebDateBusinessUnitTo.Value).Date;
            int businessUnitID = int.Parse(DropDownListBusinessUnit.SelectedValue);

            string reportName = "Report_By_BusinessUnit.pdf";
            Report = new ReportDocument();
            Report.Load(reportPath);

            int waste = Report.ParameterFields.Count;
            ConnectionInfo connectionInfo = new ConnectionInfo();

            connectionInfo.DatabaseName = ConfigurationManager.AppSettings["Database"];
            connectionInfo.UserID = ConfigurationManager.AppSettings["UserID"];
            connectionInfo.Password = ConfigurationManager.AppSettings["Password"];
            connectionInfo.ServerName = ConfigurationManager.AppSettings["Server"];
            connectionInfo.IntegratedSecurity = bool.Parse(ConfigurationManager.AppSettings["Security"]);
            connectionInfo.Type = ConnectionInfoType.CRQE;

            SetDBLogonForReport(connectionInfo, Report);
            SetDBLogonForSubReports(connectionInfo, Report);

            ArrayList arrayListFromDate = new ArrayList();
            arrayListFromDate.Add(fromDate);
            ArrayList arrayListToDate = new ArrayList();
            arrayListToDate.Add(toDate);
            ArrayList arrayListBusinessUnitID = new ArrayList();
            arrayListBusinessUnitID.Add(businessUnitID);

            SetCurrentValuesForParameterField(Report, arrayListFromDate, "@FromDate");
            SetCurrentValuesForParameterField(Report, arrayListToDate, "@ToDate");
            SetCurrentValuesForParameterField(Report, arrayListBusinessUnitID, "@BusinessUnitID");

            SetSubReportParametersDates(Report, "ReportByBusinessUnitChart.rpt", fromDate, "@FromDate");
            SetSubReportParametersDates(Report, "ReportByBusinessUnitChart.rpt", toDate, "@ToDate");
            SetSubReportParameters(Report, "ReportByBusinessUnitChart.rpt", businessUnitID, "@BusinessUnitID");

            SetSubReportParametersDates(Report, "ReportByBusinessUnitChartAmPM.rpt", fromDate, "@FromDate");
            SetSubReportParametersDates(Report, "ReportByBusinessUnitChartAmPM.rpt", toDate, "@ToDate");
            SetSubReportParameters(Report, "ReportByBusinessUnitChartAmPM.rpt", businessUnitID, "@BusinessUnitID");

            ExportOptions exportOpts = new ExportOptions();
            PdfRtfWordFormatOptions pdfopts = new PdfRtfWordFormatOptions();
            DiskFileDestinationOptions diskOpts = new DiskFileDestinationOptions();
            exportOpts = Report.ExportOptions;
            exportOpts.ExportFormatType = ExportFormatType.PortableDocFormat;
            exportOpts.FormatOptions = pdfopts;
            exportOpts.ExportDestinationType = ExportDestinationType.DiskFile;
            diskOpts.DiskFileName = Server.MapPath(ConfigurationManager.AppSettings["PDFPath"] + "\\" + reportName);
            exportOpts.DestinationOptions = diskOpts;
            Report.Export();
            reportName =  ConfigurationManager.AppSettings["PDFPath"] + "/" + reportName;
            Response.Write("<script language=\"javascript\" type=\"text/javascript\">window.open(\"" + reportName + "\",null,\"height=800,width=900,status=yes,toolbar=no,scrollbars=yes,menubar=yes,location=no,left=30,top=10\")</script>");
        }

        #endregion

        #region Report By Division Unit
        protected void LinkButtonGenerateByDivision_Click(object sender, EventArgs e)
        {
            if (((DateTime)WebDateDivFromDate.Value).Date <= ((DateTime)WebDateDivToDate.Value).Date)
            {
                if (DropDownDivDivisionUnit.SelectedIndex != -1)
                {
                    if (DropDownDivDivisionUnit.SelectedValue != "0")
                    {
                        ConfigureCrystalReports_Division();
                    }
                    else
                    {
                        LabelMessage.Text = "Please select a Division Unit.";
                    }
                }
                else
                {
                    LabelMessage.Text = "Please select a Division Unit.";
                }

            }
            else
            {
                LabelMessage.Text = "Please select valid dates.";
            }
        }

        private void ConfigureCrystalReports_Division()
        {
            reportPath = HttpContext.Current.Server.MapPath("CrystalReports\\ReportByDivisionUnit.rpt");
            DateTime fromDate = ((DateTime)WebDateDivFromDate.Value).Date;
            DateTime toDate = ((DateTime)WebDateDivToDate.Value).Date;
            int divisionUnitID = int.Parse(DropDownDivDivisionUnit.SelectedValue);

            string reportName = "Report_By_DivisionUnit.pdf";
            Report = new ReportDocument();
            Report.Load(reportPath);

            int waste = Report.ParameterFields.Count;
            ConnectionInfo connectionInfo = new ConnectionInfo();

            connectionInfo.DatabaseName = ConfigurationManager.AppSettings["Database"];
            connectionInfo.UserID = ConfigurationManager.AppSettings["UserID"];
            connectionInfo.Password = ConfigurationManager.AppSettings["Password"];
            connectionInfo.ServerName = ConfigurationManager.AppSettings["Server"];
            connectionInfo.IntegratedSecurity = bool.Parse(ConfigurationManager.AppSettings["Security"]);
            connectionInfo.Type = ConnectionInfoType.CRQE;

            SetDBLogonForReport(connectionInfo, Report);
            SetDBLogonForSubReports(connectionInfo, Report);

            ArrayList arrayListFromDate = new ArrayList();
            arrayListFromDate.Add(fromDate);
            ArrayList arrayListToDate = new ArrayList();
            arrayListToDate.Add(toDate);
            ArrayList arrayListDivisionID = new ArrayList();
            arrayListDivisionID.Add(divisionUnitID);

            SetCurrentValuesForParameterField(Report, arrayListFromDate, "@FromDate");
            SetCurrentValuesForParameterField(Report, arrayListToDate, "@ToDate");
            SetCurrentValuesForParameterField(Report, arrayListDivisionID, "@DivisionUnitID");

            SetSubReportParametersDates(Report, "ReportByDivisionUnitChart.rpt", fromDate, "@FromDate");
            SetSubReportParametersDates(Report, "ReportByDivisionUnitChart.rpt", toDate, "@ToDate");
            SetSubReportParameters(Report, "ReportByDivisionUnitChart.rpt", divisionUnitID, "@DivisionUnitID");

            SetSubReportParametersDates(Report, "ReportByDivisionUnitChartAMPM.rpt", fromDate, "@FromDate");
            SetSubReportParametersDates(Report, "ReportByDivisionUnitChartAMPM.rpt", toDate, "@ToDate");
            SetSubReportParameters(Report, "ReportByDivisionUnitChartAMPM.rpt", divisionUnitID, "@DivisionUnitID");



            ExportOptions exportOpts = new ExportOptions();
            PdfRtfWordFormatOptions pdfopts = new PdfRtfWordFormatOptions();
            DiskFileDestinationOptions diskOpts = new DiskFileDestinationOptions();
            exportOpts = Report.ExportOptions;
            exportOpts.ExportFormatType = ExportFormatType.PortableDocFormat;
            exportOpts.FormatOptions = pdfopts;
            exportOpts.ExportDestinationType = ExportDestinationType.DiskFile;
            diskOpts.DiskFileName = Server.MapPath(ConfigurationManager.AppSettings["PDFPath"] + "\\" + reportName);
            exportOpts.DestinationOptions = diskOpts;
            Report.Export();
            reportName =  ConfigurationManager.AppSettings["PDFPath"] + "/" + reportName;
            Response.Write("<script language=\"javascript\" type=\"text/javascript\">window.open(\"" + reportName + "\",null,\"height=800,width=900,status=yes,toolbar=no,scrollbars=yes,menubar=yes,location=no,left=30,top=10\")</script>");
        }

        protected void DropDownListDivBusinessUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListDivBusinessUnit.SelectedIndex != -1)
            {
                int businessUnitID = int.Parse(DropDownListDivBusinessUnit.SelectedValue.ToString());
                ComboEntityCollection comboEntityCollection = new ComboEntityCollection();
                ComboBusinessComponent comboBusinessComponent = new ComboBusinessComponent(Thread.CurrentPrincipal);
                comboEntityCollection = comboBusinessComponent.GetComboDataByForeignnKey(ReferenceTable.DivisionUnit, businessUnitID, true);
               
                UserBusinessComponent userBusinessComponent = new UserBusinessComponent(Thread.CurrentPrincipal);
                UserEntity userEntity = userBusinessComponent.GetByUserName(HttpContext.Current.User.Identity.Name);
                if (userEntity != null)
                {
                    if (userEntity.RoleID == (int)Role.DivisionHead)
                    {
                        DropDownDivDivisionUnit.DataSource = null;
                        DropDownDivDivisionUnit.DataBind();
                        for (int i = 0; i < comboEntityCollection.Count; i++)
                        {

                            if (userEntity.DivisionUnitID != null)
                            {
                                if ((int)userEntity.DivisionUnitID == comboEntityCollection[i].ComboID
                                    || comboEntityCollection[i].ComboID == 0)
                                {
                                    ListItem item = new ListItem(comboEntityCollection[i].ComboDesc, comboEntityCollection[i].ComboID.ToString());
                                    DropDownDivDivisionUnit.Items.Add(item);
                                }
                            }
                        }
                        DropDownDivDivisionUnit.DataBind();
                    }
                    else
                    {
                        DropDownDivDivisionUnit.DataSource = comboEntityCollection;
                        DropDownDivDivisionUnit.DataTextField = Combo.Description;
                        DropDownDivDivisionUnit.DataValueField = Combo.ID;
                        DropDownDivDivisionUnit.DataBind();
                    }
                }
            }
            else
            {
                ComboEntityCollection comboEntityCollection = new ComboEntityCollection();
                DropDownDivDivisionUnit.DataSource = comboEntityCollection;
                DropDownDivDivisionUnit.DataBind();
            }
        }


        #endregion

        #region Report By Department
        protected void LinkButtonReportByDepartment_Click(object sender, EventArgs e)
        {
            if (((DateTime)WebDateDepFromDate.Value).Date <= ((DateTime)WebDateDepToDate.Value).Date)
            {
                if (DropDownListDepDepartment.SelectedIndex != -1)
                {
                    if (DropDownListDepDepartment.SelectedValue != "0")
                    {
                        ConfigureCrystalReports_Department();
                    }
                    else
                    {
                        LabelMessage.Text = "Please select a Department.";
                    }
                }
                else
                {
                    LabelMessage.Text = "Please select a Department.";
                }

            }
            else
            {
                LabelMessage.Text = "Please select valid dates.";
            }
        }

        private void ConfigureCrystalReports_Department()
        {
            reportPath = HttpContext.Current.Server.MapPath("CrystalReports\\ReportByDepartment.rpt");
            DateTime fromDate = ((DateTime)WebDateDepFromDate.Value).Date;
            DateTime toDate = ((DateTime)WebDateDepToDate.Value).Date;
            int departmentID = int.Parse(DropDownListDepDepartment.SelectedValue);

            string reportName = "Report_By_Department.pdf";
            Report = new ReportDocument();
            Report.Load(reportPath);

            int waste = Report.ParameterFields.Count;
            ConnectionInfo connectionInfo = new ConnectionInfo();

            connectionInfo.DatabaseName = ConfigurationManager.AppSettings["Database"];
            connectionInfo.UserID = ConfigurationManager.AppSettings["UserID"];
            connectionInfo.Password = ConfigurationManager.AppSettings["Password"];
            connectionInfo.ServerName = ConfigurationManager.AppSettings["Server"];
            connectionInfo.IntegratedSecurity = bool.Parse(ConfigurationManager.AppSettings["Security"]);
            connectionInfo.Type = ConnectionInfoType.CRQE;

            SetDBLogonForReport(connectionInfo, Report);
            SetDBLogonForSubReports(connectionInfo, Report);

            ArrayList arrayListFromDate = new ArrayList();
            arrayListFromDate.Add(fromDate);
            ArrayList arrayListToDate = new ArrayList();
            arrayListToDate.Add(toDate);
            ArrayList arrayListDepartmentID = new ArrayList();
            arrayListDepartmentID.Add(departmentID);

            SetCurrentValuesForParameterField(Report, arrayListFromDate, "@FromDate");
            SetCurrentValuesForParameterField(Report, arrayListToDate, "@ToDate");
            SetCurrentValuesForParameterField(Report, arrayListDepartmentID, "@DepartmentID");

            SetSubReportParametersDates(Report, "ReportByDepartmentChart1.rpt", fromDate, "@FromDate");
            SetSubReportParametersDates(Report, "ReportByDepartmentChart1.rpt", toDate, "@ToDate");
            SetSubReportParameters(Report, "ReportByDepartmentChart1.rpt", departmentID, "@DepartmentID");

            ExportOptions exportOpts = new ExportOptions();
            PdfRtfWordFormatOptions pdfopts = new PdfRtfWordFormatOptions();
            DiskFileDestinationOptions diskOpts = new DiskFileDestinationOptions();
            exportOpts = Report.ExportOptions;
            exportOpts.ExportFormatType = ExportFormatType.PortableDocFormat;
            exportOpts.FormatOptions = pdfopts;
            exportOpts.ExportDestinationType = ExportDestinationType.DiskFile;
            diskOpts.DiskFileName = Server.MapPath(ConfigurationManager.AppSettings["PDFPath"] + "\\" + reportName);
            exportOpts.DestinationOptions = diskOpts;
            Report.Export();
            reportName = ConfigurationManager.AppSettings["PDFPath"] + "/" + reportName;
            Response.Write("<script language=\"javascript\" type=\"text/javascript\">window.open(\"" + reportName + "\",null,\"height=800,width=900,status=yes,toolbar=no,scrollbars=yes,menubar=yes,location=no,left=30,top=10\")</script>");
        }

        protected void DropDownListDepBusinessUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListDepBusinessUnit.SelectedIndex != -1)
            {
                int businessUnitID = int.Parse(DropDownListDepBusinessUnit.SelectedValue.ToString());
                ComboEntityCollection comboEntityCollection = new ComboEntityCollection();
                ComboBusinessComponent comboBusinessComponent = new ComboBusinessComponent(Thread.CurrentPrincipal);
                comboEntityCollection = comboBusinessComponent.GetComboDataByForeignnKey(ReferenceTable.DivisionUnit, businessUnitID, true);
               

                UserBusinessComponent userBusinessComponent = new UserBusinessComponent(Thread.CurrentPrincipal);
                UserEntity userEntity = userBusinessComponent.GetByUserName(HttpContext.Current.User.Identity.Name);
                if (userEntity != null)
                {
                    if (userEntity.RoleID == (int)Role.DivisionHead || userEntity.RoleID == (int)Role.DepartmentManager)
                    {
                        DropDownListDepDivisionUnit.DataSource = null;
                        DropDownListDepDivisionUnit.DataBind();
                        for (int i = 0; i < comboEntityCollection.Count; i++)
                        {
                            if (userEntity.DivisionUnitID != null)
                            {
                                if ((int)userEntity.DivisionUnitID == comboEntityCollection[i].ComboID
                                    || comboEntityCollection[i].ComboID == 0)
                                {
                                    ListItem item = new ListItem(comboEntityCollection[i].ComboDesc, comboEntityCollection[i].ComboID.ToString());
                                    DropDownListDepDivisionUnit.Items.Add(item);
                                }
                            }
                        }
                        DropDownListDepDivisionUnit.DataBind();
                        comboEntityCollection = new ComboEntityCollection();
                        DropDownListDepDepartment.DataSource = comboEntityCollection;
                        DropDownListDepDepartment.DataBind();
                    }
                    else
                    {
                        DropDownListDepDivisionUnit.DataSource = comboEntityCollection;
                        DropDownListDepDivisionUnit.DataTextField = Combo.Description;
                        DropDownListDepDivisionUnit.DataValueField = Combo.ID;
                        DropDownListDepDivisionUnit.DataBind(); 
                        comboEntityCollection = new ComboEntityCollection();
                        DropDownListDepDepartment.DataSource = comboEntityCollection;
                        DropDownListDepDepartment.DataBind();
                    }
                }
            }
            else
            {
                ComboEntityCollection comboEntityCollection = new ComboEntityCollection();
                DropDownListDepDivisionUnit.DataSource = comboEntityCollection;
                DropDownListDepDivisionUnit.DataBind();
                comboEntityCollection = new ComboEntityCollection();
                DropDownListDepDepartment.DataSource = comboEntityCollection;
                DropDownListDepDepartment.DataBind();
            }          
        }

        protected void DropDownListDepDivisionUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListDepDivisionUnit.SelectedIndex != -1)
            {
                int divisionUnitID = int.Parse(DropDownListDepDivisionUnit.SelectedValue.ToString());
                ComboEntityCollection comboEntityCollection = new ComboEntityCollection();
                ComboBusinessComponent comboBusinessComponent = new ComboBusinessComponent(Thread.CurrentPrincipal);
                comboEntityCollection = comboBusinessComponent.GetComboDataByForeignnKey(ReferenceTable.Department, divisionUnitID, true);
              
                
                UserBusinessComponent userBusinessComponent = new UserBusinessComponent(Thread.CurrentPrincipal);
                UserEntity userEntity = userBusinessComponent.GetByUserName(HttpContext.Current.User.Identity.Name);
                if (userEntity != null)
                {
                    if (userEntity.RoleID == (int)Role.DepartmentManager)
                    {
                        DropDownListDepDepartment.DataSource = null;
                        DropDownListDepDepartment.DataBind();
                        for (int i = 0; i < comboEntityCollection.Count; i++)
                        {
                            if (userEntity.DepartmentID != null)
                            {
                                if ((int)userEntity.DepartmentID == comboEntityCollection[i].ComboID
                                    || comboEntityCollection[i].ComboID == 0)
                                {
                                    ListItem item = new ListItem(comboEntityCollection[i].ComboDesc, comboEntityCollection[i].ComboID.ToString());
                                    DropDownListDepDepartment.Items.Add(item);
                                }
                            }
                        }
                        DropDownListDepDepartment.DataBind();
                    }
                    else
                    {
                        DropDownListDepDepartment.DataSource = comboEntityCollection;
                        DropDownListDepDepartment.DataTextField = Combo.Description;
                        DropDownListDepDepartment.DataValueField = Combo.ID;
                        DropDownListDepDepartment.DataBind();
                    }
                }
            }
            else
            {
                ComboEntityCollection comboEntityCollection = new ComboEntityCollection();
                DropDownListDepDepartment.DataSource = comboEntityCollection;
                DropDownListDepDepartment.DataBind();
            }
        }
        #endregion

        #region All Business Units
        protected void LinkButtonGenerateAllBusinessUnit_Click(object sender, EventArgs e)
        {
            if (((DateTime)WebDateAllBusinessFromDate.Value).Date <= ((DateTime)WebDateAllBusinessToDate.Value).Date)
            {
                ConfigureCrystalReports_AllBusinessUnits();
            }
            else
            {
                LabelMessage.Text = "Please select valid dates.";
            }
        }

        private void ConfigureCrystalReports_AllBusinessUnits()
        {
            reportPath = HttpContext.Current.Server.MapPath("CrystalReports\\ReportAllBusinessUnits.rpt");
            DateTime fromDate = ((DateTime)WebDateAllBusinessFromDate.Value).Date;
            DateTime toDate = ((DateTime)WebDateAllBusinessToDate.Value).Date;         

            string reportName = "Report_Summary_for_AllBusinessUnits.pdf";
            Report = new ReportDocument();
            Report.Load(reportPath);

            int waste = Report.ParameterFields.Count;
            ConnectionInfo connectionInfo = new ConnectionInfo();

            connectionInfo.DatabaseName = ConfigurationManager.AppSettings["Database"];
            connectionInfo.UserID = ConfigurationManager.AppSettings["UserID"];
            connectionInfo.Password = ConfigurationManager.AppSettings["Password"];
            connectionInfo.ServerName = ConfigurationManager.AppSettings["Server"];
            connectionInfo.IntegratedSecurity = bool.Parse(ConfigurationManager.AppSettings["Security"]);
            connectionInfo.Type = ConnectionInfoType.CRQE;

            SetDBLogonForReport(connectionInfo, Report);
            SetDBLogonForSubReports(connectionInfo, Report);

            ArrayList arrayListFromDate = new ArrayList();
            arrayListFromDate.Add(fromDate);
            ArrayList arrayListToDate = new ArrayList();
            arrayListToDate.Add(toDate);           

            SetCurrentValuesForParameterField(Report, arrayListFromDate, "@FromDate");
            SetCurrentValuesForParameterField(Report, arrayListToDate, "@ToDate");

            SetSubReportParametersDates(Report, "ReportAllBusinessUnitsChart.rpt", fromDate, "@FromDate");
            SetSubReportParametersDates(Report, "ReportAllBusinessUnitsChart.rpt", toDate, "@ToDate");

            SetSubReportParametersDates(Report, "ReportAllBusinessUnitsChartAMPM.rpt", fromDate, "@FromDate");
            SetSubReportParametersDates(Report, "ReportAllBusinessUnitsChartAMPM.rpt", toDate, "@ToDate");
         

            ExportOptions exportOpts = new ExportOptions();
            PdfRtfWordFormatOptions pdfopts = new PdfRtfWordFormatOptions();
            DiskFileDestinationOptions diskOpts = new DiskFileDestinationOptions();
            exportOpts = Report.ExportOptions;
            exportOpts.ExportFormatType = ExportFormatType.PortableDocFormat;
            exportOpts.FormatOptions = pdfopts;
            exportOpts.ExportDestinationType = ExportDestinationType.DiskFile;
            diskOpts.DiskFileName = Server.MapPath(ConfigurationManager.AppSettings["PDFPath"] + "\\" + reportName);
            exportOpts.DestinationOptions = diskOpts;
            Report.Export();
            reportName =  ConfigurationManager.AppSettings["PDFPath"] + "/" + reportName;
            Response.Write("<script language=\"javascript\" type=\"text/javascript\">window.open(\"" + reportName + "\",null,\"height=800,width=900,status=yes,toolbar=no,scrollbars=yes,menubar=yes,location=no,left=30,top=10\")</script>");
        }

        #endregion 
    }
}