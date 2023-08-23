using UnityEditor;
using UnityEngine;

namespace QuestLinkAutomation
{
    public class AndroidDebugBridgeChecker
    {
        private static string LINK = "https://developer.android.com/tools/releases/platform-tools";

        [InitializeOnLoadMethod]
        private static void OnLoad()
        {
            AndroidDebugBridgeInterface.Version((result) =>
            {
                if (!result.Contains("Android Debug Bridge version"))
                    Debug.LogError($"Android Debug Bridge (adb) was not found on this system. " +
                                    $"Please download it from {LINK}");
            });
        }
    }
}
