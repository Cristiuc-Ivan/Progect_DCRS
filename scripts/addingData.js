function SwiperAdd(fetchedData) {
    let swiperSlide = document.createElement('div');
    swiperSlide.classList.add('swiper-slide');
    swiperSlide.style.color = "#FFFFFF";

    let containerClass = document.createElement('div');
    containerClass.classList.add('container');
    containerClass.classList.add('m-0');
    containerClass.classList.add('w-100');
    containerClass.classList.add('mw-100');
    containerClass.classList.add('mx-3');
    containerClass.classList.add('h-100');

    let rowClass = document.createElement('div');
    rowClass.classList.add('row');
    rowClass.classList.add('mx-3');

    let colClass = document.createElement('div');
    colClass.classList.add('col');
    colClass.classList.add('w-50');

    let img = document.createElement('img');
    img.src = "https://image.tmdb.org/t/p/original" + fetchedData[0];
    img.classList.add('slider_img');

    // second column
    let secondColClass = document.createElement('div');
    secondColClass.classList.add('col');
    secondColClass.classList.add('w-50');

    // adding rows
    let titleRow = document.createElement('div');
    titleRow.classList.add('row');
    let titleNode = document.createTextNode(fetchedData[1]);
    titleRow.appendChild(titleNode);

    let dateRow = document.createElement('div');
    dateRow.classList.add('row');
    let dateNode = document.createTextNode(fetchedData[2]);
    dateRow.appendChild(dateNode);

    let VoteRow = document.createElement('div');
    VoteRow.classList.add('row');
    let voteNode = document.createTextNode(fetchedData[3]);
    VoteRow.appendChild(voteNode);

    let overViewRow = document.createElement('div');
    overViewRow.classList.add('row');
    let overViewNode = document.createTextNode(fetchedData[4]);
    overViewRow.appendChild(overViewNode);

    // inserting to the secondCOL
    secondColClass.appendChild(titleRow);
    secondColClass.appendChild(dateRow);
    secondColClass.appendChild(VoteRow);
    secondColClass.appendChild(overViewRow);

    // 
    colClass.appendChild(img);
    rowClass.appendChild(colClass);
    rowClass.appendChild(secondColClass);
    containerClass.appendChild(rowClass);
    swiperSlide.appendChild(containerClass);


    let contaienrDiv = document.querySelector('.swiper-wrapper');
    contaienrDiv.appendChild(swiperSlide);
}