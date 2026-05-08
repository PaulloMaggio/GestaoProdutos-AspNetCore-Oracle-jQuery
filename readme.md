# Gestão de Produtos - ASP.NET Core MVC + Oracle

Sistema Full Stack desenvolvido para gerenciamento de catálogo de produtos, integrando uma arquitetura moderna no backend com uma interface dinâmica e responsiva no frontend.

![Demonstração do Sistema](index.jpg)

## 🚀 Tecnologias Utilizadas

* **Backend:** ASP.NET Core 9 (MVC)
* **Banco de Dados:** Oracle Database (XE)
* **ORM:** Entity Framework Core
* **Frontend:** HTML5, CSS3, Bootstrap 5
* **Interatividade:** JavaScript & jQuery (Ajax)
* **Segurança:** Variáveis de ambiente com `DotNetEnv`

## 🛠️ Funcionalidades

* **CRUD Completo:** Listagem, criação e exclusão de produtos.
* **Integração Oracle:** Persistência de dados em tabelas relacionais (`PRODUTOS` e `DEPARTAMENTOS`).
* **Interface Dinâmica:** Atualização da grade de produtos via Ajax (sem reload de página).
* **Data Seeding:** Inicializador de banco de dados automático para testes e demonstração.
* **Proteção de Dados:** Uso de arquivo `.env` para ocultar strings de conexão e credenciais sensíveis.

## 🏗️ Arquitetura

O projeto segue padrões de desenvolvimento robustos para garantir manutenção e escalabilidade:
* **Repository/Service Pattern:** Desacoplamento da lógica de negócio do acesso a dados.
* **DTOs (Data Transfer Objects):** Camada de transferência de dados para segurança e performance na API.
* **Dependency Injection:** Gerenciamento de instâncias de serviços e contextos de banco.

## 🔧 Configuração para Execução

1. **Requisitos:**
 
   - .NET 9 SDK
   - Oracle Database instalado e rodando.

2. **Arquivo de Ambiente:**
 
   Crie um arquivo `.env` na raiz do projeto com sua string de conexão:
   ```env
   ORACLE_CONNECTION=Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=xe)));User Id=SYSTEM;Password=SUA_SENHA;

Restaurar e Rodar:

Bash
dotnet restore
dotnet run

✒️ Autor

Paulo - Desenvolvimento Full Stack