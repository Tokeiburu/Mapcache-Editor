using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using ErrorManager;
using TokeiLibrary.WPF.Styles.ListView;

namespace Mapcache_Editor.Core {
	public static class Extensions {
		public static void GenerateListViewTemplate(ListView list, ListViewDataTemplateHelper.GeneralColumnInfo[] columnInfos, ListViewCustomComparer sorter, IList<string> triggers, params string[] extraCommands) {
			Gen1(list);
			ListViewDataTemplateHelper.GenerateListViewTemplateNew(list, columnInfos, sorter, triggers, extraCommands);
		}

		public static void Gen1(ListView list) {
			try {
				Style style = new Style();
				style.TargetType = typeof(ListViewItem);

				style.Setters.Add(new Setter(
					FrameworkElement.HorizontalAlignmentProperty,
					HorizontalAlignment.Left
					));
				style.Setters.Add(new Setter(
					Control.HorizontalContentAlignmentProperty,
					HorizontalAlignment.Stretch
					));

				list.ItemContainerStyle = style;
			}
			catch (Exception err) {
				ErrorHandler.HandleException(err);
			}
		}
	}
}
