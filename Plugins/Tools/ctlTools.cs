﻿using PluginInterface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using greenwerx.Data;
using greenwerx.Data.Logging;
using greenwerx.Data.Logging.Models;
using greenwerx.Managers.Membership;
using greenwerx.Managers.Plant;
using greenwerx.Managers.Store;
using greenwerx.Models.App;
using greenwerx.Models.Membership;
using greenwerx.Models.Plant;
using greenwerx.Models.Store;

namespace Tools
{
    public partial class ctlTools : UserControl, IPlugin
    {
        #region Plugin interface properties

        private string myPluginAuthor = "greenwerx.org";
        private string myPluginDescription = "Opensource tools.";
        private string myPluginVersion = "1.0.0";
        private string myPluginShortName = "Tools";

        private UserSession _session;
        private AppInfo _appSettings;

        void PluginInterface.IPlugin.Dispose()
        {
            //add clean up here
        }

        public string Description
        { get { return myPluginDescription; } }

        public string Author
        { get { return myPluginAuthor; } }

        public IPluginHost Host { get; set; }

        public void Initialize(UserSession session, AppInfo appSettings)
        {
            _session = session;
            _appSettings = appSettings;
        }

        protected void Run()
        {
            //not mandatory, but good for a standard interface to main.
        }

        public void ResizeControl()
        {
            //adjust windows here
        }

        public UserControl MainInterface
        { get { return this; } }

        public string Version
        { get { return myPluginVersion; } }

        public string ShortName
        {
            get
            {
                return myPluginShortName;
            }
        }

        #endregion

        public ctlTools()
        {
            InitializeComponent();
        }
    }
}
