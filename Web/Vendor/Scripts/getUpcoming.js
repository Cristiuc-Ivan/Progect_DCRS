let movie = "https://api.themoviedb.org/3/movie/upcoming?api_key=19fe78adae46ab269edb4ba110fb5389&page=";
let movieFinite = "";

async function getapi() {

    for (let i = 1; i < 4; i++) {
        let moviePagination = 'https://api.themoviedb.org/3/movie/upcoming?api_key=19fe78adae46ab269edb4ba110fb5389&page=' + i;

        const responseMovie = await fetch(moviePagination);
        var movieData = await responseMovie.json();
        movieFinite = movieData["results"];

        for (let index = 0; index < movieFinite.length; index++) {

            let arrayMovie = [];

            arrayMovie.push(movieFinite[index]["backdrop_path"]);
            arrayMovie.push(movieFinite[index]["title"]);
            arrayMovie.push(movieFinite[index]["release_date"]);
            arrayMovie.push(movieFinite[index]["vote_average"]);

            addUpcoming(arrayMovie);
        }
    }
}

getapi();
