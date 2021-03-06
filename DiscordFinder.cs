﻿using System;
using System.Collections.Generic;

namespace FindingMotifDiscord
{
    public abstract class AbstractDiscordFinder
    {
        protected int slidingWindow;
        protected float[] data;
        protected AbstractDistanceFunction distFunc;

        public AbstractDiscordFinder(float[] data, int slidingWindow, AbstractDistanceFunction disFunc)
        {
            this.data = data;
            this.slidingWindow = slidingWindow;
            distFunc = disFunc;
        }

        public abstract void findDiscord(out int discordLoc, out float largestDistance);
    }

    public class DiscordFinder : AbstractDiscordFinder
    {
        public DiscordFinder(float[] data, int slidingWindow, AbstractDistanceFunction disFunc)
            : base(data, slidingWindow,disFunc)
        {
        }

        public override void findDiscord(out int discordLoc, out float largestDistance)
        {
            discordLoc = -1;
            largestDistance = 0;
            float nearest_nei_dis;

            for (int i = 0; i < data.Length - slidingWindow; i++)
            {
                nearest_nei_dis = float.MaxValue;
                for (int j = 0; j < data.Length - slidingWindow; j++)
                {
                    if (Math.Abs(i - j) >= slidingWindow)
                    {
                        if (distFunc.distance(i, j) < nearest_nei_dis)
                        {
                            nearest_nei_dis = distFunc.distance(i, j);                            
                        }
                    }
                }
                if (nearest_nei_dis > largestDistance)
                {
                    largestDistance = nearest_nei_dis;
                    discordLoc = i;
                }
            }
            System.Console.WriteLine("a");
        }              
    }
}

