/*function initMap() {
    // The location of Uluru
    //https://maps.googleapis.com/maps/api/geocode/json?&address=4321%2022nd%20Avenue%20Kenosha%20WI&key=AIzaSyBcwWMcJNZrBLaqQMBogJQgKcLgdfp7eH0
    var loc =
        $.ajax({
            url: "https://maps.googleapis.com/maps/api/geocode/json&address=@Model.Address@Model.City@Model.State&key=AIzaSyBcwWMcJNZrBLaqQMBogJQgKcLgdfp7eH0",
            type: "POST",

            dataType: "jsonp",
            cache: false,
            success: function (data) {
                var uluru = { lat: data.geometry.location.lat, data: data.geometry.location.lng };
                // The map, centered at Uluru
                var map = new google.maps.Map(
                    document.getElementById('map'), { zoom: 4, center: uluru });
                // The marker, positioned at Uluru
                var marker = new google.maps.Marker({ position: uluru, map: map });
            }
        });
}*/