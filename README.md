## Description
Data Store Web API é uma Web API utilizada no gerenciamento e catálogo de acessos em dados dentro de um banco de dados relacional. 

## Objetivo geral
Fornecer uma interface entre usuário final e banco de dados.

## Objetivos específicos
1) Documentar:
    Quem solicitou uma permissão à um objeto
    Quem liberou a permisão
    Quando foi a solicitação
    Quando foi a liberação

2) Catalogar:
    Objetos dentro do banco, de forma a classificálos em categorias, facilitando a busca de dados.
    
## Finalidade do software
O software desenvolvido neste repositório possui como finalidade o estudo das tecnologias utilizadas.    

## Tecnologias utilizadas

* Entity Framework - ORM
* Identity Framework - Controle de Usuários
* SQL Server - Banco de Dados

## Fluxo da api
Para ter detalhes do fluxo de uso da API, criei um fluxograma que pode ser consultado no [LINK](https://github.com/ednilsonlomazi/DataStoreWebApi/fluxo_de_uso). No entanto, forneço abaixo um resumo do fluxo: 

* Usuário cria seu cadastro na API
* Solicita uma permissão (SELECT, UPDATE, DELETE...) á um objeto (TABELA, PROCEDURE, VIEW...)
* A solicitação passa pela avaliação de um avaliador
* O avaliador quando não aprova a solicitação, dá direito ao usuário de ter um recurso
* O avaliador quando aprova a solicitação, notifica o usuário.
* No caso onde há recurso de avaliação pelo usuário, o avaliador pode aceitar ou recusar o recurso.


## Próximos passos
Atualmente uma aplicação desktop está sendo desenvovida [Link repositório git](https://github.com/ednilsonlomazi/DataStoreDesktop), a qual fará as requisições para esta API, e fornecerá ao usuário uma esperiência visual do sistema.

