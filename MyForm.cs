
using Accord.Statistics.Running;

// This is a test of a 2d Kalman Filter in C#.
// We use the filter to extrapolate a trend into the future.
// If you don't know about ScottPlot, I strongly advise you to look into it.
// see: https://scottplot.net/cookbook/5.0/
// 
using ScottPlot;

namespace KalmanFilterTest;
public partial class MyForm : Form
{
    #region Properties
    public static int nExtrap { get; set; } = 5;
    public int nPoints { get; set; } = 10;
    public int nStart { get; set; } = 70;
    public int nPointsMin { get; set; } = 10;
    public int nPointsMax { get; set; } = 70;
    #endregion

    public MyForm()
    {
        InitializeComponent();
    }

    #region DrawKalmanChart
    private void DrawKalmanChart(int nPoints, int nExtrap)
    {
        Random rnd = new Random();
        var noisySine = new double[nPoints];
        var actualSine = new double[nPoints];
        var x = new double[nPoints];
        var y = new double[nPoints];

        for (int k = 0; k < nPoints; k++)
        {
            var sine = Math.Sin((k * 3.14 * 5) / 180.0);
            var noise = (double)rnd.Next(50) / 200;
            actualSine[k] = sine;
            noisySine[k] = sine + noise;
            x[k] = k;
            y[k] = noisySine[k];
        }

        // Create a new Kalman filter
        var kf = new MyKalmanFilter2D();

        // Push the points into the filter
        for (int k = 0; k < x.Length; k++)
        {
            kf.Push(x[k], y[k]);
        }

        // Predict the location of the next nExtrap points.
        var predictedX = new double[nExtrap];
        var predictedY = new double[nExtrap];
        for (int k = 0; k < nExtrap - 1; k++)
        {
            double newX = kf.X;
            double newY = kf.Y;
            predictedX[k] = newX;
            predictedY[k] = newY;

            kf.Push(newX, newY);
            newX = kf.X;
            newY = kf.Y;
            predictedX[k + 1] = newX;
            predictedY[k + 1] = newY;
        }

        // Estimate the points velocity
        double velX = kf.XAxisVelocity;
        double velY = kf.YAxisVelocity;

        formsPlot.Plot.Clear();

        var scatter1 = formsPlot.Plot.Add.Scatter(x, actualSine, color: Colors.Black);
        scatter1.Label = "Actual";
        var scatter2 = formsPlot.Plot.Add.Scatter(x, noisySine, color: Colors.Green);
        scatter2.Label = "Noisy";
        var scatter3 = formsPlot.Plot.Add.Scatter(predictedX, predictedY, color: Colors.Red);
        scatter3.Label = "Predicted";

        formsPlot.Plot.XAxis.Label.FontSize = 20;
        formsPlot.Plot.YAxis.Label.FontSize = 20;
        formsPlot.Plot.XAxis.TickFont.Size = 20;
        formsPlot.Plot.YAxis.TickFont.Size = 20;

        formsPlot.Plot.Legend.Font.Size = 20;
        formsPlot.Plot.Legend.Location = Alignment.UpperLeft;
        formsPlot.Plot.Legend.IsVisible = true;
        formsPlot.Refresh();
    }
    #endregion

    #region FormLoad
    private void MyForm_Load(object sender, EventArgs e)
    {
        SetTrackBar();
        ReDraw();
    }
    #endregion

    #region SetTrackBar
    private void SetTrackBar()
    {
        nPointsTrackBar.Minimum = nPointsMin;
        nPointsTrackBar.Maximum = nPointsMax;
        nPointsTrackBar.TickFrequency = 1;
        nPointsTrackBar.LargeChange = 1;
        nPointsTrackBar.SmallChange = 1;
        nPointsTrackBar.Value = nStart;
        return;
    }
    #endregion

    #region ReDraw
    private void ReDraw()
    {
        var nPoints = nPointsTrackBar.Value;
        nPointsTextBox.SetText(nPoints.ToString());

        var text = nExtrapTextBox.GetText();
        if (int.TryParse(text, out int v))
        {
            nExtrap = v;
        }
        else
        {
            nExtrap = 5;
        }

        DrawKalmanChart(nPoints, nExtrap);
    }
    #endregion

    #region trackBar_Scroll
    private void trackBar_Scroll(object sender, EventArgs e)
    {
        ReDraw();
        moveLabel.Text = "";
    }
    #endregion

    #region nExtrapTextBox_TextChanged
    private void nExtrapTextBox_TextChanged(object sender, EventArgs e)
    {
        ReDraw();
    }
    #endregion
}