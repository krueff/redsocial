        $(document).ready(function () {
            $("#<%=txtBuscar.ClientID%>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/autocompletar.asmx/GetNombres") %>',
                        data: "{ 'UsuarioNombre': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response(data.d);
                        },
                        error: function (response) {
                            alert(response.responseText);
                        },
                        failure: function (response) {
                            alert(response.responseText);
                        }
                    });
                },
                minLength: 1
            });
        });