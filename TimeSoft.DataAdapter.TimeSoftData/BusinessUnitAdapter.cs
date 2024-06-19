
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
	public partial class BusinessUnitAdapter : DataAdapterBase
	{  
		#region Constructors
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="db">The existing database connection to use.</param> 
		/// <param name="txn">The transaction to participate in.  Null if a transaction is not required.</param>
        public BusinessUnitAdapter(Database db, DbTransaction txn)
            : base(db, txn)
		{ 
		}
		#endregion
		
		
		public BusinessUnitEntity Get(int businessUnitID)
		{
			DbCommand cmd = Db.GetStoredProcCommand("[dbo].prc_BusinessUnit_Get");

            Db.AddInParameter(cmd, "@BusinessUnitID", DbType.Int32, businessUnitID);

            return ExecuteSPSingular<BusinessUnitEntity>(cmd);		
		}		
		
		
		public BusinessUnitEntityCollection FindAll(Nullable<bool> active)
		{
			DbCommand cmd = Db.GetStoredProcCommand("[dbo].prc_BusinessUnit_FindAll");  
			
			Db.AddInParameter(cmd, "@Active", DbType.Boolean, active);
			
			return ExecuteSPMultiple<BusinessUnitEntity, BusinessUnitEntityCollection>(cmd);
		}
        
		public int Insert(EntityBase entity, string username, DateTime updateDateTime)
		{
			BusinessUnitEntity businessUnitEntity = (BusinessUnitEntity)entity;
            DbCommand cmd = Db.GetStoredProcCommand("[dbo].prc_BusinessUnit_Ins");
            Db.AddInParameter(cmd, "@BusinessUnitDesc", DbType.AnsiString, businessUnitEntity.BusinessUnitDesc);
            Db.AddInParameter(cmd, "@Active", DbType.Boolean, businessUnitEntity.Active);
            Db.AddOutParameter(cmd, "@BusinessUnitID", DbType.Int32, 4); 
			ExecuteSPNonQuery(cmd);
            businessUnitEntity.BusinessUnitID = (int)Db.GetParameterValue(cmd, "@BusinessUnitID");
			
			return businessUnitEntity.BusinessUnitID ;
		}

		
		public BusinessUnitEntity Update(EntityBase entity, string username, DateTime updateDateTime)
		{
            BusinessUnitEntity businessUnitEntity = (BusinessUnitEntity)entity;
		    DbCommand cmd = Db.GetStoredProcCommand("[dbo].prc_BusinessUnit_Upd");  			

			Db.AddInParameter(cmd, "@BusinessUnitID", DbType.Int32, businessUnitEntity.BusinessUnitID); 
			Db.AddInParameter(cmd, "@BusinessUnitDesc", DbType.AnsiString, businessUnitEntity.BusinessUnitDesc);
            Db.AddInParameter(cmd, "@Active", DbType.Boolean, businessUnitEntity.Active); 
			
			ExecuteSPNonQuery(cmd);				
			return businessUnitEntity;
		}  	
		
		public void Delete(EntityBase entity, string username, DateTime updateDateTime)
		{
            BusinessUnitEntity businessUnitEntity = (BusinessUnitEntity)entity;
			DbCommand cmd = Db.GetStoredProcCommand("[dbo].prc_BusinessUnit_Del"); 			
		
			Db.AddInParameter(cmd, "@BusinessUnitID", DbType.Int32, businessUnitEntity.BusinessUnitID); 
			
			ExecuteSPNonQuery(cmd);		

		}
			
	}
}

