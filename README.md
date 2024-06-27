## Projeto macena-github-integration - Documentação de Decisões e Soluções

### Problemas Encontrados

- **Problema:** Excedeu-se o limite de taxa da API do GitHub devido a solicitações não autenticadas.
  - **Solução:** Implementação de autenticação com token pessoal para aumentar o limite de taxa.

- **Problema:** Erros de concorrência ao acessar o contexto do DbContext em operações paralelas.
  - **Solução:** Uso de um novo contexto para cada operação ou garantia de que apenas uma operação acessa o contexto por vez.

### Decisões Tomadas

- **Decisão:** Utilização do Entity Framework Core para acesso aos dados.
  - **Justificativa:** Facilita a manipulação de entidades e relacionamentos no banco de dados SQL Server.

- **Decisão:** Implementação de log usando o ILogger para registrar informações, avisos e erros.
  - **Justificativa:** Facilita o monitoramento e diagnóstico de problemas durante a execução da aplicação.
 
- **Decisão:** Implementação de classe Base para as operações.
  - **Justificativa (Reutilização de Lógica):** Promove reutilização de código entre diferentes operações.
  - **Justificativa (Padronização):** Define um padrão consistente para implementação de operações que lidam com requisições e respostas, facilitando a manutenção e compreensão do código.
  - **Justificativa (Tratamento de Erros Centralizado):** Garante que erros comuns sejam tratados de maneira consistente e registrados adequadamente nos logs.
 
- **Decisão:** Implementação de classe Base para as response das operações
  - **Justificativa (Padrão para Respostas de Operação):** Estabelece um padrão consistente para as respostas das operações no sistema, garantindo que todas as respostas possuam uma estrutura básica de sucesso/erro e possam conter dados adicionais, quando necessário.

### Arquitetura e Organização do Projeto

- **Camadas:** O projeto está organizado em camadas separadas para operações de negócio (Core), acesso a dados (Repositories) e apresentação (WebApi).
- **Padrões:** Utilização de padrões como Injeção de Dependência (DI) e Mapeamento Objeto-Relacional (ORM) para manter a modularidade e a facilidade de manutenção.

## Testes Unitários

Os testes unitários no projeto são implementados utilizando o framework xUnit com o Moq.

## Endpoints da API

### Fetch and Store Repositories

**Descrição:** Executa o processamento para buscar e armazenar repositórios do GitHub de acordo com as linguagens especificadas. Caso não informe as linguagens temos 5 como default.

- **Método HTTP:** POST
- **URL:** `/api/repositories/fetch-and-store`
- **Corpo da Requisição (JSON):**
  ```json
  {
    "Languages": ["C#", "JavaScript", "Python"]
  }
- **Resposta da requisição 200 (JSON):**
  ```json
  {
    "Success": true,
    "Errors": [],
    "Languages": ["C#", "JavaScript", "Python"]
  }

- **Resposta da requisição 400 (JSON):**
  ```json
  {
    "Success": false,
    "Errors": [{
        "ErrorCode": 1001,
        "Message": "Erro ao processar a requisição."
      }
    ]
  }

### Listagem de Repositórios

**Descrição:** Retorna uma lista de repositórios do GitHub com filtros opcionais e paginação.

- **Método HTTP:** GET
- **URL:** `/api/repositories`
- Parâmetros de Consulta:
  - `language`: Filtro opcional para listar repositórios por linguagem.
  - `page`: Número da página para paginação.
  - `pageSize`: Número de itens por página.
    
- **Resposta da requisição 200 (JSON):**
  ```json
  {
    "gitHubRepositoryItem": [
      {
        "id": 2325298,
        "name": "linux",
        "fullName": "torvalds/linux",
        "owner": null,
        "htmlUrl": "https://github.com/torvalds/linux",
        "description": "Linux kernel source tree",
        "fork": false,
        "url": "https://api.github.com/repos/torvalds/linux",
        "createdAt": "2011-09-04T22:48:12",
        "updatedAt": "2024-06-25T02:21:08",
        "pushedAt": "2024-06-24T18:40:50",
        "homepage": "",
        "size": 5112327,
        "stargazersCount": 173587,
        "watchersCount": 173587,
        "language": "C",
        "forksCount": 52382,
        "openIssuesCount": 359,
        "defaultBranch": "master",
        "score": 1
      },
      {
        "id": 111583593,
        "name": "scrcpy",
        "fullName": "Genymobile/scrcpy",
        "owner": null,
        "htmlUrl": "https://github.com/Genymobile/scrcpy",
        "description": "Display and control your Android device",
        "fork": false,
        "url": "https://api.github.com/repos/Genymobile/scrcpy",
        "createdAt": "2017-11-21T18:00:27",
        "updatedAt": "2024-06-25T02:47:32",
        "pushedAt": "2024-06-24T21:19:08",
        "homepage": "",
        "size": 6429,
        "stargazersCount": 104765,
        "watchersCount": 104765,
        "language": "C",
        "forksCount": 10187,
        "openIssuesCount": 1887,
        "defaultBranch": "master",
        "score": 1
      },
    ]
  }

### Detalhes do Repositório

**Descrição:** Retorna os detalhes de um repositório específico do GitHub.

- **Método HTTP:** GET
- **URL:** `/api/repositories/{id}`
- Parâmetros da Rota:
  - `id`: ID único do repositório.
    
- **Resposta da requisição 200 (JSON):**
  ```json
  {
    "gitHubRepositoryItem": {
      "id": 2325298,
      "name": "linux",
      "fullName": "torvalds/linux",
      "owner": null,
      "htmlUrl": "https://github.com/torvalds/linux",
      "description": "Linux kernel source tree",
      "fork": false,
      "url": "https://api.github.com/repos/torvalds/linux",
      "createdAt": "2011-09-04T22:48:12",
      "updatedAt": "2024-06-25T02:21:08",
      "pushedAt": "2024-06-24T18:40:50",
      "homepage": "",
      "size": 5112327,
      "stargazersCount": 173587,
      "watchersCount": 173587,
      "language": "C",
      "forksCount": 52382,
      "openIssuesCount": 359,
      "defaultBranch": "master",
      "score": 1
    },
    "success": true,
    "errors": []
  }
