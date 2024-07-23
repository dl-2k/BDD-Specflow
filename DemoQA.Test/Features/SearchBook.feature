Feature: Search Book
  
  As a user
  I want to search book in collection

  @SearchBookInCollection
  Scenario Outline: Search for a book
    Given I navigate to the bookstore page
    When I enter "<keyword>" in the search bar
    Then I should see the search results containing "<keyword>"

    Examples:
      | keyword |
      | design  |
      | Design  |
