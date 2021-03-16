using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Weir.Synertrex.ERPS.Api.Model;

namespace Weir.Synertrex.ERPS.Api.Repository
{
    public class ERPSRepository : IERPSRepository
    {
        public List<DeviceTwin> GetDeviceTwinsData()
        {
            List<DeviceTwin> deviceTwins = new List<DeviceTwin>();

            try
            {
                var connectionString = Environment.GetEnvironmentVariable("ConnectionString");

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var text = @"SELECT [Id]
                                  ,[EquipmentId]
                                  ,[PhysicalIdentifier]
                                  ,[DesiredPropertiesDocument]
                                  ,[DesiredPropertiesVersion]
                                  ,[DesiredPropertiesLastUpdated]
                                  ,[ReportedPropertiesDocument]
                                  ,[ReportedPropertiesVersion]
                                  ,[ReportedPropertiesLastUpdated]
                               FROM [RPS].[ReportedProperties]";

                    using (SqlCommand command = new SqlCommand(text, connection))
                    {
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
