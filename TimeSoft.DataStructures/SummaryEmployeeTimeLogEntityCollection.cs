
using System;
using System.Runtime.Serialization;
using FijiITC.SolutionInfrastructure.DataStructures;

namespace TimeSoft.DataStructures
{
	/// <summary>
	/// Generated <see cref="EntityCollectionBase" /> class.
	/// </summary>
	[Serializable]
	public class SummaryEmployeeTimeLogEntityCollection : EntityCollection<SummaryEmployeeTimeLogEntity>, ISerializable
	{	
		/// <summary>
		/// Defines the collections Id Column (Primary Key).
		/// </summary> 
		public static readonly string IdColumnName = "";  

		#region Constructors
		/// <summary>
		/// Default constructor
		/// </summary>
		public SummaryEmployeeTimeLogEntityCollection() : base()
		{
		}

		/// <summary>
		/// Default constructor
		/// </summary>
		/// <param name="info">Serialization information.</param>
		/// <param name="context">Streaming context.</param>
        public SummaryEmployeeTimeLogEntityCollection(SerializationInfo info, StreamingContext context)
            : base(info, context)
		{
		}
		#endregion
	}
}
