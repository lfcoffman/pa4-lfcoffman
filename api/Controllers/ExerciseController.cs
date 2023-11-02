using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using pa4_lfcoffman.api.Models;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        // GET: api/Exercise/5
        [HttpGet]
        public List<Exercise> Get()
        {
            ExerciseUtility utility = new ExerciseUtility();
            return utility.GetAllExercises();
        }

        // POST: api/Exercise
        [HttpPost]
        public void Post([FromBody] Exercise value)
        {
            ExerciseUtility utility = new ExerciseUtility();
            utility.SaveExercise(value);
        }

        // PUT: api/Exercise/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] bool newPin)
        {
            ExerciseUtility utility = new ExerciseUtility();
            bool updated = utility.UpdatePin(id, newPin);
            return updated;
        }

        // DELETE: api/Exercise/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            System.Console.WriteLine(id);
            ExerciseUtility utility = new ExerciseUtility();
            utility.DeleteExercise(id);
            
        }
    }
}
