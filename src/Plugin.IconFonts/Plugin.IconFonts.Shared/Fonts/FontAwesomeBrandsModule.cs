﻿namespace Plugin.IconFonts.Fonts
{
    /// <summary>
    /// Defines the <see cref="FontAwesomeBrandsModule" /> icon module.
    /// </summary>
    /// <seealso cref="Plugin.IconFonts.IconModule" />
    public sealed class FontAwesomeBrandsModule : IconModule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FontAwesomeBrandsModule" /> class.
        /// </summary>
        public FontAwesomeBrandsModule()
            : base("Font Awesome 5 Brands", "FontAwesome5BrandsRegular", "iconfonts-fontawesome-brands.ttf", FontAwesomeCollection.BrandIcons)
        {
            // Intentionally left blank
        }
    }
}