<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManagementReport.aspx.cs" Inherits="TimeSoftWebApp.ManagementReport" %>
<%@ Register Assembly="Infragistics2.WebUI.WebDateChooser.v10.2, Version=10.2.20102.1011, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.WebUI.WebSchedule" tagprefix="igsch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <style type="text/css">
        
        .style3
    {
        width: 25%;
    }
    .style8
    {
        width: 133px;
    }
    .style10
    {
        width: 25%;
        height: 26px;
            text-align: left;
        }
    .style13
    {
        height: 26px;
        text-align: right;
    }
    .style14
    {
        width: 15%;
        text-align: right;
    }
        
        .style15
        {
            font-size: xx-small;
        }
        
        .style16
        {
            height: 6px;
            text-align: left;
        }
        .style17
        {
            width: 23%;
            height: 6px;
        }
        .style21
        {
            color: maroon;
        }
        .style22
        {
            color: #990000;
        }
        
        .style25
        {
            height: 26px;
            text-align: left;
        }
        
        .style26
        {
            height: 26px;
            text-align: right;
            width: 15%;
        }
        .style27
        {
            width: 13%;
            height: 26px;
            text-align: right;
        }
        .style28
        {
            width: 13%;
            text-align: right;
        }
        .style29
        {
            width: 23%;
            height: 26px;
        }
        .style30
        {
            width: 23%;
            text-align: left;
        }
        
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Management Reports</h1>
<hr />

<asp:Label ID="LabelMessage" runat="server" ForeColor="Red"></asp:Label>
<br />
<div> 
<asp:Panel ID="PanelAllBusiness" runat="server">   
    <table style="width: 100%;">
        <tr>
            <td colspan="4" class="style16">
                </td>
            <td class="style17">
                </td>
        </tr>
        <tr>
            <td class="style25" colspan="2">
                &nbsp;&nbsp;&nbsp; 
                <asp:Label ID="Label4" runat="server" style="color: #990000; font-weight: 700" 
                    Text="Report All Business Units Summary"></asp:Label>
            </td>
            <td class="style27">
                &nbsp;</td>
            <td class="style10">
                &nbsp;</td>
            <td class="style29">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style14">
                &nbsp;
                From Date:&nbsp;&nbsp; </td>
            <td class="style8" style="width: 25%">
                <igsch:WebDateChooser ID="WebDateAllBusinessFromDate" runat="server" AllowNull="False" 
                    BackColor="#EAFFFF" CssClass="style15" Format="Long" Height="16px" 
                    Width="95%">
                </igsch:WebDateChooser>
            </td>
            <td class="style28">
                ToDate:&nbsp;&nbsp; </td>
            <td class="style3">
                <igsch:WebDateChooser ID="WebDateAllBusinessToDate" runat="server" AllowNull="False" 
                    BackColor="#EAFFFF" CssClass="style15" Format="Long" Height="16px" 
                    Width="95%">
                </igsch:WebDateChooser>
            </td>
            <td class="style30">
                <asp:LinkButton ID="LinkButtonGenerateAllBusinessUnit" runat="server" 
                    onclick="LinkButtonGenerateAllBusinessUnit_Click">Generate</asp:LinkButton>
            </td>
        </tr>
    </table>
     <hr />
    </asp:Panel>
   
</div>
<div> 

    <asp:Panel ID="PanelBusinessUnit" runat="server">
    <table style="width: 100%;">
        <tr>
            <td class="style25" colspan="2">
                &nbsp;&nbsp;&nbsp; 
                <asp:Label ID="Label1" runat="server" style="color: #990000; font-weight: 700" 
                    Text="Report by Business Unit"></asp:Label>
            </td>
            <td class="style27">
                &nbsp;</td>
            <td class="style10">
                &nbsp;</td>
            <td class="style29">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style13">
                &nbsp;
                Business Unit:&nbsp;&nbsp; </td>
            <td class="style10">
                <asp:DropDownList ID="DropDownListBusinessUnit" runat="server" Width="95%" 
                    BackColor="#EAFFFF">
                </asp:DropDownList>
            </td>
            <td class="style27">
                </td>
            <td class="style10">
                &nbsp;</td>
            <td class="style29">
                </td>
        </tr>
        <tr>
            <td class="style14">
                &nbsp;
                From Date:&nbsp;&nbsp; </td>
            <td class="style8" style="width: 25%">
                <igsch:WebDateChooser ID="WebDateBusUnitFrom" runat="server" AllowNull="False" 
                    BackColor="#EAFFFF" CssClass="style15" Format="Long" Height="16px" 
                    Width="95%">
                </igsch:WebDateChooser>
            </td>
            <td class="style28">
                ToDate:&nbsp;&nbsp; </td>
            <td class="style3">
                <igsch:WebDateChooser ID="WebDateBusinessUnitTo" runat="server" AllowNull="False" 
                    BackColor="#EAFFFF" CssClass="style15" Format="Long" Height="16px" 
                    Width="95%">
                </igsch:WebDateChooser>
            </td>
            <td class="style30">
                <asp:LinkButton ID="LinkButtonGenerateByBusinessUnit" runat="server" 
                    onclick="LinkButtonGenerateByBusinessUnit_Click">Generate</asp:LinkButton>
            </td>
        </tr>
    </table>
    <hr />
    </asp:Panel>
</div>

