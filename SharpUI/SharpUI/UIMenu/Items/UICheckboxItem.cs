﻿using System;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

using IVSDKDotNet.Direct3D9;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace SharpUI.UIMenu {
    /// <summary>
    /// Checkbox menu item for the <see cref="UIMenu"/>.
    /// </summary>
    public class UICheckboxItem : UIItemBase {

        #region Variables and Properties
        // Variables
        /// <summary>The style of this <see cref="UICheckboxItem"/>.</summary>
        public new UICheckboxItemStyle Style;

        private string _itemText;
        private bool _isChecked;
        private Action<UIMenu, UICheckboxItem> _onClickAction;

        // Properties
        /// <summary>Gets or set the text of this <see cref="UICheckboxItem"/>.</summary>
        public string Text
        {
            get { return _itemText; }
            set { _itemText = value; }
        }

        /// <summary>Gets or sets if the checkbox of this <see cref="UICheckboxItem"/> is checked or not.</summary>
        public bool IsChecked
        {
            get { return _isChecked; }
            set { _isChecked = value; }
        }

        /// <summary>Gets or sets the <see cref="Action"/> that should be executed when the user checks or unchecks the <see cref="UICheckboxItem"/>.</summary>
        public Action<UIMenu, UICheckboxItem> OnClick
        {
            get { return _onClickAction; }
            set { _onClickAction = value; }
        }
        #endregion

        #region Constructor
        public UICheckboxItem(object tag, bool enabled, bool isChecked, string text, string desc, UICheckboxItemStyle style, Action<UIMenu, UICheckboxItem> onClick)
        {
            Tag = tag;
            IsEnabled = enabled;
            IsChecked = isChecked;
            Text = text;
            Description = desc;
            Style = style;
            OnClick = onClick;
        }
        public UICheckboxItem(object tag, string text, string desc, UICheckboxItemStyle style, Action<UIMenu, UICheckboxItem> onClick)
        {
            Tag = tag;
            Text = text;
            Description = desc;
            Style = style;
            OnClick = onClick;
        }
        public UICheckboxItem(bool enabled, bool isChecked, string text, string desc, UICheckboxItemStyle style, Action<UIMenu, UICheckboxItem> onClick)
        {
            IsEnabled = enabled;
            IsChecked = isChecked;
            Text = text;
            Description = desc;
            Style = style;
            OnClick = onClick;
        }
        public UICheckboxItem(string text, string desc, UICheckboxItemStyle style, Action<UIMenu, UICheckboxItem> onClick)
        {
            Text = text;
            Description = desc;
            Style = style;
            OnClick = onClick;
        }

        public UICheckboxItem(object tag, bool enabled, bool isChecked, string text, UICheckboxItemStyle style, Action<UIMenu, UICheckboxItem> onClick)
        {
            Tag = tag;
            IsEnabled = enabled;
            IsChecked = isChecked;
            Text = text;
            Style = style;
            OnClick = onClick;
        }
        public UICheckboxItem(object tag, string text, UICheckboxItemStyle style, Action<UIMenu, UICheckboxItem> onClick)
        {
            Tag = tag;
            Text = text;
            Style = style;
            OnClick = onClick;
        }
        public UICheckboxItem(bool enabled, bool isChecked, string text, UICheckboxItemStyle style, Action<UIMenu, UICheckboxItem> onClick)
        {
            IsEnabled = enabled;
            IsChecked = isChecked;
            Text = text;
            Style = style;
            OnClick = onClick;
        }
        public UICheckboxItem(string text, UICheckboxItemStyle style, Action<UIMenu, UICheckboxItem> onClick)
        {
            Text = text;
            Style = style;
            OnClick = onClick;
        }
        #endregion

        #region Methods
        private void PlayCheckedChangedSound(UIMenu menu, bool isChecked)
        {
            if (isChecked)
                menu.PlaySound("FRONTEND_MENU_TOGGLE_ON");
            else
                menu.PlaySound("FRONTEND_MENU_TOGGLE_OFF");
        }
        #endregion

        /// <inheritdoc/>
        public override void Draw(UIMenu menu, D3DGraphics gfx, Point pos)
        {
            Rectangle textRect = new Rectangle(new Point(pos.X + 5, pos.Y), new Size(menu.ItemSize.Width - 10, menu.ItemSize.Height));

            if (IsEnabled)
            {
                if (IsSelected)
                {
                    gfx.DrawBoxFilled(new Vector2(pos.X, pos.Y), menu.ItemSize, Style.SelectedBackgroundColor);
                    gfx.DrawString(menu.FontOverride, Text, textRect, eD3DFontDrawFlags.Left | eD3DFontDrawFlags.VerticalCenter, Style.SelectedForegroundColor);

                    // Draw checkbox
                    if (IsChecked)
                    {
                        gfx.DrawLine(new Vector2((pos.X + menu.ItemSize.Width) - menu.ItemSize.Height, pos.Y + 6), new Vector2((pos.X + menu.ItemSize.Width) - 9, pos.Y + 27), Style.SelectedCheckboxColor, 2.5f);
                        gfx.DrawLine(new Vector2((pos.X + menu.ItemSize.Width) - 9, pos.Y + 6), new Vector2((pos.X + menu.ItemSize.Width) - menu.ItemSize.Height, pos.Y + 27), Style.SelectedCheckboxColor, 2.5f);
                    }
                    gfx.DrawBox(new Vector2((pos.X + menu.ItemSize.Width) - menu.ItemSize.Height, pos.Y + 4), new SizeF(menu.ItemSize.Height - 8, menu.ItemSize.Height - 8), 2f, Style.SelectedCheckboxColor);
                }
                else
                {
                    gfx.DrawBoxFilled(new Vector2(pos.X, pos.Y), menu.ItemSize, Style.BackgroundColor);
                    gfx.DrawString(menu.FontOverride, Text, textRect, eD3DFontDrawFlags.Left | eD3DFontDrawFlags.VerticalCenter, Style.ForegroundColor);

                    // Draw checkbox
                    if (IsChecked)
                    {
                        gfx.DrawLine(new Vector2((pos.X + menu.ItemSize.Width) - menu.ItemSize.Height, pos.Y + 6), new Vector2((pos.X + menu.ItemSize.Width) - 9, pos.Y + 27), Style.CheckboxColor, 2.5f);
                        gfx.DrawLine(new Vector2((pos.X + menu.ItemSize.Width) - 9, pos.Y + 6), new Vector2((pos.X + menu.ItemSize.Width) - menu.ItemSize.Height, pos.Y + 27), Style.CheckboxColor, 2.5f);
                    }
                    gfx.DrawBox(new Vector2((pos.X + menu.ItemSize.Width) - menu.ItemSize.Height, pos.Y + 4), new SizeF(menu.ItemSize.Height - 8, menu.ItemSize.Height - 8), 2f, Style.CheckboxColor);
                }
            }
            else
            {
                if (IsSelected)
                {
                    gfx.DrawBoxFilled(new Vector2(pos.X, pos.Y), menu.ItemSize, Style.SelectedBackgroundColor);
                    gfx.DrawString(menu.FontOverride, Text, textRect, eD3DFontDrawFlags.Left | eD3DFontDrawFlags.VerticalCenter, Style.DisabledForegroundColor);

                    // Draw checkbox
                    if (IsChecked)
                    {
                        gfx.DrawLine(new Vector2((pos.X + menu.ItemSize.Width) - menu.ItemSize.Height, pos.Y + 6), new Vector2((pos.X + menu.ItemSize.Width) - 9, pos.Y + 27), Style.DisabledCheckboxColor, 2.5f);
                        gfx.DrawLine(new Vector2((pos.X + menu.ItemSize.Width) - 9, pos.Y + 6), new Vector2((pos.X + menu.ItemSize.Width) - menu.ItemSize.Height, pos.Y + 27), Style.DisabledCheckboxColor, 2.5f);
                    }
                    gfx.DrawBox(new Vector2((pos.X + menu.ItemSize.Width) - menu.ItemSize.Height, pos.Y + 4), new SizeF(menu.ItemSize.Height - 8, menu.ItemSize.Height - 8), 2f, Style.DisabledCheckboxColor);
                }
                else
                {
                    gfx.DrawBoxFilled(new Vector2(pos.X, pos.Y), menu.ItemSize, Style.BackgroundColor);
                    gfx.DrawString(menu.FontOverride, Text, textRect, eD3DFontDrawFlags.Left | eD3DFontDrawFlags.VerticalCenter, Style.DisabledForegroundColor);

                    // Draw checkbox
                    if (IsChecked)
                    {
                        gfx.DrawLine(new Vector2((pos.X + menu.ItemSize.Width) - menu.ItemSize.Height, pos.Y + 6), new Vector2((pos.X + menu.ItemSize.Width) - 9, pos.Y + 27), Style.DisabledCheckboxColor, 2.5f);
                        gfx.DrawLine(new Vector2((pos.X + menu.ItemSize.Width) - 9, pos.Y + 6), new Vector2((pos.X + menu.ItemSize.Width) - menu.ItemSize.Height, pos.Y + 27), Style.DisabledCheckboxColor, 2.5f);
                    }
                    gfx.DrawBox(new Vector2((pos.X + menu.ItemSize.Width) - menu.ItemSize.Height, pos.Y + 4), new SizeF(menu.ItemSize.Height - 8, menu.ItemSize.Height - 8), 2f, Style.DisabledCheckboxColor);
                }
            }
        }

        /// <inheritdoc/>
        public override void KeyPress(UIMenu menu, KeyEventArgs args, bool isKeyUpEvent, bool shouldBeUsedForNavigation)
        {
            if (IsEnabled)
            {
                if (shouldBeUsedForNavigation)
                {
                    if (args.KeyCode == menu.Options.AcceptKey)
                    {
                        IsChecked = !IsChecked;
                        PlayCheckedChangedSound(menu, IsChecked);
                        OnClick?.Invoke(menu, this);
                    }
                }
            }
            else
            {
                if (args.KeyCode == menu.Options.AcceptKey)
                    menu.PlayErrorSound();
            }
        }

        /// <inheritdoc/>
        public override void PerformClick(UIMenu parentMenu, bool ignoreEnabledState)
        {
            if (ignoreEnabledState)
            {
                OnClick?.Invoke(parentMenu, this);
            }
            else
            {
                if (IsEnabled)
                {
                    OnClick?.Invoke(parentMenu, this);
                }
            }
        }

        /// <inheritdoc/>
        public override void Cleanup()
        {

        }

    }
}
