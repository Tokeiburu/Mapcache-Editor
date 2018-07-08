using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Text;
using ErrorManager;
using GRF.IO;
using GRF.System;
using TokeiLibrary;
using Utilities;

namespace Mapcache_Editor.ApplicationConfiguration {
	/// <summary>
	/// Program's configuration (stored in config.txt)
	/// </summary>
	public static class MapcacheConfiguration {
		private static ConfigAsker _configAsker;

		public static ConfigAsker ConfigAsker {
			get { return _configAsker ?? (_configAsker = new ConfigAsker(GrfPath.Combine(Configuration.ApplicationDataPath, ProgramName, "config.txt"))); }
			set { _configAsker = value; }
		}

		#region Program's configuration and information

		public static string PublicVersion {
			get { return "1.0.1"; }
		}

		public static string Author {
			get { return "Tokeiburu"; }
		}

		public static string ProgramName {
			get { return "Mapcache Editor"; }
		}

		public static string RealVersion {
			get { return Assembly.GetEntryAssembly().GetName().Version.ToString(); }
		}

		#endregion

		private static int _processId = 0;

		public static int ProcessId {
			get {
				if (_processId == 0)
					_processId = Process.GetCurrentProcess().Id;

				return _processId;
			}
		}

		public static string TempPath {
			get { return Settings.TempPath; }
		}

		public static bool AttemptingCustomDllLoad {
			get { return Boolean.Parse(ConfigAsker["[GRFEditor - Loading custom DLL state]", false.ToString()]); }
			set { ConfigAsker["[GRFEditor - Loading custom DLL state]"] = value.ToString(); }
		}

		public static int CompressionMethod {
			get { return Int32.Parse(ConfigAsker["[GRFEditor - Compression method index]", "0"]); }
			set { ConfigAsker["[GRFEditor - Compression method index]"] = value.ToString(CultureInfo.InvariantCulture); }
		}

		public static string CustomCompressionMethod {
			get { return ConfigAsker["[GRFEditor - Custom compression library]", ""]; }
			set { ConfigAsker["[GRFEditor - Custom compression library]"] = value; }
		}

		public static string ProgramDataPath {
			get { return GrfPath.Combine(Configuration.ApplicationDataPath, ProgramName); }
		}

		public static ErrorLevel WarningLevel {
			get { return (ErrorLevel) Int32.Parse(ConfigAsker["[Server database editor - Warning level]", "0"]); }
			set { ConfigAsker["[Server database editor - Warning level]"] = ((int) value).ToString(CultureInfo.InvariantCulture); }
		}
	}
}