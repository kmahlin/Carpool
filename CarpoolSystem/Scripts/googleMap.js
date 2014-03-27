var myCenter = new google.maps.LatLng(51.508742, -0.120850);
var marker;
function initialize() {
    var mapProp = {
        center: myCenter,
        zoom: 15,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);
    marker = new google.maps.Marker({
        position: myCenter,
        // icon:'themes/assets/images/nepali-momo.png',
        animation: google.maps.Animation.BOUNCE
    });

    marker.setMap(map);

    // Info open
    var infowindow = new google.maps.InfoWindow({
        content: "DOTDOT"
    });

    google.maps.event.addListener(marker, 'click', function () {
        infowindow.open(map, marker);
    });
}
google.maps.event.addDomListener(window, 'load', initialize);