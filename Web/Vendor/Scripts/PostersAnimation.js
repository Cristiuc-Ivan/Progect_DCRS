
// the class
class Poster {

    // constructor
    constructor(scaleFactor, URL, offsetX, offsetY) {
        // basic setup
        this.scaleFactor = scaleFactor;
        this.offsetX = offsetX;
        this.offsetY = offsetY;
        this.image = new Image();
        this.opacity = 0;

        this.image.src = URL;

        // canvas setup
        this.childCanvas = document.createElement("canvas");
        this.childContext = this.childCanvas.getContext("2d");

        // onload func
        // this.image.onload = this.draw.bind(this);
    }

    draw(degree) {
        this.degree = degree;
        // get scaled Dimensions of image
        const scaledWidth = this.image.width * this.scaleFactor;
        const scaledHeight = this.image.height * this.scaleFactor;

        // set the dimensions of canvas
        this.childCanvas.width = scaledWidth;
        this.childCanvas.height = scaledHeight;

        this.childContext.globalAlpha = this.opacity;

        // draw on child and then on parent
        this.childContext.save();
        this.childContext.translate(this.childCanvas.width / 2, this.childCanvas.height / 2);
        this.childContext.rotate(this.degree);
        this.childContext.drawImage(this.image, -(this.childCanvas.width / 2), -(this.childCanvas.height / 2), scaledWidth, scaledHeight);
        this.childContext.restore();
        parentContext.drawImage(this.childCanvas, this.offsetX, this.offsetY);
    }

}

function trimStringUntilWord(string, word) {
    var index = string.indexOf(word);
    if (index !== -1) {
        return string.substring(index, string.length);
    }
    return string;
}

// GLOBAL PARAMETERS
// parent canvas and context
let parentCanvas = document.getElementById("animations");
let parentContext = parentCanvas.getContext("2d");

// dimensions of canvas
let maxW = parentCanvas.width = window.innerWidth;
let maxH = parentCanvas.height = window.innerHeight;
let min = -200;
// loading image paths 
let picSize = document.getElementById("amountPics").textContent;
let imgPaths = [];
for (let i = 0; i < picSize; i++) {
    url = document.getElementById("picture " + i.toString()).textContent;
    relURL=trimStringUntilWord(url,"\\Content\\");
    imgPaths.push(relURL);
}

console.log(imgPaths);

// initializing array of Posters 
let posters = [];
let i = 0;
imgPaths.forEach(path => {
    // let poster = new Poster(0.4, path, 0, Math.random() * (maxH - min) + min);
    let poster = new Poster(0.4, path, Math.random() * (maxW - min) + min, Math.random() * (maxH - min) + min);
    posters.push(poster);
})

let rot = 0;
let loadedImages = 0;

function preload() {
    posters.forEach((poster) => {
        poster.image.onload = function () {
            loadedImages++;
            if (loadedImages == posters.length) {
                setTimeout(startAnimations, 1000);
            }
        }
    })
}

preload();

let dx = 3;
let dy = 2;
let opacityIncrement = 0.01; // Amount to increment opacity per frame

function startAnimations() {

    parentContext.clearRect(0, 0, parentCanvas.width, parentCanvas.height);
    posters.forEach((poster) => {
        if (poster.offsetX > parentCanvas.width) {
            poster.offsetX = 0;
            poster.opacity = 0;
            poster.offsetY = Math.random() * parentCanvas.height;
        }
        if (poster.offsetY > parentCanvas.height) {
            poster.offsetY = 0;
            poster.opacity = 0;
            poster.offsetX = Math.random() * parentCanvas.width;
        }
        // Gradually increase the opacity of the child canvas
        if (poster.opacity < 1) {
            poster.opacity += opacityIncrement;
            poster.opacity = Math.min(poster.opacity, 1);
        }

        poster.offsetX += dx;
        poster.offsetY += dy;
        rot += 0.000;
        poster.draw(rot);
    })
    requestAnimationFrame(startAnimations);

}