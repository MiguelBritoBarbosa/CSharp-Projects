private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
{
    if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (Char)8)
    {
        e.Handled = true;
    }
    else
    {
        if (textBox6.Text.Length == 0)
        {
            textBox6.Text = "(";
            textBox6.Select(textBox6.Text.Length, 0);
        }
        else if(textBox6.Text.Length == 3)
        {
            textBox6.Text += ") ";
            textBox6.Select(textBox6.Text.Length, 0);
        }
        else if (textBox6.Text.Length == 10)
        {
            textBox6.Text += "-";
            textBox6.Select(textBox6.Text.Length, 0);
        }
    }
}