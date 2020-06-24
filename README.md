## **APPLITOOLS HACKATHON 2020**

The Hackathon 2020 challenge was to apply automation testing to the AppliFashion web app that is used by millions of people, using various devices and browsers to buy shoes.

**What is included:**
 - ModernTestsV1 Project on all the tasks
 - ModernTestsV2 Project on all the tasks
 - TraditionalTestsV1 on Task 1
 - TraditionalTestV2 on Task 1
 - Traditional-V1-TestResults.txt 
-  Traditional-V2-TestResults.txt 

### How to execute project
#### Before you get started
 Clone the repository 
	 
	 git clone git@github.com:acumbers/ApplitoolsHackathon2020.git  
    
#### System Requirements
1. Visual Studio 2019
2. .NET Core 3.1
3. Windows 10
4. Chrome Browser Version 83.0.4103.106

#### ModernTestV1 and ModernTestV2 steps to execute using Visual Studio:

 *Open and edit the C# file "ModernTest.cs" and edit the config.SetApiKey("YOUR API KEY") and replace the words YOUR API KEY with your Api key.*

1. Navigate to the ModernTestV1 folder
2. Double click on the Visual Studio solution ModernTestV1.sln to open it in visual studio
3. Navigate to the Test Explorer and then right click on the task you wish to execute and select "Run".
4. Browse to [https://eyes.applitools.com/](https://eyes.applitools.com/) log in and check the test results.
5. Repeat step 1-4 for the ModernTestV2 Task1
6. Repeat the cycle 1-5 until all 3 tasks are completed

#### ModernTestV1 and ModernTestV2 steps to execute using Command line:

1. On the command line navigate to the ModernTestV1 folder by using 
	
	    cd /path/to/folder/ModernTestV1
 2. Execute the command dotnet test --filter Task1
 3. Browse to [https://eyes.applitools.com/](https://eyes.applitools.com/) log in and check the test results.
 4. Repeat step 1-3 for the ModernTestV2 Task1
 5. Repeat the cycle 1-4 until all 3 tasks are completed

#### TraditionalTestsV1 and TraditionalTestsV2 steps to execute using Visual Studio:

1. Navigate to the TraditionalTestV1 folder.
2. Double click on the Visual Studio solution TraditionalTestV1.sln to open it in visual studio
3. Navigate to test explorer and select run.
4. View report by opening the file located in the bin folder 
		 
		bin\Debug\netcoreapp3.1\traditional-V1-TestResults.txt or bin\Release\netcoreapp3.1\traditional-V1-TestResults.txt

5. Repeat steps for TraditionalTestV2.

#### TraditionalTestsV1 and TraditionalTestsV2 steps to execute using Command Line:
1. On the command line navigate to the TraditionalTestV1 folder by using 
	
	    cd /path/to/folder/TraditionalTestV1
 2. Execute the command 
 
	 	    dotnet test
3. View report by opening the file located in the bin folder 
		 
		bin\Debug\netcoreapp3.1\traditional-V1-TestResults.txt or bin\Release\netcoreapp3.1\traditional-V1-TestResults.txt

5. Repeat steps for TraditionalTestV2.
	      
