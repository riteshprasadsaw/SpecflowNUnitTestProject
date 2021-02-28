Feature: EcommerceCheckout
	In order to validate checkout functionality, user add two items and performs checkout opertion

@mytag1
Scenario: Perform checkout of two items
	Given user is on Ecommerce Login page
	And enters valid credentials
	| Username      | Password     |
	| standard_user | secret_sauce |
	And clicks on Login button
	Then user should be successfully logged in
	When user add two items to cart
	| product1            | product2					  |
	| Sauce Labs Backpack |  Sauce Labs Bike Light        |
	And verify the items and total
	And performs checkout
	And user add his details
	| firstname | lastname  | ZIP    |
	| TestUser  | Ecommerce | 700123 |
	Then user should see success purchase message
	When user clicks on logout link
	Then user should be successfully logged out from the application