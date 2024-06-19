
using System;
using System.Runtime.Serialization;
using FijiITC.SolutionInfrastructure.DataStructures;

namespace TimeSoft.DataStructures
{
	/// <summary>
	/// Generated <see cref="EntityCollectionBase" /> class.
	/// </summary>
	[Serializable]
	public class BusinessUnitEntityCollection : EntityCollection<BusinessUnitEntity>, ISerializable
	{	
		/// <summary>
		/// Defines the collections Id Column (Primary Key).
		/// </summary> 
		public static readonly string IdColumnName = "BusinessUnitID";  

		#region Constructors
		/// <summary>
		/// Default constructor
		/// </summary>
		public BusinessUnitEntityCollection() : base()
		{
		}

		/// <summary>
		/// Default constructor
		/// </summary>
		/// <param name="info">Serialization information.</param>
		/// <param name="context">Streaming context.</param>
        public BusinessUnitEntityCollection(SerializationInfo info, StreamingContext context)
            : base(info, context)
		{
		}
		#endregion
	}
}
