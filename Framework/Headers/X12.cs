﻿//---------------------------------------------------------------------
// This file is part of ediFabric
//
// Copyright (c) ediFabric. All rights reserved.
//
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
// KIND, WHETHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
// PURPOSE.
//---------------------------------------------------------------------

using System.Xml.Serialization;

namespace EdiFabric.Framework.Headers
{
    /// <summary>
    /// This class represents the X12 interchange header.
    /// </summary>
    [XmlRoot(Namespace = "www.edifabric.com/x12")]
    public class S_ISA
    {
        [XmlElement(Order = 0)]
        public string D_744_1 { get; set; }

        [XmlElement(Order = 1)]
        public string D_745_2 { get; set; }

        [XmlElement(Order = 2)]
        public string D_746_3 { get; set; }

        [XmlElement(Order = 3)]
        public string D_747_4 { get; set; }

        [XmlElement(Order = 4)]
        public string D_704_5 { get; set; }

        [XmlElement(Order = 5)]
        public string D_705_6 { get; set; }

        [XmlElement(Order = 6)]
        public string D_704_7 { get; set; }

        [XmlElement(Order = 7)]
        public string D_706_8 { get; set; }

        [XmlElement(Order = 8)]
        public string D_373_9 { get; set; }

        [XmlElement(Order = 9)]
        public string D_337_10 { get; set; }

        [XmlElement(Order = 10)]
        public string D_726_11 { get; set; }

        [XmlElement(Order = 11)]
        public string D_703_12 { get; set; }

        [XmlElement(Order = 12)]
        public string D_709_13 { get; set; }

        [XmlElement(Order = 13)]
        public string D_749_14 { get; set; }

        [XmlElement(Order = 14)]
        public string D_748_15 { get; set; }

        [XmlElement(Order = 15)]
        public string D_701_16 { get; set; }
    }

    /// <summary>
    /// This class represents the X12 group header.
    /// </summary>
    [XmlRoot(Namespace = "www.edifabric.com/x12")]
    public class S_GS
    {
        [XmlElement(Order = 0)]
        public string D_479_1 { get; set; }

        [XmlElement(Order = 1)]
        public string D_142_2 { get; set; }

        [XmlElement(Order = 2)]
        public string D_124_3 { get; set; }

        [XmlElement(Order = 3)]
        public string D_29_4 { get; set; }

        [XmlElement(Order = 4)]
        public string D_30_5 { get; set; }

        [XmlElement(Order = 5)]
        public string D_28_6 { get; set; }

        [XmlElement(Order = 6)]
        public string D_455_7 { get; set; }

        [XmlElement(Order = 7)]
        public string D_480_8 { get; set; }
    }

    /// <summary>
    /// This class represents the X12 group trailer.
    /// </summary>
    [XmlRoot(Namespace = "www.edifabric.com/x12")]
    public class S_GE
    {
        [XmlElement(Order = 0)]
        public string D_97_1 { get; set; }

        [XmlElement(Order = 1)]
        public string D_28_2 { get; set; }
    }

    /// <summary>
    /// This class represents the X12 interchange trailer.
    /// </summary>
    [XmlRoot(Namespace = "www.edifabric.com/x12")]
    public class S_IEA
    {
        [XmlElement(Order = 0)]
        public string D_405_1 { get; set; }

        [XmlElement(Order = 1)]
        public string D_709_2 { get; set; }
    }
}