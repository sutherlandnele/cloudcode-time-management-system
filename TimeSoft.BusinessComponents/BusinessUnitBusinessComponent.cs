
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
	public partial class BusinessUnitBusinessComponent : BusinessComponentBase
	{  
		#region Constructors
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="principal">The <see cref="IPrincipal"/> of the user.</param>
		public BusinessUnitBusinessComponent(IPrincipal principal) : base(principal)
		{ 
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="principal">The <see cref="IPrincipal"/> of the user.</param>
		/// <param name="db">The existing database connection to use.</param> 
		/// <param name="txn">The transaction to participate in.  Null if a transaction is not required.</param>
        public BusinessUnitBusinessComponent(IPrincipal principal, Database db, DbTransaction txn)
            : base(principal, db, txn)
		{ 
		}
		#endregion

		#region Generated Methods
		
	
		public BusinessUnitEntity Get(int businessUnitID)
		{
            BusinessUnitAdapter adapter = new BusinessUnitAdapter(this.Db, this.Txn);
			return adapter.Get(businessUnitID);
		}		

		public BusinessUnitEntityCollection FindAll(Nullable<bool> active)
		{
            BusinessUnitAdapter adapter = new BusinessUnitAdapter(this.Db, this.Txn);
			return adapter.FindAll(active);
		}

        public int Insert(BusinessUnitEntity businessUnitEntity)
		{
            BusinessUnitAdapter adapter = new BusinessUnitAdapter(this.Db, this.Txn);
            adapter.Insert(businessUnitEntity, this.CurrentUserName(), DateTime.Now);
            businessUnitEntity.AcceptChanges();
            return businessUnitEntity.BusinessUnitID;
		}

        public BusinessUnitEntity Update(BusinessUnitEntity businessUnitEntity)
		{
            BusinessUnitAdapter adapter = new BusinessUnitAdapter(this.Db, this.Txn);
            adapter.Update(businessUnitEntity, base.CurrentUserName(), DateTime.Now);
            businessUnitEntity.AcceptChanges();
            return businessUnitEntity;
		}

        public void Delete(BusinessUnitEntity businessUnitEntity)
		{
            BusinessUnitAdapter adapter = new BusinessUnitAdapter(this.Db, this.Txn);
            adapter.Delete(businessUnitEntity, this.CurrentUserName(), DateTime.Now);
		}

       
	 	
		#endregion

	}
}
