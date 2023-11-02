using MySql.Data.MySqlClient;
using pa4_lfcoffman;
namespace pa4_lfcoffman.api.Models
{
    public class ExerciseUtility
    {
        public List<Exercise> GetAllExercises()
        {
            List<Exercise> myExercises = new List<Exercise>();
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"SELECT uuid, exercises, exerciseDate, distance, exerciseDelete, pin FROM exerciselist";
            using var cmd = new MySqlCommand(stm, con);
            using (var reader = cmd.ExecuteReader())
            {
                while(reader.Read())
                {
                    Exercise exercise = new Exercise
                    {
                        Id = reader.GetInt32("uuid"),
                        ExerciseName = reader.GetString("exercises"),
                        Date = reader.GetString("exerciseDate"),
                        Distance = reader.GetInt32("distance"),
                        Delete = reader.GetBoolean("exerciseDelete"),
                        Pin = reader.GetBoolean("pin")
                    };
                    myExercises.Add(exercise);
                }
            }
            return myExercises;
        }
        public void SaveExercise(Exercise myExercises)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO exerciselist(exercises, exerciseDate, distance) values(@name, @date, @distance)";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@name", myExercises.ExerciseName);
            cmd.Parameters.AddWithValue("@date", myExercises.Date);
            cmd.Parameters.AddWithValue("@distance", myExercises.Distance);
            cmd.ExecuteNonQuery();
        }

        public bool UpdatePin(int id, bool newPin)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"UPDATE exerciselIST SET pin = @newPin WHERE uuid = @id";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@newPin", newPin);
            cmd.Parameters.AddWithValue("@id", id);
            int rowsPinned = cmd.ExecuteNonQuery();
            return rowsPinned > 0;
        }

        public void DeleteExercise(int id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();
            string stm = @"DELETE FROM exerciselist WHERE UUID = @id";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
