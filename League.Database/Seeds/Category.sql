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