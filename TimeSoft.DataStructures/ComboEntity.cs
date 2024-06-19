using System;
using System.Runtime.Serialization;
using FijiITC.SolutionInfrastructure.DataStructures;

namespace TimeSoft.DataStructures
{

	/// <summary>
	/// Generated <see cref="EntityBase" /> class. 
	/// </summary>
	[Serializable]
	public class ComboEntity : EntityBase, ISerializable
	{
		#region Member Variables
		private int mComboID;
		private string mComboDesc;
		
		
		public new static string PrimaryKey = "ID"; 

		#endregion
	
		#region Constructors
		///<summary>
		/// Default Constructor. 
		///</summary>
		public ComboEntity()
		{
			mComboID = -1;
			mComboDesc = string.Empty;			
		}		
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
        public ComboEntity(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            mComboID = (int)info.GetValue("ComboID", typeof(int));
            mComboDesc = (string)info.GetValue("ComboDesc", typeof(string));
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
            info.AddValue("ComboID", mComboID);
            info.AddValue("ComboDesc", mComboDesc);

        }

		#endregion
		
		#region Properties
		
		#region PK
	
		#endregion
		
		/// <summary>
		/// Gets/Sets the ComboID.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		[EntityDataProperty("ComboID", 4)]
		public int ComboID
		{
			get
			{
				return mComboID;
			}
			set
			{
                if (mComboID != value)
				{
                    mComboID = value;
					this.ValueChanged();
				}
			}
		}

		/// <summary>
		/// Gets/Sets the ComboDesc.
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		[EntityDataProperty("ComboDesc", 50)]
		public string ComboDesc
		{
			get
			{
				return mComboDesc;
			}
			set
			{
				if (mComboDesc != value)
				{
					mComboDesc = value;
					this.ValueChanged();
				}
			}
		}

		#endregion
		
		
	}
} 
