﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.CommonSenseMedia
{
    /// <summary>
    /// Data model used as a strongly-typed interface for inserting new Assistive Tools reviews into Sitecore
    /// </summary>
    public class ReviewModel
    {
        /// <summary>
        /// Title of review. Also used for Name
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// What Kids Can Learn multi-line content
        /// </summary>
        public string WhatKidsCanLearn { get; set; }

        /// <summary>
        /// Any Good multi-line content
        /// </summary>
        public string AnyGood { get; set; }

        /// <summary>
        /// How Parents Can Help multi-line content
        /// </summary>
        public string HowParentsCanHelp { get; set; }

        /// <summary>
        /// Description multi-line content
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Summary single-line content
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// External Link single-line content, used for Websites
        /// </summary>
        public string ExternalLink { get; set; }

        /// <summary>
        /// Quality rank single-line content
        /// </summary>
        public string QualityRank { get; set; }

        /// <summary>
        /// Learning rank single-line content
        /// </summary>
        public string LearningRank { get; set; }

        /// <summary>
        /// Target Grade single-line content
        /// </summary>
        public string TargetGrade { get; set; }

        /// <summary>
        /// Off Grade single-line content
        /// </summary>
        public string OffGrade { get; set; }

        /// <summary>
        /// On Grade single-line content
        /// </summary>
        public string OnGrade { get; set; }

        /// <summary>
        /// CSV of Genres to lookup and relate
        /// </summary>
        public string Genres { get; set; }

        /// <summary>
        /// CSV of Subjects to relate
        /// </summary>
        public string Subjects { get; set; }

        /// <summary>
        /// CSV of Skills to lookup and relate
        /// </summary>
        public string Skills { get; set; }

        /// <summary>
        /// CSV of Categories to lookup and relate
        /// </summary>
        public string Categories { get; set; }

        /// <summary>
        /// CSV of Platforms to lookup and relate
        /// </summary>
        public string Platforms { get; set; }

        /// <summary>
        /// Type to lookup and relate
        /// </summary>
        public string Type { get; set; }
        
        /// <summary>
        /// ReviewImages to use as Screenshots
        /// </summary>
        public List<ReviewImage> Screenshots { get; set; }

        /// <summary>
        /// ReviewImage to use as the Thumbnail
        /// </summary>
        public ReviewImage Thumbnail { get; set; }
    }

    /// <summary>
    /// Class for defining the parts of a ReviewImage
    /// </summary>
    public class ReviewImage
    {
        /// <summary>
        /// URL to image
        /// </summary>
        public string URL { get; set; }

        /// <summary>
        /// Alt-text to use for the image
        /// </summary>
        public string AltText { get; set; }

        /// <summary>
        /// Name to use for the image
        /// </summary>
        public string Name { get; set; }
    }
}
