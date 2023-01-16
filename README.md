# SodukoSolver - Ohad Shafir

Hi and welcome to my sudoku solver project in C#.

## Information about the project

The project was developed in visual studios 2022 and uses 6.0 .NET version.

### How to use
When running the project the opening screen will be displayed:

![image](https://user-images.githubusercontent.com/117098182/212695555-4424304e-aff9-4d2c-a73e-56d278b73a7a.png)

After a key is pressed the app displays a menu of input/output formats.
1.via console
2.via files
If **console (1)** option is chosen then the following screen is displayed:

![image](https://user-images.githubusercontent.com/117098182/212696618-a7029be0-be07-44bc-bcaf-09327308e843.png)

Any sudoku board inserted is solved and the answer is displayed to screen in string and graphical formats.
For example:

![image](https://user-images.githubusercontent.com/117098182/212697568-3bdbdfab-b7d2-430d-97c2-9a8334bc2ebd.png)

To exit or change input\output format enter the values specified.
If **File (2)** option is chosen then the following screen is displayed:

![image](https://user-images.githubusercontent.com/117098182/212698047-0c4076d9-963a-4a8c-a419-5dcd998ea429.png)

The path of the input file (legal path) will be set as the input file and the application will ask whether to return the solved grid to the same file or to a diffrent one.
If the same file was chosen the program will proceed.
If a diffrent file was chosen the following screen will be displayed:

![image](https://user-images.githubusercontent.com/117098182/212698817-46e89803-d067-4d8a-9c5c-f6670895abcd.png)

After the output file path is inserted the app asks to enter and save the sudoku grid in string format in the input file and press enter to recieve the result in the output file.
The solved grid is displayed to screen as well.


![image](https://user-images.githubusercontent.com/117098182/212699486-953e0986-6f29-4f5b-a723-1796d908a30b.png)

Input file: 

![image](https://user-images.githubusercontent.com/117098182/212699592-273fd4f1-ef69-4350-8803-def70c2ee6ee.png)

Output file:

![image](https://user-images.githubusercontent.com/117098182/212699709-1ba0f0cc-b26a-42dc-a36b-36dbe576e829.png)

From this point the user can enter more grids change the format or exit the application.

### Theoretical information

#### DancingLinks and AlgorithmX
Dancing Links is an algorithm by professor Donald Knuth of Stannford university to solve exact cover problems (also called Algorithm X). An exact cover problem's definition is: given a matrix of ones and zeros, select a subset S
 of the rows so that each column has exactly one 1
 when looking at just the rows S.
 Example:
 
 ![image](https://user-images.githubusercontent.com/117098182/212702168-6bfe0816-0c2b-4096-85b3-5003faa7ce81.png)
 
 in this case the 1st, 4th and 5th rows fulfills the request.
 
 The genius in Knuth's way of solving this problem is using the "Dancing Links" matrix data structure.
 
Each 1 in the exact cover matrix is represented by a node of linked list and the whole matrix is transformed into a mesh of 4 way connected nodes. Each node contains following fields:
-Pointer to node left to it.
-Pointer to node right to it.
-Pointer to node above it.
-Pointer to node below it.
-Pointer to list header node to which it belongs.
Each row of the matrix is thus a circular linked list linked to each other with left and right pointers and each column of the matrix will also be circular linked list linked to each above with up and down pointer. Each column list also includes a special node called “list header node”. This header node is just like simple node but have few extra fields.

The previous 1 and 0 matrix as a dancing links matrix:

![image](https://user-images.githubusercontent.com/117098182/212704346-d9ee3129-4e87-42e1-b49c-0a7c3908d782.png)

On this DLX matrix the Algorithm X is operated.
The algorithm tries to remove columns and all the rows to which nodes of that column belongs to. This process is here referred as covering of node. To remove a column we can simply unlink header of that column from neighboring headers. This way this column cannot be accessed. This process is similar to removal of node from doubly linked list. It is done to find a subsets of rows that fulfill the exact cover standart.
If the algorithm reaches a dead end and no solution is possible in that case algorithm have to backtrack. Because we have removed columns and rows when we backtrack we have link again those removed rows and columns. This is what we are calling uncovering. Notice that the removed nodes still have pointers to their neighbors, so we can link them back again using these pointers.
#### The relation to sudoku
A sudoku puzzle answers to the definition of the exact cover problem. 
There are 4 constraints that a sudoku grid has to fulfill to be legal.
1. In each cell there is only one value (number)
2. In each row each value appears only once.
3. In each column each value appears only once.
4. In each box each value appears only once.

With this four constraints My application builds a (size x size x number of values) on (size x size x number of constraints) matrix that will represent the exact cover problem. Each cell has to fullfill all 4 constraints, so a proper value that fulfills all tis constraints is chosen for it.
This matrix is converted to DLX list and the algorithm X is operated on it.
Algorithm X will return a solution to the grid, otherwise the grid is unsolvable.

## Classes and Modules in my project.

 ### IO:
This module is in charge of input and output of my application.

Class ApplicationGeneralMessagesPrinter is in charge of displaying general messages to user.

Class ConsoleReader is in charge of reading data related to sudoku grid from console.

Class ConsoleWriter is in charge of writing to console information related to sudoku grid.

Class FileReader is in charge of reading from file information related to sudoku grid.

Class FileWriter is in charge of writing to file solved sudoku grid.

Class InputHandler is in charge of initializing the Reader object according to the grid reception formate chosen by the user.

Interface Ireadable demands the class implemeting it being able to read data.

Interface Iwriteable demands the class implemeting it being able to write data.

Class OutputHandler is in charge of initializing the Writer object according to the grid reception formate chosen by the user.

Class Reader is in charge of reading sudoku grids related information.

Class Writer is in charge of writing sudoku grids related information.

### Algorithm:
This module is in charge of the solving of grids.
 
Class Solver is in charge of solving the sudoku grid.
 
### DataStructures:
This module is in charge of the diffrent data structures the projects includes.
 
Class ColumnNode models a column node in the dlx matrix.

Class CoverMatrix models a cover matrix which will afterwards be transformed to a dlx matrix.

Class DancingNode models a node in the dlx matrix.

Class DLXList models a dlx cover matrix.

Class Grid models a sudoku grid.
 
### Exceptions:
This module is in charge of the diffrent exceptions which could be irrupted while running.
 
Class CharNotValidException represents the CharNotValid exception.

Class DimensionsOfBoardNotValidException represents the DimensionsOfBoardNotValid exception.

Class ExceptionsHandler is in charge of functions related to exceptions.

Class GridNotValidException represents the GridNotValid exception.

Class GridUnsolveableException represents the GridUnsolveable exception.

### Parsers:
This module is in charge of converting diffrent types of grid representations to other ones.

Class Parser is in charge of parsing the various representations of the grid to other representations.

### Timer:
This module is in charge of runtime management and displaying.

Class Timer is in charge of showing the runtime of the solution.

### Validations:
This module is in charge of validating sudoku grids and check if exceptions should be thrown.

Class Validator is in charge of validations related to the application.

### Global Items:
This collection of items are used to connect all parts of the project to one unit.

Class Config is in charge of saving constants for printing or general information.

Class Program is the entry point to my application and in charge of combining all classes, functions and modules into a working program.

### Tests:
Classes Tests and Usings are part of the test interface and ables me to assure my project works.


## Thats it I Hope have a great time using my project!!!

![image](https://user-images.githubusercontent.com/117098182/212712815-e510fffb-19ff-4af3-9d4a-c9374aa6d359.png)

 


