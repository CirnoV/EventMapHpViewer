﻿using System.ComponentModel.Composition;
using EventMapHpViewer.Models;
using EventMapHpViewer.ViewModels;
using Grabacr07.KanColleViewer.Composition;

namespace EventMapHpViewer
{
    [Export(typeof(IPlugin))]
    [Export(typeof(ITool))]
    [ExportMetadata("Guid", "101436F4-9308-4892-A88A-19EFBDF2ED5F")]
    [ExportMetadata("Title", title)]
    [ExportMetadata("Description", "Map HP를 표시합니다")]
	[ExportMetadata("Version", version)]
    [ExportMetadata("Author", "@veigr")]
    public class MapHpViewer : IPlugin, ITool
    {
        internal const string title = "MapHPViewer";
        internal const string version = "3.3.4.2";
        private ToolViewModel vm;

        public void Initialize()
        {
            this.vm = new ToolViewModel(new MapInfoProxy());
        }

        public string Name => "MapHP";

        // タブ表示するたびに new されてしまうが、今のところ new しないとマルチウィンドウで正常に表示されない
        public object View => new ToolView { DataContext = this.vm };
    }
}
