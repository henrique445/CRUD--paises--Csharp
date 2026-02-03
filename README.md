CRUD de Países – C# Console Application

Este projeto consiste em uma aplicação Console em C# que implementa um CRUD completo de países, utilizando SQLite como banco de dados e seguindo boas práticas de organização de código.

O objetivo principal é demonstrar fundamentos sólidos de desenvolvimento backend, com foco em lógica, estrutura e boas práticas, sem dependência de interfaces gráficas.

🛠️ Tecnologias Utilizadas

C#

.NET

SQLite

Visual Studio Code

Git / GitHub

🧠 Decisões Técnicas

Repository Pattern
Separa a lógica de acesso ao banco de dados da lógica da aplicação, facilitando manutenção e testes.

Validações centralizadas
Evitam repetição de código e tornam a aplicação mais organizada e segura.

Exportação em CSV
Utilizada como alternativa simples ao Excel (.xlsx), sem dependência de bibliotecas externas, permitindo abertura direta no Excel ou similares.

Aplicação Console
Foco total em lógica, estrutura e fundamentos da linguagem, sem distrações de UI.

📄 Funcionalidades

Cadastrar países

Listar países

Atualizar registros

Remover países

Exportar dados para arquivo CSV (gerado automaticamente na área de trabalho)

▶️ Como Executar o Projeto(Terminal GitHub)

Clone o repositório:

git clone https://github.com/henrique445/CRUD--paises--Csharp.git

Acesse a pasta do projeto:

cd CRUD--paises--Csharp


Execute a aplicação:

dotnet run

-Siga as instruções exibidas no menu para utilizar o sistema.

▶️ Opção 2 – Executar usando o GitHub Desktop

No GitHub Desktop, clique em:

-File → Clone Repository → URL

-Cole o URL do repositório:

https://github.com/henrique445/CRUD--paises--Csharp.git

-Mantenha o caminho padrão sugerido pelo GitHub Desktop e clique em Clone

-Após o repositório ser clonado:

-Clique em Repository → Show in Explorer

(ou use o atalho Ctrl + Shift + F)

-No Windows Explorer, dentro da pasta do projeto:

-Clique com o botão direito

-Selecione Abrir no Terminal ou Abrir no PowerShell

-Execute os comandos abaixo, na ordem:

dotnet restore
dotnet build
dotnet run

-O programa será executado no terminal.
-Siga as instruções exibidas no menu para utilizar o sistema.

📌 O banco de dados SQLite e a tabela são criados automaticamente na primeira execução.

👨‍💻 Autor

Jair Henrique de Siqueira Mendes
Estudante de Ciência da Computação e desenvolvimento de software.

Projeto desenvolvido como parte da preparação para entrevista de estágio em desenvolvimento na empresa Torrecid.
