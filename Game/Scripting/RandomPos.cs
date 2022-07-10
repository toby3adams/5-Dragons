using System;
using System.Collections;
using System.Collections.Generic;
using Dragons.Game.Casting;
using Dragons.Game.Services;
using Dragons.Game;
using System.Linq;

namespace Dragons.Game.Scripting{

    public class RandomPos 
    {
        int position_counter;
        List<Point> points = new List<Point>();
        
        Random rnd = new Random();
            
        public RandomPos(){}
        // generates and returns individual point, or generates points and adds to list if desired.
        // ShufflePoints() method rearranges the List for random position selection if desired.
        public Point GeneratePosition(int min_x, int max_x, int min_y, int max_y, bool AddToList, int DivBy)
        {   
            int x = rnd.Next(min_x, max_x);
            int y = rnd.Next(min_y, max_y);            
            if(x % DivBy != 0) // checks for divisibility by desired value
                {
                    while(x % DivBy != 0) // loops and increments coordinate until the value is divisible by desired value.
                    {
                        x++;
                    }                    
                }
                if(y % DivBy != 0)
                {
                    while(y % DivBy != 0) // loops and increments coordinate until the value is divisible by desired value.
                    {
                        y++;
                    }
                }
            Point point = new Point(x,y);
            if(AddToList)
            {
                points.Add(point);
            }
            return point;
        }
        public Point GetPosition()
        {   
            position_counter = points.Count()-1;
            Point point = points[position_counter];
            //Test code
            Console.WriteLine($"Pos index: {position_counter}");
            //
            Console.WriteLine($"X:{point.GetX()}, Y:{point.GetY()}");
            points.RemoveAt(position_counter);
            if(position_counter != 0)
            {
                position_counter = position_counter - 1;                
            }                   
            return point;
        }
        public void ShufflePoints() // randomized list order
        {
            points = points.OrderBy(x => rnd.Next()).ToList();
        }
    }
}