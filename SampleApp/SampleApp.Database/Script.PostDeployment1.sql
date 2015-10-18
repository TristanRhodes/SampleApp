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

-- Variables
DECLARE @ParentBundleName NVARCHAR(255) = 'Parent Bundle Item' 
DECLARE @ChildBundleName NVARCHAR(255) = 'Child Bundle Item' 

-- Populate Product Table with sample data
INSERT INTO [dbo].[Product]	(Name, Price, Description, ImageUrl, UpdatedDate) VALUES (@ParentBundleName, 159.99, 'DESCRIPTION', 'www.myurl.com', '2015-01-01 00:00:00.000')
INSERT INTO [dbo].[Product]	(Name, Price, Description, ImageUrl, UpdatedDate) VALUES (@ChildBundleName, 800, 'DESCRIPTION', 'www.myurl.com', '2015-01-01 00:00:00.000')
INSERT INTO [dbo].[Product]	(Name, Price, Description, ImageUrl, UpdatedDate) VALUES ('Acer Aspire One laptop', 159.99, 'DESCRIPTION', 'www.myurl.com', '2015-01-01 00:00:00.000')
INSERT INTO [dbo].[Product]	(Name, Price, Description, ImageUrl, UpdatedDate) VALUES ('HP Inspiron laptop', 800, 'DESCRIPTION', 'www.myurl.com', '2015-01-01 00:00:00.000')
INSERT INTO [dbo].[Product]	(Name, Price, Description, ImageUrl, UpdatedDate) VALUES ('IPhone 4', 599, 'DESCRIPTION', 'www.myurl.com', '2015-01-01 00:00:00.000')
INSERT INTO [dbo].[Product]	(Name, Price, Description, ImageUrl, UpdatedDate) VALUES ('IPhone 4S', 549, 'DESCRIPTION', 'www.myurl.com', '2015-01-01 00:00:00.000')
INSERT INTO [dbo].[Product]	(Name, Price, Description, ImageUrl, UpdatedDate) VALUES ('IPhone 5', 699, 'DESCRIPTION', 'www.myurl.com', '2015-01-01 00:00:00.000')
INSERT INTO [dbo].[Product]	(Name, Price, Description, ImageUrl, UpdatedDate) VALUES ('IPhone 5S', 649, 'DESCRIPTION', 'www.myurl.com', '2015-01-01 00:00:00.000')
INSERT INTO [dbo].[Product]	(Name, Price, Description, ImageUrl, UpdatedDate) VALUES ('IPhone 6', 123, 'DESCRIPTION', 'www.myurl.com', '2015-01-01 00:00:00.000')
INSERT INTO [dbo].[Product]	(Name, Price, Description, ImageUrl, UpdatedDate) VALUES ('IPhone 6S', 642, 'DESCRIPTION', 'www.myurl.com', '2015-01-01 00:00:00.000')
INSERT INTO [dbo].[Product]	(Name, Price, Description, ImageUrl, UpdatedDate) VALUES ('Mac Book Air', 291, 'DESCRIPTION', 'www.myurl.com', '2015-01-01 00:00:00.000')
INSERT INTO [dbo].[Product]	(Name, Price, Description, ImageUrl, UpdatedDate) VALUES ('Acer Aspire Extended Battery', 112, 'DESCRIPTION', 'www.myurl.com', '2015-01-01 00:00:00.000')
INSERT INTO [dbo].[Product]	(Name, Price, Description, ImageUrl, UpdatedDate) VALUES ('Acer Aspire Extended Battery', 112, 'DESCRIPTION', 'www.myurl.com', '2015-01-01 00:00:00.000')
INSERT INTO [dbo].[Product]	(Name, Price, Description, ImageUrl, UpdatedDate) VALUES ('Acer Aspire Extended Battery', 112, 'DESCRIPTION', 'www.myurl.com', '2015-01-01 00:00:00.000')

-- Populate Associated Products Table with Sample Data
DECLARE @ParentBundleProductId AS INT
DECLARE @ChildBundleProductId AS INT 

SELECT @ParentBundleProductId = ProductId FROM dbo.Product WHERE Name = @ParentBundleName
SELECT @ChildBundleProductId = ProductId FROM dbo.Product WHERE Name = @ChildBundleName

INSERT INTO dbo.ProductBundle (ParentProductId, ChildProductId) VALUES (@ParentBundleProductId, @ChildBundleProductId);