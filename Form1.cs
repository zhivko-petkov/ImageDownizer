using System.Diagnostics;

namespace ImageDownsizer
{
    public partial class Form1 : Form
    {
        private ConsequenceService consequenceService;
        private ParallService parallelService;
        private ConsequenceBitmapService consequenceBitmapService;
        private Stopwatch duration;

        public Form1()
        {
            InitializeComponent();
            consequenceService = new ConsequenceService();
            parallelService = new ParallService();
            consequenceBitmapService = new ConsequenceBitmapService();
            duration = new Stopwatch();
            ;
            percentage_combo_box.Items.Add(10);
            percentage_combo_box.Items.Add(25);
            percentage_combo_box.Items.Add(50);
            percentage_combo_box.Items.Add(75);
        }

        private void browse_btn_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All Graphics Types|*.jpg;*.jpeg;*.png;*.tif;*.tiff;*.bmp;" + "JPG|*.jpg;*.jpeg|PNG|*.png|TIFF|*.tif;*.tiff|BMP|*.bmp|\"";
            bool isSelectedFile = (openFileDialog1.ShowDialog() == DialogResult.OK);
            browsed_file_textBox.Enabled = false;
            browsed_file_textBox.Text = isSelectedFile ? openFileDialog1.FileName : null;
        }

        private void compress_button_Click(object sender, EventArgs e)
        {
            duration.Restart();
            duration_label.Text = $"Proccessing time is";
            if (resizedImagePictureBox.Image != null)
            {
                saveFileDialog1.FileName = saveFileDialog1.FileName + 1; 
            }

            if (browsed_file_textBox.Text == null || browsed_file_textBox.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please select image for downsizing", "Validation Problem");
                return;
            }

            if(save_file_textBox.Text == null || save_file_textBox.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please select directory where you want to save downsized image", "Validation Problem");
            }
            
            double percentage = Double.Parse(percentage_combo_box.Text);

            if(percentage < 0 || percentage > 100)
            {
                MessageBox.Show("Downsized image percentage have to be betweeen 0 to 100", "Validation Problem");
            }

            string savePath = $"{saveFileDialog1.FileName}{Path.GetExtension(openFileDialog1.FileName)}";

            if (conseq_radioBtn.Checked)
            {
                
                consequenceService.DownscaleImage(browsed_file_textBox.Text, savePath, percentage_combo_box.Text);
            }
            else if (parallel_radioBtn.Checked)
            {
                parallelService.DownscaleImage(browsed_file_textBox.Text, savePath, percentage_combo_box.Text);
            }
            else if (consequentialBtn2.Checked)
            {
                consequenceBitmapService.DownscaleImage(browsed_file_textBox.Text, savePath, percentage_combo_box.Text);
            }
            else
            {
                MessageBox.Show("Please select type of downscaling algorithm!", "Validation Problem");
                return;
            }
            duration.Stop();
            Image im = Image.FromFile(savePath);

            resizedImagePictureBox.Image = im;
            duration_label.Text = $"Proccessing time is {duration.ElapsedMilliseconds} ms. Resized image w: {im.Width} h: {im.Height}";

        }

        private void saveAsBtn_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            save_file_textBox.Text = saveFileDialog1.FileName;
        }
    }
}
