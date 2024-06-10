![](https://d335luupugsy2.cloudfront.net/cms/files/55993/1714398976/$e5d5hnqw2sh)

- [x] Live Dia 1: https://www.youtube.com/live/Uqlvj71FDyA
- [x] Live Dia 2: https://www.youtube.com/watch?v=O0qiBF6zRNg
- [x] Live Dia 3: https://www.youtube.com/watch?v=tSLxOA04jG4
- [x] Repositório: https://github.com/balta-io/jornada-fullstack-2024

# Introdução

Esse projeto visa realizar operações simmples usando Blazor com .NET 8, com base nos 3 dias de lives de André Baltieri, ou balta, 10x Microsoft MVP.

# Sem tempo irmão!

Se você quer ir direto ao ponto, recomendo que você siga esses passos para que a aplicação fique disponível e possa ver como isso realmente funciona.

### SQL Server no Docker e limitando a 1GB
- [x] https://balta.io/blog/sql-server-docker

- [x] ``docker run --name sqlserver_balta -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=1q2w3e4r@#$" -e "MSSQL_MEMORY_LIMIT_MB=1024" -p 1433:1433 -m 1024M -d mcr.microsoft.com/mssql/server``

### Instalar o ef-tools no Fina.Api
``Microsoft.EntityFrameworkCore.Tools``

### Criando as migrations no Fina.Api
``dotnet ef migrations add v1``

### Criando database com base na migrations no Fina.Api
``dotnet ef database update``

### Só executar
Executar os dois projetos Fina.Web e Fina.ApPi

# Estou com tempo irmão!

Já que você é uma pessoa que tem tempo e gosta de ver as coisas serem feitas desde o começo, recomendo que siga os passos abaixo:

### Criar repositório
``cd jornada-fullstack-balta``

### Criar solution
``jornada-fullstack-balta>dotnet new sln``

### Criando projeto Api
``jornada-fullstack-balta>dotnet new web -o Fina.Api``

### Criando projeto Blazor
``jornada-fullstack-balta>dotnet new blazorwasm -o Fina.Web --pwa``

### Criando projeto compartilhado que será responsável pela comunicação entre Api e Web
``jornada-fullstack-balta>dotnet new classlib -o Fina.Shared``

### Adicionando projeto Api a solution
``jornada-fullstack-balta>dotnet sln add ./Fina.Api``

### Adicionando projeto Web a solution
``jornada-fullstack-balta>dotnet sln add ./Fina.Web``

### Adicionando projeto Shared a solution
``jornada-fullstack-balta>dotnet sln add ./Fina.Shared``

### Adicionando referência do projeto Shared ao projeto Api
``jornada-fullstack-balta\Fina.Api>dotnet add reference ../Fina.Shared``

### Adicionando referência do projeto Shared ao projeto Web
``jornada-fullstack-balta\Fina.Web>dotnet add reference ../Fina.Shared``

### Adicionando os fontes a um repositório no git
``jornada-fullstack-balta>git init``

### Adicionando o gitignore
``jornada-fullstack-balta>dotnet new gitignore``

### Adicionando os arquivos
``jornada-fullstack-balta>git add -all``

### Commitando os arquivos
``jornada-fullstack-balta>git commit -a -m "Finalziado dia 1``

### SQL Server no Docker e limitando a 1GB
- [x] https://balta.io/blog/sql-server-docker

- [x] ``docker run --name sqlserver_balta -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=1q2w3e4r@#$" -e "MSSQL_MEMORY_LIMIT_MB=1024" -p 1433:1433 -m 1024M -d mcr.microsoft.com/mssql/server``

### Instalar o ef-tools no Fina.Api
``Microsoft.EntityFrameworkCore.Tools``

### Criando as migrations no Fina.Api
``dotnet ef migrations add v1``

### Criando database com base na migrations no Fina.Api
``dotnet ef database update``

### Adicionando o pacote do OpenApi no Fina.Api
``dotnet add package Microsoft.AspnetCore.OpenApi``

### Adicionando o pacote do Swagger no Fina.Api 
``dotnet add package Swashbuckle.AspnetCore``

### Adicionando o pacote MudBlazor no Fina.Web
``dotnet add package MudBlazor``

### Adicionando o pacote Http no Fina.Web
``dotnet add package Microsoft.Extensions.Http``
