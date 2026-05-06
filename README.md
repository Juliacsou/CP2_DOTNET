# 📚 API RESTful - CP2 .NET

## 📌 Participantes

Julia Corrêa e Souza de Altino - RM564870


## 📌 Descrição do Projeto

Este projeto consiste no desenvolvimento de uma API RESTful utilizando
ASP.NET Core, com o objetivo de gerenciar tutores e seus respectivos
pets.

A aplicação permite realizar operações completas de CRUD (Create, Read,
Update, Delete) para as entidades Tutor e Pet, incluindo o
relacionamento entre elas.

------------------------------------------------------------------------

## 🛠️ Tecnologias Utilizadas

-   ASP.NET Core Web API
-   Entity Framework Core
-   Oracle Database
-   Swagger (Swashbuckle)
-   Data Annotations
-   LINQ

------------------------------------------------------------------------

## ▶️ Como Rodar o Projeto

1.  Abrir o projeto no Visual Studio
2.  Configurar a string de conexão com o banco Oracle no arquivo
    `appsettings.json`
3.  Executar as migrations (caso necessário)
4.  Rodar o projeto (`F5` ou botão "Play")
5.  Acessar o Swagger pelo navegador:

https://localhost:7290/swagger

------------------------------------------------------------------------

## 📦 Estrutura das Entidades

### 🧑 Tutor

-   Id
-   Nome
-   Email
-   Telefone

### 🐶 Pet

-   Id
-   Nome
-   Espécie
-   Raça
-   Idade
-   TutorId (chave estrangeira)

------------------------------------------------------------------------

## 🔗 Endpoints Disponíveis

### 📌 Tutor

  Método   Endpoint               Descrição
  -------- ---------------------- ------------------------
  GET      /api/Tutor             Lista todos os tutores
  GET      /api/Tutor/{id}        Busca tutor por ID
  POST     /api/Tutor             Cria um novo tutor
  PUT      /api/Tutor/{id}        Atualiza um tutor
  DELETE   /api/Tutor/{id}        Remove um tutor
  GET      /api/Tutor/{id}/pets   Lista pets de um tutor

------------------------------------------------------------------------

### 📌 Pet

  Método   Endpoint        Descrição
  -------- --------------- ---------------------
  GET      /api/Pet        Lista todos os pets
  GET      /api/Pet/{id}   Busca pet por ID
  POST     /api/Pet        Cria um novo pet
  PUT      /api/Pet/{id}   Atualiza um pet
  DELETE   /api/Pet/{id}   Remove um pet

------------------------------------------------------------------------

## 📥 Exemplos de Requisição (JSON)

### 🔹 Criar Tutor

``` json
{
  "nome": "Julia",
  "telefone": "11999999999",
  "email": "julia@email.com"
}
```

------------------------------------------------------------------------

### 🔹 Criar Pet

``` json
{
  "nome": "Rex",
  "especie": "Cachorro",
  "raca": "Vira-lata",
  "idade": 5,
  "tutorId": 1
}
```

------------------------------------------------------------------------

## ✅ Status Codes Utilizados

  Código           Descrição
  ---------------- --------------------------------
  200 OK           Operação realizada com sucesso
  204 NoContent    Operação realizada sem retorno
  400 BadRequest   Dados inválidos
  404 NotFound     Recurso não encontrado

------------------------------------------------------------------------

## 📌 Observações

-   Um pet obrigatoriamente deve estar vinculado a um tutor.
-   Foi utilizado relacionamento entre as entidades via chave
    estrangeira.
-   A API possui documentação interativa via Swagger.
