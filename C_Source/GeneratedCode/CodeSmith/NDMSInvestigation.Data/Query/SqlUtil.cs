﻿#region Using Directives
using System;
using System.Configuration;
using System.Text;
#endregion

namespace NDMSInvestigation.Data
{
	/// <summary>
	/// Provides utility methods for generating SQL expressions.
	/// </summary>
	[CLSCompliant(true)]
	public static class SqlUtil
	{
		#region Declarations

		/// <summary>
		/// SQL AND keyword.
		/// </summary>
		public static readonly String AND  = "AND";
		/// <summary>
		/// SQL OR keyword.
		/// </summary>
		public static readonly String OR   = "OR";
		/// <summary>
		/// SQL ASC keyword.
		/// </summary>
		public static readonly String ASC  = "ASC";
		/// <summary>
		/// SQL DESC keyword.
		/// </summary>
		public static readonly String DESC = "DESC";
		/// <summary>
		/// SQL NULL keyword.
		/// </summary>
		public static readonly String NULL = "NULL";
		/// <summary>
		/// Used to represent quoted search terms.
		/// </summary>
		public static readonly String TOKEN = "@@@";
		/// <summary>
		/// Delimiter for quoted search terms.
		/// </summary>
		public static readonly String QUOTE = "\"";
		/// <summary>
		/// Used as wildcard character within search text.
		/// </summary>
		public static readonly String STAR  = "*";
		/// <summary>
		/// SQL wildcard character.
		/// </summary>
		public static readonly String WILD  = "%";
		/// <summary>
		/// SQL grouping open character.
		/// </summary>
		public static readonly String LEFT  = "(";
		/// <summary>
		/// SQL grouping close character.
		/// </summary>
		public static readonly String RIGHT = ")";
		/// <summary>
		/// Delimiter for optional search terms.
		/// </summary>
		public static readonly String COMMA = ",";
		
		/// <summary>
		/// PageIndex Temp Table
		/// </summary>
		public static readonly String PAGE_INDEX = "#PageIndex";

		#endregion Declarations

		#region Equals

		/// <summary>
		/// Creates an <see cref="SqlComparisonType.Equals"/> expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static String Equals(String column, String value)
		{
			return Equals(column, value, false);
		}

		/// <summary>
		/// Creates an <see cref="SqlComparisonType.Equals"/> expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <param name="ignoreCase"></param>
		/// <returns></returns>
		public static String Equals(String column, String value, bool ignoreCase)
		{
			return Equals(column, value, ignoreCase, true);
		}

		/// <summary>
		/// Creates an <see cref="SqlComparisonType.Equals"/> expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <param name="ignoreCase"></param>
		/// <param name="surround"></param>
		/// <returns></returns>
		public static String Equals(String column, String value, bool ignoreCase, bool surround)
		{
			if ( String.IsNullOrEmpty(value) ) return IsNull(column);
			return String.Format(GetEqualFormat(ignoreCase, surround), column, Equals(value));
		}

		/// <summary>
		/// Encodes the value for a <see cref="SqlComparisonType.Equals"/> expression.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static String Equals(String value)
		{
			return String.Format("{0}", Encode(value));
		}

		#endregion Equals

		#region Contains

		/// <summary>
		/// Creates a <see cref="SqlComparisonType.Contains"/> expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static String Contains(String column, String value)
		{
			return Contains(column, value, false);
		}

		/// <summary>
		/// Creates a <see cref="SqlComparisonType.Contains"/> expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <param name="ignoreCase"></param>
		/// <returns></returns>
		public static String Contains(String column, String value, bool ignoreCase)
		{
			return Contains(column, value, ignoreCase, true);
		}

		/// <summary>
		/// Creates a <see cref="SqlComparisonType.Contains"/> expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <param name="ignoreCase"></param>
		/// <param name="surround"></param>
		/// <returns></returns>
		public static String Contains(String column, String value, bool ignoreCase, bool surround)
		{
			if ( String.IsNullOrEmpty(value) ) return IsNull(column);
			return String.Format(GetLikeFormat(ignoreCase, surround), column, Contains(value));
		}

