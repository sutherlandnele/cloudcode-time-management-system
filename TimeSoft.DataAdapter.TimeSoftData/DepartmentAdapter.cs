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
	public partial class DepartmentAdapter : DataAdapterBase
	{  
		#region Constructors
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="db">The existing database connection to use.</param> 
		/// <param name="txn">The transaction to participate in.  Null if a transaction is not required.</param>
        public DepartmentAdapter(Database db, DbTransaction txn)
            : base(db, txn)
		{ 
		}
		#endregion
		
		
		public DepartmentEntity Get(int departmentID)
		{
			DbCommand cmd = Db.GetStoredProcCommand("[dbo].prc_Department_Get");

            Db.AddInParameter(cmd, "@DepartmentID", DbType.Int32, departmentID);

            return ExecuteSPSingular<DepartmentEntity>(cmd);		
		}

        public DepartmentEntityCollection FindByDivisionUnitID(int divisionUnitID, Nullable<bool> active)
        {
            DbCommand cmd = Db.GetStoredProcCommand("[dbo].prc_Department_FindByDivisionUnitID");

            Db.AddInParameter(cmd, "@DivisionUnitID", DbType.Int32, divisionUnitID);
            Db.AddInParameter(cmd, "@Active", DbType.Boolean, active);
            return ExecuteSPMultiple<DepartmentEntity, DepartmentEntityCollection>(cmd);
        } 		
		
		public DepartmentEntityCollection FindAll(Nullable<bool> active)
		{
            DbCommand cmd = Db.GetStoredProcCommand("[dbo].prc_Department_FindAll");  
			
			Db.AddInParameter(cmd, "@Active", DbType.Boolean, active);

            return ExecuteSPMultiple<DepartmentEntity, DepartmentEntityCollection>(cmd);
		}
        
		public int Insert(EntityBase entity, string username, DateTime updateDateTime)
		{
            DepartmentEntity departmentEntity = (DepartmentEntity)entity;
            DbCommand cmd = Db.GetStoredProcCommand("[dbo].prc_Department_Ins");
            Db.AddInParameter(cmd, "@DivisionUnitID", DbType.Int32, departmentEntity.DivisionUnitID); 
            Db.AddInParameter(cmd, "@DepartmentDesc", DbType.AnsiString, departmentEntity.DepartmentDesc);
            Db.AddInParameter(cmd, "@Active", DbType.Boolean, departmentEntity.Active);
            Db.AddOutParameter(cmd, "@DepartmentID", DbType.Int32, 4); 
			ExecuteSPNonQuery(cmd);
            departmentEntity.DepartmentID = (int)Db.GetParameterValue(cmd, "@DepartmentID");
			
			return departmentEntity.DepartmentID ;
		}

		
		public DepartmentEntity Update(EntityBase entity, string username, DateTime updateDateTime)
		{
            DepartmentEntity departmentEntity = (DepartmentEntity)entity;
            DbCommand cmd = Db.GetStoredProcCommand("[dbo].prc_Department_Upd");

            Db.AddInParameter(cmd, "@DepartmentID", DbType.Int32, departmentEntity.DepartmentID);
            Db.AddInParameter(cmd, "@DivisionUnitID", DbType.Int32, departmentEntity.DivisionUnitID);
            Db.AddInParameter(cmd, "@DepartmentDesc", DbType.AnsiString, departmentEntity.DepartmentDesc);
            Db.AddInParameter(cmd, "@Active", DbType.Boolean, departmentEntity.Active);  			
			
			ExecuteSPNonQuery(cmd);
            return departmentEntity;
		}  	
		
		public void Delete(EntityBase entity, string username, DateTime updateDateTime)
		{
            DepartmentEntity departmentEntity = (DepartmentEntity)entity;
			DbCommand cmd = Db.GetStoredProcCommand("[dbo].prc_Department_Del"); 			
		
			Db.AddInParameter(cmd, "@DepartmentID", DbType.Int32, departmentEntity.DepartmentID); 
			
			ExecuteSPNonQuery(cmd);		

		}
			
	}
}

