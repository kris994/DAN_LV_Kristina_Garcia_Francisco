-- Dropping the tables before recreating the database in the order depending how the foreign keys are placed.
IF OBJECT_ID('tblPizzaIngredient', 'U') IS NOT NULL DROP TABLE tblPizzaIngredient;
IF OBJECT_ID('tblPizza', 'U') IS NOT NULL DROP TABLE tblPizza;
IF OBJECT_ID('tblIngredient', 'U') IS NOT NULL DROP TABLE tblIngredient;

-- Checks if the database already exists.
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'PizzaPanDB')
CREATE DATABASE PizzaPanDB;
GO

USE PizzaPanDB
GO

CREATE TABLE tblIngredient(
	IngredientID		INT IDENTITY(1,1) PRIMARY KEY 	NOT NULL,
	IngredientName		NVARCHAR (40)					NOT NULL,
	IngredientPrice		NVARCHAR(20)					NOT NULL,
);

CREATE TABLE tblPizza(
	PizzaID			INT IDENTITY(1,1) PRIMARY KEY 	NOT NULL,
	PizzaSize		NVARCHAR (40)					NOT NULL,
);

CREATE TABLE tblPizzaIngredient(
	PizzaIngredientID		INT IDENTITY(1,1) PRIMARY KEY 	NOT NULL,
	PizzaID INT FOREIGN KEY REFERENCES tblPizza(PizzaID) NOT NULL,
	IngredientID INT FOREIGN KEY REFERENCES tblIngredient(IngredientID)	NOT NULL,
);