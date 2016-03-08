namespace FastSVGEditor
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.importSubDirectorySVG = new System.Windows.Forms.CheckBox();
            this.importDirectorySVG = new System.Windows.Forms.Button();
            this.importSVG = new System.Windows.Forms.Button();
            this.browseDirectorySVG = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.importBrowseSVG = new System.Windows.Forms.Button();
            this.importPathDirectorySVG = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.importPathSVG = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.previewMode = new System.Windows.Forms.PictureBox();
            this.actionList = new System.Windows.Forms.ListBox();
            this.discardAction = new System.Windows.Forms.Button();
            this.clearActions = new System.Windows.Forms.Button();
            this.deleteActions = new System.Windows.Forms.Button();
            this.addAction = new System.Windows.Forms.Button();
            this.newColorCode = new System.Windows.Forms.TextBox();
            this.oldColorCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.newColorPreview = new System.Windows.Forms.Label();
            this.oldColorPreview = new System.Windows.Forms.Label();
            this.svgPreview = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cropHeightPNG = new System.Windows.Forms.TextBox();
            this.cropWidthPNG = new System.Windows.Forms.TextBox();
            this.cropPNG = new System.Windows.Forms.CheckBox();
            this.exportPNG = new System.Windows.Forms.Button();
            this.exportSVG = new System.Windows.Forms.Button();
            this.exportPathPNG = new System.Windows.Forms.TextBox();
            this.exportPathSVG = new System.Windows.Forms.TextBox();
            this.exportBrowsePNG = new System.Windows.Forms.Button();
            this.exportBrowseSVG = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tooltipActions = new System.Windows.Forms.ToolTip(this.components);
            this.tooltipPreview = new System.Windows.Forms.ToolTip(this.components);
            this.svgList = new System.Windows.Forms.ListView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgPreview)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.importSubDirectorySVG);
            this.groupBox1.Controls.Add(this.importDirectorySVG);
            this.groupBox1.Controls.Add(this.importSVG);
            this.groupBox1.Controls.Add(this.browseDirectorySVG);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.importBrowseSVG);
            this.groupBox1.Controls.Add(this.importPathDirectorySVG);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.importPathSVG);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(339, 285);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Import Files";
            // 
            // importSubDirectorySVG
            // 
            this.importSubDirectorySVG.AutoSize = true;
            this.importSubDirectorySVG.Location = new System.Drawing.Point(23, 194);
            this.importSubDirectorySVG.Name = "importSubDirectorySVG";
            this.importSubDirectorySVG.Size = new System.Drawing.Size(135, 17);
            this.importSubDirectorySVG.TabIndex = 20;
            this.importSubDirectorySVG.Text = "Scan all sub-directories";
            this.importSubDirectorySVG.UseVisualStyleBackColor = true;
            // 
            // importDirectorySVG
            // 
            this.importDirectorySVG.Enabled = false;
            this.importDirectorySVG.Location = new System.Drawing.Point(84, 217);
            this.importDirectorySVG.Name = "importDirectorySVG";
            this.importDirectorySVG.Size = new System.Drawing.Size(117, 35);
            this.importDirectorySVG.TabIndex = 16;
            this.importDirectorySVG.Text = "Import";
            this.importDirectorySVG.UseVisualStyleBackColor = true;
            this.importDirectorySVG.Click += new System.EventHandler(this.importDirectorySVG_Click);
            // 
            // importSVG
            // 
            this.importSVG.Enabled = false;
            this.importSVG.Location = new System.Drawing.Point(84, 74);
            this.importSVG.Name = "importSVG";
            this.importSVG.Size = new System.Drawing.Size(117, 35);
            this.importSVG.TabIndex = 17;
            this.importSVG.Text = "Import";
            this.importSVG.UseVisualStyleBackColor = true;
            this.importSVG.Click += new System.EventHandler(this.importSVG_Click);
            // 
            // browseDirectorySVG
            // 
            this.browseDirectorySVG.Location = new System.Drawing.Point(207, 217);
            this.browseDirectorySVG.Name = "browseDirectorySVG";
            this.browseDirectorySVG.Size = new System.Drawing.Size(117, 35);
            this.browseDirectorySVG.TabIndex = 18;
            this.browseDirectorySVG.Text = "Browse";
            this.browseDirectorySVG.UseVisualStyleBackColor = true;
            this.browseDirectorySVG.Click += new System.EventHandler(this.browseDirectorySVG_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Scan directory for SVG";
            // 
            // importBrowseSVG
            // 
            this.importBrowseSVG.Location = new System.Drawing.Point(207, 74);
            this.importBrowseSVG.Name = "importBrowseSVG";
            this.importBrowseSVG.Size = new System.Drawing.Size(117, 35);
            this.importBrowseSVG.TabIndex = 19;
            this.importBrowseSVG.Text = "Browse";
            this.importBrowseSVG.UseVisualStyleBackColor = true;
            this.importBrowseSVG.Click += new System.EventHandler(this.importBrowseSVG_Click);
            // 
            // importPathDirectorySVG
            // 
            this.importPathDirectorySVG.Location = new System.Drawing.Point(23, 168);
            this.importPathDirectorySVG.Name = "importPathDirectorySVG";
            this.importPathDirectorySVG.Size = new System.Drawing.Size(301, 20);
            this.importPathDirectorySVG.TabIndex = 12;
            this.importPathDirectorySVG.TextChanged += new System.EventHandler(this.importPathDirectorySVG_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Import SVG";
            // 
            // importPathSVG
            // 
            this.importPathSVG.Location = new System.Drawing.Point(23, 48);
            this.importPathSVG.Name = "importPathSVG";
            this.importPathSVG.ReadOnly = true;
            this.importPathSVG.Size = new System.Drawing.Size(301, 20);
            this.importPathSVG.TabIndex = 13;
            this.importPathSVG.TextChanged += new System.EventHandler(this.importPathSVG_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.previewMode);
            this.groupBox2.Controls.Add(this.actionList);
            this.groupBox2.Controls.Add(this.discardAction);
            this.groupBox2.Controls.Add(this.clearActions);
            this.groupBox2.Controls.Add(this.deleteActions);
            this.groupBox2.Controls.Add(this.addAction);
            this.groupBox2.Controls.Add(this.newColorCode);
            this.groupBox2.Controls.Add(this.oldColorCode);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.newColorPreview);
            this.groupBox2.Controls.Add(this.oldColorPreview);
            this.groupBox2.Controls.Add(this.svgPreview);
            this.groupBox2.Location = new System.Drawing.Point(357, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(518, 284);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Edit";
            // 
            // previewMode
            // 
            this.previewMode.BackColor = System.Drawing.Color.White;
            this.previewMode.Image = global::FastSVGEditor.Properties.Resources.eye;
            this.previewMode.Location = new System.Drawing.Point(256, 23);
            this.previewMode.Name = "previewMode";
            this.previewMode.Size = new System.Drawing.Size(16, 16);
            this.previewMode.TabIndex = 17;
            this.previewMode.TabStop = false;
            this.tooltipPreview.SetToolTip(this.previewMode, "Show output after actions done");
            this.previewMode.Click += new System.EventHandler(this.previewMode_Click);
            // 
            // actionList
            // 
            this.actionList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionList.FormattingEnabled = true;
            this.actionList.Location = new System.Drawing.Point(15, 152);
            this.actionList.Name = "actionList";
            this.actionList.Size = new System.Drawing.Size(220, 121);
            this.actionList.TabIndex = 15;
            this.actionList.SelectedIndexChanged += new System.EventHandler(this.actionList_SelectedIndexChanged);
            // 
            // discardAction
            // 
            this.discardAction.Enabled = false;
            this.discardAction.Image = global::FastSVGEditor.Properties.Resources.refresh_arrow;
            this.discardAction.Location = new System.Drawing.Point(203, 114);
            this.discardAction.Name = "discardAction";
            this.discardAction.Size = new System.Drawing.Size(32, 32);
            this.discardAction.TabIndex = 14;
            this.tooltipActions.SetToolTip(this.discardAction, "Discard current action");
            this.discardAction.UseVisualStyleBackColor = true;
            this.discardAction.Click += new System.EventHandler(this.discardAction_Click);
            // 
            // clearActions
            // 
            this.clearActions.Enabled = false;
            this.clearActions.Image = global::FastSVGEditor.Properties.Resources.waste_can_full_of_trash;
            this.clearActions.Location = new System.Drawing.Point(89, 114);
            this.clearActions.Name = "clearActions";
            this.clearActions.Size = new System.Drawing.Size(32, 32);
            this.clearActions.TabIndex = 14;
            this.tooltipActions.SetToolTip(this.clearActions, "Clear all assigned actions");
            this.clearActions.UseVisualStyleBackColor = true;
            this.clearActions.Click += new System.EventHandler(this.clearActions_Click);
            // 
            // deleteActions
            // 
            this.deleteActions.Enabled = false;
            this.deleteActions.Image = global::FastSVGEditor.Properties.Resources.delete_point;
            this.deleteActions.Location = new System.Drawing.Point(127, 114);
            this.deleteActions.Name = "deleteActions";
            this.deleteActions.Size = new System.Drawing.Size(32, 32);
            this.deleteActions.TabIndex = 14;
            this.tooltipActions.SetToolTip(this.deleteActions, "Delete selected assigned actions");
            this.deleteActions.UseVisualStyleBackColor = true;
            this.deleteActions.Click += new System.EventHandler(this.deleteActions_Click);
            // 
            // addAction
            // 
            this.addAction.Enabled = false;
            this.addAction.Image = global::FastSVGEditor.Properties.Resources.add_point;
            this.addAction.Location = new System.Drawing.Point(165, 114);
            this.addAction.Name = "addAction";
            this.addAction.Size = new System.Drawing.Size(32, 32);
            this.addAction.TabIndex = 14;
            this.tooltipActions.SetToolTip(this.addAction, "Assign action");
            this.addAction.UseVisualStyleBackColor = true;
            this.addAction.Click += new System.EventHandler(this.addAction_Click);
            // 
            // newColorCode
            // 
            this.newColorCode.Location = new System.Drawing.Point(180, 63);
            this.newColorCode.MaxLength = 6;
            this.newColorCode.Name = "newColorCode";
            this.newColorCode.Size = new System.Drawing.Size(55, 20);
            this.newColorCode.TabIndex = 13;
            this.newColorCode.TextChanged += new System.EventHandler(this.newColorCode_TextChanged);
            // 
            // oldColorCode
            // 
            this.oldColorCode.Location = new System.Drawing.Point(180, 28);
            this.oldColorCode.MaxLength = 6;
            this.oldColorCode.Name = "oldColorCode";
            this.oldColorCode.Size = new System.Drawing.Size(55, 20);
            this.oldColorCode.TabIndex = 13;
            this.oldColorCode.TextChanged += new System.EventHandler(this.oldColorCode_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(165, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "#";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(165, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "#";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(107, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "to";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Change all colors of";
            // 
            // newColorPreview
            // 
            this.newColorPreview.BackColor = System.Drawing.Color.Transparent;
            this.newColorPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.newColorPreview.Image = global::FastSVGEditor.Properties.Resources.trans_bg;
            this.newColorPreview.Location = new System.Drawing.Point(129, 61);
            this.newColorPreview.Name = "newColorPreview";
            this.newColorPreview.Size = new System.Drawing.Size(25, 25);
            this.newColorPreview.TabIndex = 10;
            this.newColorPreview.Click += new System.EventHandler(this.newColorPreview_Click);
            // 
            // oldColorPreview
            // 
            this.oldColorPreview.BackColor = System.Drawing.Color.Transparent;
            this.oldColorPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.oldColorPreview.Image = global::FastSVGEditor.Properties.Resources.trans_bg;
            this.oldColorPreview.Location = new System.Drawing.Point(129, 26);
            this.oldColorPreview.Name = "oldColorPreview";
            this.oldColorPreview.Size = new System.Drawing.Size(25, 25);
            this.oldColorPreview.TabIndex = 10;
            this.oldColorPreview.Click += new System.EventHandler(this.oldColorPreview_Click);
            // 
            // svgPreview
            // 
            this.svgPreview.BackColor = System.Drawing.SystemColors.Control;
            this.svgPreview.BackgroundImage = global::FastSVGEditor.Properties.Resources.trans_bg;
            this.svgPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.svgPreview.Cursor = System.Windows.Forms.Cursors.Cross;
            this.svgPreview.Location = new System.Drawing.Point(250, 17);
            this.svgPreview.Name = "svgPreview";
            this.svgPreview.Size = new System.Drawing.Size(256, 256);
            this.svgPreview.TabIndex = 8;
            this.svgPreview.TabStop = false;
            this.svgPreview.MouseUp += new System.Windows.Forms.MouseEventHandler(this.svgPreview_MouseUp);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cropHeightPNG);
            this.groupBox3.Controls.Add(this.cropWidthPNG);
            this.groupBox3.Controls.Add(this.cropPNG);
            this.groupBox3.Controls.Add(this.exportPNG);
            this.groupBox3.Controls.Add(this.exportSVG);
            this.groupBox3.Controls.Add(this.exportPathPNG);
            this.groupBox3.Controls.Add(this.exportPathSVG);
            this.groupBox3.Controls.Add(this.exportBrowsePNG);
            this.groupBox3.Controls.Add(this.exportBrowseSVG);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(12, 303);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(339, 265);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Export";
            // 
            // cropHeightPNG
            // 
            this.cropHeightPNG.Enabled = false;
            this.cropHeightPNG.Location = new System.Drawing.Point(216, 180);
            this.cropHeightPNG.Name = "cropHeightPNG";
            this.cropHeightPNG.Size = new System.Drawing.Size(55, 20);
            this.cropHeightPNG.TabIndex = 19;
            // 
            // cropWidthPNG
            // 
            this.cropWidthPNG.Enabled = false;
            this.cropWidthPNG.Location = new System.Drawing.Point(137, 180);
            this.cropWidthPNG.Name = "cropWidthPNG";
            this.cropWidthPNG.Size = new System.Drawing.Size(55, 20);
            this.cropWidthPNG.TabIndex = 19;
            // 
            // cropPNG
            // 
            this.cropPNG.AutoSize = true;
            this.cropPNG.Location = new System.Drawing.Point(22, 182);
            this.cropPNG.Name = "cropPNG";
            this.cropPNG.Size = new System.Drawing.Size(109, 17);
            this.cropPNG.TabIndex = 0;
            this.cropPNG.Text = "Crop all images to";
            this.cropPNG.UseVisualStyleBackColor = true;
            this.cropPNG.CheckedChanged += new System.EventHandler(this.cropPNG_CheckedChanged);
            // 
            // exportPNG
            // 
            this.exportPNG.Enabled = false;
            this.exportPNG.Location = new System.Drawing.Point(83, 213);
            this.exportPNG.Name = "exportPNG";
            this.exportPNG.Size = new System.Drawing.Size(117, 35);
            this.exportPNG.TabIndex = 16;
            this.exportPNG.Text = "Export";
            this.exportPNG.UseVisualStyleBackColor = true;
            this.exportPNG.Click += new System.EventHandler(this.exportPNG_Click);
            // 
            // exportSVG
            // 
            this.exportSVG.Enabled = false;
            this.exportSVG.Location = new System.Drawing.Point(84, 68);
            this.exportSVG.Name = "exportSVG";
            this.exportSVG.Size = new System.Drawing.Size(117, 35);
            this.exportSVG.TabIndex = 16;
            this.exportSVG.Text = "Export";
            this.exportSVG.UseVisualStyleBackColor = true;
            this.exportSVG.Click += new System.EventHandler(this.exportSVG_Click);
            // 
            // exportPathPNG
            // 
            this.exportPathPNG.Location = new System.Drawing.Point(22, 147);
            this.exportPathPNG.Name = "exportPathPNG";
            this.exportPathPNG.Size = new System.Drawing.Size(301, 20);
            this.exportPathPNG.TabIndex = 12;
            this.exportPathPNG.TextChanged += new System.EventHandler(this.exportPathPNG_TextChanged);
            // 
            // exportPathSVG
            // 
            this.exportPathSVG.Location = new System.Drawing.Point(23, 42);
            this.exportPathSVG.Name = "exportPathSVG";
            this.exportPathSVG.Size = new System.Drawing.Size(301, 20);
            this.exportPathSVG.TabIndex = 12;
            this.exportPathSVG.TextChanged += new System.EventHandler(this.exportPathSVG_TextChanged);
            // 
            // exportBrowsePNG
            // 
            this.exportBrowsePNG.Location = new System.Drawing.Point(206, 213);
            this.exportBrowsePNG.Name = "exportBrowsePNG";
            this.exportBrowsePNG.Size = new System.Drawing.Size(117, 35);
            this.exportBrowsePNG.TabIndex = 18;
            this.exportBrowsePNG.Text = "Browse";
            this.exportBrowsePNG.UseVisualStyleBackColor = true;
            this.exportBrowsePNG.Click += new System.EventHandler(this.exportBrowsePNG_Click);
            // 
            // exportBrowseSVG
            // 
            this.exportBrowseSVG.Location = new System.Drawing.Point(207, 68);
            this.exportBrowseSVG.Name = "exportBrowseSVG";
            this.exportBrowseSVG.Size = new System.Drawing.Size(117, 35);
            this.exportBrowseSVG.TabIndex = 18;
            this.exportBrowseSVG.Text = "Browse";
            this.exportBrowseSVG.UseVisualStyleBackColor = true;
            this.exportBrowseSVG.Click += new System.EventHandler(this.exportBrowseSVG_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(198, 183);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(12, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "x";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 131);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Export PNG";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Export SVG";
            // 
            // tooltipActions
            // 
            this.tooltipActions.ToolTipTitle = "Actions";
            // 
            // tooltipPreview
            // 
            this.tooltipPreview.ToolTipTitle = "Preview";
            // 
            // svgList
            // 
            this.svgList.AllowDrop = true;
            this.svgList.Location = new System.Drawing.Point(357, 310);
            this.svgList.Name = "svgList";
            this.svgList.Size = new System.Drawing.Size(518, 258);
            this.svgList.TabIndex = 8;
            this.svgList.UseCompatibleStateImageBehavior = false;
            this.svgList.SelectedIndexChanged += new System.EventHandler(this.svgList_SelectedIndexChanged);
            this.svgList.DragDrop += new System.Windows.Forms.DragEventHandler(this.svgList_DragDrop);
            this.svgList.DragEnter += new System.Windows.Forms.DragEventHandler(this.svgList_DragEnter);
            this.svgList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.svgList_KeyUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 580);
            this.Controls.Add(this.svgList);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fast SVG Editor";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgPreview)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox importSubDirectorySVG;
        private System.Windows.Forms.Button importDirectorySVG;
        private System.Windows.Forms.Button importSVG;
        private System.Windows.Forms.Button browseDirectorySVG;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button importBrowseSVG;
        private System.Windows.Forms.TextBox importPathDirectorySVG;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox importPathSVG;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox svgPreview;
        private System.Windows.Forms.ListBox actionList;
        private System.Windows.Forms.Button addAction;
        private System.Windows.Forms.TextBox newColorCode;
        private System.Windows.Forms.TextBox oldColorCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label newColorPreview;
        private System.Windows.Forms.Label oldColorPreview;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox cropHeightPNG;
        private System.Windows.Forms.TextBox cropWidthPNG;
        private System.Windows.Forms.CheckBox cropPNG;
        private System.Windows.Forms.Button exportPNG;
        private System.Windows.Forms.Button exportSVG;
        private System.Windows.Forms.TextBox exportPathPNG;
        private System.Windows.Forms.TextBox exportPathSVG;
        private System.Windows.Forms.Button exportBrowsePNG;
        private System.Windows.Forms.Button exportBrowseSVG;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button clearActions;
        private System.Windows.Forms.Button deleteActions;
        private System.Windows.Forms.ToolTip tooltipActions;
        private System.Windows.Forms.PictureBox previewMode;
        private System.Windows.Forms.ToolTip tooltipPreview;
        private System.Windows.Forms.Button discardAction;
        private System.Windows.Forms.ListView svgList;
    }
}

