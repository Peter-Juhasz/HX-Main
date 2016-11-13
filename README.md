# Science.Collections.MultiDimensional.Linq
LINQ-style operators for manipulating multidimensional arrays supporting **.NET Standard 1.6**.

```
Install-Package Science.Collections.MultiDimensional.Linq -Pre
```

## Examples

Matrix addition of two arrays ```double[,] A, B```:
```C#
double[,] sum = A.Combine(B, (x, y) => x + y);
```

Matrix scalar multiplication of ```double c``` and ```double[,] M```:
```C#
double[,] product = M.Map(e => c * e);
```

Summing all numbers in a matrix ```int[,] data```:
```C#
int sum = data.AsEnumerable().Sum();
```

Matrix multiplication of ```double[,] A, B```:
```C#
double[,] product = A.CrossJoin(B, (x, y) => x * y, r => r.Sum());
```

Scaling down an array of pixels ```int[,] pixels``` to 50%:
```C#
int[,] scaledTo50 = pixels.Split(2, 2).Map(e => (int)e.AsEnumerable().Average());
```

Checking a sudoku solution represented as ```int[,] puzzle```:
```C#
bool correct =
	(puzzle.AsRows()) // rows
		.Union
	(puzzle.AsColumns()) // columns
		.Union
	(puzzle.Split(3, 3).AsEnumerable().Select(e => e.To1DArray())) // 3x3 regions

	// check
	.All(g => Enumerable.Range(1, 9).All(e => g.Contains(e)));
```

## Portability
 - .NET Standard 1.6
 - Common Language Specification compliant code

## Code Quality
 - Passes Microsoft Managed Recommended Rules without any warnings
 - Passes Code Contracts static checking without any warnings at high level
 - All public members and parameters are documented
