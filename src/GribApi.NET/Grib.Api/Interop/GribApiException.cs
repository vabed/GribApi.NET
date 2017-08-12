﻿// Copyright 2015 Eric Millin
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;

namespace Grib.Api.Interop
{
    public class GribApiException : Exception
    {
        protected GribApiException (string msg) : base(msg) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GribApiException"/> class.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="innerException">The inner exception.</param>
        public GribApiException (string msg, Exception innerException = null) : base(msg, innerException)
        {
        }

        /// <summary>
        /// Creates a GribApiException instance using an error code returned by grib_api.
        /// </summary>
        /// <param name="errCode">The error code.</param>
        /// <returns></returns>
        public static GribApiException Create (int errCode)
        {
            int index = Math.Abs(errCode);

            // convert code to a usable index when the negative error pattern changes
            if (errCode > 0)
            {
                index = errCode + 66;
            }

            return new GribApiException("Error occurred: " + errCode + ". " + Messages[index]);
        }

        protected static readonly string[] Messages = new[] {
            "No error",		/* 0 GRIB_SUCCESS */
            "End of resource reached",		/* -1 GRIB_END_OF_FILE */
            "Internal error",		/* -2 GRIB_INTERNAL_ERROR */
            "Passed buffer is too small",		/* -3 GRIB_BUFFER_TOO_SMALL */
            "Function not yet implemented",		/* -4 GRIB_NOT_IMPLEMENTED */
            "Missing 7777 at end of message",		/* -5 GRIB_7777_NOT_FOUND */
            "Passed array is too small",		/* -6 GRIB_ARRAY_TOO_SMALL */
            "File not found",		/* -7 GRIB_FILE_NOT_FOUND */
            "Code not found in code table",		/* -8 GRIB_CODE_NOT_FOUND_IN_TABLE */
            "Array size mismatch",		/* -9 GRIB_WRONG_ARRAY_SIZE */
            "Key/value not found",		/* -10 GRIB_NOT_FOUND */
            "Input output problem",		/* -11 GRIB_IO_PROBLEM */
            "Message invalid",		/* -12 GRIB_INVALID_MESSAGE */
            "Decoding invalid",		/* -13 GRIB_DECODING_ERROR */
            "Encoding invalid",		/* -14 GRIB_ENCODING_ERROR */
            "Code cannot unpack because of string too small",		/* -15 GRIB_NO_MORE_IN_SET */
            "Problem with calculation of geographic attributes",		/* -16 GRIB_GEOCALCULUS_PROBLEM */
            "Memory allocation error",		/* -17 GRIB_OUT_OF_MEMORY */
            "Value is read only",		/* -18 GRIB_READ_ONLY */
            "Invalid argument",		/* -19 GRIB_INVALID_ARGUMENT */
            "Null handle",		/* -20 GRIB_NULL_HANDLE */
            "Invalid section number",		/* -21 GRIB_INVALID_SECTION_NUMBER */
            "Value cannot be missing",		/* -22 GRIB_VALUE_CANNOT_BE_MISSING */
            "Wrong message length",		/* -23 GRIB_WRONG_LENGTH */
            "Invalid key type",		/* -24 GRIB_INVALID_TYPE */
            "Unable to set step",		/* -25 GRIB_WRONG_STEP */
            "Wrong units for step (step must be integer)",		/* -26 GRIB_WRONG_STEP_UNIT */
            "Invalid file id",		/* -27 GRIB_INVALID_FILE */
            "Invalid grib id",		/* -28 GRIB_INVALID_GRIB */
            "Invalid index id",		/* -29 GRIB_INVALID_INDEX */
            "Invalid iterator id",		/* -30 GRIB_INVALID_ITERATOR */
            "Invalid keys iterator id",		/* -31 GRIB_INVALID_KEYS_ITERATOR */
            "Invalid nearest id",		/* -32 GRIB_INVALID_NEAREST */
            "Invalid order by",		/* -33 GRIB_INVALID_ORDERBY */
            "Missing a key from the fieldset",		/* -34 GRIB_MISSING_KEY */
            "The point is out of the grid area",		/* -35 GRIB_OUT_OF_AREA */
            "Concept no match",		/* -36 GRIB_CONCEPT_NO_MATCH */
            "Hash array no match",		/* -37 GRIB_HASH_ARRAY_NO_MATCH */
            "Definitions files not found",		/* -38 GRIB_NO_DEFINITIONS */
            "Wrong type while packing",		/* -39 GRIB_WRONG_TYPE */
            "End of resource",		/* -40 GRIB_END */
            "Unable to code a field without values",		/* -41 GRIB_NO_VALUES */
            "Grid description is wrong or inconsistent",		/* -42 GRIB_WRONG_GRID */
            "End of index reached",		/* -43 GRIB_END_OF_INDEX */
            "Null index",		/* -44 GRIB_NULL_INDEX */
            "End of resource reached when reading message",		/* -45 GRIB_PREMATURE_END_OF_FILE */
            "An internal array is too small",		/* -46 GRIB_INTERNAL_ARRAY_TOO_SMALL */
            "Message is too large for the current architecture",		/* -47 GRIB_MESSAGE_TOO_LARGE */
            "Constant field",		/* -48 GRIB_CONSTANT_FIELD */
            "Switch unable to find a matching case",		/* -49 GRIB_SWITCH_NO_MATCH */
            "Underflow",		/* -50 GRIB_UNDERFLOW */
            "Message malformed",		/* -51 GRIB_MESSAGE_MALFORMED */
            "Index is corrupted",		/* -52 GRIB_CORRUPTED_INDEX */
            "Invalid number of bits per value",		/* -53 GRIB_INVALID_BPV */
            "Edition of two messages is different",		/* -54 GRIB_DIFFERENT_EDITION */
            "Value is different",		/* -55 GRIB_VALUE_DIFFERENT */
            "Invalid key value",		/* -56 GRIB_INVALID_KEY_VALUE */
            "String is smaller than requested",		/* -57 GRIB_STRING_TOO_SMALL */
            "Wrong type conversion",		/* -58 GRIB_WRONG_CONVERSION */
            "Missing BUFR table entry for descriptor",		/* -59 GRIB_MISSING_BUFR_ENTRY */
            "Null pointer",		/* -60 GRIB_NULL_POINTER */
            "Attribute is already present, cannot add",		/* -61 GRIB_ATTRIBUTE_CLASH */
            "Too many attributes. Increase MAX_ACCESSOR_ATTRIBUTES",		/* -62 GRIB_TOO_MANY_ATTRIBUTES */
            "Attribute not found.",		/* -63 GRIB_ATTRIBUTE_NOT_FOUND */
            "Edition not supported.",		/* -64 GRIB_UNSUPPORTED_EDITION */
            "Value out of coding range",		/* -65 GRIB_OUT_OF_RANGE */
            "Size of bitmap is incorrect",		/* -66 GRIB_WRONG_BITMAP_SIZE */
            "Value mismatch",		/* 1 GRIB_VALUE_MISMATCH */
            "double values are different",		/* 2 GRIB_DOUBLE_VALUE_MISMATCH */
            "long values are different",		/* 3 GRIB_LONG_VALUE_MISMATCH */
            "byte values are different",		/* 4 GRIB_BYTE_VALUE_MISMATCH */
            "string values are different",		/* 5 GRIB_STRING_VALUE_MISMATCH */
            "Offset mismatch",		/* 6 GRIB_OFFSET_MISMATCH */
            "Count mismatch",		/* 7 GRIB_COUNT_MISMATCH */
            "Name mismatch",		/* 8 GRIB_NAME_MISMATCH */
            "Type mismatch",		/* 9 GRIB_TYPE_MISMATCH */
            "Type and value mismatch",		/* 10 GRIB_TYPE_AND_VALUE_MISMATCH */
            "Unable to compare accessors",		/* 11 GRIB_UNABLE_TO_COMPARE_ACCESSORS */
            "Unable to reset iterator",		/* 12 GRIB_UNABLE_TO_RESET_ITERATOR */
            "Assertion failure",		/* 13 GRIB_ASSERTION_FAILURE */
        };
    }

    public class GribApiFatalException : Exception
    {
        public GribApiFatalException () : this("") { }

        public GribApiFatalException (string msg) : base(msg) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GribApiException"/> class.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="innerException">The inner exception.</param>
		public GribApiFatalException (string msg, Exception innerException = null)
                    : base(msg, innerException)
        {
        }
    }
}
