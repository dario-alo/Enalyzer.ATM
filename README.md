# Enalyzer.ATM

Create a web application that can simulate a withdrawal of cash from an ATM. The program will pay 
the least possible number of notes / coins.

Example:
I want to withdraw 578 pounds. The program specifies that I must be paid: NOTES: 1x500-1X50 -
COINS: 1x20-1x5-1x2-1x1

The program must pay in 3 boxes: Notes, Coins with a diameter greater than 20mm, coins with 
diameter less than or equal to 20mm.

The following money types should be available:
- 1,000 note
- 500 note
- 200 note
- 100 note
- 50 note
- 20 coin (40 mm)
- 10 coin (20 mm)
- 5 coin (50 mm)
- 2 coin (30 mm)
- 1 coin (10 mm)

It should be easy to add a new type of money. Work only with integer values (not cents)

A design guideline that you should adhere to, can be found in the file Design.pdf
The solution should be responsive in the design so it will adapt to any screen size/device.

It is important that the application is delivered as a finished delivery to a customer. The fictional 
customer intends to use the solution as a basis for a further development process, for a more fully 
featured solution.

It is not a requirement that there should be a database, user model, pin codes or the like. The 
assignment is only a simulation of the withdrawal process.
