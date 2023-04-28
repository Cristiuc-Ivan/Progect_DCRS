function processButton() {
    var nameValue = document.getElementById("formData").value;
    console.log(nameValue);
    AddMovieByName(nameValue);
}