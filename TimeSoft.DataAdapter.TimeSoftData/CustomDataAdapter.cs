
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
	public partial class CustomDataAdapter : DataAdapterBase
	{  
		#region Constructors
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="db">The existing database connection to use.</param> 
		/// <param name="txn">The transaction to participate in.  Null if a transaction is not required.</param>
        public CustomDataAdapter(Database db, DbTransaction txn)
            : base(db, txn)
		{ 
		}
		#endregion

        public EmployeeTimeLogEntityCollection ReportTimeLogForAllEmployee(DateTime fromDate, DateTime toDate)
        {
            DbCommand cmd = Db.GetStoredProcCommand("[dbo].rpt_GetTimeLogForAllEmployees");
            cmd.CommandTimeout= 20000;
            Db.AddInParameter(cmd, "@FromDate", DbType.DateTime, fromDate);
            Db.AddInParameter(cmd, "@ToDate", DbType.DateTime, toDate);
            return ExecuteSPMultiple<EmployeeTimeLogEntity, EmployeeTimeLogEntityCollection>(cmd);
        }
        public EmployeeTimeLogEntityCollection ReportTimeLogByIndividualEmployee(int employeeID, DateTime fromDate, DateTime toDate)
        {
            DbCommand cmd = Db.GetStoredProcCommand("[dbo].rpt_GetTimeLogByIndividualEmployee");
            cmd.CommandTimeout= 20000;
            Db.AddInParameter(cmd, "@FromDate", DbType.DateTime, fromDate);
            Db.AddInParameter(cmd, "@ToDate", DbType.DateTime, toDate);
            Db.AddInParameter(cmd, "@EmployeeID", DbType.Int32, employeeID);
            return ExecuteSPMultiple<EmployeeTimeLogEntity, EmployeeTimeLogEntityCollection>(cmd);
        }        

        public EmployeeEntityCollection Employee_FindAllBySearchWord(string searchField, string searchWord)
        {
            DbCommand cmd = Db.GetStoredProcCommand("[dbo].prc_Employee_FindAllBySearchWord");
            cmd.CommandTimeout= 20000;
            Db.AddInParameter(cmd, "@SearchField", DbType.AnsiString, searchField);
            Db.AddInParameter(cmd, "@SearchWord", DbType.AnsiString, searchWord);
            return ExecuteSPMultiple<EmployeeEntity, EmployeeEntityCollection>(cmd);
        }


        public EmployeeEntity Employee_Update(EntityBase entity, string username, DateTime updateDateTime)
		{
            EmployeeEntity employeeEntity = (EmployeeEntity)entity;
		    DbCommand cmd = Db.GetStoredProcCommand("[dbo].prc_Employee_Upd");

            Db.AddInParameter(cmd, "@EmployeeID", DbType.Int32, employeeEntity.EmployeeID);
            Db.AddInParameter(cmd, "@BusinessUnitID", DbType.Int32, employeeEntity.BusinessUnitID);
            Db.AddInParameter(cmd, "@DivisionUnitID", DbType.Int32, employeeEntity.DivisionUnitID);
            Db.AddInParameter(cmd, "@DepartmentID", DbType.Int32, employeeEntity.DepartmentID);
            Db.AddInParameter(cmd, "@RateperHour", DbType.Decimal, employeeEntity.RateperHour);
            Db.AddInParameter(cmd, "@StaffLocationID", DbType.Int32, employeeEntity.StaffLocationID);
            Db.AddInParameter(cmd, "@JobTitle", DbType.AnsiString, employeeEntity.JobTitle);
            Db.AddInParameter(cmd, "@Active", DbType.Boolean, employeeEntity.Active);
            Db.AddInParameter(cmd, "@EmployeeNo", DbType.AnsiString, employeeEntity.EmployeeNo);
            Db.AddInParameter(cmd, "@FName", DbType.AnsiString, employeeEntity.FName);
            Db.AddInParameter(cmd, "@LName", DbType.AnsiString, employeeEntity.LName); 
			ExecuteSPNonQuery(cmd);				
			return employeeEntity;
		}
        public EmployeeEntityCollection Employee_FindAll()
        {
            DbCommand cmd = Db.GetStoredProcCommand("[dbo].prc_Employee_FindAll");
            cmd.CommandTimeout = 20000;           
            return ExecuteSPMultiple<EmployeeEntity, EmployeeEntityCollection>(cmd);
        }

        public SummaryEmployeeTimeLogEntityCollection SummaryReportTimeLogForAllEmployee(DateTime fromDate, DateTime toDate)
        {
            DbCommand cmd = Db.GetStoredProcCommand("[dbo].rpt_GetSummaryTimeLogForAllEmployeesNew");
            cmd.CommandTimeout = 20000;
            Db.AddInParameter(cmd, "@FromDate", DbType.DateTime, fromDate);
            Db.AddInParameter(cmd, "@ToDate", DbType.DateTime, toDate);
            return ExecuteSPMultiple<SummaryEmployeeTimeLogEntity, SummaryEmployeeTimeLogEntityCollection>(cmd);
        }

        public ComboEntityCollection Location_FindAll()
        {
            DbCommand cmd = Db.GetStoredProcCommand("[dbo].prc_Location_FindAll");
            return ExecuteSPMultiple<ComboEntity, ComboEntityCollection>(cmd);
        }
	}
}

