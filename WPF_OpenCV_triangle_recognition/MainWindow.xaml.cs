using System;
using System.Collections.Generic;
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
using Microsoft.Win32;
using OpenCvSharp;
using Point = OpenCvSharp.Point;
using System.IO;
using Size = OpenCvSharp.Size;

namespace WPF_OpenCV_triangle_recognition
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {

        #region Global Variables

        private List<Triangle> AllTriangles;
        private List<Triangle> GreenTriangles;

        private FileDialogCustomPlace inputFile { get; set; }



        #endregion

        #region Main


        public MainWindow()
        {
            InitializeComponent();
            AllTriangles = new List<Triangle>();
            GreenTriangles = new List<Triangle>();
        }


#endregion

#region Buttons

        private void Btn_check_Click(object sender, RoutedEventArgs e)
        {
            Mat src = new Mat(@"K:\REPO2018\WPF_OpenCV_triangle_recognition\test-image.png", ImreadModes.Color);
            ///ścieżka na sztywno, docelowo pobierana pickerem

            Mat dst = new Mat();
            Mat dstRedPointed = new Mat();

            Cv2.Canny(src, dst, 50, 200);


            /// Canny zwraca obraz binarny z konurami figur
            /// następnymi krokami będą:
            /// - w debagu naliczyło 55 figur z różną liczbą rogów (często kilkadziesiąt)
            /// 3. W ten sposób otrzymamy tablicę z figurami i współrzędnymi rogów - wybieramy trójkąty i liczymy środki trójkątów
            /// 4. Wracamy do kolorowago obrazu i pobieramy kolor ze środka obrazu
            /// - mamy 3 tablice kolorów RGB, z tablicy zielonej wybieramy środek figury i sprawdzamy głębię - próg np. 50% natężenia
            /// - z pozostałych tablic próg natężenia nie większy niż np. ok 5%
            /// 5. Pozostają zielone trójkąty.
            /// 6. Obrysowujemy je okręgami




            List<Point2f> point2Fs = new List<Point2f>();
            //Cv2.CornerSubPix(dst, point2Fs, new Size(), Size.Zero, TermCriteria.Both(500, 0.1d));
            dstRedPointed = dst;

            Point[][] bla = new Point[100][];
                bla= Cv2.FindContoursAsArray(dst, RetrievalModes.CComp, ContourApproximationModes.ApproxTC89KCOS);
            bla = Cv2.FindContoursAsArray(dst, RetrievalModes.CComp, ContourApproximationModes.ApproxTC89KCOS);


            IEnumerable<KeyPoint> blaList = new List<KeyPoint>();
            var correctedBLA = bla.ToArray().ToArray();

            foreach (var VARIABLE in correctedBLA)
            {
                blaList.Append(new KeyPoint(VARIABLE.))
            }
            //for (int i = 0; i < bla.Length; i++)
            //{
            //    for (int j = 0; j < bla.Length; j++)
            //    {
            //        bla[i][j]
            //    }
            //}


            Cv2.DrawKeypoints(dst,blaList,dstRedPointed,Scalar.Red);
            bla = Cv2.FindContoursAsArray(dst, RetrievalModes.CComp, ContourApproximationModes.ApproxTC89KCOS);

            bla = Cv2.FindContoursAsArray(dst, RetrievalModes.CComp, ContourApproximationModes.ApproxTC89KCOS);

            bla = Cv2.FindContoursAsArray(dst, RetrievalModes.CComp, ContourApproximationModes.ApproxTC89KCOS);

            bla = Cv2.FindContoursAsArray(dst, RetrievalModes.CComp, ContourApproximationModes.ApproxTC89KCOS);

            bla = Cv2.FindContoursAsArray(dst, RetrievalModes.CComp, ContourApproximationModes.ApproxTC89KCOS);

            bla = Cv2.FindContoursAsArray(dst, RetrievalModes.CComp, ContourApproximationModes.ApproxTC89KCOS);

            bla = Cv2.FindContoursAsArray(dst, RetrievalModes.CComp, ContourApproximationModes.ApproxTC89KCOS);








            using (new OpenCvSharp.Window("src image", src))
            using (new OpenCvSharp.Window("dst image", dst))
            {
                Cv2.WaitKey();
            }
        }

        private void Btn_OutputFileSelector_Click(object sender, RoutedEventArgs e)
        {
            //var fileDialog = new System.Windows.Forms.OpenFileDialog();
            //var result = fileDialog.ShowDialog();
            //switch (result)
            //{
            //    case System.Windows.Forms.DialogResult.OK:
            //        var file = fileDialog.FileName;
            //        TxtFile.Text = file;
            //        TxtFile.ToolTip = file;
            //        break;
            //    case System.Windows.Forms.DialogResult.Cancel:
            //    default:
            //        TxtFile.Text = null;
            //        TxtFile.ToolTip = null;
            //        break;
            //}
        }

        private void Btn_InputFileSelector_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            bool? result = fileDialog.ShowDialog();
            switch (result)
            {
                //case DialogResult.:
                //    var file = fileDialog.FileName;
                //    TxtFile.Text = file;
                //    TxtFile.ToolTip = file;
                //    break;
                //case DialogResult.Cancel:
                default:
                    //TxtFile.Text = null;
                    //TxtFile.ToolTip = null;
                    break;
            }
        }

        #endregion

#region Functions

        string selectFilePath()
        {
            return this.label_InputFileSelector.ToString();
        }

        string selectFolderPath()
        {
            return this.label_OutputFileSelector.ToString();
        }

        void addCircles()
        {

        }

        void CollorCheck()
        {

        }

        void findCenterOfTriangle()
        {

        }

        void findRadious()
        {

        }

#endregion



    }

    class Triangle
    {
        private Point aPoint { get; set; }
        private Point bPoint { get; set; }
        private Point cPoint { get; set; }
        private Point CenterPoint { get; set; }



        double area()
        {
            return aPoint.DistanceTo(bPoint);
        }

        //double CalcCenterPoint()
        //{
        //    return centerOfMass;
        //}

    }
}
