using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreightMicroservice.Domain
{
    public class FreightModel
    {
		public int Id { get; private set; }
		public string Location { get; private set; }
		public string Destination { get; private set; }
		public string Cargo { get; private set; }
		public int Status { get; private set; }
		public int Payment { get; private set; }

        public FreightModel(string location, string destination, string cargo, int status, int payment)
        {
			Location = location;
			Destination = destination;
			Cargo = cargo;
			Status = status;
			Payment = payment;
        }

		public void ChangeStatus(int status)
        {
			Status = status;
        }
	}
}
