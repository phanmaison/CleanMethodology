# Summary
A methodology to implement Clean Architecture

`Methodology` is `a particular procedure or set of procedures to do something` or we may repharse it as `step by step actions to do something`.

# Overview
Ask yourself this question: `what is your methodology to develop a new feature?` (or what are your activities to develop a new feature).
There are something popup in your mind, right? It can be:
- Analyze the requirement
- Design the database schema
- Design the UI / create new endpoint
- Create models
- Implement business logic
- Implement persistence
- Unit test
- Documentation
- Create Pull Request and Review Code
- ..

(if you commit regularly, you may look at history to find out)

Typically, developer use bottom-up approach. Starting from small blocks and then gather them together to build the feature.

However, the other project's stakeholders use top-down approach. They start from the big picture and then break it down into smaller functionalities called `UseCase`.

# Expectation
But before that, let define some expectations. There are many ways to write code, a lot of architectures out there. But, there are common things:
- Code is easy to read and understand
- Code is easy to maintain and bug-fix
- Code is easy to extend

# Detail implementation

![Clean architecture](https://blog.cleancoder.com/uncle-bob/images/2012-08-13-the-clean-architecture/CleanArchitecture.jpg)

The `UseCase` is the starting point, it represents the business logic and a domain and it maps directly to business requirement.


Let, e.g. Create User.

Step 1: create use-case class
- Create a new usecase class named `UserCreateUsecase`
- Add a method `ExecuteAsync` to the class
- Comment the business logic need to be implemented

Step 2: define input and output model

Step 3-onward: implement actions in the business logic

Result:
- Usecase is the heart of the application, it represents the business logic and a domain

Benefits:
- Easy to read and understand
- Easy to maintain and bug-fix
- Easy to extend
- Easy to test

# Conclusion
TODO