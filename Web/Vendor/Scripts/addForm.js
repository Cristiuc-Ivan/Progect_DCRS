function AddMovieByName(theName) {
    let api_url = "https://api.themoviedb.org/3/search/movie?api_key=19fe78adae46ab269edb4ba110fb5389&query=";

    console.log(api_url);
    getadd(api_url, theName);
}

async function getadd(url,Name) {
    let vvv = "";
    url += Name;
    console.log(url);
    const response = await fetch(url);
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