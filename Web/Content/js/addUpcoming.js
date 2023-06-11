function addUpcoming(fetchedDataMovie) {

    let commentDiv = document.createElement('div');
    commentDiv.setAttribute("class", "col py-2");
    commentDiv.style.minHeight = "400px";
    commentDiv.style.color = "#FFFFFF";

    let card = document.createElement('div');
    card.setAttribute("class", "card h-100");

    let img = document.createElement('img');
    img.src = `https://image.tmdb.org/t/p/original${fetchedDataMovie[0]}`;
    img.setAttribute("class", "card-img-top");
    img.style.height = "inherit";
    let imgDiv = document.createElement('div');
    imgDiv.setAttribute("class", "h-100");
    imgDiv.appendChild(img);

    let cardBody = document.createElement('div');
    cardBody.setAttribute("class", "h-50");
    let title = document.createElement('p');
    title.style.fontSize = "1.4rem";
    title.setAttribute("class", "text-center justify-content-center text-primary my-2");
    let someNode = document.createTextNode(fetchedDataMovie[1]);
    title.appendChild(someNode);
    cardBody.appendChild(title);
    card.appendChild(imgDiv);
    card.appendChild(cardBody);
    card.style.position = "relative";

    let onTop = document.createElement('div');
    let gradeText = document.createElement('p');
    gradeText.setAttribute("class", "rounded-circle border border-primary text-center bg-white");
    gradeText.style.background = '#000';
    let gradeNode;

    if (fetchedDataMovie[3] == '0') {
        gradeNode = document.createTextNode('NA');
    }
    else {
        gradeNode = document.createTextNode(fetchedDataMovie[3]);
    }

    gradeText.style.fontSize = "1.4rem";
    gradeText.appendChild(gradeNode);
    onTop.style.marginLeft = '10px';
    onTop.style.marginTop = '5px';
    onTop.style.opacity = '0.7';
    onTop.appendChild(gradeText);
    onTop.style.position = "absolute";
    //onTop.style.background = "white";
    onTop.style.height = "40px";
    onTop.style.width = "40px";
    onTop.style.left = "0";
    onTop.style.top = "0";

    card.appendChild(onTop);

    commentDiv.appendChild(card);

    let contaienrDiv = document.querySelector('#upcoming');
    contaienrDiv.appendChild(commentDiv);
}