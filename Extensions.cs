
using System.ComponentModel;
using System.Diagnostics;

namespace KalmanFilterTest;
public static class Extensions
{
    #region IsNullOrEmpty
    public static bool IsNullOrEmpty<T>(this T[] array)
    {
        return array == null || array.Length == 0;
    }
    #endregion

    #region TextBox
    // Usage: TextBox.SetForeground(SKColor.Red);
    public static void SetForeground(this TextBox control, Color color)
    {
        if (control.InvokeRequired == true)
        {
            control.Invoke((MethodInvoker)delegate { control.ForeColor = color; });
        }
        else
        {
            control.ForeColor = color;
        }
    }
    // Usage: myTextBox.SetText("It works");
    public static void SetText(this TextBox control, string text)
    {
        if (control == null)
        {
            Debug.WriteLine("SetText control is null");
            return;
        }
        if (control.InvokeRequired == true)
        {
            control.Invoke((MethodInvoker)delegate { control.Text = text; });
        }
        else
        {
            control.Text = text;
        }
    }
    public static string GetText(this TextBox control)
    {
        string text = control.Text;
        if (control.InvokeRequired == true)
        {
            control.Invoke((MethodInvoker)delegate { text = control.Text; });
            return text;
        }
        else
        {
            return control.Text;
        }
    }

    // Add a new line of text to a multi-line TextBox
    // Usage: textBox.AddLine("It works");
    // private delegate void InsertTextBoxDelegate(TextBox control, string msg);
    public static void AddLine(this TextBox control, string text)
    {
        try
        {
            if (text.Length == 0)
            {
                return;
            }
            if (control.InvokeRequired == true)
            {
                control.BeginInvoke((MethodInvoker)delegate
                {
                    control.AppendText("\r\n" + text);
                    control.SelectionStart = control.Text.Length;
                    control.ScrollToCaret();
                    // Debug.WriteLine("1. " + text);
                });
            }
            else
            {
                control.AppendText("\r\n" + text);
                control.SelectionStart = control.Text.Length;
                control.ScrollToCaret();
            }
            // Debug.WriteLine("2. " + text);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
    public static void ClearText(this TextBox control)
    {
        control.Invoke((MethodInvoker)delegate
        {
            control.Clear();
        });
    }
    #endregion

    #region BackgroundWorker
    // Usage: backgroundWorker.RunAgain();
    public static void RunAgain(this BackgroundWorker control)
    {
        if (!control.IsBusy)
        {
            control.RunWorkerAsync();
        }
    }
    #endregion

    #region TabPage
    public static bool IsVisible(this TabPage tabPage)
    {
        var tabControl = tabPage.Parent as System.Windows.Forms.TabControl;
        return tabControl != null && tabControl.TabPages.Contains(tabPage);
    }
    #endregion

    #region Button
    // Usage: string text = myButton.GetText();
    public static string GetContent(this Button control)
    {
        var text = control.Text;
        if (control.InvokeRequired == true)
        {
            control.Invoke((MethodInvoker)delegate { text = control.Text; });
            return text;
        }
        else
        {
            return control.Text;
        }
    }
    // Usage: myButton.SetContent("Go");
    public static void SetContent(this Button control, string text)
    {
        if (control.InvokeRequired == true)
        {
            control.Invoke((MethodInvoker)delegate { control.Text = text; });
            return;
        }
        else
        {
            control.Text = text;
            return;
        }
    }
    // Usage: myButton.SetEnabled(true);
    public static void SetEnabled(this Button control, bool enabled)
    {
        if (control.InvokeRequired == true)
        {
            control.Invoke((MethodInvoker)delegate { control.Enabled = enabled; });
            return;
        }
        else
        {
            control.Enabled = enabled;
            return;
        }
    }
    // Usage: myButton.SetVisibility(visible);
    public static void SetVisibility(this Button control, bool visible)
    {
        if (control.InvokeRequired == true)
        {
            control.Invoke((MethodInvoker)delegate { control.Visible = visible; });
            return;
        }
        else
        {
            control.Visible = visible;
            return;
        }
    }
    // Usage: myButton.SetForColor(SKColor.Red);
    public static void SetForeColor(this Button control, Color color)
    {
        if (control.InvokeRequired == true)
        {
            control.Invoke((MethodInvoker)delegate { control.ForeColor = color; });
        }
        else
        {
            control.ForeColor = color;
        }
    }
    #endregion

    #region CheckBox
    // Usage: MyCheckBox.SetVisibility(Visibility.Hidden);
    public static void SetVisibility(this CheckBox control, bool visible)
    {
        if (control.InvokeRequired == true)
        {
            control.Invoke((MethodInvoker)delegate { control.Visible = visible; });
            return;
        }
        else
        {
            control.Visible = visible;
            return;
        }
    }
    // Usage: MyCheckBox.SetChecked(true);
    public static void SetChecked(this CheckBox control, bool checkedFlag)
    {
        if (control.InvokeRequired == true)
        {
            control.Invoke((MethodInvoker)delegate { control.Checked = checkedFlag; });
            return;
        }
        else
        {
            control.Checked = checkedFlag;
            return;
        }
    }
    // Usage: MyCheckBox.GetChecked();
    public static bool GetChecked(this CheckBox control)
    {
        bool result = false;

        // define a function which assigns the checkbox checked state to the result
        var checkCheckBox = new Action(() => result = control.Checked);

        // check if it should be invoked.      
        if (control.InvokeRequired)
        {
            control.Invoke(checkCheckBox);
        }
        else
        {
            checkCheckBox();
        }

        return result;
    }
    #endregion

    #region RadioButton
    // Usage: MyRadionButton.SetChecked(true);
    public static void SetChecked(this RadioButton control, bool checkedFlag)
    {
        if (control == null)
        {
            return;
        }
        if (control.InvokeRequired == true)
        {
            control.Invoke((MethodInvoker)delegate { control.Checked = checkedFlag; });
        }
        else
        {
            control.Checked |= checkedFlag;
        }
    }

    // Usage: MyRadioButton.GetChecked();
    public static bool GetChecked(this RadioButton control)
    {
        if (control == null)
        {
            return false;
        }
        var yes = false;
        if (control.InvokeRequired == true)
        {
            control.Invoke((MethodInvoker)delegate { yes = control.Checked; });
        }
        else
        {
            return control.Checked;
        }
        return yes;
    }
    #endregion
}