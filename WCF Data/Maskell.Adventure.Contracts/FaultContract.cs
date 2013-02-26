using System;
using System.Runtime.Serialization;

namespace Maskell.Adventure.Contracts
{
	[DataContract(Namespace = "http://expressfinance.paydayexpress.faultcontracts/2011/05", Name = "AdventureFaultContract")]
	public class AdventureFaultContract
	{
		[DataMember]
		public Guid FaultId { get; set; }

		[DataMember]
		public string FaultMessage { get; set; }
	}
}
