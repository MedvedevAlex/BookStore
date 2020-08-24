# BookStore

API для Книжного магазина, призван научить меня миграциям, связям, "архитектуре", авторизации, тестам и многому другому

## Системные требования

* API - Консольное приложение для всех контроллеров и настроек
* Model - Библиотека для хранения сущностей, конфигураций, обработчиков данных, сидирование данных и миграций
* Service - Библиотека для хранения бизнес слоя
* ViewModel - Библиотека для хранения моделей, перечислителей, интерфейсов и ответов для работы внутри проекта и наружу

Авторизация: JWT Token

Удобное отображение эндпоинтов + взаимодействие: Swagger

Маппинг данных: AutoMapper

Конфигурация сущностей: Fluent API

Работа с базой данных: Entity Framework Core

Visual Studio 2019, SQL Server Manager Studio 18.~6

### Установка и запуск

Открыть проект через Visual Studio 2019 в левом нижнем углу нажать на Package Manager Console, если Package Manager Console отсуствует требуется перейти по 
```
View -> Other Windows -> Package Manager Console
```
Перейти в Package Manager Console и ввести
```
update-database -Project Model -StartupProject API
```
Выбрать стартовый проект API, запуск через IIS Express
```
F5
```