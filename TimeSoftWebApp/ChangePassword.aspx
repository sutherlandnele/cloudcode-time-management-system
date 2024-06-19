<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="TimeSoftWebApp.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            text-align: left;
        }
        .style2
        {
            text-align: right;
        }
        .style3
        {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Change Password</h1>
        <hr />
        <br />
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
              <asp:Panel ID="PanelResetPassword" runat="server">
                  <table style="width:100%;">
                      <tr>
                          <td class="style1" style="width: 25%; font-weight: 700;">
                              &nbsp;</td>
                          <td style="width: 50%">
                              <table style="border-style: solid; border-width: 1px; width:100%;">
                                  <tr>
                                      <td class="style7" colspan="2" 
                                          style="background-color: #3399FF; text-align: center;">
                                          <strong>CHANGE PASSWORD</strong></td>
                                  </tr>
                                  <tr>
                                      <td class="style2">
                                          User Name:&nbsp;&nbsp;
                                      </td>
                                      <td class="style1">
                                          <asp:TextBox ID="TextBoxUserName" runat="server" Width="200px" ReadOnly="True"></asp:TextBox>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td class="style2">
                                          Current Password:&nbsp;&nbsp;
                                      </td>
                                      <td class="style1">
                                          <asp:TextBox ID="TextBoxCurrentPassword" runat="server" TextMode="Password" 
                                        Width="200px"></asp:TextBox>
                                          <asp:Label ID="LabelErrorCurrentPassword" runat="server" ForeColor="Red" 
                                        Text="required"></asp:Label>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td class="style2">
                                          New Password:&nbsp;&nbsp;
                                      </td>
                                      <td class="style1">
                                          <asp:TextBox ID="TextBoxNewPassword" runat="server" TextMode="Password" 
                                              Width="200px"></asp:TextBox>
                                          <asp:Label ID="LabelErrorNewPassword" runat="server" ForeColor="Red" 
                                              Text="required"></asp:Label>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td class="style2">
                                          Confirm New Password:&nbsp;&nbsp;
                                      </td>
                                      <td class="style1">
                                          <asp:TextBox ID="TextBoxConfirmNewPassword" runat="server" TextMode="Password" 
                                              Width="200px"></asp:TextBox>
                                          <asp:Label ID="LabelErrorConfirmPassword" runat="server" ForeColor="Red" 
                                              Text="required"></asp:Label>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td class="style3" colspan="2">
                                          <asp:Label ID="LabelMessage" runat="server" ForeColor="Red"></asp:Label>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td class="style3" colspan="2">
                                          <asp:LinkButton ID="LinkButtonChangePassword" runat="server" 
                                              onclick="LinkButtonChangePassword_Click" ValidationGroup="InsertUser">Change Password</asp:LinkButton>
                                          &nbsp;
                                          <asp:LinkButton ID="LinkButtonCancel" runat="server" 
                                              onclick="LinkButtonCancel_Click">Cancel</asp:LinkButton>
                                      </td>
                                  </tr>
                              </table>
                              <br />
                          </td>
                          <td style="width: 25%">
                              &nbsp;</td>
                      </tr>
                      <tr>
                          <td class="style8">
                          </td>
                          <td class="style9">
                          </td>
                          <td class="style8">
                          </td>
                      </tr>
                      <tr>
                          <td class="style1" style="width: 25%">
                              &nbsp;</td>
                          <td style="width: 50%">
                              &nbsp;</td>
                          <td style="width: 25%">
                              &nbsp;</td>
                      </tr>
                  </table>
                
              </asp:Panel>
              </ContentTemplate>
              <Triggers>
                  <asp:AsyncPostBackTrigger ControlID="LinkButtonCancel" EventName="Click" />
                  <asp:AsyncPostBackTrigger ControlID="LinkButtonChangePassword" 
                      EventName="Click" />
            </Triggers>
              </asp:UpdatePanel>
        </asp:Content>
