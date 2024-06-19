<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TimeSoftWebApp.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style3
        {
            height: 25px;
            text-align: center;
            background-color: #006699;
        }
        .style4
        {
            width: 25%;
            text-align: right;
        }
        .style5
        {
            color: #FFFFFF;
            font-size: small;
        }
        .style6
        {
            color: #FFFFFF;
            font-size: medium;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Login Page</h1>
<br />
<hr />
<div id="login1" style="margin-left:30%; width:40%; height:200px; border-style:solid; border-color:Black; border-width:thin; " > 
<table style="width: 100%;">
        <tr>
            <td class="style3" colspan="2">
                &nbsp;
                <strong><span class="style5">&nbsp;</span><span class="style6"> Login</span></strong></td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                User Name: </td>
            <td>
                <asp:TextBox ID="TextBoxUserName" runat="server" CssClass="textbox" 
                    Width="150px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserName" runat="server" 
                    ControlToValidate="TextBoxUserName" ErrorMessage="*" style="color: #FF0000"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Password: </td>
            <td>
                <asp:TextBox ID="TextBoxPassword" runat="server" CssClass="textbox" 
                    TextMode="Password" Width="150px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" 
                    ControlToValidate="TextBoxPassword" ErrorMessage="*" style="color: #FF0000"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td>
          
                <asp:Label ID="LabelMessage" runat="server" style="color: #FF0000"></asp:Label>
                
            </td>
        </tr>
         <tr>
            <td class="style4">
                &nbsp; </td>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButtonLogin" runat="server" 
                    onclick="LinkButtonLogin_Click">Login</asp:LinkButton>
&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButtonCancel" runat="server" 
                    onclick="LinkButtonCancel_Click">Cancel</asp:LinkButton>
            </td>
        </tr>
    </table>
    </div>
    <br />
    <br />
    <br />


</asp:Content>
