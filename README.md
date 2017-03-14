# SQrawL
A dynamic query builder based on the open-source Java Squiggle library hosted [right here on GitHub](https://github.com/gchauvet/squiggle-sql).

Example:

```csharp
var select = new SelectQuery();
var people = new Table("people");

select.AddColumn(people, "firstname");
select.AddColumn(people, "lastname");
select.AddOrder(people, "age", Order.Descending);
Console.WriteLine(select.ToString());
````

Output:
```sql
SELECT people.firstname,
   people.lastname
FROM people
ORDER BY people.age DESC
```