# Axis Challenge Backend Developer

## 📚 Introdução

Entrega do desafio `Axis Challenge Backend Developer` onde pude demonstrar um pouco das minhas habilidades como `Backend Developer` com conhecimentos intermediários em `DevOps`.

## 🚀 Tecnologias utilizadas no projeto:
<p align="left"><a href="https://skillicons.dev"> <img src="https://skillicons.dev/icons?i=git,github,docker,dotnet,githubactions" /> 
  </a>
</p>

## 🎯 Regras do Negócio

A aplicação permite o CRUD de:

- Cooperativas;
- Cooperados;
- Contatos Favoritos;

## ⚙️ Funcionalidades

A API foi criada utilizando alguns critérios no desenvolvimento. Segue abaixo algumas das funcionalidades:

- O backend foi desenvolvido em **C# e .NET 9**;
- Método para geração e validação de token utilizando JWT;
- Utilizado a ferramenta Entity Framework com migrations para o mapeamento dos objetos relacionais e criação do banco de dados.
- Limitação de requisições na api, para evitar sobrecarga no sistema;
- Possibilidade de transações durante os cadastro dos dados das tabelas;
- Implementação de paginação e ordenação nas consultas;
- Retorno padronizado de erros e mensagens para o cliente.
- Possibilidade de utilizar o docker compose para rodar a aplicação em um ambiente containerizado.
- Utilizado classes input e view models para não exibição de dados sensíveis, e otimização ao enviar os dados customizados.
- Validação do tipo da Chave pix(Cpf, Cnpj etc...), com enumerator.
- A aplicação foi desenvolvida baseada no padrão clean architecture.
- Utilização do padrão Repository para separar a lógica de acesso aos dados da lógica de negócios.
- Aplicado boas práticas de Clean Code.
- Utilização do mapper para automatizar o processo de cópia dos objetos.
- Adotado a criação de pipeline CI/CD utilizando github action, onde é acionada nos commits.
- Criado um middleware global para exceções e tratamento nos endpoints.
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

#### 2. Abrir o Projeto no Visual Studio 2022:

<ul dir="auto">
<li>Navegue até o diretório onde o projeto foi clonado e abra o arquivo de solução DesafioAxis.sln</li>
</ul>

#### 3. Configurar o Banco de dados

<ul dir="auto">
<li>Certifique-se de ter o SQL Server instalado em sua máquina.</li>
<li>Abra o arquivo appsettings.json, e digite a string de conexão para acesso ao banco de dados.</li>
</ul>

#### 4. Migrações do Entity Framework Core:

<ul dir="auto">
<li>Não é necessário rodar nenhum comando adicional como `update-database` para a criação do banco de dados com sua tabela. A Aplicação já foi preparada para isso, quando rodar o projeto pela primeira vez, automaticamente criação o banco.</li>
</ul>

#### 5. Executar o projeto:

<ul dir="auto">
<li>Pressione F5 ou clique em "Iniciar" no Visual Studio para executar o projeto.</li>
</ul>

#### 6. Endpoints da API

<ul dir="auto">
<li>Após rodar o projeto, basta acrescentar a url criada: `/swagger//index.html`</li>
<li>Após isso, irá aparecer a página do Swagger, com isso, basta acessar os endpoints e fazer os cadastros e consultas das tabelas.</li>
</ul>

## ❓ Dúvidas?

Se tiver qualquer dúvida, entre em contato com e-mail diogo_santos_goncalves@hotmail ou telefone (24) 99825-1424.
