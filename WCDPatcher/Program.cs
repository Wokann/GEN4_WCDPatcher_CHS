using System;
using System.Windows.Forms;

namespace WCDPatcher
{
    static class Program
    {
        static string _dist, _wcard, _newrom, _title, _desc, _region, _gameAL;




        public static int _desc_offset;

        public static bool _overridehash = true;
        public static bool _nocheck;
        public static bool _silent;
        public static byte _seed;
        public static bool _continueGUI;
        public static int _friendDist;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GUI.GUI());
        }
        private static void ParseCommandLine(string[] argv)
        {
            for (int i = 0; i < argv.Length; i++)
            {
                switch (argv[i])
                {
                    case "-ohash":
                        {
                            _overridehash = true;
                            break;
                        }
                    case "-seed":
                        {
                            if (argv.Length >= (i + 1))
                            {
                                int outint = 0;

                                if (int.TryParse(argv[i + 1], out outint))
                                {
                                    if (outint >= 1 && outint <= 255)
                                    { _seed = Convert.ToByte(outint); }
                                }
                                i++;
                                break;
                            }
                            break;
                        }
                    case "-dist":
                        {
                            if (argv.Length >= (i + 1))
                            {
                                _dist = argv[i + 1];
                                i++;
                                break;
                            }
                            break;
                        }
                    case "-frienddist":
                        {
                            if (argv.Length >= (i + 1))
                            {
                                int fd;

                                bool success = int.TryParse(argv[i + 1], out fd);

                                if (!success) return;

                                if (fd > 255 || fd < 0) return;
                                _dist = argv[i + 1];
                                i++;
                                break;
                            }
                            break;
                        }
                    case "-wcard":
                        {
                            if (argv.Length >= (i + 1))
                            {
                                _wcard = argv[i + 1];
                                i++;
                                break;
                            }
                            break;
                        }
                    case "-nrom":
                        {
                            if (argv.Length >= (i + 1))
                            {
                                _newrom = argv[i + 1];
                                i++;
                                break;

                            }
                            break;
                        }
                    case "-title":
                        {
                            if (argv.Length >= (i + 1))
                            {
                                _title = argv[i + 1];
                                i++;
                                break;
                            }
                            break;
                        }
                    case "-nogui":
                        {
                            _continueGUI = false;


                            break;
                        }
                    case "-region":
                        {
                            if (argv.Length >= (i + 1))
                            {
                                string lngStr = argv[i + 1];
                                _region = lngStr;
                                i++;
                                break;
                            }
                            break;
                        }

                    case "-gameal":
                        {
                            if (argv.Length >= (i + 1))
                            {
                                string alStr = argv[i + 1];
                                _gameAL = alStr;
                                i++;
                                break;
                            }
                            break;
                        }
                    case "-s":
                        {
                            _silent = true;
                            break;
                        }
                    case "-desc":
                        {
                            if (argv.Length >= (i + 1))
                            {
                                if (argv[i + 1].Length > 128) break;
                                _desc = argv[i + 1];
                                i++;
                                break;
                            }
                            break;
                        }
                    case "-desclang":
                        {

                            if (argv.Length >= (i + 1))
                            {
                                switch (argv[i + 1])
                                {
                                        
                                    case "英语": { _desc_offset = Core.DistroPatcher.DistroOffsets.DescriptionOffsets.eng_desc; break; }
                                    case "德语": { _desc_offset = Core.DistroPatcher.DistroOffsets.DescriptionOffsets.ger_desc; break; }
                                    case "法语": { _desc_offset = Core.DistroPatcher.DistroOffsets.DescriptionOffsets.frn_desc; break; }
                                    case "意大利语": { _desc_offset = Core.DistroPatcher.DistroOffsets.DescriptionOffsets.ita_desc; break; }
                                    case "西班牙语": { _desc_offset = Core.DistroPatcher.DistroOffsets.DescriptionOffsets.spn_desc; break; }
                                    case "日语": { _desc_offset = Core.DistroPatcher.DistroOffsets.DescriptionOffsets.jap_desc; break; }
                                    case "韩语": { _desc_offset = Core.DistroPatcher.DistroOffsets.DescriptionOffsets.eng_desc; break; }
                                    default: { _desc_offset = Core.DistroPatcher.DistroOffsets.DescriptionOffsets.eng_desc; break; }
                                }
                                int num = 0;
                                if (!(int.TryParse(argv[i + 1], out num))) return;

                                _desc_offset = num;
                                i++;
                                break;
                            }
                            break;


                        }
                    case "-dodirdef":
                        {
                            string dir = "";
                            if (argv.Length >= (i + 1))
                            {
                                dir = argv[i + 1];
                                i++;

                            }

                            if (System.IO.Directory.Exists(dir))
                            {
                                string[] files = System.IO.Directory.GetFiles(dir, "*.pcd", System.IO.SearchOption.AllDirectories);

                                if (_region == null) { _region = "英语"; }

                                for (int i2 = 0; i2 < files.Length; i2++)
                                {
                                    if (!_nocheck)
                                    {
                                        bool result = WCDPatcher.Core.Validation.Validation.IsValidNDSROM(files[i], _silent, true, true);
                                        bool result2 = WCDPatcher.Core.Validation.Validation.IsValidWondercard(files[i2],_silent,false);
                                        { if ((!result) || !result2) continue; }
                                    }

                                    if (!System.IO.Directory.Exists(new System.IO.FileInfo(_newrom).Directory.FullName))
                                    {
                                        System.IO.Directory.CreateDirectory(new System.IO.FileInfo(_newrom).Directory.FullName);
                                    }

                                    Core.DistroPatcher.DistroPatcher.PatchDistro(files[i2], _dist, new System.IO.FileInfo(_newrom).Directory.FullName + "\\" +
                                        new System.IO.FileInfo(files[i2]).Name.Replace(".pcd", ".nds")
                                        , _region, _gameAL, _desc, Convert.ToByte(_friendDist), 0);
                                }
                            }
                            break;
                        }
                    case "-ap":
                        {
                            if (!_nocheck)
                            {
                                if (System.IO.File.Exists(_dist) && System.IO.File.Exists(_wcard) && Core.Validation.Validation.IsValidWondercard(_wcard, _silent,false)
                                    && Core.Validation.Validation.IsValidNDSROM(_dist,_silent,true,true))
                                {
                                    Core.DistroPatcher.DistroPatcher.PatchDistro(_wcard, _dist, _newrom, _region, _gameAL
                                        , _desc, Convert.ToByte(_friendDist), 0);
                                   Core.DistroPatcher.NDSUtilities.SetNDSTitle(_newrom, _title,true);
                                }

                            }
                            else
                            {
                               Core.DistroPatcher.DistroPatcher.PatchDistro(_wcard, _dist, _newrom, _region, _gameAL
                                    , _desc, Convert.ToByte(_friendDist), _seed); Core.DistroPatcher.NDSUtilities.SetNDSTitle(
                                      _newrom, _title, true);
                            }

                            break;
                        }
                }



            }
        }

        public static void SetDefaultSettings()
        {

            _region = "英语";
            _nocheck = false;
            _continueGUI = true;
            _overridehash = true;
            _desc = "Deoxys Distribution 2008 \n Nintendo";
            _friendDist = 255;
            _gameAL = "无变化";

        }
    }
}
