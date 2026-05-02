namespace FrogWinFormsApp
{
    public partial class MainForm : Form
    {
        private int count = 0;
        private int EmptyX;
        private List<PictureBox> frog = new List<PictureBox>();

        public MainForm()
        {
            InitializeComponent();
            frog.Add(LeftPictureBox1);
            frog.Add(LeftPictureBox2);
            frog.Add(LeftPictureBox3);
            frog.Add(LeftPictureBox4);
            frog.Add(RightPictureBox1);
            frog.Add(RightPictureBox2);
            frog.Add(RightPictureBox3);
            frog.Add(RightPictureBox4);
            EmptyX = EmptyPictureBox.Location.X;
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            Swap((PictureBox)sender);
        }

        private void Swap(PictureBox clickedPictureBox)
        {
            var dist = Math.Abs(clickedPictureBox.Location.X - EmptyPictureBox.Location.X) / EmptyPictureBox.Size.Width;

            if (dist > 2)
            {
                MessageBox.Show("Так нельзя!");
            }
            else
            {
                var location = clickedPictureBox.Location;

                clickedPictureBox.Location = EmptyPictureBox.Location;

                EmptyPictureBox.Location = location;

                CountLabel.Text = Convert.ToString(++count);
            }

            CheckForWin();
        }

        private void CheckForWin()
        {
            var correctFrogsInLeftZone = 0;

            foreach (var frog in frog)
            {
                if (frog.Location.X < EmptyPictureBox.Location.X)
                {
                    if (frog.Name.Contains("Right"))
                    {
                        correctFrogsInLeftZone++;
                    }
                }
            }

            if (correctFrogsInLeftZone == 4 && EmptyPictureBox.Location.X == EmptyX)
            {
                if (count == 24)
                {
                    MessageBox.Show($"Урааа! Ты победил c минимальным количеством ходов {count}");
                }
                else
                {
                    MessageBox.Show($"Урааа! Ты победил! Но можно победить с меньшим количеством ходов");
                }
            }
        }
    }
}
