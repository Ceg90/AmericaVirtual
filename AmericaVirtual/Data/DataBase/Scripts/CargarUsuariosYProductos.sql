DELETE FROM [dbo].[UserPurchases]
DELETE FROM [dbo].[UserActions]
DELETE FROM [dbo].[User]
DELETE FROM [dbo].[Product]

INSERT INTO [dbo].[User]
	(Email
	,[Password]
	,FirstName
	,LastName
	,[Address]
	,PhoneNumber)
VALUES
	('admin@admin.com', 'admin12345', 'usuario', '1', NULL, NULL),
	('admin@admin.com', 'admin12345', 'usuario', '1', NULL, NULL)


INSERT INTO [dbo].[Product]
	(Title
	,[Description]
	,Price
	,[Images])
VALUES
	('Paquete 1', 'Paquete eonómico', 2000, NULL),
	('Paquete 2', 'Paquete Gold', 50000, NULL),
	('Paquete 3', 'Paquete Silver', 12500, NULL)