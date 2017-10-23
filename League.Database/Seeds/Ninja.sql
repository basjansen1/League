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