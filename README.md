
# CodeChallange

You have three different tables
A Customer Table with FirstName, LastName, Age, Occupation, MartialStatus, PersonID

An Orders Table with OrderID, PersonID, DateCreated, MethodofPurchase

An Orders Details table with OrderID, OrderDetailID, ProductNumber, ProductID, ProductOrigin

Please return a result of the customers who ordered product ID = 1112222333 and return
FirstName and LastName as full name, age, orderid, datecreated, MethodOfPurchase as Purchase Method, ProductNumber and ProductOrigin

    select cus.FirstName + ' ' + cus.LastName as FullName,
		   cus.Age,
		   or.OrderId,
		   or.DateCreated,
		   or.MethodOfPurchase as PurchaseMethod,
		   det.ProductNumber,
		   det.ProductOrigin
    from Customer cus
    inner join Orders or on or.PersonId = cus.PersonId
    inner join OrdersDetails det on det.OrderId = or.OrderId
    where det.ProductId = 1112222333
