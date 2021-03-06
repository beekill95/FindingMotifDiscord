﻿using System;

namespace FindingMotifDiscord
{
	public abstract class AbstractDistanceFunction
	{
		protected float[] data;
		protected int slidingWindow;

		public AbstractDistanceFunction(float[] data, int slidingWindow)
		{
			this.data = data;
			this.slidingWindow = slidingWindow;
		}

		public abstract float distance(int t1Loc, int t2Loc);
	}

	public class EucleanDistance : AbstractDistanceFunction
	{
		public EucleanDistance (float[] data, int slidingWindow)
			: base (data, slidingWindow)
		{
		}

		public override float distance(int t1Loc, int t2Loc)
		{
			float eucleanDist = 0;
			for (int i = 0; i < slidingWindow; i++) {
				float d = data [t1Loc + i] - data [t2Loc + i];
				eucleanDist += d * d;
			}
			return (float)Math.Sqrt ((double)eucleanDist);
		}
	}

	public class ImprovedEucleanDistance : AbstractDistanceFunction
	{
		private float[][] preComputedDistance;

		public ImprovedEucleanDistance(float[] data, int slidingWindow)
			: base(data, slidingWindow)
		{
			// generate computed distance matrix
			int preComputedMatrixSize = data.Length - slidingWindow;
			preComputedDistance = new float[preComputedMatrixSize][];
			for (int i = 0; i < preComputedMatrixSize; i++)
				preComputedDistance [i] = new float[i + 1];

			// initialize diagnal
			for (int i = 0; i < preComputedMatrixSize; i++)
				preComputedDistance [i] [i] = 0;

			// compute first row distance
			for (int i = 1; i < preComputedMatrixSize; i++)
				preComputedDistance [i] [0] = __distance (0, i);

		}

		// calculate distance without dynamic programming
		private float __distance(int t1Loc, int t2Loc)
		{
			float dist = 0;
			for (int i = 0; i < slidingWindow; i++) {
				float temp = data [t1Loc + i] - data [t2Loc + i];
				dist += temp * temp;
			}
			return dist;
		}

		// calculate distance with dynamic programming
		public override float distance(int t1Loc, int t2Loc)
		{
			float dist = 0;
			if (t1Loc >= t2Loc) // distance already computed
				dist = preComputedDistance[t1Loc][t2Loc];
			else {
				if (t1Loc == 0) // distance computed
					dist = preComputedDistance [t2Loc] [0];
				else {
					// need to compute distance
					float firstPosDist = data[t1Loc - 1] - data[t2Loc - 1];
					float lastPosDist = data [t1Loc + slidingWindow - 1] - data [t2Loc + slidingWindow - 1];
					dist = preComputedDistance [t2Loc - 1] [t1Loc - 1]
					- firstPosDist * firstPosDist
					+ lastPosDist * lastPosDist;

					preComputedDistance [t2Loc] [t1Loc] = dist;
				}
			}
			return (float)Math.Sqrt ((double)dist);
		}
	}

	public class EucleanDistanceArray : AbstractDistanceFunction
	{
		private float[] preComputedDistance;

		public EucleanDistanceArray(float[] data, int slidingWindow)
			: base (data, slidingWindow)
		{
			// initialize preComputed array
			// by calculating array size
			int temp = data.Length - 2 * slidingWindow;
			int arraySize = (temp + 1) * (temp + 2) / 2;
			preComputedDistance = new float[arraySize];

			// compute some distances beforehand
			for (int t2Loc = slidingWindow; t2Loc < data.Length - slidingWindow; t2Loc++)
				preComputedDistance [indexOf (0, t2Loc)] = directDistance (0, t2Loc);
		}

		public override float distance(int t1Loc, int t2Loc)
		{
			float dist = 0f;
			if (t1Loc == 0) // already computed
				dist = preComputedDistance [indexOf (0, t2Loc)];
			else {
				if (t1Loc >= t2Loc) // already computed
					dist = preComputedDistance [indexOf (t2Loc, t1Loc)];
				else { // have to compute the distance by using dynamic programming
					float firstPosDist = data[t1Loc - 1] - data[t2Loc - 1];
					float lastPosDist = data [t1Loc + slidingWindow - 1] - data [t2Loc + slidingWindow - 1];
					dist = preComputedDistance [indexOf (t1Loc - 1, t2Loc - 1)]
					- firstPosDist * firstPosDist
					+ lastPosDist * lastPosDist;

					int index = indexOf (t1Loc, t2Loc);
					preComputedDistance [index] = dist;
				}
			}

			return (float)Math.Sqrt ((double)dist);
		}

		// return index in preComputedDistance array
		// between t1Loc and t2Loc
		private int indexOf(int t1Loc, int t2Loc)
		{
			if (t1Loc == 0)
				return t2Loc - slidingWindow;
			else {
				int t = 2 * (data.Length - 2 * slidingWindow + 1);
				int index = t1Loc * (t - t1Loc + 1) / 2 + t2Loc - t1Loc - slidingWindow;
				return index;
			}
		}

		// return distance between t1Loc and t2Loc
		// by directly calculate it
		private float directDistance(int t1Loc, int t2Loc)
		{
			float dist = 0f;
			for (int i = 0; i < slidingWindow; i++) {
				float diff = data [t1Loc + i] - data [t2Loc + i];
				dist += diff * diff;
			}
			return dist;
		}
	}
}

