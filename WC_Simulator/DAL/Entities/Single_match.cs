﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WC_Simulator.DAL.Entities
{
    public class Single_match
    {

        #region Properties
        public uint? Id_match { get; set; }
        public uint Id_first_team { get; set; }
        public uint Id_second_team { get; set; }
        public uint Id_tournament { get; set; }
        public uint Match_code { get; set; }
        public uint Goals_first_team { get; set; }
        public uint Goals_second_team { get; set; }
        #endregion

        #region Constructors
        public Single_match(MySqlDataReader reader)
        {
            Id_match = uint.Parse(reader["id_match"].ToString());
            Id_first_team = uint.Parse(reader["id_first_team"].ToString());
            Id_second_team = uint.Parse(reader["id_second_team"].ToString());
            Id_tournament = uint.Parse(reader["id_tournament"].ToString());
            Match_code = uint.Parse(reader["match_code"].ToString());
            Goals_first_team = uint.Parse(reader["goals_first_team"].ToString());
            Goals_second_team = uint.Parse(reader["goals_second_team"].ToString());
        }

        public Single_match(uint id_first_team, uint id_second_team, uint id_tournament, uint match_code, uint goals_first_team, uint goals_second_team)
        {
            Id_match = null;
            Id_first_team = id_first_team;
            Id_second_team = id_second_team;
            Id_tournament = id_tournament;
            Match_code = match_code;
            Goals_first_team = goals_first_team;
            Goals_second_team = goals_second_team;
        }

        public Single_match(Single_match match)
        {
            Id_match = match.Id_match;
            Id_first_team = match.Id_first_team;
            Id_second_team = match.Id_second_team;
            Id_tournament = match.Id_tournament;
            Match_code = match.Match_code;
            Goals_first_team = match.Goals_first_team;
            Goals_second_team = match.Goals_second_team;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return $"Bramki w meczu: {Goals_first_team} : {Goals_second_team}";
        }

        public string ToInsert()
        {
            return $"('{Id_match}', '{Id_first_team}', {Id_second_team}, '{Id_tournament}', '{Match_code}', '{Goals_first_team}', '{Goals_second_team}')";
        }
        public override bool Equals(object obj)
        {
            var match = obj as Single_match;
            if (match is null) return false;
            if (Id_match != match.Id_match) return false;
            if (Id_first_team != match.Id_first_team) return false;
            if (Id_second_team != match.Id_second_team) return false;
            if (Id_tournament != match.Id_tournament) return false;
            if (Match_code != match.Match_code) return false;
            if (Goals_first_team != match.Goals_first_team) return false;
            if (Goals_second_team != match.Goals_second_team) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion

    }
}
