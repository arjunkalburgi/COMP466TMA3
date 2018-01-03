// Write your JavaScript code.

$(".item").first().addClass("active");

$('#playButton').click(function () {
    $('#imageCarousel').carousel('cycle');
});
$('#pauseButton').click(function () {
    $('#imageCarousel').carousel('pause');
});

var random = true; 
$("#randomButton").click(function () {
    // remove buttons 
    $(".carousel-control").hide();

    // remove data-interval from carousel
    $('#imageCarousel').carousel('pause');

    // make random
    random = true; 
    currentSlide = Math.floor((Math.random() * $('.item').length));
    rand = currentSlide;
    $('#imageCarousel').carousel(currentSlide);
    $('#imageCarousel').fadeIn(1000);
    randomizer = setInterval(function() { 
        while (rand == currentSlide) {
            rand = Math.floor((Math.random() * $('.item').length));
        }
        currentSlide = rand;
        $('#imageCarousel').carousel(rand);
        if (!random) {
            clearInterval(randomizer);
        }
    },2000);
});

$("#sequenceButton").click(function () {
    // show buttons 
    $(".carousel-control").show();

    // force sequence
    random = false; 

    // add back data-interval from carousel
    $('#imageCarousel').carousel('cycle');

})