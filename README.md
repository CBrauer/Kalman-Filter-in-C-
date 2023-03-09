### A Kalman Filter implemented in C#
This project was built with Visual Studio 2022 and .NET 7.0.

### Application at Launch
When the application is first launched it looks like:

![Kalman](https://user-images.githubusercontent.com/1317234/224157065-e5af1bde-4357-4abf-815a-d9f6ce550be2.png)

The slider underneath the chart can be used to add/subtract the number of data points.

The "green" lines are produced by adding noise to a Sine curve.
The "black" lines are the original Sine curve.

The "No. to Extrapolate" box can be used to add/subtract the number of data points (red) that are forecasted into the future.
