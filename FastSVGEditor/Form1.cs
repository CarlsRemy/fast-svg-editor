using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Svg;
using FastSVGEditor.Editing;
using Ookii.Dialogs;
using OpenPainter.ColorPicker;

namespace FastSVGEditor
{
    public partial class MainForm : Form
    {
        private List<SVG> vectors = new List<SVG>();
        private List<VectorAction> actions = new List<VectorAction>();
        private ImageList thumbnails = new ImageList();
        private int selectedVector = -1;
        private bool showOriginalVector = false;

        public MainForm()
        {
            InitializeComponent();
            thumbnails.ImageSize = new Size(64, 64);
        }

        private void importBrowseSVG_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog browser = new OpenFileDialog())
            {
                browser.Filter = "SVG Vectors|*.svg";
                browser.CheckFileExists = true;
                browser.CheckPathExists = true;
                browser.DefaultExt = "svg";
                browser.Multiselect = false;
                browser.Title = "Open SVG";
                browser.ShowDialog();

                if (browser.FileName == "")
                    return;

                importPathSVG.Text = browser.FileName;
            }
        }

        private void browseDirectorySVG_Click(object sender, EventArgs e)
        {
            using (VistaFolderBrowserDialog browser = new VistaFolderBrowserDialog())
            {
                browser.ShowDialog();

                if (browser.SelectedPath == "")
                    return;

                importPathDirectorySVG.Text = browser.SelectedPath;
            }
        }

        private void importPathDirectorySVG_TextChanged(object sender, EventArgs e)
        {
            importDirectorySVG.Enabled = Directory.Exists(importPathDirectorySVG.Text);
        }

        private void importSVG_Click(object sender, EventArgs e)
        {
            SVG svg = Editor.svgFactory(importPathSVG.Text);

            if (svg == null || Editor.svgExists(vectors, svg))
                return;

            vectors.Add(svg);

            importPathSVG.Text = "";

            addThumbnail(svg);
        }

        private void importPathSVG_TextChanged(object sender, EventArgs e)
        {
            importSVG.Enabled = File.Exists(importPathSVG.Text);
        }

        private void importDirectorySVG_Click(object sender, EventArgs e)
        {
            List<SVG> svgs = Editor.svgListFactory(importPathDirectorySVG.Text, importSubDirectorySVG.Checked);

            if (svgs == null)
                return;

            Editor.garbageDispose(svgs);

            this.Cursor = Cursors.WaitCursor;

            foreach (SVG svg in svgs)
            {
                if (!Editor.svgExists(vectors, svg))
                {
                    vectors.Add(svg);
                    addThumbnail(svg);
                }
            }

            importPathDirectorySVG.Text = "";
            this.Cursor = Cursors.Default;
        }

        private void drawPreview(SVG vector, PictureBox box)
        {
            if (vector == null || box == null)
                return;

            SVG previewVector = showOriginalVector ? vectors[selectedVector] : vector;

            using (Bitmap preview = Editor.getPreview(previewVector))
            {
                if (preview == null)
                {
                    box.Image = box.InitialImage;
                }

                using (Bitmap finalPreview = new Bitmap(box.Width, box.Height))
                {
                    using (Graphics g = Graphics.FromImage(finalPreview))
                    {
                        g.DrawImage(preview, new Point((box.Width - preview.Width) / 2, (box.Height - preview.Height) / 2));
                    }

                    box.Image = (Image)finalPreview.Clone();
                }
            }
        }

        private void updatePreview(int vectorIndex, VectorAction action, PictureBox box)
        {
            if (vectorIndex < 0 || vectorIndex >= vectors.Count || vectors.Count == 0)
                return;

            SVG temp = Editor.svgFromDataFactory(vectors[vectorIndex].data);
            List<SVG> tempVectors = new List<SVG>();
            List<VectorAction> tempActions = new List<VectorAction>();
            
            tempVectors.Add(temp);

            if (action != null) tempActions.Add(action);

            tempActions.AddRange(actions);

            Editor.refreshActions(tempActions);
            Editor.assignAllActions(tempVectors, tempActions);
            Editor.doActions(tempVectors);

            drawPreview(tempVectors[0], svgPreview);
        }

        private void createUpdatePreview(Color oldColor, Color newColor)
        {
            if (oldColor == Color.Transparent || newColor == Color.Transparent)
                return;

            VectorAction action = Editor.actionFactory(oldColor, newColor);

            updatePreview(selectedVector, action, svgPreview);
        }

        private void createValidPreview()
        {
            if (showOriginalVector && selectedVector >= 0 && selectedVector < vectors.Count)
                drawPreview(vectors[selectedVector], svgPreview);
            else if (!showOriginalVector && selectedVector >= 0 && selectedVector < vectors.Count)
            {
                if (isCurrentActionValid())
                    createUpdatePreview(oldColorPreview.BackColor, newColorPreview.BackColor);
                else
                    updatePreview(selectedVector, null, svgPreview);
            }
        }

        private bool isCurrentActionValid()
        {
            return (Editor.isHexColor(oldColorCode.Text) && Editor.isHexColor(newColorCode.Text));
        }

        private void svgPreview_MouseUp(object sender, MouseEventArgs e)
        {
            Color? picked = Editor.pickColor((Bitmap)svgPreview.Image, new Point(e.X, e.Y));

            if (picked == null)
                return;

            Color color = (Color)picked;

            if (color.A.ToString() == "0")
                oldColorCode.Text = "None";
            else
                oldColorCode.Text = Editor.toHexColor(color);
        }

        private void oldColorCode_TextChanged(object sender, EventArgs e)
        {
            if (Editor.isHexColor(oldColorCode.Text))
            {
                oldColorPreview.Image = null;
                oldColorPreview.BackColor = ColorTranslator.FromHtml("#" + oldColorCode.Text);
            }
            else
            {
                oldColorPreview.BackColor = Color.Transparent;
                oldColorPreview.Image = Properties.Resources.trans_bg;
            }

            addAction.Enabled = isCurrentActionValid();
            discardAction.Enabled = (oldColorCode.Text != "" || newColorCode.Text != "");
            createValidPreview();
        }

        private void newColorCode_TextChanged(object sender, EventArgs e)
        {
            if (Editor.isHexColor(newColorCode.Text))
            {
                newColorPreview.Image = null;
                newColorPreview.BackColor = ColorTranslator.FromHtml("#" + newColorCode.Text);
            }
            else
            {
                newColorPreview.BackColor = Color.Transparent;
                newColorPreview.Image = Properties.Resources.trans_bg;
            }

            addAction.Enabled = isCurrentActionValid();
            discardAction.Enabled = (oldColorCode.Text != "" || newColorCode.Text != "");
            createValidPreview();
        }

        private void newColorPreview_Click(object sender, EventArgs e)
        {
            using (frmColorPicker picker = new frmColorPicker
                (newColorPreview.BackColor == Color.Transparent ? oldColorPreview.BackColor : newColorPreview.BackColor))
            {
                DialogResult result = picker.ShowDialog();

                if (result == DialogResult.Cancel)
                    return;

                newColorPreview.BackColor = picker.PrimaryColor;
                newColorCode.Text = Editor.toHexColor(picker.PrimaryColor);
            }
        }

        private void oldColorPreview_Click(object sender, EventArgs e)
        {
            using (frmColorPicker picker = new frmColorPicker(oldColorPreview.BackColor))
            {
                DialogResult result = picker.ShowDialog();

                if (result == DialogResult.Cancel)
                    return;

                oldColorPreview.BackColor = picker.PrimaryColor;
                oldColorCode.Text = Editor.toHexColor(picker.PrimaryColor);
            }
        }

        private void previewMode_Click(object sender, EventArgs e)
        {
            showOriginalVector = !showOriginalVector;
            previewMode.Image = showOriginalVector ? Properties.Resources.eye_blocked : Properties.Resources.eye;
            tooltipPreview.SetToolTip(previewMode, (showOriginalVector ? "Show original input" : "Show output after actions done"));

            createValidPreview();
        }

        private void addAction_Click(object sender, EventArgs e)
        {
            if (!isCurrentActionValid())
                return;

            actions.Add(Editor.actionFactory(oldColorPreview.BackColor, newColorPreview.BackColor));

            actionList.Items.Add(new String(("Replace #" + oldColorCode.Text +
                " with #" + newColorCode.Text).ToCharArray()));

            oldColorCode.Text = "";
            newColorCode.Text = "";

            clearActions.Enabled = (actions.Count > 0);
        }

        private void actionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            deleteActions.Enabled = (actionList.SelectedIndex > -1);
        }

        private void deleteActions_Click(object sender, EventArgs e)
        {
            actions.RemoveAt(actionList.SelectedIndex);
            actionList.Items.RemoveAt(actionList.SelectedIndex);

            clearActions.Enabled = (actions.Count > 0);

            createValidPreview();
        }

        private void clearActions_Click(object sender, EventArgs e)
        {
            actions.Clear();
            actionList.Items.Clear();
            clearActions.Enabled = false;
            Editor.clearAllActions(vectors);

            createValidPreview();
        }

        private void discardAction_Click(object sender, EventArgs e)
        {
            oldColorCode.Text = "";
            newColorCode.Text = "";
        }

        private void addThumbnail(SVG svg)
        {
            ListViewItem item = new ListViewItem();
            thumbnails.Images.Add(svg.path, Editor.getPreview(svg));
            item.ImageKey = svg.path;
            item.Tag = svg.path;
            svgList.LargeImageList = thumbnails;
            svgList.Items.Add(item);
        }

        private void svgList_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (int index in svgList.SelectedIndices)
                selectedVector = index;

            createValidPreview();
        }

        private void svgList_DragEnter(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            foreach (string file in files)
            {
                if (Path.GetExtension(file).ToLower() != ".svg")
                {
                    e.Effect = DragDropEffects.None;
                    return;
                }
            }

            e.Effect = DragDropEffects.Copy;
        }

        private void svgList_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            foreach (string file in files)
            {
                if (Path.GetExtension(file).ToLower() != ".svg")
                    continue;

                SVG vector = Editor.svgFactory(file);

                if (vector == null || Editor.svgExists(vectors, vector))
                    continue;

                vectors.Add(vector);
                addThumbnail(vector);
            }
        }

        private void svgList_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                foreach (ListViewItem item in svgList.SelectedItems)
                {
                    thumbnails.Images.RemoveByKey(item.Tag.ToString());
                    vectors.RemoveAt(item.Index);
                    svgList.Items.RemoveAt(item.Index);
                }

                selectedVector = -1;
                svgPreview.Image = null;
            }
        }

        private void exportBrowseSVG_Click(object sender, EventArgs e)
        {
            using (VistaFolderBrowserDialog browser = new VistaFolderBrowserDialog())
            {
                browser.ShowDialog();

                if (browser.SelectedPath == "")
                    return;

                exportPathSVG.Text = browser.SelectedPath;
            }
        }

        private void exportSVG_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            Editor.refreshActions(actions);
            Editor.assignAllActions(vectors, actions);
            Editor.doActions(vectors);

            List<ExportReport> reports = Editor.exportToSVG(vectors, exportPathSVG.Text);

            this.Cursor = Cursors.Default;

            LogWindow logWin = new LogWindow();

            foreach (ExportReport report in reports)
                logWin.writeLog(report.error, report.message);

            logWin.ShowDialog(this);
        }

        private void exportPathSVG_TextChanged(object sender, EventArgs e)
        {
            exportSVG.Enabled = (Directory.Exists(exportPathSVG.Text));
        }

        private void exportPathPNG_TextChanged(object sender, EventArgs e)
        {
            exportPNG.Enabled = (Directory.Exists(exportPathPNG.Text));
        }

        private void exportBrowsePNG_Click(object sender, EventArgs e)
        {
            using (VistaFolderBrowserDialog browser = new VistaFolderBrowserDialog())
            {
                browser.ShowDialog();

                if (browser.SelectedPath == "")
                    return;

                exportPathPNG.Text = browser.SelectedPath;
            }
        }

        private void cropPNG_CheckedChanged(object sender, EventArgs e)
        {
            cropWidthPNG.Enabled = cropHeightPNG.Enabled = cropPNG.Checked;
        }

        private void exportPNG_Click(object sender, EventArgs e)
        {
            if (cropPNG.Checked && (!isNumeric(cropWidthPNG.Text.Trim()) || !isNumeric(cropHeightPNG.Text.Trim())))
            {
                MessageBox.Show("Crop dimensions invalid!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            Editor.assignAllActions(vectors, actions);
            Editor.doActions(vectors);
            List<ExportReport> reports;

            if (cropPNG.Checked)
                reports = Editor.exportToPNG(vectors, exportPathPNG.Text,
                    new Rectangle(0, 0, int.Parse(cropWidthPNG.Text), int.Parse(cropHeightPNG.Text)),
                    cropPNG.Checked);
            else
                reports = Editor.exportToPNG(vectors, exportPathPNG.Text);

            this.Cursor = Cursors.Default;

            LogWindow logWin = new LogWindow();

            foreach (ExportReport report in reports)
                logWin.writeLog(report.error, report.message);

            logWin.ShowDialog(this);
        }

        private bool isNumeric(string str)
        {
            return str.All(Char.IsNumber);
        }
    }
}
