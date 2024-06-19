<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeReport.aspx.cs" Inherits="TimeSoftWebApp.EmployeeReport" %>
<%@ Register Assembly="Infragistics2.WebUI.WebDateChooser.v10.2, Version=10.2.20102.1011, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.WebUI.WebSchedule" tagprefix="igsch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .style3
    {
        text-align: right;
    }
    .style4
    {
        width: 25%;
    }
    .style6
    {
            text-align: right;
            width: 19%;
        }
    .style7
    {
        text-align: left;
        height: 21px;
    }
        .style11
        {
            width: 6%;
        }
        .style12
        {
            text-align: right;
            width: 19%;
            height: 30px;
        }
        .style13
        {
            width: 25%;
            height: 30px;
        }
        .style14
        {
            width: 6%;
            height: 30px;
        }
        .style15
        {
            width: 25%;
            font-weight: bold;
        }
        .style16
        {
            text-align: right;
            width: 19%;
            font-weight: bold;
            color: #990000;
        }
        .style17
        {
            font-size: xx-small;
        }
        .style18
        {
            text-align: right;
            width: 19%;
            height: 24px;
        }
        .style19
        {
            width: 25%;
            height: 24px;
        }
        .style20
        {
            width: 6%;
            height: 24px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Employee Report
    </h1>
    <hr />
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
     <table width="100%" style="margin-bottom: 1px" ><tr>
            <td class="style16">
                Search Criteria:</td>
            <td class="style15">
                &nbsp;</td>
            <td class="style11">
                &nbsp;</td>
            <td class="style4">
                 &nbsp;</td>
             <td class="style4">
                 &nbsp;</td>
            
            
            </tr>  <tr>
            <td class="style18">
                From Date:&nbsp;&nbsp;
            </td>
            <td class="style19">
                <igsch:WebDateChooser ID="WebDateFrom" runat="server" 
                    style="margin-left: 0px" Value="2010-08-12" Width="95%" Height="16px" 
                    BackColor="#EAFFFF" CssClass="style17">
                    <CalendarLayout DropDownYearsNumber="40" AllowNull="False">
                    </CalendarLayout>
                </igsch:WebDateChooser>
            </td>
            <td class="style20">
                 To Date:</td>
            <td class="style19">
                 <igsch:WebDateChooser ID="WebDateTo" runat="server" 
                    style="margin-left: 0px" Value="2010-08-12" Width="95%" Height="16px" 
                     BackColor="#EAFFFF" CssClass="style17">
                    <CalendarLayout DropDownYearsNumber="40" AllowNull="False">
                    </CalendarLayout>
                </igsch:WebDateChooser>
            </td>
             <td class="style19">
                 </td>
            
            
            </tr>  <tr>
            <td class="style12">
     &nbsp;
     <asp:Label ID="Label7" runat="server" Text="Employee Search"></asp:Label>
                :&nbsp;&nbsp;
            </td>
            <td class="style13">
                <asp:DropDownList ID="DropDownListSearchCriteria" runat="server" Width="95%" 
                    BackColor="#EAFFFF">
                </asp:DropDownList>
            </td>
            <td class="style14">
            </td>
            <td class="style13">
                 <asp:TextBox ID="TextBoxSearchField" runat="server" Width="93%" 
                     BackColor="#EAFFFF"></asp:TextBox>
&nbsp;</td>
             <td class="style13">
                 <asp:Button ID="ButtonSearch" runat="server" onclick="ButtonSearch_Click" Text="Search" />
             </td>
            
            
            </tr>  <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td class="style11">
                &nbsp;</td>
            <td class="style4">
                 &nbsp;</td>
             <td class="style4">
                 &nbsp;</td>
            
            
            </tr>  <tr>
            <td class="style7" colspan="5">
    <hr />
            </td>
            
            
            </tr>  <tr>
            <td class="style7" colspan="5">
                                    <asp:Label ID="LabelMessageEmployee" runat="server" Font-Bold="True" 
                                        ForeColor="Red"></asp:Label>
            </td>
            
            
            </tr>  <tr>
            <td class="style3" colspan="5" style="width: 15%">
                <asp:GridView ID="GridViewEmployee" runat="server" AutoGenerateColumns="False" 
                    HorizontalAlign="Left" Width="100%" 
                    onrowcommand="GridViewEmployee_RowCommand" DataKeyNames="EmployeeID" 
                    CellPadding="2">
                    <Columns>
                        <asp:BoundField DataField="CardNo" HeaderText="Card No" SortExpression="CardNo">
                        <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="EmployeeNo" HeaderText="Employee No" 
                            SortExpression="EmployeeNo">
                        <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FName" HeaderText="First Name" 
                            SortExpression="FName">
                        <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="LName" HeaderText="Last Name" SortExpression="LName">
                        <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BusinessUnitDesc" HeaderText="Business Unit" 
                            SortExpression="BusinessUnitDesc">
                        <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DivisionUnitDesc" HeaderText="Division Unit" 
                            SortExpression="DivisionUnitDesc">
                        <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DepartmentDesc" HeaderText="Department" 
                            SortExpression="DepartmentDesc">
                        <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="StaffLocationDesc" HeaderText="Location" 
                            SortExpression="StaffLocationDesc">
                        <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButtonGenerate" runat="server"  CommandName="Generate" 
                             CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" >Generate Report</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle BackColor="#006699" Height="25px" ForeColor="#66FF33" />
                    <RowStyle HorizontalAlign="Left" />
                </asp:GridView>
            </td>
            
            
            </tr>  </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ButtonSearch" EventName="Click" />
        </Triggers>
            </asp:UpdatePanel>
    <br />
    <div>
    
    </div>
</asp:Content>
