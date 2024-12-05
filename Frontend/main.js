const infoText = document.getElementById("info-text");
const imageURL = document.getElementById("image-url");

async function GetImages(url) {
    let response = await fetch(url);
    let data = await response.json();
    return data;
}

// imageURL.src = "http://localhost:5045/images/wire.png";

GetImages("http://localhost:5045/api/testing/imagesupport").then(data => {
    console.log(data);
    data.map((value, index) => {
        console.log(value.ImageUrl);
        imageURL.src = value.imageUrl;
    })
})