// Author:          Evan Olds
// Creation Date:   Juine 21, 2008

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AnimCur
{
    public partial class AnimCurForm : Form
    {
        private static readonly string appName = "Animated Cursor Maker";
        
        public AnimCurForm()
        {
            InitializeComponent();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            using (AboutForm af = new AboutForm())
            {
                af.ShowDialog(this);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            // Disable the timer
            tmrRender.Enabled = false;

            // Prepare to load the image
            Bitmap bm = null;

            // Do custom loading for cursor files
            if (openFileDialog1.FileName.ToLower().EndsWith(".cur"))
            {
                System.IO.FileStream fs = new System.IO.FileStream(openFileDialog1.FileName, 
                    System.IO.FileMode.Open, System.IO.FileAccess.Read);
                unsafe
                {
                    EOIcoCurLoader icl = new EOIcoCurLoader(fs);
                    if (icl.CountImages() <= 0)
                    {
                        MessageBox.Show(this,
                            "Load Error\n\nFile is not a valid icon/cursor file.", appName,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ResetTimer();
                        fs.Close();
                        return;
                    }
                    bm = icl.GetImage(0);
                    bm.RotateFlip(System.Drawing.RotateFlipType.RotateNoneFlipY);
                }
                fs.Close();
            }
            else
            {
                // Use .NET to load the bitmap
                try
                {
                    bm = new Bitmap(openFileDialog1.FileName);
                }
                catch (ArgumentException)
                {
                    MessageBox.Show(this,
                        "The specified file could not be opened. It may be inaccessible or of an " +
                        "unsupported format.", appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetTimer();
                    return;
                }
            }
            
            // Add the loaded image to the list    
            imageList1.Images.Add(bm);

            string name = openFileDialog1.FileName;
            if (name.LastIndexOf('\\') > 0)
            {
                name = name.Substring(name.LastIndexOf('\\')+1);
            }
            
            // Create and add the list view item
            ListViewItem lvi = new ListViewItem();
            lvi.ImageIndex = listView1.Items.Count;
            lvi.SubItems.Add(name);
            lvi.SubItems.Add("60");           
            listView1.Items.Add(lvi);

            ResetTimer();
        }

        private void btnChangeDelay_Click(object sender, EventArgs e)
        {
            // Don't do anything if there aren't any images selected
            if (listView1.SelectedIndices.Count <= 0)
            {
                MessageBox.Show(this,
                    "Please selected one or more images in the list to change animation delay.",
                    "Animated Cursor Maker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            int i = -1;
            using (DelayForm df = new DelayForm())
            {
                i = df.DoPrompt();
            }

            if (-1 == i)
            {
                return;
            }

            // Set the delay for each selected frame
            for (int x = 0; x < listView1.Items.Count; x++)
            {
                if (listView1.Items[x].Selected)
                {
                    listView1.Items[x].SubItems[2].Text = Convert.ToString(i);
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            // Disable the timer
            tmrRender.Enabled = false;

            while (listView1.SelectedIndices.Count > 0)
            {
                // Remove the image from the image list
                imageList1.Images.RemoveAt(listView1.SelectedIndices[0]);
                
                // Remove the item from the list view
                listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
            }

            // Fix the image indices
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                listView1.Items[i].ImageIndex = i;
            }

            ResetTimer();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int i;
            int count = listView1.Items.Count;
            if (count <= 0)
            {
                return;
            }
            
            // First make the frame rate and sequence arrays
            uint[] frameRates = new uint[count];
            uint[] seqNums = new uint[count];
            for (i = 0; i < count; i++)
            {
                frameRates[i] = Convert.ToUInt32(listView1.Items[i].SubItems[2].Text);
                seqNums[i] = (uint)i;
            }

            // Prompt for output file name
            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            
            // Open the output file
            System.IO.FileStream fs = null;
            try
            {
                fs = new System.IO.FileStream(saveFileDialog1.FileName,
                    System.IO.FileMode.Create, System.IO.FileAccess.Write);
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show(this, "Could not open output file", "Animated Cursor Maker",
                    MessageBoxButtons.OK);
            }
            if (null == fs)
            {
                MessageBox.Show(this, "Could not open output file", "Animated Cursor Maker",
                    MessageBoxButtons.OK);
            }

            EOANIWriter aw = new EOANIWriter(fs, (uint)count, 60, frameRates, seqNums, null,
                "Made with Evan's Animated Cursor Maker (www.evanolds.com)",
                new Point((int)nudX.Value, (int)nudY.Value));

            // Write each image
            for (i = 0; i < imageList1.Images.Count; i++)
            {
                using (Bitmap bm = new Bitmap(imageList1.Images[i]))
                {
                    aw.WriteFrame32(bm);
                }
            }

            // Close the file
            fs.Close();
        }

        private void pbPreview_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.X >= 0 && e.X < 32)
            {
                nudX.Value = e.X;
            }
            if (e.Y >= 0 && e.Y < 32)
            {
                nudY.Value = e.Y;
            }
        }

        private void ResetTimer()
        {
            if (listView1.Items.Count > 0)
            {
                tmrRender.Interval = 1;
                tmrRender.Tag = (int)0;
                tmrRender.Enabled = true;
            }
            else
            {
                tmrRender.Enabled = false;
                pbPreview.Image = null;
            }
        }

        private void tmrRender_Tick(object sender, EventArgs e)
        {
            // Disable the timer
            tmrRender.Enabled = false;
            
            // Get the image index from the timer's tag
            int i = (int)tmrRender.Tag;
            
            // Display the frame for this index
            pbPreview.Image = imageList1.Images[i];

            // Set the appropriate interval for the next frame
            tmrRender.Interval = (Convert.ToInt32(listView1.Items[i].SubItems[2].Text) * 1000) / 60;

            // Advance the index, looping back to zero if we exceed the image count
            i++;
            if (i >= listView1.Items.Count)
            {
                i = 0;
            }

            tmrRender.Tag = i;

            // Re-enable the timer
            tmrRender.Enabled = true;
        }
    }
}