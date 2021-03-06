﻿using ESRI.ArcLogistics.DomainObjects;

namespace ESRI.ArcLogistics.App.Commands.SendRoutesCommandHelpers
{
    /// <summary>
    /// Class to select is route need to be send in grid
    /// </summary>
    class SentRouteConfig
    {
        #region constructors

        public SentRouteConfig(Route route)
        {
            Route = route;
        }

        #endregion

        #region public members

        /// <summary>
        /// Is route need to be sent
        /// </summary>
        public bool IsChecked
        {
            get;
            set;
        }

        /// <summary>
        /// Route name
        /// </summary>
        public string RouteName
        {
            get;
            set;
        }

        /// <summary>
        /// Route
        /// </summary>
        public Route Route
        {
            get;
            private set;
        }

        #endregion
    }
}
