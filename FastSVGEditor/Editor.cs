using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Svg;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;

namespace FastSVGEditor
{
    namespace Editing
    {
        class Editor
        {
            public static SVG svgFactory(string path)
            {
                if (path == null || !File.Exists(path))
                    return null;

                SVG vector = new SVG(File.ReadAllText(path), path);

                return vector;
            }

            public static SVG svgFromDataFactory(string data)
            {
                return new SVG(data, "");
            }

            public static List<SVG> svgListFactory(string path, bool subDir)
            {
                if (path == null || !Directory.Exists(path))
                    return null;

                List<SVG> vectors = new List<SVG>();

                string[] files = Directory.GetFiles(path, "*.svg",
                    subDir ? System.IO.SearchOption.AllDirectories : System.IO.SearchOption.TopDirectoryOnly);

                foreach (string file in files)
                {
                    vectors.Add(svgFactory(file));
                }

                garbageDispose(vectors);

                return vectors;
            }

            public static VectorAction actionFactory(Color oldColor, Color newColor)
            {
                return actionFactory(toHexColor(oldColor), toHexColor(newColor));
            }

            public static VectorAction actionFactory(string oldColor, string newColor)
            {
                if (oldColor == null || newColor == null || !isHexColor(oldColor) || !isHexColor(newColor))
                    return null;

                return new VectorAction(oldColor, newColor);
            }

            public static bool assignAction(List<SVG> vectors, VectorAction action)
            {
                if (vectors == null || action == null)
                    return false;

                masterGarbageDispose(vectors);

                foreach (SVG vector in vectors)
                {
                    if (!vector.actionExists(action))
                        vector.addAction(action);
                }

                return true;
            }

            public static bool assignAllActions(List<SVG> vectors, List<VectorAction> actions)
            {
                if (vectors == null || actions == null)
                    return false;

                bool results = true;

                foreach (VectorAction action in actions)
                    results = results && assignAction(vectors, action);

                return results;
            }

            public static bool doActions(List<SVG> vectors)
            {
                if (vectors == null || vectors.Count == 0)
                    return false;

                masterGarbageDispose(vectors);

                foreach (SVG vector in vectors)
                {
                    if (vector.data.Equals("")) continue;

                    for (int i = 0; i < vector.actionCount; i++)
                    {
                        if (vector.getAction(i).done) continue;

                        vector.data = vector.data.Replace(vector.getAction(i).oldColor,
                            vector.getAction(i).newColor);

                        vector.getAction(i).done = true;
                    }
                }

                return true;
            }

            public static void refreshActions(List<SVG> vectors)
            {
                if (vectors == null)
                    return;

                masterGarbageDispose(vectors);

                foreach (SVG vector in vectors)
                {
                    for (int i = 0; i < vector.actionCount; i++)
                    {
                        vector.getAction(i).done = false;
                    }
                }
            }

            public static void refreshActions(List<VectorAction> actions)
            {
                SVG dummy = new SVG("", "");

                foreach (VectorAction action in actions)
                    dummy.addAction(action);

                dummy.garbageDispose();

                foreach (VectorAction action in actions)
                    action.done = false;
            }

            public static List<ExportReport> exportToSVG(List<SVG> vectors, string destination)
            {
                if (vectors == null || destination == null || !Directory.Exists(destination))
                    return null;

                if (destination.ToCharArray(destination.Length - 1, 1)[0] != '\\')
                    destination += "\\";

                masterGarbageDispose(vectors);

                List<ExportReport> reports = new List<ExportReport>();

                foreach (SVG vector in vectors)
                {
                    string fileName = Path.GetFileNameWithoutExtension(vector.path);
                    ExportReport report = new ExportReport();

                    try
                    {
                        File.WriteAllText(destination + fileName + ".svg", vector.data);

                        report.error = false;
                        report.message = "Successfully exported '" + fileName + "' to '" + 
                            destination + fileName + ".svg'.";
                    }
                    catch(Exception e)
                    {
                        report.error = true;
                        report.message = "An error occurred exporting '" + fileName + 
                            "' with the following message: " + e.Message;
                    }

                    reports.Add(report);
                }

                return reports;
            }

