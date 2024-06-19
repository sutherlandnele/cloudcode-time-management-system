
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
	public partial class StaffLocationAdapter : DataAdapterBase
	{  
		#region Constructors
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="db">The existing database connection to use.</param> 
		/// <param name="txn">The transaction to participate in.  Null if a transaction is not required.</param>
        public StaffLocationAdapter(Database db, DbTransaction txn)
            : base(db, txn)
		{ 
		}
		#endregion
		
		
		public StaffLocationEntity Get(int staffLocationID)
		{
			DbCommand cmd = Db.GetStoredProcCommand("[dbo].prc_StaffLocation_Get");

            Db.AddInParameter(cmd, "@StaffLocationID", DbType.Int32, staffLocationID);

            return ExecuteSPSingular<StaffLocationEntity>(cmd);		
		}		
		
		
		public StaffLocationEntityCollection FindAll(Nullable<bool> active)
		{
			DbCommand cmd = Db.GetStoredProcCommand("[dbo].prc_StaffLocation_FindAll");  
			
			Db.AddInParameter(cmd, "@Active", DbType.Boolean, active);
			
			return ExecuteSPMultiple<StaffLocationEntity, StaffLocationEntityCollection>(cmd);
		}
        
		public int Insert(EntityBase entity, string username, DateTime updateDateTime)
		{
			StaffLocationEntity staffLocationEntity = (StaffLocationEntity)entity;
            DbCommand cmd = Db.GetStoredProcCommand("[dbo].prc_StaffLocation_Ins");
            Db.AddInParameter(cmd, "@StaffLocationDesc", DbType.AnsiString, staffLocationEntity.StaffLocationDesc);
            Db.AddInParameter(cmd, "@Active", DbType.Boolean, staffLocationEntity.Active);
            Db.AddOutParameter(cmd, "@StaffLocationID", DbType.Int32, 4); 
			ExecuteSPNonQuery(cmd);
            staffLocationEntity.StaffLocationID = (int)Db.GetParameterValue(cmd, "@StaffLocationID");
			
			return staffLocationEntity.StaffLocationID ;
		}

		
		public StaffLocationEntity Update(EntityBase entity, string username, DateTime updateDateTime)
		{
            StaffLocationEntity staffLocationEntity = (StaffLocationEntity)entity;
		    DbCommand cmd = Db.GetStoredProcCommand("[dbo].prc_StaffLocation_Upd");  			

			Db.AddInParameter(cmd, "@StaffLocationID", DbType.Int32, staffLocationEntity.StaffLocationID); 
			Db.AddInParameter(cmd, "@StaffLocationDesc", DbType.AnsiString, staffLocationEntity.StaffLocationDesc);
            Db.AddInParameter(cmd, "@Active", DbType.Boolean, staffLocationEntity.Active); 
			
			ExecuteSPNonQuery(cmd);				
			return staffLocationEntity;
		}  	
		
		public void Delete(EntityBase entity, string username, DateTime updateDateTime)
		{
            StaffLocationEntity staffLocationEntity = (StaffLocationEntity)entity;
			DbCommand cmd = Db.GetStoredProcCommand("[dbo].prc_StaffLocation_Del"); 			
		
			Db.AddInParameter(cmd, "@StaffLocationID", DbType.Int32, staffLocationEntity.StaffLocationID); 
			
			ExecuteSPNonQuery(cmd);		

		}
			
	}
}

