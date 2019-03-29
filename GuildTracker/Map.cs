using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Reflection;

namespace GuildTracker
{
    public partial class Map : UserControl
    {
        private MapData mapData;
        private Bitmap mapImage = null;
        private Dictionary<string, Color> colors;
        private Dictionary<string, Brush> brushes;
        private Font font;
        private MapData.Point focusPoint;
        private double ratio;
        private int scaleHeight;
        private int scaleWidth;
        private int drawSpotX;
        private int drawSpotY;
        private byte[] fibonacciZoom;
        private int zoomIndex;

        private bool leftMouseDown = false;
        private int moveFromX = 0;
        private int moveFromY = 0;

        public delegate void DrawHandler(Graphics g);
        public event DrawHandler OnDraw;

        private Random rnd = new Random();

        public Map()
        {
            InitializeComponent();
            colors = new Dictionary<string, Color>();
            colors["gray"] = Color.Gray;
            colors["grey"] = Color.Gray;
            colors["white"] = Color.White;
            colors["black"] = Color.Black;
            colors["0"] = Color.Black;
            colors["darkBlue"] = Color.DarkBlue;
            colors["magenta"] = Color.Magenta;
            colors["green"] = Color.Green;
            colors["darkGreen"] = Color.DarkGreen;
            colors["yellow"] = Color.Yellow;
            colors["Yellow3"] = Color.LightYellow;
            colors["darkYellow"] = Color.GreenYellow;
            colors["cyan"] = Color.Cyan;
            colors["darkRed"] = Color.DarkRed;
            colors["blue"] = Color.Blue;
            colors["red"] = Color.Red;
            colors["dim grey"] = Color.DarkGray;
            colors["tan"] = Color.Tan;
            colors["SkyBlue"] = Color.SkyBlue;
            colors["peru"] = Color.Peru;
            colors["PaleGreen"] = Color.PaleGreen;
            colors["PaleGoldenrod"] = Color.PaleGoldenrod;
            colors["MediumOrchid"] = Color.MediumOrchid;

            brushes = new Dictionary<string, Brush>();
            brushes["gray"] = Brushes.Gray;
            brushes["grey"] = Brushes.Gray;
            brushes["white"] = Brushes.White;
            brushes["black"] = Brushes.Black;
            brushes["0"] = Brushes.Black;
            brushes["darkBlue"] = Brushes.DarkBlue;
            brushes["magenta"] = Brushes.Magenta;
            brushes["green"] = Brushes.Green;
            brushes["darkGreen"] = Brushes.DarkGreen;
            brushes["yellow"] = Brushes.Yellow;
            brushes["Yellow3"] = Brushes.LightYellow;
            brushes["darkYellow"] = Brushes.GreenYellow;
            brushes["cyan"] = Brushes.Cyan;
            brushes["darkRed"] = Brushes.DarkRed;
            brushes["blue"] = Brushes.Blue;
            brushes["red"] = Brushes.Red;
            brushes["dim grey"] = Brushes.DarkGray;
            brushes["tan"] = Brushes.Tan;
            brushes["SkyBlue"] = Brushes.SkyBlue;
            brushes["peru"] = Brushes.Peru;
            brushes["PaleGreen"] = Brushes.PaleGreen;
            brushes["PaleGoldenrod"] = Brushes.PaleGoldenrod;
            brushes["MediumOrchid"] = Brushes.MediumOrchid;

            FontFamily fontFamily = new FontFamily("Arial");
            font = new Font(
               fontFamily,
               24,
               FontStyle.Regular,
               GraphicsUnit.Pixel);

            focusPoint = new MapData.Point() { x = 0, y = 0 };

            fibonacciZoom = new byte[] {1, 2, 3, 5, 8};
            zoomIndex = 0;

            typeof(Panel).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, mapPanel, new object[] { true });
        }

        public MapData MapData
        {
            get
            {
                return mapData;
            }

            set
            {
                mapData = value;
                //  New Map data. Generate a new bitmap.
                if (value != null)
                {
                    GenerateBitmap();
                    zoomIndex = 0;
                    mapPanel.Invalidate();
                }
            }
        }

