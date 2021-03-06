﻿
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
            $select.append(HtmlBuildEditar(data));
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

function ExcluirConfirmar(model, url) {

    $.ajax({
        url: url,
        type: 'POST',
        data: JSON.stringify(model),
        contentType: "application/json",
        success: function (data) {
            setTimeout(function () {
                    swal({
                        title: "Good job!",
                        text: "Perfil removido com sucesso!",
                        type: "success"
                    });
                },
                1000);

            location.reload();
        },
        error: function (xhr) { }
    });
}

function HtmlBuildEditar(data) {

    return [
        '<div class="panel-body" id="dynamicModal">' +
        '<div class="input-group input-fields">' +
        '<span class="input-group-addon">Nome</span>' +
        '<input disabled id="Tela" type="text" class="form-control" name="Tela" value="' + data.Tela + '">' +
        '</div>' +
        '<div class="input-group input-fields">' +
        '<span class="input-group-addon">Perfil</span>' +
        '<input disabled id="Perfil" type="text" class="form-control" name="Perfil" value="' + data.Perfil + '">' +
        '</div>' +
        '<div class="input-group input-fields">' +
        '<span class="input-group-addon">Ativo</span>' +
        '<div style="margin-left: 10px"> <input disabled type="checkbox" name="Ativo"' + (data.Ativo === true ? 'checked="checked"' : '') + '"></div>' +
        '</div>' +
        '<div class="input-group input-fields">' +
        '<span class="input-group-addon">Descrição</span>' +
        '<input disabled id="Descricao" type="text" class="form-control" name="Descricao" value="' + data.Descricao + '">' +
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
        '<input disabled id="Nome" type="text" class="form-control" name="Nome" value="' + data.Tela + '">' +
        '</div>' +
        '<div class="input-group input-fields">' +
        '<span class="input-group-addon">Perfil</span>' +
        '<input disabled id="Perfil" type="text" class="form-control" name="Perfil" value="' + data.Perfil + '">' +
        '</div>' +
        '<div class="input-group input-fields">' +
        '<span class="input-group-addon">Ativo</span>' +
        '<div style="margin-left: 10px"> <input disabled type="checkbox" name="Ativo"' + (data.Ativo === true ? 'checked="checked"' : '') + '"></div>' +
        '</div>' +
        '<div class="input-group input-fields">' +
        '<span class="input-group-addon">Perfil</span>' +
        '<input disabled id="Descricao" type="text" class="form-control" name="Descricao" value="' + data.Descricao + '">' +
        '</div>' +
        '</div>'
    ];

}


