namespace Nez.Textures
{
	public class SpriteAnimation
	{
		public Sprite[] Sprites;
		public float[] FrameRates;

		/// <summary>
		/// BVS added field.  Restore compatibility with previous versions of Nez and provide
		/// a single property that will set the framerate for all frames of an animation. 
		/// GET - returns framerate of frame 0
		/// SET - sets all framerate of all frames to value
		/// </summary>
		public float FrameRate
		{
			get { return FrameRates[0]; }
			set
			{
				for (int i = 0; i < FrameRates.Length; ++i)
				{
					FrameRates[i] = value;
				}
			}
		}

		public SpriteAnimation(Sprite[] sprites, float frameRate)
		{
			Sprites = sprites;
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
	}
}
