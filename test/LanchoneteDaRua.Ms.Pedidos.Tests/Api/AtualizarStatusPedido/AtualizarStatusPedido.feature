Funcionalidade: AtualizarStatusPedido
Como um usuário da API
Eu quero ser capaz de atualizar o status de um pedido
Para que eu possa gerenciar o ciclo de vida do pedido

Cenário: Atualizar o status de um pedido existente
    Dado que eu tenho um pedido criado
    Quando eu faço uma requisição PATCH para '/api/v1/pedidos/{id}'
    Então eu recebo uma resposta com status 202

Cenário: Tentar atualizar o status de um pedido inexistente
    Dado que eu não tenho um pedido com o ID '5cc38313-0688-47a2-9292-4e03cf34896f'
    Quando eu faço uma requisição PATCH para '/api/v1/pedidos/5cc38313-0688-47a2-9292-4e03cf34896f'
    Então eu recebo uma resposta com status 500