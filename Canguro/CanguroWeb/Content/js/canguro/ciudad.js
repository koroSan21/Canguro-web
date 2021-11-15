function abrirModal(id) {
    var url = "https://localhost:44368/Ciudad/Formulario?Id="+id;
    $.get(url, function (data) {
        $('#modal_info').html(data);
        $('#modal_info').modal({ backdrop: 'static', keyboard: false });
        $('#modal_info').modal('show');
    })
}

function guardar() {
    var id = $("#idCiudad").val();
    var nombre = $("#nombre").val();
    var estado = $("#estado").val();
    $.ajax({
        url: "https://localhost:44368/Ciudad/Guardar",
        data: {id: id, nombre: nombre, estado: estado },
        success: function (data) {
            if (data) {
                location.reload();
            } else {
                alert("Ocurrio un error al guardar el registro de ciudad");
            }
        }
    })
}

function eliminar(id) {
    if(confirm("¿Esta seguro que desea eliminar el registro?")){
        $.ajax({
            url: "https://localhost:44368/Ciudad/Eliminar",
            data: { id: id },
            success: function (data) {
                if (data) {
                    alert("El registro fue eliminado correctamente")
                    location.reload();
                } else {
                    alert("El registro no pudo ser eliminado. Es posible que tenga relación con otro registro");
                }
            }
        })
    }
    
}

