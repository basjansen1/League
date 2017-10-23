CREATE TABLE [dbo].[NinjaInventory]
(
	[Ninja_Id] INT NOT NULL, 
    [Equipment_Id] INT NOT NULL,
    CONSTRAINT [FK_NinjaInventory_Ninja] FOREIGN KEY ([Ninja_Id]) REFERENCES dbo.Ninja ([Id]), 
    CONSTRAINT [FK_NinjaInventory_Equipment] FOREIGN KEY ([Equipment_Id]) REFERENCES dbo.Equipment ([Id]),
	CONSTRAINT PK_Ninja_Inventory PRIMARY KEY(Ninja_Id, Equipment_Id)
)
