// <copyright file="IERPSRepository.cs" company="MicrosoftAndWeir">
// Copyright (c) Microsoft Corporation and Weir PLC.  All rights reserved.
// </copyright>
namespace Weir.Synertrex.ERPS.Api.Repository
{
    using System.Collections.Generic;
    using Weir.Synertrex.ERPS.Api.Model;

    /// <summary>
    /// IERPSRepository interface
    /// </summary>
    public interface IERPSRepository
    {
        /// <summary>
        /// Get Device Twin Data from ERPS database
        /// </summary>
        /// <param name="physicalIdentifier">Equipment Physical Identifier</param>
        /// <returns>Collection of Device Twin</returns>
        List<DeviceTwin> GetDeviceTwinData(string physicalIdentifier);
    }
}