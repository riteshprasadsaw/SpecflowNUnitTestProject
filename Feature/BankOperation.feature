Feature: BankOperation
	Verify customer's deposit and withdrawal and customer record addition by Manager

@mytag
Scenario: Perform bank deposit and withdrawal operation
	Given customer is on Bank Login page
	And customer enters valid credentials
	| Username      | Password     |
	| standard_user | secret_sauce |
	And clicks the Login button
	Then customer should be successfully logged in
	When customer deposits an amount
	And verify the balance
	Then correct bank balance should be displayed
	When customer withdraws an amount
	And verify the balance
	Then correct bank balance should be displayed
	When customer clicks on logout link
	Then customer should be successfully logged out from the application
	When manager enters valid credentials
	| Username      | Password     |
	| standard_user | secret_sauce |
	And clicks the Login button
	Then manager should be successfully logged in
	And searches for the customer
	And adds the customer
	| firstname | lastname  | ZIP    |
	| TestUser  | Ecommerce | 700123 |
	Then correct details should be added
	When customer clicks on logout link
	Then customer should be successfully logged out from the application