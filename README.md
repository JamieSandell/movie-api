

# movie-api

## Demo
[Get All Movies with Pagination and Filters](https://1drv.ms/v/s!Aj71ROvXuJl_n8xwsOMcokJOFDV3Jg?e=KPgMp7)

[Search by Title with Search Result Limit](https://1drv.ms/v/s!Aj71ROvXuJl_n8wdjR_A_TL9oWbA5Q?e=77nkdw)

## Specification
### The Task
Design an API that allows users to query and consume values from a database of your choice, using the dataset provided.
If you really want to show off and take things further, build a Front End (UI) that uses your API.

### Must have(s)
- [x] Search movies by title/name
- [x] Limit the number of results per search
- [x] Page through the list of movies

### Should have(s)
- [x] Filter movies by genre

### Could have(s)
- [x] Filter movies by actors
- [x] Sort movies by release date
- [ ] Sort movies by title

## Packages Used
### Microsoft.EntityFrameworkCore
For mapping database objects.
### Microsoft.EntityFrameworkCore.SqlServer
EF Core database provider package for Microsoft SQL Server and Azure SQL.
### Microsoft.EntityFrameworkCore.Tools
For commands for the Package Manager Console.
### StyleCop.Analyzers
For keeping a consistent coding style.

## Considerations
### Data Source
When using the data import wizard for flat files in SSMS it gave a warning about having had to drop 12 rows.
In production you'd want to have a staging table and use a config table for screening rules to alert the appropriate people of a failed import that tells them which rules the file failed on.
For the sake of brevity this hasn't been done and we're working with 9837 rows instead of 9849.
### EF Core
If the dataset was big enough or complex enough it would be worth considering calling sprocs instead of LINQ or FromSQL for performance reasons.

## TODO
- [ ] Unit tests
- [ ] Deploy with Docker and Docker compose files
- [ ] Frontend in React
- [ ] Frontend in a Desktop app

> Written with [StackEdit](https://stackedit.io/).