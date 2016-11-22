namespace EventMapHpViewer.Models
{
    public class Eventmap
    {
        public int? NowMapHp { get; set; }
        public int? MaxMapHp { get; set; }
        public int State { get; set; }
        public int SelectedRank { get; set; }
        public GaugeType GaugeType { get; set; }

        public string SelectedRankText
        {
            get
            {
                switch (this.SelectedRank)
                {
                    case 1:
                        return "º´";
                    case 2:
                        return "À»";
                    case 3:
                        return "°©";
                    default:
                        return "";
                }
            }
        }
    }
}