//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AircraftControl.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblAircraftModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblAircraftModel()
        {
            this.tblAircrafts = new HashSet<tblAircraft>();
        }
    
        public int ID_AIRCRAFTMODEL { get; set; }
        public string CODE { get; set; }
        public string ALTERNATIVE_CODE { get; set; }
        public decimal MAX_DEPARTURE_WEIGHT { get; set; }
        public decimal MAX_LANDING_WEIGHT { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAircraft> tblAircrafts { get; set; }
    }
}
