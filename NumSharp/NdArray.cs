﻿/*
 * NumSharp
 * Copyright (C) 2018 Haiping Chen
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the Apache License 2.0 as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the Apache License 2.0
 * along with this program.  If not, see <http://www.apache.org/licenses/LICENSE-2.0/>.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace NumSharp
{
    /// <summary>
    /// A powerful N-dimensional array object
    /// Inspired from https://www.numpy.org/devdocs/user/quickstart.html
    /// </summary>
    public class NdArray<TData>
    {
        public NdArray()
        {
            Data = new List<TData>();
            NDim = -1;
        }

        /// <summary>
        /// The number of axes (dimensions) of the array.
        /// </summary>
        public int NDim { get; set; }

        /// <summary>
        /// The total number of elements of the array.
        /// </summary>
        public int Size { get { return NDim * Data.Count; } }

        /// <summary>
        /// The dimensions of the array. 
        /// n rows and m columns will be (n, m)
        /// </summary>
        public Tuple<double, double> Shape { get { return new Tuple<double, double>(Data.Count, NDim); } }

        public IList<TData> Data { get; set; }

        public override string ToString()
        {
            string output = "array([";

            // loop row
            if (NDim > 1)
            {
                for (int r = 0; r < Data.Count; r++)
                {
                    output += (r == 0) ? "[" : ", [";
                    Type type = Data[r].GetType().GenericTypeArguments[0].UnderlyingSystemType;

                    // loop dimension
                    if (type.Equals(typeof(Int32)))
                    {
                        var data = Data[r] as IList<Int32>;

                        for (int d = 0; d < NDim; d++)
                        {
                            output += (d == 0) ? data[d] + "" : ", " + data[d];
                        }
                    }
                    else if (type.Equals(typeof(double)))
                    {
                        var data = Data[r] as IList<double>;

                        for (int d = 0; d < NDim; d++)
                        {
                            output += (d == 0) ? data[d] + "" : ", " + data[d];
                        }
                    }

                    
                    output += "]";
                }
            }
            else
            {
                for (int r = 0; r < Data.Count; r++)
                {
                    output += (r == 0) ? Data[r] + "" : ", " + Data[r];
                }
            }

            output += "])";

            return output;
        }
    }
}
