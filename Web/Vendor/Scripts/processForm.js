let API_url = "https://api.themoviedb.org/3/search/movie?api_key=19fe78adae46ab269edb4ba110fb5389&query=";
async function processButton() {
    var nameValue = document.getElementById("formData").value;
    let vvv = "";
    API_url += nameValue;
    const response = await fetch(API_url);
    var data = await response.json();
    vvv = data["results"];
    console.log(vvv);
    let Finarray = [];
    //for (let index = 0; index < vvv.length; index++) {
    //    let movieDetails = {
    //        picture: vvv[index]["backdrop_path"],
    //        title: vvv[index]["title"],
    //        releaseDate: vvv[index]["release_date"],
    //        avgVote: vvv[index]["vote_average"],
    //        overview: vvv[index]["overview"]
    //    };
    //}
}


//document.addEventListener('DOMContentLoaded', function () {
//    var submitButton = document.getElementById('submitButton');
//    submitButton.addEventListener('click', function () {
//        var nameInput = document.getElementById('nameInput');
//        var nameValue = nameInput.value;

//        // Create a new XMLHttpRequest object
//        var xhr = new XMLHttpRequest();
//        xhr.open('POST', '/Controller/Action', true); // Replace 'Controller' with your controller name and 'Action' with your action method name
//        xhr.setRequestHeader('Content-Type', 'application/json');
//        xhr.onload = function () {
//            if (xhr.status === 200) {
//                console.log('Data sent successfully');
//                // Handle the response from the controller
//            } else {
//                console.error('Error:', xhr.statusText);
//                // Handle the error
//            }
//        };
//        xhr.onerror = function () {
//            console.error('Request failed');
//            // Handle the error
//        };

//        // Convert the data to JSON format
//        var data = JSON.stringify({ name: nameValue });

//        // Send the request with the JSON data
//        xhr.send(data);
//    });
//});
