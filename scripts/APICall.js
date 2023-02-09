// // fetch("https://api.themoviedb.org/3/movie/550?api_key=19fe78adae46ab269edb4ba110fb5389")
// let arr = [];
// let obj = fetch("https://api.themoviedb.org/3/trending/movie/week?api_key=19fe78adae46ab269edb4ba110fb5389")
//     .then(res => res.json())
//     .then(data => { console.log(data); arr.push(data) });

// console.log(arr);


let api_url = "https://api.themoviedb.org/3/trending/movie/week?api_key=19fe78adae46ab269edb4ba110fb5389";
let api_url1 = "https://api.themoviedb.org/3/genre/movie/list?api_key=19fe78adae46ab269edb4ba110fb5389";

let vvv = "";
let vvv1 = "";
// Defining async function
async function getapi(url, url2) {
    // Storing response
    const response = await fetch(url);
    const response1 = await fetch(url2);
    // Storing data in form of JSON
    var data = await response.json();
    var data1 = await response1.json();
    vvv = data["results"];
    // vvv1 = data1["results"];
    console.log(data1);
    for (let index = 0; index < vvv.length; index++) {
        // console.log(vvv[index]);
        // https://image.tmdb.org/t/p/original/[thepath]
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
getapi(api_url,api_url1);
