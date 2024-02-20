using System.Collections.Generic;

namespace Nez.Tiled
{
	public interface ITmxLayer : ITmxElement
	{
		float OffsetX { get; }
		float OffsetY { get; }

		float ParallaxFactorX { get; }
		float ParallaxFactorY { get; }
		float Opacity { get; }
		bool Visible { get; }
		Dictionary<string, string> Properties { get; }
	}
}