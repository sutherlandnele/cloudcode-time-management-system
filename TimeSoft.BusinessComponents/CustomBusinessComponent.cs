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
using TimeSoft.DataStructures.Enumerator;

namespace TimeSoft.BusinessComponents
{
    public partial class CustomBusinessComponent : BusinessComponentBase
    {
         #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="principal">The <see cref="IPrincipal"/> of the user.</param>
        public CustomBusinessComponent(IPrincipal principal)
            : base(principal)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="principal">The <see cref="IPrincipal"/> of the user.</param>
        /// <param name="db">The existing database connection to use.</param> 
        /// <param name="txn">The transaction to participate in.  Null if a transaction is not required.</param>
        public CustomBusinessComponent(IPrincipal principal, Database db, DbTransaction txn)
            : base(principal, db, txn)
        {
        }
         #endregion



        public EmployeeTimeLogEntityCollection ReportTimeLogForAllEmployee(DateTime fromDate, DateTime toDate)
        {
            CustomDataAdapter adapter = new CustomDataAdapter(this.Db, this.Txn);
            return adapter.ReportTimeLogForAllEmployee(fromDate, toDate);
        }

        public EmployeeTimeLogEntityCollection ReportTimeLogByIndividualEmployee(int employeeID, DateTime fromDate, DateTime toDate)
        {
            CustomDataAdapter adapter = new CustomDataAdapter(this.Db, this.Txn);
            return adapter.ReportTimeLogByIndividualEmployee(employeeID, fromDate, toDate);
        }

        public EmployeeEntityCollection Employee_FindAllBySearchWord(string searchField, string searchWord)
        {
            CustomDataAdapter adapter = new CustomDataAdapter(this.Db, this.Txn);
            return adapter.Employee_FindAllBySearchWord(searchField, searchWord);
        }

        public EmployeeEntity Employee_Update(EmployeeEntity employeeEntity)
        {
            CustomDataAdapter adapter = new CustomDataAdapter(this.Db, this.Txn);
            adapter.Employee_Update(employeeEntity, base.CurrentUserName(), DateTime.Now);
            employeeEntity.AcceptChanges();
            return employeeEntity;
        }

        public EmployeeEntityCollection Employee_FindAll()
        {
            CustomDataAdapter adapter = new CustomDataAdapter(this.Db, this.Txn);
            return adapter.Employee_FindAll();
        }

        public SummaryEmployeeTimeLogEntityCollection SummaryReportTimeLogForAllEmployee(DateTime fromDate, DateTime toDate)
        {
            CustomDataAdapter adapter = new CustomDataAdapter(this.Db, this.Txn);
            return adapter.SummaryReportTimeLogForAllEmployee(fromDate, toDate);
        } 

    }
}
