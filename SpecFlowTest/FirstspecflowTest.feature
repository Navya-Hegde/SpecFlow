Feature: FirstspecflowTest
	Simple calculator for adding two numbers

@mytag
Scenario Outline: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

@mytag @Integration @Regression
Scenario Outline: Addion of two numbers 
	Given the first number is <input1>
	And the second number is <input2>
	When the two numbers are added
	Then the result should be <sum>

Examples: 
| input1 | input2 | sum |
| 50     | 70     | 120 |
| 10     | 10     | 20  |

@mytag @Integration @Regression
Scenario Outline: subtraction of two numbers 
	Given the first number is <input1>
	And the second number is <input2>
	When the two numbers are subtraction
	Then the result should be <sub>

Examples: 
| input1 | input2 | sub |
| 70     | 50     | 20 |
| 10     | 10     | 0  |

@multiplication
Scenario Outline: multiplication of two numbers 
	Given the first number is <input1>
	And the second number is <input2>
	When the two numbers are multiplied
	Then the result should be <mul>

Examples: 
| input1 | input2 | mul |
| 10     | 20     | 200 |
| 20     | 5      | 100 |

@Division
Scenario Outline: Division of two numbers 
	Given the first number is <input1>
	And the second number is <input2>
	When the two numbers are divided
	Then the result should be <div>

Examples: 
| input1 | input2 | div | 
| 100    | 20     | 5	|
| 20     | 5      | 4   |