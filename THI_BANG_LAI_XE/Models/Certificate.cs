using System;
using System.Collections.Generic;

namespace THI_BANG_LAI_XE.Models;

public partial class Certificate
{
    public long CertificatesId { get; set; }

    public long UserId { get; set; }

    public DateOnly IssuedDate { get; set; }

    public DateOnly ExpirationDate { get; set; }

    public string CertificateCode { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
