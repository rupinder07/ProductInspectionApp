using Inspections.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inspections.ViewModel
{
    public class InspectionListViewModel
    {
        public InspectionListViewModel()
        {
            Inspections.Add(new Inspection() { Name = "Inspection 1", DueDate = "21-July-2018", Location = "Gurgaon"});
        }

        public List<Inspection> Inspections { get; set; } = new List<Inspection>();
    }
}
