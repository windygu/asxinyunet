using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComLib.Lang
{
    /// <summary>
    /// Context information for the script.
    /// </summary>
    public class Context
    {
        /// <summary>
        /// Creates new instance with default Functions/Types/Scope.
        /// </summary>
        public Context()
        {
            Types = new RegisteredTypes();
            ExternalFunctions = new ExternalFunctions();
            Functions = new RegisteredFunctions();
            Plugins = new Plugins();
            Scope = new Scope();
            Limits = new Limits(this);
            CallStack stack = new CallStack(Limits.CheckCallStack);
            Callbacks = new Lang.Callbacks();
            State = new LangState(stack);
        }


        /// <summary>
        /// Registered custom functions outside of script
        /// </summary>
        public ExternalFunctions ExternalFunctions;


        /// <summary>
        /// All the combinators that extend parsing.
        /// </summary>
        public Plugins Plugins;


        /// <summary>
        /// Script functions
        /// </summary>
        public RegisteredFunctions Functions;


        /// <summary>
        /// Registered custom types
        /// </summary>
        public RegisteredTypes Types;


        /// <summary>
        /// Scope of the script.
        /// </summary>
        public Scope Scope;


        /// <summary>
        /// Settings.
        /// </summary>
        public LangSettings Settings;


        /// <summary>
        /// Callbacks to external methods to notify them when a specific action completes.
        /// </summary>
        public Callbacks Callbacks;


        /// <summary>
        /// State of the language.
        /// </summary>
        public LangState State;


        /// <summary>
        /// Limits for 
        /// </summary>
        internal Limits Limits;
    }
}
