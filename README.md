
# movie-api

## Specification
### The Task
Design an API that allows users to query and consume values from a database of your choice, using the dataset provided.
If you really want to show off and take things further, build a Front End (UI) that uses your API.

### Must have(s)
Search movies by title/name
Limit the number of results per search
Page through the list of movies

### Should have(s)
Filter movies by genre

### Could have(s)
Filter movies by actors
Sort movies by title/name or release date

## Packages Used
### Microsoft.EntityFrameworkCore
For mapping database objects.
### Microsoft.EntityFrameworkCore.SqlServer
EF Core database provider package for Microsoft SQL Server and Azure SQL.
### StyleCop.Analyzers
For keeping a consistent coding style.

## Considerations
### Data Source
When using the data import wizard for flat files in SSMS it gave a warning about having had to drop 12 rows.
In production you'd want to have a staging table and use a config table for screening rules to alert the appropriate people of a failed import that tells them which rules the file failed on.
For the sake of brevity this hasn't been done and we're working with 9837 rows instead of 9849.

> Written with [StackEdit](https://stackedit.io/).