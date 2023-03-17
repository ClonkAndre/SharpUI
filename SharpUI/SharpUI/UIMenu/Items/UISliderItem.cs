﻿using System;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

using IVSDKDotNet.Direct3D9;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace SharpUI.UIMenu.Items {
    /// <summary>
    /// Slider menu item for the <see cref="UIMenu"/>.
    /// </summary>
    public class UISliderItem : UIItemBase {

        #region Variables and Properties
        // Variables
        /// <summary>The style of this <see cref="UISliderItem"/>.</summary>
        public new UISliderItemStyle Style;

        private string _itemText;
        private int _maxValue = 100;
        private int _value;
        private Size _sliderSize = new Size(150, 10);
        private Action<UIMenu, UISliderItem> _onClickAction;

        // Properties
        /// <summary>Gets or sets the text of this <see cref="UISliderItem"/>.</summary>
        public string Text
        {
            get { return _itemText; }
            set { _itemText = value; }
        }

        /// <summary>Gets or sets the maximum value of this <see cref="UISliderItem"/>. The default is 100.</summary>
        public int MaxValue
        {
            get { return _maxValue; }
            set { _maxValue = value; }
        }
        /// <summary>Gets or sets the current value of this <see cref="UISliderItem"/>. This cannot exceed the <see cref="MaxValue"/>.</summary>
        public int Value
        {
            get { return _value; }
            set {

                int tempValue = value;
                if (tempValue >= MaxValue)
                    tempValue = MaxValue;
                if (tempValue <= 0)
                    tempValue = 0;
                _value = tempValue;

                ValueChanged?.Invoke(_value);
            }
        }

        /// <summary>Gets or sets the size of the slider of this <see cref="UISliderItem"/>. The default is 153x10.</summary>
        public Size SliderSize
        {
            get { return _sliderSize; }
            set { _sliderSize = value; }
        }

        /// <summary>Gets or sets the <see cref="Action"/> that should be executed when the user presses this <see cref="UISliderItem"/>.</summary>
        public Action<UIMenu, UISliderItem> OnClick
        {
            get { return _onClickAction; }
            set { _onClickAction = value; }
        }
        #endregion

        #region Events
        /// <summary>The delegate for the <see cref="ValueChanged"/> event.</summary>
        /// <param name="newValue">The new value of the <see cref="UISliderItem"/>.</param>
        public delegate void ValueChangedDelegate(int newValue);
        /// <summary>Raised when the <see cref="Value"/> of this <see cref="UISliderItem"/> changes.</summary>
        public event ValueChangedDelegate ValueChanged;
        #endregion

        #region Constructor
        public UISliderItem(object tag, bool enabled, string text, string desc, int maxValue, UISliderItemStyle style, Action<UIMenu, UISliderItem> onClick)
        {
            Tag = tag;
            IsEnabled = enabled;
            Text = text;
            Description = desc;
            MaxValue = maxValue;
            Style = style;
            OnClick = onClick;
        }
        public UISliderItem(object tag, string text, string desc, int maxValue, UISliderItemStyle style, Action<UIMenu, UISliderItem> onClick)
        {
            Tag = tag;
            Text = text;
            Description = desc;
            MaxValue = maxValue;
            Style = style;
            OnClick = onClick;
        }
        public UISliderItem(bool enabled, string text, string desc, int maxValue, UISliderItemStyle style, Action<UIMenu, UISliderItem> onClick)
        {
            IsEnabled = enabled;
            Text = text;
            Description = desc;
            MaxValue = maxValue;
            Style = style;
            OnClick = onClick;
        }
        public UISliderItem(string text, string desc, int maxValue, UISliderItemStyle style, Action<UIMenu, UISliderItem> onClick)
        {
            Text = text;
            Description = desc;
            MaxValue = maxValue;
            Style = style;
            OnClick = onClick;
        }

        public UISliderItem(object tag, bool enabled, string text, string desc, UISliderItemStyle style, Action<UIMenu, UISliderItem> onClick)
        {
            Tag = tag;
            IsEnabled = enabled;
            Text = text;
            Description = desc;
            Style = style;
            OnClick = onClick;
        }
        public UISliderItem(object tag, string text, string desc, UISliderItemStyle style, Action<UIMenu, UISliderItem> onClick)
        {
            Tag = tag;
            Text = text;
            Description = desc;
            Style = style;
            OnClick = onClick;
        }
        public UISliderItem(bool enabled, string text, string desc, UISliderItemStyle style, Action<UIMenu, UISliderItem> onClick)
        {
            IsEnabled = enabled;
            Text = text;
            Description = desc;
            Style = style;
            OnClick = onClick;
        }
        public UISliderItem(string text, string desc, UISliderItemStyle style, Action<UIMenu, UISliderItem> onClick)
        {
            Text = text;
            Description = desc;
            Style = style;
            OnClick = onClick;
        }

        public UISliderItem(object tag, bool enabled, string text, int maxValue, UISliderItemStyle style, Action<UIMenu, UISliderItem> onClick)
        {
            Tag = tag;
            IsEnabled = enabled;
            Text = text;
            MaxValue = maxValue;
            Style = style;
            OnClick = onClick;
        }
        public UISliderItem(object tag, string text, int maxValue, UISliderItemStyle style, Action<UIMenu, UISliderItem> onClick)
        {
            Tag = tag;
            Text = text;
            MaxValue = maxValue;
            Style = style;
            OnClick = onClick;
        }
        public UISliderItem(bool enabled, string text, int maxValue, UISliderItemStyle style, Action<UIMenu, UISliderItem> onClick)
        {
            IsEnabled = enabled;
            Text = text;
            Style = style;
            MaxValue = maxValue;
            OnClick = onClick;
        }
        public UISliderItem(string text, int maxValue, UISliderItemStyle style, Action<UIMenu, UISliderItem> onClick)
        {
            Text = text;
            Style = style;
            MaxValue = maxValue;
            OnClick = onClick;
        }

        public UISliderItem(object tag, bool enabled, string text, UISliderItemStyle style, Action<UIMenu, UISliderItem> onClick)
        {
            Tag = tag;
            IsEnabled = enabled;
            Text = text;
            Style = style;
            OnClick = onClick;
        }
        public UISliderItem(object tag, string text, UISliderItemStyle style, Action<UIMenu, UISliderItem> onClick)
        {
            Tag = tag;
            Text = text;
            Style = style;
            OnClick = onClick;
        }
        public UISliderItem(bool enabled, string text, UISliderItemStyle style, Action<UIMenu, UISliderItem> onClick)
        {
            IsEnabled = enabled;
            Text = text;
            Style = style;
            OnClick = onClick;
        }
        public UISliderItem(string text, UISliderItemStyle style, Action<UIMenu, UISliderItem> onClick)
        {
            Text = text;
            Style = style;
            OnClick = onClick;
        }
        #endregion

        /// <inheritdoc/>
        public override void Draw(UIMenu menu, D3DGraphics gfx, Point pos)
        {
            Rectangle textRect = new Rectangle(new Point(pos.X + 5, pos.Y), new Size(menu.ItemSize.Width - 10, menu.ItemSize.Height));

            if (IsEnabled)
            {
                float w = (float)Math.Floor((double)Value / (double)MaxValue * SliderSize.Width);

                if (IsSelected)
                {
                    gfx.DrawBoxFilled(gfx.Device, new Vector2(pos.X, pos.Y), menu.ItemSize, Style.SelectedBackgroundColor);
                    gfx.DrawString(gfx.Device, menu.FontOverride, Text, textRect, eD3DFontDrawFlags.Left | eD3DFontDrawFlags.VerticalCenter, Style.SelectedForegroundColor);

                    gfx.DrawBoxFilled(gfx.Device, new Vector2((pos.X + menu.ItemSize.Width - 8) - SliderSize.Width, pos.Y + (menu.ItemSize.Height / 2f - SliderSize.Height / 2f)), new SizeF(SliderSize.Width, SliderSize.Height), Style.SelectedSliderBackgroundColor); // Slider Background
                    gfx.DrawBoxFilled(gfx.Device, new Vector2((pos.X + menu.ItemSize.Width - 8) - SliderSize.Width, pos.Y + (menu.ItemSize.Height / 2f - SliderSize.Height / 2f)), new SizeF(w, 10f), Style.SelectedSliderForegroundColor); // Slider Foreground
                }
                else
                {
                    gfx.DrawBoxFilled(gfx.Device, new Vector2(pos.X, pos.Y), menu.ItemSize, Style.BackgroundColor);
                    gfx.DrawString(gfx.Device, menu.FontOverride, Text, textRect, eD3DFontDrawFlags.Left | eD3DFontDrawFlags.VerticalCenter, Style.ForegroundColor);

                    gfx.DrawBoxFilled(gfx.Device, new Vector2((pos.X + menu.ItemSize.Width - 8) - SliderSize.Width, pos.Y + (menu.ItemSize.Height / 2f - SliderSize.Height / 2f)), new SizeF(SliderSize.Width, SliderSize.Height), Style.SliderBackgroundColor); // Slider Background
                    gfx.DrawBoxFilled(gfx.Device, new Vector2((pos.X + menu.ItemSize.Width - 8) - SliderSize.Width, pos.Y + (menu.ItemSize.Height / 2f - SliderSize.Height / 2f)), new SizeF(w, 10f), Style.SliderForegroundColor); // Slider Foreground
                }
            }
            else
            {
                float w = (float)Math.Floor((double)Value / (double)MaxValue * SliderSize.Width);

                if (IsSelected)
                {
                    gfx.DrawBoxFilled(gfx.Device, new Vector2(pos.X, pos.Y), menu.ItemSize, Style.SelectedBackgroundColor);
                    gfx.DrawString(gfx.Device, menu.FontOverride, Text, textRect, eD3DFontDrawFlags.Left | eD3DFontDrawFlags.VerticalCenter, Style.DisabledForegroundColor);

                    gfx.DrawBoxFilled(gfx.Device, new Vector2((pos.X + menu.ItemSize.Width - 8) - SliderSize.Width, pos.Y + (menu.ItemSize.Height / 2f - SliderSize.Height / 2f)), new SizeF(SliderSize.Width, SliderSize.Height), Style.SliderBackgroundColor); // Slider Background
                    gfx.DrawBoxFilled(gfx.Device, new Vector2((pos.X + menu.ItemSize.Width - 8) - SliderSize.Width, pos.Y + (menu.ItemSize.Height / 2f - SliderSize.Height / 2f)), new SizeF(w, 10f), Style.DisabledSliderForegroundColor); // Slider Foreground
                }
                else
                {
                    gfx.DrawBoxFilled(gfx.Device, new Vector2(pos.X, pos.Y), menu.ItemSize, Style.BackgroundColor);
                    gfx.DrawString(gfx.Device, menu.FontOverride, Text, textRect, eD3DFontDrawFlags.Left | eD3DFontDrawFlags.VerticalCenter, Style.DisabledForegroundColor);

                    gfx.DrawBoxFilled(gfx.Device, new Vector2((pos.X + menu.ItemSize.Width - 8) - SliderSize.Width, pos.Y + (menu.ItemSize.Height / 2f - SliderSize.Height / 2f)), new SizeF(SliderSize.Width, SliderSize.Height), Style.SliderBackgroundColor); // Slider Background
                    gfx.DrawBoxFilled(gfx.Device, new Vector2((pos.X + menu.ItemSize.Width - 8) - SliderSize.Width, pos.Y + (menu.ItemSize.Height / 2f - SliderSize.Height / 2f)), new SizeF(w, 10f), Style.DisabledSliderForegroundColor); // Slider Foreground
                }
            }
        }

        /// <inheritdoc/>
        public override void KeyPress(UIMenu menu, KeyEventArgs args)
        {
            if (IsEnabled)
            {
                if (args.KeyCode == menu.Options.AcceptKey)
                {
                    OnClick?.Invoke(menu, this);
                }
                if (args.KeyCode == menu.Options.NavigateLeft)
                {
                    Value--;
                }
                if (args.KeyCode == menu.Options.NavigateRight)
                {
                    Value++;
                }
            }
        }

        /// <inheritdoc/>
        public override void Cleanup()
        {

        }

    }
}