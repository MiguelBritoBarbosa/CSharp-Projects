private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
{
    if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
    {
        e.Handled = true;
    }
    else
    {
       if ((textBox2.Text.Length == 3 || textBox2.Text.Length == 7) && e.KeyChar != (char)Keys.Back)
       {
           textBox2.Text += ".";
           textBox2.Select(textBox2.Text.Length, 0);
       }
       else if (textBox2.Text.Length == 11 && e.KeyChar != (char)Keys.Back)
       {
           textBox2.Text += "-";
           textBox2.Select(textBox2.Text.Length, 0);
       }
    }
}