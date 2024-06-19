
using System;
using System.Runtime.Serialization;
using FijiITC.SolutionInfrastructure.DataStructures;

namespace TimeSoft.DataStructures
{

	/// <summary>
	/// Generated <see cref="EntityBase" /> class. 
	/// </summary>
	[Serializable]
	public class EmployeeTimeLogEntity : EntityBase, ISerializable
	{
		#region Member Variables
		Int64 mTimeMasterID;
        Int64 mCardNo;
		string mFName;
		string mLName;					
		System.Nullable<DateTime> mDateTimeIn;
		System.Nullable<DateTime> mDateTimeOut	;
		string mDoorIn;
		string mDoorOut;
		int mMorningTimeLoss;
		int mDayTimeLoss	;
	    int mEndOfDayTimeLoss;
		string mError;
		string mEmployeeNo;
        //decimal mRateperHour	;		
        //string mBusinessUnitDesc;
        //string mDivisionDesc;
        //string mDepartmentDesc;
        //string mSectionDesc	;
        //string mLocationDesc;	
		
		public new static string PrimaryKey = "TimeManagerID"; 

		#endregion
	
		#region Constructors
		///<summary>
		/// Default Constructor. 
		///</summary>
		public EmployeeTimeLogEntity()
		{
            mTimeMasterID = -1;
            mCardNo = -1;
            mFName = string.Empty;
            mLName = string.Empty;
            mDateTimeIn = null;
            mDateTimeOut = null;
            mDoorIn = string.Empty;
            mDoorOut = string.Empty;
            mMorningTimeLoss = -1;
            mDayTimeLoss = -1;
            mEndOfDayTimeLoss = -1;
            mError = string.Empty;
            mEmployeeNo = string.Empty;
            //mRateperHour = -1;
            //mBusinessUnitDesc = string.Empty;
            //mDivisionDesc = string.Empty;
            //mDepartmentDesc = string.Empty;
            //mSectionDesc = string.Empty;
            //mLocationDesc = string.Empty;				
		}
		
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
        public EmployeeTimeLogEntity(SerializationInfo info, StreamingContext context)
            : base(info, context)
		{
            mTimeMasterID = (Int64)info.GetValue("TimeMasterID", typeof(Int64));
            mCardNo = (Int64)info.GetValue("CardNo", typeof(Int64));
            mFName = (string)info.GetValue("FName", typeof(string));
            mLName = (string)info.GetValue("LName", typeof(string));
            mDateTimeIn = (System.Nullable<DateTime>)info.GetValue("DateTimeIn", typeof(System.Nullable<DateTime>));
            mDateTimeOut = (System.Nullable<DateTime>)info.GetValue("DateTimeOut", typeof(System.Nullable<DateTime>));
            mDoorIn = (string)info.GetValue("DoorIn", typeof(string));
            mDoorOut = (string)info.GetValue("DoorOut", typeof(string));
            mMorningTimeLoss = (int)info.GetValue("MorningTimeLoss", typeof(int));
            mDayTimeLoss = (int)info.GetValue("DayTimeLoss", typeof(int));
            mEndOfDayTimeLoss = (int)info.GetValue("EndOfDayTimeLoss", typeof(int));
            mError = (string)info.GetValue("Error", typeof(string));
            mEmployeeNo = (string)info.GetValue("EmployeeNo", typeof(string));
            //mRateperHour = (decimal)info.GetValue("RateperHour", typeof(decimal));
            //mBusinessUnitDesc = (string)info.GetValue("mBusinessUnitDesc", typeof(string));
            //mDivisionDesc = (string)info.GetValue("DivisionDesc", typeof(string));
            //mDepartmentDesc = (string)info.GetValue("DepartmentDesc", typeof(string));
            //mSectionDesc = (string)info.GetValue("SectionDesc", typeof(string));
            //mLocationDesc = (string)info.GetValue("LocationDesc", typeof(string));
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

            info.AddValue("TimeMasterID", mTimeMasterID);
            info.AddValue("CardNo", mCardNo);
            info.AddValue("FName", mFName);
            info.AddValue("LName", mLName);
            info.AddValue("DateTimeIn", mDateTimeIn);
            info.AddValue("DateTimeOut", mDateTimeOut);
            info.AddValue("DoorIn", mDoorIn);
            info.AddValue("DoorOut", mDoorOut);
            info.AddValue("MorningTimeLoss", mMorningTimeLoss);
            info.AddValue("DayTimeLoss", mDayTimeLoss);
            info.AddValue("EndOfDayTimeLoss", mEndOfDayTimeLoss);
            info.AddValue("Error", mError);
            info.AddValue("EmployeeNo", mEmployeeNo);
            //info.AddValue("RateperHour", mRateperHour);
            //info.AddValue("BusinessUnitDesc", mBusinessUnitDesc);
            //info.AddValue("DivisionDesc", mDivisionDesc);
            //info.AddValue("DepartmentDesc", mDepartmentDesc);
            //info.AddValue("SectionDesc", mSectionDesc);
            //info.AddValue("LocationDesc", mLocationDesc);
		}

