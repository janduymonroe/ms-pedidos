Funcionalidade: CriarPedido
Como um usuário
Eu quero ser capaz de criar um pedido
Para que eu possa adicionar itens ao meu pedido

Cenário: Criar um novo pedido com sucesso
    Dado que eu tenho um pedido válido para criar
    Quando eu envio uma solicitação POST para "/api/v1/Pedidos"
    Então eu recebo uma resposta com o código de status 202
    E o pedido é criado com sucesso

Cenário: Tentativa de criar um pedido com dados inválidos
    Dado que eu tenho um pedido inválido para criar
    Quando eu envio uma solicitação POST para "/api/v1/Pedidos"
    Então eu recebo uma resposta com o código de status 400
    E o pedido input não é válido