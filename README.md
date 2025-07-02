# cadastro-cliente (.NET 9 + SQLite)

## 📌 Descrição

Este projeto é uma aplicação console em C# (.NET 9) para cadastro de clientes usando Entity Framework, com persistência em banco de dados local SQLite. O projeto inclui validações básicas de dados e conta com um CRUD completo.

## ✅ Pré-requisitos

- [.NET 6 SDK ou superior](https://dotnet.microsoft.com/en-us/download)
- [Git](https://git-scm.com/downloads)
- Sistema: Windows, Linux ou macOS

## 🚀 Instalação (modo automático no Windows)

Para facilitar a instalação de dependências, criei um arquivo chamado setup.bat que restaura pacotes, cria o banco e executa o app. Abaixo estão os comandos necessários para a execução do arquivo

```bash
git clone https://github.com/PedroH2o/cadastro-cliente.git
cd cadastro-cliente
setup.bat
```

## 💻 Execução manual (qualquer sistema)

Caso queira fazer a instalação manual, abaixo estão os comandos necessários, lembrando que ainda será preciso instalar o .Net SDK e o Entity Framework.

```bash
dotnet restore
dotnet tool install --global dotnet-ef
dotnet ef database update
dotnet run
```

## 📁 Estrutura do Projeto

- `Models/` → Classes de modelo (ex: Cliente.cs)
- `DTOs` → Classes para Objetos de Transferência de Dados
- `Helpers` → Classes com funcionálidades auxiliares
- `Map` → Transferidor de dados entre DTO e Model
- `Repositories` → Funcionalidades do CRUD
- `Validators` → Classes validadoras de dados
- `Context/` → Configuração do banco de dados (EF Core + SQLite)
- `Migrations/` → Histórico do schema do banco
- `Program.cs` → Ponto de entrada da aplicação
- `clientes.db` → Banco SQLite gerado localmente

## ⬆️ Melhorias

Essa é a versão inicial do projeto, com o tempo planejo melhorar e deixar a aplicação mais robusta usando alguns conceitos como Domain Driven Design e SOLID.


## ⚠️ Observações

- O projeto usa SQLite. Nenhum servidor de banco de dados precisa ser instalado.
- O arquivo `clientes.db` é criado automaticamente.
- `clientes.db` está no `.gitignore` e não é enviado para o GitHub.
- Pode ser executado via terminal ou Visual Studio (F5).
