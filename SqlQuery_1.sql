USE [HotdealsCommerce]
GO

/****** Object:  Table [Catalogue].[Products]    Script Date: 22/01/2022 6:03:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Catalogue].[Products](
	[Id] [bigint] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Description] [varchar](250) NULL,
	[Price] [decimal](18, 0) NOT NULL,
	[IsActive] [char](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [HotdealsCommerce]
GO

/****** Object:  Table [Sales].[OrderItems]    Script Date: 22/01/2022 6:09:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Sales].[OrderItems](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[OrderId] [bigint] NOT NULL,
	[OrderItemId] [bigint] NOT NULL,
	[OrderItemQuantity] [decimal](18, 0) NOT NULL,
	[OrderItemPrice] [decimal](18, 0) NULL,
	[OrderItemNetAmount] [decimal](18, 0) NOT NULL,
	[OrderItemDeliveryId] [bigint] NULL,
	[OrderItemDeliveryDate] [datetime] NULL,
	[OrderItemDeliveryCost] [decimal](18, 0) NULL,
	[OrderItemGrossAmount] [decimal](18, 0) NULL,
	[OrderItemDeliveryStatus] [varchar](2) NULL,
 CONSTRAINT [PK_OrderItemsID] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [Sales].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItemId_ProductsId] FOREIGN KEY([OrderItemId])
REFERENCES [Sales].[Orders] ([Id])
GO

ALTER TABLE [Sales].[OrderItems] CHECK CONSTRAINT [FK_OrderItemId_ProductsId]
GO


USE [HotdealsCommerce]
GO

/****** Object:  Table [Sales].[Orders]    Script Date: 22/01/2022 6:09:54 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Sales].[Orders](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[BilledTo] [varchar](50) NULL,
	[ShippedTo] [varchar](50) NULL,
	[OrderAmount] [decimal](18, 0) NOT NULL,
	[OrderDiscount] [decimal](18, 0) NULL,
	[OrderDate] [datetime] NOT NULL,
	[OrderStatus] [varchar](50) NOT NULL,
 CONSTRAINT [PK__Orders__3214EC07AC121C67] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [HotdealsCommerce]
GO

/****** Object:  Table [Shipping].[Deliveries]    Script Date: 22/01/2022 6:10:14 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Shipping].[Deliveries](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[OrderId] [bigint] NOT NULL,
	[OrderItemId] [bigint] NOT NULL,
	[TargetDeliveryDate] [date] NOT NULL,
	[DeliveryCost] [decimal](18, 0) NOT NULL,
	[ActualDeliveryDatde] [date] NULL,
	[DeliveryStatus] [varchar](50) NOT NULL,
 CONSTRAINT [PK_DeliveryId] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [Shipping].[Deliveries]  WITH CHECK ADD  CONSTRAINT [FK_DeliveryItemId_OrderItems_Id] FOREIGN KEY([OrderItemId])
REFERENCES [Sales].[OrderItems] ([Id])
GO

ALTER TABLE [Shipping].[Deliveries] CHECK CONSTRAINT [FK_DeliveryItemId_OrderItems_Id]
GO

ALTER TABLE [Shipping].[Deliveries]  WITH CHECK ADD  CONSTRAINT [FK_DeliveryOrderId_Orders_Id] FOREIGN KEY([OrderId])
REFERENCES [Sales].[Orders] ([Id])
GO

ALTER TABLE [Shipping].[Deliveries] CHECK CONSTRAINT [FK_DeliveryOrderId_Orders_Id]
GO