            public static List<ExportReport> exportToPNG(List<SVG> vectors, string destination)
            {
                return exportToPNG(vectors, destination, new Rectangle(), false);
            }

            public static List<ExportReport> exportToPNG(  List<SVG> vectors, string destination, 
                                                    Rectangle cropArea, bool doCrop)
            {
                if (vectors == null || destination == null || !Directory.Exists(destination))
                    return null;

                if (destination.ToCharArray(destination.Length - 1, 1)[0] != '\\')
                    destination += "\\";

                masterGarbageDispose(vectors);

                List<ExportReport> reports = new List<ExportReport>();

                foreach (SVG vector in vectors)
                {
                    string fileName = Path.GetFileName(vector.path);
                    ExportReport report = new ExportReport();
                    bool cropError = false;

                    try
                    {
                        var pngDocument = getPreview(vector);

                        if (doCrop)
                        {
                            cropError = (cropArea.X + cropArea.Width > pngDocument.Width ||
                                cropArea.Y + cropArea.Height > pngDocument.Height);
                            
                            if (!cropError)
                                pngDocument = pngDocument.Clone(cropArea, pngDocument.PixelFormat);
                        }

                        if (!cropError)
                        {
                            pngDocument.Save(destination + Path.GetFileNameWithoutExtension(vector.path) + ".png", ImageFormat.Png);

                            report.error = false;
                            report.message = "Successfully exported '" + fileName + "' to '" +
                                destination + Path.GetFileNameWithoutExtension(vector.path) + ".png'.";
                        }
                        else
                        {
                            report.error = true;
                            report.message = "An error occurred exporting '" + fileName +
                            "' with the following message: The desired cropping dimensions " +
                            "exceeds the image boundaries!";
                        }
                    }
                    catch (Exception e)
                    {
                        report.error = true;
                        report.message = "An error occurred exporting '" + fileName +
                            "' with the following message: " + e.Message;
                    }

                    reports.Add(report);
                }

                return reports;
            }

            public static int garbageDispose(List<SVG> vectors)
            {
                if (vectors == null)
                    return -1;

                int effectCount = 0;

                for (int i = 0; i < vectors.Count; i++)
                {
                    if (vectors[i] == null || vectors[i].data == null || vectors[i].data.Equals(""))
                    {
                        vectors.RemoveAt(i);
                        i--;
                    }

                    effectCount++;
                }

                return effectCount;
            }

            public static int masterGarbageDispose(List<SVG> vectors)
            {
                if (vectors == null)
                    return -1;

                int totalEffect = 0;

                totalEffect = garbageDispose(vectors);

                foreach (SVG vector in vectors)
                {
                    totalEffect += vector.garbageDispose();
                }

                return totalEffect;
            }

            public static string pickColorHex(Bitmap image, Point coordinates)
            {
                if (image == null || coordinates == null || coordinates.X > image.Width || 
                    coordinates.Y > image.Height || coordinates.X < 0 || coordinates.Y < 0)
                    return null;

                return Editor.toHexColor(image.GetPixel(coordinates.X, coordinates.Y));
            }

            public static Color? pickColor(Bitmap image, Point coordinates)
            {
                if (image == null || coordinates == null || coordinates.X > image.Width ||
                    coordinates.Y > image.Height || coordinates.X < 0 || coordinates.Y < 0)
                    return null;

                return image.GetPixel(coordinates.X, coordinates.Y);
            }

            public static string toHexColor(Color color)
            {
                return color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
            }

            public static bool isHexColor(string value)
            {
                if (value == null || value.Trim().Replace(" ", String.Empty).Length != 6)
                    return false;

                Regex colorCode = new Regex("^#[a-fA-F0-9]{6}$");

                return colorCode.IsMatch("#" + value);
            }

            public static Bitmap getPreview(SVG vector)
            {
                try
                {
                    return SvgDocument.FromSvg<SvgDocument>(vector.data).Draw();
                }
                catch(Exception)
                {
                    return null;
                }
            }

