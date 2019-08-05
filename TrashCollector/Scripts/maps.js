
// Initialize and add the map

var loc = { lat: 0, lng: 0 };
function getLoc(x) {
    $.ajax({
        url: "https://maps.googleapis.com/maps/api/geocode/json?address="+ x + "&key=AIzaSyBcwWMcJNZrBLaqQMBogJQgKcLgdfp7eH0",
        type: "POST",
        dataType: "json",

        success: function (data) {
            console.log(data);
            loc = { lat: data.results[0].geometry.location.lat, lng: data.results[0].geometry.location.lng };
            initMap7599();
        }
    });
}


function initMap7599() {
    var map = new google.maps.Map(
        document.getElementById('map'), { zoom: 4, center: loc });

    var marker = new google.maps.Marker({ position: loc, map: map });
}
