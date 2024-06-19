
using System;
using System.Runtime.Serialization;
using FijiITC.SolutionInfrastructure.DataStructures;

namespace TimeSoft.DataStructures
{

	/// <summary>
	/// Generated <see cref="EntityBase" /> class. 
	/// </summary>
	[Serializable]
	public class DepartmentEntity : EntityBase, ISerializable
	{
		#region Member Variables
		
		int mDepartmentID;
        int mDivisionUnitID;
        int mBusinessUnitID;
		string mDepartmentDesc;
        string mBusinessUnitDesc;
        string mDivisionUnitDesc;
        private bool mActive;
		
		public new static string PrimaryKey = "DepartmentID"; 

		#endregion
	
		#region Constructors
		///<summary>
		/// Default Constructor. 
		///</summary>
		public DepartmentEntity()
		{
            mDepartmentID = -1;
            mDivisionUnitID = -1;
            mBusinessUnitID = -1;
            mDepartmentDesc = string.Empty;
            mBusinessUnitDesc = string.Empty;
            mDivisionUnitDesc = string.Empty;
            mActive = false;
		}
		
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
        public DepartmentEntity(SerializationInfo info, StreamingContext context)
            : base(info, context)
		{
            mDepartmentID = (int)info.GetValue("DepartmentID", typeof(int));
            mDivisionUnitID = (int)info.GetValue("DivisionUnitID", typeof(int));
            mBusinessUnitID = (int)info.GetValue("BusinessUnitID", typeof(int));   
            mDepartmentDesc = (string)info.GetValue("DepartmentID", typeof(string));
            mBusinessUnitDesc = (string)info.GetValue("BusinessUnitDesc", typeof(string));
             mDivisionUnitDesc = (string)info.GetValue("DivisionUnitDesc", typeof(string));
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

            info.AddValue("DepartmentID", mDepartmentID);
            info.AddValue("DivisionUnitID", mDivisionUnitID);
            info.AddValue("BusinessUnitID", mBusinessUnitID);
            info.AddValue("DepartmentDesc", mDepartmentDesc);
            info.AddValue("BusinessUnitDesc", mBusinessUnitDesc);
            info.AddValue("DivisionUnitDesc", mDivisionUnitDesc);
            info.AddValue("Active", mActive);
		}

		#endregion
		
		#region Properties
		
		#region PK
		
		#endregion

        [EntityDataProperty("DepartmentID", 4)]
        public int DepartmentID
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


