﻿using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using System;

namespace ESRI.ArcLogistics.App.Controls
{
    /// <summary>
    /// UserControl for editing TimeWindowBreak.
    /// </summary>
    internal partial class TimeWindowBreakEditor : UserControl
    {
        #region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
        public TimeWindowBreakEditor()
        {
            InitializeComponent();
            _InitEventHandlers();

            // Set width to default.
            Width = EDITOR_WIDTH;
        }

        #endregion

        #region Public properties

        public static double EditorWidth
        {

            get
            {
                return EDITOR_WIDTH;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Inits event handlers.
        /// </summary>
        private void _InitEventHandlers()
        {
            DurationTextBox.PreviewMouseLeftButtonDown += new MouseButtonEventHandler
                (_DurationTextBoxPreviewMouseLeftButtonDown);
        }

        #endregion

        #region Private Event Handlers

        /// <summary>
        /// Select all text in textbox.
        /// </summary>
        /// <param name="sender">Ignored.</param>
        /// <param name="e">Ignored.</param>
        private void _DurationTextBoxPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ((TextBox)sender).SelectAll();
            Keyboard.Focus((TextBox)sender);
            e.Handled = true;
        }

        #endregion

        #region private constants

        private const double EDITOR_WIDTH = 310;

        private TimeTextBox _FromTime;
        private TimeTextBox _ToTime;

        #endregion
    }
}