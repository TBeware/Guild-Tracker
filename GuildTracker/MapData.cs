using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GuildTracker
{
    public class MapData : IEnumerable
    {
        private string name;
        private string name2;
        private List<Point> notSure;
        private string displayError;
        private Bounds mapBounds;

        public class Bounds
        {
            public double north;
            public double east;
            public double south;
            public double west;
        }

        public class MapNode
        {
            public char entity;
            public string name;
            public string color;
            public double numPoints;
            public List<Point> points;
        }

        public class Point
        {
            public double x;
            public double y;
            public double z;
        }

        private List<MapNode> data;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Name2
        {
            get
            {
                return name2;
            }

            set
            {
                name2 = value;
            }
        }

        public List<Point> NotSure
        {
            get
            {
                return notSure;
            }

            set
            {
                notSure = value;
            }
        }

        public string DisplayError
        {
            get
            {
                return displayError;
            }

            set
            {
                displayError = value;
            }
        }

        public Bounds MapBounds
        {
            get
            {
                return mapBounds;
            }

            set
            {
                mapBounds = value;
            }
        }

        public List<MapNode> Data
        {
            get
            {
                return data;
            }

            set
            {
                data = value;
            }
        }

        private MapData()
        {
            Data = new List<MapNode>();
        }

        static public MapData FromFile(string fileName)
        {
            MapData mapData = new MapData();
            FileStream mapFile = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            using (StreamReader sr = new StreamReader(mapFile))
            {
                string s = sr.ReadLine();
                string[] stringFormattedNode;
                if (s != null)
                {
                    stringFormattedNode = s.Split(',');
                    mapData.Name = stringFormattedNode[0];
                    mapData.Name2 = stringFormattedNode[1];
                    mapData.NotSure = new List<Point>();
                    for (int i = 2; i < stringFormattedNode.Length; i += 2)
                    {
                        mapData.NotSure.Add(new Point() { x = double.Parse(stringFormattedNode[i]), y = double.Parse(stringFormattedNode[i + 1]), z = 0 });
                    }
                    mapData.MapBounds = new Bounds()
                    {
                        east = double.MaxValue,
                        south = double.MaxValue,
                        west = double.MinValue,
                        north = double.MinValue
                    };
                }
                while (!sr.EndOfStream)
                {
                    s = sr.ReadLine();
                    if ((s != null) && (s != ""))
                    {
                        stringFormattedNode = s.Split(',');
                        if (stringFormattedNode.Length < 5)
                            continue;
                        MapNode mapNode = new MapNode();
                        mapNode.entity = stringFormattedNode[0][0];
                        mapNode.name = stringFormattedNode[1];
                        mapNode.color = stringFormattedNode[2];
                        int pointsStart = 4;
                        if (mapNode.entity == 'P')
                        {
                            mapNode.numPoints = 1;
                            pointsStart = 3;
                        }
                        else
                            mapNode.numPoints = double.Parse(stringFormattedNode[3]);
                        mapNode.points = new List<Point>();
                        int displacement = 0;
                        for (; pointsStart < stringFormattedNode.Length; pointsStart += displacement)
                        {
                            double Z = 0;
                            displacement = 2;
                            if (mapNode.entity == 'M')
                            {
                                Z = double.Parse(stringFormattedNode[pointsStart + 2]);
                                displacement = 3;
                            }

                            Point newPoint = new Point() { x = double.Parse(stringFormattedNode[pointsStart]), y = double.Parse(stringFormattedNode[pointsStart + 1]), z = Z};
                            mapNode.points.Add(newPoint);

                            //  Point is west of 0,0
                            if ((newPoint.x > mapData.MapBounds.west))
                                mapData.MapBounds.west = newPoint.x;
                            //  Point is east of 0,0
                            else if ((newPoint.x < mapData.MapBounds.east))
                                mapData.MapBounds.east = newPoint.x;

                            //  Point is north of 0,0
                            if ((newPoint.y > mapData.MapBounds.north))
                                mapData.MapBounds.north = newPoint.y;
                            //  Point is south of 0,0
                            else if ((newPoint.y < mapData.MapBounds.south))
                                mapData.MapBounds.south = newPoint.y;
                        }
                        mapData.Data.Add(mapNode);
                    }
                }
            }
            return mapData;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Data.GetEnumerator();
        }
    }
}
