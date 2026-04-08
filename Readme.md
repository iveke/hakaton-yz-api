# hakaton-yz-api

## Опис проекту

Це бекенд для логістичної системи (хакатон), написаний на ASP.NET Core Web API з використанням Entity Framework Core та PostgreSQL. Основна логіка — робота з вагонами, відправленнями, фільтрацією, підбором та статусами.

---

## Як запустити проект

1. **Встановіть залежності:**
   - .NET 10.0 SDK
   - PostgreSQL (налаштуйте підключення у `appsettings.json`)

2. **Клонувати репозиторій:**
   ```bash
   git clone <repo-url>
   cd hakaton-yz-api
   ```

3. **Налаштувати підключення до БД:**
   - Вкажіть свій connection string у `appsettings.json` (рядок `DefaultConnection`).

4. **Застосувати міграції та створити БД:**
   ```bash
   dotnet ef database update
   ```

5. **Запустити проект:**
   ```bash
   dotnet run
   ```
   Або через IDE (наприклад, Visual Studio/VS Code).

---

## Оновлення структури БД (міграції)

1. **Після змін у моделях:**
   ```bash
   dotnet ef migrations add НазваМіграції
   dotnet ef database update
   ```
2. **Якщо потрібно скасувати останню міграцію:**
   ```bash
   dotnet ef migrations remove
   ```

---

## Структура проекту

- **Controllers/** — контролери API (ShipmentController, WagonController, SuggestionController)
- **Models/** — основні моделі (Shipment, Wagon, Station)
- **Services/** — бізнес-логіка, алгоритми, сидування даних (SeedData, AlgorithmService)
- **Data/** — контекст БД (AppDbContext)
- **Properties/** — налаштування запуску
- **appsettings.json** — конфігурація (у т.ч. підключення до БД)
- **hakaton-yz-api.http** — приклади HTTP-запитів для тестування API

---

## Корисні команди

- **Збірка проекту:**
  ```bash
  dotnet build
  ```
- **Запуск проекту:**
  ```bash
  dotnet run
  ```
- **Створення міграції:**
  ```bash
  dotnet ef migrations add НазваМіграції
  ```
- **Оновлення БД:**
  ```bash
  dotnet ef database update
  ```

---

## Додатково

- Для тестування API можна використовувати Postman або файл `hakaton-yz-api.http`.
- SeedData автоматично додає тестові вагони при першому запуску.
- Якщо виникнуть питання — звертайтесь у командний чат!

Успіхів у роботі! 🚀
