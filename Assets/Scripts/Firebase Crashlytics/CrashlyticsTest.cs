
using System;
using UnityEngine;

public class CrashlyticsTest : MonoBehaviour
{
    private float timer;
    private bool crashTriggered;

    private void Start()
    {
        Debug.Log("CrashlyticsTest запущен!");
    }

    private void Update()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        if (crashTriggered)
            return;

        timer += Time.deltaTime;

        if (timer >= 10f)
        {
            crashTriggered = true;
            Debug.LogError("Crashlytics: вызываем тестовое исключение!");

            throw new Exception("Crashlytics test exception");
        }
#endif
    }
}
