# New Suits System

A Windows desktop app for a **suit shop**: manage products, sell or rent suits, print invoices and view order reports. Built with C# Windows Forms and SQL Server.

## Features

- Login screen
- Add products, list products and generate barcodes
- Sell suits and rent suits, with order and invoice printing (Crystal Reports)
- Search orders by id, product or date
- Daily report
- Three layers: `PL` (forms), `BL` (business logic), `DAL` (data access with stored procedures)

## Tech stack

C#, .NET Framework Windows Forms, ADO.NET (SQL Server), Crystal Reports.

## Getting started

1. Open `new_suits_system.sln` in Visual Studio on Windows.
2. Attach the included `new_suits_system.mdf` to SQL Server (the data access layer connects to the `new_suits_system` database on the local server `.\`) and adjust the connection string in `DAL/DataAccessLayer.cs` if needed.
3. Build and run.
