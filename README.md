# jornada-fullstack-balta
Jornada FullStack Balta
https://www.youtube.com/live/Uqlvj71FDyA
https://github.com/balta-io/jornada-fullstack-2024

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