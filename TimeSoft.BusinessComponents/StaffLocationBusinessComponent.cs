
// $Workfile: $
// $JustDate: $
// $Revision: $
// $NoKeywords: $
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

namespace TimeSoft.BusinessComponents
{
    /// <summary>
    /// Generated <see cref=" RnDSoftBusinessComponentBase" /> Class 
    /// </summary>
    public partial class StaffLocationBusinessComponent : BusinessComponentBase
    {
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="principal">The <see cref="IPrincipal"/> of the user.</param>
        public StaffLocationBusinessComponent(IPrincipal principal)
            : base(principal)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="principal">The <see cref="IPrincipal"/> of the user.</param>
        /// <param name="db">The existing database connection to use.</param> 
        /// <param name="txn">The transaction to participate in.  Null if a transaction is not required.</param>
        public StaffLocationBusinessComponent(IPrincipal principal, Database db, DbTransaction txn)
            : base(principal, db, txn)
        {
        }
        #endregion

        #region Generated Methods


        public StaffLocationEntity Get(int staffLocationID)
        {
            StaffLocationAdapter adapter = new StaffLocationAdapter(this.Db, this.Txn);
            return adapter.Get(staffLocationID);
        }

        public StaffLocationEntityCollection FindAll(Nullable<bool> active)
        {
            StaffLocationAdapter adapter = new StaffLocationAdapter(this.Db, this.Txn);
            return adapter.FindAll(active);
        }

        public int Insert(StaffLocationEntity staffLocationEntity)
        {
            StaffLocationAdapter adapter = new StaffLocationAdapter(this.Db, this.Txn);
            adapter.Insert(staffLocationEntity, this.CurrentUserName(), DateTime.Now);
            staffLocationEntity.AcceptChanges();
            return staffLocationEntity.StaffLocationID;
        }

        public StaffLocationEntity Update(StaffLocationEntity staffLocationEntity)
        {
            StaffLocationAdapter adapter = new StaffLocationAdapter(this.Db, this.Txn);
            adapter.Update(staffLocationEntity, base.CurrentUserName(), DateTime.Now);
            staffLocationEntity.AcceptChanges();
            return staffLocationEntity;
        }

        public void Delete(StaffLocationEntity staffLocationEntity)
        {
            StaffLocationAdapter adapter = new StaffLocationAdapter(this.Db, this.Txn);
            adapter.Delete(staffLocationEntity, this.CurrentUserName(), DateTime.Now);
        }

        #endregion

    }
}
