using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdditiveColorMixingExample
{
    class RGBColorMixer
    {

        public Color Additive(Color aFirstColor, Color aSecondColor, float aIntensity)
        {
            Color result;

            Color c, d;

            c = InvertColors(aFirstColor);
            d = InvertColors(aSecondColor);

            byte fA = (byte)Math.Max(0, 255f - c.A - d.A);
            byte fR = (byte)Math.Max(0, 255f - c.R - d.R);
            byte fG = (byte)Math.Max(0, 255f - c.G - d.G);
            byte fB = (byte)Math.Max(0, 255f - c.B - d.B);


            float cd = (float)GetDistance(aFirstColor, aSecondColor);
            cd = 4.0f * aIntensity * (1.0f - aIntensity) * cd;
            result = LinearMix(LinearMix(aFirstColor, aSecondColor, aIntensity), Color.FromArgb(fA, fR, fG, fB), cd);

            result = Color.FromArgb(result.A, result.R, result.G, result.B);

            return result;
        }

        private float GetDistance(Color a, Color b)
        {
            double[] rgb1 = new double[]{
											(double)a.R/255.0,
											(double)a.G/255.0,
											(double)a.B/255.0
										};

            double[] rgb2 = new double[]{
											(double)b.R/255.0,
											(double)b.G/255.0,
											(double)b.B/255.0
										};

            double aR = (b.R / 255.0) - (a.R / 255.0);
            double bR = (b.G / 255.0) - (a.G / 255.0);
            double cR = (b.B / 255.0) - (a.B / 255.0);

            return (float)Math.Sqrt(aR * aR + bR * bR + cR * cR);
        }

        private Color InvertColors(Color input)
        {
            return Color.FromArgb(255 - input.A, 255 - input.R, 255 - input.G, 255 - input.B);
        }


        private Color LinearMix(Color a, Color b, float blend)
        {
            double aA = a.A / 255d;
            double aR = a.R / 255d;
            double aG = a.G / 255d;
            double aB = a.B / 255d;

            double bA = b.A / 255d;
            double bR = b.R / 255d;
            double bG = b.G / 255d;
            double bB = b.B / 255d;

            double R = (double)(1.0f - blend) * aR + blend * bR;
            double G = (double)(1.0f - blend) * aG + blend * bG;
            double B = (double)(1.0f - blend) * aB + blend * bB;
            double A = (double)(1.0f - blend) * aA + blend * bA;

            return Color.FromArgb((byte)(A * 255), (byte)(R * 255), (byte)(G * 255), (byte)(B * 255));
        }
    }
}
