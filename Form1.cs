using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SNotepad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //File Menu
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog { Filter = "RTF|*.rtf|Text|*.txt" })
                if (ofd.ShowDialog() == DialogResult.OK)
                    if (ofd.FilterIndex == 1) richTextBox1.LoadFile(ofd.FileName);
                    else richTextBox1.Text = File.ReadAllText(ofd.FileName);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog { Filter = "RTF|*.rtf|Text|*.txt" })
                if (sfd.ShowDialog() == DialogResult.OK)
                    if (sfd.FilterIndex == 1) richTextBox1.SaveFile(sfd.FileName);
                    else File.WriteAllText(sfd.FileName, richTextBox1.Text);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Edit Menu
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }
        //View Menu
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FontDialog fd = new FontDialog())
                if (fd.ShowDialog() == DialogResult.OK) richTextBox1.Font = fd.Font;
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ColorDialog cd = new ColorDialog())
                if (cd.ShowDialog() == DialogResult.OK) richTextBox1.ForeColor = cd.Color;
        }
        //StatusStrip
        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ready";
        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {
            toolStripProgressBar1.Minimum = 0;
            toolStripProgressBar1.Maximum = 100;
            toolStripProgressBar1.Value = 70;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Font f = richTextBox1.SelectionFont;
            richTextBox1.SelectionFont = new Font(f, f.Style ^ FontStyle.Bold);
        }
        //Help Menu
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Notepad Application\r\nA simple text editor for creating and editing plain text files.\r\nSupports basic formatting like Bold, Bullets, and Numbering.\r\nDeveloped with C#.NET Windows Forms.\r\n© 2026 Sneha Holkar. All rights reserved.\r\n", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = DateTime.Now.ToString("       dd:MM:yyyy , hh:mm:ss tt");
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
                richTextBox1.SelectionFont = new Font(
                    richTextBox1.SelectionFont,
                    richTextBox1.SelectionFont.Style ^ FontStyle.Italic);

        }
        //ContextMenuStrip
        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }
        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();

        }
        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void undoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }
        private void redoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        //ToolStrip Numbering and Bulleting
        private void bulletedListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionBullet = !richTextBox1.SelectionBullet;
        }
        private void numberedLToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string[] lines = richTextBox1.SelectedText.Split('\n');
            for (int i = 0; i < lines.Length; i++)
                lines[i] = $"{i + 1}. {lines[i]}";
            richTextBox1.SelectedText = string.Join("\n", lines);
        }
        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
           
            if (richTextBox1.SelectionFont != null)
            {
                Font currentFont = richTextBox1.SelectionFont;
                FontStyle newFontStyle;

                // Toggle bold
                if (currentFont.Bold)
                    newFontStyle = currentFont.Style & ~FontStyle.Bold; // remove bold
                else
                    newFontStyle = currentFont.Style | FontStyle.Bold;  // add bold

                richTextBox1.SelectionFont = new Font(currentFont, newFontStyle);
            }
        }
       
    }

}

