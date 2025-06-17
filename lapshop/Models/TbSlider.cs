﻿using System;
using System.Collections.Generic;

namespace lapshop.Models;

public partial class TbSlider
{
    public int SliderId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string ImageName { get; set; } = null!;
}
