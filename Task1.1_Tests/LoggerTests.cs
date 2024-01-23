using NUnit.Framework;
using Task1_Logger;

namespace Task1._1_Tests
{
    public class LoggerTests : BaseTest
    {

        [Test, Category("Adding Logs"), Order(1)]
        public void Log_General_Message()
        {
            var fileName = "application.log";
            var logMessage = "Basic Generic Log";
            var logType = "Generic";

            Logger.Log_Message(fileName, logMessage, logType);

            Assert.That(ReadFromFile(fileName).Any(str => str.Contains(logMessage)), Is.True);
        }

        [Test, Category("Adding Logs")]
        public void Log_Different_Levels()
        {
            var fileName = "application.log";

            var logs = new Dictionary<string, string>()
            {
                { "INFO", "Testing Info Logging" },
                { "ERROR" , "Testing Error Logging"},
                { "CRITICAL" , "Testing Critical Logging"},
                { "FATAL ERROR" , "Testing Fatal Error Logging"},
            };

            foreach(var log in logs)
            {
                Logger.Log_Message(fileName, log.Value, log.Key);
                Assert.That(ReadFromFile(fileName).Any(str => str.Contains($"[{log.Key}] {log.Value}")), Is.True);
            }
        }

        [Test, Category("Adding Logs")]
        public void Log_Different_Files()
        {
            var firstFileName = "applicationFirst.log";
            var secondFileName = "applicationSecond.txt";

            var logMessage = "Basic Generic Log";
            var logType = "Generic";

            Logger.Log_Message(firstFileName, logMessage, logType);
            Logger.Log_Message(secondFileName, logMessage, logType);

            var existingFirstFileName = Path.GetFileName(Logger.GetFolderPath() + "/" + firstFileName) 
                ?? "NOT_FOUND";
            var existingSecondFileName = Path.GetFileName(Logger.GetFolderPath() + "/" + secondFileName) 
                ?? "NOT_FOUND"; ;

            Assert.Multiple(() =>
            {
                Assert.That(existingFirstFileName, Is.EqualTo(firstFileName));
                Assert.That(existingSecondFileName, Is.EqualTo(secondFileName));
            });
        }

        [Test, Category("Exceptions")]
        public void Fail_Logs_With_Incorrect_File_Format()
        {
            Assert.Throws<InvalidDataException>(() =>
            {
                var fileName = "application.png";
                var logMessage = "Basic Generic Log";
                var logType = "Generic";

                Logger.Log_Message(fileName, logMessage, logType);
            });
        }
    }
}