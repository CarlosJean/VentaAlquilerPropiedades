const cmbActionItem = $(".cmbAction .dropdown-item");

cmbActionItem.on("click", function () {
    var action = GetActionId(this.id);  
    var publicationId = GetPublicationId(this.id);
    console.log({ action: action, publicationId: publicationId });
    Actions(action, publicationId);
});

var HidePublication = function (publicationId) {

    Swal.fire({
        title: '¿Está segur@?',
        text: "Esta publicación se marcará como no disponible.",
        icon: 'warning',
        confirmButtonText: "Marcar como no disponible",
        confirmButtonColor: "#d23",
        cancelButtonText: "Cancelar",
        showCancelButton: true
    }).then((result) => {
        if (result.value == true) {
            $.ajax({
                type: "POST",
                url: "Myposts/HidePost",
                data: { publicationId: publicationId },
                dataType: "json",
                success: function (res) {
                    Swal.fire(
                        'Éxito!',
                        res.Status,
                        'success'
                    ).then((result) => {
                        if (result.value == true) {
                            location.reload();
                        }
                    })
                },
                error: function (jqXHR, textStatus) {
                    alert(textStatus);
                }

            });
            
        }
    });

    
}

var ShowPublication = function (publicationId) {

    Swal.fire({
        title: '¿Está segur@?',
        text: "Esta publicación se marcará como disponible.",
        icon: 'warning',
        confirmButtonText: "Marcar como disponible",
        confirmButtonColor: "#368625",
        cancelButtonText: "Cancelar",
        showCancelButton: true
    }).then((result) => {
        if (result.value == true) {
            $.ajax({
                type: "POST",
                url: "Myposts/ShowPost",
                data: { publicationId: publicationId },
                dataType: "json",
                success: function (res) {
                    Swal.fire(
                        'Éxito!',
                        res.Status,
                        'success'
                    ).then((result) => {
                        if (result.value == true) {
                            location.reload();
                        }
                    })
                },
                error: function (jqXHR, textStatus) {
                    alert(textStatus);
                }

            });

        }
    });
}
var PostDetail = function (publicationId) {
    var route = "/Detalle?id=" + publicationId;
    console.log(route);
    window.location.href=route;
        
}

var GetPublicationId = function (elementId) {

    let split = elementId.split("_");
    let publicationId = split[1];
    return publicationId;
}

var GetActionId = function (elementId) {

    let split = elementId.split("_");
    let action = split[0];
    return action;
}

var Actions = function (actionId, publicationId) {
    console.log({ actionId: actionId, publicationId: publicationId});
    switch (actionId) {
        case "viewDetail":
            PostDetail(publicationId);
            break;
        case "hidePost":
            HidePublication(publicationId);
            break;
        case "showPost":
            ShowPublication(publicationId);
            break;
    }
}