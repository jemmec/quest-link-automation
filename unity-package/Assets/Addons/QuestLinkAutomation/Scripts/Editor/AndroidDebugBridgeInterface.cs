using System;
using System.Diagnostics;
using System.Threading;

namespace QuestLinkAutomation
{
    public class AndroidDebugBridgeInterface
    {
        /// <summary>
        /// Gets the results of the adb version command
        /// </summary>
        /// <param name="result">Callback with the results</param>
        public static void Version(Action<string> result)
        {
            ExecuteCommandSync("adb version", result);
        }

        /// <summary>
        /// Starts the quest link via adb command
        /// </summary>
        public static void StartQuestLink()
        {
            ExecuteCommandSync("adb shell am start -S com.oculus.xrstreamingclient/.MainActivity");
        }

        /// <summary>
        /// Stops the quest link via adb command
        /// </summary>
        public static void StopQuestLink()
        {
            ExecuteCommandSync("adb shell am force-stop com.oculus.xrstreamingclient");
        }

        private static void ExecuteCommandSync(object command, Action<string> callback = null)
        {
            string result = null;
            try
            {
                ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + command);
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;
                Process proc = new Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                result = proc.StandardOutput.ReadToEnd();
            }
            catch (Exception e)
            {
                UnityEngine.Debug.LogError(e);
            }
            finally
            {
                callback?.Invoke(result);
            }
        }

        //TODO: Threaded
        private static void ExecuteCommandAsync(string command)
        {
            try
            {

                // Thread objThread = new Thread(ExecuteCommandSync);
                // objThread.IsBackground = true;
                // objThread.Priority = ThreadPriority.AboveNormal;
                // objThread.Start(command);
            }
            catch (ThreadStartException e)
            {
            }
            catch (ThreadAbortException e)
            {
            }
            catch (Exception e)
            {
            }
        }
    }
}