﻿using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace ESRI.ArcLogistics.App.GridHelpers
{
    /// <summary>
    /// SpecialName class
    /// </summary>
    internal class SpecialName
    {
        #region Constructors
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////

        public SpecialName(string name, bool isSpecial)
        {
            Debug.Assert(!string.IsNullOrEmpty(name));

            _name = name;
            _isSpecial = isSpecial;
        }

        #endregion // Constructors

        #region Public methods
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public bool IsSpecial
        {
            get { return _isSpecial; }
            set { _isSpecial = value; }
        }

        public override string ToString()
        {
            return _name;
        }

        #endregion // Public methods

        #region Private members
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////

        private string _name;
        private bool _isSpecial;

        #endregion // Private members
    }

    /// <summary>
    /// SelectReportWrapper class
    /// </summary>
    internal class SelectReportWrapper : IDescripted
    {
        #region Constructors
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////

        public SelectReportWrapper(string name, string description, bool isEnforceSplitted,
                                   bool isCheked, ICollection<SelectReportWrapper> subReportWrappers)
        {
            _name = new SpecialName(name, isEnforceSplitted);
            _description = description;
            _isChecked = isCheked;
            _subReportWrappers = subReportWrappers;
        }

        #endregion // Constructors

        #region Public methods
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////

        public SpecialName Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public bool IsChecked
        {
            get { return _isChecked; }
            set { _isChecked = value; }
        }

        public ICollection<SelectReportWrapper> SubReportWrappers
        {
            get { return _subReportWrappers; }
        }

        public override string ToString()
        {
            return (string.IsNullOrEmpty(_description)) ? _name.ToString() :
                                                          string.Format(FORMAT, _name.ToString(), _description);
        }

        #endregion // Public methods

        #region IDescripted
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////

        public string Description
        {
            get { return _description; }
        }

        #endregion // IDescripted

        #region Private consts
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////

        private const string FORMAT = "{0}: {1}";

        #endregion // Private consts

        #region Private members
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////

        private ICollection<SelectReportWrapper> _subReportWrappers;
        private SpecialName _name;
        private string _description;
        private bool _isChecked;

        #endregion // Private members
    }
}
