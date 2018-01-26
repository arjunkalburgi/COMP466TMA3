// Write your JavaScript code.
$(document).ready(function() {

	// source: https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/DateTimeFormat    var tz = Intl.DateTimeFormat().resolvedOptions().timeZone; 
    $(".timezone").append(tz); 
});
