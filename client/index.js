let count = 0
let myExercises = []

// myExercises.push({Exercise: "Cardio", Date: "09/22/2023", Distance: "5.5", UUID: generateUUID()})
// myExercises.push({Exercise: "Swimming", Date: "09/25/2023", Distance: "2.8", UUID: generateUUID()})
// localStorage.setItem('myExercises', JSON.stringify(myExercises))

async function handleOnLoad()
{   await updateExercises()
    populateTable()
    let html=`
    <div id="tableBody"></div>
    <form onsubmit="return false">
    <div class ="addexercisetitle"><br>Add New Exercise:</div><br>
        <label for="exercise" class = "tabover" >Exercise:</label><br>     
        <input type="text" id="exercise" name="exercise"class = "tabover" ><br>
        <label for="date" class = "tabover" >Date:</label><br>
        <input type="text" id="date" name="date" class = "tabover" placeholder = "MM/DD/YYYY"><br>
        <label for="distance" class = "tabover" >Distance (miles):</label><br>
        <input type="text" id="distance" name="distance" class = "tabover" ><br><br>
        <button onclick="handleExerciseAdd()" class="submitbutton">Submit</button>
    </form>`
    document.getElementById('app').innerHTML=html
}
async function updateExercises(){
    let response = await fetch('http://localhost:5000/api/Exercise' )
    myExercises = await response.json()
}
async function populateTable()
{
    
    //sortTableByDate()
    let html=`
    <div class="tablecontainer">
        <table class ="table table-striped">
        <tr>
            <th>Exercise</th>
            <th>Date</th>
            <th>Distance (miles)</th>
            <th>Pin</th>
            <th>Delete</th>
        </tr>`
        myExercises.forEach(function(exercise)
        {
            console.log(exercise)
            console.log(exercise.exerciseName)
            html += `
            <tr>
            <td>${exercise.exerciseName}</td>
            <td>${exercise.date}</td>
            <td>${exercise.distance}</td>
            `
            if(exercise.Pin == false)
            {
            html+=`<td><button class="btn " onclick="handlePin('${exercise.id}')">Unpinned</button></td>`
            }
            else
            {
            html+=`<td><button class="btn " onclick="handlePin('${exercise.id}')">Pinned</button></td>`
            }
            html+=`<td><button class="btn btn-danger" onclick="handleExerciseDelete('${exercise.id}')">Delete</button></td>
            </tr>`
        })
        html+=`</table>
    </div>`
    document.getElementById('tableBody').innerHTML = html
}

async function handleExerciseAdd() {
    let exerciseDate = document.getElementById('date').value;
    let exerciseName = document.getElementById('exercise').value;
    let distance = document.getElementById('distance').value;
    
    const response = await fetch('http://localhost:5000/api/Exercise', {
        method: 'POST', 
        body: JSON.stringify({
            ExerciseName: exerciseName,
            Date: exerciseDate,
            Distance: distance,
        }),
        headers: {
            'Content-Type': 'application/json'
        }
    });
    
    if (response.ok) {
        populateTable();
        document.getElementById('exercise').value = '';
        document.getElementById('date').value = '';
        document.getElementById('distance').value = '';
    }
}


function handleExerciseDelete(UUID)
{
    myExercises = myExercises.filter(exercise => exercise.UUID != UUID)
    populateTable()
}

function handlePin(uuid)
{
    myExercises.forEach(function(exercise)
    {
        if(exercise.UUID == uuid)
        {
            exercise.Pin = !exercise.Pin
        }
    })
    populateTable()
}

function sortTableByDate() {
    myExercises.sort(function(a,b)
    {
        return new Date(b.Date) - new Date(a.Date)
    })
}