private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
{
    if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (Char)8)
    {
        e.Handled = true;
    }
    else
    {
        if (textBox1.Text.Length == 0)
        {
            textBox1.Text = "(";
            textBox1.Select(textBox1.Text.Length, 0);
        }
        else if(textBox1.Text.Length == 3)
        {
            textBox1.Text += ") ";
            textBox1.Select(textBox1.Text.Length, 0);
        }
        else if (textBox1.Text.Length == 10)
        {
            textBox1.Text += "-";
            textBox1.Select(textBox6.Text.Length, 0);
        }
    }
}
