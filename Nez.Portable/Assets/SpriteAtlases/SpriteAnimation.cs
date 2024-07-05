using System.Collections.Generic;
using System.Linq;

namespace Nez.Textures
{
	public class SpriteAnimation
	{
		public Sprite[] Sprites;
		public float[] FrameRates;

		float _frameRate = 10;

		/// <summary>
		/// BVS added field.  Restore compatibility with previous versions of Nez and provide
		/// a single property that will set the framerate for all frames of an animation. 
		/// GET - returns framerate of frame 0
		/// SET - sets all framerate of all frames to value
		/// </summary>
		public float FrameRate
		{
			get { return _frameRate; }
			set
			{
				_frameRate = value;
				for (int i = 0; i < FrameRates.Length; ++i)
				{
					FrameRates[i] = value;
				}
			}
		}

		public SpriteAnimation(Sprite[] sprites, float frameRate)
		{
			Sprites = sprites;
			FrameRates = new float[1];
			FrameRates[0] = frameRate;
			_frameRate = frameRate;

			if (sprites == null)
				return;

			FrameRates = new float[sprites.Length];
			for (int i = 0; i < FrameRates.Length; ++i)
			{
				FrameRates[i] = frameRate;
			}
		}

		public SpriteAnimation(Sprite[] sprites, float[] frameRates)
		{
			Sprites = sprites;
			FrameRates = frameRates;
		}

		/// <summary>
		/// Set framerate for all frames in this animation
		/// </summary>
		/// <param name="frameRate"></param>
		public void SetFrameRate(float frameRate)
		{
			_frameRate = frameRate;
			FrameRates = new float[Sprites.Length];
			for (int i = 0; i < FrameRates.Length; ++i)
			{
				FrameRates[i] = frameRate;
			}
		}

		/// <summary>
		/// Append a frame to this animation
		/// </summary>
		/// <param name="sprite">frame sprite </param>
		/// <param name="frameRate">framrate for this frame</param>
		public void ApppendFrame(Sprite sprite, float frameRate)
		{
			if (Sprites != null)
			{
				Sprites = Sprites.Concat(new Sprite[] { sprite }).ToArray();
				FrameRates = FrameRates.Concat(new float[] { frameRate }).ToArray();
			}
			else
			{
				Sprites = new Sprite[] { sprite };
				FrameRates = new float[] { frameRate };
			}


		}

		/// <summary>
		/// Remove frame from this animation at provided index
		/// </summary>
		/// <param name="sprite"></param>
		/// <param name="index"></param>
		public void RemoveFrame(int index)
		{
			//Dump current sprites to list, if present
			var spriteList = new List<Sprite>();
			if (Sprites != null)
				spriteList = Sprites.ToList();

			spriteList.RemoveAt(index);
			Sprites = spriteList.ToArray();

			//Dump current Framerate to list
			var frameRateList = new List<float>();
			if (FrameRates != null)
				frameRateList = FrameRates.ToList();

			frameRateList.RemoveAt(index);
			FrameRates = frameRateList.ToArray();
		}
	}
}
