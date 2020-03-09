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
                return "Erstelle Verknüpfung - Clear Logo";
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
                        string rom_input = selectedGame.Title;
                        string rom_output = rom_input.Replace(':', ' ');
                        string icon_input = selectedGame.FrontImagePath;
                        string icon_convert = icon_input.Remove(icon_input.Length - 4);
                        string icon_output = icon_convert + ".ico";

                        WshShell wsh = new WshShell();
                        IWshShortcut shortcut = wsh.CreateShortcut(
                          Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + rom_output + ".lnk"
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