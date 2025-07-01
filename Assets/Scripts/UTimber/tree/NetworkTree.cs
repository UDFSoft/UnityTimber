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
using Assets.Scripts.UTimber;
using UnityEngine;
using UnityEngine.Networking;


public class NetworkTree : Tree
{
    private readonly string endpointUrl;

    public override LogLevel MinimumLogLevel => LogLevel.Warn;

    public NetworkTree(string url)
    {
        endpointUrl = url;
    }

    public override void Log(LogLevel level, string tag, string message, Exception exception = null)
    {
        var payload = new LogPayload
        {
            level = level.ToString(),
            tag = tag,
            message = message,
            exception = exception?.ToString()
        };

        string json = JsonUtility.ToJson(payload);
        UnityWebRequest request = UnityWebRequest.PostWwwForm(endpointUrl, "");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);

        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.SetRequestHeader("Content-Type", "application/json");

        request.SendWebRequest(); // Fire-and-forget
    }

    [Serializable]
    private class LogPayload
    {
        public string level;
        public string tag;
        public string message;
        public string exception;
    }
}
