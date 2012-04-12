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
    public class GroupByClause : ClauseBase
    {
        private readonly IList<Column> _columns;

        internal GroupByClause(IList<Column> columns)
        {
            _columns = columns;
        }

        public IList<Column> Columns
        {
            get { return _columns; }
        }
    }
}
