
//Declarar las variables
var sliderPrice      = $("#sliderPrice");
var spnPrice         =  $("#spnPrice");
var fromPrice        = 500000
var toPrice          = 10000000
var slcPropertyTypes = $("#slcPropertyTypes");
var slcSectors       = $("#slcSectors");
var slcProvinces     = $("#slcProvinces");
var dvPublicationTypes = $("#dvPublicationTypes");
//var chkPublicationTypes = $("<input/>", {type:'checkbox', name:'PublicationTypes'});
//var chkPublicationTypes2 = $("<input/>", {type:'checkbox', name:'PublicationTypes'});


//Declarar las funciones
function formatMoney(number, decPlaces, decSep, thouSep) {
    decPlaces = isNaN(decPlaces = Math.abs(decPlaces)) ? 2 : decPlaces,
    decSep = typeof decSep === "undefined" ? "." : decSep;
    thouSep = typeof thouSep === "undefined" ? "," : thouSep;
    var sign = number < 0 ? "-" : "";
    var i = String(parseInt(number = Math.abs(Number(number) || 0).toFixed(decPlaces)));
    var j = (j = i.length) > 3 ? j % 3 : 0;

    return sign +
        (j ? i.substr(0, j) + thouSep : "") +
        i.substr(j).replace(/(\decSep{3})(?=\decSep)/g, "$1" + thouSep) +
        (decPlaces ? decSep + Math.abs(number - i).toFixed(decPlaces).slice(2) : "");
}
function AppendOption(idSelect, option) {
    idSelect.append(option);
}
function GetPropertyTypes() {
    $.ajax({
        type: "POST",
        url: "/home/PropertyTypes",
        success: function (res) {
            var json = JSON.parse(res);
            json.forEach(function (elemento) {
                option = "<option value=" + elemento.IdPropertyType + ">" + elemento.Description+"</option>";
                AppendOption(slcPropertyTypes, option)
            });

            slcPropertyTypes.append();

        },
        error: function (settings, jqXHR) {
            alert(jqXHR);
        }
    });

}
function GetProvinces() {
    $.ajax({
        type: "POST",
        url: "/home/Provincias",
        success: function (res) {
            var json = JSON.parse(res);
            json.forEach(function (province) {
                slcProvinces.append("<option value=" + province.IdProvincia + ">" + province.Descripcion + "</option>");

            });
        },
        error: function (settings, jqxhr) {
            alert(jqxhr);
        }
    });
}
function GetPublicationTypes() {
    $.ajax({
        type: "POST",
        url: "/home/PublicationTypes",
        success: function (res) {
            var json = JSON.parse(res);
            //console.log(json);
            //dvPublicationTypes.append(chkPublicationTypes2);
            json.forEach(function (publicationType) {

                var chkPublicationTypes = $("<input/>", {
                                                            type: 'checkbox', name: 'PublicationTypes',
                                                            id: "chkPropertyType" + publicationType.IdPublicationType,
                                                            value: publicationType.IdPublicationType
                });

                var labelPropertyType = $("<label>", {
                    for: "chkPropertyType" + publicationType.IdPublicationType, class: "col-sm-6",
                    text: publicationType.Description
                });

                labelPropertyType.prepend(chkPublicationTypes);
                dvPublicationTypes.append(labelPropertyType);
            });
        },
        error: function (settings, jqxhr) {
            alert(jqxhr);
        }
    });
}
function GetPublications() {

    var price = JSON.stringify([500000,1000000]);

    var propertyType = 1;
    var publicationTypes = JSON.stringify([1, 2]);
    var province         = 1;
    var sector = 1

    console.log(price);

    $.ajax({
        type: "POST",
        url: "/home/Publications",
        data: { Price: price, PropertyType: propertyType, PublicationTypes: publicationTypes, 
                Province: province, Sector: sector },
        success: function (res) {
            console.log(res);
        },
        error: function (settings, jqXHR) {
            alert(jqXHR);
        }
    });
}

//Ejecutar las funciones
GetPublicationTypes();
GetPropertyTypes();
GetProvinces();
GetPublications();

spnPrice.text("$" + fromPrice + " - $" + toPrice);

//Manejar los eventos
sliderPrice.slider({
    range: true,
    min: 500000,
    max: 10000000,
    animate: true,
    step: 100,
    values: [500000, 10000000],
    slide: function (event, ui) {
        fromPrice = formatMoney(ui.values[0], 2, '.', ',');
        toPrice = formatMoney(ui.values[1], 2, '.', ',');
        spnPrice.text("$" + fromPrice + " - $" + toPrice);
    }
});
slcProvinces.change(function () {
    var selectedValue = parseInt($("#slcProvinces option:selected").val());
    $.ajax({
        type: "Post",
        url: "/home/Sectores",
        data: { idProvincia: selectedValue },
        success: function (res) {
            var json = JSON.parse(res);

            slcSectors.empty();
            slcSectors.append("<option value=0>Todos los sectores</option >");
            json.forEach(function (item) {
                slcSectors.append("<option value=" + item.IdSector + ">" + item.Descripcion + "</option >");

            });
        },
        error: function () {
        }

    });
});