		#endregion
		
		#region Properties
		
		#region PK
		
		#endregion
		
		
		[EntityDataProperty("TimeMasterID", 8)]
        public Int64 TimeMasterID
		{
			get
			{
                return mTimeMasterID;
			}
			set
			{
                if (mTimeMasterID != value)
				{
                    mTimeMasterID = value;
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
        [EntityDataProperty("DateTimeIn", 8)]
        public System.Nullable<DateTime> DateTimeIn
        {
            get
            {
                return mDateTimeIn;
            }
            set
            {
                if (mDateTimeIn != value)
                {
                    mDateTimeIn = value;
                    this.ValueChanged();
                }
            }
        }
        [EntityDataProperty("DateTimeOut", 8)]
        public System.Nullable<DateTime> DateTimeOut
        {
            get
            {
                return mDateTimeOut;
            }
            set
            {
                if (mDateTimeOut != value)
                {
                    mDateTimeOut = value;
                    this.ValueChanged();
                }
            }
        }
        [EntityDataProperty("DoorIn", 50)]
        public string DoorIn
        {
            get
            {
                return mDoorIn;
            }
            set
            {
                if (mDoorIn != value)
                {
                    mDoorIn = value;
                    this.ValueChanged();
                }
            }
        }
        [EntityDataProperty("DoorOut", 50)]
        public string DoorOut
        {
            get
            {
                return mDoorOut;
            }
            set
            {
                if (mDoorOut != value)
                {
                    mDoorOut= value;
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
        [EntityDataProperty("Error", 255)]
        public string Error
        {
            get
            {
                return mError;
            }
            set
            {
                if (mError != value)
                {
                    mError = value;
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
        //[EntityDataProperty("RateperHour", 8)]
        //public decimal RateperHour
        //{
        //    get
        //    {
        //        return mRateperHour;
        //    }
        //    set
        //    {
        //        if (mRateperHour != value)
        //        {
        //            mRateperHour = value;
        //            this.ValueChanged();
        //        }
        //    }
        //}

        //[EntityDataProperty("BusinessUnitDesc", 50)]
        //public string BusinessUnitDesc
        //{
        //    get
        //    {
        //        return mBusinessUnitDesc;
        //    }
        //    set
        //    {
        //        if (mBusinessUnitDesc != value)
        //        {
        //            mBusinessUnitDesc = value;
        //            this.ValueChanged();
        //        }
        //    }
        //}
        //[EntityDataProperty("DivisionDesc", 50)]
        //public string DivisionDesc
        //{
        //    get
        //    {
        //        return mDivisionDesc;
        //    }
        //    set
        //    {
        //        if (mDivisionDesc != value)
        //        {
        //            mDivisionDesc = value;
        //            this.ValueChanged();
        //        }
        //    }
        //}
        //[EntityDataProperty("DepartmentDesc", 50)]
        //public string DepartmentDesc
        //{
        //    get
        //    {
        //        return mDepartmentDesc;
        //    }
        //    set
        //    {
        //        if (mDepartmentDesc != value)
        //        {
        //            mDepartmentDesc = value;
        //            this.ValueChanged();
        //        }
        //    }
        //}
        //[EntityDataProperty("SectionDesc", 50)]
        //public string SectionDesc
        //{
        //    get
        //    {
        //        return mSectionDesc;
        //    }
        //    set
        //    {
        //        if (mSectionDesc != value)
        //        {
        //            mSectionDesc = value;
        //            this.ValueChanged();
        //        }
        //    }
        //}
        //[EntityDataProperty("LocationDesc", 50)]
        //public string LocationDesc
        //{
        //    get
        //    {
        //        return mLocationDesc;
        //    }
        //    set
        //    {
        //        if (mLocationDesc != value)
        //        {
        //            mLocationDesc = value;
        //            this.ValueChanged();
        //        }
        //    }
        //}


		#endregion
		
	}
} 
