
using System;
using System.Runtime.Serialization;
using FijiITC.SolutionInfrastructure.DataStructures;

namespace TimeSoft.DataStructures
{
	/// <summary>
	/// Generated <see cref="EntityCollectionBase" /> class.
	/// </summary>
	[Serializable]
	public class EmployeeTimeLogEntityCollection : EntityCollection<EmployeeTimeLogEntity>, ISerializable
	{	
		/// <summary>
		/// Defines the collections Id Column (Primary Key).
		/// </summary> 
		public static readonly string IdColumnName = "TimeMasterID";  

		#region Constructors
		/// <summary>
		/// Default constructor
		/// </summary>
		public EmployeeTimeLogEntityCollection() : base()
		{
		}

		/// <summary>
		/// Default constructor
		/// </summary>
		/// <param name="info">Serialization information.</param>
		/// <param name="context">Streaming context.</param>
        public EmployeeTimeLogEntityCollection(SerializationInfo info, StreamingContext context)
            : base(info, context)
		{
		}
		#endregion
	}
}