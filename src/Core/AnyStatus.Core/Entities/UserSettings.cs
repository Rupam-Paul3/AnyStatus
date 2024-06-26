﻿using AnyStatus.API.Attributes;
using AnyStatus.Core.Themes;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

namespace AnyStatus.Core.Settings
{
    [DebuggerDisplay("Theme={Theme}")]
    public class UserSettings
    {
        public UserSettings()
        {
            Theme = "Dark";
            StartMinimized = true;
            SendAnonymousUsageStatistics = false;
            WindowsSettings = new Dictionary<string, WindowSettings>();
        }

        public Dictionary<string, WindowSettings> WindowsSettings { get; set; }

        [Order(1)]
        [ItemsSource(typeof(ThemeSource), autoload: true)]
        public string Theme { get; set; }

        [Order(2)]
        [DisplayName("Start minimized")]
        public bool StartMinimized { get; set; }

        [Order(3)]
        [DisplayName("Send anonymous usage statistics")]
        [Description("Help improving AnyStatus by sending anonymous usage statistics")]
        public bool SendAnonymousUsageStatistics { get; set; }
    }
}
