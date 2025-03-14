﻿using WC_Simulator.DAL.Entities;

namespace WC_Simulator.Model
{
    public class TeamInGroup
    {
        #region Variables

        private string _position;
        private string _image;
        private string _country;
        private int _matches;
        private int _wins;
        private int _losses;
        private int _draws;
        private int _points;
        private int _gf;
        private int _ga;
        private int _id;

        #endregion


        #region Constructor

        public TeamInGroup(Team team, int matches, int gf, int ga, int points)
        {
            _id = team.Id_team;
            _points = 0;
            _image = $"../../Resources/Flags/{team.Name.Split(' ')[0]}.png";
            _country = team.Name;
            _matches = matches;
            _gf = gf;
            _ga = ga;
            _points = points;
        }

        #endregion


        #region Properties

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        public int Matches
        {
            get { return _matches; }
            set { _matches = value; }
        }

        public int Draws
        {
            get { return _draws; }
            set { _draws = value; }
        }

        public int Wins
        {
            get { return _wins; }
            set { _wins = value; }
        }

        public int Losses
        {
            get { return _losses; }
            set { _losses = value; }
        }

        public int GF
        {
            get { return _gf; }
            set { _gf = value; }
        }

        public int GA
        {
            get { return _ga; }
            set { _ga = value; }
        }

        public int Points
        {
            get { return _points; }
            set { _points = value; }
        }

        #endregion

        public override string ToString()
        {
            return Country;
        }
    }
}