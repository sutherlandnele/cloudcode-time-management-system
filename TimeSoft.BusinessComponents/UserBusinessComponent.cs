
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
	public partial class UserBusinessComponent : BusinessComponentBase
	{  
		#region Constructors
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="principal">The <see cref="IPrincipal"/> of the user.</param>
		public UserBusinessComponent(IPrincipal principal) : base(principal)
		{ 
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="principal">The <see cref="IPrincipal"/> of the user.</param>
		/// <param name="db">The existing database connection to use.</param> 
		/// <param name="txn">The transaction to participate in.  Null if a transaction is not required.</param>
        public UserBusinessComponent(IPrincipal principal, Database db, DbTransaction txn)
            : base(principal, db, txn)
		{ 
		}
		#endregion

		#region Generated Methods
		
	
		public UserEntity Get(int userID)
		{
            UserAdapter adapter = new UserAdapter(this.Db, this.Txn);
			return adapter.Get(userID);
		}
        public UserEntity GetByUserName(string userName)
        {
            UserAdapter adapter = new UserAdapter(this.Db, this.Txn);
            return adapter.GetByUserName(userName);
        }		

		public UserEntityCollection FindAll()
		{
            UserAdapter adapter = new UserAdapter(this.Db, this.Txn);
			return adapter.FindAll();
		}

        public int Insert(UserEntity userEntity)
		{
            UserAdapter adapter = new UserAdapter(this.Db, this.Txn);
            adapter.Insert(userEntity, this.CurrentUserName(), DateTime.Now);
            userEntity.AcceptChanges();
            return userEntity.UserID;
		}

        public UserEntity Update(UserEntity userEntity)
		{
            UserAdapter adapter = new UserAdapter(this.Db, this.Txn);
            adapter.Update(userEntity, base.CurrentUserName(), DateTime.Now);
            userEntity.AcceptChanges();
            return userEntity;
		}

        public void Delete(UserEntity userEntity)
		{
            UserAdapter adapter = new UserAdapter(this.Db, this.Txn);
            adapter.Delete(userEntity, this.CurrentUserName(), DateTime.Now);
		}
        public UserEntity ResetPassword(UserEntity userEntity)
        {
            UserAdapter adapter = new UserAdapter(this.Db, this.Txn);
            adapter.ResetPassword(userEntity, base.CurrentUserName(), DateTime.Now);
            userEntity.AcceptChanges();
            return userEntity;
        }
       
	 	
		#endregion

	}
}

