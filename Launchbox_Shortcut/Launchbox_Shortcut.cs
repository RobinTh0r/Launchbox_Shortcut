using Unbroken.LaunchBox.Plugins;
using Unbroken.LaunchBox.Plugins.Data;
using System.Drawing;
using System;
using System.IO;
using IWshRuntimeLibrary;


namespace BB_Shortcut
{
    public class Launchbox_Shortcut : IGameMenuItemPlugin
    {
        public bool SupportsMultipleGames
        {
            get
            {
                return true;
            }
        }

        public string Caption
        {
            get
            {
                return "Erstelle Verknüpfung";
            }
        }

        public System.Drawing.Image IconImage
        {
            get
            {
                return null;
            }
        }

        public bool ShowInLaunchBox
        {
            get
            {
                return true;
            }
        }

        public bool ShowInBigBox
        {
            get
            {
                return true;
            }
        }

        public bool GetIsValidForGame(IGame selectedGame)
        {
            return true;
        }

        public bool GetIsValidForGames(IGame[] selectedGames)
        {
            return true;
        }


        public void OnSelected(IGame selectedGame)
        {
            var launchBoxPath = AppDomain.CurrentDomain.BaseDirectory;
            foreach (var emulator in PluginHelper.DataManager.GetAllEmulators())
            {
                foreach (var emulatorPlatform in emulator.GetAllEmulatorPlatforms())
                {
                    if (emulatorPlatform.Platform == selectedGame.Platform && emulatorPlatform.IsDefault)
                    {
                        string romname = selectedGame.Title;
                        string romname2 = romname.Replace(':', ' ');
                        string icon_input = selectedGame.FrontImagePath;
                        string icon_output = selectedGame.FrontImagePath + ".ico";


                        WshShell wsh = new WshShell();
                        IWshShortcut shortcut = wsh.CreateShortcut(
                          Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + romname2 + ".lnk"
                        );
                        shortcut.TargetPath = launchBoxPath + "\\" + emulator.ApplicationPath;
                        shortcut.Arguments = emulator.CommandLine + emulatorPlatform.CommandLine + " \"" + launchBoxPath + selectedGame.ApplicationPath + "\"";
                        shortcut.WorkingDirectory = Path.GetDirectoryName(shortcut.TargetPath);
                        shortcut.IconLocation = icon_output;
                        shortcut.Save();
                        break;
                    }
                }
            }
        }
        public void OnSelected(IGame[] selectedGames)
        {
            return;
        }
    }
}