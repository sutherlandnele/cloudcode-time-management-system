using System;
using System.Runtime.Serialization;
using FijiITC.SolutionInfrastructure.DataStructures;

namespace TimeSoft.DataStructures
{

	/// <summary>
	/// Generated <see cref="EntityBase" /> class. 
	/// </summary>
	[Serializable]
	public class SummaryEmployeeTimeLogEntity : EntityBase, ISerializable
	{
		#region Member Variables

        int mEmployeeID;
        Int64 mCardNo;
		string mFName;
		string mLName;
        string mEmployeeNo;			
		int mMorningTimeLoss;
		int mDayTimeLoss	;
	    int mEndOfDayTimeLoss;
        decimal mRateperHour;
        System.Nullable<int> mBusinessUnitID;
        System.Nullable<int> mDivisionUnitID;
        System.Nullable<int> mDepartmentID;       
        string mJobTitle;    
        string mBusinessUnitDesc;
        string mDivisionUnitDesc;
        string mDepartmentDesc;
        string mLocationDesc;
       // System.Nullable<int> mLocationID;
        bool mActive;
      
		
		public new static string PrimaryKey = ""; 

		#endregion
	
		#region Constructors
		///<summary>
		/// Default Constructor. 
		///</summary>
		public SummaryEmployeeTimeLogEntity()
		{
            mEmployeeID = -1;
            mCardNo = -1;
            mEmployeeNo = string.Empty;
            mFName = string.Empty;
            mLName = string.Empty;           
            mMorningTimeLoss = -1;
            mDayTimeLoss = -1;
            mEndOfDayTimeLoss = -1;
            mRateperHour = -1;
            mBusinessUnitID = null;
            mDivisionUnitID = null;
            mDepartmentID = null;          
            mJobTitle = string.Empty;           
            mBusinessUnitDesc = string.Empty;
            mDivisionUnitDesc = string.Empty;
            mDepartmentDesc = string.Empty;
            mLocationDesc = string.Empty;
            mActive = false;
           // mLocationID = null;
		}
		
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
        public SummaryEmployeeTimeLogEntity(SerializationInfo info, StreamingContext context)
            : base(info, context)
		{
            mEmployeeID = (int)info.GetValue("EmployeeID", typeof(int));
            mCardNo = (Int64)info.GetValue("CardNo", typeof(Int64));
            mEmployeeNo = (string)info.GetValue("EmployeeNo", typeof(string));
            mFName = (string)info.GetValue("FName", typeof(string));
            mLName = (string)info.GetValue("LName", typeof(string));          
            mMorningTimeLoss = (int)info.GetValue("MorningTimeLoss", typeof(int));
            mDayTimeLoss = (int)info.GetValue("DayTimeLoss", typeof(int));
            mEndOfDayTimeLoss = (int)info.GetValue("EndOfDayTimeLoss", typeof(int));
            mRateperHour = (decimal)info.GetValue("RateperHour", typeof(decimal));          
            mBusinessUnitID = (System.Nullable<int>)info.GetValue("BusinessUnitID", typeof(System.Nullable<int>));
            mDivisionUnitID = (System.Nullable<int>)info.GetValue("DivisionUnitID", typeof(System.Nullable<int>));
            mDepartmentID = (System.Nullable<int>)info.GetValue("DepartmentID", typeof(System.Nullable<int>));                     
            mJobTitle = (string)info.GetValue("JobTitle", typeof(string));          
            mBusinessUnitDesc = (string)info.GetValue("mBusinessUnitDesc", typeof(string));
            mDivisionUnitDesc = (string)info.GetValue("DivisionUnitDesc", typeof(string));
            mDepartmentDesc = (string)info.GetValue("DepartmentDesc", typeof(string));
            mLocationDesc = (string)info.GetValue("LocationDesc", typeof(string));
            mActive = (bool)info.GetValue("Active", typeof(bool));
          //  mLocationID = (System.Nullable<int>)info.GetValue("LocationID", typeof(System.Nullable<int>));
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
            info.AddValue("CardNo", mCardNo);
            info.AddValue("EmployeeNo", mEmployeeNo);
            info.AddValue("FName", mFName);
            info.AddValue("LName", mLName);          
            info.AddValue("MorningTimeLoss", mMorningTimeLoss);
            info.AddValue("DayTimeLoss", mDayTimeLoss);
            info.AddValue("EndOfDayTimeLoss", mEndOfDayTimeLoss);
            info.AddValue("RateperHour", mRateperHour);
            info.AddValue("BusinessUnitID", mBusinessUnitID);
            info.AddValue("DivisionUnitID", mDivisionUnitID);
            info.AddValue("DepartmentID", mDepartmentID);
            info.AddValue("BusinessUnitDesc", mBusinessUnitDesc);
            info.AddValue("DivisionUnitDesc", mDivisionUnitDesc);
            info.AddValue("DepartmentDesc", mDepartmentDesc);
            info.AddValue("LocationDesc", mLocationDesc);
            info.AddValue("Active", mActive);
           // info.AddValue("LocationID", mLocationID);
            
		}

		#endregion
		
		#region Properties
		
		#region PK
		
		#endregion		

        [EntityDataProperty("EmployeeID", 4)]
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
       
        [EntityDataProperty("MorningTimeLoss", 4)]
        public int MorningTimeLoss
        {
            get
            {
                return mMorningTimeLoss;
            }
            set
            {
                if (mMorningTimeLoss != value)
                {
                    mMorningTimeLoss = value;
                    this.ValueChanged();
                }
            }
        }
        [EntityDataProperty("DayTimeLoss", 4)]
        public int DayTimeLoss
        {
            get
            {
                return mDayTimeLoss;
            }
            set
            {
                if (mDayTimeLoss != value)
                {
                    mDayTimeLoss = value;
                    this.ValueChanged();
                }
            }
        }
        [EntityDataProperty("EndOfDayTimeLoss", 8)]
        public int EndOfDayTimeLoss
        {
            get
            {
                return mEndOfDayTimeLoss;
            }
            set
            {
                if (mEndOfDayTimeLoss != value)
                {
                    mEndOfDayTimeLoss = value;
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

        [EntityDataProperty("LocationDesc", 50)]
        public string LocationDesc
        {
            get
            {
                return mLocationDesc;
            }
            set
            {
                if (mLocationDesc != value)
                {
                    mLocationDesc = value;
                    this.ValueChanged();
                }
            }
        }

        [EntityDataProperty("Active", 1)]
        public bool Active
        {
            get
            {
                return mActive;
            }
            set
            {
                if (mActive != value)
                {
                    mActive = value;
                    this.ValueChanged();
                }
            }
        }

        //[EntityDataProperty("LocationID", 4)]
        //public System.Nullable<int> LocationID
        //{
        //    get
        //    {
        //        return mLocationID;
        //    }
        //    set
        //    {
        //        if (mLocationID != value)
        //        {
        //            mLocationID = value;
        //            this.ValueChanged();
        //        }
        //    }
        //}

		#endregion
		
	}
} 
