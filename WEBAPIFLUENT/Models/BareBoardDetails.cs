﻿using Org.BouncyCastle.Math;

namespace WEBAPIFLUENT.Models
{
    public class BareBoardDetails
    {
        public int Id { get; set; }
        public string ImageName { get; set; }

        public int IId { get; set; }
        public Identity Identity { get; set; }
    }
}
