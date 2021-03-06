﻿using Grabacr07.KanColleWrapper;
using Grabacr07.KanColleWrapper.Models;
using Grabacr07.KanColleWrapper.Models.Raw;
using EventMapHpViewer.Models.Raw;

namespace EventMapHpViewer.Models
{
    public class MapInfo : RawDataWrapper<kcsapi_mst_mapinfo>, IIdentifiable
    {
        public int Id { get; }

        public string Name { get; private set; }

        public int MapAreaId { get; private set; }

        public MapArea MapArea { get; private set; }

        public int IdInEachMapArea { get; private set; }

        public int Level { get; private set; }

        public string OperationName { get; private set; }

        public string OperationSummary { get; private set; }

        public int RequiredDefeatCount { get; private set; }

        public MapInfo(kcsapi_mst_mapinfo mapinfo, MasterTable<MapArea> mapAreas)
            : base(mapinfo)
        {
            this.Id = mapinfo.api_id;
            this.Name = mapinfo.api_name;
            this.MapAreaId = mapinfo.api_maparea_id;
            this.MapArea = mapAreas[mapinfo.api_maparea_id] ?? MapArea.Dummy;
            this.IdInEachMapArea = mapinfo.api_no;
            this.Level = mapinfo.api_level;
            this.OperationName = mapinfo.api_opetext;
            this.OperationSummary = mapinfo.api_infotext;
            this.RequiredDefeatCount = mapinfo.api_required_defeat_count ?? 1;
        }

        #region static members

        public static MapInfo Dummy { get; } = new MapInfo(new kcsapi_mst_mapinfo
        {
            api_id = 0,
            api_name = "？？？",
            api_maparea_id = 0,
            api_no = 0,
            api_level = 0,
        }, new MasterTable<MapArea>());

        #endregion
    }
}
