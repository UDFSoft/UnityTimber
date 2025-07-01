/*
 *    Copyright 2025 UDF Owner
 *
 *    Licensed under the Apache License, Version 2.0 (the "License");
 *    you may not use this file except in compliance with the License.
 *    You may obtain a copy of the License at
 *
 *        http://www.apache.org/licenses/LICENSE-2.0
 *
 *    Unless required by applicable law or agreed to in writing, software
 *    distributed under the License is distributed on an "AS IS" BASIS,
 *    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *    See the License for the specific language governing permissions and
 *    limitations under the License.
 *
 *    More details: https://udfsoft.com/
 */

using System;
using System.IO;
using Assets.Scripts.UTimber;


public class FileTree : Tree
{
    private readonly string logFilePath;

    public override LogLevel MinimumLogLevel => LogLevel.Debug;

    public FileTree(string path)
    {
        logFilePath = path;
        Directory.CreateDirectory(Path.GetDirectoryName(logFilePath)!);
    }

    public override void Log(LogLevel level, string tag, string message, Exception exception = null)
    {
        var log = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{level}] [{tag}] {message}";
        if (exception != null)
            log += $"\n{exception}";

        File.AppendAllText(logFilePath, log + Environment.NewLine);
    }
}
