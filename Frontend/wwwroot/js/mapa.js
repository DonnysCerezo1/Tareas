let mapa;


window.crearMapa = function(paradas)
{

    console.log("Paradas recibidas:", paradas);


    if(mapa)
    {
        mapa.remove();
    }


    if(!paradas || paradas.length === 0)
    {
        console.log("Sin datos");
        return;
    }


    mapa = L.map("mapa");


    L.tileLayer(
        "https://tile.openstreetmap.org/{z}/{x}/{y}.png",
        {
            attribution:
                '&copy; OpenStreetMap'
        }
    ).addTo(mapa);



    let puntos = [];



    paradas.forEach((p, index)=>{


        let punto = [
            p.latitud,
            p.longitud
        ];


        puntos.push(punto);



        L.marker(punto)
            .addTo(mapa)
            .bindPopup(
                `
                <b>
                ${index + 1}. ${p.lugar}
                </b>
                `
            );


    });



    let recorrido = L.polyline(
        puntos,
        {
            weight: 5
        }
    )
        .addTo(mapa);



    mapa.fitBounds(
        recorrido.getBounds()
    );

};