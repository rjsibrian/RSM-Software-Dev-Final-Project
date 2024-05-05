# RSM-Software-Dev-Final-Project

## Client Instalation
npm i -g @quasar/cli ----> Run this in the terminal of your system to install de quasar client
npm i ----> Run this in the terminal of the quasar project (RSM-Software-Dev-Final-Project\client\quasar-project) to install dependencies
quasar dev ----> Run this to start the client

## Server Instalation
dotnet run ----> Run this in the terminal of the server project (RSM-Software-Dev-Final-Project\server)

## Requirements
Node.js has to be installed in order to run the quasar project.
.Net has to be installed in order to run the server project.

## Additional Requirements
The models of the API were mapped to database views, so you have to create the views in your database. These are the scripts to create the views:

## Create SaleSummaryView
CREATE VIEW SaleSummaryView
AS
SELECT
CAST(ROW_NUMBER() OVER (ORDER BY soh.SalesOrderID ASC) AS INT) AS Id,
soh.SalesOrderID 'OrderID', CAST(soh.OrderDate AS date) 'OrderDate', sod.ProductID, p.Name 'ProductName', pc.Name 'ProductCategory',
sod.UnitPrice, sod.OrderQty, sod.LineTotal, soh.SalesPersonID, CONCAT(Per.FirstName, ' ', Per.LastName) 'SalesPersonName',
CONCAT(sa.AddressLine1, ', ', sa.City) 'ShippingAddress',
CONCAT(ba.AddressLine1, ', ', ba.City) 'BillingAddress'
FROM Sales.SalesOrderHeader soh
INNER JOIN
	Sales.SalesOrderDetail sod ON soh.SalesOrderID = sod.SalesOrderID 
INNER JOIN
	Production.Product p ON sod.ProductID = p.ProductID 
INNER JOIN
	Production.ProductSubcategory psc ON p.ProductSubCategoryID = psc.ProductSubcategoryID
INNER JOIN
	Production.ProductCategory pc ON psc.ProductCategoryID = pc.ProductCategoryID
INNER JOIN
	Sales.SalesPerson sp ON soh.SalesPersonID = sp.BusinessEntityID
INNER JOIN
	Person.Person per ON sp.BusinessEntityID = per.BusinessEntityID
INNER JOIN
	Person.Address ba ON soh.BillToAddressID = ba.AddressID
INNER JOIN 
	Person.Address sa ON soh.ShipToAddressID = sa.AddressID;

## Create SalePerformanceView
CREATE VIEW SalePerformanceView
AS
WITH TotalSalesCTE
AS
(
    SELECT 
        st.TerritoryID, 
        st.Name AS 'RegionName', 
        pc.ProductCategoryID, 
        pc.Name AS 'CategoryName', 
        SUM(SUM(sod.LineTotal)) OVER(PARTITION BY st.TerritoryID) AS 'TotalSalesInRegion',
        SUM(sod.LineTotal) AS 'TotalCategorySalesInRegion'
    FROM 
        sales.SalesOrderDetail sod
    INNER JOIN 
        sales.SalesOrderHeader soh ON soh.SalesOrderID = sod.SalesOrderID
    INNER JOIN 
        sales.SalesTerritory st ON st.TerritoryID = soh.TerritoryID
    INNER JOIN 
        production.product p ON p.ProductID = sod.ProductID
    INNER JOIN 
        production.ProductSubcategory ps ON ps.ProductSubcategoryID = p.ProductSubcategoryID
    INNER JOIN 
        production.ProductCategory pc ON pc.ProductCategoryID = ps.ProductCategoryID
    GROUP BY 
        st.TerritoryID, st.Name, pc.ProductCategoryID, pc.Name
)
SELECT 
    CAST(ROW_NUMBER() OVER (ORDER BY s.PercentageOfTotalCategorySalesInRegion DESC) AS INT) AS Id,
    s.ProductName, 
    s.ProductCategory, 
    s.TotalSales,
    s.PercentageOfTotalSalesInRegion,
    s.PercentageOfTotalCategorySalesInRegion
FROM 
(
    SELECT TOP 10
        p.Name AS 'ProductName', 
        pc.Name AS 'ProductCategory', 
        sod.LineTotal AS 'TotalSales',
        CONVERT(decimal(10,2),ROUND((sod.LineTotal*100)/tsCTE.TotalSalesInRegion,2)) AS 'PercentageOfTotalSalesInRegion',
        CONVERT(decimal(10,2),ROUND((sod.LineTotal*100)/tsCTE.TotalCategorySalesInRegion,2)) AS 'PercentageOfTotalCategorySalesInRegion'
    FROM 
        sales.SalesOrderDetail sod
    INNER JOIN 
        sales.SalesOrderHeader soh ON soh.SalesOrderID = sod.SalesOrderID
    INNER JOIN 
        production.product p ON p.ProductID = sod.ProductID
    INNER JOIN 
        production.ProductSubcategory ps ON ps.ProductSubcategoryID = p.ProductSubcategoryID
    INNER JOIN 
        production.ProductCategory pc ON pc.ProductCategoryID = ps.ProductCategoryID
    INNER JOIN 
        sales.SalesTerritory st ON st.TerritoryID = soh.TerritoryID
    INNER JOIN 
        TotalSalesCTE tsCTE ON tsCTE.TerritoryID = st.TerritoryID AND tsCTE.CategoryName = pc.Name
) s;
