# ???

- `^\s*[\r\n]`
- заменить пустотой
- `Meziantou.Analyzer 3.0.320`
- `Microsoft.Unity.Analyzers 1.28.0`

```sh
# Проверка форматирования с записью лога + JSON-отчёт
dotnet format style --verify-no-changes --verbosity diagnostic 2>&1 --report format-report | tee format-check.log
# Форматирование
dotnet format example-csharp-lint.csproj --verbosity diagnostic
dotnet format style --verbosity diagnostic | tee format-check.log
dotnet format --diagnostics --verbosity diagnostic
dotnet format style ./SpaceSimulator.slnx --diagnostics --verbosity diagnostic

# ???
dotnet restore example-csharp-lint.csproj --verbosity diagnostic               # ???
dotnet build example-csharp-lint.csproj --no-restore --verbosity diagnostic    # сборка
```
