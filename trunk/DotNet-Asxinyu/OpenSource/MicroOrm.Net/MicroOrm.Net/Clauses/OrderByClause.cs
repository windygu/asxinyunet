// Copyright 2012, mark.yang.d All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

// Author: mark.yang.d@gmail.com

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MicroOrm
{
    public enum OrderByDirection
    {
        Ascending,
        Descending
    }

    public class OrderByClause : ClauseBase
    {
        private readonly Column _column;
        private readonly OrderByDirection _direction;

        internal OrderByClause(Column column)
            : this(column, OrderByDirection.Ascending)
        {
        }

        internal OrderByClause(Column column, OrderByDirection direction)
        {
            _column = column;
            _direction = direction;
        }

        public Column Column
        {
            get { return _column; }
        }

        public OrderByDirection Direction
        {
            get { return _direction; }
        }

        internal static string GetDirectionString(OrderByDirection direction)
        {
            if (direction == OrderByDirection.Ascending)
                return "ASC";
            else
                return "DESC";
        }
    }
}
