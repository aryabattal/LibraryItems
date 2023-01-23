USE [ManageLibraryItemsAndEmployees]
GO
SET IDENTITY_INSERT [dbo].[LibraryItems] ON 

INSERT INTO [dbo].[LibraryItems] ([Id],[CategoryId], [Title], [Author], [Pages], [RunTimeMinutes], [IsBorrowable], [Borrower],[BorrowerDate],[Type]) VALUES (4,1,'Sciences Book','Lorem ipsum ', 433,'', 'true', 'Jone Doe','2021-05-10', 'AudioBook')
INSERT INTO [dbo].[LibraryItems] ([Id],[CategoryId], [Title], [Author], [Pages], [RunTimeMinutes], [IsBorrowable], [Borrower],[BorrowerDate],[Type]) VALUES (4,1,'Sciences Book','Lorem ipsum ', 433,'', 'true', 'Jone Doe','2021-05-10', 'AudioBook')
INSERT INTO [dbo].[LibraryItems] ([Id],[CategoryId], [Title], [Author], [Pages], [RunTimeMinutes], [IsBorrowable], [Borrower],[BorrowerDate],[Type]) VALUES (1,1,'Sciences Book','Lorem ipsum ', 233,'', 'true', 'Jone Doe','2021-05-10', 'Book')
INSERT INTO [dbo].[LibraryItems] ([Id],[CategoryId], [Title], [Author], [Pages], [RunTimeMinutes], [IsBorrowable], [Borrower],[BorrowerDate],[Type]) VALUES (2,2,'literature Book','Lorem ipsum ', 199,'', 'true', 'Jone Doe','2021-05-10', 'Book')
INSERT INTO [dbo].[LibraryItems] ([Id],[CategoryId], [Title], [Author], [Pages], [RunTimeMinutes], [IsBorrowable], [Borrower],[BorrowerDate],[Type]) VALUES (3,3,'Arts Book','Lorem ipsum ', 313,'', 'true', 'Jone Doe','2021-05-10', 'Book')
INSERT INTO [dbo].[LibraryItems] ([Id],[CategoryId], [Title], [Author], [Pages], [RunTimeMinutes], [IsBorrowable], [Borrower],[BorrowerDate],[Type]) VALUES (4,1,'Sciences Book','Lorem ipsum ', 433,'', 'true', 'Jone Doe','2021-05-10', 'Book')

SET IDENTITY_INSERT [dbo].[LibraryItems] OFF
Go
SET IDENTITY_INSERT [dbo].[Categories] ON
INSERT INTO [dbo].[Categories] ([Id], [CategoryName]) VALUES (1, 'Sciences')
INSERT INTO [dbo].[Categories] ([Id], [CategoryName]) VALUES (2, 'literature')
INSERT INTO [dbo].[Categories] ([Id], [CategoryName]) VALUES (3, 'Arts')



SET IDENTITY_INSERT [dbo].[Gategories] ON
GO
