#Projeto CRUD de Países : C# + SQLite

Projeto desenvolvido como exercício prático para vaga de estágio em desenvolvimento, com foco em lógica, boas práticas, validação de dados e persistência em banco de dados.

O sistema funciona via terminal (Console App) e permite cadastrar, consultar, editar, deletar e exportar dados de países.

#Objetivo do Projeto

Criar sistema simples para armazenar dados de paises(nome,população e área total) com banco de dados relacional e possibilidade de exportar tabela como aarquivo CSV.

#Tecnologias Utilizadas

-C# (.NET Console Application)

-SQLite (banco de dados local)

-Microsoft.Data.Sqlite

-Visual Studio Code

🗂️ Estrutura do Projeto
📁 Projeto
 ┣ 📄 Program.cs          → Menu, validações e fluxo principal
 ┣ 📄 Pais.cs             → Model (entidade País)
 ┣ 📄 PaisRepository.cs   → Repository (CRUD no banco)
 ┣ 📄 Database.cs         → Criação do banco e conexão SQLite

#Funcionalidades
## CRUD completo

-Cadastrar país (nome, população, área total)

-Consultar países

-Editar país existente (com validação de ID)

-Deletar país (com validação de ID)

## Validações 

-Uso de TryParse para evitar exceções

-Validação de números positivos

-Validação de strings vazias ou nulas

-Validação de existência do ID antes de editar/deletar

## Exportação de dados

Exportação dos países para arquivo CSV

Arquivo gerado automaticamente na Área de Trabalho

Abertura automática no Excel / LibreOffice

## Exportação CSV

O sistema permite exportar os dados consultados para um arquivo:

paises.csv

Formato compatível com Excel (separador ; para PT-BR):

ID;NOME;POPULACAO;AREA_TOTAL
1;BRASIL;214000000;8515767

# Decisões Técnicas Importantes

Repository Pattern: separa a lógica de acesso ao banco da lógica do programa

Validações centralizadas: evitam repetição de código e facilitam manutenção

CSV em vez de Excel (.xlsx): solução simples, sem dependências externas

Console Application: foco em lógica e fundamentos, sem distrações de UI

#Como Executar o Projeto

Clone o repositório

git clone henrique445/CRUD--paises--Csharp

Acesse a pasta do projeto:

cd CRUD--paises--Csharp

Execute o projeto:

dotnet run

O banco SQLite e a tabela são criados automaticamente na primeira execução.

👨‍💻 Autor

Jair Henrique de Siqueira Mendes

Estudante de Ciência da Computação e desenvolvimento de software.

Projeto desenvolvido como parte da preparação para entrevista de estágio em desenvolvimento na empressa TORRECID.
