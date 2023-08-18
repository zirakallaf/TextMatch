# TextMatch
TextMatch is an ASP.NET MVC project for demonstration purposes .net Core 7.0.x, and it is written in C#. This project intends to be a string manipulation project to deliver searching text in a paragraph or any piece of string. Currently, only a text match algorithm is implemented to find the frequency of a given substring in a text/paragraph. In addition, a test-driven CI/CD pipeline has been implemented in github using GitHub actions. Further, an NUnit test project was added to the solution to protect the text match algorithm from breaking down if we need to extend it in the future.

## to run the project, you can use Visual Studio (VS) 2022 or VSCode
  1. clone the repository
  2. run the project by pressing `F5` or by typing `dotnet run`. Note, if you intend to use VSCode, make sure that you are in the root directory of the project.
  3. to run the test, you can run the following command, which is the very basic command:
     ```sh
      dotnet test
     ```
