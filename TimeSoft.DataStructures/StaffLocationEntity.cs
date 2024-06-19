using System;
using System.Runtime.Serialization;
using FijiITC.SolutionInfrastructure.DataStructures;

namespace TimeSoft.DataStructures
{

	/// <summary>
	/// Generated <see cref="EntityBase" /> class. 
	/// </summary>
	[Serializable]
	public class StaffLocationEntity : EntityBase, ISerializable
	{
		#region Member Variables
		
		int mStaffLocationID;
		string mStaffLocationDesc;
        bool mActive;
		
		public new static string PrimaryKey = "StaffLocationID"; 

		#endregion
	
		#region Constructors
		///<summary>
		/// Default Constructor. 
		///</summary>
		public StaffLocationEntity()
		{
            mStaffLocationID = -1;
            mStaffLocationDesc = string.Empty;
            mActive = false;
		}
		
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
        public StaffLocationEntity(SerializationInfo info, StreamingContext context)
            : base(info, context)
		{
            mStaffLocationID = (int)info.GetValue("StaffLocationID", typeof(int));
            mStaffLocationDesc = (string)info.GetValue("StaffLocationDesc", typeof(string));
            mActive = (bool)info.GetValue("Active", typeof(bool));
           
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

            info.AddValue("StaffLocationID", mStaffLocationID);
            info.AddValue("StaffLocationDesc", mStaffLocationDesc);
            info.AddValue("Active", mActive);
          
		}

		#endregion
		
		#region Properties
		
		#region PK
		
		#endregion
		
		
		[EntityDataProperty("StaffLocationID", 4)]
        public int StaffLocationID
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

		#endregion
		
	}
} 

