let canvas = document.getElementById("animations");
let context = canvas.getContext("2d");

let picSize = document.getElementById("amountPics").textContent;
let imgPaths = [];
for (let i = 0; i < picSize; i++) {
    imgPaths.push(document.getElementById("picture " + i.toString()).textContent);
}

console.log(imgPaths);

let base_image = new Image();
base_image.src = '../../Content/Animation Data/1 Thing.jpg';
base_image.onload = function () {

    // scale the 1000x669 image in half to 500x334 onto a temp canvas
    let c1 = scaleIt(base_image, 0.50);

    // scale the 500x335 canvas in half to 250x167 onto the main canvas
    canvas.width = c1.width / 2;
    canvas.height = c1.height / 2;
    context.drawImage(c1, 0, 0,100,10);

}

function scaleIt(source, scaleFactor) {
    let c = document.createElement('canvas');
    let ctx = c.getContext('2d');
    let w = source.width * scaleFactor;
    let h = source.height * scaleFactor;
    c.width = w;
    c.height = h;
    ctx.drawImage(source, 0, 0, w, h);
    return (c);
}













//function draw() {
//    requestAnimationFrame(draw);
//    contex.clearRect(0, 0, innerWidth, innerHeight);
//    for (let i = 0; i < 100; i++) {
//        let x = Math.random() * window.innerWidth;
//        let y = Math.random() * window.innerHeight;
//        contex.beginPath();
//        contex.arc(x, y, 10, 0, Math.PI * 2, false);
//        contex.StrokeStyle = 'blue';
//        contex.stroke();
//    }
//}
//draw();