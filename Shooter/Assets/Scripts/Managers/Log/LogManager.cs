using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Globalization;

public class LogManager : MonoBehaviour
{
    const string shooter = "\\Shooter";
    const string log = "\\log.txt";
    string docsPath;
    string shooterPath;
    string logPath;
    CultureInfo cultureInfo = new CultureInfo("en-US", false); // Date formatting to English
    const string spacing = " | ";

    private void Awake()
    {
        docsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        shooterPath = docsPath + shooter;
        logPath = shooterPath + log;
        DirectoryInfo di = Directory.CreateDirectory(shooterPath);

        CreateFile(logPath);
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
        TimeSpan timeSpan = TimeSpan.FromSeconds(Time.realtimeSinceStartup);
        string time = string.Format("{0:D2}:{1:D2}:{2:D2}:{3:D3}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);

        if (type.ToString() == "Warning")
        {
            string _message = "[" + type.ToString() + "] " + logMessage;
            AddTextToLog(logPath, time, _message);
        }
        else if (type.ToString() == "Error")
        {
            string _message = "[" + type.ToString() + "] " + logMessage;
            AddTextToLog(logPath, time, _message);
        }
        else
        {
            string _message = "[" + type.ToString() + "] " + logMessage;
            AddTextToLog(logPath, time, _message);
        }
    }

    void CreateFile(string logPath)
    {
        File.WriteAllText(logPath, "************ | Log created on: " + DateTime.Now.ToString("dddd", cultureInfo) + ", " +
            DateTime.Now.ToString("dd MMMM yyyy", cultureInfo) + " @ " + DateTime.Now.ToString("T") + "\n" +
            "==================================================================\n" +
            "************" + spacing + "[CPU] " + SystemInfo.processorType + "\n" +
            "************" + spacing + "[RAM] " + SystemInfo.systemMemorySize + " MB" + "\n" +
            "************" + spacing + "[GPU] " + SystemInfo.graphicsDeviceName + "\n" +
            "************" + spacing + "[API] " + SystemInfo.graphicsDeviceVersion + "\n" +
            "************" + spacing + "[OS] " + SystemInfo.operatingSystem + "\n" +
            "------------------------------------------------------------------" + "\n"
            ); // Create file with message
    }

    void AddTextToLog(string logPath, string time, string logMessage)
    {
        string message = time + spacing + logMessage + "\n";
        File.AppendAllText(logPath, message);
    }
}
