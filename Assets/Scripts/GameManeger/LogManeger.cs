// using System.IO;
// using UnityEngine;

// public class LogManeger : MonoBehaviour
// {
//     private string logFilePath;

//     private void Awake()
//     {
//         string logDirectoryPath = Application.dataPath + "/GameLogs";
//         if (!Directory.Exists(logDirectoryPath))
//         {
//             Directory.CreateDirectory(logDirectoryPath);
//         }

//         string logFileName = System.DateTime.Now.ToString("yyyy-MM-dd_HH:mm:ss");
//         logFilePath = logDirectoryPath + "/" + logFileName + ".txt";
//         // if (File.Exists(logFilePath))
//         // {
//         //     File.Delete(logFilePath);
//         // }

//         Application.logMessageReceived += HandleLog;
//     }

//     private void HandleLog(string logString, string stackTrace, LogType type)
//     {
//         if (type == LogType.Log)
//         {
//             using (StreamWriter writer = File.AppendText(logFilePath))
//             {
//                 writer.WriteLine(logString);
//             }
//         }
//     }
// }

