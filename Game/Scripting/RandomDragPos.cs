using System;
using System.Collections;
using System.Collections.Generic;
using Dragons.Game.Casting;
using Dragons.Game.Services;
using Dragons.Game;
using System.Linq;

namespace Dragons.Game.Scripting{

    public class RandomDragPos 
    {
        int position_counter = 4;
        List<Point> points = new List<Point>();
        
        Random rnd = new Random();
            
        public RandomDragPos(){}

        public void GeneratePositions()
        {
            Point pos_1 = new Point(rnd.Next(0,1000), rnd.Next(0,1000));            
            points.Add(pos_1);
            Point pos_2 = new Point(rnd.Next(1001, 2000), rnd.Next(0,1000));           
            points.Add(pos_2);
            Point pos_3 = new Point(rnd.Next(0,1000), rnd.Next(1001,2000));            
            points.Add(pos_3);
            Point pos_4 = new Point(rnd.Next(1001, 2000), rnd.Next(1001,2000));            
            points.Add(pos_4);
            Point pos_5 = new Point(rnd.Next(2001, 3000), rnd.Next(0,2000));
            points.Add(pos_5);
            List<Point> points_shuf = points.OrderBy(x => rnd.Next()).ToList();    
            
        }
        public Point GetPosition()
        {   
            Point point = points[position_counter];
            Console.WriteLine($"Pos index: {position_counter}");
            points.RemoveAt(position_counter);
            position_counter = position_counter - 1;
           
            return point;
        }
    }
}