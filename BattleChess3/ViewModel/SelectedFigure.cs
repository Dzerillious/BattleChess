﻿using BattleChess3.Annotations;
using BattleChess3.GameData.Figures;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BattleChess3.Game
{
    public class SelectedFigure : INotifyPropertyChanged
    {
        public Position SelPosition { get; set; }

        private BaseFigure selFigure;

        public BaseFigure SelFigure
        {
            get => selFigure;
            set
            {
                selFigure = value;
                OnPropertyChanged();
            }
        }

        public SelectedFigure()
        {
            SelFigure = new BaseFigure();
            SelPosition = null;
        }

        public void SetSelected(BaseFigure figure)
        {
            SelFigure = figure;
            SelPosition = figure.Position;
        }

        public void SetSelected(Position position)
        {
            SelFigure = Session.GetFigureAtPosition(position);
            SelPosition = position;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}