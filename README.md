I have used dot net core to solve this problem.  ParkingLot.Solution is a dot net solution which contains 2 projects:
- ParkingLot.App is a dot net core Console Project
- ParkingLot.App.Test is the Test Project powered by xUnit.

To make it runnable and testable in Linux, I have written a Dockerfile. 

The parking_lot directory contains these folders and files:
1. bin folder
2. functional_spec folder
3. ParkingLot.Solution folder
4. ParkingLot-1.4.2.pdf
5. README.md


ParkingLot.Solution folder contains two projects and one Dockerfile. Upon building the Dockerfile, we can see the test cases are passed. In this Dockerfile, I have ran dotnet test command, publish command. 

Setup file:

The Setup file is self explanatory. To run this file, use this command:

chisty@chisty-pc:/parking_lot/bin$ chmod 777 setup
chisty@chisty-pc:/parking_lot/bin$ ./setup (then setup file will run, and create the image as well as run the unit test). [screenshot1.png is attached for reference in screenshot folder]

after that parking_lot file is used to run interactive input test or file based input test. while running the file if any path argument is given, then program will try to read the file as a input otherwise, it will run as interactive mode.

so if filepath is given as parameter like,

chisty@chisty-pc:/parking_lot/bin$ chmod 777 parking_lot
chisty@chisty-pc:/parking_lot/bin$ ./parking_lot ../functional_spec/fixtures/file_input.txt (parking_lot script will read from the file input) [screenshot2.png is attached for reference in screenshot folder]

chisty@chisty-pc:/parking_lot/bin$ ./parking_lot /home/chisty/Documents/github/parking_lot/functional_spec/fixtures/file_input.txt (parking_lot script will read from the absolute file path input) [screenshot3.png is attached for reference in screenshot folder]


To run interactive mode, run the parking_lot script without any argument like below:
chisty@chisty-pc:/parking_lot/bin$./parking_lot  (it will run and wait for input)	[screenshot4.png is attached for reference in screenshot folder]
