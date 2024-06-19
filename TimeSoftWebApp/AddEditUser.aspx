<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddEditUser.aspx.cs" Inherits="TimeSoftWebApp.AddEditUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 308px;
        }
        .style2
        {
            text-align: center;
        }
        .style3
        {
            width: 300px;
        }
        .style4
        {
            text-align: right;
        }
        .style5
        {
            text-align: right;
            height: 25px;
        }
        .style6
        {
            width: 300px;
            height: 25px;
        }
        .style7
        {
            text-align: center;
            height: 25px;
        }
        .style8
        {
            width: 25%;
            height: 26px;
        }
        .style9
        {
            width: 50%;
            height: 26px;
        }
        .style10
        {
            width: 100%;
            height: 25px;
        }
        .style11
        {
            width: 300px;
            text-align: left;
        }
        .style12
        {
            width: 300px;
            height: 25px;
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Admin Reports</h1>
    <p>
        <asp:LinkButton ID="LinkButtonCreateUser" runat="server" 
            onclick="LinkButtonCreateUser_Click">Create User</asp:LinkButton>
&nbsp;
        <asp:LinkButton ID="LinkButtonEditUser" runat="server" 
            onclick="LinkButtonEditUser_Click">Edit / Delete User</asp:LinkButton>
&nbsp;
        <asp:LinkButton ID="LinkButtonResetPassword" runat="server" 
            onclick="LinkButtonResetPassword_Click">Reset Password</asp:LinkButton>
    </p>
        <br />
    <hr />
    <div>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
        <asp:Panel ID="PanelCreateUser" runat="server">
            <table style="width:100%;">
                <tr>
                    <td class="style1" style="width: 25%; font-weight: 700;">
                        &nbsp;</td>
                    <td style="width: 50%">
                        <table style="border-style: solid; border-width: 1px; width:100%;">
                            <tr>
                                <td class="style7" colspan="2" style="background-color: #3399FF">
                                    <strong>CREATE USER ACCOUNT</strong></td>
                            </tr>
                            <tr>
                                <td class="style5">
                                    User Name:&nbsp;&nbsp;
                                </td>
                                <td class="style12">
                                    <asp:TextBox ID="TextBoxUserName" runat="server" Width="200px"></asp:TextBox>
                                    <asp:Label ID="LabelErrorUserName" runat="server" ForeColor="Red" 
                                        Text="required"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style4">
                                    Last Name:&nbsp;&nbsp;
                                </td>
                                <td class="style11">
                                    <asp:TextBox ID="TextBoxLastName" runat="server" Width="200px"></asp:TextBox>
                                    <asp:Label ID="LabelErrorLastName" runat="server" ForeColor="Red" 
                                        Text="required"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style4">
                                    Other Names:&nbsp;&nbsp;
                                </td>
                                <td class="style11">
                                    <asp:TextBox ID="TextBoxOtherNames" runat="server" Width="200px"></asp:TextBox>
                                    <asp:Label ID="LabelErrorOtherNames" runat="server" ForeColor="Red" 
                                        Text="required"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style4">
                                    Role:&nbsp;&nbsp;
                                </td>
                                <td class="style11">
                                    <asp:DropDownList ID="DropDownListRole" runat="server" AutoPostBack="True" 
                                        onselectedindexchanged="DropDownListRole_SelectedIndexChanged" 
                                        Width="205px">
                                    </asp:DropDownList>
                                    <asp:Label ID="LabelErrorRole" runat="server" ForeColor="Red" Text="required"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style4">
                                    Password:&nbsp;&nbsp;
                                </td>
                                <td class="style11">
                                    <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password" 
                                        Width="200px"></asp:TextBox>
                                    <asp:Label ID="LabelErrorPassword" runat="server" ForeColor="Red" 
                                        Text="required"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style4">
                                    Confirm Password:&nbsp;&nbsp;
                                </td>
                                <td class="style11">
                                    <asp:TextBox ID="TextBoxConfirmPassword" runat="server" TextMode="Password" 
                                        Width="200px"></asp:TextBox>
                                    <asp:Label ID="LabelErrorConfirmPasswd" runat="server" ForeColor="Red" 
                                        Text="required"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style4">
                                    Email:&nbsp;&nbsp;
                                </td>
                                <td class="style11">
                                    <asp:TextBox ID="TextBoxEmail" runat="server" Width="200px" 
                                        ValidationGroup="InsertUser"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" 
                                        runat="server" ControlToValidate="TextBoxEmail" ErrorMessage="invalid" 
                                        ForeColor="Red" 
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                        ValidationGroup="InsertUser"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style4">
                                    Phone:&nbsp;&nbsp;
                                </td>
                                <td class="style11">
                                    <asp:TextBox ID="TextBoxPhone" runat="server" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style4">
                                    Business Unit:&nbsp;&nbsp;
                                </td>
                                <td class="style11">
                                    <asp:DropDownList ID="DropDownListBusinessUnit" runat="server" Width="205px" 
                                        onselectedindexchanged="DropDownListBusinessUnit_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:Label ID="LabelErrorBusinessUnit" runat="server" ForeColor="Red" 
                                        Text="required"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style4">
                                    Division Unit:&nbsp;&nbsp;
                                </td>
                                <td class="style11">
                                    <asp:DropDownList ID="DropDownListDivisionUnit" runat="server" Width="205px" 
                                        onselectedindexchanged="DropDownListDivisionUnit_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:Label ID="LabelErrorDivisionUnit" runat="server" ForeColor="Red" 
                                        Text="required"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style4">
                                    Department:&nbsp;&nbsp;
                                </td>
                                <td class="style11">
                                    <asp:DropDownList ID="DropDownListDepartment" runat="server" Width="205px">
                                    </asp:DropDownList>
                                    <asp:Label ID="LabelErrorDepartment" runat="server" ForeColor="Red" 
                                        Text="required"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style2" colspan="2">
                                    <asp:Label ID="LabelMessage" runat="server" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    &nbsp;</td>
                                <td class="style3">
                                    <asp:LinkButton ID="LinkButtonInsertUser" runat="server" 
                                        onclick="LinkButtonInsertUser_Click" ValidationGroup="InsertUser">Submit</asp:LinkButton>
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
            <asp:AsyncPostBackTrigger ControlID="LinkButtonCreateUser" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="LinkButtonCancel" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
      
      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <asp:Panel ID="PanelUpdateUser" runat="server">
            <table style="width:100%;">
                <tr>
                    <td style="width: 100%; text-align: center; background-color: #3399FF;">
                        <strong>EDIT / DELETE USER</strong></td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: left; ">
                        <asp:Label ID="LabelMessageEditUser" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style10">
                        <asp:GridView ID="GridViewUser" runat="server" AutoGenerateColumns="False" 
                            DataKeyNames="UserID" HorizontalAlign="Left" 
                            onrowcancelingedit="GridViewUser_RowCancelingEdit" 
                            onrowdeleting="GridViewUser_RowDeleting" onrowediting="GridViewUser_RowEditing" 
                            onrowupdating="GridViewUser_RowUpdating" ShowFooter="True" 
                            ShowHeaderWhenEmpty="True" style="font-family: 'Times New Roman'" 
                            Width="100%" ondatabound="GridViewUser_DataBound">
                            <Columns>
                                <asp:BoundField DataField="UserID" HeaderText="ID" ReadOnly="True" 
                                    SortExpression="UserID">
                                <ControlStyle Width="40px" />
                                <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="UserName" HeaderText="User Name" ReadOnly="True" >
                                <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Last Name" SortExpression="LastName">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBoxLastName" runat="server" Text='<%# Bind("LastName") %>' 
                                            Width="100px" style="font-size: x-small"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Other Names" SortExpression="OtherNames">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBoxOtherNames" runat="server" Text='<%# Bind("OtherNames") %>' 
                                            Width="120px" style="font-size: x-small"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("OtherNames") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Role" SortExpression="RoleDesc">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="DropDownListEditUserRole" runat="server" AutoPostBack="True" 
                                            DataSourceID="SqlDataSourceRole" DataTextField="RoleDesc" 
                                            DataValueField="RoleID" 
                                            onselectedindexchanged="DropDownListEditUserRole_SelectedIndexChanged" 
                                            SelectedValue='<%# Bind("RoleID") %>' Width="100px" 
                                            style="font-size: x-small">
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("RoleDesc") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Business Unit" SortExpression="BudinessUnitDesc">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="DropDownListEditUserBusinessUnit" runat="server" 
                                            Width="110px" AutoPostBack="True" Font-Size="Smaller" 
                                            onselectedindexchanged="DropDownListEditUserBusinessUnit_SelectedIndexChanged" 
                                            style="font-size: x-small">
                                        </asp:DropDownList>
                                        <asp:HiddenField ID="HiddenFieldBusinessUnitID" runat="server" 
                                            Value='<%# Bind("BusinessUnitID") %>' />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("BusinessUnitDesc") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Division Unit" SortExpression="DivisionUnitDesc">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="DropDownListEditUserDivisionUnitID" runat="server" 
                                            Width="110px" AutoPostBack="True" 
                                            onselectedindexchanged="DropDownListEditUserDivisionUnitID_SelectedIndexChanged" 
                                            style="font-size: x-small">
                                        </asp:DropDownList>
                                        <asp:HiddenField ID="HiddenFieldDivisionUnitID" runat="server" 
                                            Value='<%# Bind("DivisionUnitID") %>' />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("DivisionUnitDesc") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Department" SortExpression="DepartmentDesc">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="DropDownListEditUserDepartmentID" runat="server" 
                                            Width="110px" style="font-size: x-small">
                                        </asp:DropDownList>
                                        <asp:HiddenField ID="HiddenFieldDepartmentID" runat="server" 
                                            Value='<%# Bind("DepartmentID") %>' />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("DepartmentDesc") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:CommandField ShowEditButton="True">
                                <ItemStyle ForeColor="Blue" />
                                </asp:CommandField>
                                <asp:CommandField ShowDeleteButton="True">
                                <ItemStyle ForeColor="Blue" />
                                </asp:CommandField>
                            </Columns>
                            <EmptyDataTemplate>
                                No Details Found
                            </EmptyDataTemplate>
                            <HeaderStyle BackColor="#006699" Height="25px" ForeColor="#66FF33" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%">
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
        </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
          <asp:Panel ID="Panel1" runat="server" Width="100%">
              <asp:Panel ID="PanelResetPassword" runat="server">
                
                  <table style="width:100%;">
                      <tr>
                          <td class="style1" style="width: 25%; font-weight: 700;">
                              &nbsp;</td>
                          <td style="width: 50%">
                              <table style="border-style: solid; border-width: 1px; width:100%;">
                                  <tr>
                                      <td class="style7" colspan="2" style="background-color: #3399FF">
                                          <strong>RESET USER PASSWORD</strong></td>
                                  </tr>
                                  <tr>
                                      <td class="style5">
                                          User Name:&nbsp;&nbsp;
                                      </td>
                                      <td class="style6">
                                          <asp:TextBox ID="TextBoxResetUserName" runat="server" Width="200px"></asp:TextBox>
                                          <asp:Label ID="LabelErrorResetUserName" runat="server" ForeColor="Red" 
                                              Text="required"></asp:Label>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td class="style4">
                                          Password:&nbsp;&nbsp;
                                      </td>
                                      <td class="style3">
                                          <asp:TextBox ID="TextBoxResetPassword" runat="server" TextMode="Password" 
                                              Width="200px"></asp:TextBox>
                                          <asp:Label ID="LabelErrorResetPassword" runat="server" ForeColor="Red" 
                                              Text="required"></asp:Label>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td class="style4">
                                          Confirm Password:&nbsp;&nbsp;
                                      </td>
                                      <td class="style3">
                                          <asp:TextBox ID="TextBoxResetConfirmPassword" runat="server" 
                                              TextMode="Password" Width="200px"></asp:TextBox>
                                          <asp:Label ID="LabelErrorResetConfirmPasswd" runat="server" ForeColor="Red" 
                                              Text="required"></asp:Label>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td class="style2" colspan="2">
                                          <asp:Label ID="LabelMessageReset" runat="server" ForeColor="Red"></asp:Label>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td class="style2" colspan="2">
                                          <asp:LinkButton ID="LinkButtonResetUserPasswd" runat="server" 
                                              onclick="LinkButtonResetUserPasswd_Click" ValidationGroup="InsertUser">Reset Password</asp:LinkButton>
                                          &nbsp;
                                          <asp:LinkButton ID="LinkButtonResetCancel" runat="server" 
                                              onclick="LinkButtonResetCancel_Click">Cancel</asp:LinkButton>
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
        </asp:Panel>
        </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="LinkButtonResetCancel" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="LinkButtonResetUserPasswd" 
                    EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
          <br />
        <asp:SqlDataSource ID="SqlDataSourceRole" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            SelectCommand="SELECT [RoleID], [RoleDesc] FROM [Role]"></asp:SqlDataSource>
        <br />
    </div>
</asp:Content>
