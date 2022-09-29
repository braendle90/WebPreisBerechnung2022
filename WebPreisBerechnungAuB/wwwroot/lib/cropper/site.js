function uploadImage(filename) {

    var file = document.querySelector(".cropped");

    var form_data = new FormData();
    if (file) {
        form_data.append("ImageFile", file.src);
        var success_callback = function (response) {
            if (response.Status == 200) {
                //images saved successfully
            } else {
                //probably image too large
                console.log(response.Message);
            }
        };
        var error_callback = function (x, e) {
            //an error occurred
        };
        var your_app_path = 'https://localhost:44320';
        var api_path = your_app_path + "/Upload/SaveImage";
        triggerApi(api_path, form_data, success_callback, error_callback);
    } else {
        //nothing to save
    }
}

//   https://localhost:44320/Upload/SaveImage

//function triggerApi(api_path, form_data, success_callback, error_callback) {
//    $.ajax({
//        type: "POST",
//        url: api_path,
//        data: form_data,
//        dataType: 'json',
//        contentType: false,
//        processData: false,
//        success: function (response) {
//            alert("Success");
//        },
//        error: function (x, e) {
//            alert("Error");
//        }
//    });
//}


document.getElementById("mainForm").addEventListener("click", function (event) {
    event.preventDefault();

    var XHR = new XMLHttpRequest();
    var FD = new FormData();
    var ImageURL = document.getElementById("textScreenshot").getAttribute("src");
    var block = ImageURL.split(";");
    var contentType = block[0].split(":")[1];
    var realData = block[1].split(",")[1];
    var blob = b64toBlob(realData, contentType);
    FD.append('image', blob);
    XHR.open('POST', 'https://localhost:44320/Upload/SaveImage');
    XHR.send(FD);
});

function b64toBlob(b64Data, contentType, sliceSize) {
    contentType = contentType || '';
    sliceSize = sliceSize || 512;

    var byteCharacters = atob(b64Data);
    var byteArrays = [];

    for (var offset = 0; offset < byteCharacters.length; offset += sliceSize) {
        var slice = byteCharacters.slice(offset, offset + sliceSize);

        var byteNumbers = new Array(slice.length);
        for (var i = 0; i < slice.length; i++) {
            byteNumbers[i] = slice.charCodeAt(i);
        }

        var byteArray = new Uint8Array(byteNumbers);

        byteArrays.push(byteArray);
    }

    var blob = new Blob(byteArrays, { type: contentType });
    return blob;
}