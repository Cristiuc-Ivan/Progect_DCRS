/*Like button*/

let button = document.querySelector('.contentbx-favoritebutton');

button.addEventListener('click', () => {
    button.classList.toggle('active');
})

/*VanillaTilt*/
VanillaTilt.init(document.querySelectorAll('.cards-movie'), {
    max: 25,
    speed: 400
});