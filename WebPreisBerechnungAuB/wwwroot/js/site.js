function display() {
    window.print();
}

//Logo_SurfaceWidht


function colorPicker() {

    var colorBlock = document.getElementById('imgShow');
    var ctx1 = colorBlock.getContext('2d');
    var width1 = colorBlock.width;
    var height1 = colorBlock.height;
    colorBlock.clientHeight = height1;
    colorBlock.clientWidth = width1;


    var x = 0;
    var y = 0;
    var drag = false;
    var rgbaColor = 'rgba(255,0,0,1)';

    colorBlock.addEventListener("mousedown", mousedown, false);

    function getMousePos(canvas, evt) {
        var rect = canvas.getBoundingClientRect();
        return {
            x: (evt.clientX - rect.left) / (rect.right - rect.left) * canvas.width,
            y: (evt.clientY - rect.top) / (rect.bottom - rect.top) * canvas.height
        };
    }


    function mousedown(e) {

        var xy = getMousePos(colorBlock,e);


        var imageData = ctx1.getImageData(xy.x, xy.y, 1, 1).data;
        rgbaColor = 'rgba(' + imageData[0] + ',' + imageData[1] + ',' + imageData[2] + ',1)';
       // alert("x: " + xy.x + "y: " + xy.y);
        //alert(rgbaColor);
        console.log(localStorage.getItem("rgbaColor", imageData))
        localStorage.setItem("rgbaColor", imageData);
    }
}



localstorageSaveWidthAndHeight = data => {

    var LogoSizeRatio = JSON.parse(data);


    localStorage.setItem("LogoSizeRatioModel", data);

    localStorage.setItem("width", LogoSizeRatio.height);
    localStorage.setItem("ratiowidth", LogoSizeRatio.ratiowidth);

    localStorage.setItem("height", LogoSizeRatio.width);
    localStorage.setItem("ratioheight", LogoSizeRatio.ratioheight);

    localStorage.setItem("aspectRatio", LogoSizeRatio.width / LogoSizeRatio.height);

}


CalculateImageSizeInMilimeterWidth = data => {


    var imageSrc = document.getElementById("imgShow").src;

    if (imageSrc != "") {




        var LogoSizeRatio = JSON.parse(localStorage.getItem("LogoSizeRatioModel"));



        var localWidth = parseFloat(localStorage.getItem("width"));
        //var localRatioWidth = parseFloat(localStorage.getItem("ratiowidth"));

        var localHeight = parseFloat(localStorage.getItem("height"));

        var aspectRatio = parseFloat(localStorage.getItem("aspectRatio"));
        //var localRatioheight = parseFloat(localStorage.getItem("ratioheight"));

        //var aspectRatio = parseFloat(LogoSizeRatio.aspectRatio);

        var widthElement = document.getElementById("width");

        var width = widthElement.value;


        var heightElement = document.getElementById("hight");
        var height = heightElement.value;



        var sumHeight = parseInt(width / aspectRatio);

        var sumWidth = parseInt(height * aspectRatio);

        /*    heightElement.value = sumHeight;*/


        //if (sumHeight < 1) {

        //    heightElement.value = height;
        //}


        //widthElement.value = sumWidth;
        //if (sumWidth < 1) {

        //    widthElement.value = width;
        //}

        if (data.id == "width") {

            heightElement.value = sumHeight;

            widthElement.value = width;
        }

        if (data.id == "hight") {

            widthElement.value = sumWidth;

            heightElement.value = height;
        }


        //localStorage.getItem("width");
        //localStorage.getItem("ratiowidth");

        //localStorage.getItem("height");
        //localStorage.getItem("ratioheight");

    }

}

function testFunction() {
    var c = document.getElementById("imgShow");
    var ctx = c.getContext("2d");


    var img = new Image();
    img.onload = function () {
        ctx.globalCompositeOperation = "screen"; // negative multiplizieren
        ctx.drawImage(img, 0, 0, w, h);


    };
    img.src =
        "data:image/gif;base64,R0lGODlhCwALAIAAAAAA3pn/ZiH5BAEAAAEALAAAAAALAAsAAAIUhA+hkcuO4lmNVindo7qyrIXiGBYAOw==";
}




function removeWhiteBackground() {

    var file = document.getElementById("imgShow").src;


    $.ajax({
        type: "POST",
        url: "/Designer/RemoveBackground/",
        data: {
            data: file,

        },
        dataType: 'json',
        success: function (response) {
            // use console.log for debugging, and access the property of the deserialised object
            //console.log(response.isValid);
            console.log(response.imgBase64);
        },
    });

}

