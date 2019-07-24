using Library.Application.Data;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Library.Infrastructure.Data
{
    /// <summary>
    /// This class contains all the versions of script used in common. This way we can easily see wich number to use the next time.
    /// The order of execution doen't depend on the number, but i could be. Each database manager should take care of the order of execution.
    /// Most important thing is that the versions (script numbers) are unique.
    /// </summary>
    public static class LibraryScriptVersions
    {
        public const string V00000000001 = "00000000001";
        public const string V00000000002 = "00000000002";
        public const string V00000000003 = "00000000003";
        public const string V00000000004 = "00000000004";
        public const string V00000000005 = "00000000005";
        public const string V00000000006 = "00000000006";
        public const string V00000000007 = "00000000007";
        public const string V00000000008 = "00000000008";
    }

    public class DatabaseManager
    {
        public const string DefaultNameOrConnectionString = "DefaultDatabase";
        private const string UpdatescriptFilesSearchPattern = @"Updatescript_v*_*_*.sql";
        private static readonly Encoding ExpectedScriptEncoding = Encoding.BigEndianUnicode;

        private string ConnectionString { get; }

        public DatabaseManager(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void ExecuteNonQuery(string scriptContent)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var queries = Regex.Split(scriptContent + "\n", @"^\s*GO\s*$", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                        queries = queries.Where(_ => !string.IsNullOrWhiteSpace(_)).ToArray();
                        foreach (var query in queries)
                        {
                            using (var command = connection.CreateCommand())
                            {
                                command.Transaction = transaction;
                                command.CommandText = query;
                                command.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                    }
                    catch (SqlException)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Initialize()
        {
            UpdateFromScripts();
        }

        protected void UpdateFromScripts()
        {
            CreateDatabaseVersionHistoryTableIfNotExists();

            var updatescriptsFolder = new DirectoryInfo(AppContext.BaseDirectory);
            var updatescriptFilesToExecuteOrderedByName = updatescriptsFolder
                                                            .GetFiles(UpdatescriptFilesSearchPattern, SearchOption.AllDirectories)
                                                            .Select(UpdatescriptFileInfo.GetFrom)
                                                            .OrderBy(_ => _.FileInfo.Name)
                                                            .ToArray();

            foreach (var updatescriptFile in updatescriptFilesToExecuteOrderedByName)
            {
                if (ContainsVersion(updatescriptFile.Version)) { continue; }

                UpdateToVersion(updatescriptFile);
            }
        }

        protected void CreateDatabaseVersionHistoryTableIfNotExists()
        {
            #region getLatestVersionScript
            const string getLatestVersionScript = @"
            IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '_Application_DatabaseVersionHistory'))
            BEGIN
                CREATE TABLE [_Application_DatabaseVersionHistory](
                    [Id] [int] IDENTITY(1,1) NOT NULL,
                    [CreatedOn] [datetime] NOT NULL,
                    [Version] [varchar](14) NOT NULL,
                    [Comment] [varchar](max) NULL,
                    CONSTRAINT [PK__Application_DatabaseVersionHistory] PRIMARY KEY CLUSTERED ([Id] ASC),
                    CONSTRAINT [UC_Version] UNIQUE ([Version])
                )
                INSERT INTO [_Application_DatabaseVersionHistory]([CreatedOn], [Version] ,[Comment])
                VALUES (GETDATE(), '" + LibraryScriptVersions.V00000000001 + @"', 'Created table _Application_DatabaseVersionHistory')
            END
            ";
            #endregion

            ExecuteNonQuery(getLatestVersionScript);
        }

        protected bool ContainsVersion(string version)
        {
            var getVersionScript = $"SELECT * FROM [_Application_DatabaseVersionHistory] WHERE [Version] = '{version}'";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = getVersionScript;
                var resultReader = command.ExecuteReader();

                return resultReader.HasRows;
            }
        }

        private void UpdateToVersion(UpdatescriptFileInfo updatescriptFile)
        {
            var updatescriptFromFile = GetScriptFromFileWithExpectedEncoding(updatescriptFile.FileInfo, ExpectedScriptEncoding);

            UpdateToVersion(updatescriptFromFile, updatescriptFile.Version, updatescriptFile.Comment);
        }

        protected void UpdateToVersion(string updatescript, string version, string comment = "")
        {
            var updatescriptWithUpdateVersion = $"{updatescript}{Environment.NewLine}{Environment.NewLine}GO{Environment.NewLine}" +
                                                $"INSERT INTO [_Application_DatabaseVersionHistory]([CreatedOn], [Version] ,[Comment]) {Environment.NewLine}" +
                                                $"VALUES (GETDATE(), '{version}', '{comment}')";

            ExecuteNonQuery(updatescriptWithUpdateVersion);
        }

        private static string GetScriptFromFileWithExpectedEncoding(FileSystemInfo file, Encoding expectedScriptEncoding)
        {
            string scriptText;
            using (var streamReader = new StreamReader(File.Open(file.FullName, FileMode.Open, FileAccess.Read), detectEncodingFromByteOrderMarks: true))
            {
                //Important: It looks like the correct encoding is detected after reading the content of the file.
                //           It takes the default (UTF-8) encoding as CurrentEncoding if the following line isn't executed first!
                scriptText = streamReader.ReadToEnd();

                if (!streamReader.CurrentEncoding.Equals(expectedScriptEncoding))
                {
                    throw new Exception(
                        $"The file '{file.FullName}' is saved with {streamReader.CurrentEncoding.EncodingName}" +
                        $"(Codepage: {streamReader.CurrentEncoding.CodePage}) encoding or the encoding couldn't be detected. " +
                        $"To read this file correctly you should save the file with the {expectedScriptEncoding.EncodingName}" +
                        $"(Codepage: {expectedScriptEncoding.CodePage}) encoding!");
                }
            }

            return scriptText;
        }
    }
}
