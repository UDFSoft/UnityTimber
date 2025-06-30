# UTimber (Timber for Unity)
A lightweight, extensible logging library for Unity inspired by Android's Timber.

## Features
Simple static API for logging: Timber.D(), Timber.I(), Timber.W(), Timber.E(), Timber.V()

Supports multiple log levels: Verbose, Debug, Info, Warn, Error, Assert, WTF

Automatic tag generation from calling class and method (ClassName.MethodName)

Custom tags with fluent API: Timber.Tag("MyTag").D("message")

Pluggable "trees" to direct logs:

DebugTree: logs to Unity Console

FileTree: logs to a file

NetworkTree: sends logs to a server endpoint (via HTTP POST)

Minimum log level filtering per tree

Exception support in error logs

Thread-safe tagging using [ThreadStatic]

## Installation
Clone or download this repository

Copy the TimberLib folder to your Unity project's Assets/Scripts folder

Or import the provided .unitypackage (if available)

## Usage
Setup
Plant one or more trees during initialization (e.g. in a bootstrap script):

```csharp
using TimberLib;

void Awake()
{
    Timber.Plant(new DebugTree()); // Logs to Unity Console
    Timber.Plant(new FileTree("Logs/game.log")); // Logs to file
    Timber.Plant(new NetworkTree("https://yourserver.com/api/logs")); // Logs to network
}

```
## Logging examples

```csharp
Timber.V("Verbose message");
Timber.D("Debug message");
Timber.I("Info message");
Timber.W("Warning message");
Timber.E("Error message");
Timber.E(new Exception("Something went wrong"));
Timber.E("Error with exception", new Exception("Details"));

Timber.Tag("Network").D("Sending request...");
```

## Extending with custom trees
Create your own log tree by inheriting from Tree:

```csharp
public class MyCustomTree : Tree
{
    public override LogLevel MinimumLogLevel => LogLevel.Info;

    public override void Log(LogLevel level, string tag, string message, Exception exception = null)
    {
        // Your custom log handling here
    }
}
```

# Contribution
Feel free to fork and create pull requests!
Open issues for bugs or feature requests.

## Our website

[udfsoft](https://udfsoft.com/)
