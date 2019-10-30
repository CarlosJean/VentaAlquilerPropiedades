
//Declaración de variables
var slcPrecioDesde = $("#slcPrecioDesde");
var slcPrecioHasta = $("#slcPrecioHasta");
var slcProvincia   = $("#slcProvincia");
var slcSector      = $("#slcSector");
var btnBuscar      = $("#btnBuscar");

    //Declaración de funciones
function cargarPrecios() {

        $.ajax({
            type: "POST",
            url: "/home/Precios",
            success: function (res) {

                var respuesta = JSON.parse(res);
                for (var indice = 0; indice < respuesta.length; indice++) {

                    slcPrecioDesde.append("<option value=" + respuesta[indice].IdPrecio + ">" + respuesta[indice].Descripcion + "</option >");
                    slcPrecioHasta.append("<option value=" + respuesta[indice].IdPrecio + ">" + respuesta[indice].Descripcion + "</option >");
                }

            },
            error: function (settings, jqxhr) {
                alert(jqxhr);
            }

        }).done(function () {
            //console.log($("#slcPrecioHasta").val());
            $("#slcPrecioHasta option[value='1']").prop("selected", true);
        });
}
function cargarProvincias() {
    $.ajax({
        type: "POST",
        url: "/home/Provincias",
        success: function (res) {
            var respuesta = JSON.parse(res);
            for (var indice = 0; indice < respuesta.length; indice++) {

                slcProvincia.append("<option value=" + respuesta[indice].IdProvincia + ">" + respuesta[indice].Descripcion + "</option >");
            }
        },
        error: function (settings, jqxhr) {
            alert(jqxhr);
        }
    }).done(function () {
        //$("#slcProvincia option[value='']").prop("selected", true);
    });
}


//Acciones 
cargarPrecios();
cargarProvincias();

slcPrecioDesde.change(function () {         
        var selectedValue = parseInt($("select option:selected").val()) + 1;
        $("#slcPrecioHasta option[value='"+(selectedValue)+"']").prop("selected", true);
});

slcProvincia.change(function () {
    var selectedValue = parseInt($("#slcProvincia option:selected").val());
    $.ajax({
        type: "Post",
        url: "home/Sectores",
        data: { idProvincia: selectedValue },
        success: function (res) {
            var json = JSON.parse(res);

            slcSector.empty();
            slcSector.append("<option value=0>Seleccione un sector</option >");
            json.forEach(function (item) {
                slcSector.append("<option value=" + item.IdSector + ">" + item.Descripcion + "</option >");

            });
        },
        error: function () {
        }

    });
});

btnBuscar.on("click", function () {
    $.ajax({
        type: "POST",
        url: "home/Casas",
        success: function (res) {
            console.log(res);
        },
        error: function (error,jqXHR) {
            alert(jqXHR);
        }


    });

});