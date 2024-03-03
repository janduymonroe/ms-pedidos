Funcionalidade: AtualizarPedido
Como um usuário da API
Eu quero ser capaz de atualizar um pedido
Para que eu possa gerenciar os pedidos

Cenário: Atualizar um pedido existente
    Dado que eu tenho um pedido já criado com ID
    Quando eu faço uma requisição PUT para '/api/v1/pedidos/{id}'
    Então eu recebo uma resposta de atualização com status 202
    E a resposta confirma que o pedido foi atualizado

Cenário: Tentar atualizar um pedido inexistente
    Quando eu faço uma requisição PUT para '/api/v1/pedidos/5cc38313-0688-47a2-9292-4e03cf34896f'
    Então eu recebo uma resposta de atualização com status 400