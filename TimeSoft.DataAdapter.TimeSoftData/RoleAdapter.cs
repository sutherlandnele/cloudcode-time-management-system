
using System; 
using System.Data;
using System.Data.Common;
using FijiITC.SolutionInfrastructure.DataServices;
using FijiITC.SolutionInfrastructure.DataStructures;
using TimeSoft.DataStructures;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace TimeSoft.DataAdapter.TimeSoftData
{
	/// <summary>
	/// Generated <see cref="DataAdapterBase" /> Class 
	/// </summary>
	public partial class RoleAdapter : DataAdapterBase
	{  
		#region Constructors
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="db">The existing database connection to use.</param> 
		/// <param name="txn">The transaction to participate in.  Null if a transaction is not required.</param>
        public RoleAdapter(Database db, DbTransaction txn)
            : base(db, txn)
		{ 
		}
		#endregion		
		
		public RoleEntityCollection FindAll()
		{
			DbCommand cmd = Db.GetStoredProcCommand("[dbo].prc_Role_FindAll");  		
			return ExecuteSPMultiple<RoleEntity, RoleEntityCollection>(cmd);
		}
			
	}
}


