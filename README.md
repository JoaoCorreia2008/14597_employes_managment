15 de maio Ficha de avaliação #2
tenho que saber para o teste :
Criação de Modelos, Controladores, Vistas, Gerir e Controlar Migrações 
--------------------------------------------------------------------------


Modelos

O que: Definem as entidades do domínio (dados).
Onde: ficheiros em Models/ (ex.: Models/Employee.cs).
Como criar: adicionar uma classe POCO. Exemplo mínimo:
public class Employee { public int Id { get; set; } public string Name { get; set; } public string Position { get; set; } }
Ligar ao EF Core: registar DbSet em Data/ApplicationDbContext.cs:
public DbSet<Employee> Employees { get; set; }
Boas práticas: colocar validações com data annotations e separar modelos de domínio de ViewModels quando necessário.
Controladores

O que: recebem pedidos HTTP e devolvem Views/JSON.
Onde: Controllers/ (ex.: Controllers/EmployeesController.cs).
Como criar: criar um controller MVC que injeta ApplicationDbContext e implementa ações Index, Create, Edit, Details, Delete. Exemplo de assinatura:
public class EmployeesController : Controller
Scaffolding (opcional): se preferir gerar automaticamente:
Instalar code generator: dotnet tool install -g dotnet-aspnet-codegenerator
Adicionar pacote: dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
Gerar: dotnet aspnet-codegenerator controller -name EmployeesController -m Employee -dc ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
Notas: separar lógica complexa em serviços e usar ViewModels para comunicação com Views.
Vistas (Razor Views)

O que: páginas Razor para UI.
Onde: Views/Employees/ (ex.: Views/Employees/Index.cshtml, Create.cshtml, Edit.cshtml, Details.cshtml, Delete.cshtml).
Como criar: criar ficheiros .cshtml com marcação Razor, usar @model no topo para tipar a view (ex.: @model IEnumerable<Employee>).
Scaffold de Views: o comando do scaffolding do controller acima gera também as Views.
Layout & partials: usar _Layout.cshtml e partials como _ValidationScriptsPartial.cshtml para consistência.
Migrações (EF Core)

Pré-requisitos: confirmar provider e ConnectionString em appsettings.json, conferir Data/ApplicationDbContext.cs. Instalar dotnet-ef se necessário:
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
Criar uma migration: a partir da pasta do projeto onde está o .csproj:
dotnet ef migrations add NomeDaMigration
Aplicar ao banco de dados:
dotnet ef database update
Listar e remover:
dotnet ef migrations list
Remover última migration (se ainda não aplicada): dotnet ef migrations remove
Controlar versão: usar mensagens de migration significativas; commitar os ficheiros de migrations em controlo de versão; ao fazer alterações estruturais planejar migrações em dev antes de produção.
Testes e execução (como testar no projeto atual)

Executar a aplicação: na pasta do projecto:
dotnet run (ou usar dotnet watch run para reload)
abrir browser: https://localhost:5001/Employees (ou rota configurada)
Testes manuais principais: verificar Create/Read/Update/Delete nas Views de Employees. Testar validações do modelo.
Testes automatizados: se houver projectos de testes, executar: dotnet test. Se não houver, adicionar um projecto xUnit/NUnit e criar testes para: controllers (unit), serviços (unit), e testes de integração que corram contra um banco em memória.
Checklist rápido antes do teste do exame:
Conexão DB: appsettings.json apontar para a DB correta.
Migrações aplicadas: dotnet ef database update executado.
Rota Employees: EmployeesController presente e Views existentes em Views/Employees/.
Builds e run: dotnet build e dotnet run sem erros.
