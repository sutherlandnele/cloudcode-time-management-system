using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TimeSoft.BusinessComponents;
using TimeSoft.DataStructures;
using System.Threading;
using System.Collections;
using TimeSoft.DataStructures.Enumerator;
using Infragistics.WebUI.WebDataInput;
using System.Drawing;

namespace TimeSoftWebApp
{
    public partial class ReferenceTables : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HttpContext.Current.User.Identity.Name))
            {
                if (!IsPostBack)
                {
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

                    LoadGridBusinessUnit();
                    UltraWebTabRefTables.SelectedTab = 0;
                    LoadCombos();
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
            LabelMessageBusinessUnit.Text = string.Empty;
            LabelMessageDivisionUnit.Text = string.Empty;
            LabelMessageDepartment.Text = string.Empty;
            LabelMessageStaffLocation.Text = string.Empty;
            LabelMessageEmployee.Text = string.Empty;
        }

        protected void UltraWebTabRefTables_TabClick(object sender, Infragistics.WebUI.UltraWebTab.WebTabEvent e)
        {
            BusinessUnitEntityCollection businessUnitEntityCollection = new BusinessUnitEntityCollection();
            GridViewBusinessUnit.DataSource = businessUnitEntityCollection;
            GridViewBusinessUnit.DataBind();
            //DivisionUnitEntityCollection divisionUnitEntityCollection = new DivisionUnitEntityCollection();
            //GridViewDivisionUnit.DataSource = divisionUnitEntityCollection;
            //GridViewDivisionUnit.DataBind();
            //DepartmentEntityCollection departmentEntityCollection = new DepartmentEntityCollection();
            //GridViewDepartment.DataSource = departmentEntityCollection;
            //GridViewDepartment.DataBind();
            //StaffLocationEntityCollection staffLocationEntityCollection = new StaffLocationEntityCollection();
            //GridViewStaffLocation.DataSource = staffLocationEntityCollection;
            //GridViewStaffLocation.DataBind();
           
            if (UltraWebTabRefTables.SelectedTab == 0)
            {
                LoadGridBusinessUnit();               
            }
            else if (UltraWebTabRefTables.SelectedTab == 1)
            {
                LoadCombos();          
                LoadGridDivisionUnit();                
            }
            else if (UltraWebTabRefTables.SelectedTab == 2)
            {
                LoadCombos();          
                LoadGridDepartment();
            }
            else if (UltraWebTabRefTables.SelectedTab == 3)
            {
                LoadGridStaffLocation();
            }
            else if (UltraWebTabRefTables.SelectedTab == 4)
            {
                DropDownListCriteria.Items.Clear();
                ListItem item = new ListItem("CardNo", SearchCriteria.CardNo);
                DropDownListCriteria.Items.Add(item);
                item = new ListItem("Employee No", SearchCriteria.EmployeeNo);
                DropDownListCriteria.Items.Add(item);
                item = new ListItem("First Name", SearchCriteria.FName);
                DropDownListCriteria.Items.Add(item);
                item = new ListItem("Last Name", SearchCriteria.LName);
                DropDownListCriteria.Items.Add(item);
                item = new ListItem("Active", SearchCriteria.Active);
                DropDownListCriteria.Items.Add(item);             
                DropDownListCriteria.DataBind();
                TextBoxSearchWord.Text = string.Empty;
            }
            CheckBoxActive.Visible = false;
            TextBoxSearchWord.Visible = true;
            EmployeeEntityCollection employeeEntityCollection = new EmployeeEntityCollection();
            GridViewEmployee.DataSource = employeeEntityCollection;
            GridViewEmployee.DataBind();
            Session["Col"] = employeeEntityCollection;
            Session["SearchField"] = string.Empty;
            Session["SearchWord"] = string.Empty;
            GridViewEmployee.EditIndex = -1;
        }

        void LoadCombos()
        {
            ComboBusinessComponent comboBusinessComponent = new ComboBusinessComponent(Thread.CurrentPrincipal);
            ComboEntityCollection comboEntityCollection = new ComboEntityCollection();
            comboEntityCollection = comboBusinessComponent.GetComboData(ReferenceTable.BusinessUnit, true);
            DropDownListBusinessUnit.DataSource = comboEntityCollection;          
            DropDownListBusinessUnit.DataTextField = Combo.Description;
            DropDownListBusinessUnit.DataValueField = Combo.ID;
            DropDownListBusinessUnit.DataBind();

            comboEntityCollection = new ComboEntityCollection();
            comboEntityCollection = comboBusinessComponent.GetComboData(ReferenceTable.BusinessUnit, true);
            DropDownListDepartmentBusinessUnit.DataSource = comboEntityCollection;
            DropDownListDepartmentBusinessUnit.DataTextField = Combo.Description;
            DropDownListDepartmentBusinessUnit.DataValueField = Combo.ID;
            DropDownListDepartmentBusinessUnit.DataBind();          
            
        }


        #region BusinessUnit
        protected void GridViewBusinessUnit_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewBusinessUnit.EditIndex = e.NewEditIndex;
            LoadGridBusinessUnit();
            GridViewBusinessUnit.Rows[e.NewEditIndex].BackColor = Color.Yellow;
        }

        protected void GridViewBusinessUnit_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = int.Parse(GridViewBusinessUnit.DataKeys[e.RowIndex].Value.ToString());
            ICollection collection = e.NewValues.Values;
            BusinessUnitEntity businessUnitEntity = new BusinessUnitEntity();
            businessUnitEntity.BusinessUnitID = id;

            businessUnitEntity.BusinessUnitDesc = (((TextBox)GridViewBusinessUnit.Rows[e.RowIndex].FindControl("TextBoxBusBusinessUnitDescEdit")).Text);
            businessUnitEntity.Active = (((CheckBox)GridViewBusinessUnit.Rows[e.RowIndex].FindControl("CheckBoxBusActiveEdit")).Checked);
            if (string.IsNullOrEmpty(businessUnitEntity.BusinessUnitDesc))
            {
                LabelMessageBusinessUnit.Text = "Please enter Business Unit.";
                return;
            }

            BusinessUnitBusinessComponent businessUnitBusinessComponent = new BusinessUnitBusinessComponent(Thread.CurrentPrincipal);
            businessUnitBusinessComponent.Update(businessUnitEntity);
            GridViewBusinessUnit.EditIndex = -1;
            LoadGridBusinessUnit();
            LabelMessageBusinessUnit.Text = "Row with id: " + id + " sucessfully updated.";

        }

        protected void GridViewBusinessUnit_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewBusinessUnit.EditIndex = -1;
            LoadGridBusinessUnit();
            LabelMessageBusinessUnit.Text = "Row Editing Canelled.";
        }

        void LoadGridBusinessUnit()
        {
            BusinessUnitBusinessComponent businessUnitBusinessComponent = new BusinessUnitBusinessComponent(Thread.CurrentPrincipal);
            BusinessUnitEntityCollection businessUnitEntityCollection = businessUnitBusinessComponent.FindAll(null);
            GridViewBusinessUnit.DataSource = businessUnitEntityCollection;
            GridViewBusinessUnit.DataBind();
        }

        protected void GridViewBusinessUnit_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                BusinessUnitBusinessComponent businessUnitBusinessComponent = new BusinessUnitBusinessComponent(Thread.CurrentPrincipal);
                int id = int.Parse(GridViewBusinessUnit.DataKeys[e.RowIndex].Value.ToString());
                BusinessUnitEntity businessUnitEntity = new BusinessUnitEntity();
                businessUnitEntity.BusinessUnitID = id;
                businessUnitBusinessComponent.Delete(businessUnitEntity);
                GridViewBusinessUnit.EditIndex = -1;
                LoadGridBusinessUnit();
                LabelMessageBusinessUnit.Text = "Row with id: " + id + " sucessfully deleted.";
            }
            catch (Exception ex)
            {
                LabelMessageBusinessUnit.Text = ex.Message;
            }

        }

        protected void LinkButtonInsertBusinessUnit_Click(object sender, EventArgs e)
        {
            try
            {
                BusinessUnitEntity businessUnitEntity = new BusinessUnitEntity();
                businessUnitEntity.BusinessUnitDesc = TextBoxBusinessUnitDesc.Text;
                businessUnitEntity.Active = true;
                BusinessUnitBusinessComponent businessUnitBusinessComponent = new BusinessUnitBusinessComponent(Thread.CurrentPrincipal);
                businessUnitBusinessComponent.Insert(businessUnitEntity);
                LoadGridBusinessUnit();
                LabelMessageBusinessUnit.Text = "Row sucessfully inserted.";
                TextBoxBusinessUnitDesc.Text = string.Empty;
            }
            catch (Exception ex)
            {
                LabelMessageBusinessUnit.Text = ex.Message;
            }
        }

        #endregion

        #region DivisionUnit

        protected void InsertDivision_Click(object sender, EventArgs e)
        {
            try
            {
                DivisionUnitEntity divisionUnitEntity = new DivisionUnitEntity();
                divisionUnitEntity.BusinessUnitID = int.Parse(DropDownListBusinessUnit.SelectedValue.ToString());
                divisionUnitEntity.DivisionUnitDesc = TextBoxDivisionDesc.Text;
                divisionUnitEntity.Active = true;
                DivisionUnitBusinessComponent divisionUnitBusinessComponent = new DivisionUnitBusinessComponent(Thread.CurrentPrincipal);
                divisionUnitBusinessComponent.Insert(divisionUnitEntity);
                LoadGridDivisionUnit();
                LabelMessageDivisionUnit.Text = "Row sucessfully inserted.";
                TextBoxDivisionDesc.Text = string.Empty;
            }
            catch (Exception ex)
            {
                LabelMessageDivisionUnit.Text = ex.Message;
            }
        }

        

        protected void GridViewDivisionUnit_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = int.Parse(GridViewDivisionUnit.DataKeys[e.RowIndex].Value.ToString());
            ICollection collection = e.NewValues.Values;          
            DivisionUnitEntity divisionUnitEntity = new DivisionUnitEntity();
            divisionUnitEntity.DivisionUnitID = id;

            if ((((DropDownList)GridViewDivisionUnit.Rows[e.RowIndex].FindControl("DropDownListDivBusinessUnitEdit")).SelectedIndex) == -1)
            {
                LabelMessageDivisionUnit.Text = "Please select Business Unit.";
                return;
            }
            else if ((((DropDownList)GridViewDivisionUnit.Rows[e.RowIndex].FindControl("DropDownListDivBusinessUnitEdit")).SelectedValue) == "0")
            {
                LabelMessageDivisionUnit.Text = "Please select Business Unit.";
                return;
            }
            else
            {
                divisionUnitEntity.BusinessUnitID = int.Parse((((DropDownList)GridViewDivisionUnit.Rows[e.RowIndex].FindControl("DropDownListDivBusinessUnitEdit")).SelectedValue));
            }

            divisionUnitEntity.Active = (((CheckBox)GridViewDivisionUnit.Rows[e.RowIndex].FindControl("CheckBoxDivActiveEdit")).Checked);
            divisionUnitEntity.DivisionUnitDesc = (((TextBox)GridViewDivisionUnit.Rows[e.RowIndex].FindControl("TextBoxDivisionUnitDescEdit")).Text);
            if (string.IsNullOrEmpty(divisionUnitEntity.DivisionUnitDesc))
            {
                LabelMessageDivisionUnit.Text = "Please enter Division Unit.";
                return;
            }          
            DivisionUnitBusinessComponent divisionUnitBusinessComponent = new DivisionUnitBusinessComponent(Thread.CurrentPrincipal);
            divisionUnitBusinessComponent.Update(divisionUnitEntity);
            GridViewDivisionUnit.EditIndex = -1;
            LoadGridDivisionUnit();
            LabelMessageDivisionUnit.Text = "Row with id: " + id + " sucessfully updated.";
        }

        protected void GridViewDivisionUnit_RowEditing(object sender, GridViewEditEventArgs e)
        {            
            GridViewDivisionUnit.EditIndex = e.NewEditIndex;                 
            LoadGridDivisionUnit();
            GridViewDivisionUnit.Rows[e.NewEditIndex].BackColor = Color.Yellow;

        }

        protected void GridViewDivisionUnit_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int id = int.Parse(GridViewDivisionUnit.DataKeys[e.RowIndex].Value.ToString());
                DivisionUnitEntity divisionUnitEntity = new DivisionUnitEntity();
                divisionUnitEntity.DivisionUnitID = id;
                DivisionUnitBusinessComponent divisionUnitBusinessComponent = new DivisionUnitBusinessComponent(Thread.CurrentPrincipal);
                divisionUnitBusinessComponent.Delete(divisionUnitEntity);
                GridViewDivisionUnit.EditIndex = -1;
                LoadGridDivisionUnit();
                LabelMessageDivisionUnit.Text = "Row with id: " + id + " sucessfully deleted.";
            }
            catch(Exception ex)
            {
                LabelMessageDivisionUnit.Text = ex.Message;
            }


        }

        protected void GridViewDivisionUnit_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewDivisionUnit.EditIndex = -1;
            LoadGridDivisionUnit();
            LabelMessageDivisionUnit.Text = "Row Editing Canelled.";
        }
        void LoadGridDivisionUnit()
        {
            DivisionUnitBusinessComponent divisionUnitBusinessComponent = new DivisionUnitBusinessComponent(Thread.CurrentPrincipal);
            DivisionUnitEntityCollection divisionUnitEntityCollection = divisionUnitBusinessComponent.FindAll(null);
            GridViewDivisionUnit.DataSource = divisionUnitEntityCollection;
            GridViewDivisionUnit.DataBind();
        }      

        #endregion

        #region Department

        protected void InsertDepartment_Click(object sender, EventArgs e)
        {
            try
            {

                if (DropDownListDepartmentDivisionUnit.SelectedIndex != -1)
                {
                    if (DropDownListDepartmentDivisionUnit.SelectedValue != "0")
                    {
                        DepartmentEntity departmentEntity = new DepartmentEntity();
                        departmentEntity.DivisionUnitID = int.Parse(DropDownListDepartmentDivisionUnit.SelectedValue.ToString());
                        departmentEntity.DepartmentDesc = TextBoxDepartmentDesc.Text;
                        departmentEntity.Active = true;
                        DepartmentBusinessComponent departmentBusinessComponent = new DepartmentBusinessComponent(Thread.CurrentPrincipal);
                        departmentBusinessComponent.Insert(departmentEntity);
                        LoadGridDepartment();
                        LabelMessageDepartment.Text = "Row sucessfully inserted.";
                        TextBoxDepartmentDesc.Text = string.Empty;
                    }
                    else
                    {
                        LabelMessageDepartment.Text = "Please select Division Unit.";
                    }
                }
                else
                {
                    LabelMessageDepartment.Text = "Please select Division Unit.";
                }
            }
            catch (Exception ex)
            {
                LabelMessageDepartment.Text = ex.Message;
            }
        }

        protected void GridViewDepartment_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewDepartment.EditIndex = e.NewEditIndex;
            GridViewRow row = GridViewDepartment.Rows[GridViewDepartment.EditIndex];
            LoadGridDepartment();
            GridViewDepartment.Rows[e.NewEditIndex].BackColor = Color.Yellow;
        }

        protected void GridViewDepartment_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = int.Parse(GridViewDepartment.DataKeys[e.RowIndex].Value.ToString());
            ICollection collection = e.NewValues.Values;
            DepartmentEntity departmentEntity = new DepartmentEntity();
            departmentEntity.DepartmentID = id;
            if ((((DropDownList)GridViewDepartment.Rows[e.RowIndex].FindControl("DropDownListDepDivisionUnitEdit")).SelectedIndex) == -1)
            {
                LabelMessageDepartment.Text = "Please select Division Unit.";
                return;
            }
            else if ((((DropDownList)GridViewDepartment.Rows[e.RowIndex].FindControl("DropDownListDepDivisionUnitEdit")).SelectedValue) == "0")
            {
                LabelMessageDepartment.Text = "Please select Division Unit.";
                return;
            }
            else
            {
                departmentEntity.DivisionUnitID = int.Parse((((DropDownList)GridViewDepartment.Rows[e.RowIndex].FindControl("DropDownListDepDivisionUnitEdit")).SelectedValue));
            }

            departmentEntity.Active = (((CheckBox)GridViewDepartment.Rows[e.RowIndex].FindControl("CheckBoxDepActiveEdit")).Checked);
            departmentEntity.DepartmentDesc = (((TextBox)GridViewDepartment.Rows[e.RowIndex].FindControl("TextBoxDepartmentUnitEdit")).Text);
            if (string.IsNullOrEmpty(departmentEntity.DepartmentDesc))
            {
                LabelMessageDepartment.Text = "Please enter Department Unit.";
                return;
            }       
            DepartmentBusinessComponent departmentBusinessComponent = new DepartmentBusinessComponent(Thread.CurrentPrincipal);
            departmentBusinessComponent.Update(departmentEntity);
            GridViewDepartment.EditIndex = -1;
            LoadGridDepartment();
            LabelMessageDepartment.Text = "Row with id: " + id + " sucessfully updated.";
        }

        protected void GridViewDepartment_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewDepartment.EditIndex = -1;
            LoadGridDepartment();
            LabelMessageDepartment.Text = "Row Editing Canelled.";
        }

        protected void GridViewDepartment_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            try
            {
                int id = int.Parse(GridViewDepartment.DataKeys[e.RowIndex].Value.ToString());
                DepartmentEntity departmentEntity = new DepartmentEntity();
                departmentEntity.DepartmentID = id;
                DepartmentBusinessComponent departmentBusinessComponent = new DepartmentBusinessComponent(Thread.CurrentPrincipal);
                departmentBusinessComponent.Delete(departmentEntity);
                GridViewDepartment.EditIndex = -1;
                LoadGridDepartment();
                LabelMessageDepartment.Text = "Row with id: " + id + " sucessfully deleted.";
            }
            catch (Exception ex)
            {
                LabelMessageDepartment.Text = ex.Message;
            }
        }
        void LoadGridDepartment()
        {
            DepartmentBusinessComponent departmentBusinessComponent = new DepartmentBusinessComponent(Thread.CurrentPrincipal);
            DepartmentEntityCollection departmentEntityCollection = departmentBusinessComponent.FindAll(null);
            GridViewDepartment.DataSource = departmentEntityCollection;
           GridViewDepartment.DataBind();
        }       
              

        protected void DropDownListDepBusinessUnitEdit_SelectedIndexChanged(object sender, EventArgs e)
        { 
            foreach (GridViewRow row in GridViewDepartment.Rows)
            {
                if (row.FindControl("DropDownListDepBusinessUnitEdit") != null)
                {
                    int businessUnitID = Convert.ToInt32(((DropDownList)row.FindControl("DropDownListDepBusinessUnitEdit")).SelectedValue);
                    ComboBusinessComponent comboBusinessComponent = new ComboBusinessComponent(Thread.CurrentPrincipal);
                    ComboEntityCollection comboEntityCollection = comboBusinessComponent.GetComboDataByForeignnKey(ReferenceTable.DivisionUnit, businessUnitID, true);
                    DropDownList divisionUnitDropDown = (DropDownList)row.FindControl("DropDownListDepDivisionUnitEdit");
                    divisionUnitDropDown.DataValueField = Combo.ID;
                    divisionUnitDropDown.DataTextField = Combo.Description;
                    divisionUnitDropDown.DataSource = comboEntityCollection;
                    divisionUnitDropDown.DataBind();                 
                }
            }
        }

        protected void DropDownListDepartmentBusinessUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListDepartmentBusinessUnit.SelectedIndex != -1)
            {
                int businessUnitID = int.Parse(DropDownListDepartmentBusinessUnit.SelectedValue.ToString());
                ComboEntityCollection comboEntityCollection = new ComboEntityCollection();
                ComboBusinessComponent comboBusinessComponent = new ComboBusinessComponent(Thread.CurrentPrincipal);
                comboEntityCollection = comboBusinessComponent.GetComboDataByForeignnKey(ReferenceTable.DivisionUnit, businessUnitID, true);
                DropDownListDepartmentDivisionUnit.DataSource = comboEntityCollection;
                DropDownListDepartmentDivisionUnit.DataTextField = Combo.Description;
                DropDownListDepartmentDivisionUnit.DataValueField = Combo.ID;
                DropDownListDepartmentDivisionUnit.DataBind();
            }
            else
            {
                ComboEntityCollection comboEntityCollection = new ComboEntityCollection();
                DropDownListDepartmentDivisionUnit.DataSource = comboEntityCollection;             
                DropDownListDepartmentDivisionUnit.DataBind();
            }
        }
       
        protected void GridViewDepartment_DataBound(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridViewDepartment.Rows)
            {
                if (row.FindControl("DropDownListDepBusinessUnitEdit") != null)
                {
                    int businessUnitID = Convert.ToInt32(((DropDownList)row.FindControl("DropDownListDepBusinessUnitEdit")).SelectedValue);
                    ComboBusinessComponent comboBusinessComponent = new ComboBusinessComponent(Thread.CurrentPrincipal);
                    ComboEntityCollection comboEntityCollection = comboBusinessComponent.GetComboDataByForeignnKey(ReferenceTable.DivisionUnit,businessUnitID, null);
                    DropDownList divisionUnitDropDown = (DropDownList)row.FindControl("DropDownListDepDivisionUnitEdit");
                    divisionUnitDropDown.DataValueField = Combo.ID;
                    divisionUnitDropDown.DataTextField = Combo.Description;
                    divisionUnitDropDown.DataSource = comboEntityCollection;
                    divisionUnitDropDown.DataBind();

                    HiddenField hiddenFieldDivisionUnitID = (HiddenField)row.FindControl("HiddenFieldDivisionUnitID");
                    divisionUnitDropDown.SelectedValue = hiddenFieldDivisionUnitID.Value;
                }
            }
        }

        #endregion

        #region StaffLocation

        protected void LinkButtonInsertStaffLocation_Click(object sender, EventArgs e)
        {
            try
            {
                StaffLocationEntity staffLocationEntity = new StaffLocationEntity();
                staffLocationEntity.StaffLocationDesc = TextBoxLocation.Text;
                staffLocationEntity.Active = true;
                StaffLocationBusinessComponent staffLocationBusinessComponent = new StaffLocationBusinessComponent(Thread.CurrentPrincipal);
                staffLocationBusinessComponent.Insert(staffLocationEntity);
                LoadGridStaffLocation();
                LabelMessageStaffLocation.Text = "Row sucessfully inserted.";
                TextBoxLocation.Text = string.Empty;
            }
            catch (Exception ex)
            {
                LabelMessageStaffLocation.Text = ex.Message;
            }
        }     

        protected void GridViewStaffLocation_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = int.Parse(GridViewStaffLocation.DataKeys[e.RowIndex].Value.ToString());
            ICollection collection = e.NewValues.Values;
            StaffLocationEntity staffLocationEntity = new StaffLocationEntity();
            staffLocationEntity.StaffLocationID = id;

            staffLocationEntity.StaffLocationDesc = (((TextBox)GridViewStaffLocation.Rows[e.RowIndex].FindControl("TextBoxStaffLocationDescEdit")).Text);
            staffLocationEntity.Active = (((CheckBox)GridViewStaffLocation.Rows[e.RowIndex].FindControl("CheckBoxStafflocActiveEdit")).Checked);
            if (string.IsNullOrEmpty(staffLocationEntity.StaffLocationDesc))
            {
                LabelMessageStaffLocation.Text = "Please enter Staff Location.";
                return;
            }           
            StaffLocationBusinessComponent staffLocationBusinessComponent = new StaffLocationBusinessComponent(Thread.CurrentPrincipal);
            staffLocationBusinessComponent.Update(staffLocationEntity);
            GridViewStaffLocation.EditIndex = -1;
            LoadGridStaffLocation();
            LabelMessageStaffLocation.Text = "Row with id: " + id + " sucessfully updated.";
        }

        protected void GridViewStaffLocation_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int id = int.Parse(GridViewStaffLocation.DataKeys[e.RowIndex].Value.ToString());
                StaffLocationEntity staffLocationEntity = new StaffLocationEntity();
                staffLocationEntity.StaffLocationID = id;
                StaffLocationBusinessComponent staffLocationBusinessComponent = new StaffLocationBusinessComponent(Thread.CurrentPrincipal);
                staffLocationBusinessComponent.Delete(staffLocationEntity);
                GridViewStaffLocation.EditIndex = -1;
                LoadGridStaffLocation();
                LabelMessageStaffLocation.Text = "Row with id: " + id + " sucessfully deleted.";
            }
            catch (Exception ex)
            {
                LabelMessageStaffLocation.Text = ex.Message;
            }
        }

        protected void GridViewStaffLocation_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewStaffLocation.EditIndex = e.NewEditIndex;
            LoadGridStaffLocation();
            GridViewStaffLocation.Rows[e.NewEditIndex].BackColor = Color.Yellow;
        }

        protected void GridViewStaffLocation_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewStaffLocation.EditIndex = -1;
            LoadGridStaffLocation();
            LabelMessageStaffLocation.Text = "Row Editing Canelled.";
        }
        void LoadGridStaffLocation()
        {
            StaffLocationBusinessComponent staffLocationBusinessComponent = new StaffLocationBusinessComponent(Thread.CurrentPrincipal);
            StaffLocationEntityCollection staffLocationEntityCollection = staffLocationBusinessComponent.FindAll(null);
            GridViewStaffLocation.DataSource = staffLocationEntityCollection;
            GridViewStaffLocation.DataBind();
           
        }      


        #endregion

        #region Employee
        protected void LinkButtonSearch_Click(object sender, EventArgs e)
        {           
            Session["SearchField"] = DropDownListCriteria.SelectedValue.ToString();
            string searchWord = string.Empty;
            if (TextBoxSearchWord.Visible == true)
            {
                Session["SearchWord"] = TextBoxSearchWord.Text;
                searchWord = TextBoxSearchWord.Text;
            }
            else
            {
                Session["SearchWord"] = CheckBoxActive.Checked;
                searchWord = CheckBoxActive.Checked.ToString();
            }
            GridViewEmployee.EditIndex = -1;
            LoadGridEmployee(DropDownListCriteria.SelectedValue.ToString(), searchWord);
           

        }
        protected void GridViewEmployee_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewEmployee.EditIndex = -1;
            LoadGridEmployee(string.Empty,string.Empty);
            LabelMessageEmployee.Text = "Row Editing Canelled.";
        }

        protected void GridViewEmployee_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewEmployee.EditIndex = e.NewEditIndex;
            LoadGridEmployee(string.Empty, string.Empty);
            GridViewEmployee.Rows[e.NewEditIndex].BackColor = Color.Yellow;
        }

        protected void GridViewEmployee_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = int.Parse(GridViewEmployee.DataKeys[e.RowIndex].Value.ToString());
            ICollection collection = e.NewValues.Values;           
            EmployeeEntity employeeEntity = new EmployeeEntity();
            employeeEntity.EmployeeID = id;

            if ((((DropDownList)GridViewEmployee.Rows[e.RowIndex].FindControl("DropDownListBusinessUnitEdit")).SelectedIndex) == -1)
            {
                employeeEntity.BusinessUnitID = null;
            }
            else if ((((DropDownList)GridViewEmployee.Rows[e.RowIndex].FindControl("DropDownListBusinessUnitEdit")).SelectedValue) == "0")
            {
                employeeEntity.BusinessUnitID = null;
            }
            else
            {
                employeeEntity.BusinessUnitID = int.Parse((((DropDownList)GridViewEmployee.Rows[e.RowIndex].FindControl("DropDownListBusinessUnitEdit")).SelectedValue));
            }
            if ((((DropDownList)GridViewEmployee.Rows[e.RowIndex].FindControl("DropDownListDivisionUnitEdit")).SelectedIndex) == -1)
            {
                employeeEntity.DivisionUnitID = null;
            }
            else if ((((DropDownList)GridViewEmployee.Rows[e.RowIndex].FindControl("DropDownListDivisionUnitEdit")).SelectedValue) == "0")
            {
                employeeEntity.DivisionUnitID = null;
            }
            else
            {
                employeeEntity.DivisionUnitID = int.Parse((((DropDownList)GridViewEmployee.Rows[e.RowIndex].FindControl("DropDownListDivisionUnitEdit")).SelectedValue));
                employeeEntity.BusinessUnitID = null;
            }
            if ((((DropDownList)GridViewEmployee.Rows[e.RowIndex].FindControl("DropDownListDepartmentEdit")).SelectedIndex) == -1)
            {
                employeeEntity.DepartmentID = null;
            }
            else if ((((DropDownList)GridViewEmployee.Rows[e.RowIndex].FindControl("DropDownListDepartmentEdit")).SelectedValue) == "0")
            {
                employeeEntity.DepartmentID = null;
            }
            else
            {
                employeeEntity.DepartmentID = int.Parse((((DropDownList)GridViewEmployee.Rows[e.RowIndex].FindControl("DropDownListDepartmentEdit")).SelectedValue));
                employeeEntity.BusinessUnitID = null;
                employeeEntity.DivisionUnitID = null;
            }
            employeeEntity.RateperHour = decimal.Parse((((WebNumericEdit)GridViewEmployee.Rows[e.RowIndex].FindControl("WebNumericRateperHourEdit")).Value.ToString()));
            if ((((DropDownList)GridViewEmployee.Rows[e.RowIndex].FindControl("DropDownListStaffLocationEdit")).SelectedIndex) == -1)
            {
                employeeEntity.StaffLocationID = null;
            }
            else if ((((DropDownList)GridViewEmployee.Rows[e.RowIndex].FindControl("DropDownListStaffLocationEdit")).SelectedValue) == "0")
            {
                employeeEntity.StaffLocationID = null;
            }
            else
            {
                employeeEntity.StaffLocationID = int.Parse((((DropDownList)GridViewEmployee.Rows[e.RowIndex].FindControl("DropDownListStaffLocationEdit")).SelectedValue));
            }
            employeeEntity.JobTitle = (((TextBox)GridViewEmployee.Rows[e.RowIndex].FindControl("TextBoxJobTitleEdit")).Text);
            employeeEntity.Active = (((CheckBox)GridViewEmployee.Rows[e.RowIndex].FindControl("CheckBoxEmployeeActiveEdit")).Checked);
            employeeEntity.EmployeeNo = (((TextBox)GridViewEmployee.Rows[e.RowIndex].FindControl("TextBoxEmployeeNoEdit")).Text);
            employeeEntity.FName = (((TextBox)GridViewEmployee.Rows[e.RowIndex].FindControl("TextBoxFNameEdit")).Text);
            employeeEntity.LName = (((TextBox)GridViewEmployee.Rows[e.RowIndex].FindControl("TextBoxLNameEdit")).Text);

            CustomBusinessComponent customBusinessComponent = new CustomBusinessComponent(Thread.CurrentPrincipal);
            customBusinessComponent.Employee_Update(employeeEntity);
            GridViewEmployee.EditIndex = -1;
            string searchWord = string.Empty;
            string searchField = string.Empty;
            if (Session["SearchField"] != null && Session["SearchWord"] != null)
            {
                searchField = Session["SearchField"].ToString();
                searchWord = Session["SearchWord"].ToString();
            }

            LoadGridEmployee(searchField, searchWord);
            LabelMessageEmployee.Text = "Row with id: " + id + " sucessfully updated.";
        }

        void LoadGridEmployee(string field, string searchWord)
        {
            EmployeeEntityCollection employeeEntityCollection = new EmployeeEntityCollection();
            if (string.IsNullOrEmpty(field) && string.IsNullOrEmpty(searchWord))
            {
                if (Session["Col"] != null)
                {
                    employeeEntityCollection = new EmployeeEntityCollection();
                    employeeEntityCollection = (EmployeeEntityCollection)Session["Col"];
                    GridViewEmployee.DataSource = employeeEntityCollection;
                    GridViewEmployee.DataBind();
                }             
            }
            else
            {
                CustomBusinessComponent customBusinessComponent = new CustomBusinessComponent(Thread.CurrentPrincipal);
                employeeEntityCollection = customBusinessComponent.Employee_FindAllBySearchWord(field, searchWord);
                GridViewEmployee.DataSource = employeeEntityCollection;
                GridViewEmployee.DataBind();
                Session["Col"] = employeeEntityCollection;
                if (employeeEntityCollection.Count == 0)
                {
                    LabelMessageEmployee.Text = "No Employee's record found.";
                }
                else
                {
                    LabelMessageEmployee.Text = employeeEntityCollection.Count + " Employee's record(s) found.";
                }
               
            }
        }

        protected void GridViewEmployee_DataBound(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridViewEmployee.Rows)
            {
                if (row.FindControl("DropDownListBusinessUnitEdit") != null)
                {                   
                    ComboBusinessComponent comboBusinessComponent = new ComboBusinessComponent(Thread.CurrentPrincipal);
                    ComboEntityCollection comboEntityCollection = comboBusinessComponent.GetComboData(ReferenceTable.BusinessUnit, null);
                    DropDownList businessUnitUnitDropDown = (DropDownList)row.FindControl("DropDownListBusinessUnitEdit");
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
                    DropDownList divisionUnitDropDown = (DropDownList)row.FindControl("DropDownListDivisionUnitEdit");
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

                    comboEntityCollection = comboBusinessComponent.GetComboDataByForeignnKey(ReferenceTable.Department,int.Parse(divisionUnitDropDown.SelectedValue.ToString()),null);
                    DropDownList departmentDropDown = (DropDownList)row.FindControl("DropDownListDepartmentEdit");
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

                    comboEntityCollection = comboBusinessComponent.GetComboData(ReferenceTable.StaffLocation, null);
                    DropDownList staffLocationDropDown = (DropDownList)row.FindControl("DropDownListStaffLocationEdit");
                    staffLocationDropDown.DataValueField = Combo.ID;
                    staffLocationDropDown.DataTextField = Combo.Description;
                    staffLocationDropDown.DataSource = comboEntityCollection;
                    staffLocationDropDown.DataBind();
                    HiddenField hiddenFieldStaffLocationID = (HiddenField)row.FindControl("HiddenFieldStaffLocationID");
                    if (hiddenFieldStaffLocationID.Value != null)
                    {
                        staffLocationDropDown.SelectedValue = hiddenFieldStaffLocationID.Value;
                    }
                    else
                    {
                        staffLocationDropDown.SelectedValue = "0";
                    }
                    WebNumericEdit ratePerHour = (WebNumericEdit)row.FindControl("WebNumericRateperHourEdit");                  
                    HiddenField hiddenFieldRateperHour = (HiddenField)row.FindControl("HiddenFieldRateperHour");
                    ratePerHour.Value = decimal.Parse(hiddenFieldRateperHour.Value.ToString()).ToString("F2");
                    ratePerHour.DataBind();
                    
                }
            }
        }               

        protected void DropDownListBusinessUnitEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridViewEmployee.Rows)
            {
                if (row.FindControl("DropDownListBusinessUnitEdit") != null)
                {
                    int businessUnitID = Convert.ToInt32(((DropDownList)row.FindControl("DropDownListBusinessUnitEdit")).SelectedValue);
                    ComboBusinessComponent comboBusinessComponent = new ComboBusinessComponent(Thread.CurrentPrincipal);
                    ComboEntityCollection comboEntityCollection = comboBusinessComponent.GetComboDataByForeignnKey(ReferenceTable.DivisionUnit, businessUnitID, true);
                    DropDownList divisionUnitDropDown = (DropDownList)row.FindControl("DropDownListDivisionUnitEdit");
                    divisionUnitDropDown.DataValueField = Combo.ID;
                    divisionUnitDropDown.DataTextField = Combo.Description;
                    divisionUnitDropDown.DataSource = comboEntityCollection;
                    divisionUnitDropDown.DataBind();
                    comboEntityCollection = new ComboEntityCollection();
                    DropDownList departmentDropDown = (DropDownList)row.FindControl("DropDownListDepartmentEdit");
                    departmentDropDown.DataValueField = Combo.ID;
                    departmentDropDown.DataTextField = Combo.Description;
                    departmentDropDown.DataSource = comboEntityCollection;
                    departmentDropDown.DataBind();
                }
            }
        }

        protected void DropDownListDivisionUnitEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridViewEmployee.Rows)
            {
                if (row.FindControl("DropDownListDivisionUnitEdit") != null)
                {
                    int divisionUnitID = Convert.ToInt32(((DropDownList)row.FindControl("DropDownListDivisionUnitEdit")).SelectedValue);
                    ComboBusinessComponent comboBusinessComponent = new ComboBusinessComponent(Thread.CurrentPrincipal);
                    ComboEntityCollection comboEntityCollection = comboBusinessComponent.GetComboDataByForeignnKey(ReferenceTable.Department, divisionUnitID, true);
                    DropDownList departmentDropDown = (DropDownList)row.FindControl("DropDownListDepartmentEdit");
                    departmentDropDown.DataValueField = Combo.ID;
                    departmentDropDown.DataTextField = Combo.Description;
                    departmentDropDown.DataSource = comboEntityCollection;
                    departmentDropDown.DataBind();
                }
            }
        }


        protected void DropDownListCriteria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListCriteria.SelectedIndex != -1)
            {
                TextBoxSearchWord.Visible = false;
                CheckBoxActive.Visible = false;
                if (DropDownListCriteria.SelectedValue == SearchCriteria.Active)
                {
                    CheckBoxActive.Visible = true;
                }
                else
                {
                    TextBoxSearchWord.Visible = true;
                }
            }
        }


        #endregion

       

    }
}