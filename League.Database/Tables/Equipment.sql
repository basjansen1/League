CREATE TABLE [dbo].[Equipment]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Strength] INT NOT NULL, 
    [Intelligence] INT NOT NULL, 
    [Agility] INT NOT NULL, 
    [Price] INT NOT NULL, 
    [Category] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_Equipment_Category] FOREIGN KEY ([Category]) REFERENCES dbo.Category([Name])
)
