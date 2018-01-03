// Write your JavaScript code.

$(".item").first().addClass("active");

$('#playButton').click(function () {
    $('#imageCarousel').carousel('cycle');
});
$('#pauseButton').click(function () {
    $('#imageCarousel').carousel('pause');
});

