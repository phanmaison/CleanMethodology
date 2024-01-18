# Summary
A methodology to implement Clean Architecture

# Methodology
`Methodology` is `a particular procedure or set of procedures to do something` or we may repharse it as `step by step actions to do something`.

# Overview
We all have habit, it can be good or bad. Ask yourself this question: `what is your methodology to develop a new feature?` (or what are your activities to develop a new feature).
Try to answer the question. There are something popup in your mind, right? It can be:
- Analyze the requirement
- Design the UI / create new endpoint
- Create models
- Implement business logic
- Implement persistence
- Unit test
- Documentation
- Create Pull Request and Review Code
- ..

(if you commit regularly, you may look at history to find out)

It's not right or wrong, everyone has their own methodology. Some are bad and some are good.

Here I will introduce a methodology.

# Expectation
But before that, let define some expectations. There are many ways to write code, a lot of architectures out there. But, there are common things:
- Code is easy to read and understand
- Code is easy to maintain and bug-fix
- Code is easy to extend

# Detail implementation

The business analysis use top-down approach and break down the specification into use-cases already.

So let start from the use-case, e.g. Create User.

Step 1: create use-case class
- Create a new usecase class named `UserCreateUsecase`
- Add a method `ExecuteAsync` to the class
- Comment the business logic need to be implemented

Step 2: create input and output model

Step 3-onward: implement actions in the business logic

Result:
- Usecase is the heart of the application, it represents the business logic and a domain

Benefits:
- Easy to read and understand
- Easy to maintain and bug-fix
- Easy to extend
- Easy to test

# Conclusion
This example may help you to understand Clean Architecture and how to implement it. But it's not the only way to implement it.