function drawImageScaled(img, ctx) {
    var canvas = ctx.canvas;
    var hRatio = canvas.width / img.width;
    var vRatio = canvas.height / img.height;
    var ratio = Math.min(hRatio, vRatio);
    var centerShift_x = (canvas.width - img.width * ratio) / 2;
    var centerShift_y = (canvas.height - img.height * ratio) / 2;
    ctx.clearRect(0, 0, canvas.width, canvas.height);
    ctx.drawImage(img, 0, 0, img.width, img.height,
        centerShift_x, centerShift_y, img.width * ratio, img.height * ratio);
}





function SendJsonData(url) {

    var file = document.getElementById("imgShow");
    console.log(localStorage.getItem("rgbaColor"))

    var ctx = file.getContext("2d");

    //var LogoSizeRatio = JSON.parse(localStorage.getItem("rgbaColor"));

    file = ctx.canvas.toDataURL();

    var postData = { "ValueRGB": 123, "data": file };

    //JSON.stringify({ "Name": $('#name').val(), "Father": $('#father').val(), "Mother": $('#mother').val(), "Age": $('#age').val(), "Email": $('#email').val(), "Phone": $('#phone').val(), "Standard": $('#standard').val(), "Section": $('#section').val() }),


    var fdata = new FormData();
    var filesInput = document.getElementById("inputGroupFile01");
    filesInput = filesInput.files[0];

    if (fdata != null) {

        fdata.append("FileData", filesInput);
        fdata.append("Id", 123);
        fdata.append("ImageBase64", file);
        fdata.append("RemoveColorRGB", JSON.stringify(localStorage.getItem("rgbaColor")));
        fdata.append("Name", "NameFórmdata");
        fdata.append("FilePath", "FilePath");
    }






    $.ajax({
        url: "/Designer/" + url,
        type: "POST",
        data: fdata,
        processData: false,
        contentType: false,
        //data: JSON.stringify({ "Id": 123, "Name": "123", "ImageBase64": file, "FileData": fdata, "RemoveColorRGB": "1234567" }),
        //contentType: "application/json;charset=utf-8",
        success: function (res) {
            if (res.isValid) {




                var img = new Image();
                img.onload = function () {
                    ctx.canvas.height = img.height;
                    ctx.globalCompositeOperation = "screen"; // negative multiplizieren
                    ctx.drawImage(img, 0, 0);

                };
                img.src = 'data:image/png;base64,' + res.imgBase64;


            }
        },
        error: function () {
            console.log("error updating status.");
        }
    });
}



jQueryAjaxSendImage = form => {


    var fdata = new FormData();

    var fileInput = $('#inputGroupFile01')[0];
    var file = fileInput.files[0];


    if (fdata != null) {

        fdata.append("File", file);
    }


    //formData.set('File', file);

    var inputSave = $('#Image')[0];



    try {
        $.ajax({
            type: 'POST',
            url: "/Logo/SaveImage/",
            data: fdata,

            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    localstorageSaveWidthAndHeight(res.jsonString);
                    $("#imgShow").attr('src', 'data:image/png;base64,' + res.fileToSend);
                    document.getElementById("imgShow").hidden = false;
                    inputSave.value = ('data:image/png;base64,' + res.fileToSend);

                    //$('#view-all').html(res.html)
                    //$('#form-modal .modal-body').html('');
                    //$('#form-modal .modal-title').html('');
                    //$('#form-modal').modal('hide');
                    $('#form-modal').modal('show');
                }
                else
                    $('#form-modal .modal-body').html(res.html);
            },
            error: function (err) {
                console.log(err)
            }
        })
        //to prevent default form submit event
        return false;
    } catch (ex) {
        console.log(ex)
    }


    fdata.reset();
    fileInput.value = null;
}



var cropper = "";

fileToImage = (evt) => {

    var uploadedImage = document.getElementById("imgShow");

    var tgt = evt.target || window.event.srcElement,
        files = tgt.files;

    // FileReader support
    if (FileReader && files && files.length) {
        var fr = new FileReader();
        fr.onload = function () {
            uploadedImage.src = fr.result;
        }
        fr.readAsDataURL(files[0]);
    }

    // Not supported
    else {
        // fallback -- perhaps submit the input to an iframe and temporarily store
        // them on the server until the user's session ends.
    }






    // init cropper
    cropper = new Cropper(uploadedImage);


}

CropImage = (evt) => {

    document.getElementById("saveBtn").hidden = false;

    // get the <img> Element what is to cropp
    var uploadedImage = document.getElementById("imgShow");


    // init cropper
    cropper = new Cropper(uploadedImage);



    evt.srcElement.hidden = true;


}

