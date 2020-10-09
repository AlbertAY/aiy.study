using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyBitMapDrawWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }


    //// Make the tree. The angles are in radians.
    //private Bitmap MakeTree(int width, int height, int level,
    //    float angleA, float angleB,
    //    float length_scaleA, float length_scaleB)
    //{
    //    // Make the line segments.
    //    List<PointF> start_points = new List<PointF>();
    //    List<PointF> end_points = new List<PointF>();
    //    float start_length = picCanvas.ClientSize.Height * 0.33f;
    //    const float start_thickness = 10;
    //    const float start_direction = (float)(Math.PI * 0.5);
    //    FindTreePoints(start_points, end_points,
    //        0, 0, start_direction, level, start_length,
    //        angleA, angleB, length_scaleA, length_scaleB);

    //    // Find the tree's bounds.
    //    float xmin = start_points[0].X;
    //    float xmax = xmin;
    //    float ymin = start_points[0].Y;
    //    float ymax = ymin;
    //    foreach (PointF point in end_points)
    //    {
    //        if (xmin > point.X) xmin = point.X;
    //        if (xmax < point.X) xmax = point.X;
    //        if (ymin > point.Y) ymin = point.Y;
    //        if (ymax < point.Y) ymax = point.Y;
    //    }

    //    // Make the bitmap.
    //    Bitmap bm = new Bitmap(
    //        picCanvas.ClientSize.Width,
    //        picCanvas.ClientSize.Height);
    //    using (Graphics gr = Graphics.FromImage(bm))
    //    {
    //        gr.Clear(picCanvas.BackColor);
    //        gr.SmoothingMode = SmoothingMode.AntiAlias;

    //        // Map the tree onto the PictureBox.
    //        xmin -= start_thickness;
    //        xmax += start_thickness;
    //        ymin -= start_thickness;
    //        ymax += start_thickness;
    //        RectangleF world_rect = new RectangleF(
    //            xmin, ymin, xmax - xmin, ymax - ymin);
    //        const int margin = 4;
    //        RectangleF device_rect = new RectangleF(
    //            margin, margin,
    //            picCanvas.ClientSize.Width - 2 * margin,
    //            picCanvas.ClientSize.Height - 2 * margin);
    //        SetTransformationWithoutDisortion(gr,
    //            world_rect, device_rect, false, true);

    //        // Draw the tree.
    //        using (Pen pen = new Pen(Color.Blue, 1))
    //        {
    //            for (int i = 0; i < start_points.Count; i++)
    //            {
    //                pen.Width = Distance(
    //                    start_points[i], end_points[i]) / 10f;
    //                gr.DrawLine(pen, start_points[i], end_points[i]);
    //            }
    //        }
    //    }
    //    return bm;
    //}


}
