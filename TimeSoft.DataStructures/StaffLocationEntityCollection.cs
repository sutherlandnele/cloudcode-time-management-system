
using System;
using System.Runtime.Serialization;
using FijiITC.SolutionInfrastructure.DataStructures;

namespace TimeSoft.DataStructures
{
	/// <summary>
	/// Generated <see cref="EntityCollectionBase" /> class.
	/// </summary>
	[Serializable]
	public class StaffLocationEntityCollection : EntityCollection<StaffLocationEntity>, ISerializable
	{	
		/// <summary>
		/// Defines the collections Id Column (Primary Key).
		/// </summary> 
		public static readonly string IdColumnName = "StaffLocationID";  

		#region Constructors
		/// <summary>
		/// Default constructor
		/// </summary>
		public StaffLocationEntityCollection() : base()
		{
		}

		/// <summary>
		/// Default constructor
		/// </summary>
		/// <param name="info">Serialization information.</param>
		/// <param name="context">Streaming context.</param>
        public StaffLocationEntityCollection(SerializationInfo info, StreamingContext context)
            : base(info, context)
		{
		}
		#endregion
	}
}
