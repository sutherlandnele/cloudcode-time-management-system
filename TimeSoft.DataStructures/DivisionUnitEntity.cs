using System;
using System.Runtime.Serialization;
using FijiITC.SolutionInfrastructure.DataStructures;

namespace TimeSoft.DataStructures
{

	/// <summary>
	/// Generated <see cref="EntityBase" /> class. 
	/// </summary>
	[Serializable]
	public class DivisionUnitEntity : EntityBase, ISerializable
	{
		#region Member Variables
		
		int mDivisionUnitID;
        int mBusinessUnitID;
		string mDivisionUnitDesc;
        string mBusinessUnitDesc;
        private bool mActive;
		
		public new static string PrimaryKey = "DivisionUnitID"; 

		#endregion
	
		#region Constructors
		///<summary>
		/// Default Constructor. 
		///</summary>
		public DivisionUnitEntity()
		{
            mDivisionUnitID = -1;
            mBusinessUnitID = -1;
            mDivisionUnitDesc = string.Empty;
            mBusinessUnitDesc = string.Empty;
            mActive = false;
		}
		
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
        public DivisionUnitEntity(SerializationInfo info, StreamingContext context)
            : base(info, context)
		{
            mDivisionUnitID = (int)info.GetValue("DivisionUnitID", typeof(int));
            mBusinessUnitID = (int)info.GetValue("BusinessUnitID", typeof(int));            
            mDivisionUnitDesc = (string)info.GetValue("DivisionUnitID", typeof(string));
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

            info.AddValue("DivisionUnitID", mDivisionUnitID);
            info.AddValue("BusinessUnitID", mBusinessUnitID);
            info.AddValue("DivisionUnitDesc", mDivisionUnitDesc);
            info.AddValue("BusinessUnitDesc", mBusinessUnitDesc);
            info.AddValue("Active", mActive);
		}

		#endregion
		
		#region Properties
		
		#region PK
		
		#endregion

        [EntityDataProperty("DivisionUnitID", 4)]
        public int DivisionUnitID
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


