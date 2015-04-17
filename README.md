# HX-Main
Hyper Extensions contains LINQ-like extensions to multidimensional arrays.

## Portability
 - Portable Class Library which provides support for .NET Framework 4, Silverlight 5, Windows 8, Windows Phone 8.1, Windows Phone Silverlight 8
 - Common Language Specification compliant code

## Code Quality
 - Passes Microsoft Managed Recommended Rules without any warnings
 - Passes Code Contracts static checking without any warnings at high level
 - All public members and parameters are documented

## Examples

Matrix addition:
```C#
double[,] A = ..., B = ...;

double[,] sum = A.Combine(B, (x, y) => x + y);
```

Summing all numbers in a matrix:
```C#
int[,] data = new int[,] { ... };
int sum = data.AsEnumerable().Sum();
```

Matrix scalar multiplication:
```C#
double[,] A = ...;
double c  = ...;

double[,] product = A.Map(e => c * e);
```

Matrix multiplication:
```C#
double[,] A = ..., B = ...;

double[,] product = A.CrossJoin(B, (x, y) => x * y, r => r.Sum());
```

Scaling down images to 50%:
```C#
int[,] pixels = ...;

int[,] scaledTo50 = pixels.Split(2, 2).Map(e => (int)e.AsEnumerable().Average());
```

Checking a sudoku solution:
```C#
int[,] puzzle = ...;

bool isSolution =
	// rows
	puzzle.AsRows()

	// columns
	.Union(puzzle.AsColumns())

	// regions
	.Union(puzzle.Split(3, 3).AsEnumerable().Select(e => e.To1DArray()))

	// check all
	.All(g => Enumerable.Range(1, 9).All(e => g.Contains(e)))
;
```
