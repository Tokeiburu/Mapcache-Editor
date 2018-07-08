namespace Mapcache_Editor.Core.Commands {
	public interface IMapcacheCommand {
		void Execute(Mapcache mapcache);
		void Undo(Mapcache mapcache);
		string CommandDescription { get; }
	}
}
