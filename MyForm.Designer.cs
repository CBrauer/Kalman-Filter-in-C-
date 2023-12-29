namespace KalmanFilterTest;
partial class MyForm
{
    private System.ComponentModel.IContainer components = null;
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }
    private void InitializeComponent()
    {
        nPointsTrackBar = new TrackBar();
        nExtrapTextBox = new TextBox();
        extrapolateLabel = new Label();
        nPointsTextBox = new TextBox();
        formsPlot = new ScottPlot.WinForms.FormsPlot();
        moveLabel = new Label();
        ((System.ComponentModel.ISupportInitialize) nPointsTrackBar).BeginInit();
        SuspendLayout();
        // 
        // nPointsTrackBar
        // 
        nPointsTrackBar.Location = new Point(424, 937);
        nPointsTrackBar.Maximum = 100;
        nPointsTrackBar.Minimum = 50;
        nPointsTrackBar.Name = "nPointsTrackBar";
        nPointsTrackBar.Size = new Size(584, 90);
        nPointsTrackBar.TabIndex = 1;
        nPointsTrackBar.Value = 50;
        nPointsTrackBar.Scroll += trackBar_Scroll;
        // 
        // nExtrapTextBox
        // 
        nExtrapTextBox.Location = new Point(301, 947);
        nExtrapTextBox.Name = "nExtrapTextBox";
        nExtrapTextBox.Size = new Size(61, 39);
        nExtrapTextBox.TabIndex = 2;
        nExtrapTextBox.Text = "5";
        nExtrapTextBox.TextAlign = HorizontalAlignment.Right;
        nExtrapTextBox.TextChanged += nExtrapTextBox_TextChanged;
        // 
        // extrapolateLabel
        // 
        extrapolateLabel.Anchor = AnchorStyles.Right;
        extrapolateLabel.AutoSize = true;
        extrapolateLabel.Location = new Point(85, 947);
        extrapolateLabel.Name = "extrapolateLabel";
        extrapolateLabel.Size = new Size(213, 32);
        extrapolateLabel.TabIndex = 3;
        extrapolateLabel.Text = "No. To Extrapolate:";
        extrapolateLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // nPointsTextBox
        // 
        nPointsTextBox.Location = new Point(1039, 937);
        nPointsTextBox.Name = "nPointsTextBox";
        nPointsTextBox.Size = new Size(61, 39);
        nPointsTextBox.TabIndex = 4;
        nPointsTextBox.Text = "10";
        nPointsTextBox.TextAlign = HorizontalAlignment.Right;
        // 
        // formsPlot
        // 
        formsPlot.DisplayScale = 2F;
        formsPlot.Location = new Point(36, 43);
        formsPlot.Name = "formsPlot";
        formsPlot.Size = new Size(1096, 860);
        formsPlot.TabIndex = 5;
        // 
        // moveLabel
        // 
        moveLabel.AutoSize = true;
        moveLabel.Location = new Point(522, 1030);
        moveLabel.Name = "moveLabel";
        moveLabel.Size = new Size(296, 32);
        moveLabel.TabIndex = 6;
        moveLabel.Text = "Move the TrackBar pointer";
        // 
        // MyForm
        // 
        AutoScaleDimensions = new SizeF(13F, 32F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1166, 1161);
        Controls.Add(moveLabel);
        Controls.Add(formsPlot);
        Controls.Add(nPointsTextBox);
        Controls.Add(extrapolateLabel);
        Controls.Add(nExtrapTextBox);
        Controls.Add(nPointsTrackBar);
        Name = "MyForm";
        Text = "Kalman Filter Test";
        Load += MyForm_Load;
        ((System.ComponentModel.ISupportInitialize) nPointsTrackBar).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private TrackBar nPointsTrackBar;
    private TextBox nExtrapTextBox;
    private Label extrapolateLabel;
    private TextBox nPointsTextBox;
    private ScottPlot.WinForms.FormsPlot formsPlot;
    private Label moveLabel;
}