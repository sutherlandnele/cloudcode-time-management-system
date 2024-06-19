<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminReports.aspx.cs" Inherits="TimeSoftWebApp.AdminReports" %>
<%@ Register Assembly="Infragistics2.WebUI.WebDateChooser.v10.2, Version=10.2.20102.1011, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.WebUI.WebSchedule" tagprefix="igsch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 20%;
        }
      
        .style2
        {
            width: 10%;
            text-align: right;
        }
      
    .style3
    {
        width: 12%;
        text-align: left;
    }
      
        .style4
        {
            font-size: xx-small;
        }
        .style5
        {
            width: 10%;
            text-align: right;
            height: 16px;
        }
        .style6
        {
            width: 20%;
            height: 16px;
        }
      
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Admin Reports</h1>
 <br />
&nbsp;
<asp:Label ID="LabelMessage" runat="server" 
    style="font-weight: 700; color: #FF0000"></asp:Label>
 <br /><hr />
 <div>
     <table width="100%" style="margin-bottom: 1px" ><tr>
            <td class="style3">
     &nbsp;
     <asp:Label ID="Label7" runat="server" Text="Employee Report"></asp:Label>
            </td>
            <td class="style1">
                &nbsp;&nbsp;<asp:LinkButton ID="LinkButtonGenerateEmployeeReport" runat="server" 
                    onclick="LinkButtonGenerateEmployeeReport_Click">Generate</asp:LinkButton>
            </td>
            <td class="style2">
                 &nbsp;</td>
             <td class="style1">
                 &nbsp;</td>
             <td class="style1">
                 &nbsp;</td>
            
            
            </tr>  </table>
 </div>
 <br />
 <hr />
 <div>
     &nbsp;
     <asp:Label ID="Label1" runat="server" 
         Text="Time Log Report for All Employees (AM / PM/ DURING DAY)"></asp:Label>
     <br />
     <br />
     <table width="100%" style="margin-bottom: 1px" ><tr>
            <td class="style5">
                 <asp:Label ID="Label2" runat="server" Text="From Date"></asp:Label>
            </td>
            <td class="style6">
                <igsch:WebDateChooser ID="WebDateAllEmployeeFromDate" runat="server" 
                    style="margin-left: 0px" Value="2010-08-12" Width="95%" Height="16px" 
                    BackColor="#EAFFFF" CssClass="style4">
                    <CalendarLayout DropDownYearsNumber="40" AllowNull="False">
                    </CalendarLayout>
                </igsch:WebDateChooser>
            </td>
            <td class="style5">
                 <asp:Label ID="Label3" runat="server" Text="To Date"></asp:Label>
            </td>
             <td class="style6">
                 <igsch:WebDateChooser ID="WebDateAllEmployeeToDate" runat="server" Value="2010-08-12" 
                     Width="95%" Height="16px" BackColor="#EAFFFF" CssClass="style4">
                     <CalendarLayout DropDownYearsNumber="40" AllowNull="False">
                     </CalendarLayout>
                 </igsch:WebDateChooser>
            </td>
             <td class="style6">
                 <asp:LinkButton ID="LinkButtonReportAllEmployee" runat="server" 
                     onclick="LinkButtonReportAllEmployee_Click">Generate</asp:LinkButton>
            </td>
            
            
            </tr>  </table>
 </div>
 <br />
 <hr />
  <div>
     &nbsp;
     <asp:Label ID="Label8" runat="server" 
          Text="Time Log Report for All Employees (AM / PM)"></asp:Label>
     <br />
     <br />
     <table width="100%" style="margin-bottom: 1px" ><tr>
            <td class="style2">
                 <asp:Label ID="Label9" runat="server" Text="From Date"></asp:Label>
            </td>
            <td class="style1">
                <igsch:WebDateChooser ID="WebDateFromAllEmpAmPm" runat="server" 
                    style="margin-left: 0px" Value="2010-08-12" Width="95%" Height="16px" 
                    BackColor="#EAFFFF" CssClass="style4">
                    <CalendarLayout DropDownYearsNumber="40" AllowNull="False">
                    </CalendarLayout>
                </igsch:WebDateChooser>
            </td>
            <td class="style2">
                 <asp:Label ID="Label10" runat="server" Text="To Date"></asp:Label>
            </td>
             <td class="style1">
                 <igsch:WebDateChooser ID="WebDateToAllEmpAmPm" runat="server" Value="2010-08-12" 
                     Width="95%" Height="16px" BackColor="#EAFFFF" CssClass="style4">
                     <CalendarLayout DropDownYearsNumber="40" AllowNull="False">
                     </CalendarLayout>
                 </igsch:WebDateChooser>
            </td>
             <td class="style1">
                 <asp:LinkButton ID="LinkButtonAllEmpAmPm" runat="server" onclick="LinkButtonAllEmpAmPm_Click" 
                    >Generate</asp:LinkButton>
            </td>
            
            
            </tr>  </table>
 </div>
 <br />
 <hr />

  <div>
     &nbsp;
     <asp:Label ID="Label4" runat="server" 
          Text="Summary of Time Log Report for All Employees"></asp:Label>
     <br />
     <br />
     <table width="100%" style="margin-bottom: 1px" ><tr>
            <td class="style2">
                 <asp:Label ID="Label5" runat="server" Text="From Date"></asp:Label>
            </td>
            <td class="style1">
                <igsch:WebDateChooser ID="WebDateFromSummaryLog" runat="server" 
                    style="margin-left: 0px" Value="2010-08-12" Width="95%" Height="16px" 
                    BackColor="#EAFFFF" CssClass="style4">
                    <CalendarLayout DropDownYearsNumber="40" AllowNull="False">
                    </CalendarLayout>
                </igsch:WebDateChooser>
            </td>
            <td class="style2">
                 <asp:Label ID="Label6" runat="server" Text="To Date"></asp:Label>
            </td>
             <td class="style1">
                 <igsch:WebDateChooser ID="WebDateToSumaryLog" runat="server" Value="2010-08-12" 
                     Width="95%" Height="16px" BackColor="#EAFFFF" CssClass="style4">
                     <CalendarLayout DropDownYearsNumber="40" AllowNull="False">
                     </CalendarLayout>
                 </igsch:WebDateChooser>
            </td>
             <td class="style1">
                 <asp:LinkButton ID="LinkButtonGenerateSummaryLog" runat="server" 
                     onclick="LinkButtonGenerateSummaryLog_Click" >Generate</asp:LinkButton>
            </td>
            
            
            </tr>  </table>
 </div>
  <hr />
 <br />
 <br />

</asp:Content>
