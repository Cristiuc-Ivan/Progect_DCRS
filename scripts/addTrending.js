function SwiperAdd(fetchedData) {
    let swiperSlide = document.createElement('div');
    swiperSlide.classList.add('swiper-slide');
    swiperSlide.style.color = "#FFFFFF";

    let containerClass = document.createElement('div');
    containerClass.classList.add('container');
    containerClass.setAttribute("class", "m-0 w-100 mw-100 mx-3 h-100");

    let rowClass = document.createElement('div');
    rowClass.setAttribute("class", "row mx-3 h-100");

    let colClass = document.createElement('div');
    colClass.setAttribute("class", "col w-50");

    let img = document.createElement('img');
    img.src = `https://image.tmdb.org/t/p/original${fetchedData[0]}`;
    img.classList.add('slider_img');

    // second column
    let secondColClass = document.createElement('div');
    secondColClass.setAttribute("class", "col w-50");

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
    overViewRow.classList.add('overflow-auto');
    overViewRow.innerText = fetchedData[4];

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
    contaienrDiv.classList.add('h-100');
    contaienrDiv.appendChild(swiperSlide);
}