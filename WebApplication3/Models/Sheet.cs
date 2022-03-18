using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doomkinn.Timesheets.Models
{
    internal class Sheet
    {
		public int Id { get; private set; }
		public DateTime ApproveDate { get; private set; }
		public bool IsApproved { get; private set; }
		public int Amount { get; set; }

		public void Approve()
		{
			IsApproved = true;
			ApproveDate = DateTime.Now;
		}

	}
}
