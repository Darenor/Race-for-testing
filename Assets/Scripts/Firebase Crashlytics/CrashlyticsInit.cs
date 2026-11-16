using UnityEngine;
using Firebase;
using Firebase.Crashlytics;
using Firebase.Extensions;

public class CrashlyticsInit : MonoBehaviour
{
    private FirebaseApp firebaseApp;

    private void Start()
    {
        InitializeFirebase();
    }

    private void InitializeFirebase()
    {
        FirebaseApp.CheckAndFixDependenciesAsync()
            .ContinueWithOnMainThread(task =>
            {
                DependencyStatus dependencyStatus = task.Result;

                if (dependencyStatus == DependencyStatus.Available)
                {
                    firebaseApp = FirebaseApp.DefaultInstance;

                    Crashlytics.ReportUncaughtExceptionsAsFatal = true;

                    Debug.Log("Firebase Crashlytics успешно инициализирован!");
                }
                else
                {
                    Debug.LogError(
                        $"Firebase dependencies error: {dependencyStatus}"
                        );
                }
            });
    }
}
