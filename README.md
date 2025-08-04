# EfCore
Code-first
Biblioteca Microsoft.EntityFrameworkCore.Design: gera os scripts que as migrations irão aplicar (cria um script de banco de dados (no nosso caso SQL) e traduz pro banco de dados)
Biblioteca Microsoft.EntityFrameworkCore.Tools: disponibiliza os comandos para executar essa migrations

get-help entityframework - verifica os comandos disponiveis

table EfMigrationHistory - Responsável por gerenciar/armazenar os migrations do nosso banco de dados

Database first
Scaffold: 
Scaffold-DbContext -StartupProject Infraestruture.Scaffold -Connection "Server=RAFAELA;Database=fiapStore;User Id=sa;Password=12345;TrustServerCertificate=True" -Provider Microsoft.EntityFrameworkCore.SqlServer -Project Infraestruture.Scaffold