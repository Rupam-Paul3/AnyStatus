﻿using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.IO;
using Xunit;

namespace AnyStatus.Apps.Windows.Tests;

public sealed class AppFixture : IDisposable
{
    public AppFixture()
    {
        var opt = new AppiumOptions();

        opt.AddAdditionalCapability("app", GetAppPath());

        Session = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), opt);

        Assert.NotNull(Session);

        Assert.NotNull(Session.SessionId);

        Session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1.5);
    }

    public WindowsDriver<WindowsElement> Session { get; private set; }

    private static string GetAppPath()
    {
        Console.WriteLine("Current Directory: {0}", Directory.GetCurrentDirectory());
#if DEBUG
        const string config = "Debug";
#else
            const string config = "Release";
#endif
        var path = Path.Combine(Directory.GetCurrentDirectory(), $@"..\..\..\..\AnyStatus.Apps.Windows\bin\x64\{config}\net6.0-windows10.0.19041\AnyStatus.exe");

        if (!File.Exists(path))
        {
            throw new FileNotFoundException(path);
        }

        return path;
    }

    public void Dispose()
    {
        if (Session is null)
        {
            return;
        }

        Session.Quit();
        Session = null;
    }
}