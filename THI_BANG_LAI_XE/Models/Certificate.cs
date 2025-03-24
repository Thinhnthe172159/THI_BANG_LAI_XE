using System;
using System.Collections.Generic;

namespace THI_BANG_LAI_XE.Models;

public partial class Certificate
{
    public long CertificatesId { get; set; }

    public long UserId { get; set; }

    public DateTime IssuedDate { get; set; }

    public DateTime ExpirationDate { get; set; }

    public string CertificateCode { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
