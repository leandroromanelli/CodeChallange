select c.FirstName + ' ' + c.LastName as FullName,
	   c.Age,
	   o.OrderId,
	   o.DateCreated,
	   o.MethodOfPurchase as PurchaseMethod,
	   od.ProductNumber,
	   od.ProductOrigin
from Customer c
inner join Orders o on o.PersonId = c.PersonId
inner join OrdersDetails od on od.OrderId = o.OrderId
where od.ProductId = 1112222333
