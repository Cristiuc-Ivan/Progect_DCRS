let api_url = "https://api.themoviedb.org/3/trending/movie/week?api_key=19fe78adae46ab269edb4ba110fb5389";

let vvv = "";
// Defining async function
async function getapi(url) {
    // Storing response
    const response = await fetch(url);
    // Storing data in form of JSON
    var data = await response.json();
    console.log(data);
    vvv = data["results"];
    // vvv1 = data1["results"];
    for (let index = 0; index < vvv.length; index++) {
        let array = [];
        array.push(vvv[index]["backdrop_path"]);
        array.push(vvv[index]["title"]);
        array.push(vvv[index]["release_date"]);
        array.push(vvv[index]["vote_average"]);
        array.push(vvv[index]["overview"]);
        SwiperAdd(array);
        swiper.update();
    }
}
// Calling that async function
getapi(api_url);
