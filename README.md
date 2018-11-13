# CucumberBankApp

## What is this?

This is a "test" application built with in C#.net Core that exists to determine whether the author can figure out how to code. It's whoever's reading this' job to judge. In my view, it's pretty dinky, but it does what was required. 

It is a web application which asks for a user's name and a number. It then leads to a page which contains the name and the number written out as the account balance.


## How to launch

### Linux

- cd to path/CucumberBankApp/
- open vscode
- download the .net core extensions
- press 'f5' - the page https://localhost:5001 should open automatically on your browser

Note: This is just for 'development mode' - production would require nginx or apache web servers. 


### Windows

I'm guessing (as I've done all of this in my linux machine), but if I had to guess....
- launch the sln file with Visual Studio 
- press 'f5' - the page https://localhost:5001 should open automatically on your browser

Note: This is just for 'development mode' - production would require configuration with the IIS web server.


## Design Choices

To rush through this - I basically used all of the same tools that the "Getting Started with .net Core on VSCode!" tutorials pointed me to. None of them were familiar to me.

On the backend side, a major design decision was to process the number as a string. This meant that the number can be almost as long as you like (actually, only to the 900 nonillions!) without running into int range issues.

I attempted to use a TDD (Test Driven Development) approach. An issue with this was that I had never used xunit before, but I found it very nice! Unfortunately as this ended up being too slow for my self-imposed deadline, I had to settle with fewer critical tests rather than a 100% test coverage suite that I would have preferred. 


### Some considerations before I'm judged too harshly:

- This was my first project in C# that I had started from scratch.
- This was done on a VERY underpowered 11" 2GB RAM laptop running Lubuntu. As such, compile times are.... not ideal.
- This was written in vscode, rather than a IDE. 

Thanks for checking this out!


-----

Authored by Adam Ron