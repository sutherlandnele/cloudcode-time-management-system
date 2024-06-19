﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReferenceTables.aspx.cs" Inherits="TimeSoftWebApp.ReferenceTables" Theme="OnlineSkin"%>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebTab.v10.2, Version=10.2.20102.1011, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.WebUI.UltraWebTab" TagPrefix="igtab" %>
<%@ Register Assembly="Infragistics2.WebUI.WebDataInput.v10.2, Version=10.2.20102.1011, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.WebUI.WebDataInput" tagprefix="igtxt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style3
        {
            width: 807px;
        }
        .style4
        {
            width: 10px;
        }
        .style5
        {
            width: 2%;
        }
        .style9
        {
            width: 2%;
            height: 14px;
        }
        .style10
        {
            width: 96%;
            height: 14px;
        }
        .style12
        {
            width: 104px;
        }
        .style13
        {
            height: 25px;
        }
        .style14
        {
            height: 25px;
            width: 117px;
        }
        .style15
        {
            height: 24px;
            width: 70%;
        }
        .style16
        {
            width: 633px;
        }
        .style17
        {
            width: 117px;
        }
        .style18
        {
            height: 18px;
        }
        .style19
        {
            height: 18px;
            width: 15%;
        }
        .style20
        {
            height: 24px;
        }
        .style21
        {
            height: 24px;
            width: 15%;
        }
        .style22
        {
            height: 23px;
        }
        .style23
        {
            height: 23px;
            width: 70%;
        }
        .style24
        {
            height: 23px;
            width: 15%;
        }
        .style25
        {
            height: 24px;
            width: 27%;
        }
        .style26
        {
            width: 27%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Reference Tables</h1>
<hr />
<br />

<asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
    <igtab:UltraWebTab ID="UltraWebTabRefTables" runat="server" 
    BackColor="#D0CDC0" BorderStyle="Solid" Width="99%" 
        BorderColor="#000066" BorderWidth="1px" AutoPostBack="True" 
        ontabclick="UltraWebTabRefTables_TabClick" Height="100%" SelectedTab="2">
        <DefaultTabStyle BackColor="#6699FF" Font-Names="Microsoft Sans Serif" 
            Font-Size="9pt" ForeColor="White" BorderColor="#000066" 
            BorderStyle="Solid" BorderWidth="1px">
            <Padding Bottom="3px" Right="15px" Top="5px" />
            <BorderDetails ColorBottom="131, 133, 116" ColorLeft="131, 133, 116" 
                StyleBottom="Solid" StyleLeft="Solid" WidthBottom="1px" WidthLeft="1px" />
            <padding bottom="3px" right="15px" top="5px" />
            <borderdetails colorbottom="131, 133, 116" colorleft="131, 133, 116" 
                stylebottom="Solid" styleleft="Solid" widthbottom="1px" widthleft="1px" />
        </DefaultTabStyle>
        <HoverTabStyle BackColor="#BAB9AE" ForeColor="Black">
        </HoverTabStyle>
        <SelectedTabStyle BackColor="#EFEFEB" ForeColor="Black" BorderColor="#000066" 
            BorderStyle="Solid" BorderWidth="1px">
            <BorderDetails ColorBottom="159, 160, 144" ColorLeft="159, 160, 144" 
                StyleBottom="Solid" StyleLeft="Solid" />
            <borderdetails colorbottom="159, 160, 144" colorleft="159, 160, 144" 
                stylebottom="Solid" styleleft="Solid" />
        </SelectedTabStyle>
        <DefaultTabSeparatorStyle BackColor="#D0CDC0" 
            CustomRules="background-color:#D0CDC0" ForeColor="#D0CDC0" Height="3px">
            <BorderDetails ColorLeft="208, 205, 192" StyleBottom="None" StyleLeft="Solid" 
                StyleRight="None" StyleTop="None" />
            <borderdetails colorleft="208, 205, 192" stylebottom="None" styleleft="Solid" 
                styleright="None" styletop="None" />
        </DefaultTabSeparatorStyle>
        <Tabs>
            <igtab:Tab Key="BusinessUnit" Text="Business Unit">
            
                <ContentTemplate>
               
                    <div style="width: 100%; vertical-align:top">
                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
               <ContentTemplate>
                        <table style="width: 100%; vertical-align:top;" >
                            <tr>
                                <td class="style9">
                                    </td>
                                <td class="style10">
                                    <table style="width:100%;">
                                        <tr>
                                            <td class="style13" colspan="3">
                                                INSERT BUSINESS UNIT</td>
                                        </tr>
                                        <tr>
                                            <td class="style13">
                                                <asp:Label ID="Label5" runat="server" Text="Business Unit"></asp:Label>
                                            </td>
                                            <td class="style15" style="width: 70%">
                                                <asp:TextBox ID="TextBoxBusinessUnitDesc" runat="server" 
                                                    ValidationGroup="InsertBusinessUnit" Width="200px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorBusinessUnitDesc" 
                                                    runat="server" ControlToValidate="TextBoxBusinessUnitDesc" 
                                                    ErrorMessage="Required" style="color: #FF0000" 
                                                    ValidationGroup="InsertBusinessUnit"></asp:RequiredFieldValidator>
                                            </td>
                                            <td class="style14" style="width: 15%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style12" style="width: 15%">
                                                &nbsp;</td>
                                            <td class="style16" style="width: 70%">
                                                <asp:LinkButton ID="LinkButtonInsertBusinessUnit0" runat="server" 
                                                    onclick="LinkButtonInsertBusinessUnit_Click" 
                                                    ValidationGroup="InsertBusinessUnit">Insert</asp:LinkButton>
                                            </td>
                                            <td class="style17" style="width: 15%">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                                <td class="style9">
                                    </td>
                            </tr>
                            <tr>
                                <td class="style5">
                                    &nbsp;</td>
                                <td class="style3" style="width: 96%">
                                    <asp:Label ID="LabelMessageBusinessUnit" runat="server" Font-Bold="True" 
                                        ForeColor="Red"></asp:Label>
                                </td>
                                <td class="style4" style="width: 2%">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style5">
                                    &nbsp;</td>
                                <td class="style3" style="width: 96%">
                                    <asp:GridView ID="GridViewBusinessUnit" runat="server" 
                                        AutoGenerateColumns="False" DataKeyNames="BusinessUnitID" 
                                        HorizontalAlign="Left" 
                                        onrowcancelingedit="GridViewBusinessUnit_RowCancelingEdit" 
                                        onrowdeleting="GridViewBusinessUnit_RowDeleting" 
                                        onrowediting="GridViewBusinessUnit_RowEditing" 
                                        onrowupdating="GridViewBusinessUnit_RowUpdating" ShowFooter="True" 
                                        ShowHeaderWhenEmpty="True" Width="100%">
                                        
                                        <Columns>
                                        
                                            <asp:BoundField DataField="BusinessUnitID" HeaderText="ID" ReadOnly="True" 
                                                SortExpression="BusinessUnitID">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Business Unit" SortExpression="BusinessUnitDesc">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBoxBusBusinessUnitDescEdit" runat="server" 
                                                        Text='<%# Bind("BusinessUnitDesc") %>' Width="200px"></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("BusinessUnitDesc") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Active" SortExpression="Active">
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="CheckBoxBusActiveEdit" runat="server" 
                                                        Checked='<%# Bind("Active") %>' />
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Active") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:CommandField ShowEditButton="True" >
                                            <ItemStyle ForeColor="Blue" />
                                            </asp:CommandField>
                                            <asp:CommandField ShowDeleteButton="True" >
                                            <ItemStyle ForeColor="Blue" />
                                            </asp:CommandField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            No Details Found
                                        </EmptyDataTemplate>
                                        <HeaderStyle BackColor="#006699" ForeColor="#66FF33" />
                                    </asp:GridView>
                                </td>
                                <td class="style4" style="width: 2%">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style5">
                                    &nbsp;</td>
                                <td class="style3" style="width: 96%">
                                    <br />
                                    <br />
                                    <br />
                                </td>
                                <td class="style4" style="width: 2%">
                                    &nbsp;</td>
                            </tr>
                        </table>
                        </ContentTemplate>
                         <Triggers>
                             <asp:AsyncPostBackTrigger ControlID="GridViewBusinessUnit" 
                                 EventName="DataBound" />
                             <asp:AsyncPostBackTrigger ControlID="GridViewBusinessUnit" 
                                 EventName="RowCancelingEdit" />
                             <asp:AsyncPostBackTrigger ControlID="GridViewBusinessUnit" 
                                 EventName="RowDeleting" />
                             <asp:AsyncPostBackTrigger ControlID="GridViewBusinessUnit" 
                                 EventName="RowEditing" />
                             <asp:AsyncPostBackTrigger ControlID="GridViewBusinessUnit" 
                                 EventName="RowUpdating" />
                             <asp:AsyncPostBackTrigger ControlID="LinkButtonInsertBusinessUnit0" 
                                 EventName="Click" />
                         </Triggers>
                    </asp:UpdatePanel>
                    </div>
                  
                </ContentTemplate>
                <Style Height="30px">
                </Style>
            </igtab:Tab>
            <igtab:Tab Key="DivisionUnit" Text="Division Unit">


                <ContentTemplate>

                    <div style="width: 100%; vertical-align:top">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
               <ContentTemplate>
                        <table style="width: 100%; vertical-align:top;" >
                            <tr>
                                <td class="style9">
                                    </td>
                                <td class="style10">
                                    <table style="width:100%;">
                                        <tr>
                                            <td class="style18" colspan="2">
                                            </td>
                                            <td class="style19">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style13" colspan="2">
                                                INSERT DIVISION UNIT</td>
                                            <td class="style14" style="width: 15%">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="style20">
                                                <asp:Label ID="Label6" runat="server" Text="Business Unit"></asp:Label>
                                            </td>
                                            <td class="style15">
                                                <asp:DropDownList ID="DropDownListBusinessUnit" runat="server" 
                                                    ValidationGroup="InsertDivisionUnit" Width="204px">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorBusinessUnit" 
                                                    runat="server" ControlToValidate="DropDownListBusinessUnit" 
                                                    ErrorMessage="Required" style="color: #FF0000" 
                                                    ValidationGroup="InsertDivisionUnit"></asp:RequiredFieldValidator>
                                            </td>
                                            <td class="style21">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="style20">
                                                <asp:Label ID="Label4" runat="server" Text="Division Unit"></asp:Label>
                                            </td>
                                            <td class="style15">
                                                <asp:TextBox ID="TextBoxDivisionDesc" runat="server" 
                                                    ValidationGroup="InsertDivisionUnit" Width="200px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorDivisionDesc" 
                                                    runat="server" ControlToValidate="TextBoxDivisionDesc" ErrorMessage="Required" 
                                                    style="color: #FF0000" ValidationGroup="InsertDivisionUnit"></asp:RequiredFieldValidator>
                                            </td>
                                            <td class="style21">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style12" style="width: 15%">
                                                &nbsp;</td>
                                            <td class="style16" style="width: 70%">
                                                <asp:LinkButton ID="InsertDivision" runat="server" 
                                                    onclick="InsertDivision_Click" ValidationGroup="InsertDivisionUnit" 
                                                   >Insert</asp:LinkButton>
                                            </td>
                                            <td class="style17" style="width: 15%">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                                <td class="style9">
                                    </td>
                            </tr>
                            <tr>
                                <td class="style5">
                                    &nbsp;</td>
                                <td class="style3" style="width: 96%">
                                    <asp:Label ID="LabelMessageDivisionUnit" runat="server" Font-Bold="True" 
                                        ForeColor="Red"></asp:Label>
                                </td>
                                <td class="style4" style="width: 2%">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style5">
                                    &nbsp;</td>
                                <td class="style3" style="width: 96%">
                                    <asp:GridView ID="GridViewDivisionUnit" runat="server" 
                                        AutoGenerateColumns="False" DataKeyNames="DivisionUnitID" 
                                        HorizontalAlign="Left" 
                                        onrowcancelingedit="GridViewDivisionUnit_RowCancelingEdit"                                        
                                        onrowdeleting="GridViewDivisionUnit_RowDeleting" 
                                        onrowediting="GridViewDivisionUnit_RowEditing" 
                                        onrowupdating="GridViewDivisionUnit_RowUpdating" ShowFooter="True" 
                                        ShowHeaderWhenEmpty="True" Width="100%">
                                        <Columns>
                                            <asp:BoundField DataField="DivisionUnitID" HeaderText="ID" ReadOnly="True" 
                                                SortExpression="DivisionUnitID">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Business Unit">
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="DropDownListDivBusinessUnitEdit" runat="server" 
                                                        DataSourceID="SqlDataSourceBusinessUnit" DataTextField="BusinessUnitDesc" 
                                                        DataValueField="BusinessUnitID" SelectedValue='<%# Bind("BusinessUnitID") %>' 
                                                        Width="200px">
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("BusinessUnitDesc") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Division Unit" SortExpression="DivisionUnitDesc">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBoxDivisionUnitDescEdit" runat="server" 
                                                        Text='<%# Bind("DivisionUnitDesc") %>' Width="200px"></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("DivisionUnitDesc") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Active" SortExpression="Active">
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="CheckBoxDivActiveEdit" runat="server" 
                                                        Checked='<%# Bind("Active") %>' />
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Active") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:CommandField ShowEditButton="True" >
                                            <ItemStyle ForeColor="Blue" />
                                            </asp:CommandField>
                                            <asp:CommandField ShowDeleteButton="True" >
                                            <ItemStyle ForeColor="Blue" />
                                            </asp:CommandField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            No Details Found
                                        </EmptyDataTemplate>
                                        <HeaderStyle BackColor="#006699" ForeColor="#66FF33" />
                                    </asp:GridView>
                                </td>
                                <td class="style4" style="width: 2%">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style5">
                                    &nbsp;</td>
                                <td class="style3" style="width: 96%">
                                    <br />
                                    <br />
                                    <br />
                                </td>
                                <td class="style4" style="width: 2%">
                                    &nbsp;</td>
                            </tr>
                        </table>
                        </ContentTemplate> 
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="GridViewDivisionUnit" 
                                EventName="DataBound" />
                            <asp:AsyncPostBackTrigger ControlID="GridViewDivisionUnit" 
                                EventName="RowCancelingEdit" />
                            <asp:AsyncPostBackTrigger ControlID="GridViewDivisionUnit" 
                                EventName="RowDeleted" />
                            <asp:AsyncPostBackTrigger ControlID="GridViewDivisionUnit" 
                                EventName="RowEditing" />
                            <asp:AsyncPostBackTrigger ControlID="GridViewDivisionUnit" 
                                EventName="RowUpdating" />
                            <asp:AsyncPostBackTrigger ControlID="InsertDivision" EventName="Click" />
                        </Triggers>
                        </asp:UpdatePanel>
                    </div>
                   
                </ContentTemplate>


            </igtab:Tab>
            <igtab:Tab Key="Department" Text="Department">
                <ContentTemplate>
                      <div style="width: 100%; vertical-align:top">
                      <asp:UpdatePanel ID="UpdatePanel4" runat="server">
               <ContentTemplate>
                        <table style="width: 100%; vertical-align:top;" >
                            <tr>
                                <td class="style9">
                                    </td>
                                <td class="style10">
                                    <table style="width:100%;">
                                        <tr>
                                            <td class="style18" colspan="2">
                                            </td>
                                            <td class="style19">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style13" colspan="2">
                                                INSERT DEPARTMENT</td>
                                            <td class="style14" style="width: 15%">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="style20">
                                                <asp:Label ID="Label3" runat="server" Text="Business Unit"></asp:Label>
                                            </td>
                                            <td class="style15">
                                                <asp:DropDownList ID="DropDownListDepartmentBusinessUnit" runat="server" 
                                                    ValidationGroup="InsertDepartment" Width="204px" AutoPostBack="True" 
                                                    onselectedindexchanged="DropDownListDepartmentBusinessUnit_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorDepBusinessUnit" 
                                                    runat="server" ControlToValidate="DropDownListDepartmentBusinessUnit" 
                                                    ErrorMessage="Required" style="color: #FF0000" 
                                                    ValidationGroup="InsertDepartment"></asp:RequiredFieldValidator>
                                            </td>
                                            <td class="style21">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="style22">
                                                <asp:Label ID="Label10" runat="server" Text="Division Unit"></asp:Label>
                                            </td>
                                            <td class="style23">
                                                <asp:DropDownList ID="DropDownListDepartmentDivisionUnit" runat="server" 
                                                    ValidationGroup="InsertDepartment" Width="204px">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorDepDivisionUnit" runat="server" 
                                                    ControlToValidate="DropDownListDepartmentDivisionUnit" ErrorMessage="Required" 
                                                    style="color: #FF0000" ValidationGroup="InsertDepartment"></asp:RequiredFieldValidator>
                                            </td>
                                            <td class="style24">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style20">
                                                <asp:Label ID="Label8" runat="server" Text="Department"></asp:Label>
                                            </td>
                                            <td class="style15">
                                                <asp:TextBox ID="TextBoxDepartmentDesc" runat="server" 
                                                    ValidationGroup="InsertDepartment" Width="200px" Height="22px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorDepartmentDesc" 
                                                    runat="server" ControlToValidate="TextBoxDepartmentDesc" ErrorMessage="Required" 
                                                    style="color: #FF0000" ValidationGroup="InsertDepartment"></asp:RequiredFieldValidator>
                                            </td>
                                            <td class="style21">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style12" style="width: 15%">
                                                &nbsp;</td>
                                            <td class="style16" style="width: 70%">
                                                <asp:LinkButton ID="LinkButtonInsertDepartment" runat="server" 
                                                    onclick="InsertDepartment_Click" ValidationGroup="InsertDepartmentUnit" 
                                                   >Insert</asp:LinkButton>
                                            </td>
                                            <td class="style17" style="width: 15%">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                                <td class="style9">
                                    </td>
                            </tr>
                            <tr>
                                <td class="style5">
                                    &nbsp;</td>
                                <td class="style3" style="width: 96%">
                                    <asp:Label ID="LabelMessageDepartment" runat="server" Font-Bold="True" 
                                        ForeColor="Red"></asp:Label>
                                </td>
                                <td class="style4" style="width: 2%">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style5">
                                    &nbsp;</td>
                                <td class="style3" style="width: 96%">
                                    <asp:GridView ID="GridViewDepartment" runat="server" 
                                        AutoGenerateColumns="False" DataKeyNames="DepartmentID" 
                                        HorizontalAlign="Left" 
                                        onrowcancelingedit="GridViewDepartment_RowCancelingEdit" 
                                        onrowdeleting="GridViewDepartment_RowDeleting" 
                                        onrowediting="GridViewDepartment_RowEditing" 
                                        onrowupdating="GridViewDepartment_RowUpdating" ShowFooter="True" 
                                        ShowHeaderWhenEmpty="True" Width="100%" Height="100%" 
                                        ondatabound="GridViewDepartment_DataBound">
                                        <Columns>
                                            <asp:BoundField DataField="DepartmentID" HeaderText="ID" ReadOnly="True" 
                                                SortExpression="DepartmentID">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Business Unit">
                                                <EditItemTemplate>
                                                    <asp:DropDownList  ID="DropDownListDepBusinessUnitEdit" runat="server"
                                                        DataSourceID="SqlDataSourceBusinessUnit" DataTextField="BusinessUnitDesc" 
                                                        DataValueField="BusinessUnitID" SelectedValue='<%# Bind("BusinessUnitID") %>' 
                                                        Width="200px" AutoPostBack="True"
                                                        onselectedindexchanged="DropDownListDepBusinessUnitEdit_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("BusinessUnitDesc") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Division Unit">
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="DropDownListDepDivisionUnitEdit" runat="server" 
                                                        Width="200px" AutoPostBack="True" >
                                                    </asp:DropDownList>
                                                    <asp:HiddenField ID="HiddenFieldDivisionUnitID" runat="server" 
                                                        Value='<%# Bind("DivisionUnitID") %>' />
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label11" runat="server" Text='<%# Bind("DivisionUnitDesc") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="DepartmentUnit" SortExpression="DepartmentDesc">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBoxDepartmentUnitEdit" runat="server" 
                                                        Text='<%# Bind("DepartmentDesc") %>' Width="200px"></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("DepartmentDesc") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Active" SortExpression="Active">
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="CheckBoxDepActiveEdit" runat="server" 
                                                        Checked='<%# Bind("Active") %>' />
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Active") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:CommandField ShowEditButton="True" >
                                            <ItemStyle ForeColor="Blue" />
                                            </asp:CommandField>
                                            <asp:CommandField ShowDeleteButton="True" >
                                            <ItemStyle ForeColor="Blue" />
                                            </asp:CommandField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            No Details Found
                                        </EmptyDataTemplate>
                                        <HeaderStyle BackColor="#006699" ForeColor="#66FF33" />
                                    </asp:GridView>
                                </td>
                                <td class="style4" style="width: 2%">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style5">
                                    &nbsp;</td>
                                <td class="style3" style="width: 96%">
                                    <br />
                                    <br />
                                    <br />
                                </td>
                                <td class="style4" style="width: 2%">
                                    &nbsp;</td>
                            </tr>
                        </table>
                        </ContentTemplate>
                          <Triggers>
                              <asp:AsyncPostBackTrigger ControlID="DropDownListDepartmentBusinessUnit" 
                                  EventName="SelectedIndexChanged" />
                              <asp:AsyncPostBackTrigger ControlID="GridViewDepartment" 
                                  EventName="DataBound" />
                              <asp:AsyncPostBackTrigger ControlID="GridViewDepartment" 
                                  EventName="RowCancelingEdit" />
                              <asp:AsyncPostBackTrigger ControlID="GridViewDepartment" 
                                  EventName="RowDeleting" />
                              <asp:AsyncPostBackTrigger ControlID="GridViewDepartment" 
                                  EventName="RowEditing" />
                              <asp:AsyncPostBackTrigger ControlID="GridViewDepartment" 
                                  EventName="RowUpdating" />
                              <asp:AsyncPostBackTrigger ControlID="LinkButtonInsertDepartment" 
                                  EventName="Click" />
                          </Triggers>
                          </asp:UpdatePanel>
                    </div>               

                </ContentTemplate>
            </igtab:Tab>
            <igtab:Tab Key="StaffLocation" Text="Staff Location">
                <ContentTemplate>
                      <div style="width: 100%; vertical-align:top">
                       <asp:UpdatePanel ID="UpdatePanel5" runat="server">
               <ContentTemplate>
                        <table style="width: 100%; vertical-align:top;" >
                            <tr>
                                <td class="style9">
                                    </td>
                                <td class="style10">
                                    <table style="width:100%;">
                                        <tr>
                                            <td class="style13" colspan="3">
                                                INSERT STAFF LOCATION</td>
                                        </tr>
                                        <tr>
                                            <td class="style13">
                                                <asp:Label ID="Label9" runat="server" Text="Location"></asp:Label>
                                            </td>
                                            <td class="style15" style="width: 70%">
                                                <asp:TextBox ID="TextBoxLocation" runat="server" 
                                                    ValidationGroup="InsertStaffLocation" Width="200px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorLocation" 
                                                    runat="server" ControlToValidate="TextBoxLocation" 
                                                    ErrorMessage="Required" style="color: #FF0000" 
                                                    ValidationGroup="InsertStaffLocation"></asp:RequiredFieldValidator>
                                            </td>
                                            <td class="style14" style="width: 15%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style12" style="width: 15%">
                                                &nbsp;</td>
                                            <td class="style16" style="width: 70%">
                                                <asp:LinkButton ID="LinkButtonInsertStaffLocation" runat="server"                                                    
                                                    ValidationGroup="InsertStaffLocation" 
                                                    onclick="LinkButtonInsertStaffLocation_Click">Insert</asp:LinkButton>
                                            </td>
                                            <td class="style17" style="width: 15%">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                                <td class="style9">
                                    </td>
                            </tr>
                            <tr>
                                <td class="style5">
                                    &nbsp;</td>
                                <td class="style3" style="width: 96%">
                                    <asp:Label ID="LabelMessageStaffLocation" runat="server" Font-Bold="True" 
                                        ForeColor="Red"></asp:Label>
                                </td>
                                <td class="style4" style="width: 2%">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style5">
                                    &nbsp;</td>
                                <td class="style3" style="width: 96%">
                                    <asp:GridView ID="GridViewStaffLocation" runat="server" 
                                        AutoGenerateColumns="False" DataKeyNames="StaffLocationID" 
                                        HorizontalAlign="Left" 
                                        onrowcancelingedit="GridViewStaffLocation_RowCancelingEdit" 
                                        onrowdeleting="GridViewStaffLocation_RowDeleting" 
                                        onrowediting="GridViewStaffLocation_RowEditing" 
                                        onrowupdating="GridViewStaffLocation_RowUpdating" ShowFooter="True" 
                                        ShowHeaderWhenEmpty="True" Width="100%">
                                        <Columns>
                                            <asp:BoundField DataField="StaffLocationID" HeaderText="ID" ReadOnly="True" 
                                                SortExpression="StaffLocationID">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Location" SortExpression="StaffLocationDesc">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBoxStaffLocationDescEdit" runat="server" 
                                                        Text='<%# Bind("StaffLocationDesc") %>' Width="200px"></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("StaffLocationDesc") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Active" SortExpression="Active">
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="CheckBoxStafflocActiveEdit" runat="server" 
                                                        Checked='<%# Bind("Active") %>' />
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Active") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:CommandField ShowEditButton="True" >
                                            <ItemStyle ForeColor="Blue" />
                                            </asp:CommandField>
                                            <asp:CommandField ShowDeleteButton="True" >
                                            <ItemStyle ForeColor="Blue" />
                                            </asp:CommandField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            No Details Found
                                        </EmptyDataTemplate>
                                        <HeaderStyle BackColor="#006699" ForeColor="#66FF33" />
                                    </asp:GridView>
                                </td>
                                <td class="style4" style="width: 2%">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style5">
                                    &nbsp;</td>
                                <td class="style3" style="width: 96%">
                                    <br />
                                    <br />
                                    <br />
                                </td>
                                <td class="style4" style="width: 2%">
                                    &nbsp;</td>
                            </tr>
                        </table>
                        </ContentTemplate>
                           <Triggers>
                               <asp:AsyncPostBackTrigger ControlID="GridViewStaffLocation" 
                                   EventName="DataBound" />
                               <asp:AsyncPostBackTrigger ControlID="GridViewStaffLocation" 
                                   EventName="RowCancelingEdit" />
                               <asp:AsyncPostBackTrigger ControlID="GridViewStaffLocation" 
                                   EventName="RowDeleting" />
                               <asp:AsyncPostBackTrigger ControlID="GridViewStaffLocation" 
                                   EventName="RowEditing" />
                               <asp:AsyncPostBackTrigger ControlID="GridViewStaffLocation" 
                                   EventName="RowUpdating" />
                               <asp:AsyncPostBackTrigger ControlID="LinkButtonInsertStaffLocation" 
                                   EventName="Click" />
                           </Triggers>
                          </asp:UpdatePanel>
                    </div>
                </ContentTemplate>
            </igtab:Tab>
            <igtab:Tab Key="Employee" Text="Employee">
                <ContentTemplate>
                     <div style="width: 100%; vertical-align:top">
                      <asp:UpdatePanel ID="UpdatePanel6" runat="server">
               <ContentTemplate>
                        <table style="width: 100%; vertical-align:top;" >
                            <tr>
                                <td class="style9">
                                    </td>
                                <td class="style10">
                                    <table style="width:100%;">
                                        <tr>
                                            <td class="style13" colspan="4">
                                                UPDATE EMPLOYEE</td>
                                        </tr>
                                        <tr>
                                            <td class="style13">
                                                <asp:Label ID="Label12" runat="server" Text="Search Criteria"></asp:Label>
                                            </td>
                                            <td class="style25">
                                                <asp:DropDownList ID="DropDownListCriteria" runat="server" Width="200px" 
                                                    AutoPostBack="True" 
                                                    onselectedindexchanged="DropDownListCriteria_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td class="style15" style="width: 70%">
                                                <asp:TextBox ID="TextBoxSearchWord" runat="server" 
                                                    ValidationGroup="Search" Width="200px"></asp:TextBox>
                                                <asp:CheckBox ID="CheckBoxActive" runat="server" />
                                                &nbsp;</td>
                                            <td class="style14" style="width: 15%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style12" style="width: 15%">
                                                &nbsp;</td>
                                            <td class="style26">
                                                <asp:LinkButton ID="LinkButtonSearch" runat="server" 
                                                    onclick="LinkButtonSearch_Click" ValidationGroup="Search">Search</asp:LinkButton>
                                            </td>
                                            <td class="style16" style="width: 70%">
                                                &nbsp;</td>
                                            <td class="style17" style="width: 15%">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                                <td class="style9">
                                    </td>
                            </tr>
                            <tr>
                                <td class="style5">
                                    &nbsp;</td>
                                <td class="style3" style="width: 96%">
                                    <asp:Label ID="LabelMessageEmployee" runat="server" Font-Bold="True" 
                                        ForeColor="Red"></asp:Label>
                                </td>
                                <td class="style4" style="width: 2%">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style5">
                                    &nbsp;</td>
                                <td class="style3" style="width: 96%">
                                    <asp:GridView ID="GridViewEmployee" runat="server" 
                                        AutoGenerateColumns="False" DataKeyNames="EmployeeID" 
                                        HorizontalAlign="Left" 
                                        onrowcancelingedit="GridViewEmployee_RowCancelingEdit" 
                                        onrowediting="GridViewEmployee_RowEditing" 
                                        onrowupdating="GridViewEmployee_RowUpdating" ShowFooter="True" 
                                        ShowHeaderWhenEmpty="True" Width="800px" Font-Size="9pt" 
                                        ondatabound="GridViewEmployee_DataBound" 
                                        style="margin-right: 0px; font-size: 9pt; font-family: 'Arial Narrow';">
                                        <Columns>
                                            <asp:BoundField DataField="CardNo" HeaderText="Card No" 
                                                SortExpression="CardNo" ReadOnly="True">
                                                <ItemStyle Width="40px" Font-Names="Arial" Font-Size="8pt" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="First Name" SortExpression="FName">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBoxFNameEdit" runat="server" Font-Size="8pt" 
                                                        Text='<%# Bind("FName") %>' Width="60px"></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label7" runat="server" Font-Size="8pt" 
                                                        Text='<%# Bind("FName") %>' Font-Names="Arial Narrow"></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Last Name" SortExpression="LName">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBoxLNameEdit" runat="server" Font-Size="8pt" 
                                                        Text='<%# Bind("LName") %>' Width="60px"></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label6" runat="server" Font-Size="8pt" 
                                                        Text='<%# Bind("LName") %>' style="font-size: 8pt" 
                                                        Font-Names="Arial Narrow"></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Emp No" SortExpression="EmployeeNo">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBoxEmployeeNoEdit" runat="server" 
                                                        Text='<%# Eval("EmployeeNo") %>' Width="40px" Font-Size="8pt"></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label5" runat="server" Font-Size="8pt" 
                                                        Text='<%# Bind("EmployeeNo") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Job Title" SortExpression="JobTitle">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBoxJobTitleEdit" runat="server" Font-Size="8pt" 
                                                        Text='<%# Bind("JobTitle") %>' Width="70px"></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label3" runat="server" Font-Size="7pt" 
                                                        Text='<%# Bind("JobTitle") %>' Font-Names="Arial Narrow"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Business Unit" SortExpression="BusinessUnitDesc">
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="DropDownListBusinessUnitEdit" runat="server" 
                                                        AutoPostBack="True" Font-Size="8pt" 
                                                        onselectedindexchanged="DropDownListBusinessUnitEdit_SelectedIndexChanged" 
                                                        Width="85px">
                                                    </asp:DropDownList>
                                                    <asp:HiddenField ID="HiddenFieldBusinessUnitID" runat="server" 
                                                        Value='<%# Bind("BusinessUnitID") %>' />
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("BusinessUnitDesc") %>' 
                                                        Font-Size="7pt" Font-Names="Arial Narrow"></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Division Unit">
                                                <EditItemTemplate>                                              
                                                    <asp:DropDownList ID="DropDownListDivisionUnitEdit" runat="server" 
                                                        AutoPostBack="True" Font-Size="8pt" 
                                                        onselectedindexchanged="DropDownListDivisionUnitEdit_SelectedIndexChanged" 
                                                        Width="85px">
                                                    </asp:DropDownList>
                                                    <asp:HiddenField ID="HiddenFieldDivisionUnitID" runat="server" 
                                                        Value='<%# Bind("DivisionUnitID") %>' />
                                                        
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label13" runat="server" Text='<%# Bind("DivisionUnitDesc") %>' 
                                                        Font-Size="7pt" Font-Names="Arial Narrow"></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Department">
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="DropDownListDepartmentEdit" runat="server" 
                                                        Font-Size="8pt" Width="75px">
                                                    </asp:DropDownList>
                                                    <asp:HiddenField ID="HiddenFieldDepartmentID" runat="server" 
                                                        Value='<%# Bind("DepartmentID") %>' />
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label14" runat="server" Text='<%# Bind("DepartmentDesc") %>' 
                                                        Font-Size="7pt" Font-Names="Arial Narrow" 
                                                        style="font-family: 'Arial Narrow'"></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Rate / Hour">
                                                <EditItemTemplate>
                                                    <igtxt:WebNumericEdit ID="WebNumericRateperHourEdit" runat="server" 
                                                        Font-Size="8pt" MinDecimalPlaces="Two" Nullable="False" Width="40px">
                                                    </igtxt:WebNumericEdit>
                                                    <asp:HiddenField ID="HiddenFieldRateperHour" runat="server" 
                                                        Value='<%# Bind("RateperHour") %>' />
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label15" runat="server" Text='<%# Bind("RateperHour") %>' 
                                                        Font-Size="8pt"></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Location">
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="DropDownListStaffLocationEdit" runat="server" 
                                                        Font-Size="8pt" Width="55px">
                                                    </asp:DropDownList>
                                                    <asp:HiddenField ID="HiddenFieldStaffLocationID" runat="server" 
                                                        Value='<%# Bind("StaffLocationID") %>' />
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label16" runat="server" Font-Size="8pt" 
                                                        Text='<%# Bind("StaffLocationDesc") %>' Font-Names="Arial Narrow"></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Active" SortExpression="Active">
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="CheckBoxEmployeeActiveEdit" runat="server" 
                                                        Checked='<%# Bind("Active") %>' Font-Size="8pt" Width="25px" />
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Active") %>' 
                                                        Font-Size="8pt" Font-Names="Arial Narrow"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:CommandField ShowEditButton="True" >
                                            <ItemStyle Width="70px" Font-Names="Arial" Font-Size="8pt" ForeColor="Blue" />
                                            </asp:CommandField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            No Details Found
                                        </EmptyDataTemplate>
                                        <HeaderStyle BackColor="#006699" ForeColor="#66FF33" />
                                    </asp:GridView>
                                </td>
                                <td class="style4" style="width: 2%">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style5">
                                    &nbsp;</td>
                                <td class="style3" style="width: 96%">
                                    <br />
                                    <br />
                                    <br />
                                </td>
                                <td class="style4" style="width: 2%">
                                    &nbsp;</td>
                            </tr>
                        </table>
                        </ContentTemplate>
                          <Triggers>
                              <asp:AsyncPostBackTrigger ControlID="GridViewEmployee" EventName="DataBound" />
                              <asp:AsyncPostBackTrigger ControlID="GridViewEmployee" 
                                  EventName="RowCancelingEdit" />
                              <asp:AsyncPostBackTrigger ControlID="GridViewEmployee" EventName="RowEditing" />
                              <asp:AsyncPostBackTrigger ControlID="GridViewEmployee" 
                                  EventName="RowUpdating" />
                              <asp:AsyncPostBackTrigger ControlID="LinkButtonSearch" EventName="Click" />
                              <asp:AsyncPostBackTrigger ControlID="DropDownListCriteria" 
                                  EventName="SelectedIndexChanged" />
                          </Triggers>
                         </asp:UpdatePanel>
                    </div>
                </ContentTemplate>
            </igtab:Tab>
            <igtab:TabSeparator>
                <Style BackColor="#3399FF">
                </Style>
            </igtab:TabSeparator>
        </Tabs>
    </igtab:UltraWebTab>
    </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="UltraWebTabRefTables" 
                EventName="TabClick" />
        </Triggers>
    </asp:UpdatePanel>
<br />

<hr />

    <asp:SqlDataSource ID="SqlDataSourceBusinessUnit" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        
        SelectCommand="SELECT [BusinessUnitID], [BusinessUnitDesc], [Active] FROM [BusinessUnit]">
    </asp:SqlDataSource>

<br />

</asp:Content>
