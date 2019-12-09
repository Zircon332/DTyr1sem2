using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class Track
	{
        /// <summary>
        /// List of trackpoints
        /// </summary>
        private List<TrackPoint> _points;


        /// <summary>
        /// Track Constructor
        /// </summary>
        /// <param name="points">list of integerss that define the coordinates of points</param>
        public Track(List<float> points)
        {
            _points = new List<TrackPoint>();
            for (int i = 0; i < points.Count; i+=2)
            {
                _points.Add(new TrackPoint(points[i], points[i + 1]+45));
            }
        }

        /// <summary>
        /// Trackpoints property
        /// </summary>
        public List<TrackPoint> Points
        {
            get { return _points; }
        }
	}
}

