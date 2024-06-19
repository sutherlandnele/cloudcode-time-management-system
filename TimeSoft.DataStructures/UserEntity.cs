
using System;
using System.Runtime.Serialization;
using FijiITC.SolutionInfrastructure.DataStructures;

namespace TimeSoft.DataStructures
{

	/// <summary>
	/// Generated <see cref="EntityBase" /> class. 
	/// </summary>
	[Serializable]
	public class UserEntity : EntityBase, ISerializable
	{
		#region Member Variables
		
		int mUserID;
		string mUserName;
        string mLastName;
        string mPassword;
        string mOtherNames;
        int mRoleID;
        string mEmail;
        string mPhone;
        System.Nullable<int> mBusinessUnitID;
        System.Nullable<int> mDivisionUnitID;
        System.Nullable<int> mDepartmentID;
        string mRoleDesc;
        string mBusinessUnitDesc;
        string mDivisionUnitDesc;
        string mDepartmentDesc;
     		
		public new static string PrimaryKey = "UserID"; 

		#endregion
	
		#region Constructors
		///<summary>
		/// Default Constructor. 
		///</summary>
		public UserEntity()
		{
            mUserID = -1;
            mUserName = string.Empty;
            mLastName = string.Empty;
            mOtherNames = string.Empty;
            mPassword = string.Empty;
            mEmail = string.Empty;
            mPhone = string.Empty;
            mRoleID = -1;
            mBusinessUnitID = null;
            mDivisionUnitID = null;
            mDepartmentID = null;
            mRoleDesc = string.Empty;
            mBusinessUnitDesc = string.Empty;
            mDivisionUnitDesc = string.Empty;
            mDepartmentDesc = string.Empty;            
		}
		
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
        public UserEntity(SerializationInfo info, StreamingContext context)
            : base(info, context)
		{
            mUserID = (int)info.GetValue("UserID", typeof(int));
            mUserName = (string)info.GetValue("UserName", typeof(string));
            mLastName = (string)info.GetValue("LastName", typeof(string));
            mOtherNames = (string)info.GetValue("OtherNames", typeof(string));
            mPassword = (string)info.GetValue("Password", typeof(string));
            mEmail = (string)info.GetValue("Email", typeof(string));
            mPhone = (string)info.GetValue("Phone", typeof(string));
            mRoleID = (int)info.GetValue("RoleID", typeof(int));
            mBusinessUnitID = (System.Nullable<int>)info.GetValue("BusinessUnitID", typeof(System.Nullable<int>));
            mDivisionUnitID = (System.Nullable<int>)info.GetValue("DivisionUnitID", typeof(System.Nullable<int>));
            mDepartmentID = (System.Nullable<int>)info.GetValue("DepartmentID", typeof(System.Nullable<int>));
            mRoleDesc = (string)info.GetValue("RoleDesc", typeof(string));
            mBusinessUnitDesc = (string)info.GetValue("BusinessUnitDesc", typeof(string));
            mDivisionUnitDesc = (string)info.GetValue("DivisionUnitDesc", typeof(string));
            mDepartmentDesc= (string)info.GetValue("DepartmentDesc", typeof(string));
           
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

            info.AddValue("UserID", mUserID);
            info.AddValue("UserName", mUserName);
            info.AddValue("LastName", mLastName);
            info.AddValue("OtherNames", mOtherNames);
            info.AddValue("Password", mPassword);
            info.AddValue("Email", mEmail);
            info.AddValue("Phone", mPhone);
            info.AddValue("RoleID", mRoleID);
            info.AddValue("BusinessUnitID", mBusinessUnitID);
            info.AddValue("DivisionUnitID", mDivisionUnitID);
            info.AddValue("DepartmentID", mDepartmentID);
            info.AddValue("RoleDesc", mRoleDesc);
            info.AddValue("BusinessUnitDesc", mBusinessUnitDesc);
            info.AddValue("DivisionUnitDesc", mDivisionUnitDesc);
            info.AddValue("DepartmentDesc", mDepartmentDesc);
          
		}

		#endregion
		
		#region Properties
		
		#region PK
		
		#endregion
		
		
		[EntityDataProperty("UserID", 4)]
        public int UserID
		{
			get
			{
                return mUserID;
			}
			set
			{
                if (mUserID != value)
				{
                    mUserID = value;
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

        [EntityDataProperty("LastName", 50)]
        public string LastName
        {
            get
            {
                return mLastName;
            }
            set
            {
                if (mLastName != value)
                {
                    mLastName = value;
                    this.ValueChanged();
                }
            }
        }

        [EntityDataProperty("OtherNames", 255)]
        public string OtherNames
        {
            get
            {
                return mOtherNames;
            }
            set
            {
                if (mOtherNames != value)
                {
                    mOtherNames = value;
                    this.ValueChanged();
                }
            }
        }
        [EntityDataProperty("Password", 50)]
        public string Password
        {
            get
            {
                return mPassword;
            }
            set
            {
                if (mPassword != value)
                {
                    mPassword = value;
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
        [EntityDataProperty("BusinessUnitID", 4)]
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
        [EntityDataProperty("RoleDesc", 255)]
        public string RoleDesc
        {
            get
            {
                return mRoleDesc;
            }
            set
            {
                if (mRoleDesc != value)
                {
                    mRoleDesc = value;
                    this.ValueChanged();
                }
            }
        }
        [EntityDataProperty("BusinessUnitDesc", 255)]
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
        [EntityDataProperty("DivisionUnitDesc", 255)]
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
        [EntityDataProperty("DepartmentDesc", 255)]
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
		#endregion
		
	}
} 

