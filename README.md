# CQRS DotNet

Using [CQRS](https://martinfowler.com/bliki/CQRS.html) (Command Query Responsibility Segregation) to Write and Read data

## Technologies / Methodologies

- CQRS

- MediatR

- DotNet 5

## Reading data (Query)

on controller (see inplementation in Queries/PersonByName.cs)

```cs
[HttpGet]
public async Task<IActionResult> GetPersons(string Name) => Ok(await mediator.Send(new PersonByName.Query(Name)));
```

## Writing/Updating data (Commands)

see implementation in Commands/AddPerson.cs.

```cs
[HttpPost]
public async Task<IActionResult> SetPerson(AddPerson.Command command) => Ok(await mediator.Send(command));
```