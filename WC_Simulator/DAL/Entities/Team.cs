﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WC_Simulator.DAL.Entities
{
    class Team
    {

        #region Własności
        public uint? Id_team { get; set; }
        public uint Id_group { get; set; }
        public string Name { get; set; }
        public string Coach { get; set; }
        public float Def_factor { get; set; }
        public float Att_factor { get; set; }
        #endregion

        #region Konstruktory
        public Team(MySqlDataReader reader)
        {
            Id_team = uint.Parse(reader["id_team"].ToString());
            Id_group = uint.Parse(reader["id_group"].ToString());
            Name = reader["name"].ToString();
            Coach = reader["coach"].ToString();
            Def_factor = float.Parse(reader["def_factor"].ToString());
            Att_factor = float.Parse(reader["att_factor"].ToString());
        }

        public Team(uint id_group, string name, string coach, float def_factor, float att_factor)
        {
            Id_team = null;
            Id_group = id_group;
            Name = name;
            Coach = coach;
            Def_factor = def_factor;
            Att_factor = att_factor;
        }

        public Team(Team team)
        {
            Id_team =  team.Id_team;
            Id_group = team.Id_group;
            Name = team.Name;
            Coach = team.Coach;
            Def_factor = team.Def_factor;
            Att_factor = team.Att_factor;
        }

        #endregion

        #region Metody

        public override string ToString()
        {
            return $"Drużyna: {Name}, Trener: {Coach}, Wsp. obrony: {Def_factor}, Wsp. ataku: {Att_factor}";
        }

        public string ToInsert()
        {
            return $"('{Id_team}', '{Id_group}', {Name}, '{Coach}', '{Def_factor}', '{Att_factor}')";
        }
        public override bool Equals(object obj)
        {
            var team = obj as Team;
            if (team is null) return false;
            if (Id_team != team.Id_team) return false;
            if (Id_group != team.Id_group) return false;
            if (Name.ToLower() != team.Name.ToLower()) return false;
            if (Coach.ToLower() != team.Coach.ToLower()) return false;
            if (Def_factor != team.Def_factor) return false;
            if (Att_factor != team.Att_factor) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion

    }
}
