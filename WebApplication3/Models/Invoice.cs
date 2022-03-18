using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doomkinn.Timesheets.Models
{
    internal class Invoice
    {
        public int Id { get; set; }
        public DateTime DateStart { get; private set; }
        public DateTime DateEnd { get; private set; }
        public int Sum { get; private set; }

        public List<Sheet> Sheets { get; }

        public Invoice()
        {
            Sheets = new List<Sheet>();
        }

        public void IncludeSheets(Sheet sheet)
        {
            Sheets.Add(sheet);
        }
        public void Initialize (DateTime dateStart, int sum)
        {
            this.DateStart = dateStart;
            this.Sum = sum;
        }
    }
}
