# Axis Challenge Backend Developer

## 📚 Introdução

Entrega do desafio `Axis Challenge Backend Developer` onde pude demonstrar minhas habilidades como `Backend Developer` com conhecimentos intermediários em `DevOps`.

## 🚀 Tecnologias utilizadas

* Tecnologias empregadas no projeto:
  <p align="center">
<a href="https://skillicons.dev">
    <img src="https://skillicons.dev/icons?i=git,github,docker,dotnet,githubactions" /> 
  </a>
</p>

## 🎯 Regras do Negócio

A aplicação permite o cadastro de:

- Cooperativas;
- Cooperados;
- Contatos Favoritos;

## ⚙️ Funcionalidades

A API foi criada utilizado alguns critérios no desenvolvimento. Segue abaixo algumas das funcionalidades:

- O backend seja desenvolvido em **C# e .NET 9**;
- Método para geração e validação de token utilizando JWT;
- Utilizado a ferramenta Entity Framework com migrations para o mapeamento dos objetos relacionais e criação do banco de dados.
- Limitação de requisições na api, para evitar sobrecarga no sistema;
- Possibilidade de transações durante os cadastro dos dados das tabelas;
- Implementação de paginação e ordenação nas consultas;
- Retorno padronizado de erros e mensagens para o cliente.
- Possibilidade de utilizar o docker compose para rodar a aplicação em um ambiente containerizado.
- Utilizados classes input e view models para não exibição de dados sensíveis, e ótimização ao enviar os dados customizados.
- Validação do tipo da Chave pix(Cpf, Cnpj etc...), com enumerator.
- Aplicação criado com base no clean architecture.
- Utilização do padrão Repository para separar a lógica de acesso aos dados da lógica de negócios.
- Aplicado boas práticas de Clean Code.
- Utilização do mapper para automatizar o processo de cópia dos objetos.
- Adotado a criação de uma pipeline CI/CD utilizando github action, onde é acionada nos commits.
- Criado um middleware globais para exceções e tratamento no Asp.NET Core.
- Utilizado o padrão Result Pattner para lidar com as operações de requisições que foram com sucesso.
- Endpoints com boas práticas de RESTful APis e devidamente organizadas e com summary.

## 📌 Instruções

### Rodando o projeto localmente:

- A aplicação foi desenvolvida em **C# e .NET 9**; Baixe o SDK e Runtime no site https://dotnet.microsoft.com/pt-br/download/dotnet/9.0.
- Baixe o Visual Studio 2022 no site https://visualstudio.microsoft.com/.
- O Banco de dados utilizado foi o SQL Server 2022, Baixe no site https://www.microsoft.com/pt-br/sql-server/sql-server-downloads;

#### 1. Clonar o Repositório.

<pre class="notranslate"><code>https://github.com/ricardo-axis/desafio-backend-diogo.git
</code></pre>

#### 2. Configurar o Banco de dados

<ul dir="auto">
<li>Certifique-se de ter o SQL Server instalado em sua máquina.</li>
<li>Abra o arquivo arquivo appsettings.json, e digite a string de conexão do banco de dados.</li>
</ul>

infraestrutura de dados (por exemplo, Infra.Data) esteja definido como o projeto padrão no Console do Gerenciador de Pacotes.
Execute o comando Update-Database para aplicar as migrações e criar as tabelas no banco de dados.
Update-Database
5. Configurar a String de Conexão:
Abra o arquivo appsettings.json e substitua a string de conexão do banco de dados pelas credenciais do seu PostgreSQL, se necessário.
6. Executar o Projeto:
Pressione F5 ou clique em "Iniciar" no Visual Studio para executar o projeto.
Endpoints da API

- Abra o Visual Studio ou VS Code, e clone o projeto: https://github.com/ricardo-axis/desafio-backend-diogo.git.
- Abra o arquivo appsettings.json e configure a propriedade **ConnectionString** do banco de dados.
- Execute o projeto, ou no terminal, rode o projeto utilizando o comando dotnet run.
- Abra o navegador e acesse https://localhost:44339/swagger/index.html.

## ✔️ Documentação, Organização e Entrega

- O projeto deve ser entregue via **repositório Git** (GitHub, GitLab ou Bitbucket);
- Criar um arquivo `README.md` contendo:
  - Tecnologias utilizadas;
  - Instruções para rodar o projeto localmente;
  - Instruções para rodar o projeto com Docker (se aplicável);
  - Como executar os testes (se houver);
  - Configuração de ambiente para desenvolvimento e produção;
- Adicionar um `.gitignore` adequado para o projeto;
- O **prazo limite para entrega é 04/04/2025 às 23h59**.

## ❓ Dúvidas?

Se tiver qualquer dúvida, entre em contato abrindo uma [Issue](https://github.com/ricardo-axis/desafio-backend-diogo/issues) no repositório do desafio.

Boa sorte! 🚀
