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
            // let tempNode = document.createTextNode(fetchedDataReview[0] + fetchedDataReview[1] + fetchedDataReview[2]);
            let br = document.createElement('hr');

            // creating main divs
            // let authorDiv = document.createElement('div');
            // let contentDiv = document.createElement('div');
            // let dateDiv = document.createElement('div');

            // assigning display-flex attribute
            // authorDiv.setAttribute("class", "d-flex");
            // contentDiv.setAttribute("class", "d-flex");
            // dateDiv.setAttribute("class", "d-flex");

            // creating array of strings
            let arrayTxt = ['Author:', 'Review:', 'Date:'];

            for (let k = 0; k < 3; k++) {

                // creating a certain Div
                let flexDiv = document.createElement('div');

                // assigning display-flex attribute
                flexDiv.setAttribute("class", "d-flex");

                // diving div on 2 paragapgrahs
                let firstPartP = document.createElement('p');
                let secondPartP = document.createElement('p');

                // a text node which will have 3 possible values
                let fillerNode = document.createTextNode(arrayTxt[k]);
                let fetchedNode = document.createTextNode(fetchedDataReview[i][k]);

                // appending nodes to the 1|2 paragraphs
                firstPartP.appendChild(fillerNode);
                secondPartP.appendChild(fetchedNode);

                // adding styles to the Title
                firstPartP.style.fontSize = "20px";
                firstPartP.style.fontFamily = "Roboto,sans-serif";
                firstPartP.style.color = "#DC143C";
                firstPartP.style.textDecoration = "underline";

                secondPartP.style.textAlign = "justify";
                

                // appending paragraphs to divs
                flexDiv.appendChild(firstPartP);
                flexDiv.appendChild(secondPartP);

                secondCol.appendChild(flexDiv);
                secondCol.appendChild(br);
            }
        }
    }

    commentDiv.appendChild(firstCol);
    commentDiv.appendChild(secondCol);

    let contaienrDiv = document.querySelector('.comments');
    contaienrDiv.appendChild(commentDiv);
}