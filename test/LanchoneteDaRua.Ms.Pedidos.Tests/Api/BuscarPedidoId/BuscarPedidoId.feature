Funcionalidade: BuscarPedidoPorId
Como um usuário da API
Eu quero ser capaz de buscar um pedido pelo seu ID
Para que eu possa obter informações sobre um pedido específico

Cenário: Buscar um pedido existente pelo ID
    Dado que eu tenho um pedido existente com o ID 'ce0ef15f-fe9f-4ac9-b0e2-3f603ea85761'
    Quando eu faço uma requisição GET para '/api/v1/pedidos/ce0ef15f-fe9f-4ac9-b0e2-3f603ea85761'
    Então eu recebo uma resposta com o status 200
    E a resposta contém as informações do pedido com o ID 'ce0ef15f-fe9f-4ac9-b0e2-3f603ea85761'

Cenário: Tentar buscar um pedido inexistente pelo ID
    Dado que eu não tenho um pedido com o ID '5cc38313-0688-47a2-9292-4e03cf34896f'
    Quando eu faço uma requisição GET para '/api/v1/pedidos/5cc38313-0688-47a2-9292-4e03cf34896f'
    Então eu recebo uma resposta com o status 404