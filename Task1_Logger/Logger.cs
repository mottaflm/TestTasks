using System.Text;

namespace Task1_Logger
{
    public static class Logger
    {
        public static void Log_Message(string fileName, string logMessage, string logType)
        {
            if (!(fileName.EndsWith(".log") || fileName.EndsWith(".txt")))
                throw new InvalidDataException("Invalid File Format!");

            var log = new Log(logMessage, logType.ToUpper());
            var dateTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            var filePath = GetFolderPath() + "/" + fileName;

            using var stream = File.Open(filePath, FileMode.Append);
            using var writer = new StreamWriter(stream, Encoding.Default);

            writer.WriteLine($"[{dateTime}] [{log.Type}] {log.Message}");
            writer.Flush();
        }

        public static string GetFolderPath() => @$"../../../..";

        private class Log
        {
            private string _message;
            private string _type;

            public string Message
            {
                get => _message ??= "UNAVAILABLE_MESSAGE";
                set
                {
                    if (_message != value)
                        _message = value;
                }
            }

            public string Type
            {
                get => _type ??= "UNAVAILABLE_TYPE";
                set
                {
                    if (_type != value)
                        _type = value;
                }
            }

            public Log(string logMessage, string logType)
            {
                _message = logMessage;
                _type = logType;
            }
        }
    }
}