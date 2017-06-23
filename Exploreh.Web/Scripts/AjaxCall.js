
/**
 * Chamada ajax para apresentar detalhes do usuário na Modal
 * @param {} value 
 * @param {} id 
 * @returns {} 
 */
function Detalhes(value, url) {

    var modal = $('.modal-body > p');

    $.ajax({
        url: url,
        type: 'POST',
        data: { id: value },
        success: function (data) {
            var $select = modal;
            $select.html('');
            $select.append(HtmlBuild(data));
        },
        error: function (xhr) { }
    });


}


function Deletar(value, url) {

    var modal = $('.modal-body > p');

    $.ajax({
        url: url,
        type: 'POST',
        data: { id: value },
        success: function (data) {
            var $select = modal;
            $select.html('');
            $select.append(HtmlBuildDelete(data));
        },
        error: function (xhr) { }
    });


}


function ExcluirConfirmar(model, url, urlafter) {

    $.ajax({
        url: url,
        type: 'POST',
        data: JSON.stringify(model),
        contentType: "application/json",
        success: function (data) {
            setTimeout(function () {
                    swal({
                        title: "Good job!",
                        text: "Usuário removido com sucesso!",
                        type: "success"
                    });
                },
                1000);
        },
        error: function (xhr) { }
    });
}



function HtmlBuild(data) {

    return [
        '<div class="panel-body" id="dynamicModal">' +
        '<div class="input-group input-fields">' +
        '<span class="input-group-addon">Nome</span>' +
        '<input disabled id="Nome" type="text" class="form-control" name="Nome" value="' + data.Nome + '">' +
        '</div>' +
        '<div class="input-group input-fields">' +
        '<span class="input-group-addon">E-mail</span>' +
        '<input disabled id="Email" type="text" class="form-control" name="Email" value="' + data.Email + '">' +
        '</div>' +
        '<div class="input-group input-fields">' +
        '<span class="input-group-addon">Ativo</span>' +
        '<div style="margin-left: 10px"> <input disabled type="checkbox" name="Ativo"' + data.Ativo + '"></div>' +
        '</div>' +

        //'<div class="input-group input-fields">' +
        //'<span class="input-group-addon">Ativo</span>' +
        //'<div style="margin-left: 10px"> <input disabled type="text" class="form-control" name="DataCadastro" value="' + data.DataCadastro + '"></div>' +
        //'</div>' +

        //'<div class="input-group input-fields">' +
        //'<span class="input-group-addon">Ativo</span>' +
        //'<div style="margin-left: 10px"> <input disabled type="text" class="form-control" name="DataCadastro" value="' + data.DataAlteracao + '"></div>' +
        //'</div>' +

        '<div class="input-group input-fields">' +
        '<span class="input-group-addon">Perfil</span>' +
        '<input disabled id="PerfilId" type="text" class="form-control" name="PerfilId" value="' + data.PerfilId + '">' +
        '</div>' +
        '</div>'
    ];

}


function HtmlBuildDelete(data) {

    return [
        '<div class="panel-body" id="dynamicModal">' +
        '<div class="input-group input-fields">' +
        '<span class="input-group-addon">Nome</span>' +
        '<input hidden="hidden" id="Id" type="text" name="Id" value="' + data.Id + '">' +
        '<input disabled id="Nome" type="text" class="form-control" name="Nome" value="' + data.Nome + '">' +
        '</div>' +
        '<div class="input-group input-fields">' +
        '<span class="input-group-addon">E-mail</span>' +
        '<input disabled id="Email" type="text" class="form-control" name="Email" value="' + data.Email + '">' +
        '</div>' +
        '<div class="input-group input-fields">' +
        '<span class="input-group-addon">Ativo</span>' +
        '<div style="margin-left: 10px"> <input disabled type="checkbox" name="Ativo"' + data.Ativo + '"></div>' +
        '</div>' +

        '<div class="input-group input-fields">' +
        '<span class="input-group-addon">Perfil</span>' +
        '<input disabled id="PerfilId" type="text" class="form-control" name="PerfilId" value="' + data.PerfilId + '">' +
        '</div>' +
        '</div>'
    ];

}