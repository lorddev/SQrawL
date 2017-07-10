[![Build status](https://ci.appveyor.com/api/projects/status/4fslqainn8rxnhjk?svg=true)](https://ci.appveyor.com/project/lorddev/sqrawl)

# SQrawL
A dynamic query builder based on the open-source Java Squiggle library hosted [right here on GitHub](https://github.com/gchauvet/squiggle-sql). It is intended to be useful in situations where you don't have the liberty of creating a new stored procedure or implementing a new Entity Framework context. It is also designed to help avoid SQL injection attacks by parameterizing inputs.

Pseudocode:

```csharp
    var select = new SelectQuery();
    var people = new Table("people");
    var fn = select.AddColumn(people, "firstname");
    var ln = select.AddColumn(people, "lastname");    
    people.OrderBy(fn, SortOrder.Descending);   
    Console.WriteLine(select.ToString());
````

Output:

```sql
    SELECT people.firstname,
       people.lastname
    FROM people
    ORDER BY people.age DESC
```
