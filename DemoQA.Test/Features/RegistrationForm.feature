Feature: User Registration  
  
  As a user
  I want to fill all fields of Registration Form

@FillRegistartionForm
  Scenario: Successful registration with mandatory fields
    Given I have opened the registration form
    When I fill in the registration form with the following data
      | Field          | Value                   |
      | FirstName      | John                    |
      | LastName       | Doe                     |
      | Email          | john.doe@example.com    |
      | DateOfBirth    | 10 Jun 2024             |
      | MobilePhone    | 1234567890              |
      | Subject        | Maths                   |
      | Gender         | Male                    |
      | Hobbies        | Reading                 |
      | Picture        | Image\yeucau.png        |
      | CurrentAddress | 123 Main St             |
      | State          | NCR                     |
      | City           | Delhi                   |
    Then I should see the thank you message
    And the form submission should match the expected data
