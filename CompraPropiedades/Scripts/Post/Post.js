var dvAccomodations = $("#dvAccomodations");
var slcProvinces    = $("#slcProvinces");
var slcSectors      = $("#slcSectors");
var dvPublicationTypes = $("#dvPublicationTypes");
var slcPropertyTypes = $("#slcPropertyTypes");
var slcPublicationTypes = $("#slcPublicationTypes");

function GetAccomodations() {
    $.ajax({
        type:"POST",
        url: "/Post/GetAccomodations",
        success: function (res) {
            var jsonAccomodations = JSON.parse(res);
            jsonAccomodations.forEach(function (accomodation) {

               // console.log(accomodation.IdAcommodation);
                var label = $("<label/>", { for: "chkAccomodation_" + accomodation.IdAcommodation, text: accomodation.Description, class:"col-sm-4" });
                var chkAccomodation = $("<input/>", { type: "checkbox", name: "Accomodations", id: "chkAccomodation_" + accomodation.IdAcommodation, value: accomodation.IdAcommodation });

                console.log(label);
                console.log(dvAccomodations);
                label.prepend(chkAccomodation);
                dvAccomodations.append(label);
            });

        },
        error: function (settings, jqXHR) {
            alert(jqXHR);
        }});
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
function GetPropertyTypes() {
    $.ajax({
        type: "POST",
        url: "/home/PropertyTypes",
        success: function (res) {
            var json = JSON.parse(res);
            json.forEach(function (elemento) {
                option = "<option value=" + elemento.IdPropertyType + ">" + elemento.Description + "</option>";
                AppendElement(slcPropertyTypes, option)
            });

            slcPropertyTypes.append();

        },
        error: function (settings, jqXHR) {
            alert(jqXHR);
        }
    });

}
function AppendElement(parentElement, element) {
    parentElement.append(element);
}
function GetPublicationTypes() {
    $.ajax({
        type: "POST",
        url: "/home/PublicationTypes",
        success: function (res) {
            var json = JSON.parse(res);
            json.forEach(function (elemento) {
                option = "<option value=" + elemento.IdPublicationType + ">" + elemento.Description + "</option>";
                AppendElement(slcPublicationTypes, option)
            });

            slcPropertyTypes.append();

        },
        error: function (settings, jqXHR) {
            alert(jqXHR);
        }
    });
}
function UploadFiles() {

}

GetProvinces();
GetAccomodations();
GetPropertyTypes();
GetPublicationTypes();


slcProvinces.change(function () {
    var selectedValue = parseInt($("#slcProvinces option:selected").val());
    $.ajax({
        type: "Post",
        url: "/home/Sectores",
        data: { idProvincia: selectedValue },
        success: function (res) {
            var json = JSON.parse(res);

            slcSectors.empty();
            slcSectors.append("<option value=0>Sector</option >");
            json.forEach(function (item) {
                slcSectors.append("<option value=" + item.IdSector + ">" + item.Description + "</option>");

            });
        },
        error: function () {
        }

    });
});