<div> 
  <asp:Panel ID="PanelDivision" runat="server">         
    <table style="width: 100%;">
        <tr>
           
            <td class="style25" colspan="2">
                &nbsp;&nbsp;&nbsp;&nbsp; <span class="style21"> 
                <asp:Label ID="Label2" runat="server" style="color: #990000; font-weight: 700" 
                    Text="Report by Division Unit"></asp:Label>
                </span> &nbsp;</td>
            <td class="style27">
                &nbsp;</td>
            <td class="style10">
                &nbsp;</td>
            <td class="style29">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style26">
                &nbsp;
                Business Unit:&nbsp;&nbsp; </td>
            <td class="style10">
                <asp:DropDownList ID="DropDownListDivBusinessUnit" runat="server" Width="95%" 
                    BackColor="#EAFFFF" AutoPostBack="True" 
                    onselectedindexchanged="DropDownListDivBusinessUnit_SelectedIndexChanged" 
                    style="margin-left: 3px">
                </asp:DropDownList>
            </td>
            <td class="style27">
                Division Unit:&nbsp;&nbsp; </td>
            <td class="style10">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
                <asp:DropDownList ID="DropDownDivDivisionUnit" runat="server" Width="95%" 
                    BackColor="#EAFFFF">
                </asp:DropDownList>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="DropDownListDivBusinessUnit" 
                        EventName="SelectedIndexChanged" />
                </Triggers>
                </asp:UpdatePanel>
            </td>
            <td class="style29">
                </td>
        </tr>
        <tr>
            <td class="style14">
                &nbsp;
                From Date:&nbsp;&nbsp; </td>
            <td class="style8" style="width: 25%">
                <igsch:WebDateChooser ID="WebDateDivFromDate" runat="server" AllowNull="False" 
                    BackColor="#EAFFFF" CssClass="style15" Format="Long" Height="16px" 
                    Width="95%">
                </igsch:WebDateChooser>
            </td>
            <td class="style28">
                ToDate:&nbsp;&nbsp; </td>
            <td class="style3">
                <igsch:WebDateChooser ID="WebDateDivToDate" runat="server" AllowNull="False" 
                    BackColor="#EAFFFF" CssClass="style15" Format="Long" Height="16px" 
                    Width="95%">
                </igsch:WebDateChooser>
            </td>
            <td class="style30">
                <asp:LinkButton ID="LinkButtonGenerateByDivision" runat="server" 
                    onclick="LinkButtonGenerateByDivision_Click">Generate</asp:LinkButton>
            </td>
        </tr>
    </table>
    <hr />
       </asp:Panel>
</div>

<div> 
        
<asp:Panel ID="PanelDepartment" runat="server">      
    <table style="width: 100%;">
        <tr>
            <td class="style25" colspan="2">
                &nbsp;&nbsp;&nbsp;&nbsp; <span class="style22"> 
                <asp:Label ID="Label3" runat="server" style="color: #990000; font-weight: 700" 
                    Text="Report by Department Unit"></asp:Label>
                </span> &nbsp;</td>
            <td class="style27">
                &nbsp;</td>
            <td class="style10">
                &nbsp;</td>
            <td class="style29">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style13">
                &nbsp;
                Business Unit:&nbsp;&nbsp; </td>
            <td class="style10">
                <asp:DropDownList ID="DropDownListDepBusinessUnit" runat="server" Width="95%" 
                    BackColor="#EAFFFF" 
                    onselectedindexchanged="DropDownListDepBusinessUnit_SelectedIndexChanged" 
                    AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td class="style27">
                Division Unit:&nbsp;&nbsp;
                </td>
            <td class="style10"><asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
                <asp:DropDownList ID="DropDownListDepDivisionUnit" runat="server" Width="95%" 
                    BackColor="#EAFFFF" 
                    onselectedindexchanged="DropDownListDepDivisionUnit_SelectedIndexChanged" 
                    AutoPostBack="True">
                </asp:DropDownList>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="DropDownListDepBusinessUnit" 
                        EventName="SelectedIndexChanged" />
                </Triggers>
                </asp:UpdatePanel>
            </td>
            <td class="style29">
                </td>
        </tr>
        <tr>
            <td class="style13">
                Department:&nbsp;&nbsp;  </td>
            <td class="style10">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
                <asp:DropDownList ID="DropDownListDepDepartment" runat="server" Width="95%" 
                    BackColor="#EAFFFF">
                </asp:DropDownList>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="DropDownListDepDivisionUnit" 
                        EventName="SelectedIndexChanged" />
                    <asp:AsyncPostBackTrigger ControlID="DropDownListDepBusinessUnit" 
                        EventName="SelectedIndexChanged" />
                </Triggers>
                </asp:UpdatePanel>
            </td>
            <td class="style27">
                &nbsp;</td>
            <td class="style10">
                &nbsp;</td>
            <td class="style29">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style14">
                &nbsp;
                From Date:&nbsp;&nbsp; </td>
            <td class="style8" style="width: 25%">
                <igsch:WebDateChooser ID="WebDateDepFromDate" runat="server" AllowNull="False" 
                    BackColor="#EAFFFF" CssClass="style15" Format="Long" Height="16px" 
                    Width="95%">
                </igsch:WebDateChooser>
            </td>
            <td class="style28">
                To Date:&nbsp;&nbsp; </td>
            <td class="style3">
                <igsch:WebDateChooser ID="WebDateDepToDate" runat="server" AllowNull="False" 
                    BackColor="#EAFFFF" CssClass="style15" Format="Long" Height="16px" 
                    Width="95%">
                </igsch:WebDateChooser>
            </td>
            <td class="style30">
                <asp:LinkButton ID="LinkButtonReportByDepartment" runat="server" 
                    onclick="LinkButtonReportByDepartment_Click">Generate</asp:LinkButton>
            </td>
        </tr>
    </table>
 </asp:Panel>
</div>

<hr />
<br />
</asp:Content>
