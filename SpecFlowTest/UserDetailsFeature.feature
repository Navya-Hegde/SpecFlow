Feature: UserDetailsFeature
	Testing User Details

@Get
Scenario Outline: Run  userdetails getuserbyid
	Given I want run Userdetail api and id is <id>
	When  I execute userdetail api
	Then I should get returnCode as <returnCode>
	And verify userdetail data with given inputs name is <name> and email is <email> and country is <country>

	Examples:
		| id | returnCode | name  | email                 | country |
		| 1  | 200        | Navya | navya.hegde@gmail.com | India   |
		| 10 | 400        |       |                       |         |

@Post
Scenario Outline: Add UserDetails
	Given I want run Userdetail api and id is <id>
	And name is <name>
	And email is <email>
	And country is <country>
	When  I execute add userdetail api
	Then I should get returnCode as <returnCode>
	And verify userdetail data with given inputs name is <name> and email is <email> and country is <country>

	Examples:
		| id | returnCode | name  | email                 | country |
		| 4  | 201        | Vinay | vinay.hegde@gmail.com | India   |

@Put
Scenario Outline: update UserDetails
	Given I want run Userdetail api and id is <id>
	And update name is <name>
	And update email is <email>
	And update country is <country>
	When  I execute update userdetail api
	Then I should get returnCode as <returnCode>
	And verify userdetail data with given inputs name is <name> and email is <email> and country is <country>

	Examples:
		| id | returnCode | name    | email                   | country |
		| 4  | 201        | Shripad | shripad.hegde@gmail.com | India   |

@Delete
Scenario Outline: delete UserDetails
	Given I want run Userdetail api and id is <id>
	When  I execute delete userdetail api
	Then I should get returnCode as <returnCode>

	Examples:
		| id | returnCode |
		| 4  | 204        |
		| 10 | 400        |