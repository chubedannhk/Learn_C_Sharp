﻿using System;
using System.Collections.Generic;

namespace QuanLyHoaDon.Models;

public partial class TransactionDetail
{
    public int TransId { get; set; }

    public int? AccId { get; set; }

    public decimal? TransMonry { get; set; }

    public int? TransType { get; set; }

    public DateTime? DateOfTrans { get; set; }

    public virtual Account? Acc { get; set; }
}