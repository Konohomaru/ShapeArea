## Удобный запуск юнит-тестов

Если у вас установлен Docker и GNU Make, то юнит-тесты можно запустить командой из корневой папки репозитория

```bash
make -f .makefile test
```

## Задание с БД

В базе данных MS SQL Server есть продукты и категории. Одному продукту может соответствовать много категорий, в одной категории может быть много продуктов. Напишите SQL запрос для выбора всех пар «Имя продукта – Имя категории». Если у продукта нет категорий, то его имя все равно должно выводиться

Для примера были созданные самые простые таблицы, чтобы не раздувать решение

```SQL
CREATE TABLE [Products] ([Name] NVARCHAR(100))
CREATE TABLE [Categories] ([Name] NVARCHAR(100))
CREATE TABLE [ProductCategories] ([ProductName] NVARCHAR(100), [CategoryName] NVARCHAR(100))

GO

INSERT INTO [Products] VALUES
	  ('Milk')
	, ('Bread')
	, ('BRASS. Bermingem')

INSERT INTO [Categories] VALUES
	  ('Groceries')
	, ('Liquid')
	, ('Car')

INSERT INTO [ProductCategories] VALUES
	  ('Milk', 'Groceries')
	, ('Milk', 'Liquid')
	, ('Bread', 'Groceries')

GO

SELECT
	  [Name] AS 'Product'
	, [CategoryName] AS 'Category'
FROM [Products] AS [P] WITH(NOLOCK)
LEFT JOIN [ProductCategories] AS [PC] WITH(NOLOCK) ON [PC].[ProductName] = [P].[Name]
```

Выборка, написанная в запросе выше, вернёт данные, которые представлены в таблице ниже

№ | Product | Category
--- | --- | ---
1 | Milk | Groceries
2 | Milk | Liquid
3 | Bread | Groceries
4 | BRASS. Bermingem | NULL