using System;
using System.Runtime.Serialization;
using FijiITC.SolutionInfrastructure.DataStructures;

namespace TimeSoft.DataStructures
{

	/// <summary>
	/// Generated <see cref="EntityBase" /> class. 
	/// </summary>
	[Serializable]
	public class BusinessUnitEntity : EntityBase, ISerializable
	{
		#region Member Variables
		
		int mBusinessUnitID;
		string mBusinessUnitDesc;
        bool mActive;
		
		public new static string PrimaryKey = "BusinessUnitID"; 

		#endregion
	
		#region Constructors
		///<summary>
		/// Default Constructor. 
		///</summary>
		public BusinessUnitEntity()
		{
            mBusinessUnitID = -1;
            mBusinessUnitDesc = string.Empty;
            mActive = false;
		}
		
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
        public BusinessUnitEntity(SerializationInfo info, StreamingContext context)
            : base(info, context)
		{
            mBusinessUnitID = (int)info.GetValue("BusinessUnitID", typeof(int));
            mBusinessUnitDesc = (string)info.GetValue("BusinessUnitDesc", typeof(string));
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

            info.AddValue("BusinessUnitID", mBusinessUnitID);
            info.AddValue("BusinessUnitDesc", mBusinessUnitDesc);
            info.AddValue("Active", mActive);
          
		}

		#endregion
		
		#region Properties
		
		#region PK
		
		#endregion
		
		
		[EntityDataProperty("BusinessUnitID", 4)]
        public int BusinessUnitID
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

