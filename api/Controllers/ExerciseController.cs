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
        // GET: api/Exercise
        [HttpGet]
        public List<Exercise> Get()
        {
            ExerciseUtility utility = new ExerciseUtility();
            return utility.GetAllExercises();
        }

        // GET: api/Exercise/5
        [HttpGet("{id}", Name = "Get")]
        public Exercise Get(int id)
        {
            ExerciseUtility utility = new ExerciseUtility();
            List<Exercise> myExercises= utility.GetAllExercises();
            foreach(Exercise exercise in myExercises){
                if(exercise.Id == id){
                    return exercise;
                }
            }
            return new Exercise();
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
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Exercise/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            System.Console.WriteLine(id);
        }
    }
}
