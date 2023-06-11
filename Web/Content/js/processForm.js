let Actor_API_url = "https://api.themoviedb.org/3/search/person?api_key=19fe78adae46ab269edb4ba110fb5389&query=";
let Movie_API_url = "https://api.themoviedb.org/3/search/movie?api_key=19fe78adae46ab269edb4ba110fb5389&query=";

async function processActor() {
    var nameValue = document.getElementById("ActorSearch").value;
    let vvv = "";
    Actor_API_url += nameValue;
    const response = await fetch(Actor_API_url);
    var data = await response.json();
    vvv = data["results"];
    let Actors = [];
    for (let index = 0; index < vvv.length; index++) {
        if (vvv[index]["gender"] != 0 && vvv[index]["known_for_department"] == "Acting") {
            let result = vvv[index]["known_for"];
            let movies = [];
            for (let i = 0; i < 3; i++) {
                movies.push(result[i]["title"]);
            }
            let actualPath = "https://image.tmdb.org/t/p/original" + vvv[index]["profile_path"];
            let actualGender = (vvv[index]["gender"] == "1") ? "Female" : "Male";
            let actorDetails = {
                //picture: vvv[index]["profile_path"],
                picture: actualPath,
                realName: vvv[index]["original_name"],
                name: vvv[index]["name"],
                popularity: vvv[index]["popularity"],
                gender: actualGender,
                known_for: movies,
            };
            Actors.push(actorDetails);
        }
    }


    var dataToSend = {
        actors: Actors
    };

    var xhr = new XMLHttpRequest();
    xhr.open('POST', '/Search/Actors', true);
    xhr.setRequestHeader('Content-Type', 'application/json');

    xhr.onload = function () {
        if (xhr.status >= 200 && xhr.status < 400) {
            // Request was successful, redirect the user
            window.location.href = '/Search/Actors';
        } else {
            // Handle errors, if any
            console.error(xhr.responseText);
        }
    };

    xhr.onerror = function () {
        // Handle errors, if any
        console.error('Request failed.');
    };

    xhr.send(JSON.stringify(dataToSend));
}


async function processMovie() {
    var nameValue = document.getElementById("MovieSearch").value;
    let vvv = "";
    Movie_API_url += nameValue;
    const response = await fetch(Movie_API_url);
    var data = await response.json();
    vvv = data["results"];
    let Movies = [];
    for (let index = 0; index < vvv.length; index++) {
        let result = vvv[index]["genre_ids"];
        let Genres = [];
        for (let i = 0; i < result.length; i++) {
            //const genreId = 28; // Example genre ID

            await fetch('https://api.themoviedb.org/3/genre/movie/list?api_key=19fe78adae46ab269edb4ba110fb5389')
                .then(response => response.json())
                .then(data => {
                    const _genres = data.genres;
                    const _genre = _genres.find(genre => genre.id == result[i]);
                    if (_genre) {
                        //console.log('Name:', vvv[index]["title"], '  Genre Name:', _genre.name);
                        Genres.push(_genre.name);
                        //console.log(Genres);
                    } else {
                        console.log('Genre not found.');
                    }
                })
                .catch(error => {
                    console.error('Error:', error);
                });
        }
        let actualGenres = [];
        for (let key in Genres) {
            actualGenres.push(Genres[key]);
        }
        //console.log('||||Name:', vvv[index]["title"], "  Genre name:", actualGenres);
        let actualPath = "https://image.tmdb.org/t/p/original" + vvv[index]["poster_path"];
        let movieDetails = {
            id: vvv[index]["id"],
            picture: actualPath,
            overview: vvv[index]["overview"],
            popularity: vvv[index]["popularity"],
            name: vvv[index]["title"],
            releaseDate: vvv[index]["release_date"],
            genres: actualGenres,
        };
        Movies.push(movieDetails);
    }


    var dataToSend = {
        movies: Movies
    };

    var xhr = new XMLHttpRequest();
    xhr.open('POST', '/Search/Movies', true);
    xhr.setRequestHeader('Content-Type', 'application/json');

    xhr.onload = function () {
        if (xhr.status >= 200 && xhr.status < 400) {
            // Request was successful, redirect the user
            window.location.href = '/Search/Movies';
        } else {
            // Handle errors, if any
            console.error(xhr.responseText);
        }
    };

    xhr.onerror = function () {
        // Handle errors, if any
        console.error('Request failed.');
    };

    xhr.send(JSON.stringify(dataToSend));
}