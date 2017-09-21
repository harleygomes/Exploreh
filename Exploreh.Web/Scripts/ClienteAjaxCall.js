
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
                    text: "Cliente removido com sucesso!",
                    type: "success"
                });
            }, 1000);

            location.reload();
        },
        error: function (xhr) { }
    });
}

function HtmlBuildEditar(data) {

    return $(
        '<div class="panel-body" id="dynamicModal">' +
        '<div class="input-group input-fields">' +
        '<span class="input-group-addon">Nome</span>' +
        '<input disabled id="Nome" type="text" class="form-control" name="Nome" value="' +
        data.Nome +
        '">' +
        '</div>' +
        '<div class="input-group input-fields">' +
        '<span class="input-group-addon">E-mail</span>' +
        '<input disabled id="Email" type="text" class="form-control" name="Email" value="' +
        data.Email +
        '">' +
        '</div>' +
        '<div class="input-group input-fields">' +
        '<span class="input-group-addon">Ativo</span>' +
        '<div style="margin-left: 10px"> <input disabled type="checkbox" name="Ativo"' +
        (data.Ativo === true ? 'checked="checked"' : '') +
        '"></div>' +
        '</div>' +
        '<div class="input-group input-fields">' +
        '<span class="input-group-addon">Documento</span>' +
        '<input disabled id="Documento" type="text" class="form-control" name="Documento" value="' +
        data.Documento +
        '">' +
        '</div>' +
        '<div class="input-group input-fields">' +
        '<span class="input-group-addon">' +
        (data.ClienteTelefone[0].TipoTelefone === "C" ? 'Celular ' : 'Fixo') +
        '</span>' +
        '<input disabled id="ClienteTelefone[1]_Ddd" type="text" class="form-control" name="ClienteTelefone[1].Ddd" value="' +
        data.ClienteTelefone[0].Ddd +
        '">' +
        '</div>' +
        '<div class="input-group input-fields">' +
        '<span class="input-group-addon">Telefone</span>' +
        '<input disabled id="ClienteTelefone[1]_Telefone" type="text" class="form-control" name="ClienteTelefone[1].Telefone" value="' +
        data.ClienteTelefone[0].Telefone +
        '">' +
        '</div>' +
        '<div class="input-group input-fields">' +
        '<span class="input-group-addon">Logradouro</span>' +
        '<input disabled id="ClienteEndereco[0]_Logradouro" type="text" class="form-control" name="ClienteEndereco[0].Logradouro" value="' +
        data.ClienteEndereco[0].Logradouro +
        '">' +
        '</div>' +
        '<div class="input-group input-fields">' +
        '<span class="input-group-addon">Logradouro</span>' +
        '<input disabled id="ClienteEndereco[0]_Numero" type="text" class="form-control" name="ClienteEndereco[0].Numero" value="' +
        data.ClienteEndereco[0].Numero +
        '">' +
        '</div>' +
        '<div class="input-group input-fields">' +
        '<span class="input-group-addon">Complemento</span>' +
        '<input disabled id="ClienteEndereco[0]_Complemento" type="text" class="form-control" name="ClienteEndereco[0].Complemento" value="' +
        data.ClienteEndereco[0].Complemento +
        '">' +
        '</div>' +
        '<div class="input-group input-fields">' +
        '<span class="input-group-addon">Bairro</span>' +
        '<input disabled id="ClienteEndereco[0]_Bairro" type="text" class="form-control" name="ClienteEndereco[0].Bairro" value="' +
        data.ClienteEndereco[0].Bairro +
        '">' +
        '</div>' +
        '<div class="input-group input-fields">' +
        //'<span class="input-group-addon">Nome do Contato</span>' +
        //'<input disabled id="ContatoNome" type="text" class="form-control" name="ContatoNome" value="' + data.ContatoNome + '">' +
        //'</div>' +
        //'<div class="input-group input-fields">' +
        //'<span class="input-group-addon">E-mail do Contato</span>' +
        //'<input disabled id="ContatoEmail" type="text" class="form-control" name="ContatoEmail" value="' + data.ContatoEmail + '">' +
        //'</div>' +
        //'<div class="input-group input-fields">' +
        //'<span class="input-group-addon">Cidade</span>' +
        //'<input disabled id="ClienteEndereco[0]_Cidade" type="text" class="form-control" name="ClienteEndereco[0].Cidade" value="' + data.Cidade[0].Nome + '">' +
        //'</div>' +
        //'<div class="input-group input-fields">' +
        //'<span class="input-group-addon">Estado</span>' +
        //'<input disabled id="ClienteEndereco[0]_Estado" type="text" class="form-control" name="ClienteEndereco[0].Estado" value="' + data.Estado[0].Nome + '">' +
        //'</div>' +
        '</div>');


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
        '<div style="margin-left: 10px"> <input disabled type="checkbox" name="Ativo"' + (data.Ativo === true ? 'checked="checked"' : '') + '"></div>' +
        '</div>' +

        '<div class="input-group input-fields">' +
        '<span class="input-group-addon">Documento</span>' +
        '<input disabled id="Documento" type="text" class="form-control" name="Documento" value="' + data.Documento + '">' +
        '</div>' +
        '<div class="input-group input-fields">' +
        '<span class="input-group-addon">' + (data.ClienteTelefone[0].TipoTelefone === "C" ? 'Celular ' : 'Fixo') + '</span>' +
        '<input disabled id="ClienteTelefone[1]_Ddd" type="text" class="form-control" name="ClienteTelefone[1].Ddd" value="' + data.ClienteTelefone[1].Ddd + '">' +
        '</div>' +
        '<div class="input-group input-fields">' +
        '<span class="input-group-addon">Telefone</span>' +
        '<input disabled id="ClienteTelefone[1]_Telefone" type="text" class="form-control" name="ClienteTelefone[1].Telefone" value="' + data.ClienteTelefone[1].Telefone + '">' +
        '</div>' +
        '<div class="input-group input-fields">' +
        '<span class="input-group-addon">Logradouro</span>' +
        '<input disabled id="ClienteEndereco[0]_Logradouro" type="text" class="form-control" name="ClienteEndereco[0].Logradouro" value="' + data.ClienteEndereco[0].Logradouro + '">' +
        '</div>' +
        '<div class="input-group input-fields">' +
        '<span class="input-group-addon">Logradouro</span>' +
        '<input disabled id="ClienteEndereco[0]_Numero" type="text" class="form-control" name="ClienteEndereco[0].Numero" value="' + data.ClienteEndereco[0].Numero + '">' +
        '</div>' +
        '<div class="input-group input-fields">' +
        '<span class="input-group-addon">Complemento</span>' +
        '<input disabled id="ClienteEndereco[0]_Complemento" type="text" class="form-control" name="ClienteEndereco[0].Complemento" value="' + data.ClienteEndereco[0].Complemento + '">' +
        '</div>' +
        '<div class="input-group input-fields">' +
        '<span class="input-group-addon">Bairro</span>' +
        '<input disabled id="ClienteEndereco[0]_Bairro" type="text" class="form-control" name="ClienteEndereco[0].Bairro" value="' + data.ClienteEndereco[0].Bairro + '">' +
        '</div>' +
        //'<div class="input-group input-fields">' +
        //'<span class="input-group-addon">Nome do Contato</span>' +
        //'<input disabled id="ContatoNome" type="text" class="form-control" name="ContatoNome" value="' + data.ClienteContato.Nome + '">' +
        //'</div>' +
        //'<div class="input-group input-fields">' +
        //'<span class="input-group-addon">E-mail do Contato</span>' +
        //'<input disabled id="ContatoEmail" type="text" class="form-control" name="ContatoEmail" value="' + data.ContatoEmail + '">' +
        //'</div>' +
        //'<div class="input-group input-fields">' +
        //'<span class="input-group-addon">Cidade</span>' +
        //'<input disabled id="ClienteEndereco[0]_Cidade" type="text" class="form-control" name="ClienteEndereco[0].Cidade" value="' + data.Cidade[0].Nome + '">' +
        //'</div>' +
        //'<div class="input-group input-fields">' +
        //'<span class="input-group-addon">Estado</span>' +
        //'<input disabled id="ClienteEndereco[0]_Estado" type="text" class="form-control" name="ClienteEndereco[0].Estado" value="' + data.Estado[0].Nome + '">' +
        //'</div>' +
        '</div>'
    ];

}

