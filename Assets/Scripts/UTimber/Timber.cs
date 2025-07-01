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
using System.Collections.Generic;
using System.Diagnostics;
using Assets.Scripts.UTimber;

public static class Timber
{

    private static readonly List<Tree> trees = new();
    [ThreadStatic] private static string explicitTag;

    public static void Plant(Tree tree)
    {
        if (tree != null && !trees.Contains(tree))
            trees.Add(tree);
    }

    public static void UprootAll() => trees.Clear();

    public static TimberTagger Tag(string tag)
    {
        explicitTag = tag;
        return new TimberTagger();
    }

    private static string GetTag()
    {
        if (!string.IsNullOrEmpty(explicitTag))
        {
            var tag = explicitTag;
            explicitTag = null;
            return tag;
        }

        var stackTrace = new StackTrace();
        for (int i = 3; i < stackTrace.FrameCount; i++)
        {
            var method = stackTrace.GetFrame(i).GetMethod();
            var type = method?.DeclaringType;
            if (type != null && type != typeof(Timber))
                return $"{type.Name}.{method.Name}";
        }
        return "Unknown";
    }

    private static void LogInternal(LogLevel level, string message, Exception exception = null)
    {
        string tag = GetTag();
        foreach (var tree in trees)
        {
            if (tree.IsLoggable(level))
                tree.Log(level, tag, message, exception);
        }
    }

    // Обёртки
    public static void V(string message) => LogInternal(LogLevel.Verbose, message);
    public static void D(string message) => LogInternal(LogLevel.Debug, message);
    public static void I(string message) => LogInternal(LogLevel.Info, message);
    public static void W(string message) => LogInternal(LogLevel.Warn, message);
    public static void E(string message) => LogInternal(LogLevel.Error, message);
    public static void E(Exception ex) => LogInternal(LogLevel.Error, ex.Message, ex);
    public static void E(string message, Exception ex) => LogInternal(LogLevel.Error, message, ex);
}