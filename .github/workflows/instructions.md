
**Módulo:** Catalog  
**Prioridade:** P1  
**Tipo:** Feature  
**Dependências:** Ajustar entidade `Categoria`

## Objetivo

Implementar a vertical de jogos no módulo `Catalog`, seguindo o padrão arquitetural definido para o monolito modular.

O objetivo é permitir criação, consulta e atualização de jogos, respeitando as regras de domínio mapeadas para o catálogo.

## Rotas esperadas

```http
POST /api/v1/jogos
GET  /api/v1/jogos/{id}
GET  /api/v1/jogos
PUT  /api/v1/jogos/{id}
```

> Observação: o `GET /api/v1/jogos` representa a listagem do catálogo. Caso o grupo decida que o escopo inicial será apenas consulta por ID, essa rota pode ser ajustada antes do desenvolvimento.

## Contexto técnico

Atualmente o módulo `Catalog` já possui entidades e mappings relacionados a jogos e categorias, mas ainda não possui controller, contratos HTTP, casos de uso, manipuladores ou repositório próprio para jogos.

Este card deve implementar a feature de ponta a ponta, mantendo o padrão:

```text
Controller
→ Contract/DTO
→ Comando ou Consulta
→ Manipulador
→ Interface de repositório
→ Repositório EF
→ DbContext
→ Entidade/Mapping
→ Testes
```

## Arquivos existentes relacionados

```text
src/FIAP.CloudGames.Domain/Catalog/Entities/Jogo.cs
src/FIAP.CloudGames.Domain/Catalog/Entities/Categoria.cs
src/FIAP.CloudGames.Domain/Catalog/Entities/CategoriaJogo.cs

src/FIAP.CloudGames.Infrastructure/Data/EF/Mappings/Catalog/MapeamentoJogo.cs
src/FIAP.CloudGames.Infrastructure/Data/EF/Mappings/Catalog/CategoriaMapping.cs
src/FIAP.CloudGames.Infrastructure/Data/EF/Mappings/Catalog/MapeamentoCategoriaJogo.cs

src/FIAP.CloudGames.Infrastructure/Data/EF/Context/PostgresqlDbContext.cs
src/FIAP.CloudGames.Application/IoC/ApplicationDependency.cs
src/FIAP.CloudGames.Infrastructure/IoC/InfrastructureDependency.cs
```

## Arquivos a criar

### API

```text
src/FIAP.CloudGames.Api/Controllers/Catalog/JogosController.cs

src/FIAP.CloudGames.Api/Contracts/Catalog/Jogos/RequisicaoCriarJogo.cs
src/FIAP.CloudGames.Api/Contracts/Catalog/Jogos/RequisicaoAtualizarJogo.cs
src/FIAP.CloudGames.Api/Contracts/Catalog/Jogos/RespostaJogo.cs
src/FIAP.CloudGames.Api/Contracts/Catalog/Jogos/RespostaListaJogos.cs
```

### Application

```text
src/FIAP.CloudGames.Application/Catalog/Jogos/ComandoCriarJogo.cs
src/FIAP.CloudGames.Application/Catalog/Jogos/ManipuladorCriarJogo.cs
src/FIAP.CloudGames.Application/Catalog/Jogos/ResultadoCriarJogo.cs

src/FIAP.CloudGames.Application/Catalog/Jogos/ConsultaObterJogoPorId.cs
src/FIAP.CloudGames.Application/Catalog/Jogos/ManipuladorObterJogoPorId.cs
src/FIAP.CloudGames.Application/Catalog/Jogos/ResultadoObterJogo.cs

src/FIAP.CloudGames.Application/Catalog/Jogos/ConsultaListarJogos.cs
src/FIAP.CloudGames.Application/Catalog/Jogos/ManipuladorListarJogos.cs
src/FIAP.CloudGames.Application/Catalog/Jogos/ResultadoListarJogos.cs

src/FIAP.CloudGames.Application/Catalog/Jogos/ComandoAtualizarJogo.cs
src/FIAP.CloudGames.Application/Catalog/Jogos/ManipuladorAtualizarJogo.cs
src/FIAP.CloudGames.Application/Catalog/Jogos/ResultadoAtualizarJogo.cs

src/FIAP.CloudGames.Application/Abstractions/Repositories/IRepositorioJogos.cs
```

### Infrastructure

```text
src/FIAP.CloudGames.Infrastructure/Repositories/Catalog/RepositorioJogos.cs
```

### Testes

```text
tests/FIAP.CloudGames.UnitTests/Catalog/Jogos/TestesManipuladorCriarJogo.cs
tests/FIAP.CloudGames.UnitTests/Catalog/Jogos/TestesManipuladorObterJogo.cs
tests/FIAP.CloudGames.UnitTests/Catalog/Jogos/TestesManipuladorListarJogos.cs
tests/FIAP.CloudGames.UnitTests/Catalog/Jogos/TestesManipuladorAtualizarJogo.cs
```

