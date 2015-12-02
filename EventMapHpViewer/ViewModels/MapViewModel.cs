﻿using System.Windows;
using System.Windows.Media;
using EventMapHpViewer.Models;
using Livet;
using Grabacr07.KanColleWrapper;
using MetroTrilithon.Mvvm;

namespace EventMapHpViewer.ViewModels
{
    public class MapViewModel : ViewModel
    {

        #region MapNumber変更通知プロパティ
        private string _MapNumber;

        public string MapNumber
        {
            get
            { return this._MapNumber; }
            set
            {
                if (this._MapNumber == value)
                    return;
                this._MapNumber = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion


        #region Name変更通知プロパティ
        private string _Name;

        public string Name
        {
            get
            { return this._Name; }
            set
            { 
                if (this._Name == value)
                    return;
                this._Name = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion


        #region AreaName変更通知プロパティ
        private string _AreaName;

        public string AreaName
        {
            get
            { return this._AreaName; }
            set
            { 
                if (this._AreaName == value)
                    return;
                this._AreaName = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion


        #region Current変更通知プロパティ
        private int _Current;

        public int Current
        {
            get
            { return this._Current; }
            set
            { 
                if (this._Current == value)
                    return;
                this._Current = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion


        #region Max変更通知プロパティ
        private int _Max;

        public int Max
        {
            get
            { return this._Max; }
            set
            { 
                if (this._Max == value)
                    return;
                this._Max = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion


        #region SelectedRank変更通知プロパティ
        private string _SelectedRank;

        public string SelectedRank
        {
            get
            { return this._SelectedRank; }
            set
            {
                if (this._SelectedRank == value)
                    return;
                this._SelectedRank = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion

        public Visibility SelectedRankVisibility
            => string.IsNullOrEmpty(this.SelectedRank) ? Visibility.Collapsed : Visibility.Visible;

        #region RemainingCount変更通知プロパティ
        private string _RemainingCount;

        public string RemainingCount
        {
            get
            { return this._RemainingCount; }
            set
            { 
                if (this._RemainingCount == value)
                    return;
                this._RemainingCount = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion

        #region RemainingCountTransportS変更通知プロパティ
        private string _RemainingCountTransportS;

        public string RemainingCountTransportS
        {
            get
            { return this._RemainingCountTransportS; }
            set
            {
                if (this._RemainingCountTransportS == value)
                    return;
                this._RemainingCountTransportS = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion


        #region IsCleared変更通知プロパティ
        private bool _IsCleared;

        public bool IsCleared
        {
            get
            { return this._IsCleared; }
            set
            { 
                if (this._IsCleared == value)
                    return;
                this._IsCleared = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion


        #region GaugeColor変更通知プロパティ
        private SolidColorBrush _GaugeColor;

        public SolidColorBrush GaugeColor
        {
            get
            { return this._GaugeColor; }
            set
            { 
                if (Equals(this._GaugeColor, value))
                    return;
                this._GaugeColor = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion


        #region IsRankSelected変更通知プロパティ
        private bool _IsRankSelected;

        public bool IsRankSelected
        {
            get
            { return this._IsRankSelected; }
            set
            { 
                if (this._IsRankSelected == value)
                    return;
                this._IsRankSelected = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion


        #region IsSupported変更通知プロパティ
        private bool _IsSupported;

        public bool IsSupported
        {
            get
            { return this._IsSupported; }
            set
            { 
                if (this._IsSupported == value)
                    return;
                this._IsSupported = value;
                this.RaisePropertyChanged();
                this.RaisePropertyChanged(nameof(this.IsCountVisible));
            }
        }
        #endregion


        #region IsInfinity変更通知プロパティ
        private bool _IsInfinity;

        public bool IsInfinity
        {
            get
            { return this._IsInfinity; }
            set
            {
                if (this._IsInfinity == value)
                    return;
                this._IsInfinity = value;
                this.RaisePropertyChanged();
                this.RaisePropertyChanged(nameof(this.IsCountVisible));
            }
        }
        #endregion

        public bool IsCountVisible => this.IsSupported && !this.IsInfinity;

        #region GaugeType変更通知プロパティ
        private GaugeType _GaugeType;

        public GaugeType GaugeType
        {
            get
            { return this._GaugeType; }
            set
            {
                if (this._GaugeType == value)
                    return;
                this._GaugeType = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion

        private MapData _source;

        public MapViewModel(MapData info)
        {
            this._source = info;
            this.MapNumber = info.MapNumber;
            this.Name = info.Name;
            this.AreaName = info.AreaName;
            this.Current = info.Current;
            this.Max = info.Max;
            this.SelectedRank = info.Eventmap?.SelectedRankText ?? "";
            this.RemainingCount = info.RemainingCount.ToString();
            this.RemainingCountTransportS = info.RemainingCountTransportS.ToString();
            this.IsCleared = info.IsCleared == 1;
            var color = info.RemainingCount < 2
                ? new SolidColorBrush(Color.FromRgb(255, 32, 32))
                : new SolidColorBrush(Color.FromRgb(64, 200, 32));
            color.Freeze();
            this.GaugeColor = color;
            this.IsRankSelected = info.Eventmap == null
                || info.Eventmap.SelectedRank != 0
                || info.Eventmap.NowMapHp != 9999;
            this.IsSupported = 0 < info.RemainingCount;
            this.IsInfinity = info.RemainingCount == int.MaxValue;
            this.GaugeType = info.GaugeType;
        }

        public void CalcTransportCapacityChanged()
        {
            var remainingCount = this._source.RemainingCount;
            this.RemainingCount = remainingCount.ToString();
            this.RemainingCountTransportS = this._source.RemainingCountTransportS.ToString();
            this.IsInfinity = remainingCount == int.MaxValue;

            var color = this._source.RemainingCount < 2
                ? new SolidColorBrush(Color.FromRgb(255, 32, 32))
                : new SolidColorBrush(Color.FromRgb(64, 200, 32));
            color.Freeze();
            this.GaugeColor = color;
        }
    }
}
