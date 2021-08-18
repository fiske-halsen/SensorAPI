using MySqlConnector;

using System;


interface ISerializable<T>
{
    public static string Query;
    //public void Serialize(SqlDataReader reader);
    public T Deserialize(MySqlDataReader reader);
}

namespace SensorAPI.models

{
    public class Report : ISerializable<Report>
    {
        public static string Query =
                "SELECT * FROM Report";

        public int Id { get; set; }
        public int ReportTypeId { get; set; }
        public string Name { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }
        public string DisplayDataTimeZoneID { get; set; }
        public string VariableValuesJson { get; set; }

        public Report Deserialize(MySqlDataReader reader)
        {
            this.Id = reader.GetInt32(reader.GetOrdinal("ID"));
            this.ReportTypeId = reader.GetInt32(reader.GetOrdinal("ReportTypeID"));

            reader.NextResult();

            return this;
        }

    }

    public class SampleData : ISerializable<SampleData>
    {

        public static string Query =
                @"SELECT 
                    Sample.ID as SampleId,
                    SensorChannel.ID as SensorChannelId, 
                    SensorChannel.Name as SensorName, 
                    Sample.Value as SampleValue, 
                    Sample.Time as SampleTimeStamp, 
                    MeasurementType.Name as MeasurementTypeName, 
                    Site.Name as SiteName, 
                    Site.Address, 
                    Site.PostCode as ZipCode 
                FROM Sample
                INNER JOIN
                SensorChannel ON Sample.SensorChannelID = SensorChannel.ID
                INNER JOIN
                MeasurementType ON SensorChannel.MeasurementTypeID = MeasurementType.ID
                INNER JOIN
                ZoneSensorChannelAllocation ON SensorChannel.ID = ZoneSensorChannelAllocation.ChannelID
                INNER JOIN
                Zone ON ZoneSensorChannelAllocation.ZoneID = Zone.ID
                INNER JOIN
                Site ON Zone.SiteID = Site.ID";

        public int SampleId { get; set; }
        public int SensorId { get; set; }
        public string SensorName { get; set; }
        public string SampleValue { get; set; }
        public DateTime SampleTimeStamp { get; set; }
        public string MeasurementType { get; set; }
        public string SiteName { get; set; }
        public string SiteAddress { get; set; }
        public int ZipCode { get; set; }


        public SampleData Deserialize(MySqlDataReader reader)
        {

            this.SampleId = reader.GetInt32("SampleId");
            this.SensorId = reader.GetInt32(reader.GetOrdinal("SensorChannelId"));
            //this.SensorName = reader.GetString(reader.GetOrdinal("SensorName"));
            //this.SampleValue = reader.GetString(reader.GetOrdinal("SampleValue"));
            //this.SampleTimeStamp = DateTime.Parse(reader.GetString(reader.GetOrdinal("SampleTimeStamp")));
            //this.MeasurementType = reader.GetString(reader.GetOrdinal("MeasurementTypeName"));
            //this.SiteName = reader.GetString(reader.GetOrdinal("SiteName"));
            //this.SiteAddress = reader.GetString(reader.GetOrdinal("Address"));
            //this.ZipCode = reader.GetInt32(reader.GetOrdinal("ZipCode"));

            

            return this;

        }

      
    }






}
