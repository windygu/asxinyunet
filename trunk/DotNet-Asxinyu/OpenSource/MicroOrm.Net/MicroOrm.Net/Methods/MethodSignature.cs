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
using System.Dynamic;
using System.Collections;

namespace MicroOrm
{
    internal sealed class MethodSignature : IEquatable<MethodSignature>
    {
        private readonly string _name;
        private readonly IList<Parameter> _parameters;
        private static readonly object obj = new object();

        private MethodSignature(string name, IList<Parameter> parameters)
        {
            _name = name;
            _parameters = parameters;
        }

        public static string FromBinder(InvokeMemberBinder binder, object[] args)
        {
            if (args.Length == 1 && !(args[0] is IList))
                return string.Format("{0}({1})", binder.Name, (args[0] ?? obj).GetType());

            var builder = new StringBuilder(binder.Name);
            builder.Append("(");
            for (int i = 0; i < args.Length; i++)
            {
                if (binder.CallInfo.ArgumentNames.Count > i && !string.IsNullOrWhiteSpace(binder.CallInfo.ArgumentNames[i]))
                {
                    builder.Append(binder.CallInfo.ArgumentNames[i]);
                    builder.Append(":");
                }
                var type = (args[i] ?? obj).GetType();
                builder.Append(type.FullName);
                var list = args[i] as IList;
                if (list != null)
                {
                    builder.AppendFormat("[{0}]", list.Count);
                }
            }
            builder.Append(")");
            return builder.ToString();
        }

        private static IList<Parameter> GetParameters(InvokeMemberBinder binder, object[] args)
        {
            var parameters = new Parameter[args.Length];
            for (int i = 0; i < args.Length; i++)
            {
                var list = args[i] as IList;
                if (list != null)
                {
                    parameters[i] = new Parameter(NullSafeGetType(args[i]), binder.CallInfo.ArgumentNames.GetOrDefault(i), list.Count);
                }
                else
                {
                    parameters[i] = new Parameter(NullSafeGetType(args[i]), binder.CallInfo.ArgumentNames.GetOrDefault(i));
                }
            }
            return parameters;
        }

        private static Type NullSafeGetType(object o)
        {
            return o == null ? typeof(object) : o.GetType();
        }

        class Parameter : IEquatable<Parameter>
        {
            private readonly Type _type;
            private readonly string _name;
            private readonly int _size;

            public Parameter(Type type)
                : this(type, null)
            {
            }

            public Parameter(Type type, string name)
                : this(type, name, 0)
            {
            }

            public Parameter(Type type, int size)
                : this(type, null, size)
            {
            }

            public Parameter(Type type, string name, int size)
            {
                _type = type;
                _name = name;
                _size = size;
            }

            public bool Equals(Parameter other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return Equals(other._type, _type) && Equals(other._name, _name) && other._size == _size;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != typeof(Parameter)) return false;
                return Equals((Parameter)obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    int result = _type.GetHashCode();
                    result = (result * 397) ^ (_name != null ? _name.GetHashCode() : 0);
                    result = (result * 397) ^ _size;
                    return result;
                }
            }

            public static bool operator ==(Parameter left, Parameter right)
            {
                return Equals(left, right);
            }

            public static bool operator !=(Parameter left, Parameter right)
            {
                return !Equals(left, right);
            }
        }

        public bool Equals(MethodSignature other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other._name, _name) && ParameterListsMatch(other._parameters, _parameters);
        }

        private static bool ParameterListsMatch(IList<Parameter> left, IList<Parameter> right)
        {
            if (left.Count != right.Count) return false;

            for (int i = 0; i < left.Count; i++)
            {
                if (!left[i].Equals(right[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(MethodSignature)) return false;
            return Equals((MethodSignature)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = _name.GetHashCode() * 397;
                for (int i = 0; i < _parameters.Count; i++)
                {
                    hashCode ^= _parameters[i].GetHashCode();
                }
                return hashCode;
            }
        }

        public static bool operator ==(MethodSignature left, MethodSignature right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(MethodSignature left, MethodSignature right)
        {
            return !Equals(left, right);
        }
    }
}
