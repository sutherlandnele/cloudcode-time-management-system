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
using System.Drawing;
using System.Collections;

namespace TimeSoftWebApp
{
    public partial class AddEditUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ComboBusinessComponent comboBusinessComponent = new ComboBusinessComponent(Thread.CurrentPrincipal);
                ComboEntityCollection comboEntityCollection = new ComboEntityCollection();
                comboEntityCollection = comboBusinessComponent.GetComboData(ReferenceTable.Role, true);
                DropDownListRole.DataSource = comboEntityCollection;
                DropDownListRole.DataTextField = Combo.Description;
                DropDownListRole.DataValueField = Combo.ID;
                DropDownListRole.DataBind();

                comboEntityCollection = new ComboEntityCollection();
                comboEntityCollection = comboBusinessComponent.GetComboData(ReferenceTable.BusinessUnit, true);
                DropDownListBusinessUnit.DataSource = comboEntityCollection;
                DropDownListBusinessUnit.DataTextField = Combo.Description;
                DropDownListBusinessUnit.DataValueField = Combo.ID;
                DropDownListBusinessUnit.DataBind();

                PanelCreateUser.Visible = true;
                PanelUpdateUser.Visible = false;
                PanelResetPassword.Visible = false;

                UserBusinessComponent userBusinessComponent = new UserBusinessComponent(Thread.CurrentPrincipal);
                UserEntity userEntity = userBusinessComponent.GetByUserName(HttpContext.Current.User.Identity.Name);
                if (userEntity != null)
                {
                    if (userEntity.RoleID != (int)Role.Admin)
                    {
                        Response.Redirect("AccessDenied.aspx");
                    }
                }
                else
                {
                    Response.Redirect("AccessDenied.aspx");
                }

            }
            SetInsertVisibleErrorToFalse();
            LabelMessage.Text = string.Empty;
            LabelMessageEditUser.Text = string.Empty;
            LabelErrorResetUserName.Visible = false;
            LabelErrorResetPassword.Visible = false;
            LabelErrorResetConfirmPasswd.Visible = false;
        }

        protected void LinkButtonCancel_Click(object sender, EventArgs e)
        {
            ResetInsertFields();
        }

        void ResetInsertFields()
        {
            TextBoxUserName.Text = string.Empty;
            TextBoxLastName.Text = string.Empty;
            TextBoxOtherNames.Text = string.Empty;
            TextBoxPassword.Text = string.Empty;
            TextBoxPhone.Text = string.Empty;
            TextBoxEmail.Text = string.Empty;
            DropDownListRole.SelectedValue = "0";
            DropDownListBusinessUnit.SelectedValue = "0";
            DropDownListDivisionUnit.SelectedValue = "0";
            DropDownListDepartment.SelectedValue = "0";
        }

        bool ValidInsertFields()
        {
            bool valid = true;
            LabelMessage.Text = string.Empty;
            if (string.IsNullOrEmpty(TextBoxUserName.Text))
            {
                LabelErrorUserName.Visible = true;
                valid = false;
            }
            else
            {
                UserBusinessComponent userBusinesscomponent = new UserBusinessComponent(Thread.CurrentPrincipal);
                UserEntity userEntity = userBusinesscomponent.GetByUserName(TextBoxUserName.Text);
                if (userEntity != null)
                {
                    if (userEntity.UserName.CompareTo(TextBoxUserName.Text) == 0)
                    {
                        LabelMessage.Text = "The User Name you entered is already in user. Please enter a different user name.";
                        LabelMessage.ForeColor = Color.Red;
                        LabelErrorUserName.Visible = true;
                        valid = false;
                    }
                }
            }
            if (string.IsNullOrEmpty(TextBoxLastName.Text))
            {
                LabelErrorLastName.Visible = true;
                valid = false;
            }
            if (string.IsNullOrEmpty(TextBoxPassword.Text))
            {
                LabelErrorPassword.Visible = true;
                valid = false;
            }
            else if (string.IsNullOrEmpty(TextBoxConfirmPassword.Text))
            {
                LabelErrorConfirmPasswd.Visible = true;
                valid = false;
            }
            else
            {
                if (TextBoxPassword.Text.CompareTo(TextBoxConfirmPassword.Text) != 0)
                {
                    LabelErrorConfirmPasswd.Visible = true;
                    LabelErrorPassword.Visible = true;
                    valid = false;
                    if (string.IsNullOrEmpty(LabelMessage.Text))
                    {
                        LabelMessage.Text = "Your Password does not match. Please retype your password.";
                        LabelMessage.ForeColor = Color.Red;
                    }
                }
            }
            if (DropDownListRole.SelectedIndex == -1)
            {
                LabelErrorRole.Visible = true;
                valid = false;
            }
            else if (DropDownListRole.SelectedValue == "0")
            {
                LabelErrorRole.Visible = true;
                valid = false;
            }
            else
            {
                if (DropDownListRole.SelectedValue == ((int)Role.DivisionHead).ToString()
                   || DropDownListRole.SelectedValue == ((int)Role.DepartmentManager).ToString()
                      || DropDownListRole.SelectedValue == ((int)Role.BusinessHead).ToString())
                {
                    if (DropDownListBusinessUnit.SelectedIndex == -1)
                    {
                        LabelErrorBusinessUnit.Visible = true;
                        valid = false;
                    }
                    else if (DropDownListBusinessUnit.SelectedValue == "0")
                    {
                        LabelErrorBusinessUnit.Visible = true;
                        valid = false;
                    }
                }

                if (DropDownListRole.SelectedValue == ((int)Role.DivisionHead).ToString()
                    || DropDownListRole.SelectedValue == ((int)Role.DepartmentManager).ToString())
                {
                    if (DropDownListDivisionUnit.SelectedIndex == -1)
                    {
                        LabelErrorDivisionUnit.Visible = true;
                        valid = false;
                    }
                    else if (DropDownListDivisionUnit.SelectedValue == "0")
                    {
                        LabelErrorDivisionUnit.Visible = true;
                        valid = false;
                    }
                }
                else if (DropDownListRole.SelectedValue == ((int)Role.DepartmentManager).ToString())
                {
                    if (DropDownListDepartment.SelectedIndex == -1)
                    {
                        LabelErrorDepartment.Visible = true;
                        valid = false;
                    }
                    else if (DropDownListDepartment.SelectedValue == "0")
                    {
                        LabelErrorDepartment.Visible = true;
                        valid = false;
                    }
                }
            }
            return valid;
        }

        void SetInsertVisibleErrorToFalse()
        {
            LabelErrorUserName.Visible = false;
            LabelErrorLastName.Visible = false;
            LabelErrorOtherNames.Visible = false;
            LabelErrorPassword.Visible = false;
            LabelErrorConfirmPasswd.Visible = false;
            LabelErrorRole.Visible = false;
            LabelErrorBusinessUnit.Visible = false;
            LabelErrorDivisionUnit.Visible = false;
            LabelErrorDepartment.Visible = false;
        }

        protected void LinkButtonInsertUser_Click(object sender, EventArgs e)
        {
            UserBusinessComponent userBusinesscomponent = new UserBusinessComponent(Thread.CurrentPrincipal);
            UserEntity userEntity = new UserEntity();
            if (ValidInsertFields())
            {
                userEntity.UserName = TextBoxUserName.Text;
                userEntity.LastName = TextBoxLastName.Text;
                userEntity.OtherNames = TextBoxOtherNames.Text;
                userEntity.RoleID = int.Parse(DropDownListRole.SelectedValue);
                userEntity.Email = TextBoxEmail.Text;
                userEntity.Phone = TextBoxPhone.Text;
                userEntity.Password = TextBoxPassword.Text;
                if (DropDownListRole.SelectedValue == ((int)Role.BusinessHead).ToString()
                    || DropDownListRole.SelectedValue == ((int)Role.DivisionHead).ToString()
                    || DropDownListRole.SelectedValue == ((int)Role.DepartmentManager).ToString())
                {
                    userEntity.BusinessUnitID = int.Parse(DropDownListBusinessUnit.SelectedValue);
                }
                else
                {
                    userEntity.BusinessUnitID = null;
                }
                if (DropDownListRole.SelectedValue == ((int)Role.DivisionHead).ToString()
                   || DropDownListRole.SelectedValue == ((int)Role.DepartmentManager).ToString())
                {
                    userEntity.DivisionUnitID = int.Parse(DropDownListDivisionUnit.SelectedValue);
                }
                else
                {
                    userEntity.DivisionUnitID = null;
                }
                if (DropDownListRole.SelectedValue == ((int)Role.DepartmentManager).ToString())
                {
                    userEntity.DepartmentID = int.Parse(DropDownListDepartment.SelectedValue);
                }
                else
                {
                    userEntity.DepartmentID = null;
                }

                int userid = userBusinesscomponent.Insert(userEntity);
                LabelMessage.Text = "User successfully created.";
                LabelMessage.ForeColor = Color.Blue;
                ResetInsertFields();
            }
            else
            {
                if (string.IsNullOrEmpty(LabelMessage.Text))
                {
                    LabelMessage.Text = "Please fill in the required details.";
                }
            }
        }

        protected void DropDownListRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListBusinessUnit.Enabled = true;
            DropDownListDivisionUnit.Enabled = true;
            DropDownListDepartment.Enabled = true;
            if (DropDownListRole.SelectedIndex != -1)
            {
                if (DropDownListRole.SelectedValue == ((int)Role.Chief).ToString() || DropDownListRole.SelectedValue == ((int)Role.MD).ToString())
                {
                    DropDownListBusinessUnit.Enabled = false;
                    DropDownListDivisionUnit.Enabled = false;
                    DropDownListDepartment.Enabled = false;
                }
                if (DropDownListRole.SelectedValue == ((int)Role.BusinessHead).ToString())
                {
                    DropDownListDivisionUnit.Enabled = false;
                    DropDownListDepartment.Enabled = false;
                }
                else if (DropDownListRole.SelectedValue == ((int)Role.DivisionHead).ToString())
                {
                    DropDownListDepartment.Enabled = false;
                }
            }
        }

        protected void GridViewUser_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewUser.EditIndex = -1;
            LoadGridUser();
            LabelMessageEditUser.Text = "Row Editing Canelled.";
        }

        protected void GridViewUser_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                UserBusinessComponent userBusinessComponent = new UserBusinessComponent(Thread.CurrentPrincipal);
                int id = int.Parse(GridViewUser.DataKeys[e.RowIndex].Value.ToString());
                UserEntity userEntity = new UserEntity();
                userEntity.UserID = id;
                userBusinessComponent.Delete(userEntity);
                GridViewUser.EditIndex = -1;
                LoadGridUser();
                LabelMessageEditUser.Text = "Row with id: " + id + " sucessfully deleted.";
            }
            catch (Exception ex)
            {
                LabelMessageEditUser.Text = ex.Message;
            }
        }

        protected void GridViewUser_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewUser.EditIndex = e.NewEditIndex;
            LoadGridUser();
            GridViewUser.Rows[e.NewEditIndex].BackColor = Color.Yellow;
            DropDownListEditUserRole_SelectedIndexChanged(sender, e);
        }

        protected void GridViewUser_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = int.Parse(GridViewUser.DataKeys[e.RowIndex].Value.ToString());
            ICollection collection = e.NewValues.Values;
            UserEntity userEntity = new UserEntity();
            userEntity.UserID = id;

            userEntity.LastName = (((TextBox)GridViewUser.Rows[e.RowIndex].FindControl("TextBoxLastName")).Text);
            userEntity.OtherNames = (((TextBox)GridViewUser.Rows[e.RowIndex].FindControl("TextBoxOtherNames")).Text);
            if (string.IsNullOrEmpty(userEntity.LastName))
            {
                LabelMessageEditUser.Text = "Please enter Last Name.";
                return;
            }
            else if (string.IsNullOrEmpty(userEntity.OtherNames))
            {
                LabelMessageEditUser.Text = "Please enter Other Names.";
                return;
            }
            if ((((DropDownList)GridViewUser.Rows[e.RowIndex].FindControl("DropDownListEditUserRole")).SelectedValue) == "0")
            {
                LabelMessageEditUser.Text = "Please select Role.";
                return;
            }
            else
            {
                userEntity.RoleID = int.Parse((((DropDownList)GridViewUser.Rows[e.RowIndex].FindControl("DropDownListEditUserRole")).SelectedValue));
            }

            if ((((DropDownList)GridViewUser.Rows[e.RowIndex].FindControl("DropDownListEditUserBusinessUnit")).Enabled) == true)
            {
                if ((((DropDownList)GridViewUser.Rows[e.RowIndex].FindControl("DropDownListEditUserBusinessUnit")).SelectedValue) == "0")
                {
                    LabelMessageEditUser.Text = "Please select Business Unit.";
                    return;
                }
                else
                {
                    userEntity.BusinessUnitID = int.Parse((((DropDownList)GridViewUser.Rows[e.RowIndex].FindControl("DropDownListEditUserBusinessUnit")).SelectedValue));
                }
            }
            else
            {
                userEntity.BusinessUnitID = null;
            }
            if ((((DropDownList)GridViewUser.Rows[e.RowIndex].FindControl("DropDownListEditUserDivisionUnitID")).Enabled) == true)
            {
                if ((((DropDownList)GridViewUser.Rows[e.RowIndex].FindControl("DropDownListEditUserDivisionUnitID")).SelectedValue) == "0")
                {
                    LabelMessageEditUser.Text = "Please select Division Unit.";
                    return;
                }
                else
                {
                    userEntity.DivisionUnitID = int.Parse((((DropDownList)GridViewUser.Rows[e.RowIndex].FindControl("DropDownListEditUserDivisionUnitID")).SelectedValue));
                }
            }
            else
            {
                userEntity.DivisionUnitID = null;
            }
            if ((((DropDownList)GridViewUser.Rows[e.RowIndex].FindControl("DropDownListEditUserDepartmentID")).Enabled) == true)
            {
                if ((((DropDownList)GridViewUser.Rows[e.RowIndex].FindControl("DropDownListEditUserDepartmentID")).SelectedValue) == "0")
                {
                    LabelMessageEditUser.Text = "Please select Department.";
                    return;
                }
                else
                {
                    userEntity.DepartmentID = int.Parse((((DropDownList)GridViewUser.Rows[e.RowIndex].FindControl("DropDownListEditUserDepartmentID")).SelectedValue));
                }
            }
            else
            {
                userEntity.DepartmentID = null;
            }

            UserBusinessComponent userBusinessComponent = new UserBusinessComponent(Thread.CurrentPrincipal);
            userBusinessComponent.Update(userEntity);
            GridViewUser.EditIndex = -1;
            LoadGridUser();
            LabelMessageEditUser.Text = "Row with id: " + id + " sucessfully updated.";
        }

        protected void DropDownListBusinessUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListBusinessUnit.SelectedIndex != -1)
            {
                int businessUnitID = int.Parse(DropDownListBusinessUnit.SelectedValue.ToString());
                ComboEntityCollection comboEntityCollection = new ComboEntityCollection();
                ComboBusinessComponent comboBusinessComponent = new ComboBusinessComponent(Thread.CurrentPrincipal);
                comboEntityCollection = comboBusinessComponent.GetComboDataByForeignnKey(ReferenceTable.DivisionUnit, businessUnitID, true);
                DropDownListDivisionUnit.DataSource = comboEntityCollection;
                DropDownListDivisionUnit.DataTextField = Combo.Description;
                DropDownListDivisionUnit.DataValueField = Combo.ID;
                DropDownListDivisionUnit.DataBind();
                comboEntityCollection = new ComboEntityCollection();
                DropDownListDepartment.DataSource = comboEntityCollection;
                DropDownListDepartment.DataBind();
            }
            else
            {
                ComboEntityCollection comboEntityCollection = new ComboEntityCollection();
                DropDownListDivisionUnit.DataSource = comboEntityCollection;
                DropDownListDivisionUnit.DataBind();
                DropDownListDepartment.DataSource = comboEntityCollection;
                DropDownListDepartment.DataBind();
            }

        }

        protected void DropDownListDivisionUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListDivisionUnit.SelectedIndex != -1)
            {
                int divisionUnitID = int.Parse(DropDownListDivisionUnit.SelectedValue.ToString());
                ComboEntityCollection comboEntityCollection = new ComboEntityCollection();
                ComboBusinessComponent comboBusinessComponent = new ComboBusinessComponent(Thread.CurrentPrincipal);
                comboEntityCollection = comboBusinessComponent.GetComboDataByForeignnKey(ReferenceTable.Department, divisionUnitID, true);
                DropDownListDepartment.DataSource = comboEntityCollection;
                DropDownListDepartment.DataTextField = Combo.Description;
                DropDownListDepartment.DataValueField = Combo.ID;
                DropDownListDepartment.DataBind();
            }
            else
            {
                ComboEntityCollection comboEntityCollection = new ComboEntityCollection();
                DropDownListDepartment.DataSource = comboEntityCollection;
                DropDownListDepartment.DataBind();
            }
        }

        protected void LinkButtonCreateUser_Click(object sender, EventArgs e)
        {
            PanelCreateUser.Visible = true;
            PanelUpdateUser.Visible = false;
            PanelResetPassword.Visible = false;
        }

        protected void LinkButtonEditUser_Click(object sender, EventArgs e)
        {
            PanelCreateUser.Visible = false;
            PanelUpdateUser.Visible = true;
            PanelResetPassword.Visible = false;
            LoadGridUser();

        }

        void LoadGridUser()
        {
            UserBusinessComponent userBusinessComponent = new UserBusinessComponent(Thread.CurrentPrincipal);
            UserEntityCollection userEntityCollection = userBusinessComponent.FindAll();
            GridViewUser.DataSource = userEntityCollection;
            GridViewUser.DataBind();
        }

        protected void DropDownListEditUserRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridViewUser.Rows)
            {
                if (row.FindControl("DropDownListEditUserRole") != null)
                {
                    int roleID = Convert.ToInt32(((DropDownList)row.FindControl("DropDownListEditUserRole")).SelectedValue);
                    ((DropDownList)row.FindControl("DropDownListEditUserBusinessUnit")).Enabled = true;
                    ((DropDownList)row.FindControl("DropDownListEditUserDivisionUnitID")).Enabled = true;
                    ((DropDownList)row.FindControl("DropDownListEditUserDepartmentID")).Enabled = true;

                    if (roleID == (int)Role.Chief || roleID == (int)Role.MD)
                    {
                        ((DropDownList)row.FindControl("DropDownListEditUserBusinessUnit")).Enabled = false;
                        ((DropDownList)row.FindControl("DropDownListEditUserDepartmentID")).Enabled = false;
                        ((DropDownList)row.FindControl("DropDownListEditUserDivisionUnitID")).Enabled = false;
                    }
                    if (roleID == (int)Role.BusinessHead)
                    {
                        ((DropDownList)row.FindControl("DropDownListEditUserDepartmentID")).Enabled = false;
                        ((DropDownList)row.FindControl("DropDownListEditUserDivisionUnitID")).Enabled = false;
                    }
                    else if (roleID == (int)Role.DivisionHead)
                    {
                        ((DropDownList)row.FindControl("DropDownListEditUserDepartmentID")).Enabled = false;
                    }

                }
            }
        }

        protected void GridViewUser_DataBound(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridViewUser.Rows)
            {
                if (row.FindControl("DropDownListEditUserBusinessUnit") != null)
                {
                    ComboBusinessComponent comboBusinessComponent = new ComboBusinessComponent(Thread.CurrentPrincipal);
                    ComboEntityCollection comboEntityCollection = comboBusinessComponent.GetComboData(ReferenceTable.BusinessUnit, null);
                    DropDownList businessUnitUnitDropDown = (DropDownList)row.FindControl("DropDownListEditUserBusinessUnit");
                    businessUnitUnitDropDown.DataValueField = Combo.ID;
                    businessUnitUnitDropDown.DataTextField = Combo.Description;
                    businessUnitUnitDropDown.DataSource = comboEntityCollection;
                    businessUnitUnitDropDown.DataBind();
                    HiddenField hiddenFieldBusinessUnitID = (HiddenField)row.FindControl("HiddenFieldBusinessUnitID");
                    if (hiddenFieldBusinessUnitID.Value != null)
                    {
                        businessUnitUnitDropDown.SelectedValue = hiddenFieldBusinessUnitID.Value;
                    }
                    else
                    {
                        businessUnitUnitDropDown.SelectedValue = "0";
                    }


                    int businessUnitID = Convert.ToInt32(businessUnitUnitDropDown.SelectedValue.ToString());
                    comboEntityCollection = comboBusinessComponent.GetComboDataByForeignnKey(ReferenceTable.DivisionUnit, businessUnitID, null);
                    DropDownList divisionUnitDropDown = (DropDownList)row.FindControl("DropDownListEditUserDivisionUnitID");
                    divisionUnitDropDown.DataValueField = Combo.ID;
                    divisionUnitDropDown.DataTextField = Combo.Description;
                    divisionUnitDropDown.DataSource = comboEntityCollection;
                    divisionUnitDropDown.DataBind();
                    HiddenField hiddenFieldDivisionUnitID = (HiddenField)row.FindControl("HiddenFieldDivisionUnitID");
                    if (hiddenFieldDivisionUnitID.Value != null)
                    {
                        divisionUnitDropDown.SelectedValue = hiddenFieldDivisionUnitID.Value;
                    }
                    else
                    {
                        divisionUnitDropDown.SelectedValue = "0";
                    }

                    comboEntityCollection = comboBusinessComponent.GetComboDataByForeignnKey(ReferenceTable.Department, int.Parse(divisionUnitDropDown.SelectedValue.ToString()), null);
                    DropDownList departmentDropDown = (DropDownList)row.FindControl("DropDownListEditUserDepartmentID");
                    departmentDropDown.DataValueField = Combo.ID;
                    departmentDropDown.DataTextField = Combo.Description;
                    departmentDropDown.DataSource = comboEntityCollection;
                    departmentDropDown.DataBind();
                    HiddenField hiddenFieldDepartmentID = (HiddenField)row.FindControl("HiddenFieldDepartmentID");
                    if (hiddenFieldDepartmentID.Value != null)
                    {
                        departmentDropDown.SelectedValue = hiddenFieldDepartmentID.Value;
                    }
                    else
                    {
                        departmentDropDown.SelectedValue = "0";
                    }

                }
            }
        }

        protected void DropDownListEditUserBusinessUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridViewUser.Rows)
            {
                if (row.FindControl("DropDownListEditUserBusinessUnit") != null)
                {
                    int businessUnitID = Convert.ToInt32(((DropDownList)row.FindControl("DropDownListEditUserBusinessUnit")).SelectedValue);
                    ComboBusinessComponent comboBusinessComponent = new ComboBusinessComponent(Thread.CurrentPrincipal);
                    ComboEntityCollection comboEntityCollection = comboBusinessComponent.GetComboDataByForeignnKey(ReferenceTable.DivisionUnit, businessUnitID, true);
                    DropDownList divisionUnitDropDown = (DropDownList)row.FindControl("DropDownListEditUserDivisionUnitID");
                    divisionUnitDropDown.DataValueField = Combo.ID;
                    divisionUnitDropDown.DataTextField = Combo.Description;
                    divisionUnitDropDown.DataSource = comboEntityCollection;
                    divisionUnitDropDown.DataBind();
                    comboEntityCollection = new ComboEntityCollection();
                    DropDownList departmentDropDown = (DropDownList)row.FindControl("DropDownListEditUserDepartmentID");
                    departmentDropDown.DataValueField = Combo.ID;
                    departmentDropDown.DataTextField = Combo.Description;
                    departmentDropDown.DataSource = comboEntityCollection;
                    departmentDropDown.DataBind();
                }
            }
        }

        protected void DropDownListEditUserDivisionUnitID_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridViewUser.Rows)
            {
                if (row.FindControl("DropDownListEditUserDivisionUnitID") != null)
                {
                    int divisionUnitID = Convert.ToInt32(((DropDownList)row.FindControl("DropDownListEditUserDivisionUnitID")).SelectedValue);
                    ComboBusinessComponent comboBusinessComponent = new ComboBusinessComponent(Thread.CurrentPrincipal);
                    ComboEntityCollection comboEntityCollection = comboBusinessComponent.GetComboDataByForeignnKey(ReferenceTable.Department, divisionUnitID, true);
                    DropDownList departmentDropDown = (DropDownList)row.FindControl("DropDownListEditUserDepartmentID");
                    departmentDropDown.DataValueField = Combo.ID;
                    departmentDropDown.DataTextField = Combo.Description;
                    departmentDropDown.DataSource = comboEntityCollection;
                    departmentDropDown.DataBind();
                }
            }
        }

        protected void LinkButtonResetCancel_Click(object sender, EventArgs e)
        {
            TextBoxResetUserName.Text = string.Empty;
            TextBoxResetPassword.Text = string.Empty;
            TextBoxResetConfirmPassword.Text = string.Empty;
        }

        protected void LinkButtonResetUserPasswd_Click(object sender, EventArgs e)
        {
            if (ValidResetPasswordFields())
            {
                UserBusinessComponent userBusinesscomponent = new UserBusinessComponent(Thread.CurrentPrincipal);
                UserEntity userEntity = userBusinesscomponent.GetByUserName(TextBoxResetUserName.Text);
                if (userEntity != null)
                {
                    userEntity = new UserEntity();
                    userEntity.UserName = TextBoxResetUserName.Text;
                    userEntity.Password = TextBoxResetPassword.Text;
                    userBusinesscomponent.ResetPassword(userEntity);
                    LabelMessageReset.Text = "The password  for user " + userEntity.UserName +" was successfully updated.";
                    LabelMessageReset.ForeColor = Color.Blue;
                }
                else
                {
                    LabelMessageReset.Text = "The User Name you entered does not exist.";
                }
            }
        }

        bool ValidResetPasswordFields()
        {
            bool valid = true;
            LabelMessage.Text = string.Empty;
            if (string.IsNullOrEmpty(TextBoxResetUserName.Text))
            {
                LabelErrorResetUserName.Visible = true;
                valid = false;
            }
            if (string.IsNullOrEmpty(TextBoxResetPassword.Text))
            {
                LabelErrorResetPassword.Visible = true;
                valid = false;
            }
            else if (string.IsNullOrEmpty(TextBoxResetConfirmPassword.Text))
            {
                LabelErrorResetConfirmPasswd.Visible = true;
                valid = false;
            }
            else
            {
                if (TextBoxResetPassword.Text.CompareTo(TextBoxResetConfirmPassword.Text) != 0)
                {
                    LabelErrorResetConfirmPasswd.Visible = true;
                    LabelErrorResetPassword.Visible = true;
                    valid = false;
                    LabelMessageReset.Text = "Your Password does not match. Please retype your password.";
                    LabelMessage.ForeColor = Color.Red;
                }
            }

            return valid;
        }

        protected void LinkButtonResetPassword_Click(object sender, EventArgs e)
        {
            PanelResetPassword.Visible = true;
            PanelCreateUser.Visible = false;
            PanelUpdateUser.Visible = false;
        }

    }
}