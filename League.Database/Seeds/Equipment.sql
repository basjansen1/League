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