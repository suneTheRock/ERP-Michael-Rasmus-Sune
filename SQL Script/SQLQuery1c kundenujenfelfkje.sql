use H1PD021122_Gruppe2;

SELECT customers.customerID, 
	customers.lastOrder, 
	Persons.personID, 
	Persons.firstName,
	Persons.lastName,
	Persons.email,
	Persons.phone,
	Adress.adressID,
	Adress.street,
	Adress.streetNumber,
	Adress.city,
	Adress.zipCode,
	ContactInfos.contactInfoID,
	ContactInfos.value_
	FROM [H1PD021122_Gruppe2].[dbo].[Customers]
                JOIN [H1PD021122_Gruppe2].[dbo].[Persons] 
                ON Customers.person_ID = Persons.personID    
                JOIN [H1PD021122_Gruppe2].[dbo].[Adress]
                ON Customers.Adress_ID = Adress.adressID
                JOIN [H1PD021122_Gruppe2].[dbo].[ContactInfos]
                ON Customers.contactInfo_ID = ContactInfos.contactInfoID

				WHERE Customers.customerID = 2

