using TokeiLibrary.Paths;
using Utilities;

namespace Mapcache_Editor.ApplicationConfiguration {
	/// <summary>
	/// Copied from GRF Editor
	/// This class is Used when requesting paths; it saves the latest automatically
	/// </summary>
	public static class PathRequest {
		public static Setting ExtractSetting {
			get { return new Setting(null, typeof (MapcacheConfiguration).GetProperty("AppLastPath")); }
		}

		public static string SaveFileMapcache(params string[] extra) {
			return TkPathRequest.SaveFile(new Setting(null, typeof(MapcacheConfiguration).GetProperty("MapCachePath")), extra);
		}

		public static string OpenFileMapcache(params string[] extra) {
			return TkPathRequest.OpenFile(new Setting(null, typeof(MapcacheConfiguration).GetProperty("MapCachePath")), extra);
		}

		public static string[] OpenFilesCde(params string[] extra) {
			return TkPathRequest.OpenFiles(new Setting(null, typeof (MapcacheConfiguration).GetProperty("AppLastPath")), extra);
		}
	}
}