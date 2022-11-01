
# C# Backend Server

Backend desenvolvido para o projeto de gestão de faculdades, 
a parte de front-end está disponivel em 
https://github.com/RubenCipriano/GestaoFaculdadeFrontend

Este projeto backend é um backend onde é possivel fazer calls à API, 
não sendo necessário qualquer tipo de autenticação, os endpoints disponiveis na API são:

- alunos
- curso
- disciplinas
- notas
- professor

sendo que todas estas possuem o mesmo tipo de comportamento
## Instalação

Após configurar o servidor SQL nas configurações do `appsettings.json`.
Instale e corra o backend utilizando os seguintes comandos:

```bash
  dotnet env database update
  dotnet run
```
    
## Documentação da API

#### Retorna todos os alunos

    GET /api/aluno

#### Apaga um aluno


    DELETE /api/aluno/${id}


| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Obrigatório**. O ID do item que você quer eliminar |


#### Edita um aluno


    PUT /api/aluno/${id}


| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Obrigatório**. O ID do item que você quer editar |
| `body`      | `Aluno` | **Obrigatório**. Objeto do tipo **Aluno** |
