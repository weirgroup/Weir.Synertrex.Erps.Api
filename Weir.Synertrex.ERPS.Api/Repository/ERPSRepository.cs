// <copyright file="ERPSRepository.cs" company="MicrosoftAndWeir">
// Copyright (c) Microsoft Corporation and Weir PLC.  All rights reserved.
// </copyright>
namespace Weir.Synertrex.ERPS.Api.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using Weir.Synertrex.ERPS.Api.Model;

    /// <summary>
    /// ERPSRepository class
    /// </summary>
    public class ERPSRepository : IERPSRepository
    {
        /// <summary>
        /// Get Device Twin Data from ERPS database
        /// </summary>
        /// <param name="physicalIdentifier">Equipment Physical Identifier</param>
        /// <returns>Collection of Device Twin</returns>
        public List<DeviceTwin> GetDeviceTwinData(string physicalIdentifier)
        {
            List<DeviceTwin> deviceTwins = new List<DeviceTwin>();

            try
            {
                var connectionString = Environment.GetEnvironmentVariable("ConnectionString");

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var query = @"SELECT [Id]
                                       ,[EquipmentId]
                                       ,[PhysicalIdentifier]
                                       ,[DesiredPropertiesDocument]
                                       ,[DesiredPropertiesVersion]
                                       ,[DesiredPropertiesLastUpdated]
                                       ,[ReportedPropertiesDocument]
                                       ,[ReportedPropertiesVersion]
                                       ,[ReportedPropertiesLastUpdated]
                                 FROM [RPS].[ReportedProperties] WHERE 1=1 ";

                    if (!string.IsNullOrWhiteSpace(physicalIdentifier))
                    {
                        query = string.Format("{0} AND PhysicalIdentifier=@PhysicalIdentifier", query);
                    }

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (!string.IsNullOrWhiteSpace(physicalIdentifier))
                        {
                            command.Parameters.Add(new SqlParameter("@PhysicalIdentifier", physicalIdentifier));
                        }

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var deviceTwin = new DeviceTwin();
                                deviceTwin.Id = (long)reader.GetValue(reader.GetOrdinal("Id"));
                                deviceTwin.EquipmentId = (int)reader.GetValue(reader.GetOrdinal("EquipmentId"));
                                deviceTwin.PhysicalIdentifier = (string)reader.GetValue(reader.GetOrdinal("PhysicalIdentifier"));
                                deviceTwin.DesiredPropertiesDocument = reader.IsDBNull(reader.GetOrdinal("DesiredPropertiesDocument")) ? string.Empty : reader.GetValue(reader.GetOrdinal("DesiredPropertiesDocument")).ToString().Replace("\r\n", "").Trim();
                                deviceTwin.DesiredPropertiesVersion = reader.IsDBNull(reader.GetOrdinal("DesiredPropertiesVersion")) ? null : (long?)reader.GetValue(reader.GetOrdinal("DesiredPropertiesVersion"));
                                deviceTwin.DesiredPropertiesLastUpdated = reader.IsDBNull(reader.GetOrdinal("DesiredPropertiesLastUpdated")) ? null : (DateTimeOffset?)reader.GetValue(reader.GetOrdinal("DesiredPropertiesLastUpdated"));
                                deviceTwin.ReportedPropertiesDocument = reader.IsDBNull(reader.GetOrdinal("ReportedPropertiesDocument")) ? string.Empty : (string)reader.GetValue(reader.GetOrdinal("ReportedPropertiesDocument")).ToString().Replace("\r\n", "").Trim();
                                deviceTwin.ReportedPropertiesVersion = reader.IsDBNull(reader.GetOrdinal("ReportedPropertiesVersion")) ? null : (long?)reader.GetValue(reader.GetOrdinal("ReportedPropertiesVersion"));
                                deviceTwin.ReportedPropertiesLastUpdated = reader.IsDBNull(reader.GetOrdinal("ReportedPropertiesLastUpdated")) ? null : (DateTimeOffset?)reader.GetValue(reader.GetOrdinal("ReportedPropertiesLastUpdated"));

                                deviceTwins.Add(deviceTwin);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return deviceTwins;
        }
    }
}
