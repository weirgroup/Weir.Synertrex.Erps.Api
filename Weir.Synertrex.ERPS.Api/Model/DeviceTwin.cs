namespace Weir.Synertrex.ERPS.Api.Model
{
    using System;

    public class DeviceTwin
    {
        public long Id { get; set; }
        public int? EquipmentId { get; set; }
        public string PhysicalIdentifier { get; set; }
        public string DesiredPropertiesDocument { get; set; }
        public long? DesiredPropertiesVersion { get; set; }
        public DateTimeOffset? DesiredPropertiesLastUpdated { get; set; }
        public string ReportedPropertiesDocument { get; set; }
        public long? ReportedPropertiesVersion { get; set; }
        public DateTimeOffset? ReportedPropertiesLastUpdated { get; set; }        
    }
}
