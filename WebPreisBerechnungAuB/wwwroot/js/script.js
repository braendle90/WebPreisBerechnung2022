var c;
var ctx;
var w = 1024;
var h = 768;
var hexCodeHtml = "#131698";
let restore_array = [];
let index = -1;
var logo;

function clickColor() {
  hexCodeHtml = document.getElementById("html5colorpicker").value;

  draw1();
}

// set the data from Canvas and the canvas height an width
CanvasData();

function CanvasData() {
  c = document.getElementById("canvas");
  ctx = c.getContext("2d");
  c.width = w;
  c.height = h;
}

draw1();

function draw1() {
  var img = new Image();
  img.onload = function () {
    ctx.drawImage(img, 0, 0, w, h);
    ctx.globalCompositeOperation = "source-in";
    // set composite mode

    // draw color
    ctx.fillStyle = hexCodeHtml;
    ctx.fillRect(0, 0, c.width, c.height);
  };
  img.src = "/img/shirt/Base_Vorlage.svg";
  draw2();
}

function draw2() {
  var img = new Image();
  img.onload = function () {
    ctx.globalCompositeOperation = "multiply";
    ctx.drawImage(img, 0, 0, w, h);
  };
  img.src = "/img/shirt/shadows_multiplizieren.png";
  draw3();
}

function draw3() {
  var img = new Image();
  img.onload = function () {
    ctx.globalCompositeOperation = "screen"; // negative multiplizieren
    ctx.drawImage(img, 0, 0, w, h);

    restore_array.push(ctx.getImageData(0, 0, canvas.width, canvas.height));
    index += 1;
  };
  img.src = "/img/shirt/highlights_negative_muliplizieren.png";
}


function setDPI(dpi) {

  //load the canvas from the variable c
  var canvas = c;
  // Set up CSS size.
  canvas.style.width = canvas.style.width || canvas.width + 'px';
  canvas.style.height = canvas.style.height || canvas.height + 'px';

  // Get size information.
  var scaleFactor = dpi / 96;
  var width = parseFloat(canvas.style.width);
  var height = parseFloat(canvas.style.height);
  

  // Backup the canvas contents.
  var oldScale = canvas.width / width;
  var backupScale = scaleFactor / oldScale;
  var backup = canvas.cloneNode(false);
  backup.getContext('2d').drawImage(canvas, 0, 0);

  // Resize the canvas.
  var ctx = canvas.getContext('2d');
  canvas.width = Math.ceil(width * scaleFactor);
  canvas.height = Math.ceil(height * scaleFactor);

  // Redraw the canvas image and scale future draws.
  ctx.setTransform(backupScale, 0, 0, backupScale, 0, 0);
  ctx.drawImage(backup, 0, 0);
  ctx.setTransform(scaleFactor, 0, 0, scaleFactor, 0, 0);
}