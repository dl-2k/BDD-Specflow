Feature: DeleteBook
 
 In order to manage my book collection
  As a user
  I want to delete a book from my bookstore

@DeleteBookFromCollection
Scenario: Delete a book from the bookstore
	Given User already Add Book into book collection 
		| UserDataKey  | BookDataKey |
		| user_account | books3      |
	Given I navigate to the login page
	When I login into system with "user_account" data
	And I search for the book "Git Pocket Guide"
	And I delete the book "Git Pocket Guide"
	Then the book "Git Pocket Guide" should be deleted successfully



