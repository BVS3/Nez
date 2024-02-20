using Nez.Textures;

namespace Nez.Sprites
{
	public class SpriteAnimation
	{
		public Sprite[] Sprites;
		public float FrameRate;

		public SpriteAnimation(Sprite[] sprites, float frameRate)
		{
			Sprites = sprites;
			FrameRate = frameRate;
		}
	}
}
