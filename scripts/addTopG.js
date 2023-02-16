function AddContent(fetchedDataMovie, fetchedDataReview) {
    let commentDiv = document.createElement('div');
    commentDiv.setAttribute("class", "row g-0 mb-5 border p-20");
    commentDiv.style.maxHeight = "400px";
    commentDiv.style.color = "#FFFFFF";

    let firstCol = document.createElement('div');
    firstCol.setAttribute("class", "card col-5 border-0");

    let img = document.createElement('img');
    img.src = `https://image.tmdb.org/t/p/original${fetchedDataMovie[0]}`;
    img.setAttribute("class", "card-img-top h-100");

    let cardBody = document.createElement('div');
    let title = document.createElement('h5');
    title.setAttribute("class", "text-center justify-content-center text-primary");
    let someNode = document.createTextNode(fetchedDataMovie[1]);
    title.appendChild(someNode);
    cardBody.appendChild(title);
    firstCol.appendChild(img);
    firstCol.appendChild(cardBody);

    let secondCol = document.createElement('div');
    secondCol.setAttribute("class", "col-7 text-bg-light p-2 overflow-auto");
    secondCol.style.maxHeight = "inherit";

    if (fetchedDataReview.length == 0) {
        let tempNode = document.createTextNode('No comments yet!');
        secondCol.setAttribute("class", "col-7 text-bg-light p-2 text-center justify-content-center");
        secondCol.appendChild(tempNode);
    }
    else {
        for (let i = 0; i < fetchedDataReview.length; i++) {
            let tempNode = document.createTextNode(fetchedDataReview[0] + fetchedDataReview[1] + fetchedDataReview[2]);
            let br = document.createElement('hr');
            secondCol.appendChild(tempNode);
            secondCol.appendChild(br);
        }
    }

    commentDiv.appendChild(firstCol);
    commentDiv.appendChild(secondCol);

    let contaienrDiv = document.querySelector('.comments');
    contaienrDiv.appendChild(commentDiv);
}