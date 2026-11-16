using GameAnalyticsSDK;

public static class RaceAnalytics
{
    public static void RaceStarted(int playerCount)
    {
        GameAnalytics.NewDesignEvent(
            "race:started",
            playerCount
            );
    }

    public static void CheckpointPassed(float time)
    {
        GameAnalytics.NewDesignEvent(
            "race:checkpoint_passed",
            time
            );
    }

    public static void LapCompleted(float lapTime)
    {
        GameAnalytics.NewDesignEvent(
            "race:lap_completed",
            lapTime
            );
    }

    public static void RaceFinished(float totalTime)
    {
        GameAnalytics.NewDesignEvent(
            "race:finished",
            totalTime
            );
    }

    public static void RaceQuit(float progress)
    {
        GameAnalytics.NewDesignEvent(
            "race:quit",
            progress
            );
    }
}
