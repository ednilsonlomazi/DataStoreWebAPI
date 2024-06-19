## Descrição
Data Store Web API é uma Web API utilizada no gerenciamento de acessos e catálogo de dados dentro de um banco de dados relacional. 

## Objetivo geral
Fornecer uma interface entre usuário final e banco de dados.

## Objetivos específicos
1) Documentar quem solicitou uma permissão à um objeto
2) Documentar quem liberou a permisão
3) Documentar quando foi a solicitação
4) Documentar quando foi a liberação
5) Catalogar objetos dentro do banco, de forma a classificálos em categorias, facilitando a busca de dados.
    
## Finalidade do software
O software desenvolvido neste repositório possui como finalidade o estudo das tecnologias utilizadas.    

## Tecnologias utilizadas

* Entity Framework - ORM
* Identity Framework - Controle de Usuários
* SQL Server - Banco de Dados

## Fluxo da api
Para ter detalhes do fluxo de uso da API, criei um fluxograma que pode ser consultado no [Link](https://github.com/ednilsonlomazi/DataStoreWebAPI/blob/master/fluxo_de_uso.png). No entanto, forneço abaixo um resumo do fluxo: 

* Usuário cria seu cadastro na API
* Solicita uma permissão (SELECT, UPDATE, DELETE...) á um objeto (TABELA, PROCEDURE, VIEW...)
* A solicitação passa pela avaliação de um avaliador
* O avaliador quando não aprova a solicitação, dá direito ao usuário de ter um recurso
* O avaliador quando aprova a solicitação, notifica o usuário.
* No caso onde há recurso de avaliação pelo usuário, o avaliador pode aceitar ou recusar o recurso.


## Próximos passos
Atualmente uma aplicação desktop está sendo desenvovida [Link repositório git](https://github.com/ednilsonlomazi/DataStoreDesktop), a qual fará as requisições para esta API, e fornecerá ao usuário uma esperiência visual do sistema.

