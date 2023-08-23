namespace QuestLinkAutomation
{
    public static class QuickMenuItems
    {
        [UnityEditor.MenuItem("QuestLink/Start", false, 0)]
        private static void _StartQuestLink()
        {
            AndroidDebugBridgeInterface.StartQuestLink();
        }

        [UnityEditor.MenuItem("QuestLink/Stop", false, 1)]
        private static void _StopQuestLink()
        {
            AndroidDebugBridgeInterface.StartQuestLink();
        }
    }
}