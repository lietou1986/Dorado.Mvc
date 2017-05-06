﻿using Dorado.Components.Logging;
using NSubstitute;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Xunit;

namespace Dorado.Tests.Unit.Components.Logging
{
    public class LoggerTests : IDisposable
    {
        private Int32 backupSize;
        private String logPath;
        private String log;

        public LoggerTests()
        {
            backupSize = Int32.Parse(WebConfigurationManager.AppSettings["LogBackupSize"]);
            logPath = WebConfigurationManager.AppSettings["LogPath"];
            log = Path.Combine(logPath, "Log.txt");

            if (Directory.Exists(logPath))
            {
                String[] files = Directory.GetFiles(logPath);
                foreach (String file in files) File.Delete(file);

                Directory.Delete(logPath);
            }
        }

        public void Dispose()
        {
            HttpContext.Current = null;
        }

        #region Log(String message)

        [Fact]
        public void Log_MessageWithoutAccount()
        {
            HttpContext.Current = HttpContextFactory.CreateHttpContext();
            HttpContext.Current.User = null;
            Logger logger = new Logger();

            logger.Log("Test");

            String expected = "Account: " + Environment.NewLine + "Message: Test" + Environment.NewLine + Environment.NewLine;
            String actual = File.ReadAllText(log);

            Assert.True(actual.StartsWith("Time   :"));
            Assert.True(actual.EndsWith(expected));
        }

        [Fact]
        public void Log_MessageForCurrentAccount()
        {
            HttpContext.Current = HttpContextFactory.CreateHttpContext();
            Logger logger = new Logger();

            logger.Log("Test");

            String expected = "Account: 1" + Environment.NewLine + "Message: Test" + Environment.NewLine + Environment.NewLine;
            String actual = File.ReadAllText(log);

            Assert.True(actual.StartsWith("Time   :"));
            Assert.True(actual.EndsWith(expected));
        }

        [Fact]
        public void Log_CreatesBackupFile()
        {
            Logger logger = new Logger(2);

            logger.Log(new String('T', backupSize));

            String expected = "Account: 2" + Environment.NewLine + "Message: " + new String('T', backupSize) + Environment.NewLine + Environment.NewLine;
            String actual = File.ReadAllText(Directory.GetFiles(logPath, "Log *.txt").Single());

            Assert.True(actual.StartsWith("Time   :"));
            Assert.True(actual.EndsWith(expected));
        }

        #endregion Log(String message)

        #region Log(Exception exception)

        [Fact]
        public void Log_InnerException()
        {
            Exception exception = new Exception("", Substitute.For<Exception>());
            exception.InnerException.StackTrace.Returns("StackTrace");
            exception.InnerException.Message.Returns("Message");
            Logger logger = new Logger(2);

            logger.Log(exception);

            String actual = File.ReadAllText(log);
            String expected = String.Format("Account: 2{0}Message: {1}: {2}{0}{3}{0}{0}",
                Environment.NewLine,
                exception.InnerException.GetType(),
                exception.InnerException.Message,
                exception.InnerException.StackTrace);

            Assert.True(actual.StartsWith("Time   :"));
            Assert.True(actual.EndsWith(expected));
        }

        #endregion Log(Exception exception)
    }
}