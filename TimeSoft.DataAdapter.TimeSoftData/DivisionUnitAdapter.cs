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
	public partial class DivisionUnitAdapter : DataAdapterBase
	{  
		#region Constructors
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="db">The existing database connection to use.</param> 
		/// <param name="txn">The transaction to participate in.  Null if a transaction is not required.</param>
        public DivisionUnitAdapter(Database db, DbTransaction txn)
            : base(db, txn)
		{ 
		}
		#endregion
		
		
		public DivisionUnitEntity Get(int divisionUnitID)
		{
			DbCommand cmd = Db.GetStoredProcCommand("[dbo].prc_DivisionUnit_Get");

            Db.AddInParameter(cmd, "@DivisionUnitID", DbType.Int32, divisionUnitID);

            return ExecuteSPSingular<DivisionUnitEntity>(cmd);		
		}

        public DivisionUnitEntityCollection FindByBusinessUnitID(int businessUnitID, Nullable<bool> active)
        {
            DbCommand cmd = Db.GetStoredProcCommand("[dbo].prc_DivisionUnit_FindByBusinessUnitID");

            Db.AddInParameter(cmd, "@BusinessUnitID", DbType.Int32, businessUnitID);
            Db.AddInParameter(cmd, "@Active", DbType.Boolean, active);

            return ExecuteSPMultiple<DivisionUnitEntity, DivisionUnitEntityCollection>(cmd);
        } 		
		
		public DivisionUnitEntityCollection FindAll(Nullable<bool> active)
		{
            DbCommand cmd = Db.GetStoredProcCommand("[dbo].prc_DivisionUnit_FindAll");  
			
			Db.AddInParameter(cmd, "@Active", DbType.Boolean, active);

            return ExecuteSPMultiple<DivisionUnitEntity, DivisionUnitEntityCollection>(cmd);
		}
        
		public int Insert(EntityBase entity, string username, DateTime updateDateTime)
		{
            DivisionUnitEntity divisionUnitEntity = (DivisionUnitEntity)entity;
            DbCommand cmd = Db.GetStoredProcCommand("[dbo].prc_DivisionUnit_Ins");
            Db.AddInParameter(cmd, "@BusinessUnitID", DbType.Int32, divisionUnitEntity.BusinessUnitID); 
            Db.AddInParameter(cmd, "@DivisionUnitDesc", DbType.AnsiString, divisionUnitEntity.DivisionUnitDesc);
            Db.AddInParameter(cmd, "@Active", DbType.Boolean, divisionUnitEntity.Active);
            Db.AddOutParameter(cmd, "@DivisionUnitID", DbType.Int32, 4); 
			ExecuteSPNonQuery(cmd);
            divisionUnitEntity.DivisionUnitID = (int)Db.GetParameterValue(cmd, "@DivisionUnitID");
			
			return divisionUnitEntity.DivisionUnitID ;
		}

		
		public DivisionUnitEntity Update(EntityBase entity, string username, DateTime updateDateTime)
		{
            DivisionUnitEntity divisionUnitEntity = (DivisionUnitEntity)entity;
            DbCommand cmd = Db.GetStoredProcCommand("[dbo].prc_DivisionUnit_Upd");

            Db.AddInParameter(cmd, "@DivisionUnitID", DbType.Int32, divisionUnitEntity.DivisionUnitID);
            Db.AddInParameter(cmd, "@BusinessUnitID", DbType.Int32, divisionUnitEntity.BusinessUnitID);
            Db.AddInParameter(cmd, "@DivisionUnitDesc", DbType.AnsiString, divisionUnitEntity.DivisionUnitDesc);
            Db.AddInParameter(cmd, "@Active", DbType.Boolean, divisionUnitEntity.Active);  			
			
			ExecuteSPNonQuery(cmd);
            return divisionUnitEntity;
		}  	
		
		public void Delete(EntityBase entity, string username, DateTime updateDateTime)
		{
            DivisionUnitEntity divisionUnitEntity = (DivisionUnitEntity)entity;
			DbCommand cmd = Db.GetStoredProcCommand("[dbo].prc_DivisionUnit_Del"); 			
		
			Db.AddInParameter(cmd, "@DivisionUnitID", DbType.Int32, divisionUnitEntity.DivisionUnitID); 
			
			ExecuteSPNonQuery(cmd);		

		}
			
	}
}

