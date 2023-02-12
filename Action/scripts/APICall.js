const API_Key='b6528c54-448a-4456-a16d-09577067b4ed';
const API_URL_ACTION='https://kinopoiskapiunofficial.tech/api/v2.2/films?genres=3&order=RATING&type=FILM&ratingFrom=0&ratingTo=10&yearFrom=1000&yearTo=3000&page=1';
const API_USE="https://kinopoiskapiunofficial.tech/api/v2.1/films/search-by-keyword?keyword="

getMovies(API_URL_ACTION);

async function getMovies(url){
    const resp = await fetch(url, {
    headers: {
    "Content-Type":"application/json","X-API-KEY":API_Key,
},
});
const respData = await resp.json();
showMovies(respData);
}
function getClassByRate(vote){
    if (vote>=7){
        return "green";
    } else if(vote >5){
        return "orange";
    } else {return "red";
}
}
function showMovies(data){
    const moviesE1 = document.querySelector(".movies");
data.items.forEach((movie) => {
    const movieE1 = document.createElement("div")
    movieE1.classList.add("movie")
    movieE1.innerHTML=`
    <div class="movie_cover-inner">
    <img src="${movie.posterUrl}"
    class="movie_cover"
    alt="${movie.nameRu}"/>
    <div class="movie__cover--darkened"></div>
</div>
<div class="movie_info">
    <div class="movie__title">${movie.nameRu}</div>
        <div class="movie_category">${movie.genres.map((genre) => ` ${genre.genre}`)}</div>
            <div class="movie_average movie_average--${getClassByRate(movie.ratingImdb)}">${movie.ratingImdb}</div>
        </div>
    `;
    moviesE1.appendChild(movieE1);
    
});
}
const form = document.querySelector("form");
const search = document.querySelector(".header_search");
form.addEventListener("submit",(e) => {
    e.preventDefault();
    const apiSearchUrl = `${API_USE}${search.value}`
    if (search.value){
        getMovies(apiSearchUrl)
    }
})