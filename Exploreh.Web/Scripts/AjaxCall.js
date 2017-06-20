
/**
 * Chamada ajax para apresentar detalhes do usuário na Modal
 * @param {} value 
 * @param {} id 
 * @returns {} 
 */
function Detalhes(value,url) {

    var modal = $('.modal-body > p');

    $.ajax({
        url: url,
        type: 'POST',
        data: { id: value },
        success: function (data) {
            var $select = modal;
            $select.append(HtmlBuild(data));
        },
        error: function (xhr) { }
    });


}

function HtmlBuild(data) {

    var _dateCadastro = new Date(data.DataCadastro);
    var dataCadastro = (_dateCadastro.getMonth() + 1) + '/' + _dateCadastro.getDate() + '/' + _dateCadastro.getFullYear();

    var _dateAlteracao = new Date(data.DataAlteracao);
    var dataAlteracao = (_dateAlteracao.getMonth() + 1) + '/' + _dateAlteracao.getDate() + '/' + _dateAlteracao.getFullYear();

    return [
        
        '<div class="panel-body">'+
        '<div class="input-group input-fields">'+
        '<span class="input-group-addon">Nome</span>'+
        '<input disabled id="Nome" type="text" class="form-control" name="Nome" value="' + data.Nome + '">' +
        '</div>'+
        '<div class="input-group input-fields">'+
        '<span class="input-group-addon">E-mail</span>'+
        '<input disabled id="Email" type="text" class="form-control" name="Email" value="' + data.Email + '">' +
        '</div>'+
        '<div class="input-group input-fields">'+
        '<span class="input-group-addon">Ativo</span>'+
        '<div style="margin-left: 10px"> <input disabled type="checkbox" name="Ativo"' + data.Ativo + '"></div>' +
        '</div>' +

        '<div class="input-group input-fields">' +
        '<span class="input-group-addon">Ativo</span>' +
        '<div style="margin-left: 10px"> <input disabled type="text" class="form-control" name="DataCadastro" value="' + dataCadastro + '"></div>' +
        '</div>' +
        
        '<div class="input-group input-fields">' +
        '<span class="input-group-addon">Ativo</span>' +
        '<div style="margin-left: 10px"> <input disabled type="text" class="form-control" name="DataCadastro" value="' + dataAlteracao + '"></div>' +
        '</div>' +


        '<div class="input-group input-fields">'+
        '<span class="input-group-addon">Perfil</span>' +
        '<input disabled id="PerfilId" type="text" class="form-control" name="PerfilId" value="' + data.PerfilId + '">' +
        '</div>'+
        '</div>'+
        '<div class="input-fields">'
        ];
}