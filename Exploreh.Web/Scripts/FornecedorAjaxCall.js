
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

function HtmlBuildEditar(data) {

    return [
        '<div class="panel-body" id="dynamicModal">' +
        '<div class="panel-body">'+
        '<div class="input-group input-fields">'+
        '<span class="input-group-addon lblNome">Razão Social</span>'+
        ' <input disabled id="RazaoSocial" type="text" class="form-control" name="RazaoSocial" placeholder="Razão Social" value="' + data.RazaoSocial + '">' +
        '</div>' +        
        '<div class="input-group input-fields">'+
        '<span class="input-group-addon lblNome">Nome Fantasia</span>'+
        '<input disabled id="NomeFantasia" type="text" class="form-control" name="NomeFantasia" placeholder="NomeFantasia" value="' + data.NomeFantasia + '">' +
        '</div>'+        
        '<div class="input-group input-fields">'+
        '<span id="DocLabel" class="input-group-addon">Documento<span style="color: red">*</span> </span>'+
        '<input disabled type="text" class="form-control documento" name="Documento" placeholder="Número do documento" maxlength="15" value="' + data.Documento + '">' +
        '</div>'+
        '<div class="input-group input-fields">'+
        '<span class="input-group-addon">E-mail <span style="color: red">*</span></span>'+
        '<input disabled id="Email" type="text" class="form-control" name="Email" placeholder="E-mail" value="' + data.Email + '">' +
        '</div>'+
        '<div class="input-group input-fields">'+
        '<span class="input-group-addon">Home Page</span>'+
        '<input disabled id="HomePage" type="text" class="form-control" name="HomePage" placeholder="Home Page" value="' + data.HomePage + '">' +
        '</div>'+
        '<div class="input-group input-fields">'+
        '<span class="input-group-addon">Observações</span>'+
        '<input disabled id="Observacao" type="text" class="form-control" name="observacao" placeholder="Escreva aqui alguma obseervação relacionada ao fornecedor" value="' + data.Observacao + '">' +
        '</div>'+
        '<div class="input-group input-fields">'+
        '<span class="input-group-addon">Ramo de Atividade</span>'
];

}

function HtmlBuildDelete(data) {

    return [
        '<div class="panel-body" id="dynamicModal">' +
        '<div class="input-group input-fields">' +
        '<span class="input-group-addon">Razão Social</span>' +
        '<input disabled id="Nome" type="text" class="form-control" name="Nome" value="' + data.RazaoSocial + '">' +
        '</div>'
    ];

}

