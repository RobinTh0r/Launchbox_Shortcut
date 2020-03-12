using Unbroken.LaunchBox.Plugins;
using Unbroken.LaunchBox.Plugins.Data;
using System.Diagnostics;
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
                        string icon_input_path = selectedGame.FrontImagePath;
                        string icon_output_raw= icon_input_path.Remove(icon_input_path.Length - 4);
                        string icon_output_path = icon_output_raw + ".ico";

                        // Convert-Icon
                        string arguments = string.Format(@"-define jpeg:size=200x200 " + "\"" + icon_input_path + "\"" + " -thumbnail  \"256x256>\" -background transparent -gravity center -extent 256x256 " + "\"" + icon_output_path + "\""); ;
                        string converter_path = Path.Combine(@"I:\LaunchBox\Plugins\convert.exe");
                        var convert = new Process();
                        convert.StartInfo.FileName = converter_path;
                        convert.StartInfo.Arguments = arguments;
                        convert.Start();

                        //-------------------Debug-Console--------------------
                        //Process p = new Process();
                        //ProcessStartInfo psi = new ProcessStartInfo();
                        //psi.FileName = "CMD.EXE";
                        //psi.Arguments = "/K " + converter_path + " " + arguments;
                        //p.StartInfo = psi;
                        //p.Start();
                        //p.WaitForExit();


                        //Create-Shortcut
                        WshShell wsh = new WshShell();
                        IWshShortcut shortcut = wsh.CreateShortcut(
                          Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + rom_output + ".lnk"
                        );
                        shortcut.TargetPath = launchBoxPath + "\\" + emulator.ApplicationPath;
                        shortcut.Arguments = emulator.CommandLine + emulatorPlatform.CommandLine + " \"" + launchBoxPath + selectedGame.ApplicationPath + "\"";
                        shortcut.WorkingDirectory = Path.GetDirectoryName(shortcut.TargetPath);
                        shortcut.IconLocation = icon_output_path;
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



