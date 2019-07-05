﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TweakUtility.TweakPages
{
    public class AdvancedPage : TweakPage
    {
        public AdvancedPage() : base("Advanced")
        {
        }

        [DisplayName("Verbose Messages")]
        [Description("Defaults to false.")]
        public bool VerboseMessages
        {
            get
            {
                using (RegistryKey subKey = Program.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Policies\System"))
                {
                    return (int)subKey.GetValue("VerboseStatus", RegistryValueKind.DWord) == 1;
                }
            }
            set
            {
                using (RegistryKey subKey = Program.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Policies\System", true))
                {
                    subKey.SetValue("VerboseStatus", value ? 1 : 0, RegistryValueKind.DWord);
                }
            }
        }
    }
}