		/// <summary>
		/// Encodes the value for a <see cref="SqlComparisonType.Contains"/> expression.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static String Contains(String value)
		{
			return String.Format("%{0}%", Encode(value));
		}

		#endregion Contains
		
		#region NotContains

        /// <summary>
        /// Creates a <see cref="SqlComparisonType.NotContains"/> expression.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static String NotContains(String column, String value)
        {
            return NotContains(column, value, false);
        }

        /// <summary>
        /// Creates a <see cref="SqlComparisonType.NotContains"/> expression.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static String NotContains(String column, String value, bool ignoreCase)
        {
            return NotContains(column, value, ignoreCase, true);
        }

        /// <summary>
        /// Creates a <see cref="SqlComparisonType.NotContains"/> expression.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <param name="ignoreCase"></param>
        /// <param name="surround"></param>
        /// <returns></returns>
        public static String NotContains(String column, String value, bool ignoreCase, bool surround)
        {
            if (String.IsNullOrEmpty(value)) return IsNull(column);
            return String.Format(GetNotLikeFormat(ignoreCase, surround), column, NotContains(value));
        }

        /// <summary>
        /// Encodes the value for a <see cref="SqlComparisonType.NotContains"/> expression.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static String NotContains(String value)
        {
            return String.Format("%{0}%", Encode(value));
        }

        #endregion Contains

		#region StartsWith

		/// <summary>
		/// Creates a <see cref="SqlComparisonType.StartsWith"/> expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static String StartsWith(String column, String value)
		{
			return StartsWith(column, value, false);
		}

		/// <summary>
		/// Creates a <see cref="SqlComparisonType.StartsWith"/> expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <param name="ignoreCase"></param>
		/// <returns></returns>
		public static String StartsWith(String column, String value, bool ignoreCase)
		{
			return StartsWith(column, value, ignoreCase, true);
		}

		/// <summary>
		/// Creates a <see cref="SqlComparisonType.StartsWith"/> expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <param name="ignoreCase"></param>
		/// <param name="surround"></param>
		/// <returns></returns>
		public static String StartsWith(String column, String value, bool ignoreCase, bool surround)
		{
			if ( String.IsNullOrEmpty(value) ) return IsNull(column);
			return String.Format(GetLikeFormat(ignoreCase, surround), column, StartsWith(value));
		}

		/// <summary>
		/// Encodes the value for a <see cref="SqlComparisonType.StartsWith"/> expression.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static String StartsWith(String value)
		{
			return String.Format("{0}%", Encode(value));
		}

		#endregion StartsWith

		#region EndsWith

		/// <summary>
		/// Creates a <see cref="SqlComparisonType.EndsWith"/> expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static String EndsWith(String column, String value)
		{
			return EndsWith(column, value, false);
		}

		/// <summary>
		/// Creates a <see cref="SqlComparisonType.EndsWith"/> expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <param name="ignoreCase"></param>
		/// <returns></returns>
		public static String EndsWith(String column, String value, bool ignoreCase)
		{
			return EndsWith(column, value, ignoreCase, true);
		}

		/// <summary>
		/// Creates a <see cref="SqlComparisonType.EndsWith"/> expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <param name="ignoreCase"></param>
		/// <param name="surround"></param>
		/// <returns></returns>
		public static String EndsWith(String column, String value, bool ignoreCase, bool surround)
		{
			if ( String.IsNullOrEmpty(value) ) return IsNull(column);
			return String.Format(GetLikeFormat(ignoreCase, surround), column, EndsWith(value));
		}

		/// <summary>
		/// Encodes the value for a <see cref="SqlComparisonType.EndsWith"/> expression.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static String EndsWith(String value)
		{
			return String.Format("%{0}", Encode(value));
		}

		#endregion EndsWith

		#region Like

		/// <summary>
		/// Creates a <see cref="SqlComparisonType.Like"/> expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static String Like(String column, String value)
		{
			return Like(column, value, false);
		}

		/// <summary>
		/// Creates a <see cref="SqlComparisonType.Like"/> expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <param name="ignoreCase"></param>
		/// <returns></returns>
		public static String Like(String column, String value, bool ignoreCase)
		{
			return Like(column, value, ignoreCase, true);
		}

