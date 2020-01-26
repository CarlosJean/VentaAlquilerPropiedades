//Declarar las variables
var sliderPrice         = $("#sliderPrice");
var spnPrice            = $("#spnPrice");
var fromPrice           = 500000
var toPrice             = 10000000
var slcPropertyTypes    = $("#slcPropertyTypes");
var slcSectors          = $("#slcSectors");
var slcProvinces        = $("#slcProvinces");
var dvPublicationTypes  = $("#dvPublicationTypes");
var secPublications     = $("#secPublications");
var publicationsPerPage = 36
var ulPagination        = $(".pagination");
var paginationBar       = $("#paginationBar");
var numberPages         = 0;
var dvPublication       = $("#secPublications");


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

//Función que añade elementos a otro.
function AppendElement(parentElement, element) {
    parentElement.append(element);
}
function LoadPaginationBar(currentPageNumber = 1) {

    ulPagination.empty();

    if (numberPages > 0) {

        //Añadir el botón de 'anterior'.
        if (currentPageNumber == 1) {
            var li = $("<li/>", { class: "page-item disabled", id: 'li_previous' });
            var a = $("<a/>", { class: "page-link", text: '<<'/*, href: "#"*/ });
        } else {
            var li = $("<li/>", { class: "page-item", id: 'li_previous' });
            var a = $("<a/>", { class: "page-link", text: '<<'/*, href: "#"*/ });
        }

        AppendElement(li, a);
        AppendElement(ulPagination, li);

        //numberPages = 31;

        //console.log((numberPages%10));
        //console.log((numberPages%10)%1);
        //if (currentPageNumber <= 10)
        //    numberPagesShown = 10
        //else {
        //    numberPagesShown = currentPageNumber+((numberPages - currentPageNumber));
        //    //currentPageNumber = 10 + 1;
        //}
        
        
        //var arrIndexes = Math.ceil((numberPages / 10));
        var data = [];
        //if ((numberPages % 10) > 0) {
        //    arrIndexes++;
        //}

        //console.log(arrIndexes);
        //var arr  = [];
        //    for (var indice = 1; indice <= numberPages; indice++) {

        //        //console.log(arr.length);
        //        if (arr.length <= 10) {
        //            arr.push(indice);
        //        } else if (arr.length == 11) {
        //            arr.push(indice);           
        //            data.push(arr);
        //            arr = [];
        //        }

                
        //    }
        

        //console.log(data);



        for (var index = 1; index <= numberPages; index++) {
                if (index != currentPageNumber) {
                    li = $("<li/>", { class: "page-item", id: `li_${index}` });
                    a = $("<a/>", { class: "page-link", text: index/*, href: "#"*/ });
                } else {
                    li = $("<li/>", { class: "page-item active", id: `li_${index}` });
                    a = $("<a/>", { class: "page-link", text: index/*, href: "#" */});
                }           
            li.append(a);
            ulPagination.append(li);
        }
        //Añadir el botón de 'siguiente'.
        if (currentPageNumber == numberPages) {
            li = $("<li/>", { class: "page-item disabled", id: 'li_next' });
            a = $("<a/>", { class: "page-link", text: '>>' });
        } else {
            li = $("<li/>", { class: "page-item", id: 'li_next' });
            a = $("<a/>", { class: "page-link", text: '>>' });
        }
       

        AppendElement(li, a);
        AppendElement(ulPagination, li);
    }
}
function LoadPublications(jsonPublications) {
    console.log(jsonPublications);
    secPublications.empty();
    jsonPublications.forEach(function (publication, index) {
        var image = '';
        if (publication[index].Image.length > 0) {
            image = `<image src= ${publication[index].Image[0]["Image"]} />`;
        }

        var divPublication = `<div class='col-sm-2 dvPublication' id=${publication[index].IdPublication}>
                                <div id='dvPublicationImage' >
                                   ${image}
                                </div>
                                <div class="dvPublicationDetails">
                                    <p><strong>${publication[index].Title}</strong></p>
                                    <p>RD$ ${publication[index].PropertyPrice}</p>
                                </div>
                           </div>`;

        AppendElement(secPublications, divPublication);
    });
}
function GetPropertyTypes() {
    $.ajax({
        type: "POST",
        url: "/home/PropertyTypes",
        success: function (res) {
            var json = JSON.parse(res);
            json.forEach(function (elemento) {
                option = "<option value=" + elemento.IdPropertyType + ">" + elemento.Description+"</option>";
                AppendElement(slcPropertyTypes, option)
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
                slcProvinces.append("<option value=" + province.IdProvince + ">" + province.Description + "</option>");

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
        async: false,
        success: function (res) {
            var json = JSON.parse(res);
            json.forEach(function (publicationType) {

                var chkPublicationTypes = $("<input/>", {
                    type: 'checkbox', name: 'PublicationTypes',
                    id: "chkPropertyType" + publicationType.IdPublicationType,
                    value: publicationType.IdPublicationType,
                    class: "chkPropertyType"
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
    }).done(function (res) {

        
    });
}
function GetPublications(rownumberFrom = 1, rownumberTo = publicationsPerPage, currentPageNumber = 1) {

    var price = JSON.stringify([fromPrice, toPrice]);

    var propertyType = parseInt($("#slcPropertyTypes option:selected").val());
    var selectedPublicationTypes = $("input[type=checkbox]:checked");

    var publicationTypes = [];
    selectedPublicationTypes.each(function () {
        publicationTypes.push(this.value);
    });

    publicationTypes =  JSON.stringify(publicationTypes);
    var province     =  parseInt($("#slcProvinces option:selected").val());
    var sector       =  parseInt($("#slcSectors option:selected").val());

    $.ajax({
        type: "POST",
        url: "/home/Publications",
        data: {
            Price: price, PropertyType: propertyType, PublicationTypes: publicationTypes,
            Province: province, Sector: sector, rownumberFrom: rownumberFrom, rownumberTo: rownumberTo
        },
        async: false,
        success: function (res) {

            var json       = JSON.parse(res);
            var jsonLenght = json.length;
            
            if (jsonLenght > 0) {                                                               
                if (jsonLenght % publicationsPerPage > 0)
                    numberPages = 0;  
                    numberPages++;                                           
            }

            LoadPaginationBar(currentPageNumber);
            LoadPublications(json);
                      
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
        fromPrice = ui.values[0];
        toPrice   = ui.values[1];

        fromPriceFormatted = formatMoney(fromPrice, 2, '.', ',');
        toPriceFormatted   = formatMoney(toPrice, 2, '.', ',');


        spnPrice.text("$" + fromPriceFormatted + " - $" + toPriceFormatted);
    }
})

sliderPrice.mouseup(function (event ) {
    GetPublications();
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
                slcSectors.append("<option value=" + item.IdSector + ">" + item.Description + "</option >");

            });
        },
        error: function () {
        }

    });
});

$(".chkPropertyType").change(function () {
    GetPublications();
});

$("select").on('change', function () {
    GetPublications();
})

ulPagination.on('click', 'li', function () {

    var liId = $(this).attr("id");
    var liIdArr = liId.split("_");
    var currentPageNumber = liIdArr[1];

    console.log(currentPageNumber);

    var liPrevious = $("#li_previous");
    var liNext     = $("#li_next");

    if ($(this).attr("class") != "page-item disabled") {
        
        var liActive = $("li.active");

        if ($(this).attr("id") == "li_next") {
            
            liId = liActive.attr("id");

            currentPageNumber = parseInt(liId.split("_")[1]) + 1;
        } else if ($(this).attr("id") == "li_previous") {
            liId = liActive.attr("id");
            currentPageNumber = parseInt(liId.split("_")[1]) - 1;
        }

        if (currentPageNumber == 1) {
            liPrevious.attr("class", "page-item disabled");
        } else if (currentPageNumber > 1) {
            liPrevious.removeClass("disabled");
        }

        if (currentPageNumber >= numberPages) {
            liNext.attr("class", "page-item disabled");
        } else if (currentPageNumber < numberPages) {
            liNext.removeClass("page-item disabled");
        }

        $("li.active").removeClass("page-item active");
        $("#li_" + currentPageNumber).attr("class", "page-item active");

        var rownumberFrom = (((currentPageNumber - 1) * publicationsPerPage) + 1);
        var rownumberTo = rownumberFrom + 35;

        GetPublications(rownumberFrom, rownumberTo, currentPageNumber);
    }
     
});

dvPublication.on("click", ".dvPublication", function () {

    //console.log("Detalle?id=" + $(this).attr("id"));
    window.location.href = "Detalle?id=" + $(this).attr("id");
    //$.ajax({
    //    type:"POST",
    //    url: "Detalle",
    //    success: function (res) {
    //        console.log(res);
    //    },
    //    error: function (settings, jqXHR) {
    //        alert(jqXHR);
    //    }
        
    //});
});