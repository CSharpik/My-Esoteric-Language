This is an interpreter for my esoteric language;
It was written on C#, but, in future,
  I'm going to write interpreter on pure C;
It's the ideological successor of the Brainf*ck language;
But commands and coding style are different;

On start you have this:
  1) There is 5000 cells;
	2) Size of cell is two bytes;
	3) Cells can contain numbers from -32768 to 32767;
  4) Current cell is 0;
	5) Current INTERRUPT command number is 0;

Commands:
  1) / - Increments number of INTERRUPT command;
  2) \ - Decrements this number;
  3) . (point) - Calls current number INTERRUPT command;
  4) * (star, multiplie symbol) - Analogue of Brainf*ck's command "[";
  5) & (ampersand) - Analogue of Brainf*ck's command "]";

INTERRUPTs:
  0) Prints current cell's value;
  1) Incremets current cells's value;

  -1) Decrements it;
  2) Increments number of current cell;
  
  -2) Decrements it;
  3) Reads from console number and pushes to current cell;
  
  -3) Prints word "TERMINATED" and closes interpreter program; 
