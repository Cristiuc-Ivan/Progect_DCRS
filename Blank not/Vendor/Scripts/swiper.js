const myCarouselElement = document.querySelector('#carouselExampleControls');
const carousel = new bootstrap.Carousel(myCarouselElement, {
    interval: 100000,
});

document.getElementById('left').onclick = function () {
    carousel.next();
};
document.getElementById('right').onclick = function () {
    carousel.prev();
};
