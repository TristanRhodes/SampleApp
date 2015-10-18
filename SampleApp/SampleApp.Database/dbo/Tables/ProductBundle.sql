CREATE TABLE [dbo].[ProductBundle](
	[ParentProductId] [int] NOT NULL,
	[ChildProductId] [int] NOT NULL,
 CONSTRAINT [PK_ProductBundle] PRIMARY KEY CLUSTERED 
(
	[ParentProductId] ASC,
	[ChildProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ProductBundle]  WITH CHECK ADD  CONSTRAINT [FK_ProductBundle_Product_Child] FOREIGN KEY([ChildProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO

ALTER TABLE [dbo].[ProductBundle] CHECK CONSTRAINT [FK_ProductBundle_Product_Child]
GO
ALTER TABLE [dbo].[ProductBundle]  WITH CHECK ADD  CONSTRAINT [FK_ProductBundle_Product_Parent] FOREIGN KEY([ParentProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO

ALTER TABLE [dbo].[ProductBundle] CHECK CONSTRAINT [FK_ProductBundle_Product_Parent]