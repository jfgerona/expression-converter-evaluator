# Expression Converter and Evaluator

A C# console application that reads mathematical expressions from a CSV file, converts them from **infix** notation to **prefix** and **postfix**, evaluates both using **expression trees**, compares the results, and generates an **XML summary report**.

## Overview

This project was built for **INFO 5101** and focuses on expression parsing, conversion, evaluation, file handling, and XML generation. The application loads infix expressions from a CSV file, performs both prefix and postfix conversions, evaluates each converted expression, checks that both evaluation results match, and outputs the final data to both the console and an XML file. :contentReference[oaicite:0]{index=0} :contentReference[oaicite:1]{index=1}

## Features

- Deserialize infix expressions from a CSV file into a C# list
- Convert infix expressions to prefix notation
- Convert infix expressions to postfix notation
- Evaluate prefix expressions using expression trees
- Evaluate postfix expressions using expression trees
- Compare prefix and postfix evaluation results using `IComparer`
- Generate an XML output file with expression details and results
- Display conversion and evaluation results in the console
- Produce a summary report for all expressions processed

These were the main functional requirements of the assignment. :contentReference[oaicite:2]{index=2} :contentReference[oaicite:3]{index=3}

## Input Data

The project uses a CSV source file containing numbered infix expressions under the columns `sno` and `infix`. The provided dataset includes 25 expressions ranging from simple arithmetic like `5+4` and `8/2` to more complex expressions with parentheses such as `(7-3)*9+6` and `(7+9+6)*5-(2*2)`. :contentReference[oaicite:4]{index=4}

## How It Works

1. The program reads the CSV input file into a list.
2. Each infix expression is converted into:
   - prefix notation
   - postfix notation
3. Both converted expressions are evaluated using expression trees.
4. The prefix and postfix results are compared to confirm they match.
5. The application prints intermediate and summary results to the console.
6. An XML file is generated containing:
   - serial number
   - infix expression
   - prefix expression
   - postfix expression
   - evaluation result
   - comparison result

The required XML structure includes `<root>` with repeated `<elements>` entries containing `sno`, `infix`, `prefix`, `postfix`, `evaluation`, and `comparison`. :contentReference[oaicite:5]{index=5} :contentReference[oaicite:6]{index=6}

## Project Structure

Suggested classes from the project requirements include:

- `CSVFile`
  - Handles CSV deserialization into a list
- conversion classes
  - Separate public classes for infix-to-prefix and infix-to-postfix conversion
- `ExpressionEvaluation`
  - Handles evaluation using expression trees
- `CompareExpressions`
  - Implements `IComparer` to compare evaluation results
- `XMLExtension`
  - Contains extension methods for writing the XML output
- `Data`
  - Stores the source CSV file and generated XML file

The assignment also required each class to be placed in its own separate `.cs` file and to use a `Data` folder for the source and output files. :contentReference[oaicite:7]{index=7}

## Technologies Used

- C#
- .NET
- Visual Studio
- Expression Trees
- CSV file processing
- XML generation
- Console application development

The project brief specifically states that Visual Studio and .NET tools may be used for the application. :contentReference[oaicite:8]{index=8}

## Sample Output

The program produces:
- console output after each conversion and evaluation step
- a final summary report
- an XML file containing the processed expressions and results

The project brief includes a sample summary report and a sample XML output format. :contentReference[oaicite:9]{index=9}

## What I Learned

This project helped me practice:

- parsing and processing mathematical expressions
- converting between infix, prefix, and postfix notation
- building and using expression trees
- comparing computed results programmatically
- reading structured input from CSV files
- generating XML using extension methods
- organizing a C# project into focused classes

## How to Run

1. Open the solution in **Visual Studio**
2. Make sure the CSV file is inside the `Data` folder
3. Build and run the application
4. View the console output for:
   - infix to prefix conversion
   - infix to postfix conversion
   - expression evaluation
   - result comparison
5. Check the generated XML file in the `Data` folder

## Notes

- The source CSV file should not be modified.
- The text file included with the assignment is only for reference and is not used by the application.
- The application was expected to prompt the user to open the generated XML file in a web browser after showing the console summary. :contentReference[oaicite:10]{index=10}

## Why I Included This in My Portfolio

I included this project in my portfolio because it shows my ability to work with core programming concepts such as data structures, parsing logic, expression evaluation, file input/output, XML generation, and clean class design in C#. It also demonstrates problem-solving with multiple processing steps and result validation.

## Repository Name Suggestion

`expression-converter-evaluator`

## Suggested Repository Description

`C# console app that converts infix expressions to prefix and postfix, evaluates them with expression trees, compares results, and generates XML output.`
