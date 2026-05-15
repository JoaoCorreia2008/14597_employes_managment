15 de maio Ficha de avaliação #2
tenho que saber para o teste :
Criação de Modelos, Controladores, Vistas, Gerir e Controlar Migrações 
--------------------------------------------------------------------------

**Projeto: 14597_employes_managment**

Este README explica os conceitos e passos essenciais para o seu teste: criação de Modelos, Controladores, Vistas, gestão de Migrações e como executar/testar o projeto.

**Visão Geral**
- **Descrição**: projeto ASP.NET Core MVC com Entity Framework Core para gerir empregados.
- **Ponto de partida**: abra o projeto principal em `14597_employes_managment/`.

**Modelos**
- **O que:** classes POCO que representam entidades (dados).
- **Arquivo exemplo:** [14597_employes_managment/Models/Employee.cs](14597_employes_managment/Models/Employee.cs)
- **Como criar:** adicionar uma classe com propriedades públicas. Exemplo mínimo:

```
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }
}
```
- **Ligar ao DbContext:** registar `DbSet<Employee>` em [14597_employes_managment/Data/ApplicationDbContext.cs](14597_employes_managment/Data/ApplicationDbContext.cs).
- **Boas práticas:** usar data annotations para validação e separar `ViewModel`s quando necessário.

**Controladores**
- **O que:** recebem pedidos HTTP e devolvem `View`/JSON.
- **Arquivo exemplo:** [14597_employes_managment/Controllers/EmployeesController.cs](14597_employes_managment/Controllers/EmployeesController.cs)
- **Como criar:** criar uma classe que herda de `Controller`, injetar `ApplicationDbContext` e implementar ações `Index`, `Create`, `Edit`, `Details`, `Delete`.
- **Scaffolding (opcional):** para gerar controller + views automaticamente:

```
dotnet tool install -g dotnet-aspnet-codegenerator
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet aspnet-codegenerator controller -name EmployeesController -m Employee -dc ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
```

**Vistas (Razor)**
- **O que:** ficheiros `.cshtml` que apresentam a UI.
- **Exemplos:** [14597_employes_managment/Views/Employees/Index.cshtml](14597_employes_managment/Views/Employees/Index.cshtml)
- **Como criar:** adicionar ficheiro `.cshtml` em `Views/<Controller>/` e usar `@model` no topo (ex.: `@model IEnumerable<Employee>`).
- **Layout e partials:** usar `_Layout.cshtml` e `_ValidationScriptsPartial.cshtml` para consistência.

**Migrações (Entity Framework Core)**
- **Pré-requisitos:** confirmar `ConnectionString` em [14597_employes_managment/appsettings.json](14597_employes_managment/appsettings.json) e `ApplicationDbContext` configurado.
- **Instalar ferramentas (se necessário):**

```
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
```
- **Criar migration:**

```
dotnet ef migrations add NomeDaMigration
```
- **Aplicar ao banco:**

```
dotnet ef database update
```
- **Outros comandos úteis:** `dotnet ef migrations list`, `dotnet ef migrations remove`.
- **Boas práticas:** commitar ficheiros de migrations, usar nomes claros e testar migrations em ambiente de dev antes de produção.

**Testes e execução**
- **Executar o projeto:** na pasta do projeto (`14597_employes_managment/`):

```bash
dotnet run
```

- **Hot-reload (opcional):** `dotnet watch run`.
- **Aceder à rota Employees:** abrir `https://localhost:5001/Employees` (ou a porta configurada).
- **Testes automáticos:** se existir projeto de testes: `dotnet test`.
- **Sugestão de testes manuais:** verificar fluxos Create/Read/Update/Delete, mensagens de validação e integridade do DB.

**Checklist rápido para o teste**
- **Conexão DB:** `appsettings.json` configurado.
- **Migrations aplicadas:** `dotnet ef database update` executado.
- **Controller & Views:** `Controllers/EmployeesController.cs` e `Views/Employees/*` presentes.
- **Build:** `dotnet build` e `dotnet run` sem erros.

---

# trabalho-MVC

# ASP.NET Core MVC — Mini Guia

## Criar Projeto MVC

```bash
dotnet new mvc -n MeuProjeto
cd MeuProjeto
```

### O que este comando faz?
Cria automaticamente:

- `Controllers`
- `Views`
- `Models`
- configuração MVC completa

---

# Instalar Ferramentas de Scaffolding

## Instalar o code generator

```bash
dotnet tool install -g dotnet-aspnet-codegenerator-tool
```

## Adicionar package ao projeto

```bash
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
```

### O que o scaffolding gera?

- Controllers
- Views
- CRUD completo
- integração com Entity Framework

---

# Criar um Model

## Exemplo

### `Models/Product.cs`

```csharp
namespace MeuProjeto.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
```

### O que é um Model?

O Model representa os dados da aplicação.

---

# Configurar Entity Framework

## Instalar packages

```bash
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design
```

---

# Criar DbContext

## `Data/AppDbContext.cs`

```csharp
using Microsoft.EntityFrameworkCore;
using MeuProjeto.Models;

namespace MeuProjeto.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}
```

### O que é o DbContext?

O DbContext faz a ligação entre:

- a aplicação
- a base de dados

---

# Registrar o DbContext

## `Program.cs`

```csharp
using MeuProjeto.Data;
using Microsoft.EntityFrameworkCore;

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=app.db"));
```

---

# Criar Base de Dados

## Instalar ferramenta EF

```bash
dotnet tool install --global dotnet-ef
```

## Criar migration

```bash
dotnet ef migrations add InitialCreate
```

## Atualizar base de dados

```bash
dotnet ef database update
```

---

# Gerar Controller + Views Automaticamente

```bash
dotnet aspnet-codegenerator controller \
-name ProductsController \
-m Product \
-dc AppDbContext \
--relativeFolderPath Controllers \
--useDefaultLayout \
--referenceScriptLibraries
```

---

# O que este comando cria?

## Controller

```text
Controllers/ProductsController.cs
```

Responsável pela lógica da aplicação.

---

## Views CRUD

```text
Views/Products/
```

Inclui:

- Create
- Edit
- Delete
- Details
- Index

---

# Executar Projeto

```bash
dotnet run
```

Abrir:

```text
http://localhost:5000
```

ou:

```text
https://localhost:5001
```

---

# Hot Reload

```bash
dotnet watch run
```

Atualiza automaticamente quando guardas ficheiros.

---

# Estrutura MVC

| Pasta | Função |
|---|---|
| Models | Dados da aplicação |
| Views | Interface visual |
| Controllers | Lógica da aplicação |
| Data | Base de dados |

---

# Fluxo MVC

```text
Utilizador → Controller → Model → View → Utilizador
```

---

# Criar Controller Vazio

```bash
dotnet aspnet-codegenerator controller \
-name HomeController \
--relativeFolderPath Controllers
```

---

# Criar API Controller

```bash
dotnet aspnet-codegenerator controller \
-name ApiController \
-api
```

---

# Criar View Manualmente

## Exemplo

### `Views/Home/Index.cshtml`

```html
<h1>Olá MVC</h1>
```

---

# Retornar uma View

## Exemplo Controller

```csharp
public IActionResult Index()
{
    return View();
}
```

O MVC procura automaticamente:

```text
Views/Home/Index.cshtml
```

---

# Conceitos MVC

| Conceito | Função |
|---|---|
| Model | Dados |
| View | Interface |
| Controller | Lógica |

---

# CRUD

| Operação | Significado |
|---|---|
| Create | Criar |
| Read | Ler |
| Update | Atualizar |
| Delete | Apagar |

---