Save = (evt) => {


    //get the element id to change the button state
    evt.srcElement.hidden = true;
    document.getElementById("cropBtn").hidden = false;


    // get the cropped Image with a widh of 300 
    let imgSrc = cropper
        .getCroppedCanvas({
            width: 300, // input value
        });


    //get the Canvas Data from the cropped Image
    /* var canvasData = cropper.canvasData;*/

    let canvasData = JSON.stringify(cropper.cropBoxData);

    localstorageSaveWidthAndHeight(canvasData);

    CalculateImageSizeInMilimeterWidth(evt);

    // save the Cropped image to the <input> Element that it can be sent do the Controller
    var imgSrcToDataUrl = imgSrc.toDataURL();
    var inputSave = document.getElementById("Image");

    document.getElementById("imgShow").src = imgSrcToDataUrl;

    inputSave.value = imgSrcToDataUrl;


    cropper.destroy();




    var valueTest = 123;




    const changeWidth = document.getElementById('width');
    ;
    changeWidth.dispatchEvent(new Event('input', { bubbles: true }));



}

//function fileToImage() {
//    alert("hey");

//}

//document.getelementbyid('inputgroupfile01').onchange = function (evt) {
//    var tgt = evt.target || window.event.srcelement,
//        files = tgt.files;

//    // filereader support
//    if (filereader && files && files.length) {
//        var fr = new filereader();
//        fr.onload = function () {
//            document.getelementbyid(imgshow).src = fr.result;
//        }
//        fr.readasdataurl(files[0]);
//    }

//    // not supported
//    else {
//        // fallback -- perhaps submit the input to an iframe and temporarily store
//        // them on the server until the user's session ends.
//    }
//}


showInPopup = (url, title, Id, offerId) => {
    $.ajax({
        type: 'GET',
        url: "/OrderTextil/AddOrEdit/",

        data: { id: Id, offerId: offerId },
        success: function (res) {
            $('#form-modal .modal-body').html(res);
            $('#form-modal .modal-title').html(title);
            $('#form-modal').modal('show');
            // to make popup draggable
            $('.modal-dialog').draggable({
                handle: ".modal-header"
            });
        }
    })
}



showInPopupLogo = (url, title, Id, offerId, showUserLogos) => {
    $.ajax({
        type: 'GET',
        url: "/Logo/AddOrEdit/",

        data: { id: Id, offerId: offerId, showUserLogos: showUserLogos },
        success: function (res) {
            $('#form-modal .modal-body').html(res);
            $('#form-modal .modal-title').html(title);
            $('#form-modal').modal('show');
            // to make popup draggable
            $('.modal-dialog').draggable({
                handle: ".modal-header"
            });
        }
    })
}



showInPopupDesigner = (url, title, Id, offerId, showUserLogos) => {
    $.ajax({
        type: 'GET',
        url: url,

        data: { id: Id, offerId: offerId, showUserLogos: showUserLogos },
        success: function (res) {
            $('#form-modal .modal-body').html(res);
            $('#form-modal .modal-title').html(title);
            $('#form-modal').modal('show');
            // to make popup draggable
            $('.modal-dialog').draggable({
                handle: ".modal-header"
            });
        }
    })
}



showInPopupPosition = (url, title, Id, orderPositionId, offerId) => {
    $.ajax({
        type: 'GET',
        url: "/Position/AddOrEdit/",

        data: { id: Id, offerId: offerId, orderPositionId: orderPositionId },
        success: function (res) {
            $('#form-modal .modal-body').html(res);
            $('#form-modal .modal-title').html(title);
            $('#form-modal').modal('show');
            // to make popup draggable
            $('.modal-dialog').draggable({
                handle: ".modal-header"
            });
        }
    })
}




jQueryAjaxPost = form => {
    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),

            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $('#view-all').html(res.html)
                    $('#form-modal .modal-body').html('');
                    $('#form-modal .modal-title').html('');
                    $('#form-modal').modal('hide');
                }
                else
                    $('#form-modal .modal-body').html(res.html);
            },
            error: function (err) {
                console.log(err)
            }
        })
        //to prevent default form submit event
        return false;
    } catch (ex) {
        console.log(ex)
    }
}


jQueryAjaxDelete = form => {
    if (confirm('Are you sure to delete this record ?')) {
        try {
            $.ajax({
                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {
                    $('#view-all').html(res.html);
                },
                error: function (err) {
                    console.log(err)
                }
            })
        } catch (ex) {
            console.log(ex)
        }
    }

    //prevent default form submit event
    return false;
}


jQueryAjaxChangeName = form => {

    var offerId = document.getElementById("Offer_OfferId").value;

    try {
        $.ajax({
            url: "/OrderTextil/AddOrderName/",
            type: 'POST',
            dataType: 'JSON',
            data: { offerId: offerId, offerName: form.value },
            success: function (res) {


                $('#view-all').html(res.html);
                $('#orderName').html("<h2>Angebot " + res.orderName + "</h2>");
            },
            error: function (err) {
                console.log(err)
            }
        })
    } catch (ex) {
        console.log(ex)
    }


    //prevent default form submit event
    return false;
}