## Arquivos a alterar

```text
src/FIAP.CloudGames.Domain/Catalog/Entities/Jogo.cs
src/FIAP.CloudGames.Infrastructure/Data/EF/Context/PostgresqlDbContext.cs
src/FIAP.CloudGames.Application/IoC/ApplicationDependency.cs
src/FIAP.CloudGames.Infrastructure/IoC/InfrastructureDependency.cs
```

Os mappings devem ser alterados apenas se houver necessidade real de nova constraint ou ajuste identificado durante o desenvolvimento.

## Fluxo arquitetural esperado

```text
JogosController
→ Contract de entrada
→ Comando/Consulta
→ Manipulador
→ IRepositorioJogos
→ RepositorioJogos
→ PostgresqlDbContext
→ Jogo / Categoria / CategoriaJogo
```

## Contracts/DTOs esperados

### `RequisicaoCriarJogo`

Campos esperados:

```text
Titulo
Descricao
FaixaEtaria
Preco
CategoriaIds
```

> `CategoriaIds` deve ser usado apenas se o relacionamento jogo–categoria fizer parte do escopo aprovado após o ajuste da entidade `Categoria`.

### `RequisicaoAtualizarJogo`

Campos esperados:

```text
Titulo
Descricao
FaixaEtaria
Preco
CategoriaIds
```

### `RespostaJogo`

Campos esperados:

```text
Id
Titulo
Descricao
FaixaEtaria
Preco
Ativo
DataCadastro
Categorias
```

### `RespostaListaJogos`

Campos sugeridos:

```text
Itens
Pagina
TamanhoPagina
Total
```

Caso o grupo queira simplificar o MVP, a listagem pode retornar apenas uma coleção de `RespostaJogo`.

## Comandos e consultas esperados

```csharp
ComandoCriarJogo
ConsultaObterJogoPorId
ConsultaListarJogos
ComandoAtualizarJogo
```

## Manipuladores esperados

```csharp
ManipuladorCriarJogo.ProcessarAsync(...)
ManipuladorObterJogoPorId.ProcessarAsync(...)
ManipuladorListarJogos.ProcessarAsync(...)
ManipuladorAtualizarJogo.ProcessarAsync(...)
```

Todo manipulador novo deve ser registrado em:

```text
src/FIAP.CloudGames.Application/IoC/ApplicationDependency.cs
```

## Interface de repositório esperada

Criar:

```csharp
IRepositorioJogos
```

Local esperado:

```text
src/FIAP.CloudGames.Application/Abstractions/Repositories/IRepositorioJogos.cs
```

## Métodos esperados em `IRepositorioJogos`

```csharp
Task<Jogo?> ObterPorIdAsync(
    Guid id,
    CancellationToken cancellationToken);

Task<IReadOnlyList<Jogo>> ListarAsync(
    int pagina,
    int tamanhoPagina,
    CancellationToken cancellationToken);

Task AdicionarAsync(
    Jogo jogo,
    CancellationToken cancellationToken);

Task AtualizarAsync(
    Jogo jogo,
    CancellationToken cancellationToken);
```

Caso categorias façam parte do mesmo fluxo:

```csharp
Task<bool> CategoriasExistemAsync(
    IReadOnlyCollection<Guid> categoriaIds,
    CancellationToken cancellationToken);
```

## Repositório EF esperado

Criar:

```csharp
RepositorioJogos
```

Local esperado:

```text
src/FIAP.CloudGames.Infrastructure/Repositories/Catalog/RepositorioJogos.cs
```

Registrar em:

```text
src/FIAP.CloudGames.Infrastructure/IoC/InfrastructureDependency.cs
```

Responsabilidades do repositório:

- Consultar jogos no `PostgresqlDbContext`.
- Persistir criação e atualização.
- Utilizar `CancellationToken`.
- Não retornar contracts/DTOs da API.
- Não conter regra de negócio.
- Usar `AsNoTracking` em consultas quando fizer sentido.

## Métodos de domínio esperados

Na entidade `Jogo`, criar ou ajustar método de atualização controlada:

```csharp
void AtualizarDados(
    string titulo,
    string? descricao,
    string? faixaEtaria,
    decimal preco)
```

Ou, se o grupo preferir métodos menores:

```csharp
void AlterarTitulo(string titulo)
void AlterarDescricao(string? descricao)
void AlterarFaixaEtaria(string? faixaEtaria)
void AlterarPreco(decimal preco)
```

Deve ser escolhida uma única abordagem consistente.

## Regras de domínio

- `Id` obrigatório.
- `Titulo` obrigatório.
- `Titulo` deve ser normalizado com `Trim`.
- `Titulo` deve respeitar limite de 150 caracteres.
- `Descricao` é opcional.
- `Descricao` deve respeitar limite definido no mapping.
- `FaixaEtaria` é opcional.
- `Preco` não pode ser negativo.
- Jogo novo deve iniciar ativo.
- `DataCadastro` deve ser preenchida na criação.
- Categorias informadas devem existir, caso façam parte do contrato.
- Associação jogo–categoria não pode se repetir.

