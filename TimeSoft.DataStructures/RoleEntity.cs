
using System;
using System.Runtime.Serialization;
using FijiITC.SolutionInfrastructure.DataStructures;

namespace TimeSoft.DataStructures
{

	/// <summary>
	/// Generated <see cref="EntityBase" /> class. 
	/// </summary>
	[Serializable]
	public class RoleEntity : EntityBase, ISerializable
	{
		#region Member Variables
		
		int mRoleID;
		string mRoleDesc;     
		
		public new static string PrimaryKey = "RoleID"; 

		#endregion
	
		#region Constructors
		///<summary>
		/// Default Constructor. 
		///</summary>
		public RoleEntity()
		{
            mRoleID = -1;
            mRoleDesc = string.Empty;        
		}
		
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
        public RoleEntity(SerializationInfo info, StreamingContext context)
            : base(info, context)
		{
            mRoleID = (int)info.GetValue("RoleID", typeof(int));
            mRoleDesc = (string)info.GetValue("RoleDesc", typeof(string));          
           
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

            info.AddValue("RoleID", mRoleID);
            info.AddValue("RoleDesc", mRoleDesc);          
          
		}

		#endregion
		
		#region Properties
		
		#region PK
		
		#endregion
		
		
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
		
		[EntityDataProperty("RoleDesc", 50)]
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

		#endregion
		
	}
} 

