# EfCore
Code-first


Biblioteca Microsoft.EntityFrameworkCore.Design: gera os scripts que as migrations irão aplicar (cria um script de banco de dados (no nosso caso SQL) e traduz pro banco de dados)
Biblioteca Microsoft.EntityFrameworkCore.Tools: disponibiliza os comandos para executar essa migrations

get-help entityframework - verifica os comandos disponiveis

table EfMigrationHistory - Responsável por gerenciar/armazenar os migrations do nosso banco de dados

Database-first

 
O proprio scaffold fica responsável por mapear as entidades/relacionamentos/migrations do banco de dados. 

PERFOMANCE
----------------------------------
* Create and Update

Biblioteca Z

Para melhorar performance em alterações e adições em massa, é recomendado utilizar a biblioteca Z, ela adiciona métodos de extensão no DBSet que apresentam resultados mais rápidos para adição e inserção em massa, em comparação ao método nativo.
Exemplo:
Nativo: _dbSet.AddRange(entity);
Biblioteca Z: _dbSet.BulkInsert(entity);

Para melhorar performance, você pode "brincar" com essa ferramenta.

------------------------
* Read

Eager load: Tras todos os dados de uma unica vez (com includes), e você manipula o que for necessário, a partir desse carregamento massivo. Esse modelo é padrão no EFCore

Lazy load: Tras as informações somente quando for requisitada. É necessário adicionar a biblioteca Microsoft.EntityFrameworkCore.Proxies para importar essa funcionalidade.

Após instalar a biblioteca, é preciso definir as propriedades de NAVEGAÇÃO como virtual, para informar para efCore, que elas poderão ser sobreescritas/redefinas.
