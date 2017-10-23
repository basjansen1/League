/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

Merge INTO dbo.Category AS Target
USING (values
	('Shoulders'),
	('Chest'),
	('Belt'),
	('Legs'),
	('Boots')
) AS Source (Name)
ON Target.Name = Source.Name
WHEN NOT MATCHED BY TARGET THEN  
	INSERT (Name)  
	VALUES (Name)  
WHEN MATCHED THEN
	UPDATE SET
		Name = Source.Name;
Merge INTO dbo.Equipment AS Target
USING (values
	(1,'Shoulders1', 3, 5, 4, 20, 'Shoulders'),
	(2,'Chest1', 3, 5, 4, 20, 'Chest'),
	(3,'Belt1', 3, 5, 4, 20, 'Belt'),
	(4,'Legs1', 3, 5, 4, 20, 'Legs'),
	(5,'boots1', 3, 5, 4, 20, 'Boots')
) AS Source (Id, Name, Strength, Intelligence, Agility, Price, Category)
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN  
	INSERT (Id, Name, Strength, Intelligence, Agility, Price, Category)  
	VALUES (Id, Name, Strength, Intelligence, Agility, Price, Category)  
WHEN MATCHED THEN
	UPDATE SET
		Name = Source.Name,
		Strength = Source.Strength,
		Intelligence = Source.Intelligence,
		Agility = Source.Agility,
		Price = Source.Price,
		Category = Source.Category;
Merge INTO dbo.Ninja AS Target
USING (values
	(1, 'Ninja1', 800),
	(2, 'Ninja2', 800),
	(3, 'Ninja3', 800)
) AS Source (Id, Name, AmountGold)
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN  
	INSERT (Id, Name, AmountGold)  
	VALUES (Id, Name, AmountGold)  
WHEN MATCHED THEN
	UPDATE SET
		Name = Source.Name,
		AmountGold = Source.AmountGold;
GO
