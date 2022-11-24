#  Poker Hand Showdown Assessment Solution
C# Library to find Winner in a poker game.

//
/*
  Name :- Jagroop Singh
  Date :- 23 Nov 2022
  Assumptions:-
  1. For Three of A kind Case assume we found no winner for is four of a Kind.
  2. For One Pair Case assume we found no winner for two of a Kind and there is only one pair of cards with same faces.

  HOW TO RUN :- 
  Project in VS Code and write the following in Terminal
  dotnet run
  TODO :-
  Refine the Main
*/

## Link to site
(https://r97draco.github.io/library-manager/)


## Libraries required
1. [NET SDK armx64](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-7.0.100-macos-arm64-installer)

## How to start
1. Clone or download the project.
2. Dowload [NET SDK armx64](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-7.0.100-macos-arm64-installer).
3. Go to the project and type following in Terminal
<br>```dotnet run```

## Basic Gist of the Algorithm :-
Create Players and assign their cards.<br/>
Check flush. continue if no winner found.<br/>
check three of a kind? continue if no winner found<br/>
check One pain. continue if no winner found at last we check Hishest card and resolve the Ties.<br/>
