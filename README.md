# Projeto .NET 8.0 - API gerenciamento de Leads

## Requisitos
- .NET 8.0
- Entity Framework Core 9
- SQL Server instalado na máquina

## Configuração do Projeto
1. **String de Conexão**
   - No arquivo `appsettings.json`, configure a string de conexão.
   - Se o SQL Server foi instalado de forma padrão, a string de conexão não precisa ser alterada.

2. **API Key para Envio de E-mails**
   - No arquivo `appsettings.json`, utilize a chave de API para testes enviado no arquivo .txt junto com o link desse repositorio.
   - O limite de envio é **100 e-mails por dia**.

## Acesso ao Swagger
- Para testar os endpoints, acesse o Swagger:
  - [https://localhost:44341/swagger/index.html](https://localhost:44341/swagger/index.html) - IIS Express

## Endpoints

### Listar Leads
- **GET** `/api/Leads/list/{status}`
- Opções válidas para `{status}`:
  - `New`
  - `Accepted`
  - `Rejected`

### Aceitar Lead
- **PUT** `/api/Leads/accept/{id}`
- `{id}` é retornado pelo endpoint `/api/Leads/list/{status}`.
- O `price` no body deve ser o mesmo da coluna `price` do response do endpoint `/api/Leads/list/{status}`.

### Recusar Lead
- **PUT** `/api/Leads/decline/{id}`
- `{id}` é retornado pelo endpoint `/api/Leads/list/{status}`.

## Inicialização do Banco de Dados
- Após baixar o projeto, configurar o `appsettings.json` e instalar o SQL Server:
  - Ao rodar a aplicação, a tabela será criada automaticamente.
  - A tabela será populada com dados fictícios para testes.
