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
    public enum JoinType
    {
        InnerJoin,
        LeftJoin,
        RightJoin
    }

    public class JoinClause : ClauseBase
    {
        private readonly Table _joinTable;
        private readonly Expression _on;
        private readonly JoinType _joinType;

        internal JoinClause(Table joinTable, Expression on)
            : this(joinTable, on, JoinType.InnerJoin)
        {
        }

        internal JoinClause(Table joinTable, Expression on, JoinType joinType)
        {
            _joinTable = joinTable;
            _on = on;
            _joinType = joinType;
        }

        public Table JoinTable
        {
            get { return _joinTable; }
        }

        public Expression On
        {
            get { return _on; }
        }

        public JoinType JoinType
        {
            get { return _joinType; }
        }
    }
}