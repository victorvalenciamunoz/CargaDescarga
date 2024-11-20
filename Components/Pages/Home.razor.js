var map;
var markers = [];
var componentRef;
export function initializeMap(dotNetRef) {
    componentRef = dotNetRef;
    // Inicializa el mapa centrado en coordenadas espec�ficas
    map = L.map('map').setView([40.4168, -3.7038], 13); // Ejemplo: Madrid

    // Agrega la capa de OpenStreetMap
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        maxZoom: 19,
        attribution: '� OpenStreetMap contributors'
    }).addTo(map);
}

export function AddCurrentUserLocationMarker(lat, lon) {
    // Define una imagen personalizada para la posici�n actual del usuario
    var userLocationIcon = L.icon({
        iconUrl: '/images/userlocation.png', // Ruta a tu imagen personalizada
        iconSize: [24, 32], // Tama�o del icono
        iconAnchor: [16, 32], // Punto del icono que se corresponder� con la posici�n del marcador
        popupAnchor: [0, -32] // Punto desde el cual se abrir� el popup relativo al icono
    });

    // Agrega el marcador de la posici�n actual del usuario al mapa
    var userLocationMarker = L.marker([lat, lon], { icon: userLocationIcon }).addTo(map);
    markers.push(userLocationMarker);

    map.setView([lat, lon], 13);
}

export function AddMarkers(positions) {
    var customIcon = L.icon({
        iconUrl: '/images/pinmap.png', // Ruta a tu imagen personalizada
        iconSize: [24, 32], // Tama�o del icono
        iconAnchor: [16, 32], // Punto del icono que se corresponder� con la posici�n del marcador
        popupAnchor: [0, -32] // Punto desde el cual se abrir� el popup relativo al icono
    });
    positions.forEach(marker => {
        console.log(marker);
        var leafletMarker = L.marker([marker.lat, marker.lon], {icon: customIcon}).addTo(map);
        //leafletMarker.bindPopup(marker.info);

        // Evento de clic para llamar a Blazor
        leafletMarker.on('click', function () {
            componentRef.invokeMethodAsync('MarkerClicked', marker.lat, marker.lon);
        });
        markers.push(marker);
    });
}

export function ClearMarkers() {
    markers.forEach(marker => {
        map.removeLayer(marker);
    });
    markers = [];
}