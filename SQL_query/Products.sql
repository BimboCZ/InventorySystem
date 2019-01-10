USE [InventorySystem]
GO

INSERT INTO [dbo].[Products]
           ([ProductCode]
           ,[ProductName]
           ,[ProductStatus])
     VALUES
           (<ProductCode, int,>
           ,<ProductName, varchar(50),>
           ,<ProductStatus, bit,>)
GO


select * from dbo.Products

delete from dbo.Products