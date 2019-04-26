var nomeToken = 'token';

function requisicao(tipo, url, dados, token) {
    var headers = {};

    if (token) {
        headers.Authorization = 'Bearer ' + token;
    }

    $.ajax({
        type: 'POST',
        url: url,
        headers: headers,
        //contentType: 'application/json',
        //dataType: 'json',
        data: dados,
    }).done(function (data) {
        return "Concluído";
    }).fail(function () {
        return "Não foi possível concluir a requisição.";
    });
}

function showError(jqXHR) {
    console.log('Erro: ' + jqXHR.status + ': ' + jqXHR.statusText + ' - ' + jqXHR.responseText);
}