        private void GenerateBitmap()
        {
            if (mapImage != null)
                mapImage.Dispose();

            Bitmap builtImage = new Bitmap((int)(Math.Abs(mapData.MapBounds.east) + mapData.MapBounds.west), (int)(Math.Abs(mapData.MapBounds.south) + mapData.MapBounds.north));
            using (Graphics gr = Graphics.FromImage(builtImage))
            {
                Pen pen = new Pen(Color.White, 2);
                gr.FillRectangle(Brushes.Black, 0, 0, builtImage.Width, builtImage.Height);
                foreach (MapData.MapNode aNode in mapData.Data)
                {
                    //  Do Node specific stuff here.
                    if (aNode.entity == 'P')
                    {
                        gr.FillEllipse((brushes.ContainsKey(aNode.color)) ? brushes[aNode.color] : Brushes.White,
                                       (float)(builtImage.Width - (aNode.points[0].x - mapData.MapBounds.east) - 5),
                                       (float)(builtImage.Height - (aNode.points[0].y - mapData.MapBounds.south) - 5),
                                       10,
                                       10);

                        gr.DrawString(aNode.name,
                                      font,
                                      Brushes.White,
                                      (float)(builtImage.Width - (aNode.points[0].x - mapData.MapBounds.east)),
                                      (float)(builtImage.Height - (aNode.points[0].y - mapData.MapBounds.south)));
                    }
                    for (int pointIndex = 0; pointIndex < (aNode.numPoints-1); pointIndex++)
                    {
                        pen.Color = (colors.ContainsKey(aNode.color)) ? colors[aNode.color] : Color.White;
                        gr.DrawLine(pen,
                                    (float)(builtImage.Width - (aNode.points[pointIndex].x - mapData.MapBounds.east)),
                                    (float)(builtImage.Height - (aNode.points[pointIndex].y - mapData.MapBounds.south)),
                                    (float)(builtImage.Width - (aNode.points[pointIndex + 1].x - mapData.MapBounds.east)),
                                    (float)(builtImage.Height - (aNode.points[pointIndex + 1].y - mapData.MapBounds.south)));
                    }
                }
            }
            mapImage = new Bitmap(builtImage.Width / 2, builtImage.Height / 2);
            using (Graphics gr = Graphics.FromImage(mapImage))
            {
                gr.DrawImage(builtImage, 0, 0, mapImage.Width, mapImage.Height);
            }
            builtImage.Dispose();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            mapPanel.Invalidate();
        }

        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            base.OnInvalidated(e);
            mapPanel.Invalidate();
        }

        private void mapPanel_Paint(object sender, PaintEventArgs e)
        {
            if (mapImage != null)
            {
                double aspectRatioX = (double)mapPanel.Width / (double)mapImage.Width;
                double aspectRatioY = (double)mapPanel.Height / (double)mapImage.Height;

                ratio = aspectRatioX < aspectRatioY ? aspectRatioX : aspectRatioY;

                scaleHeight = Convert.ToInt32(mapImage.Height * ratio);
                scaleWidth = Convert.ToInt32(mapImage.Width * ratio);
                
                Rectangle destination = new Rectangle() { X = 0, Y = 0, Width = scaleWidth, Height = scaleHeight };
                
                e.Graphics.TranslateTransform(mapPanel.Width/2, mapPanel.Height/2);
                e.Graphics.ScaleTransform(fibonacciZoom[zoomIndex], fibonacciZoom[zoomIndex]);
                e.Graphics.TranslateTransform(-mapPanel.Width / 2, -mapPanel.Height / 2);
                e.Graphics.TranslateTransform(drawSpotX, drawSpotY);
                e.Graphics.DrawImage(mapImage, destination);
                OnDraw?.Invoke(e.Graphics);
                e.Graphics.ResetTransform();
            }
            e.Graphics.DrawLine(Pens.Yellow, 0, mapPanel.Height / 2, mapPanel.Width, mapPanel.Height/2);
            e.Graphics.DrawLine(Pens.Yellow, mapPanel.Width / 2, 0, mapPanel.Width/2, mapPanel.Height);
        }

        private void ZoomOut_Click(object sender, EventArgs e)
        {
            zoomIndex = (zoomIndex == 0) ? fibonacciZoom.Length - 1 : zoomIndex - 1;
            ZoomFactor.Text = 'x' + fibonacciZoom[zoomIndex].ToString();
            mapPanel.Invalidate();
        }

        private void ZoomIn_Click(object sender, EventArgs e)
        {
            zoomIndex = ((zoomIndex + 1) % fibonacciZoom.Length);
            ZoomFactor.Text = 'x' + fibonacciZoom[zoomIndex].ToString();
            mapPanel.Invalidate();
        }

        private void mapPanel_Click(object sender, EventArgs e)
        {
            
        }

        public float ConvertCoordXToPanel(float x)
        {
            int panelCenterX = mapPanel.Width / 2;

            int distanceFromBorderX = (panelCenterX - drawSpotX) * fibonacciZoom[zoomIndex];

            int xLength = (int)mapData.NotSure[mapData.NotSure.Count - 1].x;

            if (xLength == 0)
                xLength = (int)(Math.Abs(mapData.MapBounds.west) + Math.Abs(mapData.MapBounds.east));

            double convertRatioX = (double)(scaleWidth * fibonacciZoom[zoomIndex]) / (double)xLength;

            //  Translate to weird EQ (Top left is 0,0)
            float xCoord = (float)((mapData.MapBounds.west - x) * convertRatioX);

            //  Remove point displacement.
            float tx = xCoord / fibonacciZoom[zoomIndex];
            return tx;
        }

        public float ConvertCoordYToPanel(float y)
        {
            int panelCenterY = mapPanel.Height / 2;

            int distanceFromBorderY = (panelCenterY - drawSpotY) * fibonacciZoom[zoomIndex];

            int yLength = (int)mapData.NotSure[mapData.NotSure.Count - 1].y;

            if (yLength == 0)
                yLength = (int)(Math.Abs(mapData.MapBounds.north) + Math.Abs(mapData.MapBounds.south));

            double convertRatioY = (double)(scaleHeight * fibonacciZoom[zoomIndex]) / (double)yLength;

            //  Translate to weird EQ (Top left is 0,0)
            float yCoord = (float)((mapData.MapBounds.north - y) * convertRatioY);

            //  Remove point displacement.
            float tY = yCoord / fibonacciZoom[zoomIndex];
            return tY;
        }

        private void mapPanel_MouseMove(object sender, MouseEventArgs e)
        {
            //  Translate panel coords to map coords.
            if (!leftMouseDown)
            {
                double tX = (double)(e.X);
                double tY = (double)(e.Y);

                panelPointLabel.Text = "Panel Point: (" + tX + ", " + tY + ")";
                panelWidthlabel.Text = "Panel Width: " + mapPanel.Width;
                panelHeightLabel.Text = "Panel Height: " + mapPanel.Height;

                int panelCenterX = mapPanel.Width / 2;
                int panelCenterY = mapPanel.Height / 2;

                int distanceFromBorderX = (panelCenterX - drawSpotX) * fibonacciZoom[zoomIndex];
                int distanceFromBorderY = (panelCenterY - drawSpotY) * fibonacciZoom[zoomIndex];

                if ((tX > (panelCenterX - distanceFromBorderX)) &&
                   (tX < (panelCenterX - distanceFromBorderX) + scaleWidth * fibonacciZoom[zoomIndex]) &&
                   (tY > (panelCenterY - distanceFromBorderY)) &&
                   (tY < (panelCenterY - distanceFromBorderY) + scaleHeight * fibonacciZoom[zoomIndex]))
                {
                    //  Remove point displacement.
                    double xCoord = tX - (panelCenterX - distanceFromBorderX);
                    double yCoord = tY - (panelCenterY - distanceFromBorderY);

                    int xLength = (int)mapData.NotSure[mapData.NotSure.Count - 1].x;
                    int yLength = (int)mapData.NotSure[mapData.NotSure.Count - 1].y;

                    if (xLength == 0)
                        xLength = (int)(Math.Abs(mapData.MapBounds.west) + Math.Abs(mapData.MapBounds.east));
                    if (yLength == 0)
                        yLength = (int)(Math.Abs(mapData.MapBounds.north) + Math.Abs(mapData.MapBounds.south));

                    double convertRatioX = (double)(scaleWidth * fibonacciZoom[zoomIndex]) / (double)xLength;
                    double convertRatioY = (double)(scaleHeight * fibonacciZoom[zoomIndex]) / (double)yLength;

                    //  Translate to weird EQ (Top left is 0,0)
                    xCoord = mapData.MapBounds.west - (int)(xCoord / convertRatioX);
                    yCoord = mapData.MapBounds.north - (int)(yCoord / convertRatioY);

                    coordinates.Text = "Coordinates: (" + yCoord + "," + xCoord + ")";
                }
                else
                    coordinates.Text = "Coordinates: (?,?)";
            }
            else
            {
                if ((Math.Abs(e.X - moveFromX) > 5) ||
                    (Math.Abs(e.Y - moveFromY) > 5))
                {
                    drawSpotX += ((e.X - moveFromX) / fibonacciZoom[zoomIndex]);
                    drawSpotY += ((e.Y - moveFromY) / fibonacciZoom[zoomIndex]);
                    focusPointLabel.Text = "Focus Point: (" + focusPoint.x + ", " + focusPoint.y + ")";
                    moveFromX = e.X;
                    moveFromY = e.Y;
                    mapPanel.Invalidate();
                }
            }
        }

        private void mapPanel_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs mouseargs = (MouseEventArgs)e;

            focusPoint.x = (double)(((mapPanel.Width / 2) - mouseargs.X) / fibonacciZoom[zoomIndex]);
            focusPoint.y = (double)(((mapPanel.Height / 2) - mouseargs.Y) / fibonacciZoom[zoomIndex]);

            focusPointLabel.Text = "Focus Point: (" + focusPoint.x + ", " + focusPoint.y + ")";

            drawSpotX += (int)focusPoint.x;
            drawSpotY += (int)focusPoint.y;

            mapPanel.Invalidate();
        }

        private void mapPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                leftMouseDown = true;
                moveFromX = e.X;
                moveFromY = e.Y;
            }
        }

        private void mapPanel_MouseUp(object sender, MouseEventArgs e)
        {
            leftMouseDown = false;
        }
    }
}
