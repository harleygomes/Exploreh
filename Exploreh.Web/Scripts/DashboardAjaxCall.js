
/**
 * Chamada ajax para apresentar detalhes do usuário na Modal
 * @param {} value 
 * @param {} id 
 * @returns {} 
 */

//Call cliente number
function GetClienteCount(url) {
    var display = $('#clientCount');
   
    $.ajax({
        url: url,
        type: 'POST',
        success: function (data) {
            var $select = display;
            $select.html('');
            $select.append(data);
        },
        error: function (xhr) { }
    });


}

//Call cliente number
function GetUsersExternoCount(url) {
    var display = $('#userExternoCount');

    $.ajax({
        url: url,
        type: 'POST',
        success: function (data) {
            var $select = display;
            $select.html('');
            $select.append(data);
        },
        error: function (xhr) { }
    });


}
