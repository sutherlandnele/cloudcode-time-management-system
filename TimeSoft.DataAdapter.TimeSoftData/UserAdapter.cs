
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
	public partial class UserAdapter : DataAdapterBase
	{  
		#region Constructors
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="db">The existing database connection to use.</param> 
		/// <param name="txn">The transaction to participate in.  Null if a transaction is not required.</param>
        public UserAdapter(Database db, DbTransaction txn)
            : base(db, txn)
		{ 
		}
		#endregion
		
		
		public UserEntity Get(int userID)
		{
			DbCommand cmd = Db.GetStoredProcCommand("[dbo].prc_User_Get");
            Db.AddInParameter(cmd, "@UserID", DbType.Int32, userID);
            return ExecuteSPSingular<UserEntity>(cmd);		
		}

        public UserEntity GetByUserName(string userName)
        {
            DbCommand cmd = Db.GetStoredProcCommand("[dbo].prc_User_GetByUserName");
            Db.AddInParameter(cmd, "@UserName", DbType.AnsiString, userName);
            return ExecuteSPSingular<UserEntity>(cmd);
        }		
		
		public UserEntityCollection FindAll()
		{
			DbCommand cmd = Db.GetStoredProcCommand("[dbo].prc_User_FindAll");  			
			return ExecuteSPMultiple<UserEntity, UserEntityCollection>(cmd);
		}
        
		public int Insert(EntityBase entity, string username, DateTime updateDateTime)
		{
			UserEntity userEntity = (UserEntity)entity;
            DbCommand cmd = Db.GetStoredProcCommand("[dbo].prc_User_Ins");
            Db.AddInParameter(cmd, "@UserName", DbType.AnsiString, userEntity.UserName);
            Db.AddInParameter(cmd, "@LastName", DbType.AnsiString, userEntity.LastName);
            Db.AddInParameter(cmd, "@OtherNames", DbType.AnsiString, userEntity.OtherNames);
            Db.AddInParameter(cmd, "@Password", DbType.AnsiString, userEntity.Password);
            Db.AddInParameter(cmd, "@Email", DbType.AnsiString, userEntity.Email);
            Db.AddInParameter(cmd, "@Phone", DbType.AnsiString, userEntity.Phone);
            Db.AddInParameter(cmd, "@RoleID", DbType.AnsiString, userEntity.RoleID);
            Db.AddInParameter(cmd, "@BusinessUnitID", DbType.AnsiString, userEntity.BusinessUnitID);
            Db.AddInParameter(cmd, "@DivisionUnitID", DbType.AnsiString, userEntity.DivisionUnitID);
            Db.AddInParameter(cmd, "@DepartmentID", DbType.AnsiString, userEntity.DepartmentID);


            Db.AddOutParameter(cmd, "@UserID", DbType.Int32, 4); 
			ExecuteSPNonQuery(cmd);
            userEntity.UserID = (int)Db.GetParameterValue(cmd, "@UserID");
			
			return userEntity.UserID ;
		}

		
		public UserEntity Update(EntityBase entity, string username, DateTime updateDateTime)
		{
            UserEntity userEntity = (UserEntity)entity;
		    DbCommand cmd = Db.GetStoredProcCommand("[dbo].prc_User_Upd");  			

			Db.AddInParameter(cmd, "@UserID", DbType.Int32, userEntity.UserID);           
            Db.AddInParameter(cmd, "@LastName", DbType.AnsiString, userEntity.LastName);
            Db.AddInParameter(cmd, "@OtherNames", DbType.AnsiString, userEntity.OtherNames);          
            Db.AddInParameter(cmd, "@Email", DbType.AnsiString, userEntity.Email);
            Db.AddInParameter(cmd, "@Phone", DbType.AnsiString, userEntity.Phone);
            Db.AddInParameter(cmd, "@RoleID", DbType.AnsiString, userEntity.RoleID);
            Db.AddInParameter(cmd, "@BusinessUnitID", DbType.AnsiString, userEntity.BusinessUnitID);
            Db.AddInParameter(cmd, "@DivisionUnitID", DbType.AnsiString, userEntity.DivisionUnitID);
            Db.AddInParameter(cmd, "@DepartmentID", DbType.AnsiString, userEntity.DepartmentID);
			
			ExecuteSPNonQuery(cmd);				
			return userEntity;
		}  	
		
		public void Delete(EntityBase entity, string username, DateTime updateDateTime)
		{
            UserEntity userEntity = (UserEntity)entity;
			DbCommand cmd = Db.GetStoredProcCommand("[dbo].prc_User_Del"); 			
			Db.AddInParameter(cmd, "@UserID", DbType.Int32, userEntity.UserID); 			
			ExecuteSPNonQuery(cmd);	
		}
        public UserEntity ResetPassword(EntityBase entity, string username, DateTime updateDateTime)
        {
            UserEntity userEntity = (UserEntity)entity;
            DbCommand cmd = Db.GetStoredProcCommand("[dbo].prc_User_ResetPassword");
                      
            Db.AddInParameter(cmd, "@UserName", DbType.AnsiString, userEntity.UserName);
            Db.AddInParameter(cmd, "@Password", DbType.AnsiString, userEntity.Password);       

            ExecuteSPNonQuery(cmd);
            return userEntity;
        }  	
		
			
	}
}


