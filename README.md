Cadastro de Clientes .NET
ste é um projeto de cadastro de clientes desenvolvido em C# utilizando o framework .NET 8.0 e o Entity Framework para interação com o banco de dados.

Requisitos do Sistema
Certifique-se de ter os seguintes requisitos instalados em sua máquina antes de prosseguir:

.NET 8.0 SDK
Microsoft SQL Server
Visual Studio ou Visual Studio Code (opcional, mas recomendado)
Configuração do Banco de Dados
Certifique-se de ter o Microsoft SQL Server instalado e em execução na sua máquina.
Abra o arquivo appsettings.json localizado na pasta CadastroClientes e ajuste a string de conexão (ConnectionString) de acordo com a configuração do seu banco de dados.

Executando o Projeto
Abra o projeto em sua IDE preferida (Visual Studio, Visual Studio Code, etc.).
Restaure as dependências do projeto executando o comando dotnet restore no terminal.
Execute as migrações do Entity Framework para criar o esquema do banco de dados executando o comando dotnet ef database update no terminal, na pasta do projeto.
Inicie o projeto executando o comando dotnet run no terminal.
Abra o navegador e acesse a URL https://localhost:5001 para acessar a aplicação.
Funcionalidades
Cadastro, edição, exclusão e listagem de clientes.
Validação de dados de entrada.