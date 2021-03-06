﻿//CEP: 91010000
//Formato de retorno: javascript
//URL: http://cep.republicavirtual.com.br/web_cep.php?cep=91010000&formato=json

/*{  
    "resultado":"1",
    "resultado_txt":"sucesso - cep completo",
    "uf":"RS",
    "cidade":"Porto Alegre",
    "bairro":"Passo D'Areia",
    "tipo_logradouro":"Avenida",
    "logradouro":"Assis Brasil"
}*/

function BuscaCep(cep) {

    //var url = 'http://cep.republicavirtual.com.br/web_cep.php?cep=' + cep.replace('-', '').trim() + '&formato=json';
    //alert(cep);
    var result = "";
    $.ajax({
        url: 'GetCep/',
        type: 'POST',
        data: { cep: cep.replace('-', '').trim() },
        async: false,
        success: function (data) {            
            if (data == null || data == 0) return false;
            
            result = data;
        },
        error: function (xhr) { alert('Erro!') }
    });
    
    return result;
}


function BuscaCepEdit(url,cep) {

    //var url = 'http://cep.republicavirtual.com.br/web_cep.php?cep=' + cep.replace('-', '').trim() + '&formato=json';
    //alert(url);
    var result = "";
    $.ajax({
        url: url,//'GetCep/',
        type: 'POST',
        data: { cep: cep.replace('-', '').trim() },
        async: false,
        success: function (data) {
            if (data == null || data == 0) return false;

            result = data;
        },
        error: function (xhr) { alert('Erro!') }
    });

    return result;
}

function BuscaCidade(url, cidade) {

    var result = "";
    $.ajax({
        url: url,
        type: 'POST',
        data: { cidade: cidade },
        async: false,
        success: function (data) {
            if (data == null) return false;
            result = data;
        },
        error: function (xhr) { alert('Erro!') }
    });
    
    return result;
}


function BuscaEstado(url, uf) {
    
    var result = "";
    $.ajax({
        url: url,
        type: 'POST',
        data: { uf: uf },
        async: false,
        success: function (data) {
            if (data == null) return false;

            result = data;
        },
        error: function (xhr) { alert('Erro!') }
    });
    
    return result;
}