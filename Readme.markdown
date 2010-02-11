# FizzBuzz.Core.Tests 

## 7 concerns, 13 contexts, 21 specifications 

* * *

* * *

## Controller specifications 

### 1 context, 3 specifications 

### When the list of evaluated numbers is written 

#### 3 specifications 

*   should process every number from the number source 
*   should evaluate every number 
*   should output the evaluated message for each number 

## DefaultRule specifications 

### 1 context, 1 specification 

### When the default rule is evaluated with any number 

#### 1 specification 

*   should yield the number formatted as a string 

## DefaultRuleEvaluator specifications 

### 1 context, 7 specifications 

### When a number is evaluated 

#### 7 specifications 

*   should evaluate the first rule 
*   should evaluate the second rule 
*   should evaluate the third rule 
*   should evaluate the fourth rule 
*   should evaluate the fourth rule with the number to be evaluated 
*   should evaluate the fourth rule once 
*   should yield the last rule evaluation result that is unequal to null 

## DivisibleByFive specifications 

### 2 contexts, 2 specifications 

### When the number is divisible by five 

#### 1 specification 

*   should yield "buzz"  

### When the number is not divisible by five 

#### 1 specification 

*   should yield null 

## DivisibleByThree specifications 

### 2 contexts, 2 specifications 

### When the number is divisible by three 

#### 1 specification 

*   should return fizz 

### When the number is not divisible by three 

#### 1 specification 

*   should return null 

## DivisibleByThreeAndFive specifications 

### 2 contexts, 2 specifications 

### When the number is divisible by three and five 

#### 1 specification 

*   should yield "fizzbuzz"  

### When the number is not divisible by three and five 

#### 1 specification 

*   should yield null 

## NumberSource specifications 

### 4 contexts, 4 specifications 

### When the first number is generated 

#### 1 specification 

*   should be the equal to one 

### When the last number is generated 

#### 1 specification 

*   should be equal to one hundred 

### When the number source is generated 

#### 1 specification 

*   should be enumerable 

### When the second number is generated 

#### 1 specification 

*   should be the equal to two 

* * *