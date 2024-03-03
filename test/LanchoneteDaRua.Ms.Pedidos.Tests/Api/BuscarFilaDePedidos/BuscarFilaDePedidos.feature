Funcionalidade: BuscarPedidosNaFila
Como um usuário da API
Eu quero ser capaz de buscar pedidos na fila
Para que eu possa gerenciar os pedidos pendentes

Cenário: Buscar pedidos na fila
    Quando eu faço uma requisição de lista GET para '/api/v1/pedidos/status/Recebido'
    Então eu recebo uma resposta de lista com status 200
    E a resposta contém a lista de pedidos na fila

Cenário: Buscar pedidos na fila quando não há pedidos pendentes
    Quando eu faço uma requisição de lista GET para '/api/v1/pedidos/status/Finalizado'
    Então eu recebo uma resposta de lista com status 200
    E a resposta indica que não há pedidos pendentes