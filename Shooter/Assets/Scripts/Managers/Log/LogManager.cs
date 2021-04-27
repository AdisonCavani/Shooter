using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Globalization;

public class LogManager : MonoBehaviour
{
    static string path;
    const string logPath = "/Shooter/log.txt";
    CultureInfo cultureInfo = new CultureInfo("en-US", false); // Date formatting to English
    string spacing = " | ";

    void Start()
    {
        path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + logPath;
        CreateFile(path);
    }

    private void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    private void HandleLog(string logMessage, string stackTrace, LogType type)
    {
        path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + logPath;
        TimeSpan timeSpan = TimeSpan.FromSeconds(Time.realtimeSinceStartup);
        string time = string.Format("{0:D2}:{1:D2}:{2:D2}:{3:D3}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);

        if (type.ToString() == "Warning")
        {
            string _message = "[" + type.ToString() + "] " + logMessage;
            AddTextToLog(path, time, _message);
        }
        else if (type.ToString() == "Error")
        {
            string _message = "[" + type.ToString() + "] " + logMessage;
            AddTextToLog(path, time, _message);
        }
        else
        {
            string _message = "[" + type.ToString() + "] " + logMessage;
            AddTextToLog(path, time, _message);
        }
    }

    void CreateFile(string path)
    {
        File.WriteAllText(path, "************ | Log created on: " + DateTime.Now.ToString("dddd", cultureInfo) + ", " +
            DateTime.Now.ToString("dd MMMM yyyy", cultureInfo) + " @ " + DateTime.Now.ToString("T") + "\n" +
            "================================================================\n"); // Create file with message
    }

    void AddTextToLog(string path, string time, string logMessage)
    {
        string message = time + spacing + logMessage + "\n";
        File.AppendAllText(path, message);
    }
}
