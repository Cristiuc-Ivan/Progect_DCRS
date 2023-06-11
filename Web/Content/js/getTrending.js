let api_url = "https://api.themoviedb.org/3/trending/movie/week?api_key=19fe78adae46ab269edb4ba110fb5389";

let vvv = "";
async function getapi(url) {
    const response = await fetch(url);
    var data = await response.json();
    vvv = data["results"];
    let Finarray = [];
    for (let index = 0; index < vvv.length; index++) {
        let movieDetails = {
            picture: vvv[index]["backdrop_path"],
            title: vvv[index]["title"],
            releaseDate: vvv[index]["release_date"],
            avgVote: vvv[index]["vote_average"],
            overview: vvv[index]["overview"]
        };
        Finarray.push(movieDetails);
    }
    SwiperAdd(Finarray);
}
getapi(api_url);


