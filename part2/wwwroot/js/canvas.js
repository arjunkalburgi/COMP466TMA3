

// CONTROL FUNCTIONS
var loaded = 0, numOfImages = 20, next = sequence = forward = true;
var notransition = "0"; 

function startstop() {
	next = !next; 
	console.log("next " + next); 
}

function randomizersequencer() {
	sequence = !sequence; 
	if(sequence) document.getElementById('backwardforward').disabled = false;
    else document.getElementById('backwardforward').disabled = true;
	console.log("sequence " + sequence); 
	console.log("#backwardforward " + (sequence ? "enabled" : "disabled")); 
}

function backwardforward() {
	if (sequence) {
		forward = !forward; 
	}
	console.log("forward " + forward); 
}

$(function(){
    $('select').change(function(){
		notransition = $(this).val(); 
		console.log("transition: " + notransition);
    });
});

