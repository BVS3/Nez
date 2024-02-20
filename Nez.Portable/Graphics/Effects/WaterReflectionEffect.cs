using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace Nez
{
	public class WaterReflectionEffect : ReflectionEffect
	{
		/// <summary>
		/// defaults to 0.015. Waves are calculated by sampling the normal map twice. Any values generated that are sparkleIntensity greater
		/// than the actual uv value at the place of sampling will be colored sparkleColor.
		/// </summary>
		/// <value>The sparkle intensity.</value>
		public float SparkleIntensity
		{
			set 
			{
				_sparkleIntensity = value;
				_sparkleIntensityParam.SetValue(value); 
			} 
			get { return _sparkleIntensity;}
		}

		/// <summary>
		/// the color for the sparkly wave peaks
		/// </summary>
		/// <value>The color of the sparkle.</value>
		public Vector3 SparkleColor
		{
			set 
			{
				_sparkleColor = value;
				_sparkleColorParam.SetValue(value);
			}
			get { return _sparkleColor; }
		}

		/// <summary>
		/// position in screen space of the top of the water plane
		/// </summary>
		/// <value>The screen space vertical offset.</value>
		public float ScreenSpaceVerticalOffset
		{
			set => _screenSpaceVerticalOffsetParam.SetValue(Mathf.Map(value, 0, 1, -1, 1));

		}

		/// <summary>
		/// defaults to 0.3. intensity of the perspective correction
		/// </summary>
		/// <value>The perspective correction intensity.</value>
		public float PerspectiveCorrectionIntensity
		{
			set
			{
				_perspectiveCorrectionIntensity = value;
				_perspectiveCorrectionIntensityParam.SetValue(value);
			}
			get { return _perspectiveCorrectionIntensity;}
		}

		/// <summary>
		/// defaults to 2. speed that the first displacment/normal uv is scrolled
		/// </summary>
		/// <value>The first displacement speed.</value>
		public float FirstDisplacementSpeed
		{
			set
			{
				_firstDisplacementSpeed = value;
				_firstDisplacementSpeedParam.SetValue(value / 100);
			}
			get { return _firstDisplacementSpeed;}
		}

		/// <summary>
		/// defaults to 6. speed that the second displacment/normal uv is scrolled
		/// </summary>
		/// <value>The second displacement speed.</value>
		public float SecondDisplacementSpeed
		{
			set
			{
				_secondDisplacementSpeed = value;
				_secondDisplacementSpeedParam.SetValue(value / 100);
			}
			get { return _secondDisplacementSpeed;}
		}

		 

		/// <summary>
		/// defaults to 3. the normal map is sampled twice then combined. The 2nd sampling is scaled by this value.
		/// </summary>
		/// <value>The second displacement scale.</value>
		public float SecondDisplacementScale
		{
			set
			{
				_secondDisplacementScale = value;	
				_secondDisplacementScaleParam.SetValue(value);
			}
			get { return _secondDisplacementScale;}
		}

		float _sparkleIntensity = .04f;//0.015f;
		float _perspectiveCorrectionIntensity = .1f;//0.3f;
		float _reflectionIntensity = 1.05f; //.085f
		float _normalMagnitude = 0.03f;
		float _firstDisplacementSpeed = -16f;//6f;
		float _secondDisplacementSpeed = 8f;//2f;
		float _secondDisplacementScale = 4f;//3f;
		Vector3 _sparkleColor = Vector3.One;

		EffectParameter _timeParam;
		EffectParameter _sparkleIntensityParam;
		EffectParameter _sparkleColorParam;
		EffectParameter _screenSpaceVerticalOffsetParam;
		EffectParameter _perspectiveCorrectionIntensityParam; 
		EffectParameter _firstDisplacementSpeedParam;
		EffectParameter _secondDisplacementSpeedParam;
		EffectParameter _secondDisplacementScaleParam;


		public WaterReflectionEffect() : base()
		{
			CurrentTechnique = Techniques["WaterReflectionTechnique"];
			
			
			_timeParam = Parameters["_time"];
			_sparkleIntensityParam = Parameters["_sparkleIntensity"];
			_sparkleColorParam = Parameters["_sparkleColor"];
			_screenSpaceVerticalOffsetParam = Parameters["_screenSpaceVerticalOffset"];
			_perspectiveCorrectionIntensityParam = Parameters["_perspectiveCorrectionIntensity"];
			_firstDisplacementSpeedParam = Parameters["_firstDisplacementSpeed"];
			_secondDisplacementSpeedParam = Parameters["_secondDisplacementSpeed"];
			_secondDisplacementScaleParam = Parameters["_secondDisplacementScale"];

			_sparkleIntensityParam.SetValue(_sparkleIntensity);
			_sparkleColorParam.SetValue(Vector3.One);
			_perspectiveCorrectionIntensityParam.SetValue(_perspectiveCorrectionIntensity);
			FirstDisplacementSpeed = _firstDisplacementSpeed;
			SecondDisplacementSpeed = _secondDisplacementSpeed;
			_secondDisplacementScaleParam.SetValue(_secondDisplacementScale);

			// override some defaults from the ReflectionEffect
			ReflectionIntensity = _reflectionIntensity;
			NormalMagnitude = _normalMagnitude;
		}


		protected override void OnApply()
		{
			_timeParam.SetValue(Time.TotalTime);
			
		}
	}
}