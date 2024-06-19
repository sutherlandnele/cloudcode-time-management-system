
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
	public partial class DivisionUnitBusinessComponent : BusinessComponentBase
	{  
		#region Constructors
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="principal">The <see cref="IPrincipal"/> of the user.</param>
		public DivisionUnitBusinessComponent(IPrincipal principal) : base(principal)
		{ 
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="principal">The <see cref="IPrincipal"/> of the user.</param>
		/// <param name="db">The existing database connection to use.</param> 
		/// <param name="txn">The transaction to participate in.  Null if a transaction is not required.</param>
        public DivisionUnitBusinessComponent(IPrincipal principal, Database db, DbTransaction txn)
            : base(principal, db, txn)
		{ 
		}
		#endregion

		#region Generated Methods
		
	
		public DivisionUnitEntity Get(int divisionUnitID)
		{
            DivisionUnitAdapter adapter = new DivisionUnitAdapter(this.Db, this.Txn);
			return adapter.Get(divisionUnitID);
		}

        public DivisionUnitEntityCollection FindByBusinessUnitID(int businessUnitID, Nullable<bool> active)
        {
            DivisionUnitAdapter adapter = new DivisionUnitAdapter(this.Db, this.Txn);
            return adapter.FindByBusinessUnitID(businessUnitID,active);
        }

		public DivisionUnitEntityCollection FindAll(Nullable<bool> active)
		{
            DivisionUnitAdapter adapter = new DivisionUnitAdapter(this.Db, this.Txn);
			return adapter.FindAll(active);
		}

        public int Insert(DivisionUnitEntity divisionUnitEntity)
		{
            DivisionUnitAdapter adapter = new DivisionUnitAdapter(this.Db, this.Txn);
            adapter.Insert(divisionUnitEntity, this.CurrentUserName(), DateTime.Now);
            divisionUnitEntity.AcceptChanges();
            return divisionUnitEntity.DivisionUnitID;
		}

        public DivisionUnitEntity Update(DivisionUnitEntity divisionUnitEntity)
		{
            DivisionUnitAdapter adapter = new DivisionUnitAdapter(this.Db, this.Txn);
            adapter.Update(divisionUnitEntity, base.CurrentUserName(), DateTime.Now);
            divisionUnitEntity.AcceptChanges();
            return divisionUnitEntity;
		}

        public void Delete(DivisionUnitEntity divisionUnitEntity)
		{
            DivisionUnitAdapter adapter = new DivisionUnitAdapter(this.Db, this.Txn);
            adapter.Delete(divisionUnitEntity, this.CurrentUserName(), DateTime.Now);
		}
	 	
		#endregion

	}
}

