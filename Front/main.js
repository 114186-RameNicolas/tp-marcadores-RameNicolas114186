function obtenerMarcadoresDesdeGET() {
    var url = 'https://localhost:7033/api/Marcador/ObtenerMarcadores';
    return fetch(url)
        .then(response => {
        if (!response.ok) {
            throw new Error('Error en la solicitud. Código de estado: ' + response.status);
        }
        return response.json();
        })
        .then(data => {
        if (data.ok) {
            return data.litadoMarcadores;
        } else {
            throw new Error(data.error);
        }
    });
}
obtenerMarcadoresDesdeGET()
    .then(marcadores => {
        var mapContainer = document.getElementById('mapContainer');
        var platform = new H.service.Platform({
        apikey: '9aUQK7CS_xYwtrZ3rMhLfJGkQ3VM1W1IYSIaKId1tB0'
        });
        var defaultLayers = platform.createDefaultLayers();
        var map = new H.Map(
        mapContainer,
        defaultLayers.vector.normal.map,
        {
            zoom: 15,
            center: { lng: marcadores[0].longitud, lat: marcadores[0].latitud }
        }
    );
        var marker1 = new H.map.Marker({ lng: marcadores[0].longitud, lat: marcadores[0].latitud });
        var marker2 = new H.map.Marker({ lng: marcadores[1].longitud, lat: marcadores[1].latitud });  
        map.addObjects([marker1, marker2]);
    })
    .catch(error => {
        console.error(error);
    });
