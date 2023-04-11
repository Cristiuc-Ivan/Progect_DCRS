function SwiperAdd(fetchedData) {
    let i = 0;
    const carousel = document.querySelector('.carousel-inner');
    fetchedData.map((item) => {

        let text = (i == 0) ? "active" : "";
        i++;
        const carouselItem = document.createElement('div');
        carouselItem.innerHTML = `
<div class="m-0 w-100 mw-100 h-100">
    <div class="row mx-5 h-100">
        <div class="col w-50">
            <img src="https://image.tmdb.org/t/p/original${item.picture}" class="slider_img">
        </div>
        <div class="col w-50">
            <div class="row" style="color:#FFFFFF">Title: ${item.title}</div>
            <div class="row" style="color:#FFFFFF">Release Date: ${item.releaseDate}</div>
            <div class="row" style="color:#FFFFFF">Average Vote: ${item.avgVote}</div>
            <div class="row overflow-auto" style="color:#FFFFFF">Overview: ${item.overview}</div>
        </div>
    </div>
</div>
`;
        carouselItem.setAttribute("class", "carousel-item " + text);
        carousel.appendChild(carouselItem);
    })
}