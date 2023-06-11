let movieEnd = "";
let reviewFinite = "";

async function getapi() {
    let currentLocation = trimLocation(window.location.href);
    let id = await findId(currentLocation);
    let queryGenreId = stringGenre(id);

    const responseMovie = await fetch(queryGenreId);
    var movieData = await responseMovie.json();
    movieEnd = movieData["results"];

    for (let index = 0; index < movieEnd.length; index++) {
        const responseReview = await fetch(stringMovie(movieEnd[index]["id"]));
        var reviewData = await responseReview.json();
        reviewFinite = reviewData["results"];

        let arrayMovie = [];
        let arrayReview = [];
        arrayMovie.push(movieEnd[index]["backdrop_path"]);
        arrayMovie.push(movieEnd[index]["title"]);
        arrayMovie.push(movieEnd[index]["release_date"]);
        arrayMovie.push(movieEnd[index]["vote_average"]);

        for (let i = 0; i < reviewFinite.length; i++) {
            let tempik = [];
            tempik.push(reviewFinite[i]["author"]);
            tempik.push(reviewFinite[i]["content"]);
            tempik.push(reviewFinite[i]["created_at"]);
            arrayReview.push(tempik);
        }
        AddContent(arrayMovie, arrayReview);
    }
}

function stringMovie(id) {
    let urlStart = "https://api.themoviedb.org/3/movie/";
    let urlEnd = "/reviews?api_key=19fe78adae46ab269edb4ba110fb5389";
    return urlStart + id + urlEnd;
}

function stringGenre(genreId) {
    let urlStart = "https://api.themoviedb.org/3/discover/movie?api_key=19fe78adae46ab269edb4ba110fb5389&language=en-US&sort_by=popularity.desc&include_adult=false&include_video=false&with_genres=";
    let urlend = "&with_original_language=en&page=1";
    return urlStart + genreId + urlend;
}
function trimLocation(page) {
    let as = '';
    for (let i = 30; i < page.length; i++)
        as += page[i];
    return as;
}

async function findId(currentURL) {
    const link = await fetch("https://api.themoviedb.org/3/genre/movie/list?api_key=19fe78adae46ab269edb4ba110fb5389&language=en-US");
    var linkD = await link.json();
    let holder = linkD["genres"];

    for (let i = 0; i < holder.length; i++)
        if (currentURL == holder[i]["name"]) {
            return holder[i]["id"];
        }
}
getapi();

