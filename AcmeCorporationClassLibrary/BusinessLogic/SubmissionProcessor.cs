using AcmeCorporationClassLibrary.DataAccess;
using AcmeCorporationClassLibrary.Models;
using System;
using System.Collections.Generic;

namespace AcmeCorporationClassLibrary.BusinessLogic
{
    public static class SubmissionProcessor
    {
        public static string CreateSubmission(string firstName, string lastName,
            string emailAddress, Guid serialNumber)
        {
            if (!CheckSerialNumberExists(serialNumber))
            {
                return "That is not a valid Serial Number.";
            }
            else if (!CheckSerialNumberSubmissionCount(serialNumber))
            {
                return "This Serial Number has already been redeemed twice.";
            }

            SubmissionModel submissionData = new SubmissionModel
            {
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = emailAddress,
                SerialNumber = serialNumber
            };

            string sqlQuery = @"INSERT INTO dbo.Submission (FirstName, LastName, EmailAddress, SerialNumber)
                                VALUES (@FirstName, @LastName, @EmailAddress, @SerialNumber);";

            int rowsInserted = DBDataAccess.SaveData<SubmissionModel>(sqlQuery, submissionData);

            return rowsInserted == 1 ? "Submission Successful!" : "There seems to be a problem, try submitting again.";
        }

        public static bool CheckSerialNumberExists(Guid serialNumber)
        {
            string sqlQuery = @"SELECT COUNT(*)
                                FROM dbo.Product
                                WHERE SerialNumber = @SerialNumber;";

            int serialExists = DBDataAccess.CountData(sqlQuery, new { SerialNumber = serialNumber });

            return serialExists == 1;
        }

        public static bool CheckSerialNumberSubmissionCount(Guid serialNumber)
        {
            string sqlQuery = @"SELECT COUNT(*)
                                FROM dbo.Submission
                                WHERE SerialNumber = @SerialNumber;";

            int serialExists = DBDataAccess.CountData(sqlQuery, new { SerialNumber = serialNumber });

            return serialExists != 2;
        }

        public static List<SubmissionModel> LoadSubmissions()
        {
            string sqlQuery = @"SELECT FirstName, LastName, EmailAddress
                                FROM dbo.Submission;";

            return DBDataAccess.LoadData<SubmissionModel>(sqlQuery);
        }

        public static string DeleteSubmissionBySerial(Guid serialNumber)
        {
            string sqlQuery = @"DELETE FROM dbo.Submission 
                                WHERE SerialNumber = @SerialNumber;";

            int rowsDeleted = DBDataAccess.DeleteData(sqlQuery, new { SerialNumber = serialNumber });

            return rowsDeleted + " rows deleted.";
        }
    }
}
