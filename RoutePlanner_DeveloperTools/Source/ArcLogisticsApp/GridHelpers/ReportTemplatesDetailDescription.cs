﻿using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;

using Xceed.Wpf.DataGrid;

namespace ESRI.ArcLogistics.App.GridHelpers
{
    /// <summary>
    /// ReportTemplatesDetailDescription class
    /// </summary>
    internal class ReportTemplatesDetailDescription : DataGridDetailDescription
    {
        #region Constructors
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////

        public ReportTemplatesDetailDescription()
        {
            RelationName = "ReportTemplateDetails";
        }

        #endregion // Constructors

        #region Public members
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////

        public SelectReportWrapper MasterReportWrapper
        {
            get { return _report; }
        }

        #endregion // Public members

        #region Override methods
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////

        protected override IEnumerable GetDetailsForParentItem(DataGridCollectionViewBase parentCollectionView, object parentItem)
        {
            Debug.Assert(parentItem is SelectReportWrapper);

            IEnumerable subReports = null;
            if (null == parentItem)
                subReports = new List<SelectReportWrapper>();
            else
            {
                _report = parentItem as SelectReportWrapper;
                subReports = _report.SubReportWrappers;
            }

            return subReports;
        }

        #endregion // Override methods

        #region Private members
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////

        private SelectReportWrapper _report = null;

        #endregion // Private members
    }
}
