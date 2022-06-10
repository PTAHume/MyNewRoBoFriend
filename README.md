<div id="top"></div>

<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://github.com/othneildrew/Best-README-Template">
    <img src="https://dev.azure.com/patrick-hume/_apis/GraphProfile/MemberAvatars/msa.YWViMmIzOWQtNTQyZS03MzljLWI2YjAtYjI5ZDhhMmEwMDMw?size=2&1654814734300" alt="Logo" width="80" height="80">
  </a>
  <p align="center">
    My RoBo Toy
  </p>
</div>

<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li><a href="#how-to-use">How To Use</a></li>
    <li><a href="#constraints">Constraints</a></li>
  </ol>
</details>

<!-- How To Use -->
## How To Use

* Run the RoBoFriend.exe
* Enter a command and press the enter key
* Start by placing the robo toy on the table  

Example PLACE Command syntax:
```sh
PLACE X Y ORIENTATION
```

Where X is the horizontal location that must be between 0 and 5  
Where Y is the vertical location that must be between 0 and 5  
Where ORIENTATION must be either:  

```sh
NORTH 
EAST 
SOUTH 
WEST
```
Example PLACE Command:
```sh
PLACE 1 2 SOUTH
```
Would place the robo on the table at grid reference 1 vertically and 2 horizontally facing NORTH  


The table grid starts at the bottom left (SOUTH WEST) hand side at 0 vertically and 0 horizontally  
and increases in increments of 1 along the vertical plane to the right (EAST) of the table  
or increases in increments of 1 along the horizonal plane to the top (NORTH) side of the table  

Illustration of the table layout:
```sh
5      N
4      |
3   W--o--E
2      |
1      S
0 1 2 3 4 5
```

Proceed to issue any of the following commands as many times and in any order, you like:

```sh
RIGHT
```
Will turn the robo 90° degrees so if the robo was facing NORTH if would then be facing EAST

```sh
LEFT
```
Will turn the robo 90° degrees so if the robo was facing NORTH if would then be facing WEST

```sh
MOVE
```
Will move the robo by 1 in the direction the robo is facing  
If the robo was facing NORTH it would increase along the horizontal alignment (Y axis) by 1
If the robo was facing EAST it would increase along the vertical alignment (X axis) by 1


```sh
REPORT
```
Will output the robo's current location and directional orientation  
Example:   
```sh
Output: 1, 1, North
```

You can even re-issue the PLACE command

Example (Can you guess where the robo will end up?):
```sh
PLACE 1 1 NORTH
MOVE
RIGHT
MOVE
MOVE
LEFT
REPORT
MOVE
PLACE 2 4 EAST
MOVE
REPORT
```

To turn your robo off and exit the applicating simply type:

```sh
END
```

Remember to press the Enter Key after typing each command
<p align="right">(<a href="#top">back to top</a>)</p>

<!-- Constraints -->
## Constraints

The commands do not need to be case sensitive but will be ignored if they have leading or trailing spaces  
Example (Note the trailing and leading spaces):   

* >  MOVE             

The robo cannot fall off the table, so any PLACE or MOVE command that would cause it to fall will simple be ignore 

Example 1:
```sh
PLACE 7 8 NORTH
```
Example 2:
```sh
PLACE 5 5 NORTH
MOVE
```
Would both put the robo outside the table area and thusly these commands are ignored.

If no command or an invalid command is issued the robo will ignore them  
The robo MUST be placed on the table first using the PLACE command first before any of command can be used!

Expected responses:

* > Please start by placing your Robo-Pet on the table, example: PLACE 0 0 NORTH  

You have tried to issue a command before placing the robo on the table first  
Example:
```sh
MOVE
```


* > Please give your Robo-Pet a command, example: PLACE 0 0 NORTH 

You have not given your robo a command
Example:
```sh

```

* > Please give your Robo-Pet a valid command with no spaces, example: PLACE 0 0 NORTH  

You have given your robo an invalid command so check the syntax matches the expected format
Example (Too many spaces):
```sh
PLACE   1    3    NORTH
```
Example (Leading space):
```sh
   MOVE
```

Example (Not a recognised command):
```sh
FOO 1 2 BAR  
```
<p align="right">(<a href="#top">back to top</a>)</p>
