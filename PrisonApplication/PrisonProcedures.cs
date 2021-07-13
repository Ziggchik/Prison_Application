using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace PrisonApplication
{
    public class PrisonProcedures
    {
        private SqlCommand command
            = new SqlCommand("", PrisonConnection.connection);

        private void commandConfig(string config)
        {
            command.CommandType =
                System.Data.CommandType.StoredProcedure;
            command.CommandText = "[dbo].[" + config + "]";
            command.Parameters.Clear();
        }


        public void spPrisoner_insert(string Surname_Prisoner,
            string Name_Prisoner, string MiddleName_Prisoner)
        {
            commandConfig("Prisoner_insert");
            command.Parameters.AddWithValue("@Name_Prisoner",
                Name_Prisoner);
            command.Parameters.AddWithValue("@MiddleName_Prisoner",
                MiddleName_Prisoner);
            command.Parameters.AddWithValue("@Surname_Prisoner",
                Surname_Prisoner);
            PrisonConnection.connection.Open();
            command.ExecuteNonQuery();
            PrisonConnection.connection.Close();
        }

        public void spPrisoner_update(string Surname_Prisoner,
            string Name_Prisoner, string MiddleName_Prisoner,
            Int32 ID_Prisoner)
        {
            commandConfig("Prisoner_update");
            command.Parameters.AddWithValue("@ID_Prisoner", ID_Prisoner);
            command.Parameters.AddWithValue("@Name_Prisoner", Name_Prisoner);
            command.Parameters.AddWithValue("@MiddleName_Prisoner", MiddleName_Prisoner);
            command.Parameters.AddWithValue("@Surname_Prisoner", Surname_Prisoner);
            PrisonConnection.connection.Open();
            command.ExecuteNonQuery();
            PrisonConnection.connection.Close();
        }

        public void spPrisoner_delete(Int32 ID_Prisoner)
        {
            commandConfig("Prisoner_delete");
            command.Parameters.AddWithValue("@ID_Prisoner", ID_Prisoner);
            PrisonConnection.connection.Open();
            command.ExecuteNonQuery();
            PrisonConnection.connection.Close();
        }

        public void spGuardian_insert(string Surname_Guardian,
           string Name_Guardian, string MiddleName_Guardian)
        {
            commandConfig("Guardian_insert");
            command.Parameters.AddWithValue("@Name_Guardian",
                Name_Guardian);
            command.Parameters.AddWithValue("@MiddleName_Guardian",
                MiddleName_Guardian);
            command.Parameters.AddWithValue("@Surname_Guardian",
                Surname_Guardian);
            PrisonConnection.connection.Open();
            command.ExecuteNonQuery();
            PrisonConnection.connection.Close();
        }
        public void spGuardian_update(string Surname_Guardian,
                  string Name_Guardian, string MiddleName_Guardian,
                  Int32 ID_Guardian)
        {
            commandConfig("Guardian_update");
            command.Parameters.AddWithValue("@ID_Guardian", ID_Guardian);
            command.Parameters.AddWithValue("@Name_Guardian", Name_Guardian);
            command.Parameters.AddWithValue("@MiddleName_Guardian", MiddleName_Guardian);
            command.Parameters.AddWithValue("@Surname_Guardian", Surname_Guardian);
            PrisonConnection.connection.Open();
            command.ExecuteNonQuery();
            PrisonConnection.connection.Close();
        }

        public void spGuardian_delete(Int32 ID_Guardian)
        {
            commandConfig("Guardian_delete");
            command.Parameters.AddWithValue("@ID_Guardian", ID_Guardian);
            PrisonConnection.connection.Open();
            command.ExecuteNonQuery();
            PrisonConnection.connection.Close();
        }

        public void spWeapon_insert(string Name_Weapon)
        {
            commandConfig("Weapon_insert");
            command.Parameters.AddWithValue("@Name_Weapon",
                Name_Weapon);
            PrisonConnection.connection.Open();
            command.ExecuteNonQuery();
            PrisonConnection.connection.Close();
        }

        public void spWeapon_update(Int32 ID_Weapon, string Name_Weapon)
        {
            commandConfig("Weapon_update");
            command.Parameters.AddWithValue("@ID_Weapon",
               ID_Weapon);
            command.Parameters.AddWithValue("@Name_Weapon",
                Name_Weapon);
            PrisonConnection.connection.Open();
            command.ExecuteNonQuery();
            PrisonConnection.connection.Close();
        }

        public void spWeapon_update(Int32 ID_Weapon)
        {
            commandConfig("Weapon_delete");
            command.Parameters.AddWithValue("@ID_Weapon",
               ID_Weapon);
            PrisonConnection.connection.Open();
            command.ExecuteNonQuery();
            PrisonConnection.connection.Close();
        }
    }
}
