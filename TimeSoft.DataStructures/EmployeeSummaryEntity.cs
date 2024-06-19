
using System;
using System.Runtime.Serialization;
using FijiITC.SolutionInfrastructure.DataStructures;

namespace TimeSoft.DataStructures
{

	/// <summary>
	/// Generated <see cref="EntityBase" /> class. 
	/// </summary>
	[Serializable]
	public class EmployeeSummaryEntity : EntityBase, ISerializable
	{
		#region Member Variables
        int mEmployeeID;
        string mEmployeeNo;
        Int64 mCardNo;
		string mFName;
		string mLName;
        System.Nullable<int> mBusinessUnitID;
        System.Nullable<int> mDivisionUnitID;
        System.Nullable<int> mDepartmentID; 				
		decimal mRateperHour;
        string mUserName;
        string mJobTitle;
        string mEmail;
        string mPhone;
        int mRoleID;
        System.Nullable<int> mStaffLocationID;
		string mBusinessUnitDesc;
		string mDivisionUnitDesc;
		string mDepartmentDesc;
		string mStaffLocationDesc;	
		
		public new static string PrimaryKey = "EmployeeID"; 

		#endregion
	
		#region Constructors
		///<summary>
		/// Default Constructor. 
		///</summary>
		public EmployeeSummaryEntity()
		{
            mEmployeeID = -1;           
            mEmployeeNo = string.Empty;
            mCardNo = -1;
            mFName = string.Empty;
            mLName = string.Empty;
            mBusinessUnitID = null;
            mDivisionUnitID = null;
            mDepartmentID = null;
            mRateperHour = -1;
            mUserName = string.Empty;
            mJobTitle = string.Empty;
            mEmail = string.Empty;
            mPhone = string.Empty;
            mRoleID = -1;
            mStaffLocationID = null;
            mBusinessUnitDesc = string.Empty;
            mDivisionUnitDesc = string.Empty;
            mDepartmentDesc = string.Empty;           
            mStaffLocationDesc = string.Empty;				
		}
		
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
        public EmployeeSummaryEntity(SerializationInfo info, StreamingContext context)
            : base(info, context)
		{
            mEmployeeID = (int)info.GetValue("EmployeeID", typeof(int));
            mEmployeeNo = (string)info.GetValue("EmployeeNo", typeof(string));
            mCardNo = (Int64)info.GetValue("CardNo", typeof(Int64));
            mFName = (string)info.GetValue("FName", typeof(string));
            mLName = (string)info.GetValue("LName", typeof(string));
            mBusinessUnitID = (System.Nullable<int>)info.GetValue("BusinessUnitID", typeof(System.Nullable<int>));
            mDivisionUnitID = (System.Nullable<int>)info.GetValue("DivisionUnitID", typeof(System.Nullable<int>));
            mDepartmentID = (System.Nullable<int>)info.GetValue("DepartmentID", typeof(System.Nullable<int>));           
            mRateperHour = (decimal)info.GetValue("RateperHour", typeof(decimal));
            mUserName = (string)info.GetValue("UserName", typeof(string));
            mJobTitle = (string)info.GetValue("JobTitle", typeof(string));
            mEmail = (string)info.GetValue("Email", typeof(string));
            mPhone = (string)info.GetValue("Phone", typeof(string));
            mRoleID = (int)info.GetValue("RoleID", typeof(int));
            mStaffLocationID = (System.Nullable<int>)info.GetValue("StaffLocationID", typeof(System.Nullable<int>));
            mBusinessUnitDesc = (string)info.GetValue("mBusinessUnitDesc", typeof(string));
            mDivisionUnitDesc = (string)info.GetValue("DivisionUnitDesc", typeof(string));
            mDepartmentDesc = (string)info.GetValue("DepartmentDesc", typeof(string));           
            mStaffLocationDesc = (string)info.GetValue("LocationDesc", typeof(string));
		}
		#endregion

		#region ISerializable Members

		/// <summary>
		/// Serialize data.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(info, context);

            info.AddValue("EmployeeID", mEmployeeID);
            info.AddValue("EmployeeNo", mEmployeeNo);
            info.AddValue("CardNo", mCardNo);
            info.AddValue("FName", mFName);
            info.AddValue("LName", mLName);
            info.AddValue("BusinessUnitID", mBusinessUnitID);
            info.AddValue("DivisionUnitID", mDivisionUnitID);
            info.AddValue("DepartmentID", mDepartmentID);
            info.AddValue("RateperHour", mRateperHour);           
            info.AddValue("UserName", mUserName);
            info.AddValue("JobTitle", mJobTitle);
            info.AddValue("Email", mEmail);
            info.AddValue("Phone", mPhone);
            info.AddValue("RoleID", mRoleID);
            info.AddValue("StaffLocationID", mStaffLocationID);           
            info.AddValue("BusinessUnitDesc", mBusinessUnitDesc);
            info.AddValue("DivisionUnitDesc", mDivisionUnitDesc);
            info.AddValue("DepartmentDesc", mDepartmentDesc);           
            info.AddValue("StaffLocationDesc", mStaffLocationDesc);
		}

		#endregion
		
		#region Properties
		
		#region PK
		
		#endregion
		
		
		[EntityDataProperty("EmployeeID",4)]
        public int EmployeeID
		{
			get
			{
                return mEmployeeID;
			}
			set
			{
                if (mEmployeeID != value)
				{
                    mEmployeeID = value;
					this.ValueChanged();
				}
			}
		}

