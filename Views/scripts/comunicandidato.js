$(document).ready(function() {
    grid();
});

function limpar() {
    formulario.numeroInput.value = '';
    formulario.nomeInput.value = '';
}

function grid() {
    $.get('https://localhost:5001/Candidato/Listar')
        .done(function(resposta) { 
            for(i = 0; i < resposta.length; i++) {                
                let linha = $('<tr class="text-center"></tr>');
                
                linha.append($('<td></td>').html(resposta[i].id));
                linha.append($('<td></td>').html(resposta[i].numero));
                linha.append($('<td></td>').html(resposta[i].nome));
                linha.append($('<td></td>').html(resposta[i].partido));
                
                let botaoExcluir = $('<button class="btn btn-danger"></button>').attr('type', 'button').html('Excluir').attr('onclick', 'excluir(' + resposta[i].id + ')');

                let acoes = $('<td></td>');
                acoes.append(botaoExcluir);

                linha.append(acoes);
                
                $('#grid').append(linha);
            }
        })
        .fail(function(erro, mensagem, excecao) { 
            alert("Erro ao consultar a API!");
        });
}

function excluir(id) {
    console.log(id)
    $.ajax({
        type: 'DELETE',
        url: 'https://localhost:5001/Candidato/Excluir/',
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(id),
        success: function(resposta) { 
            alert("Candidato removido com sucesso!");
            location.reload(true);
        },
        error: function(erro, mensagem, excecao) { 
            alert("Erro ao realizar a remoção!");
        }
    });
}

function cadastrar() {
    let canditado = {
        Id:formulario.idInput.value,
        Numero: formulario.numeroInput.value,
        Nome: formulario.nomeInput.value,
        Partido: formulario.partidoInput.value
    };
    console.log(canditado);
    $.ajax({
        type: 'POST',
        url: 'https://localhost:5001/Candidato/Cadastrar',
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(canditado),
        success: function() {
            alert("canditado cadastrado com sucesso!");
            limpar();
            location.reload(true);
        },
        error: function() {
            alert("Erro ao realizar o cadastro!");
        }   
    
    });
}
