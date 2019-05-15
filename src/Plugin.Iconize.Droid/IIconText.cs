﻿using System;
using Android.Graphics;
using Android.Text;

namespace Plugin.Iconize.Droid
{
    public interface IIconText
    {
        Typeface Typeface { get; }

        string Text { get; }

        Color TextColor { get; }

        Double TextSize { get; }

        ISpannable ParseIcons();
    }
}