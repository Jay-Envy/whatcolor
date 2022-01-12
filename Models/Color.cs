using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatColor.Models
{
    public class Color
    {
        public int ColorID { get; set; }
        public string HEX { get; set; }
        public string CMYK { get; set; }
        public string RGB { get; set; }
        public string Name { get; set; }
        public string TrendingUrl { get; set; }
        public string ComplementaryHex { get; set; }
        public int ColorCategoryID { get; set; }


        ////Get CMYK (credit: https://www.cyotek.com/blog/converting-colours-between-rgb-and-cmyk-in-csharp)
        //public int GetCMYK(int RGB)
        //{
        //    double c, m, y, k;

        //    string rgbString = RGB.ToString();
        //    double r = Convert.ToDouble(rgbString.Substring(0, 2));
        //    double g = Convert.ToDouble(rgbString.Substring(2, 2));
        //    double b = Convert.ToDouble(rgbString.Substring(4, 2));

        //    r /= 255;
        //    g /= 255;
        //    b /= 255;

        //    k = IsBlack(1 - Math.Max(Math.Max(r, g), b));
        //    c = IsBlack((1 - r - k) / (1 - k));
        //    m = IsBlack((1 - g - k) / (1 - k));
        //    y = IsBlack((1 - b - k) / (1 - k));

        //    return Convert.ToInt32($"{c}{m}{y}{k}");
        //}

        ////Extra functie om te checken of het puur zwart is
        //private static double IsBlack(double value)
        //{
        //    //Aangezien we doubles gebruiken is het mogelijk dat (1 - k) 0 teruggeeft als het puur zwart is. 
        //    //Met een double krijg je geen "DivideByZeroException", maar is het result NaN.
        //    if (value < 0 || double.IsNaN(value))
        //    {
        //        value = 0;
        //    }
        //    return value;
        //}

        //public string GetComplementaryHex(int RGB)
        //{
        //    string rgbString = RGB.ToString();
        //    double r = Convert.ToDouble(rgbString.Substring(0, 2));
        //    double g = Convert.ToDouble(rgbString.Substring(2, 2));
        //    double b = Convert.ToDouble(rgbString.Substring(4, 2));

        //    r /= 255;
        //    g /= 255;
        //    b /= 255;

        //    //Minimum en maximum value zoeken van rgb
        //    double min = Math.Min(Math.Min(r,g),b);
        //    double max = Math.Max(Math.Max(r,g),b);
        //    //Delta staat voor het verschil tussen twee kleuren die op een scherm komen
        //    //bv: wanneer je een scherm koopt moet Delta E zo dicht mogelijk bij de 0

        //    //Gedeelte van easyrgb.com

        //    //Hier heb ik h een value gegeven omdat er zogezegd een manier is waarbij h geen value krijgt verder in de code.
        //    double h = 0.0;
        //    double s, l;
        //    double del_max = max - min;

        //    //Berekening
        //    l = (max + min) / 2;

        //    if (del_max == 0) 
        //    {
        //        h = 0;
        //        s = 0;
        //    }
        //    else
        //    {
        //        if(l < 0.5)
        //        {
        //            s = del_max / (max + min);
        //        }
        //        else
        //        {
        //            s = del_max + max / (2 - max - min);
        //        }

        //        double del_r = (((max - r) / 6) + (max / 2)) / del_max;
        //        double del_g = (((max - g) / 6) + (max / 2)) / del_max;
        //        double del_b = (((max - b) / 6) + (max / 2)) / del_max;

        //        //Hue wordt een value tussen 0 en 1 -> Als deze hier boven of onder zit krijgt deze respectievelijk -1 of +1
        //        if (r == max)
        //        {
        //            h = del_b - del_g;
        //        }
        //        else if (g == max)
        //        {
        //            h = (1 / 3) + del_r - del_b;
        //        }
        //        else if (b == max)
        //        {
        //            h = (2 / 3) + del_g - del_r;
        //        }

        //        if (h < 0)
        //        {
        //            h += 1;
        //        }
        //        else if (h > 1)
        //        {
        //            h -= 1;
        //        }
        //    }

        //    //h2 is de complementaire Hue, waarbij de graden worden aanzien als een waarde tussen 0 en 1.
        //    double h2 = h + 0.5;

        //    if (h2 > 1)
        //    {
        //        h2 -= 1;
        //    }

        //    //Dit maakt de complementaire kleur h2, s, l.

        //    //In de wijze woorden van Missy Elliott, *flip it and reverse it* => HSL naar RGB(HEX)

        //    double var1, var2 = 0.0;

        //    if (s == 0)
        //    {
        //        r = l * 255;
        //        g = l * 255;
        //        b = l * 255;
        //    }
        //    else
        //    {
        //        if (l < 0.5)
        //        {
        //            var1 = l * (1 + s);
        //        }
        //        else
        //        {
        //            var2 = (l + s) - (s * l);
        //        }

        //        var1 = 2 * l - var2;

        //        r = 255 * H2RGB(var1, var2, h + (1 / 3));
        //        g = 255 * H2RGB(var1, var2, h);
        //        b = 255 * H2RGB(var1, var2, h - (1 / 3));
        //    }

        //    //return rgb als hex waarde
        //    return $"{r:X2}{g:X2}{b:X2}";
            
        //}

        ////Extra functie Hue naar RGB
        //private double H2RGB(double var1, double var2, double h)
        //{
        //    if (h < 0)
        //    {
        //        h += 1;
        //    }
        //    else if (h > 1)
        //    {
        //        h -= 1;
        //    }

        //    if ((6 * h) < 1)
        //    {
        //        return (var1 + (var2 - var1) * 6 * h);
        //    }
        //    else if ((2 * h) < 1)
        //    {
        //        return var2;
        //    }
        //    else if ((3 * h) < 2)
        //    {
        //        return var1 + (var1 + (var2 - var1) * ((2 / 3) - h) * 6);
        //    }
        //    return var1;
        //}

        ///*
        //==/ code gebruikt om HEX naar RGB te converteren: /== 
        // public int color = Convert.ToInt32("FFFFFF", 16);
        //==/-----------------------------------------------/==



        //==/ code om complementaire kleur te verkrijgen /==
        //(credit: https://serennu.com/colour/rgbtohsl.php en https://www.easyrgb.com/en/math.php)
        //-> HEX naar RGB (of RGB gebruiken)
        //-> RGB naar HSL (Hue/Saturation/Lightness)
        //-> Hue value 180 graden verder draaien op het kleurenwiel (S/L values blijven hetzelfde)
        //-> HSL naar originele notatie
        //==/--------------------------------------------/==
        
        // */

    }
}