using System;
using System.Data;
using System.Security.Principal;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using FijiITC.SolutionInfrastructure.Business;
using FijiITC.SolutionInfrastructure;
using FijiITC.SolutionInfrastructure.Exceptions;
using FijiITC.SolutionInfrastructure.DataServices;
using FijiITC.SolutionInfrastructure.DataStructures;
using TimeSoft.DataStructures;
using TimeSoft.DataAdapter.TimeSoftData;
using TimeSoft.DataStructures.Enumerator;

namespace TimeSoft.BusinessComponents
{
    public partial class ComboBusinessComponent : BusinessComponentBase
    {
         #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="principal">The <see cref="IPrincipal"/> of the user.</param>
        public ComboBusinessComponent(IPrincipal principal)
            : base(principal)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="principal">The <see cref="IPrincipal"/> of the user.</param>
        /// <param name="db">The existing database connection to use.</param> 
        /// <param name="txn">The transaction to participate in.  Null if a transaction is not required.</param>
        public ComboBusinessComponent(IPrincipal principal, Database db, DbTransaction txn)
            : base(principal, db, txn)
        {
        }
        #endregion


        public ComboEntityCollection GetComboData(string referenceTable,System.Nullable<bool> active)
        {
            ComboEntityCollection comboEntityCollection = new ComboEntityCollection();
            ComboEntity comboEntity = new ComboEntity();
            comboEntity.ComboID = 0;
            comboEntity.ComboDesc = string.Empty;
            comboEntityCollection.Add(comboEntity);


            if (referenceTable == ReferenceTable.Active)
            {
                comboEntity = new ComboEntity();
                comboEntity.ComboID = 1;
                comboEntity.ComboDesc = "True";                
                comboEntityCollection.Add(comboEntity);
                comboEntity = new ComboEntity();
                comboEntity.ComboID = 0;
                comboEntity.ComboDesc = "False";              
                comboEntityCollection.Add(comboEntity);
            }

            else if (referenceTable == ReferenceTable.BusinessUnit)
            {
                BusinessUnitEntityCollection businessUnitEntityCollection = new BusinessUnitEntityCollection();
                BusinessUnitAdapter adapter = new BusinessUnitAdapter(this.Db, this.Txn);
                businessUnitEntityCollection = adapter.FindAll(active);
                for (int i = 0; i < businessUnitEntityCollection.Count; i++)
                {
                    comboEntity = new ComboEntity();
                    comboEntity.ComboID = businessUnitEntityCollection[i].BusinessUnitID;
                    comboEntity.ComboDesc = businessUnitEntityCollection[i].BusinessUnitDesc;
                    comboEntityCollection.Add(comboEntity);
                }
            }
            else if (referenceTable == ReferenceTable.DivisionUnit)
            {
                DivisionUnitEntityCollection divisionUnitEntityCollection = new DivisionUnitEntityCollection();
                DivisionUnitAdapter adapter = new DivisionUnitAdapter(this.Db, this.Txn);
                divisionUnitEntityCollection = adapter.FindAll(active);
                for (int i = 0; i < divisionUnitEntityCollection.Count; i++)
                {
                    comboEntity = new ComboEntity();
                    comboEntity.ComboID = divisionUnitEntityCollection[i].DivisionUnitID;
                    comboEntity.ComboDesc = divisionUnitEntityCollection[i].DivisionUnitDesc;
                    comboEntityCollection.Add(comboEntity);
                }
            }
            else if (referenceTable == ReferenceTable.StaffLocation)
            {
                StaffLocationEntityCollection staffLocationEntityCollection = new StaffLocationEntityCollection();
                StaffLocationAdapter adapter = new StaffLocationAdapter(this.Db, this.Txn);
                staffLocationEntityCollection = adapter.FindAll(active);
                for (int i = 0; i < staffLocationEntityCollection.Count; i++)
                {
                    comboEntity = new ComboEntity();
                    comboEntity.ComboID = staffLocationEntityCollection[i].StaffLocationID;
                    comboEntity.ComboDesc = staffLocationEntityCollection[i].StaffLocationDesc;
                    comboEntityCollection.Add(comboEntity);
                }
            }
            else if (referenceTable == ReferenceTable.Location)
            {
                StaffLocationEntityCollection staffLocationEntityCollection = new StaffLocationEntityCollection();
                CustomDataAdapter adapter = new CustomDataAdapter(this.Db, this.Txn);
                comboEntityCollection = adapter.Location_FindAll();
               
            }
            else if (referenceTable == ReferenceTable.Role)
            {
                RoleEntityCollection roleEntityCollection = new RoleEntityCollection();
                RoleAdapter adapter = new RoleAdapter(this.Db, this.Txn);
                roleEntityCollection = adapter.FindAll();
                for (int i = 0; i < roleEntityCollection.Count; i++)
                {
                    comboEntity = new ComboEntity();
                    comboEntity.ComboID = roleEntityCollection[i].RoleID;
                    comboEntity.ComboDesc = roleEntityCollection[i].RoleDesc;
                    comboEntityCollection.Add(comboEntity);
                }

            }
         
            return comboEntityCollection;
        }


        public ComboEntityCollection GetComboDataByForeignnKey(string referenceTable, int foreignkeyID, Nullable<bool> active)
        {
            ComboEntityCollection comboEntityCollection = new ComboEntityCollection();
            ComboEntity comboEntity = new ComboEntity();
            comboEntity.ComboID = 0;
            comboEntity.ComboDesc = string.Empty;
            comboEntityCollection.Add(comboEntity);


           if (referenceTable == ReferenceTable.DivisionUnit)
            {
                DivisionUnitEntityCollection divisionUnitEntityCollection = new DivisionUnitEntityCollection();
                DivisionUnitAdapter adapter = new DivisionUnitAdapter(this.Db, this.Txn);
                divisionUnitEntityCollection = adapter.FindByBusinessUnitID(foreignkeyID, active);
                for (int i = 0; i < divisionUnitEntityCollection.Count; i++)
                {
                    comboEntity = new ComboEntity();
                    comboEntity.ComboID = divisionUnitEntityCollection[i].DivisionUnitID;
                    comboEntity.ComboDesc = divisionUnitEntityCollection[i].DivisionUnitDesc;
                    comboEntityCollection.Add(comboEntity);
                }
            }

           if (referenceTable == ReferenceTable.Department)
           {
               DepartmentEntityCollection departmentEntityCollection = new DepartmentEntityCollection();
               DepartmentAdapter adapter = new DepartmentAdapter(this.Db, this.Txn);
               departmentEntityCollection = adapter.FindByDivisionUnitID(foreignkeyID, active);
               for (int i = 0; i < departmentEntityCollection.Count; i++)
               {
                   comboEntity = new ComboEntity();
                   comboEntity.ComboID = departmentEntityCollection[i].DepartmentID;
                   comboEntity.ComboDesc = departmentEntityCollection[i].DepartmentDesc;
                   comboEntityCollection.Add(comboEntity);
               }
           }
           
         
            return comboEntityCollection;
        } 
    }
}
