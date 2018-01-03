// Write your JavaScript code.
$(document).ready(function() {
    var tz = Intl.DateTimeFormat().resolvedOptions().timeZone; 
    $(".timezone").append(tz); 
});