## Validações

### POST

- Request não nulo.
- Título obrigatório.
- Preço maior ou igual a zero.
- Categoria existente, se informada.
- IDs de categoria não podem ser vazios.
- IDs de categoria não podem se repetir.

### GET por ID

- `id != Guid.Empty`.
- Jogo existente.

### GET coleção

- Página deve ser maior que zero.
- Tamanho da página deve ser maior que zero.
- Definir limite máximo de tamanho de página.

### PUT

- `id != Guid.Empty`.
- Jogo existente.
- Mesmas validações dos campos alteráveis.
- Categorias informadas devem existir, se aplicável.

## Retornos HTTP esperados

### POST `/api/v1/jogos`

- `201 Created`: jogo criado.
- `400 Bad Request`: dados inválidos.
- `409 Conflict`: apenas se houver regra de conflito definida.

### GET `/api/v1/jogos/{id}`

- `200 OK`: jogo encontrado.
- `400 Bad Request`: identificador inválido.
- `404 Not Found`: jogo inexistente.

### GET `/api/v1/jogos`

- `200 OK`: lista retornada, inclusive quando vazia.
- `400 Bad Request`: paginação inválida.

### PUT `/api/v1/jogos/{id}`

- `200 OK`: jogo atualizado.
- `400 Bad Request`: dados inválidos.
- `404 Not Found`: jogo inexistente.

## Padronização de erros

Utilizar padrão HTTP com:

```text
ProblemDetails
ValidationProblemDetails
```

O controller deve traduzir o resultado da Application para HTTP, sem concentrar regra de negócio.

## Testes obrigatórios

### Criar jogo

- Deve criar jogo válido.
- Deve rejeitar título vazio.
- Deve rejeitar preço negativo.
- Deve rejeitar categoria inexistente, se categoria fizer parte do request.
- Deve rejeitar categorias repetidas, se categoria fizer parte do request.

### Obter jogo

- Deve retornar jogo existente.
- Deve retornar não encontrado para jogo inexistente.
- Não deve retornar entidade de domínio diretamente.

### Listar jogos

- Deve retornar lista de jogos.
- Deve retornar lista vazia sem erro.
- Deve validar paginação inválida.

### Atualizar jogo

- Deve atualizar dados válidos.
- Deve rejeitar jogo inexistente.
- Deve rejeitar preço negativo.
- Deve rejeitar título vazio.
- Não deve persistir alteração quando a validação falhar.

## Fora do escopo

- Implementar aquisição/biblioteca.
- Implementar checkout/pagamento.
- Implementar login/JWT.
- Implementar autorização HTTP por policy.
- Criar lógica de recomendação de jogos.
- Criar endpoint próprio de categoria, salvo decisão explícita do grupo.
- Criar MediatR.
- Retornar entidade de domínio diretamente pela API.

## Riscos técnicos

- Incluir associação de categorias pode aumentar o escopo do card.
- O modelo atual pode exigir tratamento explícito de `CategoriaJogo`.
- Pode não existir `DbSet<Jogo>` ou `DbSet<Categoria>` no contexto.
- Não há regra de unicidade de título definida.
- Deve-se evitar que o controller concentre validações de negócio.
- Deve-se evitar que o repositório retorne DTOs da API.

## Dependências

- Depende do card **Ajustar entidade Categoria** caso `CategoriaIds` faça parte do contrato.
- Fornece consulta de jogo necessária para o card **Endpoint Autorização POST**.
- Pode ser iniciado em paralelo com usuários, desde que as dependências do módulo `Catalog` estejam claras.

## Critérios de aceite

- [ ] `POST /api/v1/jogos` implementado.
- [ ] `GET /api/v1/jogos/{id}` implementado.
- [ ] `GET /api/v1/jogos` teve escopo confirmado e implementado ou removido explicitamente do card.
- [ ] `PUT /api/v1/jogos/{id}` implementado.
- [ ] Cada fluxo possui comando/consulta e manipulador explícito.
- [ ] `IRepositorioJogos` criado na camada Application.
- [ ] `RepositorioJogos` criado na camada Infrastructure.
- [ ] Novos manipuladores registrados em `ApplicationDependency`.
- [ ] Novo repositório registrado em `InfrastructureDependency`.
- [ ] Controller não contém regra de negócio.
- [ ] Repositório não conhece contracts HTTP.
- [ ] Entidade `Jogo` protege suas invariantes.
- [ ] Retornos HTTP seguem a especificação.
- [ ] Erros seguem `ProblemDetails`/`ValidationProblemDetails`.
- [ ] Testes unitários cobrem sucesso, validação e não encontrado.
- [ ] Build concluído sem erros ou avisos.