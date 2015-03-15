// Source: https://github.com/ajdotnet/AJ.Common
using System;
using System.Collections;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace AJ.Common
{
    /// <summary>
    /// Helper class to provide parameter checks.
    /// See https://ajdotnet.wordpress.com/2009/08/01/posting-guards-guard-classes-explained/ for background.
    /// </summary>
    public static class Guard
    {
        const string NULL_PARAM = "(no param)";
        const string NULL_VALUE = "(null)";

        /// <summary>
        /// Checks if a given value is not null and throws a respective exception otherwise.
        /// </summary>
        /// <param name="arg">The value of the parameter that should be checked.</param>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <exception cref="ArgumentNullException">Thrown when the value is null.</exception>
        [DebuggerStepThrough]
        static public void AssertNotNull([ValidatedNotNull]object arg, string paramName)
        {
            if (arg == null)
                ThrowArgumentNullException(paramName, null);
        }

        /// <summary>
        /// Checks if a given value is not null and throws a respective exception otherwise.
        /// </summary>
        /// <param name="arg">The value of the parameter that should be checked.</param>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <param name="message">A message that describes the error. </param>
        /// <exception cref="ArgumentNullException">Thrown when the value is null.</exception>
        [DebuggerStepThrough]
        static public void AssertNotNull([ValidatedNotNull]object arg, string paramName, string message)
        {
            if (arg == null)
                ThrowArgumentNullException(paramName, message);
        }

        /// <summary>
        /// Checks if a given value is not null and throws a respective exception otherwise.
        /// </summary>
        /// <param name="arg">The value of the parameter that should be checked.</param>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">An Object array containing zero or more objects to format. </param>
        /// <exception cref="ArgumentNullException">Thrown when the value is null.</exception>
        [DebuggerStepThrough]
        static public void AssertNotNull([ValidatedNotNull]object arg, string paramName, string format, params object[] args)
        {
            if (arg == null)
                ThrowArgumentNullException(paramName, SafeFormat(format, args));
        }

        /// <summary>
        /// Checks if a given value is not null and throws a respective exception otherwise.
        /// </summary>
        /// <param name="arg">The value of the parameter that should be checked.</param>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <exception cref="ArgumentNullException">Thrown when the value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the value is empty.</exception>
        [DebuggerStepThrough]
        static public void AssertNotEmpty([ValidatedNotNull]string arg, string paramName)
        {
            AssertNotNull(arg, paramName);
            if (arg.Length == 0)
                ThrowArgumentOutOfRangeException(paramName, arg, null);
        }

        /// <summary>
        /// Checks if a given value is neither null nor empty and throws a respective exception otherwise.
        /// </summary>
        /// <param name="arg">The value of the parameter that should be checked.</param>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <param name="message">A message that describes the error. </param>
        /// <exception cref="ArgumentNullException">Thrown when the value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the value is empty.</exception>
        [DebuggerStepThrough]
        static public void AssertNotEmpty([ValidatedNotNull]string arg, string paramName, string message)
        {
            AssertNotNull(arg, paramName, message);
            if (arg.Length == 0)
                ThrowArgumentOutOfRangeException(paramName, arg, message);
        }

        /// <summary>
        /// Checks if a given value is neither null nor empty and throws a respective exception otherwise.
        /// </summary>
        /// <param name="arg">The value of the parameter that should be checked.</param>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">An Object array containing zero or more objects to format. </param>
        /// <exception cref="ArgumentNullException">Thrown when the value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the value is empty.</exception>
        [DebuggerStepThrough]
        static public void AssertNotEmpty([ValidatedNotNull]string arg, string paramName, string format, params object[] args)
        {
            AssertNotNull(arg, paramName, format, args);
            if (arg.Length == 0)
                ThrowArgumentOutOfRangeException(paramName, arg, SafeFormat(format, args));
        }

        /// <summary>
        /// Checks if a given value is neither null nor empty and throws a respective exception otherwise.
        /// </summary>
        /// <param name="arg">The value of the parameter that should be checked.</param>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <exception cref="ArgumentNullException">Thrown when the value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the value is empty.</exception>
        [DebuggerStepThrough]
        static public void AssertNotEmpty([ValidatedNotNull]ICollection arg, string paramName)
        {
            AssertNotNull(arg, paramName);
            if (arg.Count == 0)
                ThrowArgumentOutOfRangeException(paramName, arg, null);
        }

        /// <summary>
        /// Checks if a given value is neither null nor empty and throws a respective exception otherwise.
        /// </summary>
        /// <param name="arg">The value of the parameter that should be checked.</param>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <param name="message">A message that describes the error. </param>
        /// <exception cref="ArgumentNullException">Thrown when the value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the value is empty.</exception>
        [DebuggerStepThrough]
        static public void AssertNotEmpty([ValidatedNotNull]ICollection arg, string paramName, string message)
        {
            AssertNotNull(arg, paramName, message);
            if (arg.Count == 0)
                ThrowArgumentOutOfRangeException(paramName, arg, message);
        }

        /// <summary>
        /// Checks if a given value is neither null nor empty and throws a respective exception otherwise.
        /// </summary>
        /// <param name="arg">The value of the parameter that should be checked.</param>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">An Object array containing zero or more objects to format. </param>
        /// <exception cref="ArgumentNullException">Thrown when the value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the value is empty.</exception>
        [DebuggerStepThrough]
        static public void AssertNotEmpty([ValidatedNotNull]ICollection arg, string paramName, string format, params object[] args)
        {
            AssertNotNull(arg, paramName, format, args);
            if (arg.Count == 0)
                ThrowArgumentOutOfRangeException(paramName, arg, SafeFormat(format, args));
        }

        /// <summary>
        /// Checks if a given value is neither null nor empty and throws a respective exception otherwise.
        /// </summary>
        /// <param name="arg">The value of the parameter that should be checked.</param>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <exception cref="ArgumentNullException">Thrown when the value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the value is empty.</exception>
        [DebuggerStepThrough]
        static public void AssertNotEmpty([ValidatedNotNull]Guid arg, string paramName)
        {
            if (arg == Guid.Empty)
                ThrowArgumentOutOfRangeException(paramName, arg, null);
        }

        /// <summary>
        /// Checks if a given value is neither null nor empty and throws a respective exception otherwise.
        /// </summary>
        /// <param name="arg">The value of the parameter that should be checked.</param>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <param name="message">A message that describes the error. </param>
        /// <exception cref="ArgumentNullException">Thrown when the value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the value is empty.</exception>
        [DebuggerStepThrough]
        static public void AssertNotEmpty([ValidatedNotNull]Guid arg, string paramName, string message)
        {
            if (arg == Guid.Empty)
                ThrowArgumentOutOfRangeException(paramName, arg, message);
        }

        /// <summary>
        /// Checks if a given value is neither null nor empty and throws a respective exception otherwise.
        /// </summary>
        /// <param name="arg">The value of the parameter that should be checked.</param>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">An Object array containing zero or more objects to format. </param>
        /// <exception cref="ArgumentNullException">Thrown when the value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the value is empty.</exception>
        [DebuggerStepThrough]
        static public void AssertNotEmpty([ValidatedNotNull]Guid arg, string paramName, string format, params object[] args)
        {
            if (arg == Guid.Empty)
                ThrowArgumentOutOfRangeException(paramName, arg, SafeFormat(format, args));
        }

        /// <summary>
        /// Checks if a given condition is met and throws a respective exception otherwise.
        /// </summary>
        /// <param name="condition">The condition that has to be true, otherwise an exception is thrown.</param>
        /// <param name="arg">The value of the parameter that should be checked.</param>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">An Object array containing zero or more objects to format. </param>
        /// <exception cref="ArgumentNullException">Thrown when the value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the value is empty.</exception>
        [DebuggerStepThrough]
        static public void AssertCondition(bool condition, string paramName, object arg,
        string format, params object[] args)
        {
            if (!condition)
                ThrowArgumentOutOfRangeException(paramName, arg, SafeFormat(format, args));
        }

        /// <summary>
        /// Checks if a given condition is met and throws a respective exception otherwise.
        /// </summary>
        /// <param name="condition">The condition that has to be true, otherwise an exception is thrown.</param>
        /// <param name="arg">The value of the parameter that should be checked.</param>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <param name="message">A message that describes the error. </param>
        /// <exception cref="ArgumentNullException">Thrown when the value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the value is empty.</exception>
        [DebuggerStepThrough]
        static public void AssertCondition(bool condition, string paramName, object arg, string message)
        {
            if (!condition)
                ThrowArgumentOutOfRangeException(paramName, arg, message);

        }

        /// <summary>
        /// Checks if a given condition is met and throws a respective exception otherwise.
        /// </summary>
        /// <param name="condition">The condition that has to be true, otherwise an exception is thrown.</param>
        /// <param name="arg">The value of the parameter that should be checked.</param>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <exception cref="ArgumentNullException">Thrown when the value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the value is empty.</exception>
        [DebuggerStepThrough]
        static public void AssertCondition(bool condition, string paramName, object arg)
        {
            if (!condition)
                ThrowArgumentOutOfRangeException(paramName, arg, "Condition not met!");
        }

        /// <summary>
        /// Helper method: Replaces <see cref="String.Format"/>.
        /// 
        /// Replaces each format item in a specified String with the text equivalent of 
        /// a corresponding Object instance in a specified array. 
        /// </summary
        /// <remarks>
        /// Contrary to <see cref="String.Format"/>, this method does not throw an exception.
        /// Rather in case of an error it returns a descriptive string describing that error.
        /// This is done to avoid having a subsequent string format error obscure the original
        /// error that caused this call in the first place.
        /// </remarks>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">An Object array containing zero or more objects to format. </param>
        /// <returns>A copy of format in which the format items have been replaced by the String 
        /// equivalent of the corresponding instances of Object in args. </returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes",
            Justification = "No exceptions during error handling!")]
        static string SafeFormat(string format, params object[] args)
        {
            try
            {
                return string.Format(format, args);
            }
            catch (Exception ex)
            {
                return "Format failure: " + ex.Message + Environment.NewLine +
                format + " with " + args.Length + " arguments.";
            }
        }

        /// <summary>
        /// report invalid switch value.
        /// </summary>
        /// <param name="variable">The variable.</param>
        /// <param name="value">The value.</param>
        [DebuggerStepThrough]
        public static void InvalidSwitchValue(string variable, object value)
        {
            string msg = string.Format("Invalid switch value '{1}' for '{0}'.", variable ?? NULL_PARAM, value ?? NULL_VALUE);
            throw new InvalidOperationException(msg);
        }

        private static void ThrowArgumentNullException(string paramName, string message)
        {
            if (message == null)
                message = "Argument ‘" + paramName ?? NULL_PARAM + "’ should not be NULL!";
            throw new ArgumentNullException(paramName, message);
        }

        private static void ThrowArgumentOutOfRangeException(string paramName, object actualValue, string message)
        {
            if (message == null)
                message = "Argument ‘" + (paramName ?? NULL_PARAM) + "’ should not be empty!";
#if SILVERLIGHT
            throw new ArgumentOutOfRangeException(paramName, message);
#else
            throw new ArgumentOutOfRangeException(paramName, actualValue ?? NULL_VALUE, message);
#endif
        }

        /// <summary>
        /// Workaround to support FxCop; 
        /// see http://connect.microsoft.com/VisualStudio/feedback/details/567917/code-analysis-doesnt-resolve-copy-local-false-references
        /// </summary>
        [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
        internal sealed class ValidatedNotNullAttribute : Attribute
        {
        }
    }
}
