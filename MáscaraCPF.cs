private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
{
    if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
    {
        e.Handled = true;
    }
    else
    {
       if ((textBox1.Text.Length == 3 || textBox1.Text.Length == 7) && e.KeyChar != (char)Keys.Back)
       {
           textBox1.Text += ".";
           textBox1.Select(textBox1.Text.Length, 0);
       }
       else if (textBox1.Text.Length == 11 && e.KeyChar != (char)Keys.Back)
       {
           textBox1.Text += "-";
           textBox1.Select(textBox1.Text.Length, 0);
       }
    }
}