            public static bool svgExists(List<SVG> vectors, SVG vector)
            {
                if (vectors == null || vector == null)
                    return false;

                garbageDispose(vectors);

                foreach (SVG v in vectors)
                {
                    if (v.isEqual(vector)) return true;
                }

                return false;
            }

            public static bool clearAllActions(List<SVG> vectors)
            {
                if (vectors == null)
                    return false;

                masterGarbageDispose(vectors);

                foreach (SVG vector in vectors)
                {
                    vector.clearActions();
                }

                return true;
            }
        }

        class ExportReport
        {
            private string _message = "";
            private bool _error = false;

            public string message
            {
                get
                {
                    return _message;
                }

                set
                {
                    _message = value;
                }
            }

            public bool error
            {
                get
                {
                    return _error;
                }

                set
                {
                    _error = value;
                }
            }
        }

        class SVG
        {
            private string _data = "";
            private string _path = "";
            private int _actionCount = 0;
            private List<VectorAction> actions = new List<VectorAction>();

            public SVG(string data, string path)
            {
                this.data = data;
                this.path = path;
            }

            public string data
            {
                get
                {
                    return _data;
                }

                set
                {
                    _data = value;
                }
            }

            public string path
            {
                get
                {
                    return _path;
                }

                set
                {
                    _path = value;
                }
            }

            public int actionCount
            {
                get
                {
                    return _actionCount;
                }
            }

            public VectorAction getAction(int index)
            {
                if (index >= 0 && index < actions.Count())
                    return actions[index];
                else
                    return null;
            }

            public bool addAction(VectorAction newAction)
            {
                if (newAction != null)
                {
                    VectorAction dummy = new VectorAction(newAction.oldColor, newAction.newColor);

                    actions.Add(dummy);
                    _actionCount = actions.Count;

                    return true;
                }
                else
                    return false;
            }

            public bool removeAction(int index)
            {
                if (index >= 0 && index < actions.Count())
                {
                    actions.RemoveAt(index);
                    _actionCount = actions.Count;

                    return true;
                }
                else
                    return false;
            }

            public void clearActions()
            {
                actions.Clear();
            }

            public bool actionExists(VectorAction action)
            {
                if (action == null)
                    return false;

                garbageDispose();

                foreach (VectorAction a in actions)
                {
                    if (a.newColor.Equals(action.newColor) && a.oldColor.Equals(action.oldColor))
                        return true;
                }

                return false;
            }

            public int garbageDispose()
            {
                if (actions.Count == 0)
                    return -1;

                int effectCount = 0;

                for (int i = 0; i < actions.Count; i++)
                {
                    if (actions[i] == null || actions[i].newColor == null || actions[i].oldColor == null ||
                        actions[i].newColor.Equals("") || actions[i].oldColor.Equals(""))
                    {
                        actions.RemoveAt(i);
                        i--;
                        continue;
                    }
                }

                effectCount = _actionCount - actions.Count;
                _actionCount = actions.Count;

                return effectCount;
            }

            public bool isEqual(SVG vector)
            {
                if (vector == null)
                    return false;

                return (vector.data.Equals(_data) && vector.path.Equals(_path));
            }
        }

        class VectorAction
        {
            private string _oldColor = "";
            private string _newColor = "";
            private bool _done = false;

            public VectorAction(string oldColor, string newColor)
            {
                this.oldColor = oldColor;
                this.newColor = newColor;
            }

            public string oldColor
            {
                get
                {
                    return _oldColor;
                }

                set
                {
                    if (Editor.isHexColor(value))
                        _oldColor = value.ToUpper();
                }
            }

            public string newColor
            {
                get
                {
                    return _newColor;
                }

                set
                {
                    if (Editor.isHexColor(value))
                        _newColor = value.ToUpper();
                }
            }

            public bool done
            {
                get
                {
                    return _done;
                }

                set
                {
                    _done = value;
                }
            }
        }
    }
}