        [EntityDataProperty("EmployeeNo", 50)]
        public string EmployeeNo
        {
            get
            {
                return mEmployeeNo;
            }
            set
            {
                if (mEmployeeNo != value)
                {
                    mEmployeeNo = value;
                    this.ValueChanged();
                }
            }
        }
		
		[EntityDataProperty("CardNo", 8)]
        public Int64 CardNo
		{
			get
			{
				return mCardNo;
			}
			set
			{
                if (mCardNo != value)
				{
                    mCardNo = value;
					this.ValueChanged();
				}
			}
		}

        [EntityDataProperty("FName", 50)]
        public string FName
        {
            get
            {
                return mFName;
            }
            set
            {
                if (mFName != value)
                {
                    mFName = value;
                    this.ValueChanged();
                }
            }
        }
        [EntityDataProperty("LName", 50)]
        public string LName
        {
            get
            {
                return mLName;
            }
            set
            {
                if (mLName != value)
                {
                    mLName = value;
                    this.ValueChanged();
                }
            }
        }
        [EntityDataProperty("BusinessUnitID",4)]
        public System.Nullable<int> BusinessUnitID
        {
            get
            {
                return mBusinessUnitID;
            }
            set
            {
                if (mBusinessUnitID != value)
                {
                    mBusinessUnitID = value;
                    this.ValueChanged();
                }
            }
        }
        [EntityDataProperty("DivisionUnitID", 4)]
        public System.Nullable<int> DivisionUnitID
        {
            get
            {
                return mDivisionUnitID;
            }
            set
            {
                if (mDivisionUnitID != value)
                {
                    mDivisionUnitID = value;
                    this.ValueChanged();
                }
            }
        }
        [EntityDataProperty("DepartmentID", 4)]
        public System.Nullable<int> DepartmentID
        {
            get
            {
                return mDepartmentID;
            }
            set
            {
                if (mDepartmentID != value)
                {
                    mDepartmentID = value;
                    this.ValueChanged();
                }
            }
        }      
        
        [EntityDataProperty("RateperHour", 8)]
        public decimal RateperHour
        {
            get
            {
                return mRateperHour;
            }
            set
            {
                if (mRateperHour != value)
                {
                    mRateperHour = value;
                    this.ValueChanged();
                }
            }
        }

        [EntityDataProperty("UserName", 50)]
        public string UserName
        {
            get
            {
                return mUserName;
            }
            set
            {
                if (mUserName != value)
                {
                    mUserName = value;
                    this.ValueChanged();
                }
            }
        }
        [EntityDataProperty("JobTitle", 50)]
        public string JobTitle
        {
            get
            {
                return mJobTitle;
            }
            set
            {
                if (mJobTitle != value)
                {
                    mJobTitle = value;
                    this.ValueChanged();
                }
            }
        }
        [EntityDataProperty("Email", 255)]
        public string Email
        {
            get
            {
                return mEmail;
            }
            set
            {
                if (mEmail != value)
                {
                    mEmail = value;
                    this.ValueChanged();
                }
            }
        }
        [EntityDataProperty("Phone", 50)]
        public string Phone
        {
            get
            {
                return mPhone;
            }
            set
            {
                if (mPhone != value)
                {
                    mPhone = value;
                    this.ValueChanged();
                }
            }
        }
        [EntityDataProperty("RoleID", 4)]
        public int RoleID
        {
            get
            {
                return mRoleID;
            }
            set
            {
                if (mRoleID != value)
                {
                    mRoleID = value;
                    this.ValueChanged();
                }
            }
        }

        [EntityDataProperty("StaffLocationID", 4)]
        public System.Nullable<int> StaffLocationID
        {
            get
            {
                return mStaffLocationID;
            }
            set
            {
                if (mStaffLocationID != value)
                {
                    mStaffLocationID = value;
                    this.ValueChanged();
                }
            }
        }

        [EntityDataProperty("BusinessUnitDesc", 50)]
        public string BusinessUnitDesc
        {
            get
            {
                return mBusinessUnitDesc;
            }
            set
            {
                if (mBusinessUnitDesc != value)
                {
                    mBusinessUnitDesc = value;
                    this.ValueChanged();
                }
            }
        }
        [EntityDataProperty("DivisionUnitDesc", 50)]
        public string DivisionUnitDesc
        {
            get
            {
                return mDivisionUnitDesc;
            }
            set
            {
                if (mDivisionUnitDesc != value)
                {
                    mDivisionUnitDesc = value;
                    this.ValueChanged();
                }
            }
        }
        [EntityDataProperty("DepartmentDesc", 50)]
        public string DepartmentDesc
        {
            get
            {
                return mDepartmentDesc;
            }
            set
            {
                if (mDepartmentDesc != value)
                {
                    mDepartmentDesc = value;
                    this.ValueChanged();
                }
            }
        }
      
        [EntityDataProperty("StaffLocationDesc", 50)]
        public string StaffLocationDesc
        {
            get
            {
                return mStaffLocationDesc;
            }
            set
            {
                if (mStaffLocationDesc != value)
                {
                    mStaffLocationDesc = value;
                    this.ValueChanged();
                }
            }
        }


		#endregion
		
	}
} 
