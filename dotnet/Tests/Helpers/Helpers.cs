﻿using AdventOfCode.CommandLineInterface.Web;
using Moq;
using System;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public static class Helpers
    {
        public static string ReadResourceContentAsString(string resourceName)
        {
            string calendarPage = "";
            var assembly = Assembly.GetExecutingAssembly();
            var stream = assembly.GetManifestResourceStream(resourceName);
            if (stream != null)
            {
                calendarPage = new StreamReader(stream, Encoding.UTF8).ReadToEnd();
            }
            return calendarPage;
        }

        public static Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public static IAdventOfCodeClient GetClientThatThrows<TException>(Expression<Action<IAdventOfCodeClient>> call) where TException : Exception, new()
        {
            var client = new Mock<IAdventOfCodeClient>();
            client.Setup(call).Throws<TException>();
            return client.Object;
        }

        public static IAdventOfCodeClient GetClientThatReturns(string result, Expression<Func<IAdventOfCodeClient, Stream>> call)
        {
            var client = new Mock<IAdventOfCodeClient>();
            client.Setup(call).Returns(GenerateStreamFromString(result));
            return client.Object;
        }
    }
}
