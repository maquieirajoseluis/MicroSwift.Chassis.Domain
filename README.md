# MicroSwift.Chassis.Domain

MicroSwift.Chassis.Domain provides essential domain primitives for DDD (Domain-Driven Design) applications, such as entities, value objects, aggregate roots, and domain events.

## Features

- AggregateRoot
- ValueObject
- Entity
- IDomainEvent

## Installation

To install MicroSwift.Chassis.Domain, add the following package reference to your .csproj file:

```xml
<ItemGroup>
  <PackageReference Include="MicroSwift.Chassis.Domain" Version="1.0.0" />
</ItemGroup>
```

Alternatively, you can install it via NuGet Package Manager:

```bash
 dotnet add package MicroSwift.Chassis.Domain
```

## Contributing

Contributions are welcome! If you have any ideas, suggestions, or improvements for the MicroSwift.Chassis.Domain, please feel free to submit a pull request or open an issue on GitHub.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Building the Project

To build the project, run:

```bash
dotnet build
```

## Running Tests

To run the tests and see the code coverage, execute:

```bash
dotnet test --collect:"XPlat Code Coverage"
```

## Installing ReportGenerator

To use ReportGenerator for generating code coverage reports, you'll need to install it globally using .NET CLI tooling. Run the following command in your terminal:

```bash
dotnet tool install -g dotnet-reportgenerator-globaltool
```

## Generating Code Coverage Reports

Code coverage reports can be generated using the provided script generate_coverage_reports.sh. This script will search for coverage report files (coverage.cobertura.xml) in the current directory and its subdirectories, and then generate HTML reports for each file.

To execute the script, run the following command in your terminal from the root directory of the project:

```bash
./generate_coverage_reports.sh
```
