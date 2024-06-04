![](https://d335luupugsy2.cloudfront.net/cms/files/55993/1714398976/$e5d5hnqw2sh)

- [x] Live Dia 1: https://www.youtube.com/live/Uqlvj71FDyA
- [x] Live Dia 2: https://www.youtube.com/watch?v=O0qiBF6zRNg
- [x] Repositório: https://github.com/balta-io/jornada-fullstack-2024

# Criando a estrutura básica do projeto

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

### SQL Server no Docker
- [x] https://balta.io/blog/sql-server-docker

- [x] ``docker run --name sqlserver -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=1q2w3e4r@#$" -p 1433:1433 -d mcr.microsoft.com/mssql/server
Server=localhost,1433;Database=fina;User ID=sa;Password=1q2w3e4r@#$``

### Instalar o ef-tools
``Microsoft.EntityFrameworkCore.Tools``

### Criando as migrations
``dotnet ef migrations add v1``

### Criando database com base na migrations
``dotnet ef database update``

### Adicionando o pacote do OpenApi
``dotnet add package Microsoft.AspnetCore.OpenApi``

### Adicionando o pacote do Swagger
``dotnet add package Swashbuckle.AspnetCore``