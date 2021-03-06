﻿/*
 | Version 10.1.84
 | Copyright 2013 Esri
 |
 | Licensed under the Apache License, Version 2.0 (the "License");
 | you may not use this file except in compliance with the License.
 | You may obtain a copy of the License at
 |
 |    http://www.apache.org/licenses/LICENSE-2.0
 |
 | Unless required by applicable law or agreed to in writing, software
 | distributed under the License is distributed on an "AS IS" BASIS,
 | WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 | See the License for the specific language governing permissions and
 | limitations under the License.
 */

using System;
using System.Diagnostics;
using System.Windows.Data;
using System.Globalization;

namespace ESRI.ArcLogistics.App.Converters
{
    /// <summary>
    /// Provides conversion <see cref="ESRI.ArcLogistics.CurbApproach"/> to
    /// <see cref="T:System.String" /> and back (Mode = TwoWay).
    /// </summary>
    [ValueConversion(typeof(CurbApproach), typeof(string))]
    internal class CurbApproachConverter : IValueConverter
    {
        /// <summary>
        /// Converts <see cref="ESRI.ArcLogistics.CurbApproach"/> to <see cref="T:System.String" />.
        /// </summary>
        /// <param name="value">Value to conversion (CurbApproach).</param>
        /// <param name="targetType"><see cref="ESRI.ArcLogistics.CurbApproach"/>.</param>
        /// <param name="parameter">Ignored.</param>
        /// <param name="culture">Ignored.</param>
        /// <returns>CurbApproach related text or string.Empty.</returns>
        public object Convert(object value,
                              Type targetType,
                              object parameter,
                              CultureInfo culture)
        {
            string result = string.Empty;
            if (value != null)
            {
                try
                {
                    var inputValue = (CurbApproach)value;
                    switch (inputValue)
                    {
                        case CurbApproach.Left:
                        case CurbApproach.Right:
                            result =
                                App.Current.GetString("CurbApproachFormat", inputValue.ToString());
                            break;

                        case CurbApproach.Both:
                            result = App.Current.FindString("CurbApproachBoth");
                            break;

                        case CurbApproach.NoUTurns:
                            result = App.Current.FindString("CurbApproachNoUTurns");
                            break;

                        default:
                            Debug.Assert(false); // not supported
                            break;
                    }
                }
                catch
                {
                }
            }

            return result;
        }

        /// <summary>
        /// Converts <see cref="T:System.String" /> to <see cref="ESRI.ArcLogistics.CurbApproach"/>.
        /// </summary>
        /// <param name="value">Value to conversion (String).</param>
        /// <param name="targetType"><see cref="T:System.String" />.</param>
        /// <param name="parameter">Ignored.</param>
        /// <param name="culture">Ignored.</param>
        /// <returns>If text is supported return CurbApproach. Else - generate exception.</returns>
        public object ConvertBack(object value,
                                  Type targetType,
                                  object parameter,
                                  CultureInfo culture)
        {
            Debug.Assert(null != value);
            Debug.Assert(value is string);

            return CustomEnumParser.Parse(typeof(CurbApproach), value.ToString());
        }
    }
}
