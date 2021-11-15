function abrirModal() {
    var url = "https://localhost:44368/ComprobanteDomicilio/Formulario";
    $.get(url, function (data) {
        $('#modal_info').html(data);
        $('#modal_info').modal({ backdrop: 'static', keyboard: false });
        $('#modal_info').modal('show');
    })
}

function guardar() {
    var nombre = $("#nombre").val();
    $.ajax({
        url: "https://localhost:44368/ComprobanteDomicilio/Guardar",
        data: { nombre: nombre },
        success: function (data) {
            if (data) {
                location.reload();
            } else {
                alert("Ocurrio un error al guardar el registro de comprobante");
            }
        }
    })
}