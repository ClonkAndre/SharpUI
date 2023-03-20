﻿using System.Drawing;
using System.Windows.Forms;

using IVSDKDotNet.Direct3D9;

namespace SharpUI {
    /// <summary>
    /// Base class for everything that can be drawn on screen. Like an <see cref="UIMenu.UIMenu"/>.
    /// </summary>
    public abstract class UIBase {

        #region Variables and Properties
        // Variables
        private Point _pos;
        private bool _isVisible;
        private bool _hasFocus;
        private object _tag;

        // Properties
        /// <summary>Gets or sets the position of this element.</summary>
        public Point Position
        {
            get { return _pos; }
            set { _pos = value; }
        }

        /// <summary>
        /// Gets if this element should be visible or not.
        /// </summary>
        public bool IsVisible
        {
            get { return _isVisible; }
            private set { _isVisible = value; }
        }

        /// <summary>
        /// Gets if this element has currently the focus or not. Use <see cref="SetFocus(bool)"/> to set the focus of this <see cref="UIBase"/> element.
        /// </summary>
        public bool HasFocus
        {
            get { return _hasFocus; }
            private set { _hasFocus = value; }
        }

        /// <summary>
        /// Gets or sets the tag of this element.
        /// This can be used to store custom data for this element.
        /// </summary>
        public object Tag
        {
            get { return _tag; }
            set { _tag = value; }
        }
        #endregion

        #region Events
        /// <summary>The delegate for the <see cref="FocusChanged"/> event.</summary>
        /// <param name="focused">Is this <see cref="UIBase"/> element focused or not.</param>
        public delegate void FocusChangedDelegate(bool focused);
        /// <summary>Raised when the focus of this <see cref="UIBase"/> element changes.</summary>
        public event FocusChangedDelegate FocusChanged;

        /// <summary>The delegate for the <see cref="VisibilityChanged"/> event.</summary>
        /// <param name="visible">Is this <see cref="UIBase"/> element visible or not.</param>
        public delegate void VisibilityChangedDelegate(bool visible);
        /// <summary>Raised when the visibility of this <see cref="UIBase"/> element changes.</summary>
        public event VisibilityChangedDelegate VisibilityChanged;
        #endregion

        #region Methods
        /// <summary>
        /// Sets the focus of this <see cref="UIBase"/> element.
        /// <para>Raises the <see cref="FocusChanged"/> event.</para>
        /// </summary>
        /// <param name="focused">Focused or not.</param>
        public void SetFocus(bool focused)
        {
            HasFocus = focused;
            FocusChanged?.Invoke(HasFocus);
        }

        /// <summary>
        /// Sets the visibility of this <see cref="UIBase"/> element.
        /// <para>Raises the <see cref="VisibilityChanged"/> event.</para>
        /// </summary>
        /// <param name="visible">Visible or not.</param>
        public void SetVisibility(bool visible)
        {
            IsVisible = visible;
            VisibilityChanged?.Invoke(IsVisible);
        }
        #endregion

        /// <summary>
        /// Responsible for drawing the element.
        /// </summary>
        /// <param name="gfx">The <see cref="D3DGraphics"/> object needed for drawing.</param>
        public abstract void Draw(D3DGraphics gfx);

        /// <summary>
        /// Responsible for handling key presses.
        /// </summary>
        /// <param name="args">The <see cref="KeyEventArgs"/> from either the <see cref="IVSDKDotNet.Script.KeyDown"/> or <see cref="IVSDKDotNet.Script.KeyUp"/> method.</param>
        public abstract void KeyPress(KeyEventArgs args);

        /// <summary>
        /// Performs some cleaning up actions.
        /// <para>Should be called from your <see cref="IVSDKDotNet.Script.Uninitialize"/> event.</para>
        /// </summary>
        public abstract void Cleanup();

    }
}
