// $Workfile: NTierBusinessException.cs $
// $JustDate:  2/11/06 $
// $Revision: 2 $
// $NoKeywords: $
using System;
using System.Collections.Generic;
using System.Text;
using FijiITC.SolutionInfrastructure.Exceptions;

namespace TimeSoft.Exceptions
{
	/// <summary>
	/// Encapsulates business rule errors
	/// </summary>
    class TimeSoftBusinessException : BusinessException
	{
		#region Constructors
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="message">Error message</param>
        public TimeSoftBusinessException(string message)
			: base(message)
		{ 
		}
		#endregion
	}
}
