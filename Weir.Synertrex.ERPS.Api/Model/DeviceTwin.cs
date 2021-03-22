// <copyright file="DeviceTwin.cs" company="MicrosoftAndWeir">
// Copyright (c) Microsoft Corporation and Weir PLC.  All rights reserved.
// </copyright>

namespace Weir.Synertrex.ERPS.Api.Model
{
    using System;

    public class DeviceTwin
    {
        /// <summary>
        /// Gets or sets Identity
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets Equipment Identity
        /// </summary>
        public int? EquipmentId { get; set; }

        /// <summary>
        /// Gets or sets Equipment Physical Identifier
        /// </summary>
        public string PhysicalIdentifier { get; set; }

        /// <summary>
        /// Gets or sets Desired Properties Document
        /// </summary>
        public string DesiredPropertiesDocument { get; set; }

        /// <summary>
        /// Gets or sets Desired Properties Version
        /// </summary>
        public long? DesiredPropertiesVersion { get; set; }

        /// <summary>
        /// Gets or sets Desired Properties Last Updated
        /// </summary>
        public DateTimeOffset? DesiredPropertiesLastUpdated { get; set; }

        /// <summary>
        /// Gets or sets Reported Properties Document
        /// </summary>
        public string ReportedPropertiesDocument { get; set; }

        /// <summary>
        /// Gets or sets Reported Properties Version
        /// </summary>
        public long? ReportedPropertiesVersion { get; set; }

        /// <summary>
        /// Gets or sets Reported Properties Last Updated
        /// </summary>
        public DateTimeOffset? ReportedPropertiesLastUpdated { get; set; }        
    }
}
