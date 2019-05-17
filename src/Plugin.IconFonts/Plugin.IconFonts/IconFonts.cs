﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Plugin.IconFonts
{
    /// <summary>
    /// Defines the <see cref="Plugin.IconFonts" /> type.
    /// </summary>
    public static class IconFonts
    {
        /// <summary>
        /// List of icon font descriptors
        /// </summary>
        public static IList<IIconModule> Modules { get; } = new List<IIconModule>();

        /// <summary>
        /// Add support for a new icon font.
        /// </summary>
        /// <param name="module">The Icon Module holding the ttf file reference and its mappings.</param>
        /// <returns>An initializer instance for chain calls.</returns>
        public static IconFontsInitializer With(IIconModule module)
        {
            return new IconFontsInitializer(module);
        }

        /// <summary>
        /// Adds the icon module.
        /// </summary>
        /// <param name="module">The module.</param>
        private static void AddModule(IIconModule module)
        {
            // Prevent duplicates
            foreach (var wrapper in Modules)
            {
                if (wrapper.FontName.Equals(module.FontName))
                {
                    return;
                }
            }

            // Add to the list
            Modules.Add(module);
        }

        /// <summary>
        /// Allows chain calls on <see cref="IconFonts.With(IIconModule)" />.
        /// </summary>
        public sealed class IconFontsInitializer
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="IconFontsInitializer" /> class.
            /// </summary>
            /// <param name="iconFontDescriptor">The icon font descriptor.</param>
            public IconFontsInitializer(IIconModule iconFontDescriptor)
            {
                AddModule(iconFontDescriptor);
            }

            /// <summary>
            /// Add support for a new icon font.
            /// </summary>
            /// <param name="iconFontDescriptor">The IconDescriptor holding the ttf file reference and its mappings.</param>
            /// <returns>An initializer instance for chain calls.</returns>
            public IconFontsInitializer With(IIconModule iconFontDescriptor)
            {
                AddModule(iconFontDescriptor);
                return this;
            }
        }

        /// <summary>
        /// Finds the Typeface to apply for a given icon.
        /// </summary>
        /// <param name="icon">The icon for which you need the typeface.</param>
        /// <returns>
        ///     The font descriptor which contains info about the typeface to apply, or null
        ///     if the icon cannot be found. In that case, check that you properly added the modules
        ///     using <see cref="With(IIconModule)" /> prior to calling this method.
        /// </returns>
        public static IIconModule FindModuleOf(IIcon icon)
        {
            foreach (var module in Modules)
            {
                if (module.HasIcon(icon))
                {
                    return module;
                }
            }

            return null;
        }

        /// <summary>
        /// Retrieve an icon from a key.
        /// </summary>
        /// <param name="iconKey">The icon key.</param>
        /// <returns>The icon, or null if no icon matches the key</returns>
        public static IIcon FindIconForKey(String iconKey)
        {
            if (String.IsNullOrWhiteSpace(iconKey))
                return null;

            return Modules?.FirstOrDefault(x => x.Keys.Contains(iconKey))?.GetIcon(iconKey);
        }
    }
}