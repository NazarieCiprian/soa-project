using System;
using System.Collections.Generic;
using System.Text;

namespace FreightApp.Core.Model
{
    public class FreightModel
    {
		public int Id { get;  set; }
		public string Location { get;  set; }
		public string Destination { get;  set; }
		public string Cargo { get;  set; }
		public int Status { get;  set; }
		public int Payment { get;  set; }
		public FreightModel()
        {

        }
		public FreightModel(int id, string location, string destination, string cargo, int status, int payment)
		{
			Id = id;
			Location = location;
			Destination = destination;
			Cargo = cargo;
			Status = status;
			Payment = payment;
		}
	}
}
