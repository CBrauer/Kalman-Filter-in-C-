### A Kalman Filter implemented in C#

### Application at Launch
When the application is first launched it looks like:

![Kalman](https://user-images.githubusercontent.com/1317234/224166439-28048dbe-31e8-4b68-9b18-0403dc4c351a.png)

The slider underneath the chart can be used to add/subtract the number of data points.</br>
The "green" lines are produced by adding noise to a Sine curve.</br>
The "black" lines are the original Sine curve.</br>
The "No. to Extrapolate" box can be used to add/subtract the number of data points (red) that are forecasted into the future.
### Comments
When you use the slider you will notice the forecasted data (red) has a strange shape when the Sine curve tops (or bottoms out).</br>
If someone has an explanation for this behaviour I would appreciate your comments.<br>
Also, the Kalman curve is shifed below the Sine curve.</br>
I wonder why?

### My Environment
* Windows 11, version: 23H2 (10.0.22631.2861) (December 12, 2023)
* Microsoft Visual Studio Professional 2022 (64-bit) - Current Version 17.8.3
* .NET 8.0
* ScottPlot. WinForms, Version=5.0.11-beta

Charles Brauer</br>
CBrauer@CypressPoint.com

