# 🛒 iShopping — Gestão de Compras e Orçamentos

> **Aplicação Desktop Windows Forms** para gestão de artigos, categorias, orçamentos mensais e compras, desenvolvida em C# com .NET 10 e Entity Framework Core.

---

## 📋 Sobre o Projeto

O **iShopping** é uma aplicação de gestão de compras e orçamentos pessoais/empresariais construída com Windows Forms. Permite aos utilizadores organizar artigos por categorias, definir orçamentos mensais, criar listas de compras e acompanhar os gastos com itens individuais.

O projeto segue uma arquitetura **MVC (Model-View-Controller)** adaptada para Windows Forms, com separação clara entre modelos de dados, controladores de lógica de negócio e formulários de apresentação.

---

## 🏗️ Arquitetura

O projeto utiliza uma arquitetura **MVC** adaptada para WinForms:

```
Projeto_DA/
├── Models/            # Entidades de dados (EF Core)
│   ├── Article.cs
│   ├── ArticleType.cs
│   ├── Budget.cs
│   ├── Purchase.cs
│   ├── PurchaseItem.cs
│   └── User.cs
│
├── Controllers/       # Lógica de negócio
│   ├── ArticleController.cs
│   ├── ArticleTypeController.cs
│   ├── AuthController.cs
│   ├── BudgetController.cs
│   ├── PurchaseController.cs
│   └── PurchaseItemController.cs
│
├── Views/             # Formulários WinForms (UI)
│   ├── LoginForm.cs
│   ├── CategoriesForm.cs
│   ├── ArticlesForm.cs
│   ├── BudgetsForm.cs
│   ├── PurchasesForm.cs
│   └── PurchaseDetailsForm.cs
│
├── Data/              # Contexto de base de dados
│   └── AppDbContext.cs
│
├── Migrations/        # Migrações EF Core
├── MainForm.cs        # Dashboard principal
├── SessionManager.cs  # Gestão de sessão do utilizador
└── Program.cs         # Ponto de entrada da aplicação
```

---

## 🗄️ Modelo de Dados

```mermaid
erDiagram
    User ||--o{ Budget : "cria / modifica"
    User ||--o{ Purchase : "cria / modifica / fecha"
    ArticleType ||--o{ Article : "contém"
    Article ||--o{ PurchaseItem : "referenciado por"
    Purchase ||--o{ PurchaseItem : "contém"

    User {
        int Id PK
        string Username UK
        string Password
    }

    ArticleType {
        int ID PK
        string Name
    }

    Article {
        int ID PK
        string Name
        int ArticleTypeID FK
    }

    Budget {
        int ID PK
        int Month
        int Year
        decimal Amount
        int CreateById FK
        int ModifiedById FK
    }

    Purchase {
        int Id PK
        string Name
        bool IsClosed
        datetime CreatedDate
        datetime ClosedDate
        int CreatedById FK
        int ModifiedById FK
        int ClosedById FK
    }

    PurchaseItem {
        int Id PK
        int PurchaseId FK
        int ArticleId FK
        bool IsPlanned
        int PlannedQuantity
        int BoughtQuantity
        decimal UnitPrice
        string Notes
    }
```

---

## 🛠️ Tecnologias

| Tecnologia | Versão |
|---|---|
| **C#** | .NET 10.0 |
| **Windows Forms** | WinForms (.NET) |
| **Entity Framework Core** | 10.0.8 |
| **SQL Server** | LocalDB (MSSQLLocalDB) |
| **IDE** | Visual Studio 2022+ |

---

## 🚀 Como Executar

### Pré-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Visual Studio 2022+](https://visualstudio.microsoft.com/) com workload **".NET Desktop Development"**
- SQL Server LocalDB (incluído com o Visual Studio)

### Passos

1. **Clonar o repositório:**
   ```bash
   git clone https://github.com/Stalker0566/Projeto_DA-AAN.git
   cd Projeto_DA-AAN
   ```

2. **Abrir a solução** no Visual Studio:
   ```
   Projeto_DA.slnx
   ```

3. **Restaurar pacotes NuGet** (automático no Visual Studio, ou via terminal):
   ```bash
   dotnet restore
   ```

4. **Executar a aplicação:**
   - Pressionar `F5` no Visual Studio, ou:
   ```bash
   dotnet run --project Projeto_DA
   ```

5. **Login padrão:**
   | Utilizador | Palavra-passe |
   |---|---|
   | `admin` | `123` |

   > ⚠️ A base de dados é criada automaticamente na primeira execução via `EnsureCreated()`.

---

## 📸 Ecrãs e Funcionalidades da Aplicação

| Ecrã / Módulo | Descrição |
|---|---|
| **Login** | Autenticação segura de utilizador com palavras-passe encriptadas (PBKDF2 com Salt). |
| **Dashboard** | Painel principal com visualização de compras em aberto e acesso direto a todos os submódulos. |
| **Categorias** | Gestão completa (CRUD) de categorias de artigos (Tipos de Artigos). |
| **Artigos** | Gestão completa (CRUD) de artigos, associados a categorias. |
| **Orçamentos** | Definição de orçamentos mensais, prevenindo duplicados para o mesmo período. |
| **Compras** | Planeamento e gestão de compras por intervalo de datas. |
| **Detalhes de Compra** | Modos de edição e de compra, permitindo controlo de quantidades, preços, itens previstos/não previstos e fecho de compras (modo leitura automático). |
| **Estatísticas** | Visualização de total gasto vs. orçamento restante. |
| **Apoio à Decisão** | Geração automática de sugestões inteligentes de listas de compras e orçamentos recomendados com base no histórico. |
| **Exportação CSV** | Exportação completa das compras fechadas para ficheiro CSV. |
| **Utilizadores** | CRUD de utilizadores da aplicação para controlo de acesso. |

---

## 👥 Autores

- **André Kotelyanets** (Nº Aluno: 2024147182)
- **Nazar Bobko** (Nº Aluno: 2024??????)
- **Artem Chernysch** (Nº Aluno: 2024??????)
- **Grupo AAN**

---

## 📄 Licença

Este projeto é desenvolvido para fins académicos no âmbito da unidade curricular de Desenvolvimento de Aplicações (DA).