		/// <summary>
		/// Creates a <see cref="SqlComparisonType.Like"/> expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <param name="ignoreCase"></param>
		/// <param name="surround"></param>
		/// <returns></returns>
		public static String Like(String column, String value, bool ignoreCase, bool surround)
		{
			if ( String.IsNullOrEmpty(value) ) return IsNull(column);
			return String.Format(GetLikeFormat(ignoreCase, surround), column, Like(value));
		}

		/// <summary>
		/// Encodes the value for a <see cref="SqlComparisonType.Like"/> expression.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static String Like(String value)
		{
			return String.Format("{0}", Encode(value));
		}

		#endregion Like
		
		#region NotLike

		/// <summary>
		/// Creates a <see cref="SqlComparisonType.NotLike"/> expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static String NotLike(String column, String value)
		{
			return NotLike(column, value, false);
		}

		/// <summary>
		/// Creates a <see cref="SqlComparisonType.NotLike"/> expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <param name="ignoreCase"></param>
		/// <returns></returns>
		public static String NotLike(String column, String value, bool ignoreCase)
		{
			return NotLike(column, value, ignoreCase, true);
		}

		/// <summary>
		/// Creates a <see cref="SqlComparisonType.NotLike"/> expression.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <param name="ignoreCase"></param>
		/// <param name="surround"></param>
		/// <returns></returns>
		public static String NotLike(String column, String value, bool ignoreCase, bool surround)
		{
			if ( String.IsNullOrEmpty(value) ) return IsNull(column);
			return String.Format(GetNotLikeFormat(ignoreCase, surround), column, Like(value));
		}

		/// <summary>
		/// Encodes the value for a <see cref="SqlComparisonType.NotLike"/> expression.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static String NotLike(String value)
		{
			return String.Format("{0}", Encode(value));
		}

		#endregion Like

		#region Null/Not Null

		/// <summary>
		/// Creates an IS NULL expression.
		/// </summary>
		/// <param name="column"></param>
		/// <returns></returns>
		public static String IsNull(String column)
		{
			return String.Format("{0} IS NULL", column);
		}

		/// <summary>
		/// Creates an IS NOT NULL expression.
		/// </summary>
		/// <param name="column"></param>
		/// <returns></returns>
		public static String IsNotNull(String column)
		{
			return String.Format("{0} IS NOT NULL", column);
		}

		#endregion Null/Not Null

		#region Encode

		/// <summary>
		/// Encodes the specified value for use in SQL expressions.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static String Encode(String value)
		{
			return Encode(value, false);
		}

		/// <summary>
		/// Encodes the specified value for use in SQL expressions and
		/// optionally surrounds the value with single-quotes.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="surround"></param>
		/// <returns></returns>
		public static String Encode(String value, bool surround)
		{
			if ( String.IsNullOrEmpty(value) ) return SqlUtil.NULL;
			String format = surround ? "'{0}'" : "{0}";
			return String.Format(format, value.Replace("'", "''"));
		}

		/// <summary>
		/// Encodes the specified values for use in SQL expressions.
		/// </summary>
		/// <param name="values"></param>
		/// <returns></returns>
		public static String Encode(String[] values)
		{
			return Encode(values, false);
		}

		/// <summary>
		/// Encodes the specified values for use in SQL expressions and
		/// optionally surrounds the value with single-quotes.
		/// </summary>
		/// <param name="values"></param>
		/// <param name="surround"></param>
		/// <returns></returns>
		public static String Encode(String[] values, bool surround)
		{
			if ( values == null || values.Length < 1 )
			{
				return SqlUtil.NULL;
			}

            StringBuilder csv = new StringBuilder();

			foreach (String value in values )
			{
				if ( !String.IsNullOrEmpty(value) )
				{
                    if (csv.Length > 0)
                        csv.Append(",");

                    csv.Append(SqlUtil.Encode(value.Trim(), surround));
				}
			}

			return csv.ToString();
		}
		
		#endregion Encode

		#region Format Methods

