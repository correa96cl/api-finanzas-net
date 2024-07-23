 CREATE TABLE netcore_cashflow.Expenses (
  Id INT AUTO_INCREMENT PRIMARY KEY,
  Title VARCHAR(500) NOT NULL,
  Description VARCHAR(1000),
  Date DATE NOT NULL,
  PaymentType INTEGER NOT NULL,
  Amount DECIMAL NOT NULL

);


COMMIT;


SELECT Id, Title, Description, `Date`, PaymentType, Amount
FROM netcore_cashflow.Expenses;