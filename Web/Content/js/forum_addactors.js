/*Like button*/
let buttons = document.querySelectorAll('.contentbx-favoritebutton');

buttons.forEach(button =>
    button.addEventListener('click', () => {
        button.classList.toggle('active');
        console.log("aaaa");
    }));


/*VanillaTilt*/
VanillaTilt.init(document.querySelectorAll('.cards-movie'), {
    max: 25,
    speed: 400
});