		/// <summary>
		/// Gets the like format string.
		/// </summary>
		/// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
		/// <returns></returns>
		public static String GetLikeFormat(bool ignoreCase)
		{
			return GetLikeFormat(ignoreCase, true);
		}

		/// <summary>
		/// Gets the like format string.
		/// </summary>
		/// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
		/// <param name="surround"></param>
		/// <returns></returns>
		public static String GetLikeFormat(bool ignoreCase, bool surround)
		{
			if ( surround )
			{
				return ignoreCase ? "UPPER({0}) LIKE UPPER('{1}')" : "{0} LIKE '{1}'";
			}

			return ignoreCase ? "UPPER({0}) LIKE UPPER({1})" : "{0} LIKE {1}";
		}
		
		/// <summary>
		/// Gets the not like format string.
		/// </summary>
		/// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
		/// <returns></returns>
		public static String GetNotLikeFormat(bool ignoreCase)
		{
			return GetNotLikeFormat(ignoreCase, true);
		}

		/// <summary>
		/// Gets the not like format string.
		/// </summary>
		/// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
		/// <param name="surround"></param>
		/// <returns></returns>
		public static String GetNotLikeFormat(bool ignoreCase, bool surround)
		{
			if ( surround )
			{
				return ignoreCase ? "UPPER({0}) NOT LIKE UPPER('{1}')" : "{0} NOT LIKE '{1}'";
			}

			return ignoreCase ? "UPPER({0}) NOT LIKE UPPER({1})" : "{0} NOT LIKE {1}";
		}
		
		

		/// <summary>
		/// Gets the equal format string.
		/// </summary>
		/// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
		/// <returns></returns>
		public static String GetEqualFormat(bool ignoreCase)
		{
			return GetEqualFormat(ignoreCase, true);
		}

		/// <summary>
		/// Gets the equal format string.
		/// </summary>
		/// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
		/// <param name="surround"></param>
		/// <returns></returns>
		public static String GetEqualFormat(bool ignoreCase, bool surround)
		{
			if ( surround )
			{
				return ignoreCase ? "UPPER({0}) = UPPER('{1}')" : "{0} = '{1}'";
			}

			return ignoreCase ? "UPPER({0}) = UPPER({1})" : "{0} = {1}";
		}

		#endregion Format Methods
	}

	#region SqlComparisonType Enum

	/// <summary>
	/// Enumeration of SQL expression comparison types.
	/// </summary>
	public enum SqlComparisonType
	{
		/// <summary>
		/// Represents = value.
		/// </summary>
		Equals,
		/// <summary>
		/// Represents LIKE value%.
		/// </summary>
		StartsWith,
		/// <summary>
		/// Represents LIKE %value.
		/// </summary>
		EndsWith,
		/// <summary>
		/// Represents LIKE %value%.
		/// </summary>
		Contains,
        /// <summary>
        /// Represents NOT LIKE %value%.
        /// </summary>
        NotContains,
		/// <summary>
		/// Represents LIKE value.
		/// </summary>
		Like,
		/// <summary>
		/// Represents NOT LIKE value.
		/// </summary>
		NotLike

	}

	#endregion SqlComparisonType Enum
	
	#region SqlFilterType Enum

    /// <summary>
    /// Enumeration of SQL Filter Types.
    /// </summary>
    public enum SqlFilterType
    {
        /// <summary>
        /// Represents an Individual Word filter
        /// </summary>
        /// <example>(if using <see cref="SqlComparisonType.Contains"/>) CompanyName LIKE "%Acme" AND CompanyName LIKE "Company%"</example>
        Word,
        /// <summary>
        /// Represents a Phrase filter
        /// </summary>
        /// <example>(if using <see cref="SqlComparisonType.Contains"/>) CompanyName LIKE "%Acme Company%"</example>
        Phrase
    }

    #endregion
	
	#region SqlSortDirection Enum
	
	/// <summary>
    /// Enumeration of SQL expression Sort Directions
    /// </summary>
    public enum SqlSortDirection
    {
        /// <summary>
        /// Database Ascending
        /// </summary>
        ASC,

        /// <summary>
        /// Database Descending
        /// </summary>
        DESC
    } 
	
	#endregion 
}
