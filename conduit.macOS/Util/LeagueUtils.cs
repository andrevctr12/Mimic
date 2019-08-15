using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Conduit
{
    /**
    * Some static utilities used to interact/query the state of the league client process.
*/
    static class LeagueUtils
    {
        private static Regex AUTH_TOKEN_REGEX = new Regex("--remoting-auth-token=(.+?) ");
        private static Regex PORT_REGEX = new Regex("--app-port=(\\d+?) ");
        public static bool isLeagueOpen = false;

        /**
        * Returns a tuple with the process, remoting auth token and port of the current league client.
        * Returns null if the current league client is not running.
*/
        public static Tuple<Process, string, string> GetLeagueStatus()
        {

            var commandLine = ExecuteBashCommand("ps x -o args | grep 'LeagueClientUx'");

            try
            {
                var authToken = AUTH_TOKEN_REGEX.Match(commandLine).Groups[1].Value;
                var port = PORT_REGEX.Match(commandLine).Groups[1].Value;

                if (authToken != "")
                {
                    isLeagueOpen = true;
                    // Use regex to extract data, return it.
                    return new Tuple<Process, string, string>
                        (
                            new Process(),
                            authToken,
                            port
                        );
                }
            }
            catch (Exception e)
            {
                DebugLogger.Global.WriteError($"Error while trying to get the status for LeagueClientUx: {e.ToString()}\n\n(CommandLine = {commandLine})");
            }

            //}
            //}

            // LeagueClientUx process was not found. Return null.
            isLeagueOpen = false;
            return null;
        }

        static string ExecuteBashCommand(string command)
        {
            // according to: https://stackoverflow.com/a/15262019/637142
            // thans to this we will pass everything as one command
            command = command.Replace("\"", "\"\"");

            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "/bin/bash",
                    Arguments = "-c \"" + command + "\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            proc.Start();
            proc.WaitForExit();

            return proc.StandardOutput.ReadToEnd();
        }
    }
}
